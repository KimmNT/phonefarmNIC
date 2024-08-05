using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneFarms.Helpers;
using PhoneFarms.Managers;

namespace PhoneFarms.ControllerForms
{
    public partial class FacebookServices : Form
    {
        string[] _deviceArray;
        public FacebookServices(string[] devices)
        {
            InitializeComponent();
            _deviceArray = devices;
        }

        public static async Task FBWatchLive(string device, string userName,string password,string pageURL)
        {
            try
            {
                //await DeviceManager.OpenApp(device, "com.android.chrome/com.google.android.apps.chrome.Main");
                await ADBHelper.ExecuteAdbCommandAsync(device, "shell am start -a android.intent.action.VIEW -d "+pageURL+" com.android.chrome");
                //await Task.Delay(5000);
                //await DeviceManager.TapButtonWithTextAsync(device, "Play Video");
                //await Task.Delay(500);
                //await DeviceManager.HandleInput(device, userName);
                //await Task.Delay(1000);
                ////await DeviceManager.HandleTab(device);
                //await DeviceManager.TapButtonWithTextAsync(device, "Mật khẩu");
                //await Task.Delay(500);
                //await DeviceManager.HandleInput(device,password);
                //await Task.Delay(500);
                //await DeviceManager.TapButtonWithTextAsync(device, "Đăng nhập");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on device {device}: {ex.Message}");
            }
        }

        public static async Task LikePost(string device, string targetName)
        {
            try
            {
                await DeviceManager.TapButtonWithTextAsync(device, targetName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on device {device}: {ex.Message}");
            }
        }

        public static async Task CommentPost(string device, string targetName,string cmtValue)
        {
            try
            {
                await DeviceManager.TapButtonWithTextAsync(device, targetName);
                await Task.Delay(2000);
                await DeviceManager.HandleInput(device, cmtValue);
                await Task.Delay(2000);
                await DeviceManager.HandlePressEnter(device);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on device {device}: {ex.Message}");
            }
        }

        private async void btnWatchLive_Click(object sender, EventArgs e)
        {
            var tasks = new Task[_deviceArray.Length];
            for (int i = 0; i < _deviceArray.Length; i++)
            {
                tasks[i] = FBWatchLive(_deviceArray[i], txtUserName.Text, txtPassword.Text,txtPageURL.Text);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Loggin into Facebook successfully");
        }

        private async void btnLikePost_Click(object sender, EventArgs e)
        {
            var tasks = new Task[_deviceArray.Length];
            for (int i = 0; i < _deviceArray.Length; i++)
            {
                tasks[i] = LikePost(_deviceArray[i], "React");
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Liked");
        }

        private async void btnCmt_Click(object sender, EventArgs e)
        {
            var tasks = new Task[_deviceArray.Length];
            for (int i = 0; i < _deviceArray.Length; i++)
            {
                tasks[i] = CommentPost(_deviceArray[i], "React",txtComment.Text);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Commented");
        }
    }
}
