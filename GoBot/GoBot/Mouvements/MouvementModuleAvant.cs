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

        public MouvementModuleAvant(int numero)
        {
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
            // TODO attrapage module avant
            module.Ramasse = true;
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
                if (module.Ramasse)
                    return 0;

                int facteurTemps = 1;

                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 30))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 45))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant > new TimeSpan(0, 0, 60))
                    facteurTemps++;

                double facteurCouleur;

                if (module.Couleur == Color.White)
                    facteurCouleur = 1.5;
                else if (module.Couleur == Plateau.NotreCouleur)
                    facteurCouleur = 1;
                else
                    facteurCouleur = 0;

                return facteurTemps * 5 * facteurCouleur;
            }
        }

        public override string ToString()
        {
            return "Attrape avant " + module.ToString();
        }
    }
}
