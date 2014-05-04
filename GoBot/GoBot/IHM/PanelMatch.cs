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

namespace GoBot.IHM
{
    public partial class PanelMatch : UserControl
    {
        public PanelMatch()
        {
            InitializeComponent();
            btnJoueurDroite.BackColor = Plateau.CouleurDroiteJaune;
            btnJoueurGauche.BackColor = Plateau.CouleurGaucheRouge;
            assietteAuto1 = assietteAuto2 = assietteAuto3 = false;
            angleAuto1 = angleAuto2 = angleAuto3 = false;

            Plateau.Balise1.RotationChange += Balise1_RotationChange;
            Plateau.Balise2.RotationChange += Balise2_RotationChange;
            Plateau.Balise3.RotationChange += Balise3_RotationChange;

            Plateau.Balise1.CalibrationAngulaireTerminee += Balise1_CalibrationAngulaireTerminee;
            Plateau.Balise2.CalibrationAngulaireTerminee += Balise2_CalibrationAngulaireTerminee;
            Plateau.Balise3.CalibrationAngulaireTerminee += Balise3_CalibrationAngulaireTerminee;

            Plateau.Balise1.CalibrationAssietteTerminee += Balise1_CalibrationAssietteTerminee;
            Plateau.Balise2.CalibrationAssietteTerminee += Balise2_CalibrationAssietteTerminee;
            Plateau.Balise3.CalibrationAssietteTerminee += Balise3_CalibrationAssietteTerminee;
        }

        public void AfficherTable(Image img)
        {
            pictureBoxTable.Image = img;
        }

        void Balise1_CalibrationAssietteTerminee()
        {
            ledBalise1Assiette.CouleurVert();

            if (angleAuto1)
            {
                angleAuto1 = false;
                Plateau.Balise1.ReglerOffset(16);
            }
        }
        void Balise2_CalibrationAssietteTerminee()
        {
            ledBalise2Assiette.CouleurVert();

            if (angleAuto2)
            {
                angleAuto2 = false;
                Plateau.Balise2.ReglerOffset(16);
            }
        }
        void Balise3_CalibrationAssietteTerminee()
        {
            ledBalise3Assiette.CouleurVert();

            if (angleAuto3)
            {
                angleAuto3 = false;
                Plateau.Balise3.ReglerOffset(16);
            }
        }

        void Balise1_CalibrationAngulaireTerminee()
        {
            ledBalise1Angle.CouleurVert();
        }
        void Balise2_CalibrationAngulaireTerminee()
        {
            ledBalise2Angle.CouleurVert();
        }
        void Balise3_CalibrationAngulaireTerminee()
        {
            ledBalise3Angle.CouleurVert();
        }

        void Balise1_RotationChange(bool rotation)
        {
            if (rotation)
            {
                ledBalise1Rotation.CouleurVert();
                if (assietteAuto1)
                {
                    assietteAuto1 = false;
                    Plateau.Balise1.ReglerAssiette();
                }
            }
            else
                ledBalise1Rotation.CouleurRouge();
        }
        void Balise2_RotationChange(bool rotation)
        {
            if (rotation)
            {
                ledBalise2Rotation.CouleurVert();
                if (assietteAuto2)
                {
                    assietteAuto2 = false;
                    Plateau.Balise2.ReglerAssiette();
                }
            }
            else
                ledBalise2Rotation.CouleurRouge();
        }
        void Balise3_RotationChange(bool rotation)
        {
            if (rotation)
            {
                ledBalise3Rotation.CouleurVert();
                if (assietteAuto3)
                {
                    assietteAuto3 = false;
                    Plateau.Balise3.ReglerAssiette();
                }
            }
            else
                ledBalise3Rotation.CouleurRouge();
        }

        private void btnCouleurJaune_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurDroiteJaune;
        }

