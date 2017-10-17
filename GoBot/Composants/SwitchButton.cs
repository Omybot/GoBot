using System;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class SwitchButton : UserControl
    {
        public SwitchButton()
        {
            InitializeComponent();
            value = false;
            mirrored = true;
            ChangeImages();
        }
        
        public delegate void ValueChangedDelegate(object sender, bool value);
        public event ValueChangedDelegate ValueChanged;
        
        private bool value;
        private bool mirrored;

        private bool FocusedImage { get; set; }

        /// <summary>
        /// Retourne vrai ou faux selon l'état du composant
        /// </summary>
        public bool Value
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    ChangeImages();
                    OnValueChanged();
                }
            }
        }

        /// <summary>
        /// Mettre à vrai pour activer le contrôle de droite à gauche au lieu de gauche à droite
        /// </summary>
        public bool Mirrored
        {
            get
            {
                return mirrored;
            }
            set
            {
                mirrored = value;
                ChangeImages();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Value = (!Value);
        }

        protected override void OnEnter(EventArgs e)
        {
            FocusedImage = true;
            ChangeImages();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            FocusedImage = false;
            ChangeImages();
            base.OnLeave(e);
        }

        protected void OnValueChanged()
        {
            ValueChanged?.Invoke(this, value);
        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            Focus();
            Value = !Value;
        }

        private void ChangeImages()
        {
            if (value)
                pictureBox.Image = Properties.Resources.SwitchOn;
            else
                pictureBox.Image = Properties.Resources.SwitchOff;

            int x = 0;
            if((mirrored && !value) || (!mirrored && value))
                x = 20;

            Bitmap bouton;

            if(FocusedImage)
                bouton = Properties.Resources.TrackBarCurseurSelect;
            else
                bouton = Properties.Resources.TrackBarCurseurNormal;

            Graphics.FromImage(pictureBox.Image).DrawImage(bouton, x, 0);
        }
    }
}
