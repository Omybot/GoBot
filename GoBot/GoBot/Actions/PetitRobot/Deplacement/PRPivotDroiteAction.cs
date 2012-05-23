using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRPivotDroiteAction : IAction
    {
        private int angle;

        public PRPivotDroiteAction(int a)
        {
            angle = a;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.pivotDroite; }
        }

        string IAction.ToString()
        {
            return PetitRobot.Nom + " pivote de " + angle + "° droite";
        }

        void IAction.Executer()
        {
            PetitRobot.PivotDroite(angle);
        }
    }
}
