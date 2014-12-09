using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.ElementsJeu
{
    public class Pied : ElementJeu
    {
        private Color couleur;

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public Pied(PointReel position, Color couleur)
            : base(position, 50)
        {
            Couleur = couleur;
        }
    }
}
