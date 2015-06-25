using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Actionneurs;
using GoBot.Mouvements;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotSequences : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotSequences()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxSequences.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxSequences_Deploiement);
        }

        void groupBoxSequences_Deploiement(bool deploye)
        {
            Config.CurrentConfig.SequencesGROuvert = deploye;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            groupBoxSequences.Deployer(Config.CurrentConfig.SequencesGROuvert, false);
        }

        private void btnEmpilerDroite_Click(object sender, EventArgs e)
        {
            /*Thread th = new Thread(Actionneur.BrasPiedsDroite.Empiler);
            th.Start();*/
        }

        private void btnCleanBasGauche_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(FonctionBasGauche);
            th.Start();
        }

        public void FonctionBasGauche()
        {
            Robots.GrosRobot.GotoXYTeta(437, 1483, 138.85);
            Robots.GrosRobot.Avancer(193);
            Actionneur.BrasPiedsGauche.FermerPinceBas();
            Thread.Sleep(200);

            Robots.GrosRobot.Lent();

            Robots.GrosRobot.PivotGauche(12.17);
            Robots.GrosRobot.Avancer(109);
            Actionneur.BrasPiedsDroite.Empiler();

            Robots.GrosRobot.PivotGauche(17.34);
            Robots.GrosRobot.Avancer(66);
            Actionneur.BrasPiedsDroite.Empiler();

            /*Robots.GrosRobot.Reculer(193);
            Robots.GrosRobot.PivotGauche(6.69);
            Robots.GrosRobot.Avancer(308);
            Actionneur.BrasPiedsDroite.Empiler();

            Robots.GrosRobot.PivotGauche(20.11);
            Robots.GrosRobot.Avancer(58);
            Actionneur.BrasPiedsDroite.Empiler();*/
        }

        private void btnDebutMatch_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Robots.GrosRobot.Rayon + "");
            Thread th = new Thread(FonctionDebutMatch);
            th.Start();
        }

        public void FonctionDebutMatch()
        {
            Robots.GrosRobot.VitesseDeplacement = 1000;
            Robots.GrosRobot.AccelerationDebutDeplacement = 2000;

            Actionneur.BrasAmpoule.Fermer();
            Thread.Sleep(250);
            Actionneur.BrasAmpoule.Monter();

            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();

            Robots.GrosRobot.PivotGauche(7.76);

            Robots.GrosRobot.AccelerationFinDeplacement /= 3;
            Robots.GrosRobot.Avancer(570);

            //Robots.GrosRobot.Avancer(500);
            //Robots.GrosRobot.Lent();
            //Robots.GrosRobot.Avancer(70);

            Robots.GrosRobot.Rapide();
            Actionneur.BrasPiedsGauche.FermerPinceBas();
            Thread.Sleep(200);
            Actionneur.BrasPiedsGauche.SouleverLegerement();
            Thread.Sleep(50);

            Robots.GrosRobot.GotoXYTeta(772, 763, -90);
            Robots.GrosRobot.Avancer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(60);
            Actionneur.BrasPiedsDroite.Empiler();
            Thread.Sleep(200);
            Robots.GrosRobot.Avancer(90);
            Actionneur.BrasPiedsDroite.Empiler();
            Robots.GrosRobot.Rapide();

            Mouvements.MouvementDistributeur move1 = new Mouvements.MouvementDistributeur(0);
            move1.Executer();
            Mouvements.MouvementPied move = new Mouvements.MouvementPied(0);
            move.Executer();
            move = new Mouvements.MouvementPied(5);
            move.Executer();

            Robots.GrosRobot.GotoXYTeta(355, 1001, 180);
            Actionneur.BrasPiedsGauche.AscenseurDescendre();
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
            Actionneur.BrasPiedsDroite.Deverrouiller();
            Actionneur.BrasPiedsGauche.Deverrouiller();

            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(280);
            Actionneur.BrasAspirateur.Maintenir();
            Robots.GrosRobot.PivotDroite(180);
            Actionneur.BrasAspirateur.PositionDepose();
            Robots.GrosRobot.PivotDroite(60);

            Actionneur.BrasAspirateur.Arreter();

            Actionneur.BrasPiedsDroite.Verrouiller();
            Actionneur.BrasPiedsGauche.Verrouiller();
        }

        private void btnEmpilerGauche_Click(object sender, EventArgs e)
        {
            /*Thread th = new Thread(Actionneur.BrasPiedsGauche.Empiler);
            th.Start();*/
        }

        private void btnDebutMatchGauche_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(DebutMatchGauche);
            th.Start();
        }

        private void DebutMatchGauche()
        {

            Robots.GrosRobot.VitesseDeplacement = 1000;
            Robots.GrosRobot.AccelerationDebutDeplacement = 2000;

            Actionneur.BrasAmpoule.Fermer();
            Thread.Sleep(250);
            Actionneur.BrasAmpoule.Monter();

            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            //Actionneur.BrasPiedsGauche.OuvrirPinceHaut();

            Robots.GrosRobot.PivotDroite(7.76);
            Robots.GrosRobot.Avancer(500);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(70);
            Robots.GrosRobot.Rapide();
            Actionneur.BrasPiedsDroite.FermerPinceBas();
            Thread.Sleep(200);
            Actionneur.BrasPiedsDroite.SouleverLegerement();
            Thread.Sleep(50);

            Robots.GrosRobot.GotoXYTeta(3000 - 772, 763, -90);
            Robots.GrosRobot.Avancer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(60);
            Actionneur.BrasPiedsGauche.Empiler();
            Thread.Sleep(200);
            Robots.GrosRobot.Avancer(90);
            Actionneur.BrasPiedsGauche.Empiler();
            Robots.GrosRobot.Rapide();

            Mouvements.MouvementPied move = new Mouvements.MouvementPied(13);
            move.Executer();
            move = new Mouvements.MouvementPied(5);
            move.Executer();

            Robots.GrosRobot.GotoXYTeta(3000 - 355, 1001, 180);
            Actionneur.BrasPiedsDroite.AscenseurDescendre();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.Deverrouiller();
            Actionneur.BrasPiedsDroite.Deverrouiller();

            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(280);
            Actionneur.BrasAspirateur.Maintenir();
            Robots.GrosRobot.PivotDroite(180);
            Actionneur.BrasAspirateur.PositionDepose();
            Robots.GrosRobot.PivotDroite(60);

            Actionneur.BrasAspirateur.Arreter();

            Actionneur.BrasPiedsGauche.Verrouiller();
            Actionneur.BrasPiedsDroite.Verrouiller();

            /*
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();

            Robots.GrosRobot.PivotDroite(7.76);
            Robots.GrosRobot.Avancer(500);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(64);
            Robots.GrosRobot.Rapide();
            Actionneur.BrasPiedsDroite.FermerPinceBas();
            Thread.Sleep(200);

            Robots.GrosRobot.GotoXYTeta(3000 - 772, 763, -90);
            Robots.GrosRobot.Avancer(390);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(50);
            Actionneur.BrasPiedsGauche.Empiler();
            Robots.GrosRobot.Avancer(100);
            Actionneur.BrasPiedsGauche.Empiler();*/
        }

        private void btnBasTableGauche_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(BasTableGauche2);
            th.Start();
        }

        private void BasTableGauche2()
        {
            Robots.GrosRobot.GotoXYTeta(3000 - 437, 1483, 180-138.85);
            Robots.GrosRobot.Avancer(193);
            Actionneur.BrasPiedsDroite.FermerPinceBas();
            Thread.Sleep(200);

            Robots.GrosRobot.Lent();

            Robots.GrosRobot.PivotDroite(12.17);
            Robots.GrosRobot.Avancer(109);
            Actionneur.BrasPiedsGauche.Empiler();

            Robots.GrosRobot.PivotDroite(17.34);
            Robots.GrosRobot.Avancer(66);
            Actionneur.BrasPiedsGauche.Empiler();
        }

        private void btnDeposeTapisDroit_Click(object sender, EventArgs e)
        {
            Actionneur.BrasTapis.PoserTapisDroit();
        }

        private void btnDeposeTapisGauche_Click(object sender, EventArgs e)
        {
            Actionneur.BrasTapis.PoserTapisGauche();
        }

        Thread thDroit;
        Thread thGauche;
        private void btnEmpileTout_Click(object sender, EventArgs e)
        {
            thDroit = new Thread(EmpileDroit);
            thGauche = new Thread(EmpileGauche);

            thDroit.Start();
            thGauche.Start();
        }

        private void EmpileGauche()
        {
            Actionneur.BrasPiedsDroite.Empiler();
            Actionneur.BrasPiedsDroite.Empiler();
            Actionneur.BrasPiedsDroite.Empiler();
            Actionneur.BrasPiedsDroite.Empiler();
            Actionneur.BrasPiedsDroite.Empiler();

            thDroit.Join();

            Robots.GrosRobot.Reculer(100);
        }

        private void EmpileDroit()
        {
            Actionneur.BrasPiedsGauche.Empiler();
            Actionneur.BrasPiedsGauche.Empiler();
            Actionneur.BrasPiedsGauche.Empiler();
            Actionneur.BrasPiedsGauche.Empiler();
            Actionneur.BrasPiedsGauche.Empiler();
        }

        private void btnDeposeSpotDroit_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.DeposeSpot();
        }

        private void btnDeposeSpotGauche_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsGauche.DeposeSpot();
        }

        private void btnDeposeEstradeDroite_Click(object sender, EventArgs e)
        {
            Thread thMouvement = new Thread(DeposeEstradeDroite);
            thMouvement.Start();
        }

        private void DeposeEstradeDroite()
        {
            Mouvement m = new MouvementDeposeEstrade(Plateau.ZoneDeposeEstradeDroite);
            m.Executer();
        }

        private void btnTransfertVersDroite_Click(object sender, EventArgs e)
        {
            TransfertVersDroite();
        }

        private void btnTransfertVersGauche_Click(object sender, EventArgs e)
        {
            TransfertVersGauche();
        }

        private void TransfertVersGauche()
        {
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
            Actionneur.BrasPiedsDroite.Deverrouiller();
            Thread.Sleep(200);
            Robots.GrosRobot.VitesseDeplacement = 2000;
            Robots.GrosRobot.AccelerationDebutDeplacement = 2000;
            Robots.GrosRobot.VitessePivot = 4000;
            Robots.GrosRobot.AccelerationPivot = 3000;
            Robots.GrosRobot.Reculer(100);
            Robots.GrosRobot.PivotDroite(39);
            Robots.GrosRobot.Avancer(100);
            Actionneur.BrasPiedsGauche.FermerPinceBas();
            Actionneur.BrasPiedsGauche.FermerPinceHaut();
            Robots.GrosRobot.Rapide();
            Thread.Sleep(200);
        }

        private void TransfertVersDroite()
        {
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.Deverrouiller();
            Thread.Sleep(200);
            Robots.GrosRobot.VitesseDeplacement = 2000;
            Robots.GrosRobot.AccelerationDebutDeplacement = 2000;
            Robots.GrosRobot.VitessePivot = 4000;
            Robots.GrosRobot.AccelerationPivot = 3000;
            Robots.GrosRobot.Reculer(100);
            Robots.GrosRobot.PivotGauche(39);
            Robots.GrosRobot.Avancer(100);
            Actionneur.BrasPiedsDroite.FermerPinceBas();
            Actionneur.BrasPiedsDroite.FermerPinceHaut();
            Robots.GrosRobot.Rapide();
            Thread.Sleep(200);
        }

        private void btnVideDistributeur_Click(object sender, EventArgs e)
        {
            Actionneur.BrasAspirateur.Aspirer();
            Thread.Sleep(500);
            Actionneur.BrasAspirateur.PositionAspire();
            Thread.Sleep(2000);

            Actionneur.BrasAspirateur.Maintenir();
            Actionneur.BrasAspirateur.PositionRange();
        }

        private void btnToutOuvrir_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
        }

        private void btnTransfertBalle_Click(object sender, EventArgs e)
        {
            Actionneurs.BrasPieds.TransfererBalle();
        }

        private void btnBallePrechargee_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGobelet.AmpoulePrechargee = true;
        }

        private void btnClicClicDroit_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.ClicClic();
        }

        private void btn1Droite_Click(object sender, EventArgs e)
        {
            Actionneur.BrasSpot.NbPieds = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actionneur.BrasSpot.NbPieds = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actionneur.BrasSpot.NbPieds = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Actionneur.BrasSpot.NbPieds = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Actionneur.BrasSpot.NbPieds = 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGobelet.Gobelet = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGobelet.Gobelet = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }
    }
}
