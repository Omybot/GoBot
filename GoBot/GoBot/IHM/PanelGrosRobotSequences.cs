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
    public partial class PanelGrosRobotSequences : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelGrosRobotSequences()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupBoxSeq.Height;
            tailleMin = 39;
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupBoxSeq.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupBoxSeq.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupBoxSeq.Height = tailleMin;
                btnTaille.Image = Properties.Resources.Bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxSeq.Controls)
                    c.Visible = true;

                groupBoxSeq.Height = tailleMax;
                btnTaille.Image = Properties.Resources.Haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.SequencesGROuvert = deployer;
        }

        Thread th;
        private void btnCerises_Click(object sender, EventArgs e)
        {
            th = new Thread(ThreadCerises);
            th.Start();
        }

        private void ThreadCerises()
        {
            AspirerBalles();
            LancerBalles();
        }

        private void btnCerise1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, 250);
            Thread.Sleep(500);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, 550);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
            Thread.Sleep(300);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.SequencesGROuvert);
        }

        private void btnAssiette_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Avancer(80);
            Robots.GrosRobot.PivotDroite(90);
            Robots.GrosRobot.Reculer(250);

            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, Config.CurrentConfig.VitessePropulsionBonne);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
            Thread.Sleep(1200);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 70);
            Thread.Sleep(200);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
            Thread.Sleep(1500);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);

            Robots.GrosRobot.Avancer(120);
            Robots.GrosRobot.PivotGauche(90);
            Robots.GrosRobot.Avancer(200);
            Robots.GrosRobot.PivotGauche(45);

            LancerBalles();
        }

        private bool AspirerBalles()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanonTMin, 7600);

            int distance = 50;
            // Approche d'aspiration
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);

                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Reculer(distance);
                Robots.GrosRobot.Rapide();

            // Si pas d'assiette on abandonne et on s'en va. On considère que l'assiette n'est pas ici
            if (!Robots.GrosRobot.GetPresenceAssiette())
            {
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);

                    Robots.GrosRobot.Avancer(distance);
                    return false;
            }

            bool aspirateurRemonte;
            int i = 0;
            while (i < 3)
            {
                // Remontage de l'aspirateur
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspirationMaintien);
                Thread.Sleep(300);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
                Thread.Sleep(1500);

                // Teste si l'aspirateur est bien remonté
                aspirateurRemonte = Robots.GrosRobot.GetAspiRemonte();
                if (aspirateurRemonte)
                {
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                    break;
                }

                // Repose les bougies dans l'assiette et tente de les réaspirer
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                Thread.Sleep(500);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
                Thread.Sleep(500);
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                Thread.Sleep(1500);
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                Thread.Sleep(1000);
                i++;
            }

            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
            if (i == 3)
            {
                Thread.Sleep(1500);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
            }
            Robots.GrosRobot.Avancer(distance);

            if (i == 3)
                return false;

            return true;
        }

        private void LancerBalles()
        {
            int vitesseActuelleCanon = Robots.GrosRobot.GetVitesseCanon();
            while ((vitesseActuelleCanon + 60 < 7600 || vitesseActuelleCanon - 60 > 7600))
            {
                Thread.Sleep(500);
                vitesseActuelleCanon = Robots.GrosRobot.GetVitesseCanon();
            }

            DateTime debut = DateTime.Now;
            bool balle = true;
            while (balle)
            {
                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                Thread.Sleep(500);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                if (!Robots.GrosRobot.GetPresenceBalle())
                {
                    Thread.Sleep(350);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                    Thread.Sleep(350);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                    if (!Robots.GrosRobot.GetPresenceBalle())
                    {
                        balle = false;
                    }
                }
                else
                {
                    Color couleur = Robots.GrosRobot.GetCouleurBalle();
                    Console.WriteLine(couleur);
                    if (couleur != Color.White)
                    {
                        Robots.GrosRobot.PivotGauche(15, false);
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                        Thread.Sleep(300);
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                        Robots.GrosRobot.PivotDroite(15, false);
                    }
                    else
                    {
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                        Thread.Sleep(250);
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                    }

                }
            }

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);

            Console.WriteLine((DateTime.Now - debut).TotalMilliseconds + " ms");
        }

        private void btnVerres_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitRange);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheRange);
            Robots.GrosRobot.VitesseDeplacement = 1800;
            Robots.GrosRobot.AccelerationDeplacement = 2000;
            Robots.GrosRobot.VitessePivot = 1000;
            Robots.GrosRobot.AccelerationPivot = 2000;
            Robots.GrosRobot.Avancer(1065);
            Robots.GrosRobot.PivotDroite(37.21);
            Robots.GrosRobot.Avancer(746);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitSorti);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheSorti);
            Robots.GrosRobot.PivotDroite(145.86);
            Robots.GrosRobot.Avancer(1400);

            /*Robots.GrosRobot.Avancer(80);
            Robots.GrosRobot.PivotGauche(48);
            Robots.GrosRobot.Virage(SensAR.Avant, SensGD.Droite, 1059, 103);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitSorti);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheSorti);
            Robots.GrosRobot.PivotDroite(126);
            Robots.GrosRobot.Avancer(1420);*/
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitRange);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheRange);
        }
    }
}
