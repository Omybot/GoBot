using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRAccelerationLigneAction : IAction
    {
        private int vitesse;

        public PRAccelerationLigneAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " accélération ligne à " + vitesse;
        }

        void IAction.Executer()
        {
            PetitRobot.AccelerationDeplacement = vitesse;
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
