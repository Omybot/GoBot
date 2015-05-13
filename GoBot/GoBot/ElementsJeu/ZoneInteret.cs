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
    }
}
