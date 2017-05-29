using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot
{
    /// <summary>
    /// CLasse permettant de convertir des coordonnées réelles (sur l'aire de jeu) en coordonnées écran (sur l'image de l'aire de jeu)
    /// </summary>
    class PaintScale
    {
        #region Conversion coordonnées réelles / écran

        /// <summary>
        /// Nombre de pixels par mm du terrain
        /// </summary>
        private const double RAPPORT_SCREEN_REAL = 3.605769230769231;

        /// <summary>
        /// Position en pixel sur l'image de l'abscisse 0 de la table
        /// </summary>
        private const int OFFSET_IMAGE_X = 29;

        /// <summary>
        /// Position en pixel sur l'image de l'ordonnée 0 de la table
        /// </summary>
        private const int OFFSET_IMAGE_Y = 62;

        #endregion


        // Ecran vers réel

        public int ScreenToRealDistance(double value)
        {
            return (int)(value * RAPPORT_SCREEN_REAL);
        }

        public PointReel ScreenToRealPosition(Point value)
        {
            return new PointReel(ScreenToRealDistance(value.X - OFFSET_IMAGE_X), ScreenToRealDistance(value.Y - OFFSET_IMAGE_Y));
        }

        // Réel vers écran

        public int RealToScreenDistance(double value)
        {
            return (int)(value / RAPPORT_SCREEN_REAL);
        }

        public Point RealToScreenPosition(PointReel value)
        {
            return new Point(RealToScreenDistance(value.X) + OFFSET_IMAGE_X, RealToScreenDistance(value.Y) + OFFSET_IMAGE_Y);
        }

        public Point RealToScreenPosition(PointF value)
        {
            return ScreenToRealPosition(new PointReel(value.X, value.Y));
        }

        public Size RealToScreenSize(SizeF sz)
        {
            return new Size(RealToScreenDistance(sz.Width), RealToScreenDistance(sz.Height));
        }

        public Rectangle RealToScreenRect(RectangleF rect)
        {
            return new Rectangle(RealToScreenPosition(rect.Location), RealToScreenSize(rect.Size));
        }
    }
}
