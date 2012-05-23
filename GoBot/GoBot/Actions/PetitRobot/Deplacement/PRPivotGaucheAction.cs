using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class PRPivotGaucheAction : IAction
    {
        private int angle;

        public PRPivotGaucheAction(int a)
        {
            angle = a;
        }

        System.Drawing.Image IAction.Image
        {
            get { return GoBot.Properties.Resources.pivotGauche; }
        }

        string IAction.ToString()
        {
            return PetitRobot.Nom + " pivote de " + angle + "° gauche";
        }

        void IAction.Executer()
        {
            PetitRobot.PivotGauche(angle);
        }
    }
}
