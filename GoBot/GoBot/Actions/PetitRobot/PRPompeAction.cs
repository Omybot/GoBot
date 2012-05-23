using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRPompeAction : IAction
    {
        private bool actif;
        PompeID pompe;

        public PRPompeAction(bool a, PompeID p)
        {
            actif = a;
            pompe = p;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " " + Nommeur.Nommer(pompe) + (actif ? " activée" : " désactivée");
        }

        void IAction.Executer()
        {
            PetitRobot.ActiverPompe(pompe, actif);
        }

        public System.Drawing.Image Image
        {
            get
            {
                return GoBot.Properties.Resources.pompe;
            }
        }
    }
}
