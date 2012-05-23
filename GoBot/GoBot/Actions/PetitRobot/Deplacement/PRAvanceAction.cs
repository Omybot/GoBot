using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRAvanceAction : IAction
    {
        private int distance;

        public PRAvanceAction(int dist)
        {
            distance = dist;
        }

        String IAction.ToString()
        {
            return PetitRobot.Nom + " avance de " + distance + "mm";
        }

        void IAction.Executer()
        {
            PetitRobot.Avancer(distance);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.avance;  
            }
        }
    }
}
