using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRReculeAction : IAction
    {
        private int distance;

        public GRReculeAction(int dist)
        {
            distance = dist;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.recule; }
        }

        string IAction.ToString()
        {
            return GrosRobot.Nom + " recule de " + distance + "mm";
        }

        void IAction.Executer()
        {
            GrosRobot.Reculer(distance);
        }
    }
}
