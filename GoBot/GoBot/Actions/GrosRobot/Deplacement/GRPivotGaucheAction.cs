using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRPivotGaucheAction : IAction
    {
        private int angle;

        public GRPivotGaucheAction(int a)
        {
            angle = a;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.pivotGauche; }
        }

        string IAction.ToString()
        {
            return GrosRobot.Nom + " pivote de " + angle + "° gauche";
        }

        void IAction.Executer()
        {
            GrosRobot.PivotGauche(angle);
        }
    }
}
