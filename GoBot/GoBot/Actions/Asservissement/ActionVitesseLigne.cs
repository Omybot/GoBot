using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionVitesseLigne : IAction
    {
        private int vitesse;
        private Robot robot;

        public ActionVitesseLigne(Robot r, int vit)
        {
            robot = r;
            vitesse = vit;
        }

        public override String ToString()
        {
            return robot.Nom + " vitesse ligne à " + vitesse;
        }

        void IAction.Executer()
        {
            robot.VitesseDeplacement = vitesse;
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
