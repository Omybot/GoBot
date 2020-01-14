using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM
{
    public partial class PanelActionneurOnOff : UserControl
    {
        private ActuatorOnOffID actionneur;

        public PanelActionneurOnOff()
        {
            InitializeComponent();
        }

        public void SetActionneur(ActuatorOnOffID act)
        {
            actionneur = act;
            lblName.Text = NameFinder.GetName(act).Substring(0, 1).ToUpper() + NameFinder.GetName(act).Substring(1);
        }

        private void btnOnOff_ValueChanged(object sender, bool value)
        {
            Robots.MainRobot.SetActuatorOnOffValue(actionneur, value);
        }
    }
}
