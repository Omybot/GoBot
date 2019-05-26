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
        private ServoElevationGold _servoElevation;
        private ServoClamp _servoClamp;

        Balance _balance;

        public MoveBalance(Balance balance)
        {
            _balance = balance;

            if(_balance.Owner == Plateau.CouleurDroiteViolet)
            {
                Positions.Add(new Geometry.Position(-90, new Geometry.Shapes.RealPoint(3000 - (1772 - 50), 1300)));
                _servoElevation = Config.CurrentConfig.ServoElevationGoldRight;
                _servoClamp = Config.CurrentConfig.ServoClampRight;
            }
            else
            {
                Positions.Add(new Geometry.Position(-90, new Geometry.Shapes.RealPoint(1772 - 50, 1300)));
                _servoElevation = Config.CurrentConfig.ServoElevationGoldLeft;
                _servoClamp = Config.CurrentConfig.ServoClampLeft;
            }
        }

        public override bool CanExecute => _balance.AtomsCount < 6; // TODO if goldenium chargé

        public override int Score => 0;

        public override double Value => IsCorrectColor() ? 1 : 0;

        public override GameElement Element => _balance;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _balance.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            _servoElevation.SendPosition(_servoElevation.PositionLocking);
            Robot.Lent();
            Robot.Recallage(SensAR.Avant);
            _servoClamp.SendPosition(_servoClamp.PositionOpen);
            Robot.Rapide();

            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(100);
            _servoClamp.SendPosition(_servoClamp.PositionOpen);

            Config.CurrentConfig.ServoElevationGoldRight.SendPosition(17000); // TODO position poussage
            Robots.GrosRobot.Avancer(950);
            Robots.GrosRobot.Reculer(100);

            _servoClamp.SendPosition(_servoClamp.PositionClose);
            _servoElevation.SendPosition(_servoElevation.PositionStored);
        }
    }
}
