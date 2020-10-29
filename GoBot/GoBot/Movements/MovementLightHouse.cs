using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.BoardContext;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Movements
{
    class MovementLightHouse : Movement
    {
        LightHouse _lightHouse;

        public MovementLightHouse(LightHouse lighthouse)
        {
            _lightHouse = lighthouse;

            Positions.Add(new Position(-90, new RealPoint(_lightHouse.Position.X, 275)));
        }

        public override bool CanExecute
        { get
            {
                Buoy b = _lightHouse.Position.X < 1500 ? GameBoard.Elements.FindBuoy(new Geometry.Shapes.RealPoint(300, 400)) : GameBoard.Elements.FindBuoy(new Geometry.Shapes.RealPoint(2700, 400));
                return !_lightHouse.Enable && !b.IsAvailable;
            }
        }

        public override int Score => (10 + 3);

        public override double Value => 1.2;

        public override GameElement Element => _lightHouse;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => _lightHouse.Owner;

        protected override void MovementBegin()
        {
        }

        protected override bool MovementCore()
        {
            Robot.SetSpeedVerySlow();
            Robot.Recalibration(SensAR.Avant, true, true);
            Actionneur.ElevatorLeft.DoPushLight();
            Actionneur.ElevatorLeft.DoPushLight();
            Thread.Sleep(500);
            _lightHouse.Enable = true;
            Actionneur.ElevatorLeft.DoPushInsideFast();
            Actionneur.ElevatorLeft.DoPushInsideFast();
            Robot.SetSpeedFast();
            Robots.MainRobot.MoveBackward(100);

            return true;
        }

        protected override void MovementEnd()
        {
        }
    }
}
