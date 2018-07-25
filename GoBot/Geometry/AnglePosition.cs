using System;

namespace Geometry
{
    public enum AngleType
    {
        Radian,
        Degre
    }

    public struct AnglePosition
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
        public AnglePosition(double angle, AngleType type = AngleType.Degre)
        {
            if (type == AngleType.Degre)
                _angle = angle;
            else
                _angle = (double)(180 * angle / Math.PI);

            _angle = _angle % 360;

            if (_angle > 180)
                _angle = _angle - 360;
            if (_angle < -180)
                _angle = _angle + 360;
        }

        #endregion

        #region Trigonometrie

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
        /// Retourne l'angle en radians (-PI à +PI)
        /// </summary>
        public double InRadians
        {
            get
            {
                return (double)(_angle / 180 * Math.PI);
            }
        }

        /// <summary>
        /// Retourne l'angle en degrés (-180 à +180)
        /// </summary>
        public double InDegrees
        {
            get
            {
                return _angle;
            }
        }

        /// <summary>
        /// Retourne l'angle en degrés positif (0 à 360)
        /// </summary>
        public double InPositiveDegrees
        {
            get
            {
                if (_angle < 0)
                    return 360 + _angle;
                else
                    return _angle;
            }
        }

        /// <summary>
        /// Retourne l'angle en radians positif (0 à 2PI)
        /// </summary>
        public double InPositiveRadians
        {
            get
            {
                return InPositiveDegrees / 180 * Math.PI;
            }
        }

        #endregion

        #region Centre de l'arc

        public static AnglePosition Center(AnglePosition startAngle, AnglePosition endAngle)
        {
            AnglePosition a;

            if (startAngle.InPositiveDegrees < endAngle.InPositiveDegrees)
                a = new AnglePosition((startAngle.InPositiveDegrees + endAngle.InPositiveDegrees) / 2);
            else
                a = new AnglePosition((startAngle.InPositiveDegrees + endAngle.InPositiveDegrees) / 2 + 180);

            return a;
        }

        public static AnglePosition CenterSmallArc(AnglePosition a1, AnglePosition a2)
        {
            AnglePosition a;

            if (Math.Abs(a1.InPositiveDegrees - a2.InPositiveDegrees) < 180)
                return new AnglePosition((a1.InPositiveDegrees + a2.InPositiveDegrees) / 2);
            else
                a = new AnglePosition((a1.InPositiveDegrees + a2.InPositiveDegrees) / 2 + 180);

            return a;
        }

        public static AnglePosition CenterLongArc(AnglePosition a1, AnglePosition a2)
        {
            AnglePosition a;

            if (Math.Abs(a1.InPositiveDegrees - a2.InPositiveDegrees) > 180)
                a = new AnglePosition((a1.InPositiveDegrees + a2.InPositiveDegrees) / 2);
            else
                a = new AnglePosition((a1.InPositiveDegrees + a2.InPositiveDegrees) / 2 + 180);

            return a;
        }

        #endregion

        #region Autres calculs

        /// <summary>
        /// Retourne si l'angle est compris entre les angles données, c'est à dire qu'il se situe dans l'arc de cercle partant de startAngle vers endAngle
        /// Exemples : 
        /// 150° est entre 130° et 160° mais pas entre 160° et 130°
        /// 10° est entre 350° et 50° mais pas entre 50° et 350°
        /// </summary>
        /// <param name="startAngle">Angle de départ</param>
        /// <param name="endAngle">Angle d'arrivée</param>
        /// <returns>Vrai si l'angle est compris entre les deux angles</returns>
        public bool IsOnArc(AnglePosition startAngle, AnglePosition endAngle)
        {
            bool ok;

            if (startAngle.InPositiveDegrees < endAngle.InPositiveDegrees)
                ok = this.InPositiveDegrees >= startAngle.InPositiveDegrees && this.InPositiveDegrees <= endAngle.InPositiveDegrees;
            else
                ok = this.InPositiveDegrees == startAngle.InPositiveDegrees || this.InPositiveDegrees == endAngle.InPositiveDegrees || !this.IsOnArc(endAngle, startAngle);

            return ok;
        }

        #endregion

        #region Operateurs

        public static AnglePosition operator +(AnglePosition a1, AngleDelta a2)
        {
            return new AnglePosition(a1.InPositiveDegrees + a2.InDegrees, AngleType.Degre);
        }

        public static AnglePosition operator -(AnglePosition a1, AngleDelta a2)
        {
            return new AnglePosition(a1.InPositiveDegrees - a2.InDegrees, AngleType.Degre);
        }

        public static AngleDelta operator -(AnglePosition start, AnglePosition end)
        {
            double a = start.InDegrees - end.InDegrees;

            if (a > 180)
                a = -(360 - a);
            if (a < -180)
                a = 360 + a;

            return new AngleDelta(a);
        }

        public static bool operator ==(AnglePosition a1, AnglePosition a2)
        {
            return Math.Abs((a1 - a2).InDegrees) <= PRECISION;
        }

        public static bool operator !=(AnglePosition a1, AnglePosition a2)
        {
            return !(a1 == a2);
        }

        public static implicit operator AnglePosition(double angle)
        {
            return new AnglePosition(angle);
        }

        public static implicit operator double(AnglePosition angle)
        {
            return angle.InDegrees;
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            try
            {
                return Math.Abs(((AnglePosition)obj)._angle - _angle) < PRECISION;
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
