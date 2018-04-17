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
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelTestServos : UserControl
    {
        private ThreadLink _linkSearch;

        public PanelTestServos()
        {
            InitializeComponent();
            foreach (ServoBaudrate baudrate in Enum.GetValues(typeof(ServoBaudrate)))
                checkedListBoxBaudrates.Items.Add(baudrate.ToString().Substring(1), true);
        }
        
        private void SearchLoop()
        {
            this.InvokeAuto(() =>
            {
                btnChercher.Text = "Stop";
                listBoxServos.Items.Clear();
                progressBarBaudrate.Value = 0;
            });

            int iBaudrate = 0;

            foreach (ServoBaudrate baudrate in Enum.GetValues(typeof(ServoBaudrate)))
            {
                if (!_linkSearch.Cancelled && checkedListBoxBaudrates.CheckedIndices.Contains(iBaudrate))
                {
                    Connections.ConnectionIO.SendMessage(FrameFactory.ChangementBaudrate(baudrate));
                    Thread.Sleep(100);

                    //Servomoteur servoAll = new Servomoteur(Carte.RecIO, 254, 0);
                    //if (servoAll.Connecte)
                    {
                        this.InvokeAuto(() => progressBarId.Value = 0);

                        for (int i = 1; i <= 253; i++)
                        {
                            this.InvokeAuto(() =>
                            {
                                progressBarId.Value++;
                                lblScannId.Text = "ID : " + i.ToString();
                                lblScannBaudrate.Text = "Baud : " + baudrate.ToString().Substring(1);
                                Servomoteur servo = new Servomoteur(Board.RecIO, i, 0);
                                if (servo.Connecte)
                                    listBoxServos.Items.Add(new Servomoteur(Board.RecIO, i, baudrate));
                            });
                        }
                    }
                }

                this.InvokeAuto(() =>
                {
                    progressBarBaudrate.Value++;
                    iBaudrate++;
                });
            }

            this.InvokeAuto(() =>
            {
                progressBarId.Value = 0;
                progressBarBaudrate.Value = 0;
                btnChercher.Text = "Chercher servomoteurs";
            });
        }

        private void btnChercher_Click(object sender, EventArgs e)
        {
            if(_linkSearch != null)
            {
                _linkSearch.Cancel();
                _linkSearch.WaitEnd();
                _linkSearch = null;
            }
            else
            {
                _linkSearch = ThreadManager.StartThread(link => SearchLoop());
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
