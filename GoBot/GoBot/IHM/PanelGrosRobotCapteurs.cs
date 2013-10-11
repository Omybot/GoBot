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

        public PanelGrosRobotCapteurs()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;
            groupBoxCapteurs.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxCapteurs_Deploiement);
        }

        void groupBoxCapteurs_Deploiement(bool deploye)
        {
            Config.CurrentConfig.CapteursGROuvert = deploye;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            ledPresence.CouleurGris();
            ledAssiette.CouleurGris();
            ledAspi.CouleurGris();
            ledJack.CouleurGris();
            ledCouleur.CouleurGris();

            groupBoxCapteurs.Deployer(Config.CurrentConfig.CapteursGROuvert, false);

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
            timerJack = new System.Timers.Timer(100);
            timerJack.Elapsed += new System.Timers.ElapsedEventHandler(timerJack_Elapsed);

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

                if (couleur == Plateau.CouleurJ1Rouge)
                {
                    ledCouleur.Visible = true;
                    ledCouleur.CouleurBleu();
                }
                else if (couleur == Plateau.CouleurJ2Jaune)
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

        System.Timers.Timer timerJack;
        private void boxJack_CheckedChanged(object sender, EventArgs e)
        {
            if (boxJack.Checked)
                timerJack.Start();
            else
            {
                timerJack.Stop();
                ledJack.CouleurGris();
            }
        }

        void timerJack_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Robots.GrosRobot.GetJack(false))
                    ledJack.CouleurVert();
                else
                    ledJack.CouleurRouge();
            }));
        }
    }
}
