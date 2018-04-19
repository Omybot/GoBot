using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace GoBot
{
    public struct ColorPlus
    {
        #region Fields

        private Color _innerColor;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définit la couleur selon sa valeur 32 bits.
        /// </summary>
        public int ARGB
        {
            get
            {
                return _innerColor.ToArgb();
            }
            set
            {
                _innerColor = Color.FromArgb(value);
            }
        }

        /// <summary>
        /// Obtient ou définit la transparence de la couleur (0 = Transparent, 255 = Opaque).
        /// </summary>
        public byte Alpha
        {
            get
            {
                return _innerColor.A;
            }

            set
            {
                _innerColor = Color.FromArgb(value, _innerColor.R, _innerColor.G, _innerColor.B);
            }
        }

        /// <summary>
        /// Obtient ou définit la composante rouge de la couleur.
        /// </summary>
        public byte Red
        {
            get
            {
                return _innerColor.R;
            }

            set
            {
                _innerColor = Color.FromArgb(_innerColor.A, value, _innerColor.G, _innerColor.B);
            }
        }

        /// <summary>
        /// Obtient ou définit la composante verte de la couleur.
        /// </summary>
        public byte Green
        {
            get
            {
                return _innerColor.G;
            }

            set
            {
                _innerColor = Color.FromArgb(_innerColor.A, _innerColor.R, value, _innerColor.B);
            }
        }

        /// <summary>
        /// Obtient ou définit la composante bleue de la couleur.
        /// </summary>
        public byte Blue
        {
            get
            {
                return _innerColor.B;
            }

            set
            {
                _innerColor = Color.FromArgb(_innerColor.A, _innerColor.R, _innerColor.G, value);
            }
        }

        /// <summary>
        /// Obtient ou définit la teinte de la couleur (0° à 360°).
        /// </summary>
        public double Hue
        {
            get
            {
                return _innerColor.GetHue();
            }

            set
            {
                _innerColor = ColorPlus.FromAhsl(_innerColor.A, value, _innerColor.GetSaturation(), _innerColor.GetBrightness());
            }
        }


        /// <summary>
        /// Obtient ou définit la saturation de la couleur (0 = Terne, 1 = Vive).
        /// </summary>
        public double Saturation
        {
            get
            {
                return _innerColor.GetSaturation();
            }

            set
            {
                _innerColor = ColorPlus.FromAhsl(_innerColor.A, _innerColor.GetHue(), value, _innerColor.GetBrightness());
            }
        }

        /// <summary>
        /// Obtient ou définit la luminosité de la couleur (0 = Sombre, 1 = Claire)
        /// </summary>
        public double Lightness
        {
            get
            {
                return _innerColor.GetBrightness();
            }

            set
            {
                _innerColor = ColorPlus.FromAhsl(_innerColor.A, _innerColor.GetHue(), _innerColor.GetSaturation(), value);
            }
        }

        #endregion

        #region Factory

        /// <summary>
        /// Créée une couleur depuis les paramètres de rouge, bleu et vert.
        /// </summary>
        /// <param name="r">Composante rouge, de 0 à 255.</param>
        /// <param name="g">Composante verte, de 0 à 255.</param>
        /// <param name="b">Composante bleue, de 0 à 255.</param>
        /// <returns>Couleur correspondante.</returns>
        public static ColorPlus FromRgb(int r, int g, int b)
        {
            return FromArgb(255, r, g, b);
        }

        /// <summary>
        /// Créée une couleur depuis les paramètres de transparence, rouge, bleu et vert.
        /// </summary>
        /// <param name="alpha">Transparence, de 0 à 255.</param>
        /// <param name="r">Composante rouge, de 0 à 255.</param>
        /// <param name="g">Composante verte, de 0 à 255.</param>
        /// <param name="b">Composante bleue, de 0 à 255.</param>
        /// <returns>Couleur correspondante.</returns>
        public static ColorPlus FromArgb(int alpha, int r, int g, int b)
        {
            if (0 > alpha || 255 < alpha)
                throw new ArgumentOutOfRangeException(nameof(alpha));
            if (0 > r || 255 < r)
                throw new ArgumentOutOfRangeException(nameof(r));
            if (0 > g || 255 < g)
                throw new ArgumentOutOfRangeException(nameof(g));
            if (0 > b || 255 < b)
                throw new ArgumentOutOfRangeException(nameof(b));

            ColorPlus color = new ColorPlus();
            color._innerColor = Color.FromArgb(alpha, r, g, b);

            return color;
        }

        /// <summary>
        /// Créée une couleur depuis les paramètres de teinte, saturation et luminosité.
        /// </summary>
        /// <param name="hue">Teinte de 0° à 360°.</param>
        /// <param name="saturation">Saturation de 0 à 1.</param>
        /// <param name="lighting">Luminosité de 0 à 1.</param>
        /// <returns>Couleur correspondante.</returns>
        public static ColorPlus FromHsl(double hue, double saturation, double lighting)
        {
            return FromAhsl(255, hue, saturation, lighting);
        }

        /// <summary>
        /// Créée une couleur depuis les paramètres de transparence, teinte, saturation et luminosité.
        /// </summary>
        /// <param name="alpha">Transparence, de 0 à 255.</param>
        /// <param name="hue">Teinte de 0° à 360°.</param>
        /// <param name="saturation">Saturation de 0 à 1.</param>
        /// <param name="lighting">Luminosité de 0 à 1.</param>
        /// <returns>Couleur correspondante.</returns>
        public static ColorPlus FromAhsl(int alpha, double hue, double saturation, double lighting)
        {
            if (0 > alpha || 255 < alpha)
                throw new ArgumentOutOfRangeException(nameof(alpha));
            if (0f > hue || 360f < hue)
                throw new ArgumentOutOfRangeException(nameof(hue));
            if (0f > saturation || 1f < saturation)
                throw new ArgumentOutOfRangeException(nameof(saturation));
            if (0f > lighting || 1f < lighting)
                throw new ArgumentOutOfRangeException(nameof(lighting));

            if (0 == saturation)
            {
                return Color.FromArgb(alpha, Convert.ToInt32(lighting * 255), Convert.ToInt32(lighting * 255), Convert.ToInt32(lighting * 255));
            }

            double fMax, fMid, fMin;
            int sextant, iMax, iMid, iMin;

            if (0.5 < lighting)
            {
                fMax = lighting - (lighting * saturation) + saturation;
                fMin = lighting + (lighting * saturation) - saturation;
            }
            else
            {
                fMax = lighting + (lighting * saturation);
                fMin = lighting - (lighting * saturation);
            }

            sextant = (int)Math.Floor(hue / 60f);

            if (300f <= hue)
                hue -= 360f;

            hue /= 60f;
            hue -= 2f * (double)Math.Floor(((sextant + 1f) % 6f) / 2f);

            if (0 == sextant % 2)
                fMid = hue * (fMax - fMin) + fMin;
            else
                fMid = fMin - hue * (fMax - fMin);

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            ColorPlus color = new ColorPlus();

            switch (sextant)
            {
                case 1:
                    color._innerColor = Color.FromArgb(alpha, iMid, iMax, iMin);
                    break;
                case 2:
                    color._innerColor = Color.FromArgb(alpha, iMin, iMax, iMid);
                    break;
                case 3:
                    color._innerColor = Color.FromArgb(alpha, iMin, iMid, iMax);
                    break;
                case 4:
                    color._innerColor = Color.FromArgb(alpha, iMid, iMin, iMax);
                    break;
                case 5:
                    color._innerColor = Color.FromArgb(alpha, iMax, iMin, iMid);
                    break;
                default:
                    color._innerColor = Color.FromArgb(alpha, iMax, iMid, iMin);
                    break;
            }

            return color;
        }

        /// <summary>
        /// Retourne la couleur fluo équivalente.
        /// </summary>
        /// <param name="color">Couleur d'origine.</param>
        /// <returns>Couleur fluo.</returns>
        public static ColorPlus GetFluo(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.6);
        }

        /// <summary>
        /// Retourne la couleur intense équivalente.
        /// </summary>
        /// <param name="color">Couleur d'origine.</param>
        /// <returns>Couleur intense.</returns>
        public static ColorPlus GetIntense(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.4);
        }

        /// <summary>
        /// Retourne la couleur pastel équivalente.
        /// </summary>
        /// <param name="color">Couleur d'origine.</param>
        /// <returns>Couleur pastel.</returns>
        public static ColorPlus GetPastel(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.85);
        }

        /// <summary>
        /// Retourne la couleur très estompée équivalente.
        /// </summary>
        /// <param name="color">Couleur d'origine.</param>
        /// <returns>Couleur très estompée.</returns>
        public static ColorPlus GetVeryLight(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.93);
        }

        /// <summary>
        /// Retourne la couleur sombre équivalente.
        /// </summary>
        /// <param name="color">Couleur d'origine.</param>
        /// <returns>Couleur sombre.</returns>
        public static ColorPlus GetDark(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.3);
        }

        /// <summary>
        /// Retourne la couleur terne équivalente.
        /// </summary>
        /// <param name="color">Couleur d'origine.</param>
        /// <returns>Couleur terne.</returns>
        public static ColorPlus GetDull(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 0.2, 0.75);
        }

        /// <summary>
        /// Retourne la couleur connue la plus similaire à la couleur inconnue.
        /// </summary>
        /// <param name="unknown">Couleur inconnue.</param>
        /// <param name="knowns">Couleurs connues.</param>
        /// <returns>Couleur connue la plus proche de la couleur inconnue.</returns>
        public static ColorPlus GuessColor(ColorPlus unknown, IEnumerable<ColorPlus> knowns)
        {
            return knowns.OrderBy(known => HueDelta(unknown, known)).First();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Calcule la différence angulaire en degrés de la teinte entre deux couleurs.
        /// </summary>
        /// <param name="c1">Première couleur.</param>
        /// <param name="c2">Deuxième couleur.</param>
        /// <returns>Différence angulaire.</returns>
        public static double HueDelta(ColorPlus c1, ColorPlus c2)
        {
            double d1 = Math.Abs(c1.Hue - c2.Hue);
            double d2 = Math.Abs(c1.Hue - (c2.Hue - 360));
            double d3 = Math.Abs(c1.Hue - (c2.Hue + 360));

            return new double[] { d1, d2, d3 }.Min();
        }

        #endregion

        #region Operators

        public static implicit operator ColorPlus(Color color)
        {
            return new ColorPlus { _innerColor = color };
        }

        public static implicit operator Color(ColorPlus color)
        {
            return Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
        }

        public static implicit operator ColorPlus(int color)
        {
            return new ColorPlus { ARGB = color };
        }

        public static implicit operator int(ColorPlus color)
        {
            return color.ARGB;
        }

        public override string ToString()
        {
            return "{R = " + this.Red.ToString() + ", G = " + this.Green.ToString() + ", B = " + this.Blue.ToString() + "} - {H = " + this.Hue.ToString("0") + "°, S = " + (this.Saturation * 100).ToString("0") + "%, L = " + (this.Lightness * 100).ToString("0") + "%}";
        }

        #endregion
    }
}
