using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneFarms.Helpers;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using Tesseract;
using System.Drawing.Imaging;
using System.IO;



namespace PhoneFarms.Managers
{
    public static class DeviceManager
    {
        //BASIC USER GESTURES
        public static async Task HandleInput(string device, string text)
        {
            await ADBHelper.ExecuteAdbCommandAsync(device, "shell input text " + text);
            await Task.Delay(3000);
        }

        public static async Task OpenChromeByURL(string device,string url)
        {
            await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.intent.action.VIEW -d "+url+" com.android.chrome");
            await Task.Delay(1000);
        }

        public static async Task GoBackToHomeScreenAsync(string device)
        {
            try
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell input keyevent KEYCODE_HOME");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error going back to home screen on device {device}: {ex.Message}");
            }
        }

        public static async Task Swipe(string device, int time, int startX, int startY, int endX, int endY,int delay)
        {
            for (int i = 0; i < time; i++)
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell input swipe " + startX + " " + startY + " " + endX + " " + endY + " 100");
                await Task.Delay(delay);
            }
        }

        public static async Task HandlePressEnter(string device)
        {
            await ADBHelper.ExecuteAdbCommandAsync(device, "shell input keyevent 66");
        }

        public static async Task<bool> TapAsync(string device, int x, int y)
        {
            try
            {
                // Construct the adb command to simulate a tap
                string command = $"shell input tap {x} {y}";

                // Execute the adb command
                await ADBHelper.ExecuteAdbCommandAsync(device, command);

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error tapping at coordinates ({x}, {y}) on device {device}: {ex.Message}");
                return false;
            }
        }

        public static async Task InstallApkAsync(string device, string apkPath)
        {
            string command = $"install -r {apkPath}";
            await ADBHelper.ExecuteAdbCommandAsync(device, command);
        }

        //HANDLE READING SCREEN CONTENT
        public static async Task DumpUIHierarchyAsync(string device)
        {
            try
            {
                // Dump the UI hierarchy to a file on the device
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell uiautomator dump /data/local/tmp/ui.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dumping UI hierarchy on device {device}: {ex.Message}");
            }
        }

        public static async Task<string> PullUIHierarchyFileAsync(string device)
        {
            try
            {
                // Pull the dumped file from device to local machine
                string localFilePath = $"./ui_{device}.xml";
                await ADBHelper.ExecuteAdbCommandAsync(device, $"pull /data/local/tmp/ui.xml {localFilePath}");
                return localFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error pulling UI hierarchy file from device {device}: {ex.Message}");
                return string.Empty;
            }
        }

        public static async Task<bool> TapButtonWithTextAsync(string device, string buttonText)
        {
            // Step 1: Dump UI hierarchy
            await DumpUIHierarchyAsync(device);

            // Step 2: Pull the XML file
            string localFilePath = await PullUIHierarchyFileAsync(device);

            if (string.IsNullOrEmpty(localFilePath))
            {
                return false;
            }

            // Step 3: Parse the XML file
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(localFilePath);

                // Find the node with the specified text
                XmlNode node = xmlDoc.SelectSingleNode($"//node[@text='{buttonText}']");

                if (node != null)
                {
                    // Extract the bounds attribute
                    string bounds = node.Attributes["bounds"]?.Value ?? string.Empty;
                    if (!string.IsNullOrEmpty(bounds))
                    {
                        // Parse the bounds to get the coordinates
                        var match = System.Text.RegularExpressions.Regex.Match(bounds, @"\[(\d+),(\d+)\]\[(\d+),(\d+)\]");
                        if (match.Success)
                        {
                            int x1 = int.Parse(match.Groups[1].Value);
                            int y1 = int.Parse(match.Groups[2].Value);
                            int x2 = int.Parse(match.Groups[3].Value);
                            int y2 = int.Parse(match.Groups[4].Value);

                            // Calculate the center of the button
                            int x = (x1 + x2) / 2;
                            int y = (y1 + y2) / 2;

                            // Simulate tap on the button
                            await ADBHelper.ExecuteAdbCommandAsync(device, $"shell input tap {x} {y}");
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing UI hierarchy file or tapping button: {ex.Message}");
                return false;
            }
        }

        //for button clicked
        private static (int x, int y) ExtractCoordinates(string bounds)
        {
            // Example bounds format: "[x1,y1][x2,y2]"
            var match = Regex.Match(bounds, @"\[(\d+),(\d+)\]\[\d+,\d+\]");
            if (match.Success)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                return (x, y);
            }
            return (0, 0);
        }

        public static async Task<string> ClickButtonByTextAsync(string device, string buttonText)
        {
            // Step 1: Dump UI hierarchy
            await DumpUIHierarchyAsync(device);

            // Step 2: Pull the XML file
            string localFilePath = await PullUIHierarchyFileAsync(device);

            if (string.IsNullOrEmpty(localFilePath))
            {
                return "Error pulling UI hierarchy file.";
            }

            // Step 3: Parse the XML file
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(localFilePath);

                // Find the button node with the specified text
                var buttonNode = xmlDoc.SelectSingleNode($"//node[@class='android.widget.Button' and @text='{buttonText}']");

                if (buttonNode == null)
                {
                    return $"No button found with text: {buttonText}";
                }

                // Get the bounds of the button
                string bounds = buttonNode.Attributes["bounds"]?.Value;

                if (string.IsNullOrEmpty(bounds))
                {
                    return "No bounds found for the button.";
                }

                // Extract coordinates from bounds
                var coordinates = ExtractCoordinates(bounds);

                // Perform click action using ADB
                var adbResult = await ExecuteAdbCommandAsync(device, $"input tap {coordinates.x} {coordinates.y}");

                if (adbResult.Contains("error"))
                {
                    return $"Error clicking the button: {adbResult}";
                }

                return $"Button with text '{buttonText}' clicked successfully.";
            }
            catch (Exception ex)
            {
                return $"Error parsing UI hierarchy file: {ex.Message}";
            }
        }

        private static async Task<string> ExecuteAdbCommandAsync(string device, string command)
        {
            // Execute ADB command and return the result
            var processInfo = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = $"-s {device} shell {command}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processInfo))
            {
                var output = await process.StandardOutput.ReadToEndAsync();
                var error = await process.StandardError.ReadToEndAsync();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    return $"Error: {error}";
                }

                return output;
            }
        }

        public static async Task<string> GetDeviceScreenContentAsync(string device)
        {
            // Step 1: Dump UI hierarchy
            await DumpUIHierarchyAsync(device);

            // Step 2: Pull the XML file
            string localFilePath = await PullUIHierarchyFileAsync(device);

            if (string.IsNullOrEmpty(localFilePath))
            {
                return "Error pulling UI hierarchy file.";
            }

            // Step 3: Parse the XML file
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(localFilePath);

                // Extract relevant information (example: all node texts)
                var nodeList = xmlDoc.SelectNodes("//node");
                string screenContent = "";

                foreach (XmlNode node in nodeList)
                {
                    string text = node.Attributes["text"]?.Value ?? string.Empty;
                    string resourceId = node.Attributes["resource-id"]?.Value ?? string.Empty;
                    string className = node.Attributes["class"]?.Value ?? string.Empty;

                    if (!string.IsNullOrEmpty(text))
                    {
                        screenContent += $"Text: {text}, Resource ID: {resourceId}, Class: {className}\n";
                    }
                }

                return screenContent;
            }
            catch (Exception ex)
            {
                return $"Error parsing UI hierarchy file: {ex.Message}";
            }
        }

        public static async Task<string> GetButtonInformationAsync(string device)
        {
            // Step 1: Dump UI hierarchy
            await DumpUIHierarchyAsync(device);

            // Step 2: Pull the XML file
            string localFilePath = await PullUIHierarchyFileAsync(device);

            if (string.IsNullOrEmpty(localFilePath))
            {
                return "Error pulling UI hierarchy file.";
            }

            // Step 3: Parse the XML file
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(localFilePath);

                // Find all button nodes
                var buttonNodes = xmlDoc.SelectNodes("//node[@class='android.widget.Button']");

                if (buttonNodes == null || buttonNodes.Count == 0)
                {
                    return "No buttons found in the UI hierarchy.";
                }

                // Collect button information
                StringBuilder buttonInfo = new StringBuilder();
                foreach (XmlNode node in buttonNodes)
                {
                    string text = node.Attributes["text"]?.Value ?? "No text";
                    string resourceId = node.Attributes["resource-id"]?.Value ?? "No resource ID";
                    string bounds = node.Attributes["bounds"]?.Value ?? "No bounds";

                    buttonInfo.AppendLine($"Button - Text: {text}, Resource ID: {resourceId}, Bounds: {bounds}");
                }

                return buttonInfo.ToString();
            }
            catch (Exception ex)
            {
                return $"Error parsing UI hierarchy file: {ex.Message}";
            }
        }

        public static async Task<bool> IsTextPresentInScreenAsync(string device, string searchText)
        {
            try
            {
                // Step 1: Dump the UI hierarchy to a file on the device
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell uiautomator dump /data/local/tmp/ui.xml");

                // Step 2: Pull the XML file from device to local machine
                string localFilePath = $"./ui_{device}.xml";
                await ADBHelper.ExecuteAdbCommandAsync(device, $"pull /data/local/tmp/ui.xml {localFilePath}");

                // Step 3: Parse the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(localFilePath);

                // Find any node that contains the searchText
                XmlNodeList nodes = xmlDoc.SelectNodes("//node[contains(@text, '" + searchText + "')]");

                // Return true if nodes are found
                return nodes.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking text presence: {ex.Message}");
                return false;
            }
        }


        // END READING SCREEN CONTENT

        public static async Task<int> LoadDevicesAsync(DataGridView dataGridViewDevices)
        {
            int deviceCount = 0;

            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "adb",
                        Arguments = "devices",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (line.EndsWith("device"))
                    {
                        dataGridViewDevices.Rows.Add(false, line.Split('\t')[0], "Not Showing", "");
                        deviceCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading devices: {ex.Message}");
            }
            return deviceCount;
        }

        public static void ShowScreen(string device, List<Process> scrcpyProcesses, DataGridView dataGridViewDevices)
        {
            try
            {
                // Find the row corresponding to the specified device
                DataGridViewRow targetRow = null;
                foreach (DataGridViewRow row in dataGridViewDevices.Rows)
                {
                    if (row.Cells["DeviceID"].Value != null && row.Cells["DeviceID"].Value.ToString() == device)
                    {
                        targetRow = row;
                        break;
                    }
                }

                // If the device is found
                if (targetRow != null)
                {
                    // Start the scrcpy process
                    Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "scrcpy",
                            Arguments = $"-s {device} --window-width 200 --window-height 300",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        },
                        EnableRaisingEvents = true // Enable process exit event
                    };

                    process.Exited += (sender, e) =>
                    {
                        // Update the Screen Status column to "Not Showing"
                        dataGridViewDevices.Invoke((MethodInvoker)delegate
                        {
                            targetRow.Cells["ScreenStatus"].Value = "Not Showing";
                        });
                    };

                    process.Start();
                    scrcpyProcesses.Add(process);

                    // Update the Screen Status column
                    targetRow.Cells["ScreenStatus"].Value = "Showing";
                }
                else
                {
                    MessageBox.Show($"Device {device} not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing screen for device {device}: {ex.Message}");
            }
        }

        public static async Task WifiSetting(string device)
        {
            try
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.intent.action.MAIN -n com.android.settings/.wifi.WifiSettings");
                await Task.Delay(2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting device {device} to Wi-Fi: {ex.Message}");
            }
        }

        public static async Task OpenApp(string device,string appPath)
        {
            try
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -n " + appPath);
                //await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -n com.android.chrome/com.google.android.apps.chrome.Main");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on devices: {ex.Message}");
            }
        }

        public static async Task OpenPlayStoreAndSearchFacebook(string device)
        {
            try
            {
                // Open Google Play Store and search for Facebook
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.intent.action.VIEW -d 'market://search?q=Facebook'");
                await Task.Delay(2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on device {device}: {ex.Message}");
            }
        }

        public static async Task OpenPlayStoreAndSearchFacebookOnMultipleDevices(string[] devices)
        {
            try
            {
                // Create tasks for each device to open Play Store
                var tasks = new Task[devices.Length];
                for (int i = 0; i < devices.Length; i++)
                {
                    tasks[i] = OpenPlayStoreAndSearchFacebook(devices[i]);
                }

                // Wait for all tasks to complete
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on devices: {ex.Message}");
            }
        }

        public static async Task AccessYoutube(string device,string appPath, string videoURL)
        {
            try
            {
                await OpenApp(device, appPath);
                await Task.Delay(3000);
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell input keyevent 84");
                await HandleInput(device,videoURL);
                await Task.Delay(3000);
                await HandlePressEnter(device);
                await Task.Delay(3000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on devices: {ex.Message}");
            }
        }

        public static async Task ReelSwiping(string device)
        {
            Random random = new Random();
            try
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.intent.action.VIEW -d https://www.facebook.com/reel/ com.android.chrome");
                await Task.Delay(3000);
                for (int i = 0; i < 50; i++)
                {               
                    await TapButtonWithTextAsync(device, "Thẻ tiếp theo");
                    await TapButtonWithTextAsync(device, "Next card");
                    await Task.Delay(random.Next(500, 700));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reel: {ex.Message}");
            }
        }
        
        public static async Task ProxyConfig(string device)
        {
            try
            {
                await DeviceManager.OpenApp(device, "com.scheler.superproxy/.activity.MainActivity");
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 950, 1400);
                await Task.Delay(500);
                await DeviceManager.TapButtonWithTextAsync(device,"HTTP");
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 50, 950);
                await DeviceManager.Swipe(device, 1, 250, 880, 250, 480, 0);
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 50, 750);
                await DeviceManager.HandleInput(device, "14.226.231.17");
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 50, 1050);
                await DeviceManager.HandleInput(device, "54926");
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 50, 1150);
                await DeviceManager.HandleInput(device, "sdver");
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 50, 1350);
                await DeviceManager.HandleInput(device, "231df");
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 1000, 100);
                await Task.Delay(500);
                await DeviceManager.TapAsync(device, 50, 1500);
                await Task.Delay(500);
                await GoBackToHomeScreenAsync(device);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reel: {ex.Message}");
            }
        }

        public static async Task DisableRotation(string device)
        {
                try
                {
                    await ADBHelper.ExecuteAdbCommandAsync(device, "shell settings put system accelerometer_rotation 0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening reel: {ex.Message}");
                }
        }
        public static async Task ChangeResolution(string device)
        {
            try
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.settings.DISPLAY_SETTINGS");
                await Task.Delay(2000);
                bool result = await DeviceManager.IsTextPresentInScreenAsync(device, "WQHD(2560x1440)");
                bool result1 = await DeviceManager.IsTextPresentInScreenAsync(device, "HD(1280x720)");
                if (result)
                {
                    await DeviceManager.TapButtonWithTextAsync(device, "WQHD(2560x1440)");
                    await Task.Delay(2000);
                    await DeviceManager.TapAsync(device, 800, 800);
                    await Task.Delay(2000);
                    await DeviceManager.TapButtonWithTextAsync(device, "ÁP DỤNG");
                    await Task.Delay(2000);
                    await DeviceManager.GoBackToHomeScreenAsync(device);
                }
                else if (result1)
                {
                    await DeviceManager.TapButtonWithTextAsync(device, "HD(1280x720)");
                    await Task.Delay(2000);
                    await DeviceManager.TapAsync(device, 400, 400);
                    await Task.Delay(2000);
                    await DeviceManager.TapButtonWithTextAsync(device, "ÁP DỤNG");
                    await Task.Delay(2000);
                    await DeviceManager.GoBackToHomeScreenAsync(device);
                }
                else
                {
                    await DeviceManager.GoBackToHomeScreenAsync(device);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reel: {ex.Message}");
            }
        }
        public static async Task ChangeLanguage(string device)
        {
            try
            {
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.settings.DISPLAY_SETTINGS");
                await Task.Delay(2000);
                bool result1 = await DeviceManager.IsTextPresentInScreenAsync(device, "WQHD(2560x1440)");
                bool result = await DeviceManager.IsTextPresentInScreenAsync(device, "FHD(1920x1080)");
                //await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.settings.LOCALE_SETTINGS");
                if (result)
                {
                    await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.settings.LOCALE_SETTINGS");
                    await Task.Delay(2000);
                    await DeviceManager.TapAsync(device, 800, 800);
                    await Task.Delay(2000);
                    await DeviceManager.TapButtonWithTextAsync(device, "Tiếng Việt (Việt Nam)");
                    await Task.Delay(2000);
                    await DeviceManager.TapAsync(device, 970, 1150);
                    await Task.Delay(2000);
                    await DeviceManager.GoBackToHomeScreenAsync(device);
                }
                else if (result1)
                {
                    await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.settings.LOCALE_SETTINGS");
                    await Task.Delay(2000);
                    await DeviceManager.TapAsync(device, 800, 1050);
                    await Task.Delay(2000);
                    await DeviceManager.TapButtonWithTextAsync(device, "Tiếng Việt (Việt Nam)");
                    await Task.Delay(2000);
                    await DeviceManager.TapAsync(device, 1200, 1400);
                    await Task.Delay(2000);
                    await DeviceManager.GoBackToHomeScreenAsync(device);
                }    

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reel: {ex.Message}");
            }
        }

    }
}
