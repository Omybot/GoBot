﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs
{
    public enum AnglyeType
    {
        Radian,
        Degre
    }

    public class Angle
    {
        private double angle;

        /// <summary>
        /// Retourne l'angle en degrés
        /// </summary>
        public double AngleDegres
        {
            get
            {
                return angle;
            }
        }

        public double AnglePositif
        {
            get
            {
                if (angle < 0)
                    return 360 + angle;
                else
                    return angle;
            }
        }

        /// <summary>
        /// Retourne l'angle en radians
        /// </summary>
        public double AngleRadians
        {
            get
            {
                return (double)(angle/180*Math.PI);
            }
        }

        /// <summary>
        /// Construit un angle avec la valeur passée en paramètre
        /// </summary>
        /// <param name="angle">Angle de départ</param>
        public Angle(double angleDepart, AnglyeType type)
        {
            if (type == AnglyeType.Degre)
                angle = angleDepart;
            else if (type == AnglyeType.Radian)
                angle = (double)(180 * angleDepart / Math.PI);

            angle = angle % 360;
            angle = angleOptimal(this);
        }

        /// <summary>
        /// Constructeur par défaut. L'angle vaudra 0.
        /// </summary>
        public Angle()
        {
            angle = 0;
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (en degrés) choisi
        /// </summary>
        /// <param name="angleTourne">Angle à tourner</param>
        public void tourner(double angleTourne)
        {
            angle += angleTourne;
            angle = angleOptimal(this);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (objet) choisi
        /// </summary>
        /// <param name="angleTourne">Angle à tourner</param>
        public void tourner(Angle angleTourne)
        {
            this.tourner(angleTourne.AngleDegres);
        }

        /// <summary>
        /// Retourne l'angle le plus rapide en fonction d'un angle passé en paramètre.
        /// Il est par exemple plus facile de tourner de -15° que de tourner de 345°
        /// </summary>
        /// <param name="a">Angle à tester</param>
        /// <returns>Angle optimal (en degrés)</returns>
        public static double angleOptimal(Angle a)
        {
            double retour = a.AngleDegres % 360;

            if (retour > 180)
                retour = retour - 360;

            return retour;
        }

        public void setAngle(double _angle, AnglyeType type)
        {
            if (type == AnglyeType.Degre)
                angle = _angle;
            else if (type == AnglyeType.Radian)
                angle = (double)(180 * angle / Math.PI);

            angle = angleOptimal(this);
        }

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.AngleDegres + a2.AngleDegres, AnglyeType.Degre);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.AngleDegres - a2.AngleDegres, AnglyeType.Degre);
        }

        public override string ToString()
        {
            return angle + "°";
        }
    }
}
