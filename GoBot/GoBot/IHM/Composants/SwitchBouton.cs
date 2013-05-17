using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM.Composants
{
    public partial class SwitchBouton : UserControl
    {
        public SwitchBouton()
        {
            InitializeComponent();
            actif = false;
            focus = false;
            rightToLeft = true;
            ChangeImage();
        }

        private bool actif;
        private bool rightToLeft;
        private bool focus;

        /// <summary>
        /// Retourne vrai ou faux selon l'état du composant
        /// </summary>
        public bool Actif
        {
            get
            {
                return actif;
            }
        }

        public void SetActif(bool active, bool tickEvent = true)
        {
            if (actif != active)
            {
                actif = active;
                ChangeImage();
                if (tickEvent && ChangementEtat != null)
                    ChangementEtat(this, null);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            SetActif(!Actif);
        }

        protected override void OnEnter(EventArgs e)
        {
            focus = true;
            ChangeImage();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            focus = false;
            ChangeImage();
            base.OnLeave(e);
        }

        /// <summary>
        /// Mettre à vrai pour activer le contrôle de droite à gauche au lieu de gauche à droite
        /// </summary>
        public bool Symetrique
        {
            get
            {
                return rightToLeft;
            }
            set
            {
                rightToLeft = value;
                ChangeImage();
            }
        }
        
        public event EventHandler ChangementEtat;

        private void ChangeImage()
        {
            if (actif)
                pictureBox.Image = global::GoBot.Properties.Resources.switchOn;
            else
                pictureBox.Image = global::GoBot.Properties.Resources.switchOff;

            int x = 0;
            if((rightToLeft && !actif) || (!rightToLeft && actif))
                x = 20;

            Bitmap bouton;

            if(focus)
                bouton = global::GoBot.Properties.Resources.trackBarCurseurSelect;
            else
                bouton = global::GoBot.Properties.Resources.trackBarCurseurNormal;

            Graphics g = Graphics.FromImage(pictureBox.Image);
            g.DrawImage(bouton, x, 0);
        }

        private void SwitchBouton_Click(object sender, EventArgs e)
        {
            actif = !actif;

            ChangeImage();
            if (ChangementEtat != null)
                ChangementEtat(this, null);

            Focus();
        }
    }
}
