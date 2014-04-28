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

            Balise.InclinaisonFace = Config.CurrentConfig.GetCourseFaceMin(Balise.Carte);
            valeurs = Balise.ParcourirAxeFace(3, minLarge, Config.CurrentConfig.GetCourseFaceMax(Balise.Carte), false, true);

            for (int i = 0; i < valeurs.Count; i++)
                if (valeurs[i] != 0)
                {
                    if (minPrecis == -1)
                        minPrecis = minLarge + i * 3;
                    maxPrecis = minLarge + i * 3;
                }

            int position = ((maxPrecis + minPrecis) / 2);
            Balise.InclinaisonFace = Config.CurrentConfig.GetCourseFaceMin(Balise.Carte);
            Thread.Sleep(500);
            Balise.InclinaisonFace = position;
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
    }
}
