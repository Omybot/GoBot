using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.GameElements
{
    class StandingAtom : GameElement
    {
        private Color _color;

        public StandingAtom(RealPoint position, Color owner, Color color) : base(position, owner, 38)
        {
            _color = color;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Rectangle rct = scale.RealToScreenRect(new RectangleF((float)(_position.X - 38), (float)(_position.Y - 12.5), 76, 25));

            Brush b = new SolidBrush(_color);
            g.FillRectangle(b, rct);
            b.Dispose();

            if(_isHover)
                g.DrawRectangle(Pens.White, rct);
            else
                g.DrawRectangle(Pens.Black, rct);
        }
    }
}
