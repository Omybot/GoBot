using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Composants
{
    public partial class LabelPlus : Label
    {        
        
        // Fonctionnalités supplémentaires :
        //
        //      - Afficher un texte pendant une certaine durée
        //              Fonction TextDuring(texte, durée)

        private Timer timer;
        private Color couleurPrec;

        public LabelPlus()
        {
            InitializeComponent();
        }

        public void TextDuring(String texte, int millis = 2000, Color? couleur = null)
        {
            couleurPrec = ForeColor;

            if (couleur.HasValue)
            {
                ForeColor = couleur.Value;
            }

            Text = texte;

            if (timer != null && timer.Enabled)
                timer.Stop();
            timer = new Timer();
            timer.Interval = millis;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            timer.Start();
        }

        void  timer_Tick(object sender, EventArgs e)
        {
            ForeColor = couleurPrec;
            timer.Stop();
            Text = "";
        }
    }
}
