﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;
using System.Net;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelEnvoiUdp : UserControl
    {
        public PanelEnvoiUdp()
        {
            InitializeComponent();
        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            Trame trame = null;
            try
            {
                trame = new Trame(txtTrame.Text);
            }
            catch (Exception)
            {
                txtTrame.ErrorMode = true;
                return;
            }

            if (boxMove.Checked)
                Connections.ConnectionMove.SendMessage(trame);
            if (boxIO.Checked)
                Connections.ConnectionIO.SendMessage(trame);
            if (boxGB.Checked)
                Connections.ConnectionGB.SendMessage(trame);
        }

        private void PanelEnvoiUdp_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                switchBoutonMove.SetActif(true, false);
                switchBoutonIO.SetActif(true, false);
                switchBoutonGB.SetActif(true, false);

                foreach (ConnexionUDP conn in Connections.AllConnections)
                {
                    ConnectionDetails details = new ConnectionDetails();
                    details.Connection = conn;
                    _pnlConnections.Controls.Add(details);
                }

                IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

                bool ipTrouvee = false;
                foreach (IPAddress ip in adresses)
                {
                    if (ip.ToString().Length > 7)
                    {
                        String ipString = ip.ToString().Substring(0, 7);
                        if (ipString == "10.1.0.")
                        {
                            lblMonIP.Text = ip.ToString();
                            ipTrouvee = true;
                        }
                    }
                }

                if (!ipTrouvee)
                {
                    lblMonIP.Text = "Incorrecte";
                    lblMonIP.ForeColor = Color.Red;
                }
            }
        }
        
        private void btnDebug_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int val = Convert.ToInt16(btn.Tag);

            if (boxMove.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecMove, val);
                Connections.ConnectionMove.SendMessage(trame);
            }
            if (boxIO.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecIO, val);
                Connections.ConnectionIO.SendMessage(trame);
            }
            if (boxGB.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecGB, val);
                Connections.ConnectionGB.SendMessage(trame);
            }
        }

        private System.Windows.Forms.Timer timerTestConnexion;
        private void btnSendTest_Click(object sender, EventArgs e)
        {
            if (btnSendTest.Text == "Envoyer")
            {
                btnSendTest.Text = "Stop";

                timerTestConnexion = new System.Windows.Forms.Timer();
                timerTestConnexion.Interval = (int)numIntervalleTest.Value;
                timerTestConnexion.Tick += new EventHandler(timerTestConnexion_Tick);

                timerTestConnexion.Start();
            }
            else
            {
                btnSendTest.Text = "Envoyer";
                timerTestConnexion.Stop();
            }
        }

        void timerTestConnexion_Tick(object sender, EventArgs e)
        {
            if (boxMove.Checked)
            {
                Trame trame = TrameFactory.TestConnexion(Carte.RecMove);
                Connections.ConnectionMove.SendMessage(trame);
            }
            if (boxIO.Checked)
            {
                Trame trame = TrameFactory.TestConnexion(Carte.RecIO);
                Connections.ConnectionIO.SendMessage(trame);
            }
            if (boxGB.Checked)
            {
                Trame trame = TrameFactory.TestConnexion(Carte.RecGB);
                Connections.ConnectionGB.SendMessage(trame);
            }
        }

        private void switchBoutonConnexion_ChangementEtat(object sender, EventArgs e)
        {
            Connections.EnableConnection[Carte.RecMove] = switchBoutonMove.Actif;
            Connections.EnableConnection[Carte.RecIO] = switchBoutonIO.Actif;
            Connections.EnableConnection[Carte.RecGB] = switchBoutonGB.Actif;
        }
    }
}
