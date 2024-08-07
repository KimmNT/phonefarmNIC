using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneFarms.Helpers;
using PhoneFarms.Managers;

namespace PhoneFarms
{
    public partial class PhonesController : Form
    {
        private List<Process> scrcpyProcesses = new List<Process>();

        public PhonesController()
        {
            InitializeComponent();
            InitializeDeviceGrid();
        }

        private void InitializeDeviceGrid()
        {
            dataGridViewDevices.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Select", HeaderText = "Select" });
            dataGridViewDevices.Columns.Add("DeviceID", "Device ID");
            dataGridViewDevices.Columns.Add("ScreenStatus", "Screen Status");

            // Create button column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Display";
            buttonColumn.Text = "Show device";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridViewDevices.Columns.Add(buttonColumn);

            // Handle CellClick event
            dataGridViewDevices.CellClick += new DataGridViewCellEventHandler(showDeviceBtn);
        }


        private async void Main_Load(object sender, EventArgs e)
        {
            await DeviceManager.LoadDevicesAsync(dataGridViewDevices);
            int deviceCount = await DeviceManager.LoadDevicesAsync(dataGridViewDevices);
            lbDeviceCount.Text = deviceCount.ToString();
        }

        private void showDeviceBtn(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button cell
            if (e.ColumnIndex == 3 && e.RowIndex >= 0) // Column index 3 corresponds to the button column
            {
                // Get the DataGridView and the clicked row
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                if (row.Cells["DeviceID"].Value != null)
                {
                    string device = row.Cells["DeviceID"].Value.ToString();

                    // Mark the checkbox in the clicked row
                    row.Cells["Select"].Value = true;

                    // Call the method to show the screen
                    ShowScreen(device);
                }
            }
        }

        private void ShowScreen(string device)
        {
            DeviceManager.ShowScreen(device, scrcpyProcesses,dataGridViewDevices);
        }


