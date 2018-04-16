using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelTestServos : UserControl
    {
        public PanelTestServos()
        {
            InitializeComponent();
            foreach (ServoBaudrate baudrate in Enum.GetValues(typeof(ServoBaudrate)))
                checkedListBoxBaudrates.Items.Add(baudrate.ToString().Substring(1), true);
        }
        
        bool searching;

        private void SearchLoop()
        {
            btnChercher.Text = "Stop";
            listBoxServos.Items.Clear();

            progressBarBaudrate.Value = 0;
            int iBaudrate = 0;
            foreach (ServoBaudrate baudrate in Enum.GetValues(typeof(ServoBaudrate)))
            {
                if (searching && checkedListBoxBaudrates.CheckedIndices.Contains(iBaudrate))
                {
                    Connections.ConnectionIO.SendMessage(FrameFactory.ChangementBaudrate(baudrate));
                    Thread.Sleep(100);

                    //Servomoteur servoAll = new Servomoteur(Carte.RecIO, 254, 0);
                    //if (servoAll.Connecte)
                    {
                        progressBarId.Value = 0;
                        for (int i = 1; i <= 253; i++)
                        {
                            progressBarId.Value++;
                            lblScannId.Text = "ID : " + i.ToString();
                            lblScannBaudrate.Text = "Baud : " + baudrate.ToString().Substring(1);
                            Servomoteur servo = new Servomoteur(Board.RecIO, i, 0);
                            if (servo.Connecte)
                                listBoxServos.Items.Add(new Servomoteur(Board.RecIO, i, baudrate));
                        }
                    }
                }

                progressBarBaudrate.Value++;
                iBaudrate++;
            }

            progressBarId.Value = 0;
            progressBarBaudrate.Value = 0;
            btnChercher.Text = "Chercher servomoteurs";
        }

        private void btnChercher_Click(object sender, EventArgs e)
        {
            if (searching)
            {
                searching = false;
            }
            else
            {
                searching = true;
                ThreadPool.QueueUserWorkItem(f => SearchLoop());
            }
        }

        private void listBoxServos_SelectedValueChanged(object sender, EventArgs e)
        {
            Servomoteur servo = (Servomoteur)listBoxServos.SelectedItem;
            Connections.ConnectionIO.SendMessage(FrameFactory.ChangementBaudrate(servo.Baudrate));
            panelServo.AfficherServo(servo);
        }
    }
}
