using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRVitessePivotAction : IAction
    {
        private int vitesse;

        public GRVitessePivotAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return Robots.GrosRobot.Nom + " vitesse pivot à " + vitesse;
        }

        void IAction.Executer()
        {
            Robots.GrosRobot.VitessePivot = vitesse;
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
