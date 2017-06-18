using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.ElementsJeu
{
    public class ZoneInteret : ElementJeu
    {
        private Color couleur;

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        private bool interet;

        public bool Interet
        {
            get { return interet; }
            set { interet = value; }
        }

        public ZoneInteret(PointReel position, Color couleur, int rayon)
            : base(position, rayon)
        {
            Interet = true;
            Hover = false;
            Couleur = couleur;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Pen pBlack = new Pen(Color.Black);
            Pen pWhite = new Pen(Color.White);
            Pen pWhiteBold = new Pen(Color.White);

            pWhite.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pWhiteBold.Width = 3;

            Rectangle rect = new Rectangle(scale.RealToScreenPosition(Position.Translation(-RayonHover, -RayonHover)), scale.RealToScreenSize(new SizeF(RayonHover*2, RayonHover*2)));

            if (Hover)
            {
                g.DrawEllipse(pWhiteBold, rect);
            }
            else
            {
                g.DrawEllipse(pBlack, rect);
                g.DrawEllipse(pWhite, rect);
            }

            pBlack.Dispose();
            pWhite.Dispose();
            pWhiteBold.Dispose();
        }

        public override bool ClickAction()
        {
            return true;
        }
    }
}
