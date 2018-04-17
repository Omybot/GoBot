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
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PotarControl : UserControl
    {
        private ThreadLink _linkPolling;
        private Positionable positionnable;

        public PotarControl()
        {
            InitializeComponent();
            _linkPolling = null;
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
            if (value)
                _linkPolling = ThreadManager.StartThread(link => PollingLoop());
            else
            {
                _linkPolling.Cancel();
            }
        }

        private void PollingLoop()
        {
            double posValue;
            double ticksMin, ticksCurrent, ticksRange;
            int pointsParTour = 4096;
            double toursRange = 5;

            _linkPolling.RegisterName();

            ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();
            ticksMin = ticksCurrent;
            ticksRange = pointsParTour * toursRange;

            posValue = positionnable.Minimum;

            while (!_linkPolling.Cancelled)
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

            _linkPolling = null;
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
