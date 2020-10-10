using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM.Forms
{
    public partial class DebugLidar : Form
    {
        public DebugLidar()
        {
            InitializeComponent();
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtMessage.Text = ((HokuyoRec)AllDevices.LidarGround).ReadMessage();
            lblTime.Text = sw.ElapsedMilliseconds.ToString() + "ms";
        }
    }
}
