using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IhmRobot.IHM.IHMGrosRobot
{
    public partial class DeplacementGrosRobot : UserControl
    {
        private ToolTip tooltip;

        public DeplacementGrosRobot()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tooltip.SetToolTip(btnAvance, "Avancer");
            tooltip.SetToolTip(btnRecule, "Reculer");
            tooltip.SetToolTip(btnPivotDroite, "Pivoter vers la droite");
            tooltip.SetToolTip(btnPivotGauche, "Pivoter vers la gauche");
            tooltip.SetToolTip(btnVirageArDr, "Virage vers l'arrière droite");
            tooltip.SetToolTip(btnVirageAvDr, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnVirageArGa, "Virage vers l'arrière gauche");
            tooltip.SetToolTip(btnVirageAvGa, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnStop, "STOP ZOMG §§");

            Deployer(Config.CurrentConfig.DeplacementGROuvert);
        }

        public void ChargerConfig()
        {
            trackBarVitesse.Value = Config.CurrentConfig.VitesseLigne;
            trackBarAccel.Value = Config.CurrentConfig.AccelerationLigne;
        }

        private void btnAvance_Click(object sender, EventArgs e)
        {
            int distance;
            if (Int32.TryParse(txtDistance.Text, out distance) && distance != 0)
            {
                GrosRobot.Avancer(distance);
            }
            else
                txtDistance.ErrorMode = true;
        }

        private void btnRecule_Click(object sender, EventArgs e)
        {
            int distance;
            if (Int32.TryParse(txtDistance.Text, out distance) && distance != 0)
            {
                GrosRobot.Reculer(distance);
            }
            else
                txtDistance.ErrorMode = true;
        }

        private void btnPivotGauche_Click(object sender, EventArgs e)
        {
            int angle;
            if (Int32.TryParse(txtAngle.Text, out angle) && angle != 0)
            {
                GrosRobot.PivotGauche(angle);
            }
            else
                txtAngle.ErrorMode = true;
        }

        private void btnPivotDroite_Click(object sender, EventArgs e)
        {
            int angle;
            if (Int32.TryParse(txtAngle.Text, out angle) && angle != 0)
            {
                GrosRobot.PivotDroite(angle);
            }
            else
                txtAngle.ErrorMode = true;
        }

        private void btnVirageAvDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;

            if (angle != 0 && distance != 0)
            {
                GrosRobot.Virage(SensAR.Avant, SensGD.Droite, distance, angle);
            }
        }

        private void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;

            if (angle != 0 && distance != 0)
            {
                GrosRobot.Virage(SensAR.Avant, SensGD.Gauche, distance, angle);
            }
        }

        private void btnVirageArGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;

            if (angle != 0 && distance != 0)
            {
                GrosRobot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle);
            }
        }

        private void btnVirageArDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;

            if (angle != 0 && distance != 0)
            {
                GrosRobot.Virage(SensAR.Arriere, SensGD.Droite, distance, angle);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            GrosRobot.Stop();
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupDeplacement.Height == 259)
                Deployer(false);
            else
                Deployer(true);
        }

        public void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupDeplacement.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupDeplacement.Height = 39;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupDeplacement.Controls)
                    c.Visible = true;

                groupDeplacement.Height = 259;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.DeplacementGROuvert = deployer;
        }

        private void trackBarVitesse_ValueChanged()
        {
            lblValeurVitesse.Text = (int)trackBarVitesse.Value + "";
        }

        private void trackBarAccel_ValueChanged()
        {
            lblValeurAccel.Text = (int)trackBarAccel.Value + "";
        }

        private void boxPivot_CheckedChanged_1(object sender, EventArgs e)
        {
            if (boxPivot.Checked)
            {
                lblVitesse.Text = "Vitesse pivot";
                lblAcceleration.Text = "Accélération pivot";
                trackBarVitesse.Value = Config.CurrentConfig.VitessePivot;
                trackBarAccel.Value = Config.CurrentConfig.AccelerationPivot;
            }
            else
            {
                lblVitesse.Text = "Vitesse ligne";
                lblAcceleration.Text = "Accélération ligne";
                trackBarVitesse.Value = Config.CurrentConfig.VitesseLigne;
                trackBarAccel.Value = Config.CurrentConfig.AccelerationLigne;
            }
        }

        private void trackBarVitesse_TickValueChanged()
        {
            if (boxPivot.Checked)
            {
                GrosRobot.VitessePivot = (int)trackBarVitesse.Value;
                Config.CurrentConfig.VitessePivot = (int)trackBarVitesse.Value;
            }
            else
            {
                GrosRobot.VitesseDeplacement = (int)trackBarVitesse.Value;
                Config.CurrentConfig.VitesseLigne = (int)trackBarVitesse.Value;
            }
        }

        private void trackBarAccel_TickValueChanged()
        {
            if (boxPivot.Checked)
            {
                GrosRobot.AccelerationPivot = (int)trackBarAccel.Value;
                Config.CurrentConfig.AccelerationPivot = (int)trackBarAccel.Value;
            }
            else
            {
                GrosRobot.AccelerationDeplacement = (int)trackBarAccel.Value;
                Config.CurrentConfig.AccelerationLigne = (int)trackBarAccel.Value;
            }
        }
    }
}
