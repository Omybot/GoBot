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

        public Module(PointReel position, Color couleur, int rayon)
            : base(position, rayon)
        {
            Hover = false;
            Couleur = couleur;
        }

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }
    }
}
