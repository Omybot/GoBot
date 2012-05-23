using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRVitesseLigneAction : IAction
    {
        private int vitesse;

        public PRVitesseLigneAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " vitesse ligne à " + vitesse;
        }

        void IAction.Executer()
        {
            PetitRobot.VitesseDeplacement = vitesse;
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.iconeVitesse;  
            }
        }
    }
}
