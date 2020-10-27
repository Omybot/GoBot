using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.GameElements
{
    public class GroundedZone : GameElementZone
    {
        private List<Buoy> _buoys;

        public GroundedZone(RealPoint position, Color color, List<Buoy> buoys) : base(position, color, 150)
        {
            _buoys = buoys;
        }

        public List<Buoy> Buoys => _buoys;
    }
}
