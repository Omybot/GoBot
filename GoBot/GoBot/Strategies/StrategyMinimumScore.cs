using GoBot.Movements;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à marquer juste quelques points (pour homologuation de capacité à marquer des points par exemple)
    /// </summary>
    class StrategyMinimumScore : Strategy
    {
        private bool _avoidElements = false;

        public override bool AvoidElements => _avoidElements;

        protected override void SequenceBegin()
        {
            // Sortir ICI de la zonde de départ

            Plateau.Score += (3 + 5 + 10 + 10 + 35); // abeille posée - erreur de 2
            //Plateau.Score += 5; // panneau domotique posé
            //Plateau.Score += 10; // sortir de la zone de départ
            //Plateau.Score += 10; // distributeur ouvert
            //Plateau.Score += 35; // 7 balles

            Robots.GrosRobot.SpeedConfig.SetParams(400, 1000, 2000, 400, 1000, 2000);

            ThreadManager.CreateThread(link => Actionneurs.Actionneur.Harvester.DoInitArms()).StartThread();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
            {
                Robots.GrosRobot.Avancer(920);

                Config.CurrentConfig.ServoBouton.SendPosition(Config.CurrentConfig.ServoBouton.Minimum);
                Thread.Sleep(1000);
                Plateau.Score += 25;
                Plateau.Elements.DomoticBoards[0].IsAvailable = false;
                
                Robots.GrosRobot.Avancer(120);
            }
            else
            {
                Robots.GrosRobot.Avancer(1040);

                Robots.GrosRobot.PivotDroite(180);

                Config.CurrentConfig.ServoBouton.SendPosition(Config.CurrentConfig.ServoBouton.Minimum);
                Thread.Sleep(1000);
                Plateau.Score += 25;
                Plateau.Elements.DomoticBoards[1].IsAvailable = false;
            }

            Robots.GrosRobot.PivotDroite(90);
            Config.CurrentConfig.ServoBouton.SendPosition(Config.CurrentConfig.ServoBouton.Maximum);
            Robots.GrosRobot.Avancer(100);
        }

        protected override void SequenceCore()
        {
            // Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
            {
                _avoidElements = true;
                Robots.GrosRobot.MajGraphFranchissable();
                while (!new MovementBee(Plateau.Elements.Flowers[0]).Execute()) ;
                while (!new MovementsCubesFromBottom(Plateau.Elements.CubesCrosses[0]).Execute());
                while (!new MovementsCubesFromBottom(Plateau.Elements.CubesCrosses[1]).Execute());
                while (!new MovementBuilding(Plateau.Elements.ConstructionZones[1]).Execute());
                //_avoidElements = true;
                //Robots.GrosRobot.MajGraphFranchissable();
                //fixedMovements.Add(new MouvementFusee(1));
            }
            else
            {
                _avoidElements = true;
                Robots.GrosRobot.MajGraphFranchissable();
                while (!new MovementBee(Plateau.Elements.Flowers[1]).Execute()) ;
                //fixedMovements.Add(new MouvementFusee(2));
            }
        }
    }
}
