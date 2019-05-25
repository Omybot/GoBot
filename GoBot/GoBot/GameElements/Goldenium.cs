using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class Goldenium : GameElementZone
    {
        public Goldenium(RealPoint position, Color color, int radius) : base(position, color, radius)
        {
        }

        public override string ToString()
        {
            return "Goldenium";
        }
    }
}
