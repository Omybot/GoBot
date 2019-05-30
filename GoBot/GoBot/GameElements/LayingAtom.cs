using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class LayingAtom : GameElement
    {
        private Color _color;

        public LayingAtom(RealPoint position, Color owner, Color color) : base(position, owner, 38)
        {
            _color = color;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Rectangle rct = scale.RealToScreenRect(new RectangleF((float)_position.X - 38, (float)_position.Y - 38, 76, 76));

            Brush b = new SolidBrush(_color);
            g.FillEllipse(b, rct);
            b.Dispose();

            if (_isHover)
                g.DrawEllipse(Pens.White, rct);
            else
                g.DrawEllipse(Pens.Black, rct);
        }
    }
}
