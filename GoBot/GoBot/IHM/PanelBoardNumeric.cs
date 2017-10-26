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
    public partial class PanelBoardNumeric : UserControl
    {
        private System.Timers.Timer timerValues;

        public PanelBoardNumeric()
        {
            InitializeComponent();
            
            timerValues = new System.Timers.Timer(50);
            timerValues.Elapsed += new ElapsedEventHandler(timerValues_Elapsed);

            byteBinaryGraphA1.SetNames(new List<String>() { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" });
            byteBinaryGraphA2.SetNames(new List<String>() { "A9", "A10", "A11", "A12", "A13", "A14", "A15", "A16" });

            byteBinaryGraphB1.SetNames(new List<String>() { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8" });
            byteBinaryGraphB2.SetNames(new List<String>() { "B9", "B10", "B11", "B12", "B13", "B14", "B15", "B16" });

            byteBinaryGraphC1.SetNames(new List<String>() { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8" });
            byteBinaryGraphC2.SetNames(new List<String>() { "C9", "C10", "C11", "C12", "C13", "C14", "C15", "C16" });
        }

        public Board Board { get; set; }

        void timerValues_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Execution.Shutdown)
                return;

            Robots.GrosRobot.DemandeValeursNumeriques(Board, true);

            if (switchButtonPortA.Value)
            {
                byteBinaryGraphA1.SetValue(Robots.GrosRobot.ValeursNumeriques[Board][0]);
                byteBinaryGraphA2.SetValue(Robots.GrosRobot.ValeursNumeriques[Board][1]);
            }
            if (switchButtonPortB.Value)
            {
                byteBinaryGraphB1.SetValue(Robots.GrosRobot.ValeursNumeriques[Board][2]);
                byteBinaryGraphB2.SetValue(Robots.GrosRobot.ValeursNumeriques[Board][3]);
            }
            if (switchButtonPortC.Value)
            {
                byteBinaryGraphC1.SetValue(Robots.GrosRobot.ValeursNumeriques[Board][4]);
                byteBinaryGraphC2.SetValue(Robots.GrosRobot.ValeursNumeriques[Board][5]);
            }
        }

        private void switchButtonPort_ValueChanged(object sender, bool value)
        {
            if ((switchButtonPortA.Value | switchButtonPortB.Value | switchButtonPortC.Value) & !timerValues.Enabled)
                timerValues.Start();

            if (!switchButtonPortA.Value & !switchButtonPortB.Value & !switchButtonPortC.Value & timerValues.Enabled)
                timerValues.Stop();
        }
    }
}
