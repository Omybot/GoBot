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
                Connexions.ConnexionMove.SendMessage(trame);
            if (boxMiwi.Checked)
                Connexions.ConnexionMiwi.SendMessage(trame);
        }

        private void PanelEnvoiUdp_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                lblIpRecMove.Text = Connexions.ConnexionMove.AdresseIp.ToString();
                lblEntreeRecMove.Text = Connexions.ConnexionMove.PortEntree.ToString();
                lblSortieRecMove.Text = Connexions.ConnexionMove.PortSortie.ToString();

                lblIpRecMiwi.Text = Connexions.ConnexionMiwi.AdresseIp.ToString();
                lblEntreeRecMiwi.Text = Connexions.ConnexionMiwi.PortEntree.ToString();
                lblSortieRecMiwi.Text = Connexions.ConnexionMiwi.PortSortie.ToString();

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
    }
}
