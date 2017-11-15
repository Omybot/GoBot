using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.ElementsJeu
{
    public class Fusee : GameElement
    {
        private Color couleur;
        private int numero;

        public int ModulesRestants { get; set; }

        public Fusee(int num, RealPoint position, Color couleur, int rayon)
            : base(position, couleur, rayon)
        {
            numero = num;
            IsHover = false;
            Couleur = couleur;
            ModulesRestants = 3;
        }

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public override string ToString()
        {
            return "fusée " + numero.ToString();
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            if (ModulesRestants > 0)
            {
                Point center = scale.RealToScreenPosition(Position);
                Size size = new Size(scale.RealToScreenDistance(HoverRadius) * 2, scale.RealToScreenDistance(HoverRadius) * 2);
                Rectangle rect = new Rectangle(center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
                Brush b;

                if (Couleur == Color.White)
                {
                    g.FillEllipse(Brushes.White, rect);
                    b = new SolidBrush(Plateau.CouleurGaucheBleu);
                    g.FillPie(b, rect, -135, 90);
                    b.Dispose();
                    b = new SolidBrush(Plateau.CouleurDroiteJaune);
                    g.FillPie(b, rect, +45, 90);
                    b.Dispose();
                }
                else
                {
                    b = new SolidBrush(Couleur);
                    g.FillEllipse(b, rect);
                    b.Dispose();
                }

                if (IsHover)
                    g.DrawEllipse(Pens.White, rect);
                else
                    g.DrawEllipse(Pens.Black, rect);
            }
        }

        public override bool ClickAction()
        {
            return new Mouvements.MouvementFusee(numero).Executer();
        }
    }
}
