using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRVirageArriereDroiteAction : IAction
    {
        private int distance;
        private int angle;

        public GRVirageArriereDroiteAction(int dist, int a)
        {
            distance = dist;
            angle = a;
        }

        String IAction.ToString()
        {
            return GrosRobot.Nom + " tourne " + distance + "mm " + angle + "° arriere droite";
        }

        void IAction.Executer()
        {
            GrosRobot.Virage(SensAR.Arriere, SensGD.Droite, distance, angle);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.virageArDr;  
            }
        }
    }
}
