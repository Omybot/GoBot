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
        private Positionnable positionnable;

        public PotarControl()
        {
            InitializeComponent();
            pollingEnable = false;
        }

        private void PotarControl_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                cboPositionnable.Items.AddRange(Config.Positionnables.ToArray());
            }
        }

        private void cboPositionnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            positionnable = (Positionnable)cboPositionnable.SelectedItem;
            trackBar.Min = positionnable.Minimum;
            trackBar.Max = positionnable.Maximum;
        }

        private void switchBouton_ChangementEtat(object sender, EventArgs e)
        {
            if(switchBouton.Actif)
            {
                pollingEnable = true;
                threadPolling = new Thread(ThreadPollingCodeur);
                threadPolling.Start();
            }
            else
            {
                pollingEnable = false;
                threadPolling.Join();
            }
        }

        private void ThreadPollingCodeur()
        {
            double exValue, value, posValue;
            double ticksMin, ticksCurrent, ticksRange;
            int pointsParTour = 4096;
            int toursRange = 5;

            ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();
            ticksMin = ticksCurrent;
            ticksRange = pointsParTour * toursRange;

            posValue = positionnable.Minimum;

            while(pollingEnable)
            {
                Thread.Sleep(50);
                ticksCurrent = Devices.Devices.RecGoBot.GetCodeurPosition();

                if (ticksCurrent > ticksMin + ticksRange)
                    ticksMin = ticksCurrent - ticksRange;
                else if (ticksCurrent < ticksMin)
                    ticksMin = ticksCurrent;

                posValue = (ticksCurrent - ticksMin) / ticksRange * (positionnable.Maximum - positionnable.Minimum) + positionnable.Minimum;

                posValue = Math.Min(posValue, positionnable.Maximum);
                posValue = Math.Max(posValue, positionnable.Minimum);

                trackBar.Invoke(new EventHandler(delegate
                {
                    trackBar.SetValue((int)posValue);
                }));
            }
        }

        private void trackBar_TickValueChanged(object sender, EventArgs e)
        {
            if (positionnable != null)
            {
                positionnable.Positionner((int)trackBar.Value);
                lblValue.Text = trackBar.Value.ToString();
            }
        }
    }
}
