using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.ElementsJeu
{
    public abstract class ElementJeu
    {
        private PointReel position;

        public PointReel Position
        {
            get { return position; }
            set { position = value; }
        }

        private bool hover;

        public bool Hover
        {
            get { return hover; }
            set { hover = value; }
        }

        private int rayonHover;

        public int RayonHover
        {
            get { return rayonHover; }
            set { rayonHover = value; }
        }

        public ElementJeu(PointReel position, int rayonHover)
        {
            RayonHover = rayonHover;
            Position = position;
        }
    }
}
