using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionMoteur : IAction
    {
        private int vitesse;
        MotorID moteur;
        private Robot robot;

        public ActionMoteur(Robot r, int vi, MotorID mo)
        {
            robot = r;
            vitesse = vi;
            moteur = mo;
        }

        public override String ToString()
        {
            return robot + " tourne " + NameFinder.GetName(moteur) + " à " + NameFinder.GetName(vitesse, moteur);
        }

        void IAction.Executer()
        {
            robot.MoteurPosition(moteur, vitesse);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Motor16;  
            }
        }
    }
}
