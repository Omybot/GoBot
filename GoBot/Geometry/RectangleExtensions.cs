using System.Drawing;

internal static class RectangleExtensions
{
    #region RectangleF

    /// <summary>
    /// Retourne le point central du rectangle
    /// </summary>
    /// <param name="rect">Rectangle dont on cherche le centre</param>
    /// <returns>Point central du rectangle<returns>
    public static PointF Center(this RectangleF rect)
    {
        return new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
    }

    /// <summary>
    /// Augmente la largeur du rectangle tout en conservant son centre au même endroit
    /// </summary>
    /// <param name="rect">Rectangle à modifier</param>
    /// <param name="newWidth">Nouvelle largeur</param>
    public static RectangleF ExpandWidth(this RectangleF rect, double newWidth)
    {
        rect.X -= (float)(newWidth - rect.Width) / 2;
        rect.Width = (float)newWidth;
        return rect;
    }

    /// <summary>
    /// Augmente la hauteur du rectangle tout en conservant son centre au même endroit
    /// </summary>
    /// <param name="rect">Rectangle à modifier</param>
    /// <param name="newHeight">Nouvelle hauteur</param>
    public static RectangleF ExpandHeight(this RectangleF rect, double newHeight)
    {
        rect.Y -= (float)(newHeight - rect.Height) / 2;
        rect.Height = (float)newHeight;
        return rect;
    }

    /// <summary>
    /// Déplace le rectangle sur les axes X et Y suivant les deltas donnés
    /// </summary>
    /// <param name="rect">Ractangle à déplacer</param>
    /// <param name="deltaX">Déplacement sur l'axe des abscisses</param>
    /// <param name="deltaY">Déplacement sur l'axe des ordonnées</param>
    public static RectangleF Shift(this RectangleF rect, double deltaX, double deltaY)
    {
        rect.X += (float)deltaX;
        rect.Y += (float)deltaY;
        return rect;
    }

    /// <summary>
    /// Déplace le rectangle en modifiant son centre et en conservant sa taille
    /// </summary>
    /// <param name="rect">Rectangle à modifier</param>
    /// <param name="center">Nouveau centre</param>
    public static RectangleF SetCenter(this RectangleF rect, PointF center)
    {
        rect.X = center.X - rect.Width / 2;
        rect.Y = center.Y - rect.Height / 2;
        return rect;
    }

    #endregion

    #region Rectangle

    public static PointF Center(this Rectangle rect)
    {
        return new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
    }

    #endregion
}
