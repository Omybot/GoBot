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
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxSeq.Controls)
                    c.Visible = true;

                groupBoxSeq.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
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
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, Config.CurrentConfig.VitessePropulsionBonne);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
            Thread.Sleep(1300);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 70);
            Thread.Sleep(200);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
            Thread.Sleep(00);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
            Thread.Sleep(500);

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

        private void LancerBalles()
        {
            DateTime debut = DateTime.Now;
            bool balle = true;
            while (balle)
            {
                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                Thread.Sleep(350);
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
                        Robots.GrosRobot.PivotGauche(10);
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                        Thread.Sleep(250);
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                        Robots.GrosRobot.PivotDroite(10);
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
    }
}
