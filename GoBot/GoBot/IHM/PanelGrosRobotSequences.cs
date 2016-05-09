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

        private void btnOuvrirPinceBas_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBas.Ouvrir();
        }

        private void btnFermerPinceBas_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBas.Fermer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mouvement m = new MouvementCube1();
            m.Executer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actionneur.BarreDePompes.Aspirer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Actionneur.BarreDePompes.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Actionneur.PinceBas.Fermer();
            Thread.Sleep(600);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.PivotDroite(180);

            Actionneur.BarreDePompes.Aspirer();
            Robots.GrosRobot.Lent();

            Robots.GrosRobot.Recallage(SensAR.Avant, false);
            Thread.Sleep(2000);
            Robots.GrosRobot.Stop();
            Thread.Sleep(500);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Reculer(200);
            Actionneur.BarreDePompes.Stop();
            Robots.GrosRobot.Reculer(50);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actionneur.BrasDroite.Deployer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Actionneur.BrasDroite.Ranger();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGauche.Deployer();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGauche.Ranger();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Actionneur.BrasDroite.Ouvrir();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Actionneur.BrasDroite.Fermer();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGauche.Ouvrir();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Actionneur.BrasGauche.Fermer();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.PivotGauche(90);
            Robots.GrosRobot.Reculer(190);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Mouvement m = new MouvementDune1();
            m.Executer();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBasLateralGauche.Ranger();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBasLateralGauche.Ouvrir();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBasLateralGauche.Fermer();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBasLateralDroite.Ranger();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBasLateralDroite.Ouvrir();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBasLateralDroite.Fermer();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Actionneur.PinceVerrou.Ouvrir();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Actionneur.PinceVerrou.Fermer();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Actionneur.PinceBas.Ranger();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Actionneur.MaintienDune.Ranger();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Actionneur.MaintienDune.Ouvrir();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Actionneur.MaintienDune.Fermer();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Actionneur.PinceVerrou.Ranger();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Actionneur.BrasDroite.Ranger();
            Actionneur.BrasGauche.Ranger();
            Actionneur.MaintienDune.Ranger();
            Actionneur.PinceBas.Ranger();
            Actionneur.PinceBasLateralDroite.Ranger();
            Actionneur.PinceBasLateralGauche.Ranger();
            Actionneur.PinceVerrou.Ranger();
        }
    }
}
