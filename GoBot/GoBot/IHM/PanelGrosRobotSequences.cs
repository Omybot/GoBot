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

        Thread thMove;

        private void btnEmpilerDroite_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsGauche.Empiler();
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
            Robots.GrosRobot.AccelerationDeplacement = 2000;

            Actionneur.BrasAmpoule.Fermer();
            Thread.Sleep(250);
            Actionneur.BrasAmpoule.Monter();

            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            //Actionneur.BrasPiedsGauche.OuvrirPinceHaut();

            Robots.GrosRobot.PivotGauche(7.76);
            Robots.GrosRobot.Avancer(500);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(70);
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

            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(200);
        }

        private void btnEmpilerGauche_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.Empiler();
        }

        private void btnDebutMatchGauche_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(DebutMatchGauche);
            th.Start();
        }

        private void DebutMatchGauche()
        {
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
            Actionneur.BrasPiedsGauche.Empiler();
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
    }
}