        private void btnCouleurRouge_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurGaucheRouge;
        }

        public void CouleurGaucheRouge()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurGaucheRouge;

            pictureBoxBunRouge.Visible = true;
            pictureBoxBeuRouge.Visible = true;
            pictureBoxBoiRouge.Visible = true;

            pictureBoxBunJaune.Visible = false;
            pictureBoxBeuJaune.Visible = false;
            pictureBoxBoiJaune.Visible = false;

            Balise.GetBalise(Carte.RecBun).Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBeu).Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBoi).Position = new Position(new Angle(180, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        public void CouleurDroiteJaune()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurDroiteJaune;

            pictureBoxBunRouge.Visible = false;
            pictureBoxBeuRouge.Visible = false;
            pictureBoxBoiRouge.Visible = false;

            pictureBoxBunJaune.Visible = true;
            pictureBoxBeuJaune.Visible = true;
            pictureBoxBoiJaune.Visible = true;

            Balise.GetBalise(Carte.RecBeu).Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBun).Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBoi).Position = new Position(new Angle(0, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        Thread thRecallage;
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            if (!Robots.GrosRobot.GetJack(false))
            {
                MessageBox.Show("Jack absent !" + Environment.NewLine + "Jack nécessaire avant de commencer à recaller.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            thRecallage = new Thread(RecallagesGros);
            thRecallage.Start();
        }

        Thread thRecallagePetit;
        private void RecallagePetit()
        {
            // Recallage du gros robot

            this.Invoke(new EventHandler(delegate
            {
                ledRecallagePetit.CouleurOrange();
            }));

            Recallages.RecallagePetitRobot();

            this.Invoke(new EventHandler(delegate
            {
                ledRecallagePetit.CouleurVert();
            }));
        }

        /// <summary>
        /// Première partie du recallage : Le robot doit terminer dans une position connue pour la calibration des balises
        /// </summary>
        public void RecallagesGros()
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
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                    CouleurGaucheRouge();
                else if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                    CouleurDroiteJaune();
            }));
        }

        private void btnArmerJack_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ArmerJack();
            ledJackArme.CouleurVert();
        }

        private void radioBaliseOui_CheckedChanged(object sender, EventArgs e)
        {
            Plateau.ReflecteursNosRobots = radioBaliseOui.Checked;
        }

        private void PanelMatch_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                // Réglage rouge par défaut
                btnCouleurRouge_Click(null, null);
                Plateau.NotreCouleurChange += new EventHandler(Plateau_NotreCouleurChange);
                Connexions.ConnexionIO.SendMessage(TrameFactory.DemandeCouleurEquipe());
            }
        }

        bool assietteAuto1, assietteAuto2, assietteAuto3;
        bool angleAuto1, angleAuto2, angleAuto3;
        private void btnBalises_Click(object sender, EventArgs e)
        {
            ledBalise1Rotation.CouleurOrange();
            ledBalise2Rotation.CouleurOrange();
            ledBalise3Rotation.CouleurOrange();

            assietteAuto1 = boxCalibrationAssiette.Checked;
            assietteAuto2 = boxCalibrationAssiette.Checked;
            assietteAuto3 = boxCalibrationAssiette.Checked;
            angleAuto1 = boxCalibrationAngulaire.Checked;
            angleAuto2 = boxCalibrationAngulaire.Checked;
            angleAuto3 = boxCalibrationAngulaire.Checked;

            Plateau.Balise1.Lancer(4);
            Plateau.Balise2.Lancer(4);
            Plateau.Balise3.Lancer(4);
        }

        private void btnCalibrationAssiette_Click(object sender, EventArgs e)
        {
            // todo
        }

        private void btnCalibrationAngle_Click(object sender, EventArgs e)
        {
            ledBalise1Angle.CouleurOrange();
            ledBalise2Angle.CouleurOrange();
            ledBalise3Angle.CouleurOrange();

            Plateau.Balise1.ReglerOffset(16); // 16 mesures à 4 tours seconde ce qui fait 4 secondes de calibration
            Plateau.Balise2.ReglerOffset(16); 
            Plateau.Balise3.ReglerOffset(16); 
        }
    }
}
