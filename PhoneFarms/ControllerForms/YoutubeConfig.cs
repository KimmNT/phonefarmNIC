using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneFarms.Managers;
using PhoneFarms.Helpers;

namespace PhoneFarms.ControllerForms
{
    public partial class YoutubeConfig : Form
    {

        string[] _deviceArray;
        public YoutubeConfig(string[] devices)
        {
            InitializeComponent();
            _deviceArray = devices;
        }

        public static async Task WatchingYoutubeByURL(string device, string videoURL, int videoTime)
        {
            try
            {
                await DeviceManager.OpenChromeByURL(device, videoURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Play Store on device {device}: {ex.Message}");
            }
        }

        private async void btnWatchYoutube_Click(object sender, EventArgs e)
        {
            var tasks = new Task[_deviceArray.Length];
            for (int i = 0; i < _deviceArray.Length; i++)
            {
                tasks[i] = WatchingYoutubeByURL(_deviceArray[i], txtVideoURL.Text, int.Parse(txtVideoTime.Text));
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
            MessageBox.Show("Finish watching youtube");
        }
    }
}
