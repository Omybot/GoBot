using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class Balance : GameElementZone
    {
        int _atomsCount;
        
        public Balance(RealPoint position, Color color, int radius) : base(position, color, radius)
        {
            _atomsCount = 0;
        }

        public int AtomsCount
        {
            get { return _atomsCount; }
            set { _atomsCount = value; }
        }

        public override string ToString()
        {
            return "Balance";
        }
    }
}
