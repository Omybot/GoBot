using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoBot.Geometry;
using GoBot.Geometry.Shapes;

namespace GoBot.GameElements
{
    public class Distributor : GameElement
    {
        /// <summary>
        /// Liste des couleurs de balles encore présentes. L'indice 0 représente la prochaine balle à tomber.
        /// </summary>
        private List<Color> balls;
        private bool isOpen;
        private int numero;
        private AnglePosition angle;

        private static int nextNumero;

        public Distributor(RealPoint position, Color owner, bool alternate, AnglePosition angle) : base(position, owner, 50)
        {
            this.angle = angle;
            isOpen = false;
            numero = nextNumero++;

            if (!alternate)
                balls = Enumerable.Repeat(owner, 8).ToList();
            else
            {
                Color secondBallColor = owner == Plateau.CouleurGaucheVert ? Plateau.CouleurDroiteOrange : Plateau.CouleurGaucheVert;
                balls = new List<Color>();

                for (int i = 0; i < 4; i++)
                {
                    balls.Add(owner);
                    balls.Add(secondBallColor);
                }
            }
        }

        public override bool ClickAction()
        {
            isOpen = !isOpen;

            if(balls.Count > 0)
                balls.RemoveAt(0);

            return true;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Point ballPos = scale.RealToScreenPosition(position);
            Size ballSize = scale.RealToScreenSize(new SizeF(44, 44));

            ballPos.X -= ballSize.Width / 2;
            ballPos.Y -= ballSize.Height / 2;

            foreach (Color ball in balls)
            {
                Rectangle ballRect = new Rectangle(ballPos, ballSize);
                using (Brush brush = new SolidBrush(ball))
                    g.FillEllipse(brush, ballRect);

                if (isHover)
                    g.DrawEllipse(Pens.White, ballRect);
                else
                    g.DrawEllipse(Pens.Black, ballRect);
                
                ballPos.X += (int)(angle.Cos * scale.RealToScreenDistance(20));
                ballPos.Y += (int)(angle.Sin * scale.RealToScreenDistance(20));
            }

            Point start = new Point(40, -20);
            Point end = start;

            if (isOpen)
                end = new Point(start.X, start.Y - 80);
            else
                end = new Point(start.X - 80, start.Y);

            start = scale.RealToScreenPosition(position.Translation(angle.Sin * start.X + angle.Cos * start.Y, angle.Sin * start.Y + angle.Cos * start.X));
            end = scale.RealToScreenPosition(position.Translation(angle.Sin * end.X + angle.Cos * end.Y, angle.Sin * end.Y + angle.Cos * end.X));

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            using (Pen pen = new Pen(Color.Black, 4))
                g.DrawLine(pen, start, end);

            using (Pen pen = new Pen(Color.White, 2))
                g.DrawLine(pen, start, end);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.FillEllipse(Brushes.White, start.X - 4, start.Y - 4, 8, 8);
            
            g.DrawEllipse(Pens.Black, start.X - 4, start.Y - 4, 8, 8);
        }

        public override string ToString()
        {
            return "distributeur n°" + (numero+1).ToString();
        }
    }
}
