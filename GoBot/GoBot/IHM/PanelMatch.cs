using GoBot.Threading;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelMatch : UserControl
    {
        private ThreadLink _linkCalibration;

        public PanelMatch()
        {
            InitializeComponent();
            btnJoueurDroite.BackColor = Plateau.CouleurDroiteOrange;
            btnJoueurGauche.BackColor = Plateau.CouleurGaucheVert;

            if (!Execution.DesignMode)
            {
                Dessinateur.TableDessinee += Dessinateur_TableDessinee;
            }
        }

        void Dessinateur_TableDessinee(Image img)
        {
            pictureBoxTable.Image = img;
        }
        public void AfficherTable(Image img)
        {
            pictureBoxTable.Image = img;
        }

        private void btnCouleurJoueurDroite_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurDroiteOrange;
        }

        private void btnCouleurJoueurGauche_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurGaucheVert;
        }

        public void CouleurGauche()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurGaucheVert;
        }

        public void CouleurDroite()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurDroiteOrange;
        }
        
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            if (!Robots.GrosRobot.GetJack())
            {
                MessageBox.Show("Jack absent !" + Environment.NewLine + "Jack nécessaire avant de commencer à recaller.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _linkCalibration = ThreadManager.StartThread(link => PositionCalibration());
            }
        }

        /// <summary>
        /// Première partie du recallage : Le robot doit terminer dans une position connue pour la calibration des balises
        /// </summary>
        public void PositionCalibration()
        {
            // Recallage du gros robot

            _linkCalibration?.RegisterName();

            this.InvokeAuto(() => ledRecallageGros.Color = Color.DarkOrange);

            Recallages.RecallageGrosRobot();

            this.InvokeAuto(() => ledRecallageGros.Color = Color.LimeGreen);
        }

        void Plateau_NotreCouleurChange(object sender, EventArgs e)
        {
            this.InvokeAuto(() =>
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                    CouleurGauche();
                else if (Plateau.NotreCouleur == Plateau.CouleurDroiteOrange)
                    CouleurDroite();
            });
        }

        private void btnArmerJack_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ArmerJack();
            ledJackArme.Color = Color.LimeGreen;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Repasser toutes les leds à rouge et couper tous les threads en train de tourner

            ledRecallageGros.Color = Color.Red;

            if (_linkCalibration != null && _linkCalibration.Running)
                _linkCalibration.Kill();

            Thread.Sleep(100);
            Robots.GrosRobot.Stop(StopMode.Smooth);
        }

        private void PanelMatch_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                Plateau.NotreCouleurChange += new EventHandler(Plateau_NotreCouleurChange);

                if (Plateau.NotreCouleur == Plateau.CouleurDroiteOrange)
                    CouleurDroite();
                else
                    CouleurGauche();
            }
        }

        private void boxHomologtion_CheckedChanged(object sender, EventArgs e)
        {
            if (boxHomologtion.Checked)
            {
                Plateau.Strategy = new Strategies.StrategyMinimumScore();
            }
            else
                Plateau.Strategy = null;
        }

        private void boxAR_CheckedChanged(object sender, EventArgs e)
        {
            if (boxAR.Checked)
                Plateau.Strategy = new Strategies.StrategyRoundTrip();
            else
                Plateau.Strategy = null;
        }
    }
}
