using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneFarms.ControllerForms
{
    public partial class ReelConfig : Form
    {
        string[] _deviceArray;
        public ReelConfig(string[] devices)
        {
            InitializeComponent();
            _deviceArray = devices;
        }

        private void ReelConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
