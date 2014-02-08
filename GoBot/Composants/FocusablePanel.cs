using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composants
{
    public partial class FocusablePanel : UserControl
    {
        private bool ecoute;

        public FocusablePanel()
        {
            BackColor = Color.LightGray;
            InitializeComponent();
            ecoute = true;
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

        public delegate void ToucheEnfonceeDelegate(PreviewKeyDownEventArgs e);
        public event ToucheEnfonceeDelegate ToucheEnfoncee;
        protected override void  OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            if (ecoute)
            {
                ecoute = false;
                ToucheEnfoncee(e);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            ecoute = true;
            base.OnKeyUp(e);
        }
    }
}
