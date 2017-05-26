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
        private int num;

        public MouvementFusee(int numero)
        {
            num = numero;

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
            Robots.GrosRobot.Avancer(80);

            while (fusee.ModulesRestants > 0 && Actionneur.GestionModules.PlacesLibres > 0)
            {
                for (int j = 0; j < 5; j++)
                    Actionneurs.Actionneur.BrasLunaire.Descendre();
                Actionneurs.Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(120);
                Actionneurs.Actionneur.BrasLunaire.Avancer();
                Thread.Sleep(180);
                Actionneurs.Actionneur.BrasLunaire.Fermer();
                Thread.Sleep(180);
                Actionneurs.Actionneur.BrasLunaire.Reculer();
                Robots.GrosRobot.Reculer(50);
                Actionneurs.Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(50);
                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Avancer(30);
                Robots.GrosRobot.Rapide();
                Actionneurs.Actionneur.BrasLunaire.Fermer();

                Actionneur.GestionModules.AttraperUnModuleEtRanger();

                if(fusee.ModulesRestants > 0 && Actionneur.GestionModules.PlacesLibres > 0)
                    Robots.GrosRobot.Avancer(20);

                fusee.ModulesRestants--;
                Robots.GrosRobot.Historique.Log("Chargement module " + fusee.ToString() + ", " + fusee.ModulesRestants + " modules restants");
            }

            Robots.GrosRobot.Reculer(60);
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

                int facteurPlace = Math.Max(fusee.ModulesRestants - Actionneur.Stockeur.ModulesCount, 0);

                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 30))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 45))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 60))
                    facteurTemps++;

                int facteurPresencePetitRobot = 1;

                if ((num == 1 || num == 2) && Plateau.Enchainement.TempsRestant < new TimeSpan(0, 0, 30))
                    facteurPresencePetitRobot = 0;

                double facteurCote = 1;

                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu && num > 1)
                    facteurCote = 0.5;
                if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune && num <= 1)
                    facteurCote = 0.5;

                return facteurPresencePetitRobot * facteurTemps * 5 * facteurPlace * facteurCouleur * facteurCote;
            }
        }
        public override string ToString()
        {
            return "Attrape " + fusee.ToString();
        }
    }
}
