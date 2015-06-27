using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    class Triangle : Polygone
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
                // TODOFORMES
                return 0;
            }
        }

        /// <summary>
        /// Barycentre du Triangle
        /// </summary>
        public override PointReel BaryCentre
        {
            get
            {
                // TODOFORMES
                return null;
            }
        }
    }
}
