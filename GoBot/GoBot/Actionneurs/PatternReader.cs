using GoBot.GameElements;
using System;
using System.Collections.Generic;
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
    }
}
