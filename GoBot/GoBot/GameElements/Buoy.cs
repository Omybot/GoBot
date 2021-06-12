using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class Buoy : GameElement
    {
        public static Color Red = Color.FromArgb(187, 30, 16);
        public static Color Green = Color.FromArgb(0, 111, 61);

        private Color _color;

        private bool _virtual;

        public Buoy(RealPoint position, Color owner, Color color, bool isVirtual = false) : base(position, owner, 36)
        {
            _color = color;
            _virtual = isVirtual;
        }

        public Color Color => _color;

        public bool IsVirtual => _virtual;

        public override void Paint(Graphics g, WorldScale scale)
        {
            if (_isAvailable)
            {
                Circle c = new Circle(_position, _hoverRadius);
                c.Paint(g, _isHover ? Color.White : Color.Black, 1, _color, scale);
            }
        }
    }
}
