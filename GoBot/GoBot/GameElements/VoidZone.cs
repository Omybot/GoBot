using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class VoidZone : GameElementZone
    {
        int _atomsCount;
        bool _isObstacle;

        public VoidZone(RealPoint position, Color color, int radius) : base(position, color, radius)
        {
            _atomsCount = 4;
        }

        public int AtomsCount { get => _atomsCount; set => _atomsCount = value; }
        public bool IsObstacle { get => _isObstacle; set => _isObstacle = value; }
    }
}
