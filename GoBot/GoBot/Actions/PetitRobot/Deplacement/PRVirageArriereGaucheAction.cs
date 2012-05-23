using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRVirageArriereGaucheAction : IAction
    {
        private int distance;
        private int angle;

        public PRVirageArriereGaucheAction(int dist, int a)
        {
            distance = dist;
            angle = a;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " tourne " + distance + "mm " + angle + "° arriere gauche";
        }

        void IAction.Executer()
        {
            PetitRobot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle);
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
