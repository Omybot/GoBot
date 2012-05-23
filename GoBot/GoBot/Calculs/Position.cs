using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Calculs
{
    public class Position
    {
        private Angle angle;
        private PointReel coordonnees;

        /// <summary>
        /// Constructeur par défaut
        /// Angle de 0° et Coordonnées (0, 0)
        /// </summary>
        public Position()
        {
            angle = new Angle();
            coordonnees = new PointReel();
        }

        /// <summary>
        /// Construit une position selon les paramètres
        /// </summary>
        /// <param name="a">Angle de départ</param>
        /// <param name="c">Coordonnées de départ</param>
        public Position(Angle a, PointReel c)
        {
            angle = a;
            coordonnees = c;
        }

        /// <summary>
        /// Déplace les coordonnées par rapport aux anciennes coordonnées
        /// </summary>
        /// <param name="x">Déplacement sur l'axe des abscisses</param>
        /// <param name="y">Déplacement sur l'axe des ordonnées</param>
        public void deplacer(double x, double y)
        {
            coordonnees.deplacer(x, y);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (en degrés) choisi
        /// </summary>
        /// <param name="a">Angle à tourner</param>
        public void tourner(double a)
        {
            angle.tourner(a);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (objet) choisi
        /// </summary>
        /// <param name="a">Angle à tourner</param>
        public void tourner(Angle a)
        {
            angle.tourner(a);
        }

        public PointReel Coordonnees
        {
            get
            {
                return coordonnees;
            }
        }

        public Angle Angle
        {
            get
            {
                return angle;
            }
        }
    }
}
