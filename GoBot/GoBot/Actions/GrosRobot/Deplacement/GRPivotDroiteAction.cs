using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRPivotDroiteAction : IAction
    {
        private double angle;

        public GRPivotDroiteAction(double a)
        {
            angle = a;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.pivotDroite; }
        }

        string IAction.ToString()
        {
            return Robots.GrosRobot.Nom + " pivote de " + angle + "° droite";
        }

        void IAction.Executer()
        {
            Robots.GrosRobot.PivotDroite(angle);
        }
    }
}
