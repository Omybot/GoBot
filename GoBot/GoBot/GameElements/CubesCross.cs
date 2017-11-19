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
                Rectangle rect;
                Pen pen = isHover ? Pens.White : Pens.Black;

                if (colors[CubePlace.Top] != CubeColor.Empty)
                {
                    rect = new Rectangle(topLeft.X + size.Width, topLeft.Y, size.Width, size.Height);
                    using (SolidBrush brush = new SolidBrush(CubeColorToColor(colors[CubePlace.Top])))
                    {
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
                if (colors[CubePlace.Bottom] != CubeColor.Empty)
                {
                    rect = new Rectangle(topLeft.X + size.Width, topLeft.Y + size.Width * 2, size.Width, size.Height);
                    using (SolidBrush brush = new SolidBrush(CubeColorToColor(colors[CubePlace.Bottom])))
                    {
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
                if (colors[CubePlace.Left] != CubeColor.Empty)
                {
                    rect = new Rectangle(topLeft.X, topLeft.Y + size.Width, size.Width, size.Height);
                    using (SolidBrush brush = new SolidBrush(CubeColorToColor(colors[CubePlace.Left])))
                    {
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
                if (colors[CubePlace.Center] != CubeColor.Empty)
                {
                    rect = new Rectangle(topLeft.X + size.Width, topLeft.Y + size.Width, size.Width, size.Height);
                    using (SolidBrush brush = new SolidBrush(CubeColorToColor(colors[CubePlace.Center])))
                    {
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
                if (colors[CubePlace.Rigth] != CubeColor.Empty)
                {
                    rect = new Rectangle(topLeft.X + size.Width * 2, topLeft.Y + size.Width, size.Width, size.Height);
                    using (SolidBrush brush = new SolidBrush(CubeColorToColor(colors[CubePlace.Rigth])))
                    {
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
            }
        }

        public override bool ClickAction()
        {
            return true;
        }

        private Color CubeColorToColor(CubeColor color)
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
            }

            return output;
        }
    }
}
