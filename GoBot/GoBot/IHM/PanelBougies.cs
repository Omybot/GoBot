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

            if (!Config.DesignMode)
                btnAlea_Click(null, null);

            ContinuerJusquauDebutMatch = false;
        }

        private void PanelBougies_Load(object sender, EventArgs e)
        {
        }

        public bool imageRefresh;
        public void btnCapture_Click(object sender, EventArgs e)
        {
            imageRefresh = false;
            th = new Thread(ThreadImage);
            th.Start();
        }

        public static bool ContinuerJusquauDebutMatch { get; set; }

        private Thread th;
        private void ThreadImage()
        {
            Camera = new CameraIP();

            if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
            {
                Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraBleu);
                Thread.Sleep(200);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraRouge);
                Thread.Sleep(1000);
            }
            else
            {
                Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraRouge);
                Thread.Sleep(200);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraBleu);
                Thread.Sleep(1000);
            }
            do
            {
                Bitmap img = Camera.GetImage();
                Graphics g = Graphics.FromImage(img);

                if (Plateau.Enchainement != null)
                    return;

                CheckForIllegalCrossThreadCalls = false;
                this.Invoke(new EventHandler(delegate
                {
                    Plateau.CouleursBougies[10] = Plateau.CouleurJ2B;
                    Plateau.CouleursBougies[11] = Plateau.CouleurJ2B;

                    Plateau.CouleursBougies[0] = Plateau.CouleurJ1R;
                    Plateau.CouleursBougies[1] = Plateau.CouleurJ1R;

                    if (boxBlanches.Checked)
                    {
                        Plateau.CouleursBougies[7] = Color.White;
                        Plateau.CouleursBougies[9] = Color.White;
                        Plateau.CouleursBougies[17] = Color.White;
                        Plateau.CouleursBougies[19] = Color.White;
                    }

                    List<int> valeursBleu = new List<int>();
                    int min = 12, max = 20, offset = -10;
                    if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
                    {
                        min = 2; max = 10; offset = 10;
                    }
                    for (int i = min; i < max; i++)
                    {
                        if (boxBlanches.Checked && (i == 17 || i == 19 || i == 7 || i == 9))
                            continue;

                        Color pixel = img.GetPixel(Config.CurrentConfig.PositionsBougiesCameraX[i], Config.CurrentConfig.PositionsBougiesCameraY[i]);
                        Console.WriteLine(i + " R=" + pixel.R + " G=" + pixel.G + " B=" + pixel.B);
                        //valeursBleu.Add(pixel.B);

                        if (pixel.R > pixel.B)
                        {
                            Plateau.CouleursBougies[i] = Plateau.CouleurJ1R;
                            Plateau.CouleursBougies[i + offset] = Plateau.CouleurJ2B;
                        }
                        else
                        {
                            Plateau.CouleursBougies[i] = Plateau.CouleurJ2B;
                            Plateau.CouleursBougies[i + offset] = Plateau.CouleurJ1R;
                        }
                    }

                    /*
                    valeursBleu.Sort();
                    List<int> valeursBleuMax = new List<int>();

                    int nbBleu = 4;
                    int delta = 10;
                    if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
                    {
                        nbBleu = 2;
                        delta = -10;
                    }

                    for (int i = valeursBleu.Count - 1; i > valeursBleu.Count - nbBleu - 1; i--)
                        valeursBleuMax.Add(valeursBleu[i]);

                    for (int i = min; i < max; i++)
                    {
                        if (boxBlanches.Checked && (i == 17 || i == 19 || i == 7 || i == 9))
                            continue;

                        Color pixel = img.GetPixel(Config.CurrentConfig.PositionsBougiesCameraX[i], Config.CurrentConfig.PositionsBougiesCameraY[i]);

                        if (valeursBleuMax.Contains(pixel.B))
                        {
                            Plateau.CouleursBougies[i] = Plateau.CouleurJ2B;
                            Plateau.CouleursBougies[i + delta] = Plateau.CouleurJ1R;
                        }
                        else
                        {
                            Plateau.CouleursBougies[i] = Plateau.CouleurJ1R;
                            Plateau.CouleursBougies[i + delta] = Plateau.CouleurJ2B;
                        }
                    }*/

                    DessineChiffres(img);
                    imageRefresh = true;
                }));
            }
            while (ContinuerJusquauDebutMatch);
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            BougiePlacement = Convert.ToInt32(((Button)sender).Text);
        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            if (BougiePlacement != -1)
            {
                Config.CurrentConfig.PositionsBougiesCameraX[BougiePlacement] = pictureBoxImage.PointToClient(MousePosition).X;
                Config.CurrentConfig.PositionsBougiesCameraY[BougiePlacement] = pictureBoxImage.PointToClient(MousePosition).Y;
                BougiePlacement++;
                if (BougiePlacement == 20)
                    BougiePlacement = 12;
                if(BougiePlacement == 10)
                    BougiePlacement = 2;
            }
        }
        
        public void ChangementCouleur()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
            {
                BougiePlacement = 12;
                for (int i = 10; i < 20; i++)
                    Boutons[i].Enabled = true;
                for (int i = 0; i < 10; i++)
                    Boutons[i].Enabled = false;
            }
            else
            {
                BougiePlacement = 2;
                for (int i = 0; i < 10; i++)
                    Boutons[i].Enabled = true;
                for (int i = 10; i < 20; i++)
                    Boutons[i].Enabled = false;
            }
        }

        private void btnAlea_Click(object sender, EventArgs e)
        {
            int nbBleues = 0;
            int nbRouges = 2;

            int nbMaxCouleur = 5;
            if (boxBlanches.Checked)
                nbMaxCouleur = 4;

            Random rand = new Random(DateTime.Now.Millisecond);

            Plateau.CouleursBougies[1] = Plateau.CouleurJ1R;
            Plateau.CouleursBougies[11] = Plateau.CouleurJ2B;

            Plateau.CouleursBougies[0] = Plateau.CouleurJ1R;
            Plateau.CouleursBougies[10] = Plateau.CouleurJ2B;

            for (int i = 2; i < 10; i++)
            {
                if (boxBlanches.Checked && (i == 7 || i == 9))
                {
                    Plateau.CouleursBougies[i] = Color.White;
                    Plateau.CouleursBougies[i + 10] = Color.White;
                }
                else if (nbRouges == nbMaxCouleur || (rand.Next(2) == 0 && nbBleues < nbMaxCouleur))
                {
                    Plateau.CouleursBougies[i] = Plateau.CouleurJ2B;
                    Plateau.CouleursBougies[i + 10] = Plateau.CouleurJ1R;
                    nbBleues++;
                }
                else
                {
                    Plateau.CouleursBougies[i] = Plateau.CouleurJ1R;
                    Plateau.CouleursBougies[i + 10] = Plateau.CouleurJ2B;
                    nbRouges++;
                }
            }

            DessineChiffres();
        }

        private void btnBlanc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                Plateau.CouleursBougies[i] = Color.White;

            DessineChiffres();
        }

        private void DessineChiffres(Bitmap img = null)
        {
            for (int i = 0; i < 20; i++)
            {
                Boutons[i].BackColor = Plateau.CouleursBougies[i];
                if (Plateau.CouleursBougies[i] == Color.White)
                    Boutons[i].ForeColor = Color.Black;
                else
                    Boutons[i].ForeColor = Color.White;
            }
            if (img != null)
            {
                Graphics g = Graphics.FromImage(img);

                int debut = 0, fin = 10;
                if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
                {
                    debut = 10;
                    fin = 20;
                }

                using(SolidBrush brushBlanc = new SolidBrush(Color.White), brushNoir = new SolidBrush(Color.Black))
                    for (int i = debut; i < fin; i++)
                        g.DrawString(i + "", font, Plateau.CouleursBougies[i] == Color.White ? brushNoir : brushBlanc, new PointF(Config.CurrentConfig.PositionsBougiesCameraX[i] - 2, Config.CurrentConfig.PositionsBougiesCameraY[i] - 2));

                pictureBoxImage.Image = img;
                img.Dispose();
            }
        }
    }
}
