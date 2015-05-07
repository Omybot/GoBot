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

            foreach (ServoBaudrate baudrate in Enum.GetValues(typeof(ServoBaudrate)))
            {
                cboBaudrate.Items.Add(baudrate);
            }
        }

        public void AfficherServo(Servomoteur servo)
        {
            numID.Value = (int)servo.ID;
            cboBaudrate.SelectedItem = servo.Baudrate;
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(numID.Value == 14 || numID.Value == 16)
                servo = new Servomoteur(Carte.RecPi, (int)numID.Value, (ServoBaudrate)cboBaudrate.SelectedItem);
            else
                servo = new Servomoteur(Carte.RecIO, (int)numID.Value, (ServoBaudrate)cboBaudrate.SelectedItem);
            Actualisation(true);
        }

        private int cptTemp = 0;
        private void DessinePosition()
        {
            cptTemp++;

            ctrlGraphiquePosition.AjouterPoint("Position", servo.PositionActuelle, Color.DarkOrchid);
            ctrlGraphiquePosition.DessineCourbes();
            if(cptTemp == 10)
            {
                ctrlGraphiqueTemperature.AjouterPoint("Temperature", servo.Temperature, Color.DarkBlue);
                ctrlGraphiqueTemperature.DessineCourbes();
                cptTemp = 0;
            }
            ctrlGraphiqueVitesse.AjouterPoint("Vitesse", servo.VitesseActuelle, Color.DarkGreen);
            ctrlGraphiqueVitesse.DessineCourbes();
            ctrlGraphiqueCouple.AjouterPoint("Couple", servo.CoupleActuel, Color.DarkRed);
            ctrlGraphiqueCouple.DessineCourbes();

            Bitmap bmp = new Bitmap(160, 160);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(GoBot.Properties.Resources.FondServo, 0, 0, 160, 160);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            double angleTotal = 120 / 360.0 * 2.0 * Math.PI;

            // Position min
            double alpha = 300.0 * servo.PositionMin / 1023.0;//servo.PositionActuelle / 1023;
            alpha = alpha / 360 * 2 * Math.PI;

            int xPosActuelle = (int)(80 + 65 * Math.Cos(angleTotal + alpha));
            int yPosActuelle = (int)(80 + 65 * Math.Sin(angleTotal + alpha));

            g.DrawLine(penPositionActuelleFond, 80, 80, xPosActuelle, yPosActuelle);
            g.DrawLine(penPositionMin, 80, 80, xPosActuelle, yPosActuelle);

            // Position max
            alpha = 300.0 * servo.PositionMax / 1023.0;//servo.PositionActuelle / 1023;
            alpha = alpha / 360 * 2 * Math.PI;

            xPosActuelle = (int)(80 + 65 * Math.Cos(angleTotal + alpha));
            yPosActuelle = (int)(80 + 65 * Math.Sin(angleTotal + alpha));

            g.DrawLine(penPositionActuelleFond, 80, 80, xPosActuelle, yPosActuelle);
            g.DrawLine(penPositionMax, 80, 80, xPosActuelle, yPosActuelle);

            // Position actuelle
            alpha = 300.0 * servo.PositionActuelle / 1023.0;//servo.PositionActuelle / 1023;
            alpha = alpha / 360 * 2 * Math.PI;

            xPosActuelle = (int)(80 + 65 * Math.Cos(angleTotal + alpha));
            yPosActuelle = (int)(80 + 65 * Math.Sin(angleTotal + alpha));

            g.DrawLine(penPositionActuelleFond, 80, 80, xPosActuelle, yPosActuelle);
            g.DrawLine(penPositionActuelle, 80, 80, xPosActuelle, yPosActuelle);

            pictureBoxAngles.Image = bmp;
        }

        private void DessineCompliance(int parametre = 0)
        {
            Bitmap bmp = new Bitmap(218, 140);
            Graphics g = Graphics.FromImage(bmp);

            Pen penNoir = new Pen(Color.Black);
            penNoir.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Pen penGris = new Pen(Color.DarkGray);
            penGris.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            Pen penRouge = new Pen(Color.Black);
            penRouge.Width = 3;

            Pen penRougeVif = new Pen(Color.Red);
            penRougeVif.Width = 3;
            penRougeVif.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            penRougeVif.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(penGris, 0, 70, 218, 70);
            g.DrawLine(penGris, 109, 0, 109, 140);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.DrawLine(penRouge, 0,
                                   3,
                                   (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin) + 3.1 * Math.Sqrt(servo.CCWSlope))),
                                   3);

            g.DrawLine(penRouge, (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin) + 3.1 * Math.Sqrt(servo.CCWSlope))),
                                    3,
                                    (int)(10 + 100 - 3.1 * Math.Sqrt(servo.CCWMargin)),
                                    (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))));

            g.DrawLine(penRouge, (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin))),
                                    (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                    (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin))),
                                    70);

            g.DrawLine(penRouge, (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin))),
                                    70,
                                    (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin))),
                                    70);

            g.DrawLine(penRouge, (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin))),
                                    70,
                                    (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin))),
                                    (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))));

            g.DrawLine(penRouge, (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin))),
                                    (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                    (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin) + (3.1 * Math.Sqrt(servo.CWSlope)))),
                                    137);

            g.DrawLine(penRouge, (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin) + (3.1 * Math.Sqrt(servo.CWSlope)))),
                                    137,
                                    218,
                                    137);

            switch(parametre)
            {
                case 0:
                    break;
                case 1: // CCW Slope
                    g.DrawLine(penRougeVif, (int)(10 + 100 - ((3.1 * Math.Sqrt(servo.CCWMargin) + (3.1 * Math.Sqrt(servo.CCWSlope))))),
                                            (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                            (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin))),
                                            (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))));
                    break; 
                case 2: // CCW Margin
                    g.DrawLine(penRougeVif, (int)(10 + 100 - (3.1 * Math.Sqrt(servo.CCWMargin))),
                                            (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                            109,
                                            (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))));
                    break;
                case 3: // CW Slope 
                    g.DrawLine(penRougeVif, (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin))),
                                         (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                         (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin) + (3.1 * Math.Sqrt(servo.CWSlope)))),
                                         (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))));
                    break;
                case 4: // CW Margin                    
                    g.DrawLine(penRougeVif, 109,
                                            (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                            (int)(109 + (3.1 * Math.Sqrt(servo.CWMargin))),
                                            (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))));
                    break;
                case 5: // Punch            
                    g.DrawLine(penRougeVif, 108,
                                         (int)(70 - 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                         108,
                                         70);
                    g.DrawLine(penRougeVif, 108,
                                         (int)(70 + 10.7 * Math.Sqrt(Math.Sqrt(servo.Punch))),
                                         108,
                                         70);
                    break;
                
            }

            pictureBoxCompliance.Image = bmp;
        }

        private void Actualisation(bool complete)
        {
            MajIHM = true;

            servo.DemandeActualisation(complete);

            //trackBarPosition.SetValue(servo.PositionActuelle, false);
            //trackBarPosition.SetValue(servo.VitesseActuelle, false);

            try
            {
                lblModele.Text = servo.Modele.ToString();
                lblFirmware.Text = servo.Firmware.ToString();
                cboBaudrate.SelectedItem = servo.Baudrate;
                numCouple.Value = (decimal)servo.CoupleMaximum;
                numCoupleLimite.Value = (decimal)servo.CoupleLimite;
                numPositionMin.Value = (decimal)servo.PositionMin;
                numPositionMax.Value = (decimal)servo.PositionMax;
                numCCWSlope.Value = (decimal)servo.CCWSlope;
                numCCWMargin.Value = (decimal)servo.CCWMargin;
                numCWSlope.Value = (decimal)servo.CWSlope;
                numCWMargin.Value = (decimal)servo.CWMargin;
                numTensionMin.Value = (decimal)servo.TensionMinimum;
                numTensionMax.Value = (decimal)servo.TensionMaximum;
                numTempMax.Value = (decimal)servo.TemperatureMaximum;

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
                lblCoupleActuel.Text = servo.CoupleActuel.ToString();

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

                DessinePosition();
                DessineCompliance();
            }
            catch (Exception)
            {
                lblFirmware.Text = "Erreur";
            }

            MajIHM = false;
        }

        private void btnOkBaudrate_Click(object sender, EventArgs e)
        {
            servo.Baudrate = (ServoBaudrate)cboBaudrate.SelectedItem;
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
            DessineCompliance();
        }

        private void btnOkCCWMargin_Click(object sender, EventArgs e)
        {
            servo.CCWMargin = (byte)numCCWMargin.Value;
            DessineCompliance();
        }

        private void btnOkCWSlope_Click(object sender, EventArgs e)
        {
            servo.CWSlope = (byte)numCWSlope.Value;
            DessineCompliance();
        }

        private void btnOkCWMargin_Click(object sender, EventArgs e)
        {
            servo.CWMargin = (byte)numCWMargin.Value;
            DessineCompliance();
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
            Actualisation(false);
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

        private void trackBarPosition_ValueChanged(object sender, EventArgs e)
        {
            lblPosition.Text = trackBarPosition.Value.ToString();
        }

        private void trackBarVitesse_ValueChanged(object sender, EventArgs e)
        {
            lblVitesse.Text = trackBarVitesse.Value.ToString();
        }

        private void trackBarPosition_TickValueChanged(object sender, EventArgs e)
        {
            if (Servomoteur.servosPololu.ContainsKey((ServomoteurID)numID.Value))
                Devices.PololuMiniUart.setTarget(Servomoteur.servosPololu[(ServomoteurID)numID.Value], (ushort)trackBarPosition.Value);
            else
                servo.PositionCible = (int)trackBarPosition.Value;
        }

        private void trackBarVitesse_TickValueChanged(object sender, EventArgs e)
        {
            servo.VitesseMax = (int)trackBarVitesse.Value;
        }

        private void switchLed_ChangementEtat(object sender, EventArgs e)
        {
            servo.LedAllumee = switchLed.Actif;
        }

        private void switchCouple_ChangementEtat(object sender, EventArgs e)
        {
            servo.CoupleActive = switchCouple.Actif;
        }

        private Pen penPositionActuelle;
        private Pen penPositionActuelleFond;
        private Pen penPositionMin;
        private Pen penPositionMax;

        private void PanelServo_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                penPositionActuelle = new Pen(Color.Red, 2);
                penPositionActuelleFond = new Pen(Color.Black, 4);
                penPositionMin = new Pen(Color.Red, 4);
                penPositionMax = new Pen(Color.Red, 4);

                penPositionMin.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                penPositionMax.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
        }

        private void btnOkTensionMin_Click(object sender, EventArgs e)
        {
            servo.TensionMinimum = (double)numTensionMin.Value;
        }

        private void btnOkTensionMax_Click(object sender, EventArgs e)
        {
            servo.TensionMaximum = (double)numTensionMax.Value;
        }

        private void btnOkTempMax_Click(object sender, EventArgs e)
        {
            servo.TemperatureMaximum = (int)numTempMax.Value;
        }

        private void btnOkCoupleLimite_Click(object sender, EventArgs e)
        {
            servo.CoupleLimite = (int)numCoupleLimite.Value;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        }

        private void btnChangeID_Click(object sender, EventArgs e)
        {
            if (!Servomoteur.servosPololu.ContainsKey((ServomoteurID)numID.Value))
                servo.ID = (int)numID.Value;
            else
            {
                trackBarPosition.Min = 2432;
                trackBarPosition.Max = 8192;
            }
        }

        private void btnOkPunch_Click(object sender, EventArgs e)
        {
            servo.Punch = (byte)numPunch.Value;
            DessineCompliance();
        }

        private void numCompliance_Leave(object sender, EventArgs e)
        {
            DessineCompliance(0);
        }

        private void numCCWSlope_Enter(object sender, EventArgs e)
        {
            DessineCompliance(1);
        }

        private void numCCWMargin_Enter(object sender, EventArgs e)
        {
            DessineCompliance(2);
        }

        private void numCWSlope_Enter(object sender, EventArgs e)
        {
            DessineCompliance(3);
        }

        private void numCWMargin_Enter(object sender, EventArgs e)
        {
            DessineCompliance(4);
        }

        private void numPunch_Enter(object sender, EventArgs e)
        {
            DessineCompliance(5);
        }
    }
}
