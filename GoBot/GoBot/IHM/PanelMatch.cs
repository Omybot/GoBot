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

            if (!Config.DesignMode)
            {
                Plateau.Balise1.FinAsservissement += Balise1_FinAsservissement;
                Plateau.Balise2.FinAsservissement += Balise2_FinAsservissement;
                Plateau.Balise3.FinAsservissement += Balise3_FinAsservissement;

                Plateau.Balise1.RotationChange += Balise1_RotationChange;
                Plateau.Balise2.RotationChange += Balise2_RotationChange;
                Plateau.Balise3.RotationChange += Balise3_RotationChange;

                Plateau.Balise1.CalibrationAngulaireTerminee += Balise1_CalibrationAngulaireTerminee;
                Plateau.Balise2.CalibrationAngulaireTerminee += Balise2_CalibrationAngulaireTerminee;
                Plateau.Balise3.CalibrationAngulaireTerminee += Balise3_CalibrationAngulaireTerminee;

                Plateau.Balise1.CalibrationAssietteTerminee += Balise1_CalibrationAssietteTerminee;
                Plateau.Balise2.CalibrationAssietteTerminee += Balise2_CalibrationAssietteTerminee;
                Plateau.Balise3.CalibrationAssietteTerminee += Balise3_CalibrationAssietteTerminee;

                Dessinateur.TableDessinee += Dessinateur_TableDessinee;
            }
        }

        void Dessinateur_TableDessinee(Image img)
        {
            pictureBoxTable.Image = img;
        }

        void Balise1_RotationChange(bool rotation)
        {
            if (!rotation)
                ledBalise1Rotation.CouleurRouge(true);
            else
                ledBalise1Rotation.CouleurOrange();
        }

        void Balise2_RotationChange(bool rotation)
        {
            if (!rotation)
                ledBalise2Rotation.CouleurRouge(true);
            else
                ledBalise2Rotation.CouleurOrange();
        }

        void Balise3_RotationChange(bool rotation)
        {
            if (!rotation)
                ledBalise3Rotation.CouleurRouge(true);
            else
                ledBalise3Rotation.CouleurOrange();
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
                ledBalise1Angle.CouleurOrange();
                angleAuto1 = false;
                Plateau.Balise1.ReglerOffset(16);
            }
        }
        void Balise2_CalibrationAssietteTerminee()
        {
            ledBalise2Assiette.CouleurVert();

            if (angleAuto2)
            {
                ledBalise2Angle.CouleurOrange();
                angleAuto2 = false;
                Plateau.Balise2.ReglerOffset(16);
            }
        }
        void Balise3_CalibrationAssietteTerminee()
        {
            ledBalise3Assiette.CouleurVert();

            if (angleAuto3)
            {
                ledBalise3Angle.CouleurOrange();
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

        void Balise1_FinAsservissement()
        {
            ledBalise1Rotation.CouleurVert();
            if (assietteAuto1)
            {
                assietteAuto1 = false;
                thAssiette1 = new Thread(ThreadAssiette);
                thAssiette1.Start(Plateau.Balise1);
            }
        }

        void Balise2_FinAsservissement()
        {
            ledBalise2Rotation.CouleurVert();
            if (assietteAuto2)
            {
                assietteAuto2 = false;
                thAssiette2 = new Thread(ThreadAssiette);
                thAssiette2.Start(Plateau.Balise2);
            }
        }

        void Balise3_FinAsservissement()
        {
            ledBalise3Rotation.CouleurVert();
            if (assietteAuto3)
            {
                assietteAuto3 = false;
                thAssiette3 = new Thread(ThreadAssiette);
                thAssiette3.Start(Plateau.Balise3);
            }
        }

        Thread thAssiette1, thAssiette2, thAssiette3;

        private void ThreadAssiette(Object o)
        {
            Balise balise = (Balise)o;

            // Pause pour laisser la balise commencer à tourner tranquillement
            Thread.Sleep(1000);
            switch (balise.Carte)
            {
                case Carte.RecBun:
                    ledBalise1Assiette.CouleurOrange();
                    break;
                case Carte.RecBeu:
                    ledBalise2Assiette.CouleurOrange();
                    break;
                case Carte.RecBoi:
                    ledBalise3Assiette.CouleurOrange();
                    break;
            }

            balise.ReglerAssiette();

            switch (balise.Carte)
            {
                case Carte.RecBun:
                    ledBalise1Assiette.CouleurVert();
                    break;
                case Carte.RecBeu:
                    ledBalise2Assiette.CouleurVert();
                    break;
                case Carte.RecBoi:
                    ledBalise3Assiette.CouleurVert();
                    break;
            }
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

        Thread thRecallageGros;
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            if (!Robots.GrosRobot.GetJack(false))
            {
                MessageBox.Show("Jack absent !" + Environment.NewLine + "Jack nécessaire avant de commencer à recaller.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            thRecallageGros = new Thread(RecallagesGros);
            thRecallageGros.Start();

            if (boxPetit.Checked)
            {
                thRecallagePetit = new Thread(RecallagePetit);
                thRecallagePetit.Start();
            }
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

            Recallages.RecallageGrosRobot(boxPetit.Checked);

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
            assietteAuto1 = boxCalibrationAssiette.Checked;
            assietteAuto2 = boxCalibrationAssiette.Checked;
            assietteAuto3 = boxCalibrationAssiette.Checked;
            angleAuto1 = boxCalibrationAngulaire.Checked;
            angleAuto2 = boxCalibrationAngulaire.Checked;
            angleAuto3 = boxCalibrationAngulaire.Checked;

            Plateau.Balise1.ReglageVitessePermanent = false;
            Plateau.Balise2.ReglageVitessePermanent = false;
            Plateau.Balise3.ReglageVitessePermanent = false;

            Plateau.Balise1.Lancer(4);
            Plateau.Balise2.Lancer(4);
            Plateau.Balise3.Lancer(4);

            timerFinAsserBalise = new System.Windows.Forms.Timer();
            timerFinAsserBalise.Interval = 3000;
            timerFinAsserBalise.Tick += new EventHandler(timerFinAsserBalise_Tick);
            timerFinAsserBalise.Start();
        }

        void timerFinAsserBalise_Tick(object sender, EventArgs e)
        {
            bool toutesLancees = true;

            if (Plateau.Balise1.EnRotation && Plateau.Balise1.ReglageVitesse)
            {
                Plateau.Balise1.ReglageVitesse = false;
                Console.WriteLine("Balise 1 bien lancée, coupure asservissement manuel");
            }
            else
            {
                Plateau.Balise1.VitesseRotation(2400);
                toutesLancees = false;
                Console.WriteLine("Balise 1 mal lancée, relance");
            }

            if (Plateau.Balise2.EnRotation && Plateau.Balise2.ReglageVitesse)
            {
                Plateau.Balise2.ReglageVitesse = false;
                Console.WriteLine("Balise 2 bien lancée, coupure asservissement manuel");
            }
            else
            {
                Plateau.Balise2.VitesseRotation(2400);
                toutesLancees = false;
                Console.WriteLine("Balise 2 mal lancée, relance");
            }

            if (Plateau.Balise3.EnRotation && Plateau.Balise3.ReglageVitesse)
            {
                Plateau.Balise3.ReglageVitesse = false;
                Console.WriteLine("Balise 3 bien lancée, coupure asservissement manuel");
            }
            else
            {
                Plateau.Balise3.VitesseRotation(2400);
                toutesLancees = false;
                Console.WriteLine("Balise 3 mal lancée, relance");
            }

            if (toutesLancees)
                timerFinAsserBalise.Stop();
        }

        System.Windows.Forms.Timer timerFinAsserBalise;

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

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Repasser toutes les leds à rouge et couper tous les threads en train de tourner

            ledBalise1Angle.CouleurRouge();
            ledBalise2Angle.CouleurRouge();
            ledBalise3Angle.CouleurRouge();
            ledBalise1Assiette.CouleurRouge();
            ledBalise2Assiette.CouleurRouge();
            ledBalise3Assiette.CouleurRouge();
            ledBalise1Rotation.CouleurRouge();
            ledBalise2Rotation.CouleurRouge();
            ledBalise3Rotation.CouleurRouge();
            ledRecallageGros.CouleurRouge();
            ledRecallagePetit.CouleurRouge();

            if (thRecallageGros != null && thRecallageGros.IsAlive)
                thRecallageGros.Abort();

            Thread.Sleep(100);
            Robots.GrosRobot.Stop(StopMode.Smooth);
            Robots.PetitRobot.Stop(StopMode.Smooth);
        }

        private void btnBalise1_Click(object sender, EventArgs e)
        {
            if(thAssiette1 != null && thAssiette1.IsAlive)
                thAssiette1.Abort();

            while (thAssiette1 != null && thAssiette1.IsAlive)
                Thread.Sleep(100);

            Plateau.Balise1.ReglageOffset = false;
            Plateau.Balise1.InclinaisonFace = Config.CurrentConfig.CourseBunFaceOpti;
            Thread.Sleep(100);
            Plateau.Balise1.InclinaisonProfil = Config.CurrentConfig.CourseBunProfilOpti;

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
            {
                Config.CurrentConfig.OffsetBaliseDroiteJaune1Capteur1 = Plateau.Balise1.OffsetDefaut(1);
                Config.CurrentConfig.OffsetBaliseDroiteJaune1Capteur2 = Plateau.Balise1.OffsetDefaut(2);
            }
            else
            {
                Config.CurrentConfig.OffsetBaliseGaucheRouge1Capteur1 = Plateau.Balise1.OffsetDefaut(1);
                Config.CurrentConfig.OffsetBaliseGaucheRouge1Capteur2 = Plateau.Balise1.OffsetDefaut(2);
            }
        }

        private void btnBalise2_Click(object sender, EventArgs e)
        {
            if (thAssiette2 != null && thAssiette2.IsAlive)
                thAssiette2.Abort();

            while (thAssiette2 != null && thAssiette2.IsAlive)
                Thread.Sleep(100);

            Plateau.Balise2.ReglageOffset = false;
            Plateau.Balise2.InclinaisonFace = Config.CurrentConfig.CourseBeuFaceOpti;
            Thread.Sleep(100);
            Plateau.Balise2.InclinaisonProfil = Config.CurrentConfig.CourseBeuProfilOpti;

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
            {
                Config.CurrentConfig.OffsetBaliseDroiteJaune2Capteur1 = Plateau.Balise2.OffsetDefaut(1);
                Config.CurrentConfig.OffsetBaliseDroiteJaune2Capteur2 = Plateau.Balise2.OffsetDefaut(2);
            }
            else
            {
                Config.CurrentConfig.OffsetBaliseGaucheRouge2Capteur1 = Plateau.Balise2.OffsetDefaut(1);
                Config.CurrentConfig.OffsetBaliseGaucheRouge2Capteur2 = Plateau.Balise2.OffsetDefaut(2);
            }
        }

        private void btnBalise3_Click(object sender, EventArgs e)
        {
            if (thAssiette3 != null && thAssiette3.IsAlive)
                thAssiette3.Abort();

            while (thAssiette3 != null && thAssiette3.IsAlive)
                Thread.Sleep(100);

            Plateau.Balise3.ReglageOffset = false;
            Plateau.Balise3.InclinaisonFace = Config.CurrentConfig.CourseBoiFaceOpti;
            Thread.Sleep(100);
            Plateau.Balise3.InclinaisonProfil = Config.CurrentConfig.CourseBoiProfilOpti;

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
            {
                Config.CurrentConfig.OffsetBaliseDroiteJaune3Capteur1 = Plateau.Balise3.OffsetDefaut(1);
                Config.CurrentConfig.OffsetBaliseDroiteJaune3Capteur2 = Plateau.Balise3.OffsetDefaut(2);
            }
            else
            {
                Config.CurrentConfig.OffsetBaliseGaucheRouge3Capteur1 = Plateau.Balise3.OffsetDefaut(1);
                Config.CurrentConfig.OffsetBaliseGaucheRouge3Capteur2 = Plateau.Balise3.OffsetDefaut(2);
            }
        }
    }
}
