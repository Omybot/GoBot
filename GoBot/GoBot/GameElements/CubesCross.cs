using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.GameElements
{
    public class CubesCross : GameElement
    {
        private const int KCubeSize = 58;

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
        public Dictionary<CubePlace, CubeColor> colors;

        public CubesCross(RealPoint position, bool greenAtLeft)
            : base(position, Color.White, 184/2)
        {
            this.numero = nextNumero++;

            colors = new Dictionary<CubePlace, CubeColor>();

            colors.Add(CubePlace.Bottom, CubeColor.Blue);
            colors.Add(CubePlace.Center, CubeColor.Joker);
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

        public override string ToString()
        {
            return "croix de cubes n°" + (numero+1).ToString();
        }

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

        public override bool ClickAction()
        {
            return true;
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

        public static void PaintCube(Graphics g, CubeColor color, Point topLeft, Size size, Color outlineColor)
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
            
            if(color == CubeColor.Joker)
            {
                topLeft.X += (size.Width - Properties.Resources.Star16.Width) / 2;
                topLeft.Y += (size.Height - Properties.Resources.Star16.Height) / 2;

                g.DrawImage(Properties.Resources.Star16, new Rectangle(topLeft, Properties.Resources.Star16.Size));
            }
        }
    }
}
