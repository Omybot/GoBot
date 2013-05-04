using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionOnOff : IAction
    {
        private bool on;
        ActionneurOnOffID actionneur;
        private Robot robot;

        public ActionOnOff(Robot r, ActionneurOnOffID ac, bool _on)
        {
            robot = r;
            on = _on;
            actionneur = ac;
        }

        String IAction.ToString()
        {
            return robot + " change " + Nommeur.Nommer(actionneur) + " à " + (on ? "on" : "off");
        }

        void IAction.Executer()
        {
            robot.ActionneurOnOff(actionneur, on);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Moteur;  
            }
        }
    }
}
