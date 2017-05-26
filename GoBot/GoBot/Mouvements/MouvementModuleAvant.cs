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
    class MouvementModuleAvant : Mouvement
    {
        private Module module;
        private int num;

        public MouvementModuleAvant(int numero)
        {
            num = numero;
            module = Plateau.Elements.Modules[numero];

            Positions.Add(PositionsMouvements.PositionsApprocheModuleFace[numero]);
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
            get { return module; }
        }

        protected override void ActionApresDeplacement()
        {
            Actionneurs.Actionneur.BrasLunaire.Descendre();
            Actionneurs.Actionneur.BrasLunaire.Ouvrir();
            Thread.Sleep(200);
            Actionneurs.Actionneur.BrasLunaire.Avancer();
            Robots.GrosRobot.AccelerationFinDeplacement = 300;
            Robots.GrosRobot.Avancer(100);
            Actionneurs.Actionneur.BrasLunaire.Fermer();
            Thread.Sleep(200);
            Actionneurs.Actionneur.BrasLunaire.Reculer();
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(30);
            Actionneurs.Actionneur.BrasLunaire.Ouvrir();
            Thread.Sleep(50);
            Robots.GrosRobot.AccelerationFinDeplacement = 300;
            Robots.GrosRobot.Avancer(30);
            Robots.GrosRobot.Rapide();
            Actionneurs.Actionneur.BrasLunaire.Fermer();

            Actionneur.GestionModules.AttraperUnModuleEtRanger();
            module.Ramasse = true;

            if (num == 2) // Gros patch déblocage
                Robots.GrosRobot.Reculer(250);
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
                if (module.Ramasse || Actionneur.GestionModules.PlacesLibres == 0)
                    return 0;

                double facteurTemps = 1;

                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 30))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 45))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 60))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant < new TimeSpan(0, 0, 15))
                    facteurTemps = 0.2;

                double facteurCouleur;

                if (module.Couleur == Color.White)
                    facteurCouleur = 3;
                else if (module.Couleur == Plateau.NotreCouleur)
                    facteurCouleur = 1;
                else
                    facteurCouleur = 0;

                double facteurCote = 1;

                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu && num > 6)
                    facteurCote = 0.5;
                if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune && num <= 6)
                    facteurCote = 0.5;

                return facteurTemps * 5 * facteurCouleur * facteurCote;
            }
        }

        public override string ToString()
        {
            return "Attrape avant module " + num.ToString();
        }
    }
}
