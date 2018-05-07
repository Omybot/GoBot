using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;

namespace GoBot.Movements
{
    class MovementDomoticBoard : Movement
    {
        private DomoticBoard _board;

        public MovementDomoticBoard(DomoticBoard board)
        {
            _board = board;

            Positions.Add(new Geometry.Position(-90, new Geometry.Shapes.RealPoint(_board.Color == Plateau.CouleurGaucheVert ? 1130 : 1870, 400)));
        }

        public override bool CanExecute => _board.IsAvailable;

        public override double Score => 25;

        public override double Value => 25;

        public override GameElement Element => _board;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _board.Color;

        protected override void MovementBegin()
        {
            // Préparer le bras ?
        }

        protected override void MovementCore()
        {
            Robots.GrosRobot.Avancer(180);

            // Pousser l'interrupteur

            _board.IsAvailable = false;

            Robots.GrosRobot.Reculer(180);
        }
    }
}
