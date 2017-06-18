using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot
{
    /// <summary>
    /// Classe permettant de convertir des coordonnées réelles (sur l'aire de jeu) en coordonnées écran (sur l'image de l'aire de jeu)
    /// </summary>
    public class WorldScale
    {
        public double Factor { get; protected set; }
        public int OffsetX { get; protected set; }
        public int OffsetY { get; protected set; }

        /// <summary>
        /// Crée un PaintScale à partir des mesures fournies
        /// </summary>
        /// <param name="mmPerPixel">Nombre de mm par pixels</param>
        /// <param name="offsetX">Position en pixels de l'abscisse 0</param>
        /// <param name="offsetY">Position en pixels de l'ordonnéee 0</param>
        public WorldScale(double mmPerPixel, int offsetX, int offsetY)
        {
            Factor = mmPerPixel;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

        public WorldScale(WorldScale other)
        {
            Factor = other.Factor;
            OffsetX = other.OffsetX;
            OffsetY = other.OffsetY;
        }

        /// <summary>
        /// Retourne une échelle par défaut (par de transformation)
        /// </summary>
        /// <returns></returns>
        public static WorldScale Default()
        {
            return new WorldScale(1, 0, 0);
        }

        // Ecran vers réel

        public int ScreenToRealDistance(double value)
        {
            return (int)(value * Factor);
        }

        public PointReel ScreenToRealPosition(Point value)
        {
            return new PointReel(ScreenToRealDistance(value.X - OffsetX), ScreenToRealDistance(value.Y - OffsetY));
        }

        public SizeF ScreenToRealSize(Size sz)
        {
            return new SizeF(ScreenToRealDistance(sz.Width), ScreenToRealDistance(sz.Height));
        }

        public RectangleF ScreenToRealRect(Rectangle rect)
        {
            return new RectangleF(ScreenToRealPosition(rect.Location), ScreenToRealSize(rect.Size));
        }

        // Réel vers écran

        public int RealToScreenDistance(double value)
        {
            return (int)(value / Factor);
        }

        public Point RealToScreenPosition(PointReel value)
        {
            return new Point(RealToScreenDistance(value.X) + OffsetX, RealToScreenDistance(value.Y) + OffsetY);
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
