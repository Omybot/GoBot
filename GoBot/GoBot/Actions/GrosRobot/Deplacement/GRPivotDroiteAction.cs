using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class GRPivotDroiteAction : IAction
    {
        private int angle;

        public GRPivotDroiteAction(int a)
        {
            angle = a;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.pivotDroite; }
        }

        string IAction.ToString()
        {
            return GrosRobot.Nom + " pivote de " + angle + "° droite";
        }

        void IAction.Executer()
        {
            GrosRobot.PivotDroite(angle);
        }
    }
}
