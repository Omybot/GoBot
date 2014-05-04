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
            BrasFeux.PositionRange();
        }

        private void btnBrasFeuEtage1_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionDeposeLoinSol();
        }

        private void btnBrasFeuInterne1_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionInterne1();
        }

        private void btnAttrapeTorche3_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveAttrapeTorche3();
        }

        private void btnFeuxTorche3_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionTorche3();
        }

        private void btnFeuxTorche2_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionTorche2();
        }

        private void btnFeuIntermediaire_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionTorcheDessus();
        }

        private void btnFeuxTorche1_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionTorche1();
        }

        private void btnAttrapeTorche2_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveAttrapeTorche2();
        }

        private void btnAttrapeTorche1_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveAttrapeTorche1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveAttrapeTorcheTout();
        }

        private void btnBrasFeuInterne3_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionInterne3();
        }

        private void btnBrasFeuInterne2_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionInterne2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeLoin3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeLoin2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeLoin1();
        }

        private void btnBrasFeuInversion_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionRetournement();
        }

        private void btnFeuRetourneTout_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveRetourneTout();
        }

        private void btnFeuSolProche_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionSolProche();
        }

        private void btnFeuDeposeProche3_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeProche3();
        }

        private void btnFeuDeposeProche2_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeProche2();
        }

        private void btnFeuDeposeProche1_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeProche1();
        }

        private void btnFeuDeposeProcheTout_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeProche3();
            BrasFeux.MoveDeposeProche2();
            BrasFeux.MoveDeposeProche1();
        }

        private void btnFeuDeposeInverse3_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeRetourne3();
        }

        private void btnFeuDeposeInverse2_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeRetourne2();
        }

        private void btnFeuDeposeInverse1_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveDeposeRetourne1();
        }

        private void btnMur_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionContreMur();
        }

        private void btnAttrapeContreMur_Click(object sender, EventArgs e)
        {
            BrasFeux.MoveAttrapeContreMur();
        }
    }
}
