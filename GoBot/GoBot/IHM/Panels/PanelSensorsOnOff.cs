using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelSensorsOnOff : UserControl
    {
        public PanelSensorsOnOff()
        {
            InitializeComponent();
        }

        private void PanelSensorsOnOff_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                int y = 20;

                foreach (SensorOnOffID sensor in Enum.GetValues(typeof(SensorOnOffID)))
                {
                    PanelSensorOnOff panel = new PanelSensorOnOff();
                    panel.SetBounds(5, y, grpSensors.Width - 10, panel.Height);
                    panel.SetSensor(sensor);
                    y += panel.Height;
                    grpSensors.Controls.Add(panel);
                }

                grpSensors.Height = y + 5;
                this.Height = grpSensors.Bottom + 3;
            }
        }
    }
}
