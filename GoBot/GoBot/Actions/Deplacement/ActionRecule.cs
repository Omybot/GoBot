using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionRecule : IActionDuree
    {
        private int distance;
        private Robot robot;

        public ActionRecule(Robot r, int dist)
        {
            robot = r;
            distance = dist;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.Recule; }
        }

        public override String ToString()
        {
            return robot.Nom + " recule de " + distance + "mm";
        }

        void IAction.Executer()
        {
            robot.Reculer(distance);
        }

        public int Duree
        {
            get
            {
                return robot.SpeedConfig.LineDuration(distance);
            }
        }
    }
}
