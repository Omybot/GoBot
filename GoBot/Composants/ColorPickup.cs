using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class ColorPickup : PictureBox
    {
        public delegate void ColorDelegate(Color color);

        /// <summary>
        /// Se produit lorsque la souris passe sur une nouvelle couleur
        /// </summary>
        public event ColorDelegate ColorHover;

        /// <summary>
        /// Se produit lorsque la souris clique sur une couleur
        /// </summary>
        public event ColorDelegate ColorClick;

        public ColorPickup()
        {
            InitializeComponent();
            this.Image = Properties.Resources.Rainbow2D;
            this.Width = this.Image.Width;
            this.Height = this.Image.Height;
            this.MouseMove += ColorPickup_MouseMove;
            this.MouseClick += ColorPickup_MouseClick;
        }

        void ColorPickup_MouseClick(object sender, MouseEventArgs e)
        {
            ColorClick?.Invoke(GetColor(new Point(e.X, e.Y)));
        }

        void ColorPickup_MouseMove(object sender, MouseEventArgs e)
        {
            ColorHover?.Invoke(GetColor(new Point(e.X, e.Y)));
        }

        private Color GetColor(Point pos)
        {
            return Properties.Resources.Rainbow2D.GetPixel(pos.X, pos.Y);
        }
    }
}
