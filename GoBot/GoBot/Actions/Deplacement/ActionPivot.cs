using GoBot.Calculs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionPivot : IActionDuree
    {
        private Angle angle;
        private Robot robot;
        private SensGD sens;

        public ActionPivot(Robot r, Angle a, SensGD s)
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

        public override String ToString()
        {
            return robot.Nom + " pivote de " + angle + "° " + sens.ToString().ToLower();
        }

        void IAction.Executer()
        {
            if(sens == SensGD.Droite)
                robot.PivotDroite(angle);
            else
                robot.PivotGauche(angle);
        }

        public int Duree
        {
            get
            {
                return robot.CalculDureePivot(angle);
            }
        }
    }
}
