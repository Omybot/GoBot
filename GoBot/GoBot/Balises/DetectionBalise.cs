using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoBot.Calculs.Formes;
using GoBot.Calculs;

namespace GoBot.Balises
{
    public class DetectionBalise
    {
        /// <summary>
        /// Balise qui a généré cette détection
        /// </summary>
        public Balise Balise { get; set; }

        /// <summary>
        /// Angle du début de la détection
        /// </summary>
        public double AngleDebut { get; set; }

        /// <summary>
        /// Angle de la fin de la détection
        /// </summary>
        public double AngleFin { get; set; }

        /// <summary>
        /// Angle médian de la détection
        /// </summary>
        public double AngleCentral { get; set; }

        /// <summary>
        /// Distance de détection en mm
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Position du point détectée en mm
        /// </summary>
        public PointReel Position { get; set; }

        public DetectionBalise(Balise balise, double angleDebut, double angleFin)
        {
            AngleDebut = angleDebut;
            AngleFin = angleFin;
            AngleCentral = (angleDebut + angleFin ) / 2;
            Distance = AngleVisibleToDistance(Math.Abs(AngleFin - AngleDebut));

            // Bornes
            if (Distance > Plateau.LongueurPlateau)
                Distance = Plateau.LongueurPlateau;
            if (Distance < 1)
                Distance = 1;

            // Un peu de trigo pas bien compliquée
            double xPoint = balise.Position.Coordonnees.X + Math.Cos(Maths.DegreeToRadian(AngleCentral)) * Distance;
            double yPoint = balise.Position.Coordonnees.Y + Math.Sin(Maths.DegreeToRadian(AngleCentral)) * Distance;

            Position = new PointReel(xPoint, yPoint);

            Balise = balise;
        }

        /// <summary>
        /// Retourne la distance de la balise en fonction de l'angle de détection calculé
        /// </summary>
        /// <param name="largeurAngle">Largeur de l'angle de détection</param>
        /// <returns>Distance calculée</returns>
        private double AngleVisibleToDistance(double largeurAngle)
        {
            // Formule calculée par expérimentations
            return 2784.6 * Math.Pow(largeurAngle, -0.96);
        }
    }
}
