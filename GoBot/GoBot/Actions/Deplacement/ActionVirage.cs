using GoBot.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionVirage : IAction
    {
        private int distance;
        private Angle angle;
        private Robot robot;
        private SensGD sensGD;
        private SensAR sensAR;

        public ActionVirage(Robot r, int dist, Angle a, SensAR ar, SensGD gd)
        {
            robot = r;
            distance = dist;
            angle = a;
            sensAR = ar;
            sensGD = gd;
        }

        public override String ToString()
        {
            return robot.Nom + " tourne " + distance + "mm " + angle + "° " + sensAR.ToString().ToLower() + " " + sensGD.ToString().ToLower();
        }

        void IAction.Executer()
        {
            robot.Virage(sensAR, sensGD, distance, angle);
        }

        public System.Drawing.Image Image
        {
            get
            {
                if (sensAR == SensAR.Avant)
                {
                    if (sensGD == SensGD.Droite)
                        return GoBot.Properties.Resources.BottomToRigth16;
                    else
                        return GoBot.Properties.Resources.BottomToLeft16;
                }
                else
                {
                    if (sensGD == SensGD.Droite)
                        return GoBot.Properties.Resources.TopToRigth16;
                    else
                        return GoBot.Properties.Resources.TopToLeft16;
                }
            }
        }
    }
}
