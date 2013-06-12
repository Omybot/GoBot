using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionAccelerationPivot : IAction
    {
        private int vitesse;
        private Robot robot;

        public ActionAccelerationPivot(Robot r, int vit)
        {
            robot = r;
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return robot.Nom + " accélération pivot à " + vitesse;
        }

        void IAction.Executer()
        {
            robot.AccelerationPivot = vitesse;
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
