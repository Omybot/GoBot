using System;
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
                Connexions.ConnexionMove.SendMessage(trame);
            if (boxIO.Checked)
                Connexions.ConnexionIO.SendMessage(trame);
            if (boxGB.Checked)
                Connexions.ConnexionGB.SendMessage(trame);
        }

        private void PanelEnvoiUdp_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                switchBoutonMove.SetActif(true, false);
                switchBoutonIO.SetActif(true, false);
                switchBoutonGB.SetActif(true, false);

                lblIpRecMove.Text = Connexions.ConnexionMove.AdresseIp.ToString();
                lblEntreeRecMove.Text = Connexions.ConnexionMove.PortEntree.ToString();
                lblSortieRecMove.Text = Connexions.ConnexionMove.PortSortie.ToString();

                lblIpRecIO.Text = Connexions.ConnexionIO.AdresseIp.ToString();
                lblEntreeRecIO.Text = Connexions.ConnexionIO.PortEntree.ToString();
                lblSortieRecIO.Text = Connexions.ConnexionIO.PortSortie.ToString();

                lblIpRecGB.Text = Connexions.ConnexionGB.AdresseIp.ToString();
                lbEntreeRecGB.Text = Connexions.ConnexionGB.PortEntree.ToString();
                lblSortieRecGB.Text = Connexions.ConnexionGB.PortSortie.ToString();

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

        Thread thTrames;

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int val = Convert.ToInt16(btn.Tag);

            if (boxMove.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecMove, val);
                Connexions.ConnexionMove.SendMessage(trame);
            }
            if (boxIO.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecIO, val);
                Connexions.ConnexionIO.SendMessage(trame);
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
                Trame trame = TrameFactory.TestConnexionMove(Robots.GrosRobot.BatterieVoltage < Config.CurrentConfig.BatterieRobotOrange && Robots.GrosRobot.BatterieVoltage < Config.CurrentConfig.BatterieRobotOrange);
                Connexions.ConnexionMove.SendMessage(trame);
            }
            if (boxIO.Checked)
            {
                Trame trame = TrameFactory.TestConnexionIO();
                Connexions.ConnexionIO.SendMessage(trame);
            }
        }

        private void switchBoutonConnexion_ChangementEtat(object sender, EventArgs e)
        {
            Connexions.ActivationConnexion[Carte.RecMove] = switchBoutonMove.Actif;
            Connexions.ActivationConnexion[Carte.RecIO] = switchBoutonIO.Actif;
            Connexions.ActivationConnexion[Carte.RecGB] = switchBoutonGB.Actif;
        }
    }
}
