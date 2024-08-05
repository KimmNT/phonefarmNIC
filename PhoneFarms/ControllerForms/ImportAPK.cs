using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneFarms.Managers;
using PhoneFarms.Helpers;

namespace PhoneFarms.ControllerForms
{
    public partial class ImportAPK : Form
    {
        private string[] _deviceArray;

        public ImportAPK(string[] devices)
        {
            InitializeComponent();
            _deviceArray = devices;
        }

        private static async Task InstallAPKFromFile(string device, string apkPath)
        {
            try
            {
                await Task.Run(() => DeviceManager.InstallApkAsync(device, apkPath).Wait());
                MessageBox.Show($"APK installed successfully on device {device}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error installing APK on device {device}: {ex.Message}");
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "APK files (*.apk)|*.apk|All files (*.*)|*.*";
                openFileDialog.Title = "Select an APK file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private async void btnInstallAPK_Click(object sender, EventArgs e)
        {
            string apkPath = txtFilePath.Text;
            if (string.IsNullOrEmpty(apkPath))
            {
                MessageBox.Show("Please select an APK file first.");
                return;
            }

            btnInstallAPK.Enabled = false;
            btnOpenFile.Enabled = false;

            var tasks = _deviceArray.Select(device => InstallAPKFromFile(device, apkPath)).ToArray();

            try
            {
                await Task.WhenAll(tasks);
                MessageBox.Show("APK installation process completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the APK installation process: {ex.Message}");
            }
            finally
            {
                btnInstallAPK.Enabled = true;
                btnOpenFile.Enabled = true;
            }
        }
    }
}
