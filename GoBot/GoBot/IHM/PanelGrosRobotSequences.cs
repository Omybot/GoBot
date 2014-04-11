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
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2850);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 937);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 563);
        }

        private void btnBrasFeuEtage1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1250);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 570);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 487);
        }

        private void btnBrasFeuInterne1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2850);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 971);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 486);
        }
    }
}
