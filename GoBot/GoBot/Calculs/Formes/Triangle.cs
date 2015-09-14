using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    public class Triangle : Polygone
    {
        public Triangle(PointReel p1, PointReel p2, PointReel p3)
            : base(new List<PointReel>() { p1, p2, p3 })
        {
        }

        public Triangle(Segment s1, Segment s2, Segment s3)
            : base(new List<Segment>() { s1, s2, s3 })
        {
            if (s1.Fin != s2.Debut || s2.Fin != s3.Debut || s3.Fin != s1.Debut)
                throw new Exception("Triangle mal formé");
        }

        /// <summary>
        /// Surface du Triangle
        /// </summary>
        public override double Surface
        {
            get
            {
                Segment seg = new Segment(Points[0], Points[1]);
                double hauteur = seg.Distance(Points[2]);
                double largeur = seg.Longueur;
                return hauteur * largeur / 2;
            }
        }

        /// <summary>
        /// Barycentre du Triangle
        /// </summary>
        public override PointReel BaryCentre
        {
            get
            {
                Droite d1 = new Droite(new Segment(Points[0], Points[1]).BaryCentre, Points[2]);
                Droite d2 = new Droite(new Segment(Points[1], Points[2]).BaryCentre, Points[0]);

                return d1.getCroisement(d2);
            }
        }
    }
}
