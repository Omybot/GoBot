using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRVirageAvantGaucheAction : IAction
    {
        private int distance;
        private int angle;

        public PRVirageAvantGaucheAction(int dist, int a)
        {
            distance = dist;
            angle = a;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " tourne " + distance + "mm " + angle + "° avant gauche";
        }

        void IAction.Executer()
        {
            PetitRobot.Virage(SensAR.Avant, SensGD.Gauche, distance, angle);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.virageAvGa;  
            }
        }
    }
}
