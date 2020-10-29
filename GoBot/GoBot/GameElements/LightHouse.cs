using System.Drawing;

using Geometry;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class LightHouse : GameElement
    {
        private bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        public LightHouse(RealPoint position, Color owner) : base(position, owner, 100)
        {
            _enable = false;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            new Circle(new RealPoint(Position.X, Position.Y), _hoverRadius).Paint(g, Pens.Black, _enable ? Brushes.LimeGreen : Brushes.WhiteSmoke, scale);
        }
    }
}
