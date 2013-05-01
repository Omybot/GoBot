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
    public partial class PanelServo : UserControl
    {
        Servomoteur servo;

        ToolTip tootltip;
        System.Windows.Forms.Timer timerLed;
        bool ledAllume;

        public PanelServo()
        {
            InitializeComponent();
            tootltip = new ToolTip();

            EnableInterface(false);

            servo = null;

            timerLed = new System.Windows.Forms.Timer();
            timerLed.Interval = 250;
            timerLed.Tick += new EventHandler(timerled_Tick);

            ledAllume = false;

            comboBoxFonctions.Text = "ID";
        }


        void Connexion_ConnexionChange(bool conn)
        {
            SetLed(conn);

            EnableInterface(conn);
        }

        delegate void SetLedCallback(bool on);
        private void SetLed(bool on)
        {
            if (ledConnect.InvokeRequired)
            {
                SetLedCallback d = new SetLedCallback(SetLed);
                this.Invoke(d, new object[] { on });
            }
            else
            {
                if (on)
                    ledConnect.CouleurVert(true);
                else
                    ledConnect.CouleurRouge(true);
            }
        }

        delegate void SetTextCallback(Control control, String text);
        private void SetText(Control control, String text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        delegate void EnableControlCallback(Control control, bool enable);
        private void EnableControl(Control control, bool enable)
        {
            if (control.InvokeRequired)
            {
                EnableControlCallback d = new EnableControlCallback(EnableControl);
                this.Invoke(d, new object[] { control, enable });
            }
            else
            {
                control.Enabled = enable;
            }
        }
        
        void EnableInterface(bool enable)
        {
            EnableControl(comboBoxFonctions, enable);
            EnableControl(btnGet, enable);
            EnableControl(btnSet, enable);
            EnableControl(numValeur, enable);
            EnableControl(switchLed, enable);
            EnableControl(trackBarPosition, enable);
            EnableControl(trackBarVitesse, enable);
        }

        void servo_TensionChange(double tension)
        {
            SetText(lblTension, tension + "V");
        }

        void servo_TemperatureChange(int temperature)
        {
            SetText(lblTemperature, temperature + "°");
        }

        void servo_CoupleChange(int couple)
        {
            SetText(lblCouple, couple + "");
        }

        void servo_RechercheAutoFinie(int idServo, double baudrate)
        {
            numID.Value = idServo;
            numBaudrate.Value = (decimal)baudrate;
        }

        private void PanelServo_Load(object sender, EventArgs e)
        {
            tootltip.SetToolTip(ledErreur1, "Instruction inconnue ou instruction envoyée sans Reg_Write");
            ledErreur1.CouleurGris();

            tootltip.SetToolTip(ledErreur2, "Couple hors plage");
            ledErreur2.CouleurGris();

            tootltip.SetToolTip(ledErreur3, "Checksum incorrect");
            ledErreur3.CouleurGris();

            tootltip.SetToolTip(ledErreur4, "Instruction hors plage");
            ledErreur4.CouleurGris();

            tootltip.SetToolTip(ledErreur5, "Température trop élevée");
            ledErreur5.CouleurGris();

            tootltip.SetToolTip(ledErreur6, "Position hors plage");
            ledErreur6.CouleurGris();

            tootltip.SetToolTip(ledErreur7, "Voltage hors plage");
            ledErreur7.CouleurGris();

            ledConnect.CouleurRouge();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous sûr de vouloir modifier la valeur " + comboBoxFonctions.Text + " à " + numValeur.Value + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Faire le changement

                if (comboBoxFonctions.Text == "Baudrate")
                {
                    // Changement de baudrate
                    servo.ChangerBaudrate((int)numValeur.Value);
                }

                else if (comboBoxFonctions.Text == "ID")
                {
                    // Changement de baudrate
                    servo.ChangerID((int)numValeur.Value);
                    numID.Value = numValeur.Value;
                }

                else if (comboBoxFonctions.Text == "Position minimum")
                {
                    // Changement de baudrate
                    servo.SetPositionMin((int)numValeur.Value);
                }

                else if (comboBoxFonctions.Text == "Position maximum")
                {
                    // Changement de baudrate
                    servo.SetPositionMax((int)numValeur.Value);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (servo == null)
            {
                //servo = new Servomoteur(Carte.RecIo, (int)numID.Value, (double)numBaudrate.Value);

                servo.RechercheAutoFinie += new Servomoteur.RechercheAutoDelegate(servo_RechercheAutoFinie);
                servo.TemperatureChange += new Servomoteur.TemperatureDelegate(servo_TemperatureChange);
                servo.TensionChange += new Servomoteur.TensionDelegate(servo_TensionChange);
                servo.CoupleChange += new Servomoteur.CoupleDelegate(servo_CoupleChange);
                servo.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(Connexion_ConnexionChange);
            }
            else
            {
                servo.ID = (int)numID.Value;
                servo.Baudrate = (double)numBaudrate.Value;
            }

            servo.TestConnexion();
        }

        private void trackBarPosition_ValueChanged()
        {
            lblPosition.Text = (int)trackBarPosition.Value + "";
        }

        private void trackBarVitesse_ValueChanged()
        {
            lblVitesse.Text = (int)trackBarVitesse.Value + "";
        }

        private void trackBarVitesse_TickValueChanged()
        {
            servo.SetVitesse((int)trackBarVitesse.Value);
        }

        private void trackBarPosition_TickValueChanged()
        {
            servo.SetPosition((int)trackBarPosition.Value);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            servo.Reset();
        }

        private void btnLed_Click(object sender, EventArgs e)
        {
            servo.SetLed(true);
        }

        void timerled_Tick(object sender, EventArgs e)
        {
            ledAllume = !ledAllume;
            servo.SetLed(ledAllume);
            if(!switchLed.Actif && !ledAllume)
                timerLed.Stop();
        }

        private void switchLed_ChangementEtat(bool actif)
        {
            if (actif)
            {
                timerLed.Start();
            }
        }
    }
}
