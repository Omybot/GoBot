using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM.IHMPetitRobot
{
    public partial class PanelDeplacementPR : PanelDeplacement
    {
        public PanelDeplacementPR()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();

            trackBarVitesse.SetValue(Config.CurrentConfig.PRVitesseLigne);
            trackBarAccel.SetValue(Config.CurrentConfig.PRAccelerationLigne);

            Deployer(Config.CurrentConfig.DeplacementPROuvert);
        }

        public override void Deployer(bool deployer)
        {
            base.Deployer(deployer);

            Config.CurrentConfig.DeplacementPROuvert = deployer;
        }

        protected void btnAvance_Click(object sender, EventArgs e)
        {
            base.btnAvance_Click(sender, e);

            int distance;
            if (Int32.TryParse(txtDistance.Text, out distance) && distance != 0)
                PetitRobot.Avancer(distance);
            else
                txtDistance.ErrorMode = true;
        }

        protected void btnRecule_Click(object sender, EventArgs e)
        {
            base.btnRecule_Click(sender, e);

            int distance;
            if (Int32.TryParse(txtDistance.Text, out distance) && distance != 0)
                PetitRobot.Reculer(distance);
            else
                txtDistance.ErrorMode = true;
        }

        protected void btnPivotGauche_Click(object sender, EventArgs e)
        {
            base.btnPivotGauche_Click(sender, e);

            int angle;
            if (Int32.TryParse(txtAngle.Text, out angle) && angle != 0)
                PetitRobot.PivotGauche(angle);
            else
                txtAngle.ErrorMode = true;
        }

        protected void btnPivotDroite_Click(object sender, EventArgs e)
        {
            base.btnPivotDroite_Click(sender, e);

            int angle;
            if (Int32.TryParse(txtAngle.Text, out angle) && angle != 0)
                PetitRobot.PivotDroite(angle);
            else
                txtAngle.ErrorMode = true;
        }

        protected void btnVirageAvDr_Click(object sender, EventArgs e)
        {
            base.btnVirageAvDr_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                PetitRobot.Virage(SensAR.Avant, SensGD.Droite, distance, angle);
        }

        protected void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            base.btnVirageAvGa_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                PetitRobot.Virage(SensAR.Avant, SensGD.Gauche, distance, angle);
        }

        protected void btnVirageArGa_Click(object sender, EventArgs e)
        {
            base.btnVirageArGa_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                PetitRobot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle);
        }

        protected void btnVirageArDr_Click(object sender, EventArgs e)
        {
            base.btnVirageArDr_Click(sender, e);

            int distance = 0;
            int angle = 0;

            Int32.TryParse(txtDistance.Text, out distance);
            Int32.TryParse(txtAngle.Text, out angle);

            if (angle != 0 && distance != 0)
                PetitRobot.Virage(SensAR.Arriere, SensGD.Droite, distance, angle);
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            base.btnStop_Click(sender, e);

            PetitRobot.Stop();
        }

        protected void boxPivot_CheckedChanged(object sender, EventArgs e)
        {
            base.boxPivot_CheckedChanged(sender, e);

            if (boxPivot.Checked)
            {
                trackBarVitesse.SetValue(Config.CurrentConfig.PRVitessePivot, false);
                trackBarAccel.SetValue(Config.CurrentConfig.PRAccelerationPivot, false);
            }
            else
            {
                trackBarVitesse.SetValue(Config.CurrentConfig.PRVitesseLigne, false);
                trackBarAccel.SetValue(Config.CurrentConfig.PRAccelerationLigne, false);
            }
        }

        protected void trackBarVitesse_TickValueChanged()
        {
            base.trackBarVitesse_TickValueChanged();

            if (boxPivot.Checked)
            {
                PetitRobot.VitessePivot = (int)trackBarVitesse.Value;
                Config.CurrentConfig.PRVitessePivot = (int)trackBarVitesse.Value;
            }
            else
            {
                PetitRobot.VitesseDeplacement = (int)trackBarVitesse.Value;
                Config.CurrentConfig.PRVitesseLigne = (int)trackBarVitesse.Value;
            }
        }


        protected void trackBarAccel_TickValueChanged()
        {
            if (boxPivot.Checked)
            {
                PetitRobot.AccelerationPivot = (int)trackBarAccel.Value;
                Config.CurrentConfig.PRAccelerationPivot = (int)trackBarAccel.Value;
            }
            else
            {
                PetitRobot.AccelerationDeplacement = (int)trackBarAccel.Value;
                Config.CurrentConfig.PRAccelerationLigne = (int)trackBarAccel.Value;
            }
        }
    }
}
