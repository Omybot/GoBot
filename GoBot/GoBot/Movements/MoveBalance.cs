using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoBot.Actionneurs;
using System.Threading;

namespace GoBot.Movements
{
    public class MoveBalance : Movement
    {
        private GoldGrabber _grabber;

        Balance _balance;

        public MoveBalance(Balance balance)
        {
            _balance = balance;

            if(_balance.Owner == Plateau.CouleurDroiteViolet)
            {
                Positions.Add(new Geometry.Position(90, new Geometry.Shapes.RealPoint(1772 - 50, 1300)));
                _grabber = Actionneur.GoldGrabberRight;
            }
            else
            {
                Positions.Add(new Geometry.Position(90, new Geometry.Shapes.RealPoint(3000 - (1772 - 50), 1300)));
                _grabber = Actionneur.GoldGrabberLeft;
            }
        }

        public override bool CanExecute => _balance.AtomsCount < 6 && (Actionneur.GoldGrabberLeft.Loaded || Actionneur.GoldGrabberRight.Loaded); // TODO if goldenium chargé

        public override int Score => 0;

        public override double Value => IsCorrectColor() ? ((Actionneur.GoldGrabberLeft.Loaded || Actionneur.GoldGrabberRight.Loaded) ? 100 : 0) : 0;

        public override GameElement Element => _balance;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _balance.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementEnd()
        {
        }

        protected override void MovementCore()
        {
            _grabber.DoDown();
            Robot.Lent();

            if(Robot.GetType().Name == "RobotSimu")
                Robot.Avancer(100);
            else
                Robot.Recallage(SensAR.Avant);

            Robot.Rapide();

            _grabber.DoOpen();

            Plateau.Score += 24; // Goldenium dans la balance

            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(100);

            _grabber.DoClose();
            _grabber.DoStore();
        }
    }
}
