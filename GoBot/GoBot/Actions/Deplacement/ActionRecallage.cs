using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionRecallage : IAction
    {
        private SensAR sens;
        private Robot robot;

        public ActionRecallage(Robot r, SensAR s)
        {
            robot = r;
            sens = s;
        }

        public override String ToString()
        {
            return robot.Name + " recallage " + sens.ToString().ToLower();
        }

        void IAction.Executer()
        {
            robot.Recalibration(sens);
        }

        public System.Drawing.Image Image
        {
            get
            {
                return GoBot.Properties.Resources.BottomLine16;
            }
        }
    }
}
