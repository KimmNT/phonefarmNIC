using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneFarms.Managers;
using PhoneFarms.Helpers;

namespace PhoneFarms.Controller_Forms
{
    public partial class WifiConfig : Form
    {
        string[] _deviceArray;

        public WifiConfig(string[] devices)
        {
            InitializeComponent();
            _deviceArray = devices;
        }

        public static async Task WifiSettingForEach(string device,string wifiName,string password)
        {
            try
            {
                await Task.Run(() => DeviceManager.WifiSetting(device));
                await Task.Delay(3000);
                await DeviceManager.Swipe(device, 3, 250, 800, 250, 400,1000);
                //await Task.Delay(500);
                await DeviceManager.TapButtonWithTextAsync(device, "Thêm mạng");
                await Task.Delay(3000);
                await Task.Run(() => DeviceManager.HandleInput(device, wifiName));
                await Task.Delay(2000);
                await DeviceManager.TapButtonWithTextAsync(device, "Không dùng");
                await Task.Delay(2000);
                await DeviceManager.TapButtonWithTextAsync(device, "WPA/WPA2/FT PSK");
                await Task.Delay(2000);
                await DeviceManager.TapButtonWithTextAsync(device, "Nhập mật mã");
                await Task.Delay(2000);
                await Task.Run(() => DeviceManager.HandleInput(device, password));
                await Task.Delay(2000);
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell input keyevent 66");
                await Task.Delay(500);
                await DeviceManager.GoBackToHomeScreenAsync(device);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on device {device}: {ex.Message}");
            }
        }

        private async void btnWifiSetting_Click_1(object sender, EventArgs e)
        {
            var tasks = new Task[_deviceArray.Length];
            for (int i = 0; i < _deviceArray.Length; i++)
            {
                tasks[i] = WifiSettingForEach(_deviceArray[i],txtWifiName.Text,txtPassword.Text);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Connect to WiFi "+txtWifiName.Text+" successfully");
        }
    }
}
