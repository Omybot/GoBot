using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    class Buoy : GameElement
    {
        private Color _color;

        public Buoy(RealPoint position, Color owner, Color color, int hoverRadius) : base(position, owner, hoverRadius)
        {
            _color = color;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Circle c = new Circle(_position, _hoverRadius);
            c.Paint(g, _isHover ? Color.White : Color.Black, 1, _color, scale);
        }
    }
}
