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
            pictureBoxBalises.Image = Properties.Resources.PositionBalises1;

            Robots.GrosRobot.ReglerOffsetAsserv(220, 150, 180);

            Balise.GetBalise(Carte.RecBun).Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBeu).Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBoi).Position = new Position(new Angle(180, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        public void CouleurDroiteJaune()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurDroiteJaune;
            pictureBoxBalises.Image = Properties.Resources.PositionBalises2;

            Robots.GrosRobot.ReglerOffsetAsserv(3000 - 220, 150, 180);

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
            btnRecallage.Enabled = false;
            if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
            {
                thRecallage = new Thread(RecallagesDebut);
                thRecallage.Start();
            }
        }

        Thread thRecallagePetit;
        private void RecallagePetit()
        {
            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Avancer(10);
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Avancer(250);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Thread.Sleep(1000);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.PetitRobot.ReglerOffsetAsserv(Robots.PetitRobot.Longueur / 2, 1750 - Robots.PetitRobot.Longueur / 2, 0);
            else
                Robots.PetitRobot.ReglerOffsetAsserv(3000 - Robots.PetitRobot.Longueur / 2, 1750 - Robots.PetitRobot.Longueur / 2, 0);
        }

        /// <summary>
        /// Première partie du recallage : Le robot doit terminer dans une position connue pour la calibration des balises
        /// </summary>
        public void RecallagesDebut()
        {
            //panelCamera.btnCapture_Click(null, null);
            // Recallage du gros robot
            
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Reculer(10);
            Robots.GrosRobot.Recallage(SensAR.Avant);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(101);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotDroite(90);
            else
                Robots.GrosRobot.PivotGauche(90);

            Robots.GrosRobot.Reculer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(352);
            Robots.GrosRobot.PivotDroite(26);

            Robots.GrosRobot.Reculer(339);

            Robots.GrosRobot.ReglerOffsetAsserv(197, 402, 26);

            this.Invoke(new EventHandler(delegate
            {
                ledRecallage.CouleurOrange();
            }));
        }

        /// <summary>
        /// Deuxième partie du recallage : le robot doit partir de la position de recallage des balises et arriver à son point de départ du match
        /// </summary>
        private void RecallagesFin()
        {
            Robots.GrosRobot.Reculer(1450 - Robots.GrosRobot.Longueur / 2);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Thread.Sleep(1000);

            // Envoyer la position actuelle au robot afin qu'il recalle ses offsets
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.ReglerOffsetAsserv(3000 - Robots.GrosRobot.Longueur / 2, 1000, 180);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(Robots.GrosRobot.Longueur / 2, 1000, 0);

            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.ArmerJack();

            PanelCamera.ContinuerCamera = true;

            this.Invoke(new EventHandler(delegate
            {
                ledRecallage.CouleurVert();
            }));
        }

        private void btnBalises_Click(object sender, EventArgs e)
        {
            thRecallage = new Thread(RecallagesFin);
            thRecallage.Start();
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
            Robots.GrosRobot.ReglerOffsetAsserv(0, 0, 270);
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
    }
}
