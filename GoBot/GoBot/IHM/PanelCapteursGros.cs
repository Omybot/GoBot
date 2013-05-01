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
    public partial class PanelCapteursGros : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelCapteursGros()
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

            ledPresence.CouleurGris();
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
                    if (Robots.GrosRobot.PresenceBalle())
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
                lblCouleur.Text = Robots.GrosRobot.CouleurBalle();
            }));
        }
    }
}
