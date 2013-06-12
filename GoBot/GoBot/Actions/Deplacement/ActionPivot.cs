using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionPivot : IAction
    {
        private double angle;
        private Robot robot;
        private SensGD sens;

        public ActionPivot(Robot r, double a, SensGD s)
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
                    return GoBot.Properties.Resources.PivotDroite;
                else
                    return GoBot.Properties.Resources.PivotGauche;
            }
        }

        string IAction.ToString()
        {
            return robot.Nom + " pivote de " + angle + "° " + sens.ToString().ToLower();
        }

        void IAction.Executer()
        {
            if(sens == SensGD.Droite)
                Robots.GrosRobot.PivotDroite(angle);
            else
                Robots.GrosRobot.PivotGauche(angle);
        }
    }
}
