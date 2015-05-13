using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionAccelerationLigne : IAction
    {
        private int vitesse;
        private Robot robot;

        public ActionAccelerationLigne(Robot r, int vit)
        {
            robot = r;
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return robot.Nom + " accélération ligne à " + vitesse;
        }

        void IAction.Executer()
        {
            robot.AccelerationDebutDeplacement = vitesse;
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.IconeVitesse;  
            }
        }
    }
}
