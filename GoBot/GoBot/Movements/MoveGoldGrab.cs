using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using GoBot.Actionneurs;
using System.Threading;
using Geometry;
using Geometry.Shapes;

namespace GoBot.Movements
{
    class MoveGoldGrab : Movement
    {
        private GoldGrabber _grabber;

        private Goldenium _goldenium;

        public MoveGoldGrab(Goldenium goldenium)
        {
            _goldenium = goldenium;

            if (_goldenium.Owner == Plateau.CouleurDroiteViolet)
            {
                Positions.Add(new Position(-90, new RealPoint(_goldenium.Position.X - 100, 360)));
                _grabber = Actionneur.GoldGrabberRight;
            }
            else
            {
                Positions.Add(new Position(-90, new RealPoint(_goldenium.Position.X + 100, 360)));
                _grabber = Actionneur.GoldGrabberLeft;
            }
        }

        public override bool CanExecute => Plateau.Strategy.GoldFree && !Plateau.Strategy.GoldGrabed;

        public override int Score => 0;

        public override double Value => IsCorrectColor() && Plateau.Strategy.GoldFree && !Plateau.Strategy.GoldGrabed ? 1 : 0;

        public override GameElement Element => _goldenium;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _goldenium.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementEnd()
        {
        }

        protected override void MovementCore()
        {
            Thread.Sleep(250);
            _grabber.DoUp();
            _grabber.DoOpen();
            Thread.Sleep(500);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(120);
            Robots.GrosRobot.Stop(StopMode.Freely);

            _grabber.DoDown();
            Thread.Sleep(500);
            _grabber.DoClose();
            Thread.Sleep(500);
            _grabber.DoUp();
            Thread.Sleep(500);
            Robots.GrosRobot.Stop(StopMode.Abrupt);

            //if (Color == Plateau.CouleurDroiteViolet)
            //    Robots.GrosRobot.PivotGauche(5);
            //else
            //    Robots.GrosRobot.PivotDroite(5);

            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(150);

            _grabber.DoStore();

            Plateau.Strategy.GoldGrabed = true;

            Plateau.Score += 20; // Goldenium retiré
        }
    }
}
