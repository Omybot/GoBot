using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionAvance : ITimeableAction
    {
        private int distance;
        private Robot robot;

        public ActionAvance(Robot r, int dist)
        {
            robot = r;
            distance = dist;
        }

        public override String ToString()
        {
            return robot.Name + " avance de " + distance + "mm";
        }

        void IAction.Executer()
        {
            robot.MoveForward(distance);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.UpGreen16;  
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return robot.SpeedConfig.LineDuration(distance);
            }
        }
    }
}
