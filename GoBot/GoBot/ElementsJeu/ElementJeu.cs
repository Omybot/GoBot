using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.ElementsJeu
{
    public abstract class ElementJeu
    {
        private PointReel position;
        private bool ramasse;

        public bool Ramasse
        {
            get { return ramasse; }
            set { ramasse = value; }
        }

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
            Ramasse = false;
        }

        public abstract void Paint(Graphics g, PaintScale scale);

        public abstract bool ClickAction();
    }
}
