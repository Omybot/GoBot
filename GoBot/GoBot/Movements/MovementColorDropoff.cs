using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.BoardContext;
using GoBot.GameElements;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace GoBot.Movements
{
    public class MovementColorDropoff : Movement
    {
        ColorDropOff _zone;

        public MovementColorDropoff(ColorDropOff zone)
        {
            _zone = zone;

            Positions.Add(new Position(90, new RealPoint(_zone.Position.X, _zone.Position.Y - 450)));
        }

        public override bool CanExecute =>
            _zone.Owner == GameBoard.MyColor &&
            Math.Max(_zone.LoadsOnRed, _zone.LoadsOnRed) < 4 &&
            !Actionneur.Lifter.Loaded &&
            Actionneur.ElevatorLeft.CountTotal + Actionneur.ElevatorLeft.CountTotal > 0;

        public override int Score => 0; // On va compter les points de ménière plus précise

        public override double Value => Actionneur.ElevatorLeft.CountTotal + Actionneur.ElevatorLeft.CountTotal;

        public override GameElement Element => _zone;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => _zone.Owner;

        protected override void MovementBegin()
        {
            // Rien, mais on peut envisager de pré-décharger SI y'a pas de gobelet à attraper à l'arrivée ?
        }

        protected override bool MovementCore()
        {
            // TODO : Attrapage (avec test) des bouées exterieures, d'ailleurs prévoir de la place pour les attraper

            if (_zone.HasOutsideBuoys)
            {
                Robot.SetSpeedSlow();
                Actionneur.ElevatorLeft.DoGrabOpen();
                Actionneur.ElevatorRight.DoGrabOpen();
                Robot.Move(250);
                Robot.SetSpeedFast();
                ThreadManager.CreateThread(link => { Actionneur.ElevatorLeft.DoSequencePickupColor(Buoy.Red); }).StartThread();
                ThreadManager.CreateThread(link => { Actionneur.ElevatorRight.DoSequencePickupColor(Buoy.Green); }).StartThread();
                _zone.TakeOutsideBuoys();
                Thread.Sleep(500);
                Robot.PivotRight(180);
                Robot.Move(-150);
            }
            else
            {
                Robot.Move(-400);
            }

            Robot.SetSpeedSlow();

            if (_zone.HasInsideBuoys)
            {
                Robot.Recalibration(SensAR.Arriere, true, true);
                // TODO recallage X et Y tant qu'à faire ?
                DoFingersGrab(); // Attrapage des bouées initialement contre la bordure avec les fingers
                _zone.TakeInsideBuoys();
                Robot.SetSpeedFast();
                Robot.Move(150);
                Robot.PivotLeft(180);
                Robot.Move(125);
                Robot.SetSpeedSlow();
                DoElevatorsDropoff(0);
            }
            else
            {
                // TODO, y'a surement des bouées posées, donc pas de recallage et avancer moins
            }

            bool hasLeft = Actionneur.FingerLeft.Loaded;
            bool hasRight = Actionneur.FingerRight.Loaded;

            if (hasLeft || hasRight)
            {
                Color cLeft = Actionneur.FingerLeft.Load;
                Color cRight = Actionneur.FingerRight.Load;

                _zone.SetPendingLeft(cLeft, new RealPoint(Robot.Position.Coordinates.X + 193.5, Robot.Position.Coordinates.Y - 86.5));
                Actionneur.FingerLeft.DoRelease();
                _zone.SetPendingRight(cRight, new RealPoint(Robot.Position.Coordinates.X - 193.5, Robot.Position.Coordinates.Y - 86.5));
                Actionneur.FingerRight.DoRelease();

                Robot.MoveBackward(250);
                Actionneur.ElevatorLeft.DoGrabOpen();
                Robot.MoveForward(250 - 85);

                int score = 0;
                int level = _zone.GetAvailableLevel();
                if (hasLeft)
                {
                    _zone.SetBuoyOnGreen(cRight, level);
                    score += 2;
                }
                if (hasRight)
                {
                    _zone.SetBuoyOnRed(cLeft, level);
                    score += 2;
                }

                _zone.RemovePending();

                if (hasLeft && hasRight)
                    score += 2;

                GameBoard.Score += score;
            }

            Robot.Move((int)(Positions[0].Coordinates.Y - Robot.Position.Coordinates.Y) - 100); // TODO tester la présence d'un adversaire ptet ?

            Robot.SetSpeedFast();

            return true;
        }

        private void DoFingersGrab()
        {
            ThreadLink left = ThreadManager.CreateThread(link => Actionneur.FingerLeft.DoGrabColor(Buoy.Red));
            ThreadLink right = ThreadManager.CreateThread(link => Actionneur.FingerRight.DoGrabColor(Buoy.Green));

            left.StartThread();
            right.StartThread();

            left.WaitEnd();
            right.WaitEnd();
        }

        private void DoElevatorsDropoff(int level)
        {
            Color colorLeft = Color.Transparent, colorRight = Color.Transparent;
            bool okColorLeft, okColorRight;

            ThreadLink left = ThreadManager.CreateThread(link => colorLeft = Actionneur.ElevatorLeft.DoSequenceDropOff());
            ThreadLink right = ThreadManager.CreateThread(link => colorRight = Actionneur.ElevatorRight.DoSequenceDropOff());

            while (_zone.LoadsOnGreen < 4 && _zone.LoadsOnRed < 4 && Actionneur.ElevatorLeft.CountTotal > 0 && Actionneur.ElevatorRight.CountTotal > 0)
            {
                left.StartThread();
                right.StartThread();

                left.WaitEnd();
                right.WaitEnd();

                if (colorLeft != Color.Transparent)
                {
                    _zone.SetBuoyOnRed(colorLeft, level);
                    okColorLeft = (colorLeft == Buoy.Red);
                    GameBoard.Score += (1 + (okColorLeft ? 1 : 0));
                }
                else
                {
                    okColorLeft = false;
                }

                if (colorRight != Color.Transparent)
                {
                    _zone.SetBuoyOnGreen(colorRight, level);
                    okColorRight = (colorRight == Buoy.Green);
                    GameBoard.Score += (1 + (okColorRight ? 1 : 0));
                }
                else
                {
                    okColorRight = false;
                }

                if (okColorLeft && okColorRight)
                    GameBoard.Score += 2;

                level++;

                Robot.Move(-85);
            }

            // Pour ranger à la fin :
            Actionneur.ElevatorLeft.DoPushInside();
            Actionneur.ElevatorRight.DoPushInside();
        }

        protected override void MovementEnd()
        {
            // rien ?
        }
    }
}
