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
            
            Robots.GrosRobot.SpeedConfig.SetParams(1000, 1500, 2000, 1000, 2000, 2000);
            //Robots.GrosRobot.SpeedConfig.SetParams(500, 500, 500, 500, 500, 500);
            
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
            {
                Robots.GrosRobot.Avancer(920);

                Config.CurrentConfig.ServoBouton.SendPosition(Config.CurrentConfig.ServoBouton.Minimum);
                Thread.Sleep(1000);
                Plateau.Score += 25;
                
                Robots.GrosRobot.Avancer(120);
            }
            else
            {
                Robots.GrosRobot.Avancer(1040);

                Robots.GrosRobot.PivotDroite(180);

                Config.CurrentConfig.ServoBouton.SendPosition(Config.CurrentConfig.ServoBouton.Minimum);
                Thread.Sleep(1000);
            }

            Robots.GrosRobot.SpeedConfig.SetParams(500, 1000, 1500, 500, 1000, 2000);

            Robots.GrosRobot.PivotDroite(90);
            Config.CurrentConfig.ServoBouton.SendPosition(Config.CurrentConfig.ServoBouton.Maximum);
            Robots.GrosRobot.Avancer(100);
        }

        protected override void SequenceCore()
        {
            // TODOYEACHYEAR Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
            {
                _avoidElements = true;
                Robots.GrosRobot.MajGraphFranchissable(Plateau.ListeObstacles);
            }
            else
            {
                _avoidElements = true;
                Robots.GrosRobot.MajGraphFranchissable(Plateau.ListeObstacles);
            }
        }
    }
}
