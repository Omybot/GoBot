using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using GoBot.Communications;
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelAnalogique : UserControl
    {
        private ThreadLink _linkPolling, _linkDraw;

        public PanelAnalogique()
        {
            InitializeComponent();
        }

        public Board Carte { get; set; }

        private void PanelAnalogique_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                ctrlGraphique.BorderVisible = true;
                ctrlGraphique.BorderColor = Color.LightGray;
            }
        }

        void AskValues()
        {
            Robots.MainRobot.ReadAnalogicPins(Carte, true);

            if (Robots.MainRobot.AnalogicPinsValue[Carte] != null)
            {
                this.InvokeAuto(() =>
                {
                    List<double> values = Robots.MainRobot.AnalogicPinsValue[Carte];
                    lblAN1.Text = values[0].ToString("0.0000") + " V";
                    lblAN2.Text = values[1].ToString("0.0000") + " V";
                    lblAN3.Text = values[2].ToString("0.0000") + " V";
                    lblAN4.Text = values[3].ToString("0.0000") + " V";
                    lblAN5.Text = values[4].ToString("0.0000") + " V";
                    lblAN6.Text = values[5].ToString("0.0000") + " V";
                    lblAN7.Text = values[6].ToString("0.0000") + " V";
                    lblAN8.Text = values[7].ToString("0.0000") + " V";
                    lblAN9.Text = values[8].ToString("0.0000") + " V";

                    ctrlGraphique.AddPoint("AN1", values[0], ColorPlus.FromHsl(360 / 9 * 0, 1, 0.4));
                    ctrlGraphique.AddPoint("AN2", values[1], ColorPlus.FromHsl(360 / 9 * 1, 1, 0.4));
                    ctrlGraphique.AddPoint("AN3", values[2], ColorPlus.FromHsl(360 / 9 * 2, 1, 0.4));
                    ctrlGraphique.AddPoint("AN4", values[3], ColorPlus.FromHsl(360 / 9 * 3, 1, 0.4));
                    ctrlGraphique.AddPoint("AN5", values[4], ColorPlus.FromHsl(360 / 9 * 4, 1, 0.4));
                    ctrlGraphique.AddPoint("AN6", values[5], ColorPlus.FromHsl(360 / 9 * 5, 1, 0.4));
                    ctrlGraphique.AddPoint("AN7", values[6], ColorPlus.FromHsl(360 / 9 * 6, 1, 0.4));
                    ctrlGraphique.AddPoint("AN8", values[7], ColorPlus.FromHsl(360 / 9 * 7, 1, 0.4));
                    ctrlGraphique.AddPoint("AN9", values[8], ColorPlus.FromHsl(360 / 9 * 8, 1, 0.4));
                });
            }
        }

        private void switchBouton_ValueChanged(object sender, bool value)
        {
            if(value)
            {
                _linkPolling = ThreadManager.CreateThread(link => AskValues());
                _linkPolling.Name = "Ports analogiques " + Carte.ToString();
                _linkPolling.StartInfiniteLoop(50);

                _linkDraw = ThreadManager.CreateThread(link => ctrlGraphique.DrawCurves());
                _linkDraw.Name = "Graph ports analogiques " + Carte.ToString();
                _linkDraw.StartInfiniteLoop(100);
            }
            else
            {
                _linkPolling.Cancel();
                _linkPolling.WaitEnd();
                _linkPolling = null;

                _linkDraw.Cancel();
                _linkDraw.WaitEnd();
                _linkDraw = null;
            }
        }

        private void boxAN1_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN1", boxIOAN1.Checked);
        }

        private void boxAN2_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN2", boxIOAN2.Checked);
        }

        private void boxAN3_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN3", boxIOAN3.Checked);
        }

        private void boxAN4_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN4", boxIOAN4.Checked);
        }

        private void boxAN5_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN5", boxIOAN5.Checked);
        }

        private void boxAN6_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN6", boxIOAN6.Checked);
        }

        private void boxAN7_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN7", boxIOAN7.Checked);
        }

        private void boxAN8_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN8", boxIOAN8.Checked);
        }

        private void boxAN9_CheckedChanged(object sender, EventArgs e)
        {
            ctrlGraphique.ShowCurve("AN9", boxIOAN9.Checked);
        }
    }
}
