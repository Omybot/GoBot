using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Geometry
{
    public enum AnglyeType
    {
        Radian,
        Degre
    }

    public class Angle
    {
        private double angle { get; set; }

        private const double PRECISION = 0.01;

        public double Cos
        {
            get
            {
                return Math.Cos(InRadians);
            }
        }

        public double Acos
        {
            get
            {
                return Math.Acos(InRadians);
            }
        }

        public double Sin
        {
            get
            {
                return Math.Sin(InRadians);
            }
        }

        public double Asin
        {
            get
            {
                return Math.Asin(InRadians);
            }
        }

        public double Tan
        {
            get
            {
                return Math.Tan(InRadians);
            }
        }

        public double Atan
        {
            get
            {
                return Math.Atan(InRadians);
            }
        }

        /// <summary>
        /// Retourne l'angle en degrés (-180 à +180)
        /// </summary>
        public double InDegrees
        {
            get
            {
                return angle;
            }
        }

        /// <summary>
        /// Retourne l'angle en degrés positif (0 à 360 au lieu de -180 à +180)
        /// </summary>
        public double InPositiveDegrees
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
        public double InRadians
        {
            get
            {
                return (double)(angle / 180 * Math.PI);
            }
        }

        /// <summary>
        /// Retourne l'angle en radians positif
        /// </summary>
        public double InPositiveRadians
        {
            get
            {
                return (double)(InPositiveDegrees / 180 * Math.PI);
            }
        }

        /// <summary>
        /// Construit un angle avec la valeur passée en paramètre
        /// </summary>
        /// <param name="angle">Angle de départ</param>
        public Angle(double angle, AnglyeType type = AnglyeType.Degre)
        {
            if (type == AnglyeType.Degre)
                this.angle = angle;
            else if (type == AnglyeType.Radian)
                this.angle = (double)(180 * angle / Math.PI);

            this.angle = this.angle % 360;
            this.angle = OptimalAngle(this);
        }

        /// <summary>
        /// Constructeur par défaut. L'angle vaudra 0.
        /// </summary>
        public Angle()
        {
            angle = 0;
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (objet) choisi
        /// </summary>
        /// <param name="turnAngle">Angle à tourner</param>
        public void Turn(Angle turnAngle)
        {
            angle += turnAngle;
            angle = OptimalAngle(this);
        }

        /// <summary>
        /// Retourne l'angle le plus proche de 0 correspondant à l'angle passé en paramètre.
        /// Par exemple pour 345°, l'angle optimal est -15°
        /// </summary>
        /// <param name="a">Angle à convertir</param>
        /// <returns>Angle optimal (en degrés)</returns>
        private static double OptimalAngle(Angle a)
        {
            double newAngle = a.InDegrees;

            while (newAngle > 180)
                newAngle = newAngle - 360;
            while (newAngle < -180)
                newAngle = newAngle + 360;

            return newAngle;
        }

        /// <summary>
        /// Retourne si l'angle est compris entre les angles données, c'est à dire qu'i lse situe dans l'arc de cercle le plus petit formé par les deux angles
        /// Exemples : 
        /// 150° est entre 130° et 160°
        /// 10° est entre 350° et 50°
        /// </summary>
        /// <param name="a1">Premier angle</param>
        /// <param name="a2">Deuxième angle</param>
        /// <returns>Vrai si l'angle est compris entre les deux angles</returns>
        public bool IsBetween(Angle a1, Angle a2)
        {
            if (a1.InPositiveDegrees < a2.InPositiveDegrees)
                return InPositiveDegrees > a1.InPositiveDegrees && InPositiveDegrees < a2.InPositiveDegrees;
            else if (a1.InPositiveDegrees > a2.InPositiveDegrees)
                return (InPositiveDegrees < a1.InPositiveDegrees && InPositiveDegrees > 0) || (InPositiveDegrees > a2.InPositiveDegrees && InPositiveDegrees < 0);

            return true;
        }

        /// <summary>
        /// Affecte un nouvel angle
        /// </summary>
        /// <param name="other">Nouvel angle</param>
        public void Set(Angle other)
        {
            angle = other.angle;
        }

        #region Operateurs

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.InDegrees + a2.InDegrees, AnglyeType.Degre);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.InPositiveDegrees - a2.InPositiveDegrees, AnglyeType.Degre);
        }

        public static bool operator ==(Angle a1, Angle a2)
        {
            if (!(a1 is Angle) && !(a2 is Angle))
                return true;

            if ((!(a1 is Angle) && a2 is Angle) || (a1 is Angle && !(a2 is Angle)))
                return false;

            return Math.Abs((a1 - a2).InDegrees) <= PRECISION;
        }

        public static bool operator !=(Angle a1, Angle a2)
        {
            if ((!(a1 is Angle) && a2 is Angle) || (a1 is Angle && !(a2 is Angle)))
                return true;
            return !(a1 == a2);
        }

        public static implicit operator Angle(double angle)
        {
            return new Angle(angle);
        }

        public static implicit operator double(Angle angle)
        {
            return angle.InDegrees;
        }

        #endregion

        public override string ToString()
        {
            return Math.Round(angle, 2) + "°";
        }

        public override bool Equals(object obj)
        {
            try
            {
                return (Angle)obj == this;
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (int)(InDegrees * 1000);
        }
    }
}
