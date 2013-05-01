using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM
{
    public partial class PanelDeplacement : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public Robot Robot { get; set; }

        public PanelDeplacement()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupDeplacement.Height;
            tailleMin = 39;

            tooltip.SetToolTip(btnAvance, "Avancer");
            tooltip.SetToolTip(btnRecule, "Reculer");
            tooltip.SetToolTip(btnPivotDroite, "Pivoter vers la droite");
            tooltip.SetToolTip(btnPivotGauche, "Pivoter vers la gauche");
            tooltip.SetToolTip(btnVirageArDr, "Virage vers l'arrière droite");
            tooltip.SetToolTip(btnVirageAvDr, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnVirageArGa, "Virage vers l'arrière gauche");
            tooltip.SetToolTip(btnVirageAvGa, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnStop, "STOP ZOMG §§");
        }

        public virtual void Init()
        {
            // Charger la config

            trackBarVitesse.SetValue(Config.CurrentConfig.GRVitesseLigne);
            trackBarAccel.SetValue(Config.CurrentConfig.GRAccelerationLigne);

            Robot.VitesseDeplacement = Config.CurrentConfig.GRVitesseLigne;
            Robot.AccelerationDeplacement = Config.CurrentConfig.GRAccelerationLigne;

            Robot.VitessePivot = Config.CurrentConfig.GRVitessePivot;
            Robot.AccelerationPivot = Config.CurrentConfig.GRAccelerationPivot;

            Deployer(Config.CurrentConfig.DeplacementGROuvert);
        }

        protected virtual void btnAvance_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
            else
                Robot.Avancer(distance, false);
        }

        protected virtual void btnRecule_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
            else
                Robot.Reculer(distance, false);
        }

        protected virtual void btnPivotGauche_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
            else
                Robot.PivotGauche(angle, false);
        }

        protected virtual void btnPivotDroite_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
            else
                Robot.PivotDroite(angle, false);
        }

        protected virtual void btnVirageAvDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if(ok)
                Robot.Virage(SensAR.Avant, SensGD.Droite, distance, angle, false);
        }

        protected virtual void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Avant, SensGD.Gauche, distance, angle, false);
        }

        protected virtual void btnVirageArGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle, false);
        }

        protected virtual void btnVirageArDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Arriere, SensGD.Droite, distance, angle, false);
        }

        protected virtual void btnStop_Click(object sender, EventArgs e)
        {
            Robot.Stop(StopMode.Freely);
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupDeplacement.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupDeplacement.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupDeplacement.Height = tailleMin;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupDeplacement.Controls)
                    c.Visible = true;

                groupDeplacement.Height = tailleMax;
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

        protected virtual void boxPivot_CheckedChanged(object sender, EventArgs e)
        {
            if (boxPivot.Checked)
            {
                lblVitesse.Text = "Vitesse pivot";
                lblAcceleration.Text = "Accélération pivot";
                trackBarVitesse.SetValue(Config.CurrentConfig.GRVitessePivot, false);
                trackBarAccel.SetValue(Config.CurrentConfig.GRAccelerationPivot, false);
            }
            else
            {
                lblVitesse.Text = "Vitesse ligne";
                lblAcceleration.Text = "Accélération ligne";
                trackBarVitesse.SetValue(Config.CurrentConfig.GRVitesseLigne, false);
                trackBarAccel.SetValue(Config.CurrentConfig.GRAccelerationLigne, false);
            }
        }

        protected virtual void trackBarVitesse_TickValueChanged()
        {
            if (boxPivot.Checked)
            {
                Robot.VitessePivot = (int)trackBarVitesse.Value;
                Config.CurrentConfig.GRVitessePivot = (int)trackBarVitesse.Value;
            }
            else
            {
                Robot.VitesseDeplacement = (int)trackBarVitesse.Value;
                Config.CurrentConfig.GRVitesseLigne = (int)trackBarVitesse.Value;
            }
        }

        protected virtual void trackBarAccel_TickValueChanged()
        {
            if (boxPivot.Checked)
            {
                Robot.AccelerationPivot = (int)trackBarAccel.Value;
                Config.CurrentConfig.GRAccelerationPivot = (int)trackBarAccel.Value;
            }
            else
            {
                Robot.AccelerationDeplacement = (int)trackBarAccel.Value;
                Config.CurrentConfig.GRAccelerationLigne = (int)trackBarAccel.Value;
            }
        }

        protected virtual void panelControleManuel_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true; 
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                Robot.Stop();
        }

        protected virtual void panelControleManuel_ToucheEnfoncee(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Reculer
                Robot.Reculer(10000, false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Avancer
                Robot.Avancer(10000, false);
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Pivot gauche
                Robot.PivotGauche(3600, false);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Pivot droit
                Robot.PivotDroite(3600, false);
            }
            else if (e.KeyCode == Keys.Add)
            {
                // Augmenter vitesse
                Robot.VitesseDeplacement += 50;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                // Diminuer vitesse
                Robot.VitesseDeplacement -= 50;
            }
        }
    }
}
