using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class Slope : GameElementZone
    {
        private bool _hasAtoms;

        public Slope(RealPoint position, Color color, int radius) : base(position, color, radius)
        {
        }

        public bool HasAtoms { get => _hasAtoms; set => _hasAtoms = value; }
    }
}
