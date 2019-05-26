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
        private ServoElevationGold _servoElevation;
        private ServoClamp _servoClamp;

        private Goldenium _goldenium;

        public MoveGoldGrab(Goldenium goldenium)
        {
            _goldenium = goldenium;

            if (_goldenium.Owner == Plateau.CouleurDroiteViolet)
            {
                Positions.Add(new Position(-90, new RealPoint(_goldenium.Position.X - 100, 310)));
                _servoElevation = Config.CurrentConfig.ServoElevationGoldRight;
                _servoClamp = Config.CurrentConfig.ServoClampGoldRight;
            }
            else
            {
                Positions.Add(new Position(-90, new RealPoint(_goldenium.Position.X + 100, 300)));
                _servoElevation = Config.CurrentConfig.ServoElevationGoldLeft;
                _servoClamp = Config.CurrentConfig.ServoClampGoldLeft;
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

        protected override void MovementCore()
        {
            _servoElevation.SendPosition(_servoElevation.PositionApproach);
            _servoClamp.SendPosition(_servoClamp.PositionOpen);
            Thread.Sleep(500);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(70);
            Robots.GrosRobot.Stop(StopMode.Freely);

            _servoElevation.SendPosition(_servoElevation.PositionLocking);
            Thread.Sleep(500);
            _servoClamp.SendPosition(_servoClamp.PositionClose);
            Thread.Sleep(500);
            _servoElevation.SendPosition(_servoElevation.PositionApproach);
            Thread.Sleep(500);
            Robots.GrosRobot.Stop(StopMode.Abrupt);

            //if (Color == Plateau.CouleurDroiteViolet)
            //    Robots.GrosRobot.PivotGauche(5);
            //else
            //    Robots.GrosRobot.PivotDroite(5);

            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(150);

            _servoElevation.SendPosition(_servoElevation.PositionStored);

            Plateau.Strategy.GoldGrabed = true;

            Plateau.Score += 20; // Goldenium retiré
        }
    }
}
