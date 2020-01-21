using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelActuatorsOnOff : UserControl
    {
        public PanelActuatorsOnOff()
        {
            InitializeComponent();
        }

        private void PanelActuatorsOnOff_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                int y = 20;

                foreach (ActuatorOnOffID actuator in Enum.GetValues(typeof(ActuatorOnOffID)))
                {
                    PanelActuatorOnOff panel = new PanelActuatorOnOff();
                    panel.SetBounds(5, y, grpActuatorsOnOff.Width - 10, panel.Height);
                    panel.SetActuator(actuator);
                    y += panel.Height;
                    grpActuatorsOnOff.Controls.Add(panel);
                }

                grpActuatorsOnOff.Height = y + 5;
                this.Height = grpActuatorsOnOff.Bottom + 3;
            }
        }
    }
}
