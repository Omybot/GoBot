using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRServoAction : IAction
    {
        private int position;
        ServomoteurID pince;

        public PRServoAction(int po, ServomoteurID pi)
        {
            position = po;
            pince = pi;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " bouge " + Nommeur.Nommer(pince) + " à " + Nommeur.Nommer(position, pince);
        }

        void IAction.Executer()
        {
            PetitRobot.BougeBras(pince, position);
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
