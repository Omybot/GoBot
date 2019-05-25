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

            Positions.Add(new Position(90, new RealPoint(_goldenium.Position.X, _goldenium.Position.Y - 150)));

            if (_goldenium.Owner == Plateau.CouleurDroiteViolet)
            {
                _servoElevation = Config.CurrentConfig.ServoElevationGoldRight;
                _servoClamp = Config.CurrentConfig.ServoClampRight;
            }
            else
            {
                _servoElevation = Config.CurrentConfig.ServoElevationGoldLeft;
                _servoClamp = Config.CurrentConfig.ServoClampLeft;
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

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Avant);

            _servoElevation.SendPosition(_servoElevation.PositionLocking);
            Thread.Sleep(500);
            _servoClamp.SendPosition(_servoClamp.PositionClose);
            Thread.Sleep(500);
            _servoElevation.SendPosition(_servoElevation.PositionApproach);
            Thread.Sleep(500);

            if (Color == Plateau.CouleurDroiteViolet)
                Robots.GrosRobot.PivotGauche(5);
            else
                Robots.GrosRobot.PivotDroite(5);
            
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(150);

            _servoElevation.SendPosition(_servoElevation.PositionStored);

            Plateau.Strategy.GoldGrabed = true;

            Plateau.Score += 20; // Goldenium retiré
        }
    }
}
