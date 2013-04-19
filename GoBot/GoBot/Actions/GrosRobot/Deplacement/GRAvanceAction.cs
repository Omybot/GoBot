﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRAvanceAction : IAction
    {
        private int distance;

        public GRAvanceAction(int dist)
        {
            distance = dist;
        }

        String IAction.ToString()
        {
            return Robots.GrosRobot.Nom + " avance de " + distance + "mm";
        }

        void IAction.Executer()
        {
            Robots.GrosRobot.Avancer(distance);
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
