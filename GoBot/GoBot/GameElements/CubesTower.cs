using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using GoBot.Actionneurs;
using Geometry;

namespace GoBot.GameElements
{
    public class CubesTower : GameElement
    {
        private List<CubesCross.CubeColor> cubes;

        public CubesTower(RealPoint position) : base(position, Color.White, 0)
        {
            this.cubes = new List<CubesCross.CubeColor>();
        }

        public CubesTower(List<CubesCross.CubeColor> cubes) : base(new RealPoint(0, 0), Color.White, 0)
        {
            this.cubes = new List<CubesCross.CubeColor>(cubes.GetRange(0, Math.Min(cubes.Count, 5)));
        }

        public void AddCube(CubesCross.CubeColor cube)
        {
            cubes.Add(cube);
        }

        public override bool ClickAction()
        {
            // Rien ?
            return true;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Point topLeft = scale.RealToScreenPosition(new RealPoint(position.X - CubesCross.KCubeSize * 0.5, position.Y - CubesCross.KCubeSize * 0.5));
            Size size = new Size(scale.RealToScreenDistance(CubesCross.KCubeSize), scale.RealToScreenDistance(CubesCross.KCubeSize));
            Point cubePosition = topLeft;

            for (int iCube = 0; iCube < cubes.Count; iCube++)
            {
                CubesCross.PaintCube(g, cubes[iCube], cubePosition, size, Color.Black, true);
                cubePosition.Y -= size.Height;
            }
            
            int patternIndex = Actionneur.PatternReader.Pattern.PatternPosition(cubes);

            if(patternIndex != -1)
            {
                using (Pen pen = new Pen(Color.Lime))
                {
                    Rectangle rct = new Rectangle(topLeft.X + 1, topLeft.Y - (patternIndex + 2) * size.Height + 1, size.Width - 2, size.Height * 3 - 2);
                    g.DrawRectangle(pen, rct);
                    g.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Lime, Color.Transparent), rct);
                }
            }
        }

        public int Score
        {
            get
            {
                int total = 0;

                for(int i = 0; i < 5; i++)
                    if (cubes.Count > i)
                        total += (i + 1);

                if (this.ContainsPattern)
                    total += 30;

                return total;
            }
        }

        public bool ContainsPattern
        {
            get
            {
                return Actionneur.PatternReader.Pattern.PatternPosition(cubes) != -1;
            }
        }
    }
}
