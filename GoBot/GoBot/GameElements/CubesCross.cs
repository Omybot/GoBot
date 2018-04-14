using GoBot.Actionneurs;
using GoBot.Geometry.Shapes;
using GoBot.Movements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace GoBot.GameElements
{
    public class CubesCross : GameElement
    {
        public const int KCubeSize = 58;

        public enum CubePlace : byte
        {
            Bottom,
            Left,
            Center,
            Rigth,
            Top
        }

        public enum CubeColor : byte
        {
            Orange,
            Blue,
            Green,
            Yellow,
            Black,
            Empty,
            Joker
        }

        private int numero;
        private static int nextNumero;
        private Dictionary<CubePlace, CubeColor> colors;

        public CubesCross(RealPoint position, bool greenAtLeft)
            : base(position, Color.White, 184/2)
        {
            this.numero = nextNumero++;

            colors = new Dictionary<CubePlace, CubeColor>();

            colors.Add(CubePlace.Bottom, CubeColor.Blue);
            colors.Add(CubePlace.Center, CubeColor.Yellow);
            colors.Add(CubePlace.Top, CubeColor.Black);

            if (greenAtLeft)
            {
                colors.Add(CubePlace.Left, CubeColor.Green);
                colors.Add(CubePlace.Rigth, CubeColor.Orange);
            }
            else
            {
                colors.Add(CubePlace.Left, CubeColor.Orange);
                colors.Add(CubePlace.Rigth, CubeColor.Green);
            }
        }

        public IShape AsObstacle
        {
            get
            {
                return new Circle(position, 184 / 2);
            }
        }

        public CubeColor GetColor(CubePlace place)
        {
            return colors[place];
        }

        public void RemoveCube(CubePlace place)
        {
            colors[place] = CubeColor.Empty;
        }

        public override string ToString()
        {
            return "croix de cubes n°" + (numero+1).ToString();
        }

        public int CubesCount => colors.Where(o => o.Value != CubeColor.Empty).Count();

        public override void Paint(Graphics g, WorldScale scale)
        {
            if (isAvailable)
            {
                Point topLeft = scale.RealToScreenPosition(new RealPoint(position.X - KCubeSize * 1.5, position.Y - KCubeSize * 1.5));
                Size size = new Size(scale.RealToScreenDistance(KCubeSize), scale.RealToScreenDistance(KCubeSize));

                Color outlineColor = isHover ? Color.White : Color.Black;

                PaintCube(g, colors[CubePlace.Top], new Point(topLeft.X + size.Width, topLeft.Y), size, outlineColor);
                PaintCube(g, colors[CubePlace.Bottom], new Point(topLeft.X + size.Width, topLeft.Y + size.Height * 2), size, outlineColor);
                PaintCube(g, colors[CubePlace.Left], new Point(topLeft.X, topLeft.Y + size.Height), size, outlineColor);
                PaintCube(g, colors[CubePlace.Center], new Point(topLeft.X + size.Width, topLeft.Y + size.Height), size, outlineColor);
                PaintCube(g, colors[CubePlace.Rigth], new Point(topLeft.X + size.Width * 2, topLeft.Y + size.Height), size, outlineColor);
            }
        }

        private static Color CubeColorToColor(CubeColor color)
        {
            Color output = Color.Transparent;

            switch(color)
            {
                case CubeColor.Black:
                    output = Color.FromArgb(0, 0, 0);
                    break;
                case CubeColor.Orange:
                    output = Color.FromArgb(219, 114, 52);
                    break;
                case CubeColor.Green:
                    output = Color.FromArgb(96, 153, 58);
                    break;
                case CubeColor.Blue:
                    output = Color.FromArgb(0, 91, 140);
                    break;
                case CubeColor.Yellow:
                    output = Color.FromArgb(246, 181, 0);
                    break;
                case CubeColor.Joker:
                    output = Color.White;
                    break;
                case CubeColor.Empty:
                    output = Color.Transparent;
                    break;
            }

            return output;
        }

        public static void PaintCube(Graphics g, CubeColor color, Point topLeft, Size size, Color outlineColor, bool drawEmptyCubes = false)
        {
            Rectangle rect = new Rectangle(topLeft, size);

            if (color != CubeColor.Empty)
            {
                using (SolidBrush brush = new SolidBrush(CubeColorToColor(color)))
                {
                    g.FillRectangle(brush, rect);
                }
                using (Pen pen = new Pen(outlineColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }

            if (color == CubeColor.Joker)
            {
                topLeft.X += (size.Width - Properties.Resources.Star16.Width) / 2;
                topLeft.Y += (size.Height - Properties.Resources.Star16.Height) / 2;

                g.DrawImage(Properties.Resources.Star16, new Rectangle(topLeft, Properties.Resources.Star16.Size));
            }

            if (drawEmptyCubes && color == CubeColor.Empty)
            {
                topLeft.X += (size.Width - Properties.Resources.Star16.Width) / 2;
                topLeft.Y += (size.Height - Properties.Resources.Star16.Height) / 2;

                g.DrawImage(Properties.Resources.Close16, new Rectangle(topLeft, Properties.Resources.Close16.Size));
            }
        }

        public static void PaintCubesInRow(Graphics g, List<CubeColor> cubes, RealPoint bottomMiddle, WorldScale scale, bool markPattern)
        {
            Point topLeft = scale.RealToScreenPosition(bottomMiddle.Translation(0, - CubesCross.KCubeSize * 0.5));
            Size size = new Size(scale.RealToScreenDistance(CubesCross.KCubeSize), scale.RealToScreenDistance(CubesCross.KCubeSize));
            Point cubePosition = topLeft;

            for (int iCube = 0; iCube < cubes.Count; iCube++)
            {
                CubesCross.PaintCube(g, cubes[iCube], cubePosition, size, Color.Black, true);
                cubePosition.X += size.Width;
            }

            if (markPattern)
            {
                int patternIndex = Actionneur.PatternReader.Pattern.PatternPosition(cubes);

                if (patternIndex != -1)
                {
                    using (Pen pen = new Pen(Color.Lime))
                    {
                        Rectangle rct = new Rectangle(topLeft.X + patternIndex * size.Width + 1, topLeft.Y + 1, size.Width * 3 - 2, size.Height - 2);
                        g.DrawRectangle(pen, rct);
                        g.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Lime, Color.Transparent), rct);
                    }
                }
            }
        }
    }
}
