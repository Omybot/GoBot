using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRVitesseLigneAction : IAction
    {
        private int vitesse;

        public GRVitesseLigneAction(int vit)
        {
            vitesse = vit;
        }

        String IAction.ToString()
        {
            return GrosRobot.Nom + " vitesse ligne à " + vitesse;
        }

        void IAction.Executer()
        {
            Plateau.GrosRobot.VitesseDeplacement = vitesse;
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
