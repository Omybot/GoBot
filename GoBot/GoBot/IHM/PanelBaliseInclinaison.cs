using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs;
using GoBot.Balises;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelBaliseInclinaison : UserControl
    {
        private Balise balise;
        public Balise Balise
        {
            get
            {
                return balise;
            }
            set
            {
                balise = value;
                if (balise != null)
                {
                    groupBalise.Text = "Balise " + balise.Carte;
                }
            }
        }

        public PanelBaliseInclinaison()
        {
            InitializeComponent();
        }

        private void trackBarInclinaisonFace_ValueChanged(object sender, EventArgs e)
        {
            lblInclinaisonFace.Text = trackBarInclinaisonFace.Value.ToString();
        }

        private void trackBarInclinaisonProfil_ValueChanged(object sender, EventArgs e)
        {
            lblInclinaisonProfil.Text = trackBarInclinaisonProfil.Value.ToString();
        }

        private void trackBarInclinaisonFace_TickValueChanged(object sender, EventArgs e)
        {
            Balise.InclinaisonFace = (int)trackBarInclinaisonFace.Value;
        }

        private void trackBarInclinaisonProfil_TickValueChanged(object sender, EventArgs e)
        {
            Balise.InclinaisonProfil = (int)trackBarInclinaisonProfil.Value;
        }

        BackgroundWorker worker;
        private void btnCourseFace_Click(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            /*Balise.InclinaisonFace = Config.CurrentConfig.GetCourseFaceMin(Balise.Carte);
            Thread.Sleep(300);
            List<double> valeurs = Balise.ParcourirAxeFace((int)numPasFace.Value, Config.CurrentConfig.GetCourseFaceMin(Balise.Carte), Config.CurrentConfig.GetCourseFaceMax(Balise.Carte), true, true);

            ctrlGraphique.SupprimerCourbe("Face");
            ctrlGraphique.SupprimerCourbe("Profil");
            foreach (double d in valeurs)
                ctrlGraphique.AjouterPoint("Face", d, Color.Blue);

            ctrlGraphique.DessineCourbes();

            int minLarge = -1;

            for (int i = 0; i < valeurs.Count; i++)
                if (valeurs[i] != 0)
                {
                    if (minLarge == -1)
                        minLarge = (i - 1) * (int)numPasFace.Value + Config.CurrentConfig.GetCourseFaceMin(Balise.Carte);
                }

            Console.WriteLine("min = " + minLarge);

            int minPrecis = -1;
            int maxPrecis = -1;

            //Balise.InclinaisonFace = Config.CurrentConfig.GetCourseFaceMin(Balise.Carte);
            //Thread.Sleep(300);
            valeurs = Balise.ParcourirAxeFace(3, minLarge, Config.CurrentConfig.GetCourseFaceMax(Balise.Carte), false, true);

            for (int i = 0; i < valeurs.Count; i++)
                if (valeurs[i] != 0)
                {
                    if (minPrecis == -1)
                        minPrecis = minLarge + i * 3;
                    maxPrecis = minLarge + i * 3;
                }

            int position = ((maxPrecis + minPrecis) / 2);
            Balise.InclinaisonFace = position - 10;
            Thread.Sleep(300);
            Balise.InclinaisonFace = position;
            Thread.Sleep(1000);
            Balise.InclinaisonFace = 0;*/
        }

        private void btnCourseProfil_Click(object sender, EventArgs e)
        {
            /*List<double> valeurs = Balise.ParcourirAxeProfil((int)numPasFace.Value);

            ctrlGraphique.SupprimerCourbe("Face");
            ctrlGraphique.SupprimerCourbe("Profil");
            foreach (double d in valeurs)
                ctrlGraphique.AjouterPoint("Profil", d, Color.Green);

            ctrlGraphique.DessineCourbes();*/
        }

        Thread thAssiette;

        private void CalibrationAssiette()
        {
            DateTime debut = DateTime.Now;
            Balise.ReglerAssiette();
            Console.WriteLine((DateTime.Now - debut).TotalSeconds + " secondes calibration assiette");
        }

        private void btnAutocalibTout_Click(object sender, EventArgs e)
        {
            thAssiette = new Thread(CalibrationAssiette);
            thAssiette.Start();
        }

        private void btnStopFace_Click(object sender, EventArgs e)
        {
            Balise.InclinaisonFace = 0;
        }

        private void btnStopProfil_Click(object sender, EventArgs e)
        {
            Balise.InclinaisonProfil = 0;
        }

        private void btnAutocalibFace_Click(object sender, EventArgs e)
        {
            Balise.ReglerAssietteFace();
        }

        private void btnAutocalibProfil_Click(object sender, EventArgs e)
        {
            Balise.ReglerAssietteProfil();
        }

        private void btnResetAngle_Click(object sender, EventArgs e)
        {
            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
            {
                switch (Balise.Carte)
                {
                    case Carte.RecBun:
                        Config.CurrentConfig.OffsetBaliseDroiteJaune1Capteur1 = balise.OffsetDefaut(1);
                        Config.CurrentConfig.OffsetBaliseDroiteJaune1Capteur2 = balise.OffsetDefaut(2);
                        break;
                    case Carte.RecBeu:
                        Config.CurrentConfig.OffsetBaliseDroiteJaune2Capteur1 = balise.OffsetDefaut(1);
                        Config.CurrentConfig.OffsetBaliseDroiteJaune2Capteur2 = balise.OffsetDefaut(2);
                        break;
                    case Carte.RecBoi:
                        Config.CurrentConfig.OffsetBaliseDroiteJaune3Capteur1 = balise.OffsetDefaut(1);
                        Config.CurrentConfig.OffsetBaliseDroiteJaune3Capteur2 = balise.OffsetDefaut(2);
                        break;
                }
            }
            else
            {
                switch (Balise.Carte)
                {
                    case Carte.RecBun:
                        Config.CurrentConfig.OffsetBaliseGaucheRouge1Capteur1 = balise.OffsetDefaut(1);
                        Config.CurrentConfig.OffsetBaliseGaucheRouge1Capteur2 = balise.OffsetDefaut(2);
                        break;
                    case Carte.RecBeu:
                        Config.CurrentConfig.OffsetBaliseGaucheRouge2Capteur1 = balise.OffsetDefaut(1);
                        Config.CurrentConfig.OffsetBaliseGaucheRouge2Capteur2 = balise.OffsetDefaut(2);
                        break;
                    case Carte.RecBoi:
                        Config.CurrentConfig.OffsetBaliseGaucheRouge3Capteur1 = balise.OffsetDefaut(1);
                        Config.CurrentConfig.OffsetBaliseGaucheRouge3Capteur2 = balise.OffsetDefaut(2);
                        break;
                }
            }
        }
    }
}
