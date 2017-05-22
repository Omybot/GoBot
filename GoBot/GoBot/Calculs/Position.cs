using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Calculs
{
    public class Position
    {
        public PointReel Coordonnees { get; private set; }
        public Angle Angle { get; private set; }

        /// <summary>
        /// Constructeur par défaut
        /// Angle de 0° et Coordonnées (0, 0)
        /// </summary>
        public Position()
        {
            Angle = new Angle();
            Coordonnees = new PointReel();
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        public Position(Position other)
        {
            Angle = new Angle(other.Angle.AngleDegres);
            Coordonnees = new PointReel(other.Coordonnees);
        }

        /// <summary>
        /// Construit une position selon les paramètres
        /// </summary>
        /// <param name="a">Angle de départ</param>
        /// <param name="c">Coordonnées de départ</param>
        public Position(Angle a, PointReel c)
        {
            Angle = a;
            Coordonnees = c;
        }

        /// <summary>
        /// Déplace les coordonnées par rapport aux anciennes coordonnées
        /// </summary>
        /// <param name="x">Déplacement (mm) sur l'axe des abscisses</param>
        /// <param name="y">Déplacement (mm) sur l'axe des ordonnées</param>
        public void Deplacer(double x, double y)
        {
            Coordonnees = Coordonnees.Translation(x, y);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (en degrés) choisi
        /// </summary>
        /// <param name="a">Angle à tourner</param>
        public void Tourner(double a)
        {
            Angle.Tourner(a);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (objet) choisi
        /// </summary>
        /// <param name="a">Angle à tourner</param>
        public void Tourner(Angle a)
        {
            Angle.Tourner(a);
        }

        /// <summary>
        /// Avance de la distance spécifiée suivant l'angle actuel
        /// </summary>
        /// <param name="distance">Distance à avancer (mm)</param>
        public void Avancer(double distance)
        {
            double depX = distance * Math.Cos(Angle.AngleRadians);
            double depY = distance * Math.Sin(Angle.AngleRadians);

            Coordonnees = Coordonnees.Translation(depX, depY);
        }

        public void Copie(Position position)
        {
            Angle.Set(position.Angle);
            Coordonnees.Placer(position.Coordonnees.X, position.Coordonnees.Y);
        }

        public override string ToString()
        {
            return Coordonnees.ToString() + " " + Angle.ToString();
        }
    }
}
