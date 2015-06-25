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
            return robot + " bouge " + Nommeur.Nommer(pince) + " à " + Nommeur.Nommer(position, pince);
        }

        void IAction.Executer()
        {
            robot.BougeServo(pince, position);
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
