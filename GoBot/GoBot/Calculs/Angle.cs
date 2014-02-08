using System;
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
        private double angle { get; set; }

        /// <summary>
        /// Retourne l'angle en degrés (-180 à +180)
        /// </summary>
        public double AngleDegres
        {
            get
            {
                return angle;
            }
        }

        /// <summary>
        /// Retourne l'angle en degrés positif (0 à 360 au lieu de -180 à +180)
        /// </summary>
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
        public Angle(double angleDepart, AnglyeType type = AnglyeType.Degre)
        {
            if (type == AnglyeType.Degre)
                angle = angleDepart;
            else if (type == AnglyeType.Radian)
                angle = (double)(180 * angleDepart / Math.PI);

            angle = angle % 360;
            angle = AngleOptimal(this);
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
        public void Tourner(double angleTourne)
        {
            angle += angleTourne;
            angle = AngleOptimal(this);
        }

        /// <summary>
        /// Fait tourner l'angle de l'angle (objet) choisi
        /// </summary>
        /// <param name="angleTourne">Angle à tourner</param>
        public void Tourner(Angle angleTourne)
        {
            this.Tourner(angleTourne.AngleDegres);
        }

        /// <summary>
        /// Retourne l'angle le plus rapide en fonction d'un angle passé en paramètre.
        /// Il est par exemple plus facile de tourner de -15° que de tourner de 345°
        /// </summary>
        /// <param name="a">Angle à tester</param>
        /// <returns>Angle optimal (en degrés)</returns>
        private static double AngleOptimal(Angle a)
        {
            double retour = a.AngleDegres;

            while (retour > 180)
                retour = retour - 360;
            while (retour < -180)
                retour = retour + 360;

            return retour;
        }

        #region Operateurs

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.AngleDegres + a2.AngleDegres, AnglyeType.Degre);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.AnglePositif - a2.AnglePositif, AnglyeType.Degre);
        }

        public static bool operator ==(Angle a1, Angle a2)
        {
            return Math.Abs((a1 - a2).AngleDegres) <= 0.01;
        }

        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1 == a2);
        }

        public static implicit operator Angle(double angle)
        {
            return new Angle(angle);
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
                return ((Angle)obj).AngleDegres == AngleDegres;
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (int)(AngleDegres * 1000);
        }
    }
}
