using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actions
{
    class ActionMoteur : IAction
    {
        private int vitesse;
        MoteurID moteur;
        private Robot robot;

        public ActionMoteur(Robot r, int vi, MoteurID mo)
        {
            robot = r;
            vitesse = vi;
            moteur = mo;
        }

        String IAction.ToString()
        {
            return robot + " tourne " + Nommeur.Nommer(moteur) + " à " + Nommeur.Nommer(vitesse, moteur);
        }

        void IAction.Executer()
        {
            robot.TourneMoteur(moteur, vitesse);
        }

        public System.Drawing.Image Image
        {
            get 
            { 
                return GoBot.Properties.Resources.Moteur;  
            }
        }
    }
}
