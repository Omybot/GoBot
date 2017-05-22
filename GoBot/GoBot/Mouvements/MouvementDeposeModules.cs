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
    class MouvementDeposeModules : Mouvement
    {
        private ZoneInteret zone;

        public MouvementDeposeModules(int numero)
        {
            zone = Plateau.Elements.ZonesDepose[numero];

            Positions.Add(PositionsMouvements.PositionsApprocheDepose[numero]);
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
            get { return zone; }
        }

        protected override void ActionApresDeplacement()
        {
            // TODO vidage modules
        }

        protected override void ActionAvantDeplacement()
        {
            // Rien ?
        }

        public override double Score
        {
            get 
            { 
                return 10 * Actionneur.Stockeur.ModulesCount; 
            }
        }

        public override double ValeurAction
        {
            get 
            { 
                int facteurTemps = 1;

                if (Plateau.Enchainement.TempsRestant < new TimeSpan(0, 0, 30))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant < new TimeSpan(0, 0, 45))
                    facteurTemps++;
                if (Plateau.Enchainement.TempsRestant < new TimeSpan(0, 0, 60))
                    facteurTemps++;

                return facteurTemps * 5 * (Actionneur.Stockeur.ModulesCount + (Actionneur.Convoyeur.ModuleCharge ? 1 : 0)); 
            }
        }

        public override string ToString()
        {
            return "Dépose modules " + zone.ToString();
        }
    }
}
