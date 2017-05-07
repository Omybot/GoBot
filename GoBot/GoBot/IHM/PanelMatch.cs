using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Communications;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.Balises;
using GoBot.Actionneurs;

namespace GoBot.IHM
{
    public partial class PanelMatch : UserControl
    {
        public PanelMatch()
        {
            InitializeComponent();
            btnJoueurDroite.BackColor = Plateau.CouleurDroiteJaune;
            btnJoueurGauche.BackColor = Plateau.CouleurGaucheBleu;

            if (!Config.DesignMode)
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
            Plateau.NotreCouleur = Plateau.CouleurDroiteJaune;
        }

        private void btnCouleurJoueurGauche_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurGaucheBleu;
        }

        public void CouleurGauche()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurGaucheBleu;
        }

        public void CouleurDroite()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurDroiteJaune;
        }

        Thread thRecallageGros;
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            if (!Robots.GrosRobot.GetJack(false))
            {
                MessageBox.Show("Jack absent !" + Environment.NewLine + "Jack nécessaire avant de commencer à recaller.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            thRecallageGros = new Thread(RecallageGros);
            thRecallageGros.Start();
        }

        /// <summary>
        /// Première partie du recallage : Le robot doit terminer dans une position connue pour la calibration des balises
        /// </summary>
        public void RecallageGros()
        {
            // Recallage du gros robot

            this.Invoke(new EventHandler(delegate
            {
                ledRecallageGros.CouleurOrange();
            }));

            Recallages.RecallageGrosRobot();

            this.Invoke(new EventHandler(delegate
            {
                ledRecallageGros.CouleurVert();
            }));
        }

        void Plateau_NotreCouleurChange(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                    CouleurGauche();
                else if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                    CouleurDroite();
            }));
        }

        private void btnArmerJack_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ArmerJack();
            ledJackArme.CouleurVert();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Repasser toutes les leds à rouge et couper tous les threads en train de tourner

            ledRecallageGros.CouleurRouge();

            if (thRecallageGros != null && thRecallageGros.IsAlive)
                thRecallageGros.Abort();

            Thread.Sleep(100);
            Robots.GrosRobot.Stop(StopMode.Smooth);
        }

        private void PanelMatch_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                Plateau.NotreCouleurChange += new EventHandler(Plateau_NotreCouleurChange);

                if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                    CouleurDroite();
                else
                    CouleurGauche();
            }
        }

        private void boxHomologtion_CheckedChanged(object sender, EventArgs e)
        {
            if (boxHomologtion.Checked)
            {
                Plateau.Enchainement = new Enchainements.EnchainementHomologation();
            }
            else
                Plateau.Enchainement = null;
        }

        private void boxAR_CheckedChanged(object sender, EventArgs e)
        {
            if (boxAR.Checked)
                Plateau.Enchainement = new Enchainements.EnchainementAllerRetour();
            else
                Plateau.Enchainement = null;
        }
    }
}
