using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Devices;

namespace GoBot.IHM
{
    public partial class PanelPololu : UserControl
    {
        public PanelPololu()
        {
            InitializeComponent();
            trackBarPosition.Min = (double)numMin.Value;
            trackBarPosition.Max = (double)numMax.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBarPosition.Min = (double)numMin.Value;
        }

        private void trackBarPosition_TickValueChanged(object sender, double value)
        {
            PololuMiniUart.setTarget((byte)numId.Value, (ushort)value);
            lblPosition.Text = trackBarPosition.Value.ToString("0");
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            trackBarPosition.Max = (double)numMax.Value;
        }
    }
}
