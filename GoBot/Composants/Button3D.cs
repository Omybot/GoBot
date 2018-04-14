using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class Button3D : PictureBox
    {
        private bool value;

        public Button3D()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
            Image = Properties.Resources.Button3DOff;
            value = false;
        }

        /// <summary>
        /// Obtient ou détermine si le bouton est enfoncé ou non
        /// </summary>
        public bool Value
        {
            get
            {
                return value;
            }
            set
            {
                Image = value ? Properties.Resources.Button3DOn : Properties.Resources.Button3DOff;
                this.value = value;
            }
        }
    }
}
