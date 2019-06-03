using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelReglageAsserv : UserControl
    {
        private Robot Robot { get; set; }

        public PanelReglageAsserv()
        {
            InitializeComponent();

            numCoeffP.Value = Config.CurrentConfig.GRCoeffP;
            numCoeffI.Value = Config.CurrentConfig.GRCoeffI;
            numCoeffD.Value = Config.CurrentConfig.GRCoeffD;
            this.numCoeffD.ValueChanged += new System.EventHandler(this.btnOk_Click);
            this.numCoeffI.ValueChanged += new System.EventHandler(this.btnOk_Click);
            this.numCoeffP.ValueChanged += new System.EventHandler(this.btnOk_Click);
            Robot = Robots.GrosRobot;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(link => EnvoiTestPid(link)).StartThread();
        }

        private void EnvoiTestPid(ThreadLink link)
        {
            link.RegisterName();

            Robot.EnvoyerPID((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);
            List<int>[] mesures = Robot.MesureTestPid((int)numPasCodeurs.Value, SensAR.Avant, (int)numNbPoints.Value);
            // Afficher les courbes

            int derniereValeurGauche = mesures[0][mesures[0].Count - 1];
            int derniereValeurDroite = mesures[1][mesures[1].Count - 1];

            int premiereValeurGauche = mesures[0][0];
            int premiereValeurDroite = mesures[1][0];

            for (int i = 0; i < mesures[0].Count; i++)
                mesures[0][i] = mesures[0][i] - premiereValeurGauche;
            for (int i = 0; i < mesures[1].Count; i++)
                mesures[1][i] = mesures[1][i] - premiereValeurDroite;

            if (derniereValeurGauche == 0)
                derniereValeurGauche = 1;

            if (derniereValeurDroite == 0)
                derniereValeurDroite = 1;

            double depassementGauchePositif = (mesures[0].Max() - (int)numPasCodeurs.Value) / (double)numPasCodeurs.Value * 100;
            double depassementDroitePositif = (mesures[1].Max() - (int)numPasCodeurs.Value) / (double)numPasCodeurs.Value * 100;

            int tempsGaucheStable = mesures[0].Count - 1;
            while (tempsGaucheStable > 0 && mesures[0][tempsGaucheStable] < mesures[0][mesures[0].Count - 1] * 1.05 && mesures[0][tempsGaucheStable] > mesures[0][mesures[0].Count - 1] * 0.95)
                tempsGaucheStable--;

            int tempsDroiteStable = mesures[1].Count - 1;
            while (tempsDroiteStable > 0 && mesures[1][tempsDroiteStable] < mesures[1][mesures[1].Count - 1] * 1.05 && mesures[1][tempsDroiteStable] > mesures[1][mesures[1].Count - 1] * 0.95)
                tempsDroiteStable--;

            lblTpsStabilisationGauche.Text = tempsGaucheStable + "ms";
            lblTpsStabilisationDroite.Text = tempsDroiteStable + "ms";

            lblOvershootGauche.Text = depassementGauchePositif.ToString("0.00") + "%";
            lblOvershootDroite.Text = depassementDroitePositif.ToString("0.00") + "%";

            lblValeurFinGauche.Text = mesures[0][mesures[0].Count - 1].ToString();
            lblValeurFinDroite.Text = mesures[1][mesures[1].Count - 1].ToString();

            ctrlGraphique.DeleteCurve("Roue droite");
            ctrlGraphique.DeleteCurve("Roue gauche");


            for (int i = 0; i < mesures[0].Count; i++)
            {
                if(boxMoyenne.Checked && i > 1 && i < mesures[0].Count - 2)
                {
                    double valeur = (mesures[0][i - 2] + mesures[0][i - 1] + mesures[0][i] + mesures[0][i + 1] + mesures[0][i + 2]) / 5.0;
                    ctrlGraphique.AddPoint("Roue gauche", valeur, Color.Blue);
                }
                else
                    ctrlGraphique.AddPoint("Roue gauche", mesures[0][i], Color.Blue);
            }

            for (int i = 0; i < mesures[1].Count; i++)
            {
                if (boxMoyenne.Checked && i > 1 && i < mesures[1].Count - 2)
                {
                    double valeur = (mesures[1][i - 2] + mesures[1][i - 1] + mesures[1][i] + mesures[1][i + 1] + mesures[1][i + 2]) / 5.0;
                    ctrlGraphique.AddPoint("Roue droite", valeur, Color.Green);
                }
                else
                    ctrlGraphique.AddPoint("Roue droite", mesures[1][i], Color.Green);
            }

            ctrlGraphique.DrawCurves();

            Robot.MesureTestPid((int)numPasCodeurs.Value, SensAR.Arriere, (int)numNbPoints.Value);
        }
    }
}
