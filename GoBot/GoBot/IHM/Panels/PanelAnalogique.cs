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

namespace GoBot.IHM
{
    public partial class PanelAnalogique : UserControl
    {
        private System.Timers.Timer timerTrame;

        public PanelAnalogique()
        {
            InitializeComponent();
        }

        public Board Carte { get; set; }

        private void PanelAnalogique_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                timerTrame = new System.Timers.Timer();
                timerTrame.Elapsed += new ElapsedEventHandler(timerTrame_Elapsed);
                timerTrame.Start();
                timerTrame.Enabled = false;
            }
        }

        void timerTrame_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Execution.Shutdown)
                return;

            if (Robots.GrosRobot.ValeursAnalogiques[Carte] != null)
            {
                this.InvokeAuto(() =>
                {
                    List<double> values = Robots.GrosRobot.ValeursAnalogiques[Carte];
                    lblAN1.Text = values[0].ToString("0.0000") + " V";
                    lblAN2.Text = values[1].ToString("0.0000") + " V";
                    lblAN3.Text = values[2].ToString("0.0000") + " V";
                    lblAN4.Text = values[3].ToString("0.0000") + " V";
                    lblAN5.Text = values[4].ToString("0.0000") + " V";
                    lblAN6.Text = values[5].ToString("0.0000") + " V";
                    lblAN7.Text = values[6].ToString("0.0000") + " V";
                    lblAN8.Text = values[7].ToString("0.0000") + " V";
                    lblAN9.Text = values[8].ToString("0.0000") + " V";

                    ctrlGraphique.AddPoint("AN1", values[0], Color.Blue);
                    ctrlGraphique.AddPoint("AN2", values[1], Color.Aqua);
                    ctrlGraphique.AddPoint("AN3", values[2], Color.Red);
                    ctrlGraphique.AddPoint("AN4", values[3], Color.Magenta);
                    ctrlGraphique.AddPoint("AN5", values[4], Color.Green);
                    ctrlGraphique.AddPoint("AN6", values[5], Color.Orange);
                    ctrlGraphique.AddPoint("AN7", values[6], Color.Black);
                    ctrlGraphique.AddPoint("AN8", values[7], Color.Coral);
                    ctrlGraphique.AddPoint("AN9", values[8], Color.DeepPink);
                });
            }

            ctrlGraphique.DrawCurves();

            Robots.GrosRobot.DemandeValeursAnalogiques(Carte);
        }

        private void switchBouton_ValueChanged(object sender, bool value)
        {
            timerTrame.Enabled = value;
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
