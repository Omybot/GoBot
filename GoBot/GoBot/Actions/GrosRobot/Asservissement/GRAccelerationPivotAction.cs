using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRAccelerationPivotAction : IAction
    {
        private int vitesse;

        public GRAccelerationPivotAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return GrosRobot.Nom + " accélération pivot à " + vitesse;
        }

        void IAction.Executer()
        {
            GrosRobot.AccelerationPivot = vitesse;
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
