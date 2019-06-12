using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionOnOff : IAction
    {
        private bool on;
        ActuatorOnOffID actionneur;
        private Robot robot;

        public ActionOnOff(Robot r, ActuatorOnOffID ac, bool _on)
        {
            robot = r;
            on = _on;
            actionneur = ac;
        }

        public override String ToString()
        {
            return robot + " change " + NameFinder.GetName(actionneur) + " à " + (on ? "on" : "off");
        }

        void IAction.Executer()
        {
            robot.ActionneurOnOff(actionneur, on);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Motor16;  
            }
        }
    }
}
