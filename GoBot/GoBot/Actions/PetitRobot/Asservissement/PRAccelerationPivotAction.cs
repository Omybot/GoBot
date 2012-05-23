using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRAccelerationPivotAction : IAction
    {
        private int vitesse;

        public PRAccelerationPivotAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " accélération pivot à " + vitesse;
        }

        void IAction.Executer()
        {
            PetitRobot.AccelerationPivot = vitesse;
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
