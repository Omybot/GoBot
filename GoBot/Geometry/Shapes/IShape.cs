using System.Collections.Generic;
using System.Drawing;

namespace Geometry.Shapes
{
    public interface IShape
    {
        /// <summary>
        /// Teste si la forme courante croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si la forme courante croise la forme donnée</returns>
        bool Cross(IShape shape);

        /// <summary>
        /// Teste si la forme courante contient la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si la forme courante contient la forme donnée</returns>
        bool Contains(IShape shape);

        /// <summary>
        /// Retourne la distance minimum entre la forme courante et la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Distance entre la forme actuelle et la forme testée. Si les deux formes se croisent la distance est de 0</returns>
        double Distance(IShape shape);

        /// <summary>
        /// Retourne les points de croisement entre la forme courante et la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Liste des points de croisements entre la forme courante et la forme donnée</returns>
        List<RealPoint> GetCrossingPoints(IShape shape);

        /// <summary>
        /// Obtient la surface de la forme
        /// </summary>
        double Surface { get; }

        /// <summary>
        /// Obtient le barycentre de la forme
        /// </summary>
        RealPoint Barycenter { get; }

        /// <summary>
        /// Peint la forme sur le Graphic donné
        /// </summary>
        /// <param name="g">Graphic sur lequel peindre</param>
        /// <param name="outline">Pen utilisé pour peindre le contour de la forme (null pour aucun contour)</param>
        /// <param name="fillColor">Brush pour de remplissag de la forme (null pour aucun remplissage)</param>
        /// <param name="scale">Echelle de conversion</param>
        void Paint(Graphics g, Pen outline, Brush fill, WorldScale scale);
    }

    public static class IShapeExtensions
    {
        /// <summary>
        /// Retourne une copie de la forme ayant subit une translation
        /// </summary>
        /// <param name="shape">Forme à translater</param>
        /// <param name="dx">Distance de translation en X</param>
        /// <param name="dy">Distance de translation en Y</param>
        /// <returns>Nouvelle forme ayant subit la translation</returns>
        public static IShape Translation(this IShape shape, double dx, double dy)
        {
            return ((IShapeModifiable<IShape>)shape).Translation(dx, dy);
        }

        /// <summary>
        /// Retourne une copie de la forme ayant subit une rotation
        /// </summary>
        /// <param name="shape">Forme à tourner</param>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation. Si null alors le barycentre est utilisé.</param>
        /// <returns>Nouvelle forme ayant subit la rotation</returns>
        public static IShape Rotation(this IShape shape, AngleDelta angle, RealPoint rotationCenter = null)
        {
            return ((IShapeModifiable<IShape>)shape).Rotation(angle, rotationCenter);
        }

        public static void Paint(this IShape shape, Graphics g, Color outline, int outlineWidth, Color fill, WorldScale scale)
        {
            Pen p = new Pen(outline, outlineWidth);
            Brush b = new SolidBrush(fill);

            shape.Paint(g, p, b, scale);

            p.Dispose();
            b.Dispose();
        }
    }

    public interface IShapeModifiable<out T>
    {
        /// <summary>
        /// Retourne une copie de la forme ayant subit une translation
        /// </summary>
        /// <param name="dx">Distance de translation en X</param>
        /// <param name="dy">Distance de translation en Y</param>
        /// <returns>Nouvelle forme ayant subit la trabslation</returns>
        T Translation(double dx, double dy);

        /// <summary>
        /// Retourne une copie de la forme ayant subit une rotation
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation. Si null alors le barycentre est utilisé.</param>
        /// <returns>Nouvelle forme ayant subit la rotation</returns>
        T Rotation(AngleDelta angle, RealPoint rotationCenter = null);
    }
}
