using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Geometry.Shapes
{
    public class PolygonRectangle : Polygon
    {
        /// <summary>
        /// Construit un rectangle à partir du point en haut à gauche, de la largeur et de la hauteur
        /// </summary>
        /// <param name="topLeft">Point en haut à gauche du rectangle</param>
        /// <param name="width">Largeur du rectangle</param>
        /// <param name="heigth">Hauteur du rectangle</param>
        public PolygonRectangle(RealPoint topLeft, double width, double heigth)
        {
            List<Segment> rectSides = new List<Segment>();

            topLeft = new RealPoint(topLeft);

            if (width < 0)
            {
                topLeft.X += width;
                width = -width;
            }
            if(heigth < 0)
            {
                topLeft.Y += heigth;
                heigth = -heigth;
            }

            if (topLeft == null)
                throw new ArgumentOutOfRangeException();

            List<RealPoint> points = new List<RealPoint>
            {
                new RealPoint(topLeft.X, topLeft.Y),
                new RealPoint(topLeft.X + width, topLeft.Y),
                new RealPoint(topLeft.X + width, topLeft.Y + heigth),
                new RealPoint(topLeft.X, topLeft.Y + heigth)
            };

            for (int i = 1; i < points.Count; i++)
                rectSides.Add(new Segment(points[i - 1], points[i]));

            rectSides.Add(new Segment(points[points.Count - 1], points[0]));

            BuildPolygon(rectSides);
        }

        public override string ToString()
        {
            return _sides[0].StartPoint.ToString() + "; " +
                "W = " + (_sides[1].StartPoint.X - _sides[0].StartPoint.X).ToString("0.00") + "; " +
                "H = " + (_sides[3].StartPoint.Y - _sides[0].StartPoint.Y).ToString("0.00");
        }
    }
}
