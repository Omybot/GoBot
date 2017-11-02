using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    class RectanglePolygone : Polygone
    {
        public RectanglePolygone(RealPoint pointHautGauche, double largeur, double hauteur)
        {
            cotes = new List<Segment>();

            List<Segment> cotesPoly = new List<Segment>();

            if (largeur < 0 || hauteur < 0 || pointHautGauche == null)
                throw new ArgumentOutOfRangeException();

            List<RealPoint> points = new List<RealPoint>();
            points.Add(new RealPoint(pointHautGauche.X, pointHautGauche.Y));
            points.Add(new RealPoint(pointHautGauche.X + largeur, pointHautGauche.Y));
            points.Add(new RealPoint(pointHautGauche.X + largeur, pointHautGauche.Y + hauteur));
            points.Add(new RealPoint(pointHautGauche.X, pointHautGauche.Y + hauteur));

            for (int i = 1; i < points.Count; i++)
                cotesPoly.Add(new Segment(points[i - 1], points[i]));

            cotesPoly.Add(new Segment(points[points.Count - 1], points[0]));

            construirePolygone(cotesPoly);
        }
    }
}
