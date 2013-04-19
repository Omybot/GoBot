using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRPivotGaucheAction : IAction
    {
        private double angle;

        public GRPivotGaucheAction(double a)
        {
            angle = a;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.pivotGauche; }
        }

        string IAction.ToString()
        {
            return Robots.GrosRobot.Nom + " pivote de " + angle + "° gauche";
        }

        void IAction.Executer()
        {
            Robots.GrosRobot.PivotGauche(angle);
        }
    }
}
