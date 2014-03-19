using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelServo : UserControl
    {
        private Servomoteur servo;
        private bool MajIHM { get; set; }

        public PanelServo()
        {
            InitializeComponent();

            servo = null;

            ledErreurAngleLimit.CouleurGris();
            ledErreurChecksum.CouleurGris();
            ledErreurInputVoltage.CouleurGris();
            ledErreurInstruction.CouleurGris();
            ledErreurOverheating.CouleurGris();
            ledErreurOverload.CouleurGris();
            ledErreurRange.CouleurGris();
            ledLed.CouleurGris();
            ledMouvement.CouleurGris();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Actualisation();
        }

        private void Actualisation()
        {
            MajIHM = true;

            servo = new Servomoteur(Carte.RecMove, (int)numID.Value, 19200);

            trackBarPosition.SetValue(servo.PositionActuelle);
            trackBarPosition.SetValue(servo.VitesseActuelle);

            lblModele.Text = servo.Modele.ToString();
            lblFirmware.Text = servo.Firmware.ToString();
            numBaudrate.Value = (decimal)servo.Baudrate;
            numCouple.Value = (decimal)servo.CoupleMaximum;
            numPositionMin.Value = (decimal)servo.PositionMin;
            numPositionMax.Value = (decimal)servo.PositionMax;
            numCCWSlope.Value = (decimal)servo.CCWSlope;
            numCCWMargin.Value = (decimal)servo.CCWMargin;
            numCWSlope.Value = (decimal)servo.CWSlope;
            numCWMargin.Value = (decimal)servo.CWMargin;
            if (servo.LedAllumee)
            {
                ledLed.CouleurRouge();
                switchLed.SetActif(true, false);
            }
            else
            {
                ledLed.CouleurGris();
                switchLed.SetActif(false, false);
            }

            if (servo.CoupleActive)
            {
                ledCouple.CouleurVert();
                switchCouple.SetActif(true, false);
            }
            else
            {
                ledCouple.CouleurGris();
                switchCouple.SetActif(false, false);
            }

            if (servo.EnMouvement)
                ledMouvement.CouleurVert();
            else
                ledMouvement.CouleurGris();

            lblTemperature.Text = servo.Temperature + " °C";
            lblTension.Text = servo.Tension + " V";
            lblPositionActuelle.Text = servo.PositionActuelle.ToString();
            lblVitesseActuelle.Text = servo.VitesseActuelle.ToString();

            boxLEDAngleLimit.Checked = servo.AlarmeLEDAngleLimit;
            boxLEDChecksum.Checked = servo.AlarmeLEDChecksum;
            boxLEDInputVoltage.Checked = servo.AlarmeLEDInputVoltage;
            boxLEDInstruction.Checked = servo.AlarmeLEDInstruction;
            boxLEDOverheating.Checked = servo.AlarmeLEDOverheating;
            boxLEDOverload.Checked = servo.AlarmeLEDOverload;
            boxLEDRange.Checked = servo.AlarmeLEDRange;

            boxShutdownAngleLimit.Checked = servo.AlarmeShutdownAngleLimit;
            boxShutdownChecksum.Checked = servo.AlarmeShutdownChecksum;
            boxShutdownInputVoltage.Checked = servo.AlarmeShutdownInputVoltage;
            boxShutdownInstruction.Checked = servo.AlarmeShutdownInstruction;
            boxShutdownOverheating.Checked = servo.AlarmeShutdownOverheating;
            boxShutdownOverload.Checked = servo.AlarmeShutdownOverload;
            boxShutdownRange.Checked = servo.AlarmeShutdownRange;

            if (servo.ErreurAngleLimit)
                ledErreurAngleLimit.CouleurRouge();
            else
                ledErreurAngleLimit.CouleurGris();

            if (servo.ErreurChecksum)
                ledErreurChecksum.CouleurRouge();
            else
                ledErreurChecksum.CouleurGris();

            if (servo.ErreurInputVoltage)
                ledErreurInputVoltage.CouleurRouge();
            else
                ledErreurInputVoltage.CouleurGris();

            if (servo.ErreurInstruction)
                ledErreurInstruction.CouleurRouge();
            else
                ledErreurInstruction.CouleurGris();

            if (servo.ErreurOverheating)
                ledErreurOverheating.CouleurRouge();
            else
                ledErreurOverheating.CouleurGris();

            if (servo.ErreurOverload)
                ledErreurOverload.CouleurRouge();
            else
                ledErreurOverload.CouleurGris();

            if (servo.ErreurRange)
                ledErreurRange.CouleurRouge();
            else
                ledErreurRange.CouleurGris();

            MajIHM = false;
        }

        private void btnOkBaudrate_Click(object sender, EventArgs e)
        {
            servo.Baudrate = (double)numBaudrate.Value;
        }

        private void btnOkCoupleMax_Click(object sender, EventArgs e)
        {
            servo.CoupleMaximum = (int)numCouple.Value;
        }

        private void btnOkPositionMin_Click(object sender, EventArgs e)
        {
            servo.PositionMin = (int)numPositionMin.Value;
        }

        private void btnOkPositionMax_Click(object sender, EventArgs e)
        {
            servo.PositionMax = (int)numPositionMax.Value;
        }

        private void btnOkCCWSlope_Click(object sender, EventArgs e)
        {
            servo.CCWSlope = (byte)numCCWSlope.Value;
        }

        private void btnOkCCWMargin_Click(object sender, EventArgs e)
        {
            servo.CCWMargin = (byte)numCCWMargin.Value;
        }

        private void btnOkCWSlope_Click(object sender, EventArgs e)
        {
            servo.CWSlope = (byte)numCWSlope.Value;
        }

        private void btnOkCWMargin_Click(object sender, EventArgs e)
        {
            servo.CWMargin = (byte)numCWMargin.Value;
        }

        private void boxLEDInputVoltage_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDInputVoltage = boxLEDInputVoltage.Checked;
        }

        private void boxLEDAngleLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDAngleLimit = boxLEDAngleLimit.Checked;
        }

        private void boxLEDOverheating_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDOverheating = boxLEDOverheating.Checked;
        }

        private void boxLEDRange_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDRange = boxLEDRange.Checked;
        }

        private void boxLEDChecksum_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDChecksum = boxLEDChecksum.Checked;
        }

        private void boxLEDOverload_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDOverload = boxLEDOverload.Checked;
        }

        private void boxLEDInstruction_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeLEDInstruction = boxLEDInstruction.Checked;
        }

        private void boxShutdownInputVoltage_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownInputVoltage = boxShutdownInputVoltage.Checked;
        }

        private void boxShutdownAngleLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownAngleLimit = boxShutdownAngleLimit.Checked;
        }

        private void boxShutdownOverheating_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownOverheating = boxShutdownOverheating.Checked;
        }

        private void boxShutdownRange_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownRange = boxShutdownRange.Checked;
        }

        private void boxShutdownChecksum_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownChecksum = boxShutdownChecksum.Checked;
        }

        private void boxShutdownOverload_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownOverload = boxShutdownOverload.Checked;
        }

        private void boxShutdownInstruction_CheckedChanged(object sender, EventArgs e)
        {
            if (!MajIHM)
                servo.AlarmeShutdownInstruction = boxShutdownInstruction.Checked;
        }

        private System.Windows.Forms.Timer timer;
        private void btnAuto_Click(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)numIntervalle.Value;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            servo.DemandeActualisation();
            Actualisation();
        }

        private void switchSurveillance_ChangementEtat(object sender, EventArgs e)
        {
            if (switchSurveillance.Actif)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = (int)numIntervalle.Value;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            else
                timer.Stop();
        }
    }
}
