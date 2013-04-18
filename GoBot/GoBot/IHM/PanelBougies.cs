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
    public partial class PanelBougies : UserControl
    {
        private CameraIP Camera { get; set; }
        private int BougiePlacement { get; set; }
        private Font font = new Font("Calibri", 8);
        private List<Button> Boutons { get; set; }

        public PanelBougies()
        {
            InitializeComponent();
            BougiePlacement = -1;

            Boutons = new List<Button>();

            Boutons.Add(button0);
            Boutons.Add(button1);
            Boutons.Add(button2);
            Boutons.Add(button3);
            Boutons.Add(button4);
            Boutons.Add(button5);
            Boutons.Add(button6);
            Boutons.Add(button7);
            Boutons.Add(button8);
            Boutons.Add(button9);

            Boutons.Add(button10);
            Boutons.Add(button11);
            Boutons.Add(button12);
            Boutons.Add(button13);
            Boutons.Add(button14);
            Boutons.Add(button15);
            Boutons.Add(button16);
            Boutons.Add(button17);
            Boutons.Add(button18);
            Boutons.Add(button19);

            ChangementCouleur();
        }

        private void PanelBougies_Load(object sender, EventArgs e)
        {
            Camera = new CameraIP();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            th = new Thread(ThreadImage);
            th.Start();
        }

        private Thread th;
        private void ThreadImage()
        {
            Bitmap img = Camera.GetImage();
            Graphics g = Graphics.FromImage(img);
            Color color;

            this.Invoke(new EventHandler(delegate
            {
                if (Plateau.NotreCouleur == Color.Red)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Color pixel = img.GetPixel(Config.CurrentConfig.PositionsBougiesX[i], Config.CurrentConfig.PositionsBougiesY[i]);

                        if (pixel.B > pixel.R)
                        {
                            Boutons[i].BackColor = Color.Blue;
                            Boutons[i].ForeColor = Color.Red;
                            Boutons[i + 10].BackColor = Color.Red;
                            Boutons[i + 10].ForeColor = Color.Blue;
                            color = Color.Red;
                        }
                        else if (pixel.R + pixel.B + pixel.G < 350)
                        {
                            Boutons[i].BackColor = Color.Red;
                            Boutons[i].ForeColor = Color.Blue;
                            Boutons[i + 10].BackColor = Color.Blue;
                            Boutons[i + 10].ForeColor = Color.Red;
                            color = Color.Blue;
                        }
                        else
                        {
                            Boutons[i].BackColor = Color.White;
                            Boutons[i].ForeColor = Color.Black;
                            Boutons[i + 10].BackColor = Color.White;
                            Boutons[i + 10].ForeColor = Color.Black;
                            color = Color.Black;
                        }

                        g.DrawString(i + "", font, new SolidBrush(color), new PointF(Config.CurrentConfig.PositionsBougiesX[i] - 2, Config.CurrentConfig.PositionsBougiesY[i] - 2));

                        Plateau.CouleursBougies[i] = Boutons[i].BackColor;
                    }
                }
                else
                {
                    for (int i = 10; i < 20; i++)
                    {
                        Color pixel = img.GetPixel(Config.CurrentConfig.PositionsBougiesX[i], Config.CurrentConfig.PositionsBougiesY[i]);

                        if (pixel.B > pixel.R)
                        {
                            Boutons[i].BackColor = Color.Blue;
                            Boutons[i - 10].BackColor = Color.Red;
                            color = Color.Red;
                        }
                        else if (pixel.R + pixel.B + pixel.G < 350)
                        {
                            Boutons[i].BackColor = Color.Red;
                            Boutons[i - 10].BackColor = Color.Blue;
                            color = Color.Blue;
                        }
                        else
                        {
                            Boutons[i].BackColor = Color.White;
                            Boutons[i - 10].BackColor = Color.White;
                            color = Color.Black;
                        }

                        g.DrawString(i + "", font, new SolidBrush(color), new PointF(Config.CurrentConfig.PositionsBougiesX[i] - 2, Config.CurrentConfig.PositionsBougiesY[i] - 2));

                        Plateau.CouleursBougies[i] = Boutons[i].BackColor;
                    }
                }

                pictureBoxImage.Image = img;
            }));
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            BougiePlacement = Convert.ToInt32(((Button)sender).Text);
        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            if (BougiePlacement != -1)
            {
                Config.CurrentConfig.PositionsBougiesX[BougiePlacement] = pictureBoxImage.PointToClient(MousePosition).X;
                Config.CurrentConfig.PositionsBougiesY[BougiePlacement] = pictureBoxImage.PointToClient(MousePosition).Y;

                BougiePlacement = -1;
            }
        }

        public void ChangementCouleur()
        {
            if (Plateau.NotreCouleur == Color.Blue)
            {
                for (int i = 10; i < 20; i++)
                    Boutons[i].Enabled = true;
                for (int i = 0; i < 10; i++)
                    Boutons[i].Enabled = false;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                    Boutons[i].Enabled = true;
                for (int i = 10; i < 20; i++)
                    Boutons[i].Enabled = false;
            }
        }

        private void btnAlea_Click(object sender, EventArgs e)
        {
            int nbBleues = 0;
            int nbRouges = 0;

            int nbMaxCouleur = 5;
            if(boxBlanches.Checked)
                nbMaxCouleur = 4;

            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                if (boxBlanches.Checked && (i == 7 || i == 9))
                {
                    Plateau.CouleursBougies[i] = Color.White;
                    Plateau.CouleursBougies[i + 10] = Color.White;
                }
                else if (nbRouges == nbMaxCouleur || (rand.Next(2) == 0 && nbBleues < nbMaxCouleur))
                {
                    Plateau.CouleursBougies[i] = Color.Blue;
                    Plateau.CouleursBougies[i + 10] = Color.Red;
                    nbBleues++;
                }
                else
                {
                    Plateau.CouleursBougies[i] = Color.Red;
                    Plateau.CouleursBougies[i + 10] = Color.Blue;
                    nbRouges++;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                if (Plateau.CouleursBougies[i] == Color.Blue)
                    Boutons[i].BackColor = Color.Blue;
                else if (Plateau.CouleursBougies[i] == Color.Red)
                    Boutons[i].BackColor = Color.Red;
                else
                    Boutons[i].BackColor = Color.White;
            }
        }
    }
}
