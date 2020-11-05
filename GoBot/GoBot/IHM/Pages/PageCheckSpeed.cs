using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PageCheckSpeed : UserControl
    {
        public PageCheckSpeed()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Threading.ThreadManager.CreateThread(link =>
            {
                List<int>[] vals = Robots.MainRobot.DiagnosticLine((int)numDistance.Value, SensAR.Arriere);
                SetPoints(vals[0], vals[1]);
            }).StartThread();
        }

        private void SetPoints(List<int> left, List<int> right)
        {
            List<double> posLeft = Smooth(TargetCount(left.ConvertAll(v => (double)v), gphPos.Width), 30);
            List<double> posRight = Smooth(TargetCount(right.ConvertAll(v => (double)v), gphPos.Width), 30);
            List<double> speedLeft = Derivation(posLeft, 30);
            List<double> speedRight = Derivation(posRight, 30);
            List<double> accelLeft = Derivation(speedLeft, 30);
            List<double> accelRight = Derivation(speedRight, 30);

            gphPos.DeleteCurve("Gauche pos.");
            gphPos.DeleteCurve("Droite pos.");
            gphPos.DeleteCurve("Gauche Vit.");
            gphPos.DeleteCurve("Droite Vit.");
            gphPos.DeleteCurve("Gauche Accel.");
            gphPos.DeleteCurve("Droite Accel.");

            for (int i = 0; i < posLeft.Count; i++)
            {
                gphPos.AddPoint("Gauche pos.", posLeft[i], Color.Lime, false);
                gphPos.AddPoint("Droite pos.", posRight[i], Color.OrangeRed, false);
                gphPos.AddPoint("Gauche Vit.", speedLeft[i], Color.Green, false);
                gphPos.AddPoint("Droite Vit.", speedRight[i], Color.Red, false);
                gphPos.AddPoint("Gauche Accel.", accelLeft[i], Color.DarkGreen, false);
                gphPos.AddPoint("Droite Accel.", accelRight[i], Color.DarkRed, false);
            }

            gphPos.DrawCurves();
        }

        private List<double> Derivation(List<double> values, int interval = 1)
        {
            List<double> output = new List<double>();

            for (int i = 0; i < values.Count; i++)
            {
                output.Add(values[Math.Min(i + interval, values.Count - 1)] - values[i]);
            }

            return output;
        }

        private List<double> TargetCount(List<double> values, int count)
        {
            List<double> output;

            if (values.Count > count)
            {
                output = new List<double>();
                int avg = (int)Math.Ceiling((double)values.Count / count);
                for (int i = 0; i < values.Count - avg; i++)
                {
                    output.Add(values.GetRange(i, avg).Average());
                }
            }
            else
            {
                output = new List<double>(values);

                while (values.Count < count / 2)
                {
                    output = new List<double>();

                    for (int i = 0; i < values.Count - 1; i++)
                    {
                        output.Add(values[i]);
                        output.Add((values[i] + values[i + 1]) / 2);
                    }

                    values = output;
                }
            }

            return output;
        }

        private List<double> Smooth(List<double> values, int count)
        {
            List<double> output = new List<double>();

            for (int i = 0; i < values.Count - count; i++)
                output.Add(values.GetRange(i, count).Average());

            return output;
        }
    }
}
