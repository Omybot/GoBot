using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRVirageAvantDroiteAction : IAction
    {
        private int distance;
        private int angle;

        public GRVirageAvantDroiteAction(int dist, int a)
        {
            distance = dist;
            angle = a;
        }

        String IAction.ToString()
        {
            return GrosRobot.Nom + " tourne " + distance + "mm " + angle + "° avant droite";
        }

        void IAction.Executer()
        {
            GrosRobot.Virage(SensAR.Avant, SensGD.Droite, distance, angle);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.virageAvDr;  
            }
        }
    }
}
