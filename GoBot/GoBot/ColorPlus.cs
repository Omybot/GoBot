using System;
using System.Drawing;

namespace GoBot
{
    public class ColorPlus
    {
        #region Fields

        private Color _innerColor;

        #endregion

        #region Properties

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

        #region Constructors

        public ColorPlus(ColorPlus other)
        {
            _innerColor = other._innerColor;
        }

        private ColorPlus()
        {

        }

        #endregion

        #region Factory

        public static ColorPlus FromRgb(int r, int g, int b)
        {
            return FromArgb(255, r, g, b);
        }

        public static ColorPlus FromArgb(int alpha, int r, int g, int b)
        {
            if (0 > alpha || 255 < alpha)
                throw new ArgumentOutOfRangeException("alpha");
            if (0 > r || 255 < r)
                throw new ArgumentOutOfRangeException("red");
            if (0 > g || 255 < g)
                throw new ArgumentOutOfRangeException("green");
            if (0 > b || 255 < b)
                throw new ArgumentOutOfRangeException("blue");

            ColorPlus color = new ColorPlus();
            color._innerColor = Color.FromArgb(alpha, r, g, b);

            return color;
        }

        public static ColorPlus FromHsl(double hue, double saturation, double lighting)
        {
            return FromAhsl(255, hue, saturation, lighting);
        }

        public static ColorPlus FromAhsl(int alpha, double hue, double saturation, double lighting)
        {
            if (0 > alpha || 255 < alpha)
                throw new ArgumentOutOfRangeException("alpha");
            if (0f > hue || 360f < hue)
                throw new ArgumentOutOfRangeException("hue");
            if (0f > saturation || 1f < saturation)
                throw new ArgumentOutOfRangeException("saturation");
            if (0f > lighting || 1f < lighting)
                throw new ArgumentOutOfRangeException("lighting");

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

        public static ColorPlus GetFluo(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.6);
        }

        public static ColorPlus GetIntense(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.4);
        }

        public static ColorPlus GetPastel(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.85);
        }

        public static ColorPlus GetVeryLight(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.9);
        }

        public static ColorPlus GetDark(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 1, 0.3);
        }

        public static ColorPlus GetFade(ColorPlus color)
        {
            return ColorPlus.FromHsl(color.Hue, 0.2, 0.75);
        }

        #endregion

        #region Operators


        public static implicit operator ColorPlus(Color color)
        {
            return ColorPlus.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static implicit operator Color(ColorPlus color)
        {
            return Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
        }

        #endregion
    }
}
