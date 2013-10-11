using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelCamera : UserControl
    {
        private CameraIP Camera { get; set; }
        private Thread ThreadCapture { get; set; }
        public static bool ContinuerCamera { get; set; }

        public PanelCamera()
        {
            InitializeComponent();
            ContinuerCamera = true;
        }

        public void btnCapture_Click(object sender, EventArgs e)
        {
            ThreadCapture = new Thread(ThreadImage);
            ThreadCapture.Start();
        }

        private void ThreadImage()
        {
            Camera = new CameraIP();

            do
            {
                Bitmap img = Camera.GetImage();
                Graphics g = Graphics.FromImage(img);

                // Traiter l'image de la caméra ici
                this.Invoke(new EventHandler(delegate
                {
                    pictureBoxImage.Image = img;
                }));
            }
            while (ContinuerCamera);
        }
    }
}
