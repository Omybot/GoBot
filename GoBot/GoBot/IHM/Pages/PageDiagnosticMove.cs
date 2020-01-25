using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using GoBot.Threading;

namespace GoBot.IHM.Pages
{
    public partial class PageDiagnosticMove : UserControl
    {
        private ThreadLink _linkPolling;
        private ThreadLink _linkDrawing;

        double _cpuAverage;

        public PageDiagnosticMove()
        {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (_linkPolling == null)
            {
                btnLaunch.Text = "Stopper";
                btnLaunch.Image = Properties.Resources.Pause16;

                _linkPolling = ThreadManager.CreateThread(link => Measure());
                _linkPolling.StartInfiniteLoop(new TimeSpan(0));

                _linkDrawing = ThreadManager.CreateThread(link => DrawMeasures());
                _linkDrawing.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 50));
            }
            else
            {
                btnLaunch.Text = "Lancer";
                btnLaunch.Image = Properties.Resources.Play16;

                _linkPolling.Cancel();
                _linkDrawing.Cancel();

                _linkPolling.WaitEnd();
                _linkDrawing.WaitEnd();

                _linkPolling = null;
                _linkDrawing = null;
            }
        }

        private void DrawMeasures()
        {
            this.InvokeAuto(() =>
            {
                lblCpuLoad.Text = (_cpuAverage * 100).ToString("00") + "%";
                gphCpu.DrawCurves();
                gphPwmRight.DrawCurves();
                gphPwmLeft.DrawCurves();
                
                Image img = new Bitmap(Properties.Resources.Vumetre);
                Graphics g = Graphics.FromImage(img);
                g.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), 0, 0, 12, img.Height - (int)(_cpuAverage * img.Height));
                picVumetre.Image = img;
            });
        }

        private void Measure()
        {
            List<double>[] values = Robots.MainRobot.DiagnosticCpuPwm(30);
            _cpuAverage = values[0].Average();

            int min = Math.Min(values[0].Count, values[1].Count);
            min = Math.Min(min, values[2].Count);

            for (int i = 0; i < min; i++)
            {
                gphCpu.AddPoint("Charge CPU", values[0][i], Color.Green, true);

                gphPwmLeft.AddPoint("PWM Gauche", values[1][i], Color.Blue, true);
                gphPwmRight.AddPoint("PWM Droite", values[2][i], Color.Red, true);
            }
        }

        private void PanelDiagnosticMove_Load(object sender, EventArgs e)
        {
            if(!Execution.DesignMode)
            {
                gphCpu.MaxLimit = 1;
                gphCpu.MinLimit = 0;
                gphCpu.ScaleMode = Composants.GraphPanel.ScaleType.Fixed;
                gphCpu.NamesVisible = true;
                gphCpu.BorderVisible = true;
                gphCpu.BorderColor = Color.FromArgb(100, 100, 100);
                gphCpu.BackColor = Color.FromArgb(250, 250, 250);
                gphCpu.NamesAlignment = ContentAlignment.BottomLeft;

                gphPwmLeft.MaxLimit = 4000;
                gphPwmLeft.MinLimit = -4000;
                gphPwmLeft.ScaleMode = Composants.GraphPanel.ScaleType.Fixed;
                gphPwmLeft.NamesVisible = true;
                gphPwmLeft.BorderVisible = true;
                gphPwmLeft.BorderColor = Color.FromArgb(100, 100, 100);
                gphPwmLeft.BackColor = Color.FromArgb(250, 250, 250);
                gphPwmLeft.NamesAlignment = ContentAlignment.TopLeft;

                gphPwmRight.MaxLimit = 4000;
                gphPwmRight.MinLimit = -4000;
                gphPwmRight.ScaleMode = Composants.GraphPanel.ScaleType.Fixed;
                gphPwmRight.NamesVisible = true;
                gphPwmRight.BorderVisible = true;
                gphPwmRight.BorderColor = Color.FromArgb(100, 100, 100);
                gphPwmRight.BackColor = Color.FromArgb(250, 250, 250);
                gphPwmRight.NamesAlignment = ContentAlignment.BottomLeft;
            }
        }
    }
}
