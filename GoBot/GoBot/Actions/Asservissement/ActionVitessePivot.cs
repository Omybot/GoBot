using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionVitessePivot : IAction
    {
        private int vitesse;
        private Robot robot;

        public ActionVitessePivot(Robot r, int vit)
        {
            robot = r;
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return robot.Nom + " vitesse pivot à " + vitesse;
        }

        void IAction.Executer()
        {
            robot.VitessePivot = vitesse;
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
