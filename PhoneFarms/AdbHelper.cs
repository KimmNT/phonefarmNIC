using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneFarms.Helpers
{
    public static class ADBHelper
    {
        public static async Task ExecuteAdbCommandAsync(string device, string command)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "adb",
                        Arguments = $"-s {device} {command}",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing ADB command on device {device}: {ex.Message}");
            }
        }

        public static async Task<string> ExecuteAdbCommandWithOutputAsync(string device, string command)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "adb",
                        Arguments = $"-s {device} {command}",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                Console.WriteLine($"Command: adb -s {device} {command}");
                Console.WriteLine($"Output: {output}");

                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing ADB command with output on device {device}: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
