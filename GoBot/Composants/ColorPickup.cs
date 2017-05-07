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
    public partial class ColorPickup : PictureBox
    {

        public delegate void ColorDelegate(Color color);
        public event ColorDelegate ColorHover;
        public event ColorDelegate ColorClick;

        public ColorPickup()
        {
            InitializeComponent();
            this.Image = global::Composants.Properties.Resources.rainbow2;
            this.Width = this.Image.Width;
            this.Height = this.Image.Height;
            this.MouseMove += ColorPickup_MouseMove;
            this.MouseClick += ColorPickup_MouseClick;
        }

        void ColorPickup_MouseClick(object sender, MouseEventArgs e)
        {
            if (ColorClick != null)
                ColorClick(GetColor(new Point(e.X, e.Y)));
        }

        void ColorPickup_MouseMove(object sender, MouseEventArgs e)
        {
            if (ColorHover != null)
                ColorHover(GetColor(new Point(e.X, e.Y)));
        }

        private Color GetColor(Point pos)
        {
            return global::Composants.Properties.Resources.rainbow2.GetPixel(pos.X, pos.Y);
        }
    }
}
