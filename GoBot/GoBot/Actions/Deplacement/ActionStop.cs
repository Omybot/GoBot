using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionStop : IAction
    {
        private StopMode mode;
        private Robot robot;

        public ActionStop(Robot r, StopMode m)
        {
            robot = r;
            mode = m;
        }

        public override string ToString()
        {
            return robot.Nom + " stop " + mode;
        }

        void IAction.Executer()
        {
            robot.Stop(mode);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Stop16;  
            }
        }
    }
}
