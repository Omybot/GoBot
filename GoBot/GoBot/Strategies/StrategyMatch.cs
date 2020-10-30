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
using GoBot.Threading;

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
            initScore += 2; // Phare posé
            initScore += 15; // 2 manches à air
            GameBoard.Score = initScore;

            // Sortir ICI de la zonde de départ
            robot.UpdateGraph(GameBoard.ObstaclesAll);

            // codé en bleu avec miroir
            Elevator left = GameBoard.MyColor == GameBoard.ColorLeftBlue ? (Elevator)Actionneur.ElevatorLeft : Actionneur.ElevatorRight;
            Elevator right = GameBoard.MyColor == GameBoard.ColorLeftBlue ? (Elevator)Actionneur.ElevatorRight : Actionneur.ElevatorLeft;

            ThreadManager.CreateThread(link =>
            {
                left.DoGrabOpen();
                Thread.Sleep(750);
                left.DoGrabClose();
            }).StartThread();

            robot.MoveForward((int)(850 - 120 - Robots.MainRobot.LenghtBack + 50)); // Pour s'aligner sur le centre de l'écueil

            left.DoGrabOpen();

            robot.MoveBackward(50);

            right.DoGrabOpen();

            if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                GameBoard.Elements.FindBuoy(new RealPoint(450, 510)).IsAvailable = false;
            else
                GameBoard.Elements.FindBuoy(new RealPoint(3000 - 450, 510)).IsAvailable = false;

            robot.GoToAngle(-90);
            robot.SetSpeedSlow();
            robot.MoveForward(50);

            ThreadLink grabLink = ThreadManager.CreateThread(l => right.DoSequencePickupColor(GameBoard.MyColor == GameBoard.ColorLeftBlue ? Buoy.Green : Buoy.Red));
            grabLink.StartThread();
            Thread.Sleep(1000);

            Actionneur.ElevatorLeft.DoGrabOpen();
            Actionneur.ElevatorRight.DoGrabOpen();
            robot.MoveForward(450);
            grabLink.WaitEnd();




            //robot.MoveForward((int)(850 - 120 - Robots.MainRobot.LenghtBack)); // Pour s'aligner sur le centre de l'écueil

            //robot.GoToAngle(-90);
            //robot.SetSpeedSlow();
            //Actionneur.ElevatorLeft.DoGrabOpen();
            //Actionneur.ElevatorRight.DoGrabOpen();
            //robot.MoveForward(500);

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
                fixedMovements.Add(new MovementGroundedZone(GameBoard.Elements.GroundedZones[2]));
                fixedMovements.Add(new MovementBuoy(GameBoard.Elements.FindBuoy(new RealPoint(300, 400))));
                fixedMovements.Add(new MovementLightHouse(GameBoard.Elements.LightHouses[0]));
                fixedMovements.Add(new MovementGreenDropoff(GameBoard.Elements.RandomDropoffs[0]));
                fixedMovements.Add(new MovementGroundedZone(GameBoard.Elements.GroundedZones[0]));
                fixedMovements.Add(new MovementRedDropoff(GameBoard.Elements.RandomDropoffs[0]));
            }
            else
            {
                fixedMovements.Add(new MovementGroundedZone(GameBoard.Elements.GroundedZones[1]));
                fixedMovements.Add(new MovementBuoy(GameBoard.Elements.FindBuoy(new RealPoint(2700, 400))));
                fixedMovements.Add(new MovementLightHouse(GameBoard.Elements.LightHouses[1]));
                fixedMovements.Add(new MovementGreenDropoff(GameBoard.Elements.RandomDropoffs[1]));
                fixedMovements.Add(new MovementGroundedZone(GameBoard.Elements.GroundedZones[3]));
                fixedMovements.Add(new MovementRedDropoff(GameBoard.Elements.RandomDropoffs[1]));
            }
        }

        protected override void SequenceCore()
        {
            Movement bestMovement;

            int iMovement = 0;
            bool ok = true;

            // Execution de la strat fixe tant que rien n'échoue
            while (ok && iMovement < fixedMovements.Count)
            {
                int score = fixedMovements[iMovement].Score;
                ok = fixedMovements[iMovement].Execute();
                if (ok) GameBoard.Score += score;
                iMovement++;
            }

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
