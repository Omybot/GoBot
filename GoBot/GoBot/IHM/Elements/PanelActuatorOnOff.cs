using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelActuatorOnOff : UserControl
    {
        private ActuatorOnOffID _actuator;

        public PanelActuatorOnOff()
        {
            InitializeComponent();
        }

        public void SetActuator(ActuatorOnOffID actuator)
        {
            _actuator = actuator;
            lblName.Text = NameFinder.GetName(actuator).Substring(0, 1).ToUpper() + NameFinder.GetName(actuator).Substring(1);
        }

        private void btnOnOff_ValueChanged(object sender, bool value)
        {
            Robots.MainRobot.SetActuatorOnOffValue(_actuator, value);
        }
    }
}
