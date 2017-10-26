using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Composants
{
    public partial class Battery : PictureBox
    {
        private System.Windows.Forms.Timer timerBlink;

        private double currentVoltage;
        private State currentState;

        public enum State
        {
            High,
            MidHigh,
            Average,
            Low,
            VeryLow,
            Absent
        }

        /// <summary>
        /// Définit la tension au dessus de laquelle la tension est considérée comme élevée
        /// </summary>
        public double VoltageHigh { get; set; }

        /// <summary>
        /// Définit la tension au dessus de laquelle la tension est considérée comme moyenne
        /// </summary>
        public double VoltageAverage { get; set; }

        /// <summary>
        /// Définit la tension au dessus de laquelle la tension est considérée comme basse
        /// </summary>
        public double VoltageLow { get; set; }

        /// <summary>
        /// Définit la tension au dessus de laquelle la tension est considérée comme critique
        /// </summary>
        public double VoltageVeryLow { get; set; }
        
        public Battery()
        {
            InitializeComponent();
            timerBlink = new System.Windows.Forms.Timer();
            timerBlink.Interval = 300;
            timerBlink.Tick += new EventHandler(timer_Tick);
            CurrentVoltage = -1;
            CurrentState = State.Absent;
            VoltageLow = 0;
            VoltageAverage = 0;
            VoltageHigh = 0;
            toolTip.SetToolTip(this, "0V");
        }

        /// <summary>
        /// Permet d'obtenir ou de définir le visuel actuel de la batterie
        /// </summary>
        public State CurrentState
        {
            get { return currentState; }
            set
            {
                Image img;

                currentState = value;

                if (Enabled)
                {
                    switch (currentState)
                    {
                        case State.High:
                            img = Properties.Resources.BatHigh;
                            ChangeImage(Properties.Resources.BatHigh, false);
                            break;
                        case State.MidHigh:
                            ChangeImage(Properties.Resources.BatMidHigh, false);
                            break;
                        case State.Average:
                            ChangeImage(Properties.Resources.BatMid, false);
                            break;
                        case State.Low:
                            img = Properties.Resources.BatLow;
                            ChangeImage(Properties.Resources.BatLow, true);
                            break;
                        case State.VeryLow:
                            img = Properties.Resources.BatCrit;
                            ChangeImage(Properties.Resources.BatCrit, true);
                            break;
                        case State.Absent:
                            ChangeImage(Properties.Resources.BatNo);
                            break;
                    }
                }
                else
                    ChangeImage(Properties.Resources.BatNo, false);
            }
        }

        /// <summary>
        /// Permet de définir ou d'obtenir la tension qui détermine le visuel
        /// </summary>
        public double CurrentVoltage
        {
            get { return currentVoltage; }
            set
            {
                toolTip.SetToolTip(this, currentVoltage + "V");

                currentVoltage = value;

                if (value > VoltageHigh)
                    CurrentState = State.High;
                else if (value > VoltageAverage)
                    CurrentState = State.Average;
                else if (value > VoltageLow)
                    CurrentState = State.Low;
                else if (value >= VoltageVeryLow)
                    CurrentState = State.VeryLow;
            }
        }

        private void ChangeImage(Image img, bool blink = false)
        {
            timerBlink.Stop();
            Visible = true;

            Image = img;

            if (blink)
                timerBlink.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
                Visible = false;
            else
            {
                Visible = true;
                timerBlink.Stop();
            }
        }
    }
}
