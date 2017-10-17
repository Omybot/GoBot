using System;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class FocusablePanel : UserControl
    {
        private bool Listening { get; set; }

        public delegate void KeyPressedDelegate(PreviewKeyDownEventArgs e);

        /// <summary>
        /// Se produit lorsque qu'une touche est appuyée
        /// </summary>
        public event KeyPressedDelegate KeyPressed;

        public FocusablePanel()
        {
            BackColor = Color.LightGray;
            InitializeComponent();
            Listening = true;
        }

        protected override void OnEnter(EventArgs e)
        {
            BackColor = Color.FromArgb(72, 216, 251);
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            BackColor = Color.LightGray;
            base.OnLeave(e);
        }

        protected override void  OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            if (Listening)
            {
                Listening = false;
                KeyPressed(e);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            Listening = true;
            base.OnKeyUp(e);
        }
    }
}
