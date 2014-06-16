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
            if (boxMiwi.Checked)
                Connexions.ConnexionMiwi.SendMessage(trame);
            if (boxIO.Checked)
                Connexions.ConnexionIO.SendMessage(trame);
            if (boxRecPi.Checked)
                Connexions.ConnexionPi.SendMessage(trame);
            if (boxRecBun.Checked)
                Connexions.ConnexionBun.SendMessage(trame);
            if (boxRecBeu.Checked)
                Connexions.ConnexionBeu.SendMessage(trame);
            if (boxRecBoi.Checked)
                Connexions.ConnexionBoi.SendMessage(trame);
        }

        private void PanelEnvoiUdp_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                switchBoutonBeu.SetActif(true, false);
                switchBoutonBoi.SetActif(true, false);
                switchBoutonBun.SetActif(true, false);
                switchBoutonMove.SetActif(true, false);
                switchBoutonMiwi.SetActif(true, false);
                switchBoutonIO.SetActif(true, false);
                switchBoutonPi.SetActif(true, false);

                lblIpRecMove.Text = Connexions.ConnexionMove.AdresseIp.ToString();
                lblEntreeRecMove.Text = Connexions.ConnexionMove.PortEntree.ToString();
                lblSortieRecMove.Text = Connexions.ConnexionMove.PortSortie.ToString();

                lblIpRecIO.Text = Connexions.ConnexionIO.AdresseIp.ToString();
                lblEntreeRecIO.Text = Connexions.ConnexionIO.PortEntree.ToString();
                lblSortieRecIO.Text = Connexions.ConnexionIO.PortSortie.ToString();

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

        Thread thTrames;

        private void ThreadEnvoi()
        {
            byte i = 0;
            while (true)
            {
                Connexions.ConnexionPi.SendMessage(new Trame("C3 " + i.ToString("00")), true);
                Thread.Sleep(10);
                i++;
                if (i == 100)
                    i = 0;
            }
            //Connexions.ConnexionPi.SendMessage(new Trame("C3 02"), true);
            //Connexions.ConnexionPi.SendMessage(new Trame("C3 03"), true);
            //Connexions.ConnexionPi.SendMessage(new Trame("C3 04"), true);
        }
        private void btnDebug_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int val = Convert.ToInt16(btn.Tag);

            if (val == 0)
            {

                thTrames = new Thread(ThreadEnvoi);
                thTrames.Start();
            }
            else

                Connexions.ConnexionPi.SendMessage(new Trame("C3 " + ("FF")), false);

            if (boxMove.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecMove, val);
                Connexions.ConnexionMove.SendMessage(trame);
            }
            if (boxMiwi.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecMiwi, val);
                Connexions.ConnexionMiwi.SendMessage(trame);
            }
            if (boxIO.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecIO, val);
                Connexions.ConnexionIO.SendMessage(trame);
            }
            if (boxRecPi.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecPi, val);
                Connexions.ConnexionPi.SendMessage(trame);
            }
            if (boxRecBun.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecBun, val);
                Connexions.ConnexionBun.SendMessage(trame);
            }
            if (boxRecBeu.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecBeu, val);
                Connexions.ConnexionBeu.SendMessage(trame);
            }
            if (boxRecBoi.Checked)
            {
                Trame trame = TrameFactory.Debug(Carte.RecBoi, val);
                Connexions.ConnexionBoi.SendMessage(trame);
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
                Trame trame = TrameFactory.TestConnexionMove(Robots.GrosRobot.TensionPack1 < Config.CurrentConfig.BatterieRobotOrange && Robots.GrosRobot.TensionPack2 < Config.CurrentConfig.BatterieRobotOrange);
                Connexions.ConnexionMove.SendMessage(trame);
            }
            if (boxMiwi.Checked)
            {
                Trame trame = TrameFactory.TestConnexionMiwi();
                Connexions.ConnexionMiwi.SendMessage(trame);
            }
            if (boxIO.Checked)
            {
                Trame trame = TrameFactory.TestConnexionIO();
                Connexions.ConnexionIO.SendMessage(trame);
            }
            if (boxRecPi.Checked)
            {
                Trame trame = TrameFactory.TestConnexionPi(Robots.PetitRobot.TensionPack1 < Config.CurrentConfig.BatterieRobotOrange && Robots.PetitRobot.TensionPack2 < Config.CurrentConfig.BatterieRobotOrange);
                Connexions.ConnexionPi.SendMessage(trame);
            }
            if (boxRecBun.Checked)
            {
                Trame trame = TrameFactory.BaliseTestConnexion(Carte.RecBun);
                Connexions.ConnexionBun.SendMessage(trame);
            }
            if (boxRecBeu.Checked)
            {
                Trame trame = TrameFactory.BaliseTestConnexion(Carte.RecBeu);
                Connexions.ConnexionBeu.SendMessage(trame);
            }
            if (boxRecBoi.Checked)
            {
                Trame trame = TrameFactory.BaliseTestConnexion(Carte.RecBoi);
                Connexions.ConnexionBoi.SendMessage(trame);
            }
        }

        private void switchBoutonConnexion_ChangementEtat(object sender, EventArgs e)
        {
            Connexions.ActivationConnexion[Carte.RecBun] = switchBoutonBun.Actif;
            Connexions.ActivationConnexion[Carte.RecBeu] = switchBoutonBeu.Actif;
            Connexions.ActivationConnexion[Carte.RecBoi] = switchBoutonBoi.Actif;
            Connexions.ActivationConnexion[Carte.RecMove] = switchBoutonMove.Actif;
            Connexions.ActivationConnexion[Carte.RecMiwi] = switchBoutonMiwi.Actif;
            Connexions.ActivationConnexion[Carte.RecIO] = switchBoutonIO.Actif;
            Connexions.ActivationConnexion[Carte.RecPi] = switchBoutonPi.Actif;
        }
    }
}
