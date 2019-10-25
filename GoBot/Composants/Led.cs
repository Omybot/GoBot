using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class Led : PictureBox
    {
        private Color _color;

        private Timer _blinkTimer;
        private int _blinkCounter;

        private static Dictionary<Color, Bitmap> _bitmaps { get; set; } // Images déjà créées, inutile de les recaculer à chaque fois
        
        public Led()
        {
            if(_bitmaps is null)
            {
                _bitmaps = new Dictionary<Color, Bitmap>();
                _bitmaps.Add(Color.Red, Properties.Resources.RedLed);
            }

            InitializeComponent();
            BackColor = Color.Transparent;

            _blinkTimer = new Timer();
            _blinkTimer.Interval = 100;
            _blinkTimer.Tick += new EventHandler(timer_Tick);

            _blinkCounter = 0;

            Color = Color.Red;
        }

        /// <summary>
        /// Permet d'obtenir ou de définir la couleur de la LED
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;

                lock (_bitmaps)
                {
                    if (!_bitmaps.ContainsKey(_color))
                        GenerateLed(_color);

                    this.Image = (Image)_bitmaps[_color].Clone();
                }

            }
        }

        /// <summary>
        /// Fait clignoter la LED 7 fois
        /// </summary>
        /// <param name="shutdown">Vrai si la LED doit rester éteinte à la fin du clignotement</param>
        public void Blink(bool shutdown = false)
        {
            _blinkTimer.Stop();
            Visible = true;
            _blinkCounter = 0;
            if (shutdown)
                _blinkCounter = 1;

            _blinkTimer.Start();
        }

        /// <summary>
        /// Change la couleur de la led et la fait clignoter 7 fois si la couleur est différente à la précédente.
        /// </summary>
        /// <param name="color"></param>
        public void BlinkColor(Color color)
        {
            if(_color != color)
            {
                Color = color;
                Blink();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
                Visible = false;
            else
                Visible = true;

            _blinkCounter++;

            if (_blinkCounter > 7)
                _blinkTimer.Stop();
        }
        
        private void GenerateLed(Color col)
        {
            Bitmap bmp;
            Color ex;

            // Création des LEDs de différentes couleurs à partir du modèle rouge
            bmp = new Bitmap(Properties.Resources.RedLed);
            
            for (int i = 0; i <= bmp.Width - 1; i++)
            {
                for (int j = 0; j <= bmp.Height - 1; j++)
                {
                    ex = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, Color.FromArgb(ex.A, (int)(ex.B + (ex.R - ex.B) / 255.0 * col.R), (int)(ex.B + (ex.R - ex.B) / 255.0 * col.G), (int)(ex.B + (ex.R - ex.B) / 255.0 * col.B)));
                }
            }

            _bitmaps.Add(col, bmp);
        }
    }
}
