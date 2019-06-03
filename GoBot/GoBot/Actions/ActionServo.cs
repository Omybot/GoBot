using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionServo : IAction
    {
        private int position;
        ServomoteurID pince;
        private Robot robot;

        public ActionServo(Robot r, int po, ServomoteurID pi)
        {
            robot = r;
            position = po;
            pince = pi;
        }

        public override String ToString()
        {
            return robot + " bouge " + NameFinder.GetName(pince) + " à " + NameFinder.GetName(position, pince);
        }

        void IAction.Executer()
        {
            Devices.AllDevices.CanServos[pince].SetPosition(position);
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
