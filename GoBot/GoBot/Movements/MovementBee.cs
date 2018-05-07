using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;

namespace GoBot.Movements
{
    class MovementBee : Movement
    {
        private Flower _flower;

        public MovementBee(Flower flower)
        {
            _flower = flower;

            Positions.Add(new Geometry.Position(90, flower.Position.Translation(_flower.Color == Plateau.CouleurGaucheVert ? -1100 : 1200, -115 - 350)));
        }

        public override bool CanExecute => _flower.IsAvailable;

        public override double Score => 50;

        public override double Value => Score;

        public override GameElement Element => _flower;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _flower.Color;

        protected override void MovementBegin()
        {
            // Préparer le bras pour pousser l'abeille mais sans géner le déplacement
        }

        protected override void MovementCore()
        {
            // Finir d'ouvrir le bras (on est face à l'abeille)

            Robot.Avancer(150);

            // Pousser l'abeille

            Robot.Reculer(150);

            _flower.IsAvailable = false;
        }
    }
}
