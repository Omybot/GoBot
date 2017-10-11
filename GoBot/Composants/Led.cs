using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class Led : PictureBox
    {
        private Color color;

        private Timer BlinkTimer { get; set; }
        private int BlinkCounter { get; set; } = 0;

        private static Dictionary<Color, Bitmap> LedsBitmap { get; } // Images déjà créées, inutile de les recaculer à chaque fois

        static Led()
        {
            LedsBitmap = new Dictionary<Color, Bitmap>();
            LedsBitmap.Add(Color.Red, Properties.Resources.RedLed);
        }

        public Led()
        {
            InitializeComponent();
            BackColor = Color.Transparent;

            BlinkTimer = new Timer();
            BlinkTimer.Interval = 100;
            BlinkTimer.Tick += new EventHandler(timer_Tick);

            Color = Color.Red;
        }

        /// <summary>
        /// Permet d'obtenir ou de définir la couleur de la LED
        /// </summary>
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;

                if (!LedsBitmap.ContainsKey(color))
                    GenerateLed(color);

                this.Image = LedsBitmap[color];

            }
        }

        /// <summary>
        /// Fait clignoter la LED 7 fois
        /// </summary>
        /// <param name="shutdown">Vrai si la LED doit rester éteinte à la fin du clignotement</param>
        public void Blink(bool shutdown = false)
        {
            BlinkTimer.Stop();
            Visible = true;
            BlinkCounter = 0;
            if (shutdown)
                BlinkCounter = 1;

            BlinkTimer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
                Visible = false;
            else
                Visible = true;

            BlinkCounter++;

            if (BlinkCounter > 7)
                BlinkTimer.Stop();
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
                    bmp.SetPixel(i, j, Color.FromArgb(ex.A, ex.B + (ex.R - ex.B) / 255 * col.R, ex.B + (ex.R - ex.B) / 255 * col.G, ex.B + (ex.R - ex.B) / 255 * col.B));
                }
            }

            LedsBitmap.Add(col, bmp);
        }
    }
}
