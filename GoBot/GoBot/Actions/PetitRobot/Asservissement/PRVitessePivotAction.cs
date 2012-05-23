using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRVitessePivotAction : IAction
    {
        private int vitesse;

        public PRVitessePivotAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " vitesse pivot à " + vitesse;
        }

        void IAction.Executer()
        {
            PetitRobot.VitessePivot = vitesse;
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
