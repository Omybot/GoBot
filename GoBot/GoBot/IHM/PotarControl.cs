using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actionneurs;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PotarControl : UserControl
    {
        private Thread threadPolling;
        private bool pollingEnable;
        private Positionable positionnable;

        public PotarControl()
        {
            InitializeComponent();
            pollingEnable = false;
        }

        private void PotarControl_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                cboPositionnable.Items.AddRange(Config.Positionnables.ToArray());
            }
        }

        private void cboPositionnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            positionnable = (Positionable)cboPositionnable.SelectedItem;
            trackBar.Min = positionnable.Minimum;
            trackBar.Max = positionnable.Maximum;
        }

        private void switchBouton_ValueChanged(object sender, bool value)
        {
            if(value)
            {
                pollingEnable = true;
                threadPolling = new Thread(ThreadPollingCodeur);
                threadPolling.Start();
            }
            else
            {
                pollingEnable = false;
            }
        }

        private void ThreadPollingCodeur()
        {
            double posValue;
            double ticksMin, ticksCurrent, ticksRange;
            int pointsParTour = 4096;
            double toursRange = 5;

            ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();
            ticksMin = ticksCurrent;
            ticksRange = pointsParTour * toursRange;

            posValue = positionnable.Minimum;

            while(pollingEnable)
            {
                toursRange = trackBarSpeed.Value;
                ticksRange = pointsParTour * toursRange;
                Thread.Sleep(50);
                ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();

                if (ticksCurrent > ticksMin + ticksRange)
                    ticksMin = ticksCurrent - ticksRange;
                else if (ticksCurrent < ticksMin)
                    ticksMin = ticksCurrent;

                posValue = (ticksCurrent - ticksMin) / ticksRange * (positionnable.Maximum - positionnable.Minimum) + positionnable.Minimum;

                posValue = Math.Min(posValue, positionnable.Maximum);
                posValue = Math.Max(posValue, positionnable.Minimum);

                this.InvokeAuto(() => trackBar.SetValue((int)posValue));
            }
        }

        private void TrackBar_TickValueChanged(object sender, double value)
        {
            if (positionnable != null)
            {
                positionnable.SendPosition((int)value);
                lblValue.Text = trackBar.Value.ToString();
            }
        }

        private void trackBarSpeed_ValueChanged(object sender, double value)
        {
            lblSpeed.Text = "Rapport " + value.ToString();
        }
    }
}
