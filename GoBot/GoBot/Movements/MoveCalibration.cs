using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using GoBot.Actionneurs;

namespace GoBot.Movements
{
    public class MoveCalibration : Movement
    {
        private ZoneCalibration _zone;

        public MoveCalibration(ZoneCalibration zone)
        {
            _zone = zone;

            Positions.Add(new Geometry.Position(90, zone.Position));
        }

        public override bool CanExecute => Actionneur.GoldGrabberLeft.NeedCalibration || Actionneur.GoldGrabberRight.NeedCalibration;

        public override int Score => 0;

        public override double Value => Plateau.Strategy.TimeBeforeEnd.TotalSeconds > 20 ? 30 : 0;

        public override GameElement Element => _zone;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _zone.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            // TODO détecter LIDAR qu'on a pas de palet qui empeche le recallage

            Recallages.RecallageGrosRobot();

            Robot.Lent();
            Robot.Avancer(150);
            Robot.Rapide();
        }

        protected override void MovementEnd()
        {
        }
    }
}
