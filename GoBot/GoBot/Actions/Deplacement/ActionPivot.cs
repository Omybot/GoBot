using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionPivot : ITimeableAction
    {
        private AngleDelta angle;
        private Robot robot;
        private SensGD sens;

        public ActionPivot(Robot r, AngleDelta a, SensGD s)
        {
            robot = r;
            angle = a;
            sens = s;
        }

        System.Drawing.Image IAction.Image
        {
            get 
            {
                if (sens == SensGD.Droite)
                    return GoBot.Properties.Resources.TurnRigth16;
                else
                    return GoBot.Properties.Resources.TurnLeft16;
            }
        }

        public override String ToString()
        {
            return robot.Name + " pivote de " + angle + " " + sens.ToString().ToLower();
        }

        void IAction.Executer()
        {
            if(sens == SensGD.Droite)
                robot.PivotRight(angle);
            else
                robot.PivotLeft(angle);
        }

        public TimeSpan Duration
        {
            get
            {
                return robot.SpeedConfig.PivotDuration(angle, robot.WheelSpacing);
            }
        }
    }
}
