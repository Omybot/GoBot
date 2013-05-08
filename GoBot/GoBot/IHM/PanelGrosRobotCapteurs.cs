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
    public partial class PanelGrosRobotCapteurs : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelGrosRobotCapteurs()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupBoxCap.Height;
            tailleMin = 39;
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupBoxCap.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupBoxCap.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupBoxCap.Height = tailleMin;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxCap.Controls)
                    c.Visible = true;

                groupBoxCap.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.CapteursGROuvert = deployer;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.CapteursGROuvert);

            timerPresence = new System.Timers.Timer(100);
            timerPresence.Elapsed += new System.Timers.ElapsedEventHandler(timerBalle_Elapsed);
            timerCouleur = new System.Timers.Timer(100);
            timerCouleur.Elapsed += new System.Timers.ElapsedEventHandler(timerCouleur_Elapsed);
            timerAssiette = new System.Timers.Timer(100);
            timerAssiette.Elapsed += new System.Timers.ElapsedEventHandler(timerAssiette_Elapsed);
            timerAspiRemonte = new System.Timers.Timer(100);
            timerAspiRemonte.Elapsed += new System.Timers.ElapsedEventHandler(timerAspiRemonte_Elapsed);
            timerVitesseCanon = new System.Timers.Timer(500);
            timerVitesseCanon.Elapsed += new System.Timers.ElapsedEventHandler(timerVitesseCanon_Elapsed);

            ledPresence.CouleurGris();
            ledAssiette.CouleurGris();
            ledAspi.CouleurGris();
        }

        System.Timers.Timer timerPresence;
        private void boxBalle_CheckedChanged(object sender, EventArgs e)
        {
            if (boxBalle.Checked)
                timerPresence.Start();
            else
            {
                ledPresence.CouleurGris();
                timerPresence.Stop();
            }
        }

        void timerBalle_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    if (Robots.GrosRobot.GetPresenceBalle(false))
                        ledPresence.CouleurVert();
                    else
                        ledPresence.CouleurRouge();
                }));
        }

        System.Timers.Timer timerCouleur;
        private void boxCouleur_CheckedChanged(object sender, EventArgs e)
        {
            if (boxCouleur.Checked)
                timerCouleur.Start();
            else
                timerCouleur.Stop();
        }

        void timerCouleur_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                Color couleur = Robots.GrosRobot.GetCouleurBalle(false);

                if (couleur == Plateau.CouleurJ1R)
                {
                    ledCouleur.Visible = true;
                    ledCouleur.CouleurBleu();
                }
                else if (couleur == Plateau.CouleurJ2B)
                {
                    ledCouleur.Visible = true;
                    ledCouleur.CouleurRouge();
                }
                else if (couleur == Color.White)
                {
                    ledCouleur.Visible = true;
                    ledCouleur.CouleurGris();
                }
                else
                    ledCouleur.Visible = false;

            }));
        }

        System.Timers.Timer timerAssiette;
        private void boxAssiette_CheckedChanged(object sender, EventArgs e)
        {
            if (boxAssiette.Checked)
                timerAssiette.Start();
            else
            {
                timerAssiette.Stop();
                ledAssiette.CouleurGris();
            }
        }

        void timerAssiette_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Robots.GrosRobot.GetPresenceAssiette(false))
                    ledAssiette.CouleurVert();
                else
                    ledAssiette.CouleurRouge();
            }));
        }

        System.Timers.Timer timerAspiRemonte;
        private void boxAspiRemonte_CheckedChanged(object sender, EventArgs e)
        {
            if (boxAspiRemonte.Checked)
                timerAspiRemonte.Start();
            else
            {
                timerAspiRemonte.Stop();
                ledAspi.CouleurGris();
            }
        }

        void timerAspiRemonte_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Robots.GrosRobot.GetAspiRemonte(false))
                    ledAspi.CouleurVert();
                else
                    ledAspi.CouleurRouge();
            }));
        }

        System.Timers.Timer timerVitesseCanon;
        private void boxVitesseCanon_CheckedChanged(object sender, EventArgs e)
        {
            if (boxVitesseCanon.Checked)
                timerVitesseCanon.Start();
            else
                timerVitesseCanon.Stop();
        }

        void timerVitesseCanon_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                lblVitesseCanon.Text = Robots.GrosRobot.GetVitesseCanon(false) + " t/min";
            }));
        }
    }
}
