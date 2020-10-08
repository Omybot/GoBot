using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ((HokuyoRec)AllDevices.LidarGround).ReadMessage();
        }
    }
}
