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
    public partial class PanelImageBalise : UserControl
    {
        Semaphore semImage;
        public PanelImageBalise()
        {
            InitializeComponent();
            semImage = new Semaphore(1, 1);
        }

        private void btnParcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                semImage.WaitOne();
                pictureBox.Image = new Bitmap(new Bitmap(open.FileName), 360, 16);
                semImage.Release();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (threadImage == null)
            {
                threadImage = new Thread(ThreadAfficherBande);
                threadImage.Start();
                btnPlay.Text = "Stop";
            }
            else
            {
                threadImage.Abort();
                threadImage = null;
                btnPlay.Text = "Play";
            }
        }

        Thread threadImage = null;
        private double vitesse = 4;
        private void ThreadAfficherBande()
        {
            double ticks = DateTime.Now.Ticks;
            Thread.Sleep(100);
            double ticksParSec = (DateTime.Now.Ticks - ticks) * 10;

            int index = 0;

            DateTime debutImage = DateTime.Now;
            while (true)
            {
                semImage.WaitOne();
                Bitmap image = new Bitmap(pictureBox.Image);
                semImage.Release();

                double imgParSecondes = image.Width * vitesse;
                double ticksParImage = ticksParSec / imgParSecondes;

                long ticksDebut = DateTime.Now.Ticks;

                Bitmap bmp = new Bitmap(15, 32);
                Graphics g = Graphics.FromImage(bmp);
                for(int i = 0; i < 16; i++)
                {
                    using (SolidBrush brush = new SolidBrush(image.GetPixel(index, i)))
                    {
                        g.FillRectangle(brush, 0, i * 2, 15, 2);
                    }
                }

                this.Invoke(new EventHandler(delegate
                {
                    pictureBoxDefilement.Image = bmp;
                    pictureBoxDefilement.SizeMode = PictureBoxSizeMode.StretchImage;
                }));

                index++;
                if (index >= image.Width)
                {
                    Console.WriteLine((DateTime.Now - debutImage).TotalMilliseconds + " ms");
                    debutImage = DateTime.Now;
                    index = 0;
                }
                
                long ticksEcoules;
                do
                {
                    ticksEcoules = DateTime.Now.Ticks - ticksDebut;
                }
                while (ticksEcoules < ticksParImage * (int)numRalentissement.Value);
            }
        }
    }
}
