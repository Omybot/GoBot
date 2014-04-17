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

        private void btnRangeBras_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, Config.CurrentConfig.PositionGRCoudeRange);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, Config.CurrentConfig.PositionGREpauleRange);
        }

        private void btnBrasFeuRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 780);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);
            /*Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2850);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 867);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 563);*/
        }

        private void btnBrasFeuEtage1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1200);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 542);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 479);
        }

        private void btnBrasFeuInterne1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 920);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 486);
        }

        private void btnAttrapeTorche3_Click(object sender, EventArgs e)
        {
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            btnFeuxTorche3_Click(null, null);
            Thread.Sleep(1300);
            btnFeuIntermediaire_Click(null, null);
            Thread.Sleep(600);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        private void btnFeuxTorche3_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 650);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 500);
        }

        private void btnFeuxTorche2_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 730);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 430);
        }

        private void btnFeuIntermediaire_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 600);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
        }

        private void btnFeuxTorche1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 785);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 370);
        }

        private void btnAttrapeTorche2_Click(object sender, EventArgs e)
        {
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            btnFeuxTorche2_Click(null, null);
            Thread.Sleep(1300);
            btnFeuIntermediaire_Click(null, null);
            Thread.Sleep(600);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        private void btnAttrapeTorche1_Click(object sender, EventArgs e)
        {
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            btnFeuxTorche1_Click(null, null);
            Thread.Sleep(1300);
            btnFeuIntermediaire_Click(null, null);
            Thread.Sleep(600);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAttrapeTorche3_Click(null, null);
            btnAttrapeTorche2_Click(null, null);
            btnAttrapeTorche1_Click(null, null);
        }

        private void btnBrasFeuInterne3_Click(object sender, EventArgs e)
        {
            btnBrasFeuRange_Click(null, null);
        }

        private void btnBrasFeuInterne2_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2800);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 840);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnBrasFeuRange_Click(null, null);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(1000);
            btnBrasFeuEtage1_Click(null, null);
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            btnBrasFeuRange_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnBrasFeuInterne2_Click(null, null);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(1000);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(1000);
            btnBrasFeuEtage1_Click(null, null);
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            btnBrasFeuRange_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnBrasFeuInterne1_Click(null, null);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(1000);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(1000);
            btnBrasFeuEtage1_Click(null, null);
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            btnBrasFeuRange_Click(null, null);
        }

        private void btnBrasFeuInversion_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2100);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 780);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);
        }

        private void btnFeuRetourneTout_Click(object sender, EventArgs e)
        {
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(500);
            btnBrasFeuInterne3_Click(null, null);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            btnBrasFeuInversion_Click(null, null);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);

            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(500);
            btnBrasFeuInterne2_Click(null, null);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(500);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(500);
            btnBrasFeuInversion_Click(null, null);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);

            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(500);
            btnBrasFeuInterne1_Click(null, null);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(500);
            btnBrasFeuRange_Click(null, null);
            Thread.Sleep(500);
            btnBrasFeuInversion_Click(null, null);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);

            btnBrasFeuRange_Click(null, null);
        }

        private void btnFeuSolProche_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1780);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 900);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 260);
        }
    }
}
