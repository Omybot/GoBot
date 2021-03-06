﻿using System;

namespace Geometry
{
    public struct AngleDelta
    {
        #region Constantes

        public const double PRECISION = 0.01;

        #endregion

        #region Attributs

        private double _angle;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Construit un angle avec la valeur passée en paramètre
        /// </summary>
        /// <param name="angle">Angle de départ</param>
        public AngleDelta(double angle, AngleType type = AngleType.Degre)
        {
            if (type == AngleType.Degre)
                _angle = angle;
            else
                _angle = (180 * angle / Math.PI);
        }

        #endregion

        /// <summary>
        /// Minimize l'angle en considérant que la valeur doit se situer entre -180° et +180°.
        /// Exemple : 370° est minimisé à 10°.
        /// </summary>
        public AngleDelta Modulo()
        {
            while (_angle > 180)
                _angle -= 360;
            while (_angle < -180)
                _angle += 360;

            return this;
        }


        #region Trigonométrie

        public double Cos
        {
            get
            {
                return Math.Cos(InRadians);
            }
        }

        public double Sin
        {
            get
            {
                return Math.Sin(InRadians);
            }
        }

        public double Tan
        {
            get
            {
                return Math.Tan(InRadians);
            }
        }

        #endregion

        #region Proprietes

        /// <summary>
        /// Retourne l'angle en radians
        /// </summary>
        public double InRadians
        {
            get
            {
                return (double)(_angle / 180 * Math.PI);
            }
        }

        /// <summary>
        /// Retourne l'angle en degrés
        /// </summary>
        public double InDegrees
        {
            get
            {
                return _angle;
            }
        }

        #endregion

        #region Operateurs

        public static AngleDelta operator +(AngleDelta a1, AngleDelta a2)
        {
            return new AngleDelta(a1.InDegrees + a2.InDegrees, AngleType.Degre);
        }

        public static AngleDelta operator -(AngleDelta a1, AngleDelta a2)
        {
            return new AngleDelta(a1.InDegrees - a2.InDegrees, AngleType.Degre);
        }

        public static bool operator ==(AngleDelta a1, AngleDelta a2)
        {
            return Math.Abs((a1 - a2).InDegrees) <= PRECISION;
        }

        public static bool operator !=(AngleDelta a1, AngleDelta a2)
        {
            return !(a1 == a2);
        }

        public static implicit operator AngleDelta(double angle)
        {
            return new AngleDelta(angle);
        }

        public static implicit operator double(AngleDelta angle)
        {
            return angle.InDegrees;
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            try
            {
                return Math.Abs(((AngleDelta)obj)._angle - _angle) < PRECISION;
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (int)(_angle * (1 / PRECISION));
        }

        public override string ToString()
        {
            return _angle.ToString("0.00") + "°";
        }

        #endregion
    }
}