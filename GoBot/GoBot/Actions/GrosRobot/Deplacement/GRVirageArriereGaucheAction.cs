using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRVirageArriereGaucheAction : IAction
    {
        private int distance;
        private int angle;

        public GRVirageArriereGaucheAction(int dist, int a)
        {
            distance = dist;
            angle = a;
        }

        String IAction.ToString()
        {
            return Robots.GrosRobot.Nom + " tourne " + distance + "mm " + angle + "° arriere gauche";
        }

        void IAction.Executer()
        {
            Robots.GrosRobot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.virageArGa;  
            }
        }
    }
}
