using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionAvance : IAction
    {
        private int distance;
        private Robot robot;

        public ActionAvance(Robot r, int dist)
        {
            robot = r;
            distance = dist;
        }

        String IAction.ToString()
        {
            return robot.Nom + " avance de " + distance + "mm";
        }

        void IAction.Executer()
        {
            robot.Avancer(distance);
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
