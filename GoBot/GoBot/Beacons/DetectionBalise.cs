using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoBot.Geometry.Shapes;
using GoBot.Geometry;

namespace GoBot.Beacons
{
    /// <summary>
    /// Classe de stockage de mesure de balise
    /// </summary>
    public class BeaconDetection
    {
        /// <summary>
        /// Balise qui a généré cette détection
        /// </summary>
        public Beacon Balise { get; set; }

        /// <summary>
        /// Angle du début de la détection
        /// </summary>
        public Angle AngleDebut { get; set; }

        /// <summary>
        /// Angle de la fin de la détection
        /// </summary>
        public Angle AngleFin { get; set; }

        /// <summary>
        /// Angle médian de la détection
        /// </summary>
        public Angle AngleCentral { get; set; }

        /// <summary>
        /// Distance de détection en mm
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Position du point détectée en mm
        /// </summary>
        public RealPoint Position { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="balise">Balise ayant émis cette mesure</param>
        /// <param name="angleDebut">Début de l'angle mesuré</param>
        /// <param name="angleFin">Fin de l'angle mesuré</param>
        public BeaconDetection(Beacon balise, Angle angleDebut, Angle angleFin)
        {
            AngleDebut = angleDebut;
            AngleFin = angleFin;
            AngleCentral = (angleDebut + angleFin ) / 2;
            Distance = AngleVisibleToDistance(Math.Abs(AngleFin - AngleDebut));

            // Bornes
            if (Distance > Plateau.Largeur)
                Distance = Plateau.Largeur;
            if (Distance < 1)
                Distance = 1;

            // Un peu de trigo pas bien compliquée
            double xPoint = balise.Position.Coordinates.X + Math.Cos(AngleCentral.InRadians) * Distance;
            double yPoint = balise.Position.Coordinates.Y + Math.Sin(AngleCentral.InRadians) * Distance;

            Position = new RealPoint(xPoint, yPoint);

            Balise = balise;
        }

        /// <summary>
        /// Retourne la distance de la balise en fonction de l'angle de détection calculé
        /// </summary>
        /// <param name="largeurAngle">Largeur de l'angle de détection</param>
        /// <returns>Distance calculée</returns>
        private double AngleVisibleToDistance(Angle largeurAngle)
        {
            // Formule calculée par expérimentations
            return 2784.6 * Math.Pow(largeurAngle, -0.96);
        }

        /// <summary>
        /// Transforme une détection de balise en triangle
        /// </summary>
        /// <returns>Triangle correspondant à la détection</returns>
        public Polygon ToPolygone()
        {
            List<RealPoint> listePoints = new List<RealPoint>();

            // Point de la balise

            double xPoint1 = Balise.Position.Coordinates.X;
            double yPoint1 = Balise.Position.Coordinates.Y;

            RealPoint point = new RealPoint(xPoint1, yPoint1);

            listePoints.Add(point);

            // Point du côté du début de l'angle
            // 5000 valeur arbitraire, assez grande pour dépasser de la table

            xPoint1 = Balise.Position.Coordinates.X + Math.Cos(AngleDebut.InRadians) * 5000;
            yPoint1 = Balise.Position.Coordinates.Y + Math.Sin(AngleDebut.InRadians) * 5000;
            point = new RealPoint(xPoint1, yPoint1);

            listePoints.Add(point);

            // Point du côté du début de l'angle

            xPoint1 = Balise.Position.Coordinates.X + Math.Cos(AngleFin.InRadians) * 5000;
            yPoint1 = Balise.Position.Coordinates.Y + Math.Sin(AngleFin.InRadians) * 5000;
            point = new RealPoint(xPoint1, yPoint1);

            listePoints.Add(point);

            Polygon polygone = new Polygon(listePoints);

            return polygone;
        }
    }
}
