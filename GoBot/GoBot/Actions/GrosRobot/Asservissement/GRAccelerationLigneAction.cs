using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRAccelerationLigneAction : IAction
    {
        private int vitesse;

        public GRAccelerationLigneAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return Robots.GrosRobot.Nom + " accélération ligne à " + vitesse;
        }

        void IAction.Executer()
        {
            Robots.GrosRobot.AccelerationDeplacement = vitesse;
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
