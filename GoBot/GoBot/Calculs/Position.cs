﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Calculs
{
    public class Position
    {
        public RealPoint Coordinates { get; private set; }
        public Angle Angle { get; private set; }

        /// <summary>
        /// Constructeur par défaut
        /// Angle de 0° et Coordonnées (0, 0)
        /// </summary>
        public Position()
        {
            Angle = new Angle();
            Coordinates = new RealPoint();
        }
        
        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="other">Position à copier</param>
        public Position(Position other)
        {
            Angle = new Angle(other.Angle);
            Coordinates = new RealPoint(other.Coordinates);
        }

        /// <summary>
        /// Construit une position selon les paramètres
        /// </summary>
        /// <param name="angle">Angle de départ</param>
        /// <param name="coordinates">Coordonnées de départ</param>
        public Position(Angle angle, RealPoint coordinates)
        {
            Angle = new Angle(angle);
            Coordinates = new RealPoint(coordinates);
        }

        /// <summary>
        /// Déplace les coordonnées par rapport aux anciennes coordonnées
        /// </summary>
        /// <param name="x">Déplacement sur l'axe des abscisses</param>
        /// <param name="y">Déplacement sur l'axe des ordonnées</param>
        public void Shift(double x, double y)
        {
            Coordinates = Coordinates.Translation(x, y);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle choisi
        /// </summary>
        /// <param name="angle">Angle à tourner</param>
        public void Turn(Angle angle)
        {
            Angle.Turn(angle);
        }

        /// <summary>
        /// Avance de la distance spécifiée suivant l'angle actuel
        /// </summary>
        /// <param name="distance">Distance à avancer</param>
        public void Move(double distance)
        {
            double depX = distance * Math.Cos(Angle.InRadians);
            double depY = distance * Math.Sin(Angle.InRadians);

            Coordinates = Coordinates.Translation(depX, depY);
        }

        /// <summary>
        /// Copie une autre position
        /// </summary>
        /// <param name="position">Position à copier</param>
        public void Copy(Position position)
        {
            Angle.Set(position.Angle);
            Coordinates.Placer(position.Coordinates.X, position.Coordinates.Y);
        }

        public override string ToString()
        {
            return Coordinates.ToString() + " " + Angle.ToString();
        }
    }
}
