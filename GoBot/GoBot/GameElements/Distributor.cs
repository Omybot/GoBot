using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static int nextNumero;

        public Distributor(RealPoint position, Color owner, bool alternate) : base(position, owner, 50)
        {
            isOpen = false;
            numero = ++nextNumero;

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

                g.DrawEllipse(Pens.Black, ballRect);

                ballPos.X += GetInterVector(scale.RealToScreenDistance(20)).X;
                ballPos.Y += GetInterVector(scale.RealToScreenDistance(20)).Y;
            }
        }

        public override string ToString()
        {
            return "distributeur n°" + (numero+1).ToString();
        }

        private Point GetInterVector(int interBallSize)
        {
            Point vect = new Point();
            

            switch (numero)
            {
                case 1:
                    vect = new Point(-interBallSize, 0);
                    break;
                case 2:
                    vect = new Point(0, interBallSize);
                    break;
                case 3:
                    vect = new Point(0, interBallSize);
                    break;
                case 4:
                    vect = new Point(interBallSize, 0);
                    break;
            }

            return vect;
        }
    }
}
