using System;
using System.Collections.Generic;

namespace Geometry.Shapes
{
    /// <summary>
    /// Polygone à 3 côtés.
    /// </summary>
    public class PolygonTriangle : Polygon
    {
        /// <summary>
        /// Construit un triangle à partir de ses 3 sommets
        /// </summary>
        /// <param name="p1">Sommet 1</param>
        /// <param name="p2">Sommet 2</param>
        /// <param name="p3">Sommet 3</param>
        public PolygonTriangle(RealPoint p1, RealPoint p2, RealPoint p3)
            : base(new List<RealPoint>() { p1, p2, p3 })
        {
            // L'interet du triangle c'est qu'il est simple de calculer son aire et son barycentre et qu'on s'en sert pour calculer ceux de polygones quelconques
        }

        /// <summary>
        /// COnstruit un triangle à partir de ses 3 cotés
        /// </summary>
        /// <param name="p1">Coté 1</param>
        /// <param name="p2">Coté 2</param>
        /// <param name="p3">Coté 3</param>
        public PolygonTriangle(Segment s1, Segment s2, Segment s3)
            : base(new List<Segment>() { s1, s2, s3 })
        {
            if (s1.EndPoint != s2.StartPoint || s2.EndPoint != s3.StartPoint || s3.EndPoint != s1.StartPoint)
                throw new Exception("Triangle mal formé");
        }
        
        protected override double ComputeSurface()
        {
            Segment seg = new Segment(Points[0], Points[1]);
            double height = seg.Distance(Points[2]);
            double width = seg.Length;
            return height * width / 2;
        }

        protected override RealPoint ComputeBarycenter()
        {
            RealPoint output = null;

            if (Points[0] == Points[1] && Points[0] == Points[2])
                output = new RealPoint(Points[0]);
            else if (Points[0] == Points[1])
                output = new Segment(Points[0], Points[2]).Barycenter;
            else if (Points[0] == Points[2])
                output = new Segment(Points[1], Points[2]).Barycenter;
            else if (Points[1] == Points[2])
                output = new Segment(Points[0], Points[1]).Barycenter;
            else
            {
                Line d1 = new Line(new Segment(Points[0], Points[1]).Barycenter, Points[2]);
                Line d2 = new Line(new Segment(Points[1], Points[2]).Barycenter, Points[0]);

                output = d1.GetCrossingPoints(d2)[0];
            }

            return output;
        }
    }
}
