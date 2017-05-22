using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.ElementsJeu
{
    public class Fusee : ElementJeu
    {
        private Color couleur;
        private int numero;

        public int ModulesRestants { get; set; }

        public Fusee(int num, PointReel position, Color couleur, int rayon)
            : base(position, rayon)
        {
            numero = num;
            Hover = false;
            Couleur = couleur;
            ModulesRestants = 4;
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
    }
}
