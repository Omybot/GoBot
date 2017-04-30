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
    public partial class Button3D : PictureBox
    {
        private bool state;

        public Button3D()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
            Image = global::Composants.Properties.Resources.btnOff;
            state = false;
        }

        public void Off()
        {
            Image = global::Composants.Properties.Resources.btnOff;
            state = false;
        }

        public void On()
        {
            Image = global::Composants.Properties.Resources.btnOn;
            state = true;
        }

        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                if (value)
                    On();
                else
                    Off();
            }
        }
    }
}
