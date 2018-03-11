using GoBot.GameElements;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBot.Actionneurs
{
    class PatternReader
    {
        private CubesPattern readPattern;

        public CubesPattern Pattern
        {
            get { return readPattern; }
        }

        public PatternReader()
        {
            // TODO lecture du pattern
            readPattern = new CubesPattern(CubesCross.CubeColor.Green, CubesCross.CubeColor.Orange, CubesCross.CubeColor.Black);
        }

        public void Paint(Graphics g, WorldScale scale)
        {
            readPattern.Paint(g, new RealPoint(1500 - CubesCross.KCubeSize * 1.5, -20), scale);
        }
    }
}
