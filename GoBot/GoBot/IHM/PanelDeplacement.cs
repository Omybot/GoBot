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
        }

        protected virtual void btnAvance_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
        }

        protected virtual void btnRecule_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
        }

        protected virtual void btnPivotGauche_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
        }

        protected virtual void btnPivotDroite_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
        }

        protected virtual void btnVirageAvDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;
        }

        protected virtual void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;
        }

        protected virtual void btnVirageArGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;
        }

        protected virtual void btnVirageArDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
                txtDistance.ErrorMode = true;
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
                txtAngle.ErrorMode = true;
        }

        protected virtual void btnStop_Click(object sender, EventArgs e)
        {
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
            }
            else
            {
                lblVitesse.Text = "Vitesse ligne";
                lblAcceleration.Text = "Accélération ligne";
            }
        }

        protected virtual void trackBarVitesse_TickValueChanged()
        {
        }

        protected virtual void trackBarAccel_TickValueChanged()
        {
        }

        protected virtual void panelControleManuel_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        protected virtual void panelControleManuel_ToucheEnfoncee(PreviewKeyDownEventArgs e)
        {

        }
    }
}
