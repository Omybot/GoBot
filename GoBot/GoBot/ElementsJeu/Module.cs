using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.ElementsJeu
{
    public class Module : ElementJeu
    {
        private Color couleur;
        private int numero;

        public Module(int num, PointReel position, Color couleur, int rayon)
            : base(position, rayon)
        {
            numero = num;
            Hover = false;
            Couleur = couleur;
        }

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }
        
        public override void Paint(Graphics g, PaintScale scale)
        {
            if (!Ramasse)
            {
                Point center = scale.RealToScreenPosition(Position);
                Size size = new Size(scale.RealToScreenDistance(RayonHover) * 2, scale.RealToScreenDistance(RayonHover) * 2);
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

                if (Hover)
                    g.DrawEllipse(Pens.White, rect);
                else
                    g.DrawEllipse(Pens.Black, rect);
            }
        }

        public override bool ClickAction()
        {
            return new Mouvements.MouvementModuleAvant(numero).Executer();
        }
    }
}
