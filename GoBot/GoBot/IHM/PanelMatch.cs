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
        }

        private void btnCouleurJaune_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurJ2Jaune;
        }

        private void btnCouleurRouge_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurJ1Rouge;
        }

        public void CouleurRouge()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurJ1Rouge;
            pictureBoxBalises.Image = Properties.Resources.TableRouge;

            Balise.GetBalise(Carte.RecBun).Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBeu).Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBoi).Position = new Position(new Angle(0, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        public void CouleurBleu()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurJ2Jaune;
            pictureBoxBalises.Image = Properties.Resources.TableViolet;

            Balise.GetBalise(Carte.RecBun).Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBeu).Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            Balise.GetBalise(Carte.RecBoi).Position = new Position(new Angle(180, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));

        }

        Thread thRecallage;
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            if (!Robots.GrosRobot.GetJack(false))
            {
                MessageBox.Show("Tu lances un recallages et tu branches pas le jack ? C'est comme si t'es Omybot t'as pas de robot quoi...", "Non mais allô quoi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnRecallage.Enabled = false;
            if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
            {
                thRecallage = new Thread(RecallagesDebut);
                thRecallage.Start();
            }
            if (Connexions.ConnexionPi.ConnexionCheck.Connecte)
            {
                thRecallagePetit = new Thread(RecallagePetit);
                thRecallagePetit.Start();
            }
        }

        Thread thRecallagePetit;
        private void RecallagePetit()
        {
            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Avancer(10);
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Avancer(250);

            if (Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Thread.Sleep(1000);

            if (Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
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
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(890);

            if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Reculer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();

            Robots.GrosRobot.Avancer(1500 - Robots.GrosRobot.Longueur / 2);

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
            if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
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
                if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
                    CouleurRouge();
                else if (Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
                    CouleurBleu();
            }));
        }

        private void btnArmerJack_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ArmerJack();
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
                Connexions.ConnexionMove.SendMessage(TrameFactory.DemandeCouleurEquipe());
            }
        }
    }
}
