using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRServoAction : IAction
    {
        private int position;
        ServomoteurID pince;

        public GRServoAction(int po, ServomoteurID pi)
        {
            position = po;
            pince = pi;
        }

        String IAction.ToString()
        {
            return GrosRobot.Nom + " bouge " + Nommeur.Nommer(pince) + " à " + Nommeur.Nommer(position, pince);
        }

        void IAction.Executer()
        {
            Plateau.GrosRobot.BougeServo(pince, position);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.crochet;  
            }
        }
    }
}
