using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoBot.Movements;
using GoBot.BoardContext;
using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.GameElements;

namespace GoBot.Strategies
{
    class StrategyMatch : Strategy
    {
        private List<Movement> fixedMovements;

        public override bool AvoidElements => true;

        protected override void SequenceBegin()
        {
            // TODOEACHYEAR Actions fixes au lancement du match

            Robot robot = Robots.MainRobot;

            fixedMovements = new List<Movement>();

            // Ajouter les points fixes au score (non forfait, elements posés etc)
            int initScore = 0;
            initScore += 7; // Non forfait + phare posé
            initScore += 15; // 2 manches à air
            initScore += (3 + 10); // Phare appuyé + déployé
            GameBoard.Score = initScore;

            // Sortir ICI de la zonde de départ
            robot.UpdateGraph(GameBoard.ObstaclesAll);

            robot.MoveForward((int)(850 - 120 - Robots.MainRobot.LenghtBack)); // Pour s'aligner sur le centre de l'écueil

            robot.GoToAngle(-90);
            robot.SetSpeedSlow();
            Actionneur.ElevatorLeft.DoGrabOpen();
            Actionneur.ElevatorRight.DoGrabOpen();
            robot.MoveForward(500);

            Threading.ThreadManager.CreateThread(link => { Actionneur.ElevatorLeft.DoSequencePickupColor(Buoy.Red); }).StartThread();
            Threading.ThreadManager.CreateThread(link => { Actionneur.ElevatorRight.DoSequencePickupColor(Buoy.Green); }).StartThread();

            List<Buoy> taken = GameBoard.Elements.Buoys.Where(b => b.Position.X < robot.Position.Coordinates.X + 200 && b.Position.X > robot.Position.Coordinates.X - 200 && b.Position.Y < 1000 && b.Position.Y > 0).ToList();
            taken.ForEach(b => b.IsAvailable = false);

            Thread.Sleep(500);

            robot.MoveBackward(35);
            robot.SetSpeedFast();
            robot.Pivot(180);

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
                        int score = bestMovement.Score;

                        if (bestMovement.Execute())
                            GameBoard.Score += score;
                        else
                            bestMovement.Deactivate(new TimeSpan(0, 0, 1));
                    }
                    else
                    {
                        Robots.MainRobot.Historique.Log("Aucune action à effectuer");
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    Robots.MainRobot.Historique.Log("Aucune action à effectuer");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
