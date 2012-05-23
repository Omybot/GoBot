using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRReculeAction : IAction
    {
        private int distance;

        public PRReculeAction(int dist)
        {
            distance = dist;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.recule; }
        }

        string IAction.ToString()
        {
            return PetitRobot.Nom + " recule de " + distance + "mm";
        }

        void IAction.Executer()
        {
            PetitRobot.Reculer(distance);
        }
    }
}
