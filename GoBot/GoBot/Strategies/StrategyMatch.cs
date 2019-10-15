using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoBot.Movements;
using GoBot.BoardContext;

namespace GoBot.Strategies
{
    class StrategyMatch : Strategy
    {
        private List<Movement> fixedMovements;

        public override bool AvoidElements => true;

        protected override void SequenceBegin()
        {
            // TODOEACHYEAR Actions fixes au lancement du match

            fixedMovements = new List<Movement>();

            // Ajouter les points fixes au score (non forfait, elements posés etc)
            GameBoard.Score = 42;

            // Sortir ICI de la zonde de départ
            Robots.GrosRobot.MajGraphFranchissable(GameBoard.ObstaclesAll);
            Robots.GrosRobot.Avancer(500);
            
            // Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
            {
                //*fixedMovements.Add(new MoveVoidZone(Plateau.Elements.VoidZoneYellow));
                //*fixedMovements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorYellow));
            }
            else
            {
                //*fixedMovements.Add(new MoveVoidZone(Plateau.Elements.VoidZoneViolet));
                //*fixedMovements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorViolet));
            }
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
