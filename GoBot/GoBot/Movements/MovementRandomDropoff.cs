using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.BoardContext;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace GoBot.Movements
{
    class MovementRandomDropoff : Movement
    {
        private RandomDropOff _dropoff;

        public override bool CanExecute => Actionneur.Lifter.Loaded;

        public override int Score => 5;

        public override double Value => 3;

        public override GameElement Element => _dropoff;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => _dropoff.Owner;

        public MovementRandomDropoff(RandomDropOff dropoff)
        {
            _dropoff = dropoff;

            Positions.Add(new Position(0, new RealPoint(_dropoff.Position.X + 300 + 40, _dropoff.Position.Y)));
            Positions.Add(new Position(180, new RealPoint(_dropoff.Position.X - 300 - 40, _dropoff.Position.Y)));
        }

        protected override void MovementBegin()
        {
            // rien
        }

        protected override bool MovementCore()
        {
            Robots.MainRobot.SetSpeedSlow();
            Stopwatch sw = Stopwatch.StartNew();
            Actionneur.Lifter.DoTilterPositionDropoff();

            Robots.MainRobot.Move(-(270 - 85 * _dropoff.LoadsCount));

            int waitMs = 500 - (int)sw.ElapsedMilliseconds;
            if (waitMs > 0) Thread.Sleep(waitMs);
            Actionneur.Lifter.DoOpenAll();
            Thread.Sleep(100);
            Actionneur.Lifter.DoTilterPositionStore();
            Thread.Sleep(150);

            _dropoff.AddLoad(Actionneur.Lifter.Load);
            Actionneur.Lifter.Load = null;

            Actionneur.Lifter.DoStoreAll();
            Robots.MainRobot.Move(200);
            Robots.MainRobot.SetSpeedFast();

            Actionneur.Lifter.DoDisableAll();

            return true;
        }

        protected override void MovementEnd()
        {
            // rien
        }
    }
}
