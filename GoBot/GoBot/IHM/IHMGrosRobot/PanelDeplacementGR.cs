using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;
using System.Threading;

namespace GoBot.IHM.IHMGrosRobot
{
    public partial class PanelDeplacementGR : PanelDeplacement
    {
        public PanelDeplacementGR()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();

            trackBarVitesse.SetValue(Config.CurrentConfig.GRVitesseLigne);
            trackBarAccel.SetValue(Config.CurrentConfig.GRAccelerationLigne);

            Deployer(Config.CurrentConfig.DeplacementGROuvert);
        }

        public override void Deployer(bool deployer)
        {
            base.Deployer(deployer);

            Config.CurrentConfig.DeplacementGROuvert = deployer;
        }

        protected override void btnAvance_Click(object sender, EventArgs e)
        {
            th = new Thread(avancer);
            th.Start();
        }
        Thread th;

        private void avancer()
        {
            base.btnAvance_Click(null, null);

            int distance;
            if (Int32.TryParse(txtDistance.Text, out distance) && distance != 0)
            {
                Plateau.GrosRobot.Avancer(distance);
            }
        }

        protected override void btnRecule_Click(object sender, EventArgs e)
        {
            base.btnRecule_Click(sender, e);

            int distance;
            if (Int32.TryParse(txtDistance.Text, out distance) && distance != 0)
                Plateau.GrosRobot.Reculer(distance);
        }

        protected override void btnPivotGauche_Click(object sender, EventArgs e)
        {
            base.btnPivotGauche_Click(sender, e);

            int angle;
            if (Int32.TryParse(txtAngle.Text, out angle) && angle != 0)
                Plateau.GrosRobot.PivotGauche(angle);
        }

        protected override void btnPivotDroite_Click(object sender, EventArgs e)
        {
            base.btnPivotDroite_Click(sender, e);

            int angle;
            if (Int32.TryParse(txtAngle.Text, out angle) && angle != 0)
                Plateau.GrosRobot.PivotDroite(angle);
        }

        protected override void btnVirageAvDr_Click(object sender, EventArgs e)
        {
            base.btnVirageAvDr_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                Plateau.GrosRobot.Virage(SensAR.Avant, SensGD.Droite, distance, angle);
        }

        protected override void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            base.btnVirageAvGa_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                Plateau.GrosRobot.Virage(SensAR.Avant, SensGD.Gauche, distance, angle);
        }

        protected override void btnVirageArGa_Click(object sender, EventArgs e)
        {
            base.btnVirageArGa_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                Plateau.GrosRobot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle);
        }

        protected override void btnVirageArDr_Click(object sender, EventArgs e)
        {
            base.btnVirageArDr_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                Plateau.GrosRobot.Virage(SensAR.Arriere, SensGD.Droite, distance, angle);
        }

        protected override void btnStop_Click(object sender, EventArgs e)
        {
            base.btnStop_Click(sender, e);

            Plateau.GrosRobot.Stop();
        }

        protected override void boxPivot_CheckedChanged(object sender, EventArgs e)
        {
            base.boxPivot_CheckedChanged(sender, e);

            if (boxPivot.Checked)
            {
                trackBarVitesse.SetValue(Config.CurrentConfig.GRVitessePivot, false);
                trackBarAccel.SetValue(Config.CurrentConfig.GRAccelerationPivot, false);
            }
            else
            {
                trackBarVitesse.SetValue(Config.CurrentConfig.GRVitesseLigne, false);
                trackBarAccel.SetValue(Config.CurrentConfig.GRAccelerationLigne, false);
            }
        }

        protected override void trackBarVitesse_TickValueChanged()
        {
            base.trackBarVitesse_TickValueChanged();

            if (boxPivot.Checked)
            {
                Plateau.GrosRobot.VitessePivot = (int)trackBarVitesse.Value;
                Config.CurrentConfig.GRVitessePivot = (int)trackBarVitesse.Value;
            }
            else
            {
                Plateau.GrosRobot.VitesseDeplacement = (int)trackBarVitesse.Value;
                Config.CurrentConfig.GRVitesseLigne = (int)trackBarVitesse.Value;
            }
        }


        protected override void trackBarAccel_TickValueChanged()
        {
            if (boxPivot.Checked)
            {
                Plateau.GrosRobot.AccelerationPivot = (int)trackBarAccel.Value;
                Config.CurrentConfig.GRAccelerationPivot = (int)trackBarAccel.Value;
            }
            else
            {
                Plateau.GrosRobot.AccelerationDeplacement = (int)trackBarAccel.Value;
                Config.CurrentConfig.GRAccelerationLigne = (int)trackBarAccel.Value;
            }
        }

        protected override void panelControleManuel_ToucheEnfoncee(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Reculer
                Plateau.GrosRobot.Reculer(10000);
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Avancer
                Plateau.GrosRobot.Avancer(10000);
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Pivot gauche
                Plateau.GrosRobot.PivotGauche(10000);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Pivot droit
                Plateau.GrosRobot.PivotDroite(10000);
            }
            else if (e.KeyCode == Keys.Add)
            {
                // Augmenter vitesse
                Plateau.GrosRobot.VitesseDeplacement += 50;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                // Diminuer vitesse
                Plateau.GrosRobot.VitesseDeplacement -= 50;
            }
        }

        protected override void panelControleManuel_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Plateau.GrosRobot.Stop();
            }
        }

        private void btnAvance_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRecule_Click_1(object sender, EventArgs e)
        {

        }
    }
}
