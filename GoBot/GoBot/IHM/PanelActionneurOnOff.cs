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
        private ActionneurOnOffID actionneur;

        public PanelActionneurOnOff()
        {
            InitializeComponent();
        }

        public void SetActionneur(ActionneurOnOffID act)
        {
            actionneur = act;
            lblName.Text = Nommeur.Nommer(act).Substring(0, 1).ToUpper() + Nommeur.Nommer(act).Substring(1);
        }

        private void btnOnOff_ValueChanged(object sender, bool value)
        {
            Robots.GrosRobot.ActionneurOnOff(actionneur, value);
        }
    }
}
