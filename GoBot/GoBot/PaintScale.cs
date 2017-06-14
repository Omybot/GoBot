using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot
{
    /// <summary>
    /// Classe permettant de convertir des coordonnées réelles (sur l'aire de jeu) en coordonnées écran (sur l'image de l'aire de jeu)
    /// </summary>
    public class PaintScale
    {
        double _factor;
        int _offsetX, _offsetY;

        /// <summary>
        /// Crée un PaintScale à partir des mesures fournies
        /// </summary>
        /// <param name="factor">Nombre de mm par pixels</param>
        /// <param name="offsetX">Position en pixel l'abscisse 0</param>
        /// <param name="offsetY">Position en pixel l'ordonnéee 0</param>
        public PaintScale(double factor, int offsetX, int offsetY)
        {
            _factor = factor;
            _offsetX = offsetX;
            _offsetY = offsetY;
        }

        /// <summary>
        /// Retourne une échelle par défaut (par de transformation)
        /// </summary>
        /// <returns></returns>
        public static PaintScale Default()
        {
            return new PaintScale(1, 0, 0);
        }

        // Ecran vers réel

        public int ScreenToRealDistance(double value)
        {
            return (int)(value * _factor);
        }

        public PointReel ScreenToRealPosition(Point value)
        {
            return new PointReel(ScreenToRealDistance(value.X - _offsetX), ScreenToRealDistance(value.Y - _offsetY));
        }

        // Réel vers écran

        public int RealToScreenDistance(double value)
        {
            return (int)(value / _factor);
        }

        public Point RealToScreenPosition(PointReel value)
        {
            return new Point(RealToScreenDistance(value.X) + _offsetX, RealToScreenDistance(value.Y) + _offsetY);
        }

        public Point RealToScreenPosition(PointF value)
        {
            return RealToScreenPosition(new PointReel(value.X, value.Y));
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
