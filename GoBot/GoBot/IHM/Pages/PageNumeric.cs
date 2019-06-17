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
    public partial class PanelBoardNumeric : UserControl
    {
        private ThreadLink _link;
        private Board _board;

        public PanelBoardNumeric()
        {
            InitializeComponent();

            //byteBinaryGraphA1.SetNames(new List<String>() { "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7" });
            //byteBinaryGraphA2.SetNames(new List<String>() { "A8", "A9", "A10", "A11", "A12", "A13", "A14", "A15" });

            //byteBinaryGraphB1.SetNames(new List<String>() { "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7" });
            //byteBinaryGraphB2.SetNames(new List<String>() { "B8", "B9", "B10", "B11", "B12", "B13", "B14", "B15" });

            //byteBinaryGraphC1.SetNames(new List<String>() { "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7" });
            //byteBinaryGraphC2.SetNames(new List<String>() { "C8", "C9", "C10", "C11", "C12", "C13", "C14", "C15" });
            
            byteBinaryGraphA1.SetNames(new List<String>() { "A0", "A1", "A2", "A3", "Ethernet reset", "A5", "A6", "A7" });
            byteBinaryGraphA2.SetNames(new List<String>() { "PWM balise", "Ethernet CS", "A10", "A11", "A12", "A13", "A14", "A15" });

            byteBinaryGraphB1.SetNames(new List<String>() { "B0", "B1", "B2", "Lidar TX", "Top tour", "B5", "B6", "Ethernet INT" });
            byteBinaryGraphB2.SetNames(new List<String>() { "Codeur 1B", "Codeur 1A", "Moteur 2 H", "Moteur 2 L", "Moteur 3 H", "Moteur 3 L", "Moteur 4 H", "Moteur 4 L" });

            byteBinaryGraphC1.SetNames(new List<String>() { "Lidar RX", "Laser 1", "Laser 2", "Ethernet SCK", "Ethernet MOSI", "Ethernet MISO", "Moteur 1 H", "Moteur 1 L" });
            byteBinaryGraphC2.SetNames(new List<String>() { "Codeur 2 A", "Codeur 2 B", "C10", "C11", "C12", "C13", "C14", "C15" });
        }
        
        private void AskValues()
        {
            Robots.GrosRobot.DemandeValeursNumeriques(_board, true);

            lock (Robots.GrosRobot.ValeursNumeriques)
            {
                if (switchButtonPortA.Value)
                {
                    byteBinaryGraphA1.SetValue(Robots.GrosRobot.ValeursNumeriques[_board][1]);
                    byteBinaryGraphA2.SetValue(Robots.GrosRobot.ValeursNumeriques[_board][0]);
                }
                if (switchButtonPortB.Value)
                {
                    byteBinaryGraphB1.SetValue(Robots.GrosRobot.ValeursNumeriques[_board][3]);
                    byteBinaryGraphB2.SetValue(Robots.GrosRobot.ValeursNumeriques[_board][2]);
                }
                if (switchButtonPortC.Value)
                {
                    byteBinaryGraphC1.SetValue(Robots.GrosRobot.ValeursNumeriques[_board][5]);
                    byteBinaryGraphC2.SetValue(Robots.GrosRobot.ValeursNumeriques[_board][4]);
                }
            }
        }

        public void SetBoard(Board board)
        {
            _board = board;
        }

        private void switchButtonPort_ValueChanged(object sender, bool value)
        {
            if ((switchButtonPortA.Value || switchButtonPortB.Value || switchButtonPortC.Value) && _link  == null)
            {
                _link = ThreadManager.CreateThread(link => AskValues());
                _link.Name = "Ports numériques " + _board.ToString();
                _link.StartInfiniteLoop(50);
            }

            if (!switchButtonPortA.Value & !switchButtonPortB.Value & !switchButtonPortC.Value & _link != null)
            {
                _link.Cancel();
                _link.WaitEnd();
                _link = null;
            }
        }
    }
}