        private async void btnOpenChrome_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    await Task.Run(() => DeviceManager.OpenApp(device, "free.vpn.unblock.proxy.turbovpn/.activity.StartupActivity"));
                }
            }

            MessageBox.Show("Started opening Chrome on selected devices.");
        }

        private async void btnDownloadsFB_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> selectedDevices = GetSelectedDevices();

                // Convert list to array for parallel execution
                string[] devicesArray = selectedDevices.ToArray();

                // Open Play Store and search for Facebook on multiple devices concurrently
                await DeviceManager.OpenPlayStoreAndSearchFacebookOnMultipleDevices(devicesArray);

                MessageBox.Show("Started searching for Facebook on multiple devices.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for Facebook on multiple devices: {ex.Message}");
            }
        }

        private List<string> GetSelectedDevices()
        {
            List<string> selectedDevices = new List<string>();

            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    selectedDevices.Add(row.Cells["DeviceID"].Value.ToString());
                }
            }

            return selectedDevices;
        }

        private async void btnTapHelloButton_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            foreach (string device in selectedDevices)
            {
                string screenContent = await DeviceManager.GetDeviceScreenContentAsync(device);
                //string screenContent = await DeviceManager.GetDeviceScreenContentAsync(device);
                //await DeviceManager.TapAsync(device, 123, 456);
                MessageBox.Show($"Screen content for device {device}:\n{screenContent}");
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            foreach (string device in selectedDevices)
            {
                Task.Run(() => DeviceManager.GoBackToHomeScreenAsync(device));
            }
        }

        private void btnWifiConfig_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            Controller_Forms.WifiConfig wifiConfig = new Controller_Forms.WifiConfig(devicesArray);
            wifiConfig.Show();
        }

        private async void btnTurnProxy_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = DeviceManager.ProxyConfig(devicesArray[i]);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Proxy config success!");
        }

        private async void btnGetInstalled_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    await ADBHelper.ExecuteAdbCommandAsync(device, "shell pm list packages -3");
                }
            }
        }

        private async void btnYoutube_Click(object sender, EventArgs e)
        {
        }

        private void btnImportAPK_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            ControllerForms.ImportAPK importAPK = new ControllerForms.ImportAPK(devicesArray);
            importAPK.Show();
        }

        private async void btnReadButtons_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            foreach (string device in selectedDevices)
            {
                string screenContent = await DeviceManager.GetButtonInformationAsync(device);
                //string screenContent = await DeviceManager.GetDeviceScreenContentAsync(device);
                //await DeviceManager.TapAsync(device, 123, 456);
                MessageBox.Show($"Screen content for device {device}:\n{screenContent}");
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (row.Cells["Select"] != null && row.Cells["Select"].Value != null)
                {
                    row.Cells["Select"].Value = true;
                }
            }
            btnUnselectAll.Visible = true;
            btnSelectAll.Visible = false;
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (row.Cells["Select"] != null)
                {
                    row.Cells["Select"].Value = false;
                }
            }
            btnSelectAll.Visible = true;
            btnUnselectAll.Visible = false;
        }

        private void btnFacebookService_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            ControllerForms.FacebookServices fbService = new ControllerForms.FacebookServices(devicesArray);
            fbService.Show();

        }

        private async void btnWebView_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    //await ADBHelper.ExecuteAdbCommandAsync(device, "shell pm list packages -3");
                    await DeviceManager.TapAsync(device, 1008, 72);
                    await Task.Delay(500);
                    await DeviceManager.Swipe(device, 1, 350, 800, 350, 400, 0);
                    await Task.Delay(500);
                    await DeviceManager.TapButtonWithTextAsync(device, "Trang web cho máy tính");
                }
            }
        }

        private async void btnSwipeCustom_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    //await ADBHelper.ExecuteAdbCommandAsync(device, "shell pm list packages -3");
                    await DeviceManager.Swipe(device, 1, int.Parse(txtX1.Text),int.Parse(txtY1.Text), int.Parse(txtX2.Text), int.Parse(txtY2.Text), 1000 );
                }
            }
        }

        private async void btnTapping_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    //await ADBHelper.ExecuteAdbCommandAsync(device, "shell pm list packages -3");
                    await DeviceManager.TapAsync(device, int.Parse(txtTapX.Text), int.Parse(txtTapY.Text));
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = DeviceManager.ReelSwiping(devicesArray[i]);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Facebook reel swiping successfully");
        }

        private async void btnGetActivity_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    //await ADBHelper.ExecuteAdbCommandAsync(device, "shell pm list packages -3");
                    await ADBHelper.ExecuteAdbCommandAsync(device, "shell pm dump "+txtAppName.Text+" | grep -A 1 'MAIN'");
                }
            }
        }

        private async void btnRotation_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = DeviceManager.DisableRotation(devicesArray[i]);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Disable rotation successfully!!");
        }

        private async void btnUnlock_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                //tasks[i] = DeviceManager.Swipe(devicesArray[i], 1, 250, 1050, 250, 350, 0);
                tasks[i] = ADBHelper.ExecuteAdbCommandAsync(devicesArray[i], "shell am start -a android.settings.SECURITY_SETTINGS");
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
        }

        private async void btnFindText_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();
                    bool result = await DeviceManager.IsTextPresentInScreenAsync(device, "FHD(1920x1080)");
                    if (result)
                    {
                        await DeviceManager.TapButtonWithTextAsync(device, "FHD(1920x1080)");
                    }
                    else
                    {
                        await DeviceManager.GoBackToHomeScreenAsync(device);
                    }
                }
            }
        }

        private async void btnSetting_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDevices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    string device = row.Cells["DeviceID"].Value.ToString();

                    await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.settings.DISPLAY_SETTINGS");
                    // }
                }
            }
        }

        private async void btnResolution_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = DeviceManager.ChangeResolution(devicesArray[i]);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Change resolution successfully");
        }

        private async void btnLanguage_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = DeviceManager.ChangeLanguage(devicesArray[i]);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Change language successfully");
        }

        private async void btnTimeOut_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = ADBHelper.ExecuteAdbCommandAsync(devicesArray[i], "shell settings put system screen_off_timeout 600000");
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Change timeout successfully");
        }

        private async void btnLockType_Click(object sender, EventArgs e)
        {
            List<string> selectedDevices = GetSelectedDevices();

            // Convert list to array for parallel execution
            string[] devicesArray = selectedDevices.ToArray();
            var tasks = new Task[devicesArray.Length];
            for (int i = 0; i < devicesArray.Length; i++)
            {
                tasks[i] = ADBHelper.ExecuteAdbCommandAsync(devicesArray[i], "shell am start -a android.settings.SECURITY_SETTINGS");
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
        }
    }
}
