using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.ElementsJeu
{
    public class Clap : ElementJeu
    {
        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        private Color couleur;

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public Clap(PointReel position, Color couleur)
            : base(position, 80)
        {
            Active = false;
            Hover = false;
            Couleur = couleur;
        }
    }
}
