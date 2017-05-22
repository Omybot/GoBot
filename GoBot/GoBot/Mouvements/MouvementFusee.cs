using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actionneurs;
using System.Threading;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.PathFinding;
using GoBot.ElementsJeu;
using System.Drawing;

namespace GoBot.Mouvements
{
    class MouvementFusee : Mouvement
    {
        private Fusee fusee;

        public MouvementFusee(int numero)
        {
            fusee = Plateau.Elements.Fusees[numero];

            Positions.Add(PositionsMouvements.PositionsApprocheFusee[numero]);
        }

        public override Color Couleur
        {
            get { return Color.White; }
        }

        public override Robot Robot
        {
            get { return Robots.GrosRobot; }
        }

        public override ElementJeu Element
        {
            get { return fusee; }
        }

        protected override void ActionApresDeplacement()
        {
            // TODO attrapage fusée

            fusee.ModulesRestants--;
            Robots.GrosRobot.Historique.Log("Chargement module " + fusee.ToString() + ", " + fusee.ModulesRestants + " modules restants");
            fusee.ModulesRestants--;
            Robots.GrosRobot.Historique.Log("Chargement module " + fusee.ToString() + ", " + fusee.ModulesRestants + " modules restants");
            fusee.ModulesRestants--;
            Robots.GrosRobot.Historique.Log("Chargement module " + fusee.ToString() + ", " + fusee.ModulesRestants + " modules restants");
            fusee.ModulesRestants--;
            Robots.GrosRobot.Historique.Log("Chargement module " + fusee.ToString() + ", " + fusee.ModulesRestants + " modules restants");
        }

        protected override void ActionAvantDeplacement()
        {
            // Rien ?
        }

        public override double Score
        {
            get { return 0; }
        }

        public override double ValeurAction
        {
            get 
            {
                double facteurCouleur;

                if (fusee.Couleur == Color.White)
                    facteurCouleur = 1.5;
                else if (fusee.Couleur == Plateau.NotreCouleur)
                    facteurCouleur = 1;
                else
                    facteurCouleur = 0;

                int facteurTemps = 1;

                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 30))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 45))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 60))
                    facteurTemps++;

                return facteurTemps * 5 * fusee.ModulesRestants * facteurCouleur; 
            }
        }
        public override string ToString()
        {
            return "Attrape " + fusee.ToString();
        }
    }
}
