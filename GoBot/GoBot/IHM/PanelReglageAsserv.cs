using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelReglageAsserv : UserControl
    {
        private Robot Robot { get; set; }

        public PanelReglageAsserv()
        {
            InitializeComponent();
        }

        private void rdoGrosRobot_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGrosRobot.Checked)
                Robot = Robots.GrosRobot;
            else
                Robot = Robots.PetitRobot;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EnvoiTestPid();
        }

        private void EnvoiTestPid()
        {
            List<int>[] mesures = Robot.MesureTestPid((int)numPasCodeurs.Value, SensAR.Avant, (int)numNbPoints.Value);
            // Afficher les courbes
            
            int derniereValeurGauche = mesures[0][mesures[0].Count - 1];
            int derniereValeurDroite = mesures[1][mesures[1].Count - 1];

            if (derniereValeurGauche == 0)
                derniereValeurGauche = 1;

            if (derniereValeurDroite == 0)
                derniereValeurDroite = 1;

            double depassementGauchePositif = (mesures[0].Max() - derniereValeurGauche) / derniereValeurGauche * 100;
            double depassementGaucheNegatif = (mesures[0].Min() - derniereValeurGauche) / derniereValeurGauche * 100;

            double depassementDroitePositif = (mesures[1].Max() - derniereValeurDroite) / derniereValeurDroite * 100;
            double depassementDroiteNegatif = (mesures[1].Min() - derniereValeurDroite) / derniereValeurDroite * 100;

            int tempsGaucheStable = mesures[0].Count - 1;
            while (tempsGaucheStable > 0 && mesures[0][tempsGaucheStable] < derniereValeurGauche * 1.05 && mesures[0][tempsGaucheStable] > derniereValeurGauche * 0.95)
                tempsGaucheStable--;

            int tempsDroiteStable = mesures[1].Count - 1;
            while (tempsDroiteStable > 0 && mesures[1][tempsDroiteStable] < derniereValeurDroite * 1.05 && mesures[1][tempsDroiteStable] > derniereValeurDroite * 0.95)
                tempsDroiteStable--;

            lblTpsStabilisationGauche.Text = tempsGaucheStable + "ms";
            lblTpsStabilisationDroite.Text = tempsDroiteStable + "ms";

            lblOvershootGauche.Text = Math.Round(depassementGauchePositif, 2) + "%";
            lblOvershootDroite.Text = Math.Round(depassementDroitePositif, 2) + "%";

            ctrlGraphique1.SupprimerCourbe("Roue droite");
            ctrlGraphique1.SupprimerCourbe("Roue gauche");

            for (int i = 0; i < mesures[0].Count; i++)
                ctrlGraphique1.AjouterPoint("Roue gauche", mesures[0][i], Color.Blue);

            for (int i = 0; i < mesures[1].Count; i++)
                ctrlGraphique1.AjouterPoint("Roue droite", mesures[1][i], Color.Green);

            ctrlGraphique1.DessineCourbes();

            Robot.MesureTestPid((int)numPasCodeurs.Value, SensAR.Arriere, (int)numNbPoints.Value);
        }
    }
}
