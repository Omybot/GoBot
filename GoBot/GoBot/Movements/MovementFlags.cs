using GoBot.Actionneurs;
using GoBot.BoardContext;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Movements
{
    class MovementFlags : Movement
    {
        public override bool CanExecute => true;

        public override int Score => 10;

        public override double Value => 0;

        public override GameElement Element => null;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => GameBoard.ColorNeutral;

        protected override void MovementBegin()
        {
        }

        protected override bool MovementCore()
        {
            Actionneur.Flags.DoOpenLeft();
            Actionneur.Flags.DoOpenRight();

            return true;
        }

        protected override void MovementEnd()
        {
        }
    }
}
