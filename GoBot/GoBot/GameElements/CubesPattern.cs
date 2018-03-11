using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBot.GameElements
{
    class CubesPattern
    {
        private List<CubesCross.CubeColor> colors;

        public CubesPattern(CubesCross.CubeColor color1, CubesCross.CubeColor color2, CubesCross.CubeColor color3)
        {
            colors = new List<CubesCross.CubeColor>();
            colors.Add(color1);
            colors.Add(color2);
            colors.Add(color3);
        }

        public int PatternPosition(List<CubesCross.CubeColor> cubes)
        {
            bool match = false;
            int i = 0;

            while (i < cubes.Count - 2 && !match)
            {
                match = TestColors(cubes[i], cubes[i + 1], cubes[i + 2]);
                i++;
            }

            return match ? i-1 : -1;
        }

        private bool TestColors(CubesCross.CubeColor color1, CubesCross.CubeColor color2, CubesCross.CubeColor color3)
        {
            if (new List<CubesCross.CubeColor>() { color1, color2, color3 }.Where(c => c == CubesCross.CubeColor.Joker).Count() > 1)
                return false;

            if ((color1 == colors[0] || color1 == CubesCross.CubeColor.Joker) &&
                (color2 == colors[1] || color2 == CubesCross.CubeColor.Joker) &&
                (color3 == colors[2] || color3 == CubesCross.CubeColor.Joker))
                return true;

            if ((color1 == colors[2] || color1 == CubesCross.CubeColor.Joker) &&
                (color2 == colors[1] || color2 == CubesCross.CubeColor.Joker) &&
                (color3 == colors[0] || color3 == CubesCross.CubeColor.Joker))
                return true;

            return false;
        }


        public void Paint(Graphics g, RealPoint pos, WorldScale scale)
        {
            CubesCross.PaintCubesInRow(g, colors, pos, scale, false);
        }
    }
}
