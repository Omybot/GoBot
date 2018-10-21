using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GoBot.Movements;
using GoBot.Threading;

namespace GoBot.Strategies
{
    class StrategyMatch : Strategy
    {
        private List<Movement> fixedMovements;

        public override bool AvoidElements => false;

        protected override void SequenceBegin()
        {
            // TODOEACHYEAR

            fixedMovements = new List<Movement>();

            // Sortir ICI de la zonde de départ

            Plateau.Score = 0;

            ThreadManager.CreateThread(link => InitArms()).StartThread();

            Robots.GrosRobot.Avancer(50);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                Robots.GrosRobot.PivotDroite(5);
            else
                Robots.GrosRobot.PivotGauche(5);

            Robots.GrosRobot.Avancer(900);

            // Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
            {
                //fixedMovements.Add(new MouvementFusee(1));
            }
            else
            {
                //fixedMovements.Add(new MouvementFusee(2));
            }
        }

        private void InitArms()
        {

            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionApprocheHaute);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionApprocheHaute);
            Thread.Sleep(500);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionStockage);
            Config.CurrentConfig.ServoLateralDroite.SendPosition(Config.CurrentConfig.ServoLateralDroite.PositionDroite);
            Config.CurrentConfig.ServoPoignetDroite.SendPosition(Config.CurrentConfig.ServoPoignetDroite.PositionPrise);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            Thread.Sleep(500);
            Config.CurrentConfig.ServoCoudeDroite.SendPosition(Config.CurrentConfig.ServoCoudeDroite.PositionRange);
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.PositionRange);

        }

        protected override void SequenceCore()
        {
            Movement bestMovement;

            int iMovement = 0;

            // Execution de la strat fixe tant que rien n'échoue
            while (iMovement < fixedMovements.Count && fixedMovements[iMovement].Execute())
                iMovement++;

            // Passage en mode recherche de la meilleure action
            while (IsRunning)
            {
                List<Movement> sorted = Movements.Where(m => m.IsCorrectColor() && m.CanExecute).OrderBy(m => m.GlobalCost).ToList();

                if (sorted.Count > 0)
                {
                    bestMovement = sorted[0];

                    if (bestMovement.GlobalCost != double.MaxValue && bestMovement.Value != 0)
                    {
                        if (!bestMovement.Execute())
                            bestMovement.Deactivate(new TimeSpan(0, 0, 1));
                    }
                    else
                    {
                        Robots.GrosRobot.Historique.Log("Aucune action à effectuer");
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Aucune action à effectuer");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
