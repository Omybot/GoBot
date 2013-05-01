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
    public partial class PanelSequencesGros : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelSequencesGros()
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

        private void btnAspiration_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.AspirerBalles();
        }

        private void btnPropulsion_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.EjecterBalles();
        }

        private void btnCerises_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.AspirerVitesse(Config.CurrentConfig.VitesseAspiration);
            Robots.GrosRobot.CanonVitesse(Config.CurrentConfig.VitessePropulsionBonne);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
            Thread.Sleep(1500);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
            Thread.Sleep(1500);
            Robots.GrosRobot.AspirerVitesse(0);
            Thread.Sleep(1500);
            bool balle = true;

            while(balle)
            {
                Robots.GrosRobot.Shutter(true);
                Thread.Sleep(350);
                Robots.GrosRobot.Shutter(false);
                Thread.Sleep(600);

                if (!Robots.GrosRobot.PresenceBalle())
                {
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                    if (!Robots.GrosRobot.PresenceBalle())
                    {
                        Robots.GrosRobot.AspirerVitesse(Config.CurrentConfig.VitesseAspiration);
                        Thread.Sleep(600);
                        Robots.GrosRobot.AspirerVitesse(0);
                        Thread.Sleep(1200);

                        if (!Robots.GrosRobot.PresenceBalle())
                        {
                            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                            Thread.Sleep(500);
                            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                            if (!Robots.GrosRobot.PresenceBalle())
                                balle = false;
                        }
                    }
                }
            }
            Robots.GrosRobot.CanonVitesse(0);
        }

        private void btnCerise1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, 250);
            Thread.Sleep(500);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, 550);
            Thread.Sleep(500);
            Robots.GrosRobot.Shutter(true);
            Thread.Sleep(300);
            Robots.GrosRobot.Shutter(false);
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.SequencesGROuvert);
        }
    }
}
