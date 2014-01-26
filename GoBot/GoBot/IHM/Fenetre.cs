using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class Fenetre : Form
    {
        public Fenetre(Control control)
        {
            Controls.Add(control);
            control.SetBounds(0, 0, control.Width, control.Height);
            InitializeComponent();
            this.Width = control.Width + 10;
            this.Height = control.Height + 30;
        }

        public Panel Panel
        {
            set
            {
                Controls.Clear();
                Controls.Add(value);
            }
        }
    }
}
