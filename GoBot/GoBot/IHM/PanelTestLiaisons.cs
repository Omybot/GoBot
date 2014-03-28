using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelTestLiaisons : UserControl
    {
        List<LiaisonDataCheck> Liaisons { get; set; }
        Timer Timer { get; set; }
        Timer TimerIhm { get; set; }

        public PanelTestLiaisons()
        {
            InitializeComponent();
            Timer = null;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Timer == null)
            {
                Liaisons = new List<LiaisonDataCheck>();

                Liaisons.Add(new LiaisonDataCheck(Connexions.ConnexionMiwi, Carte.RecBun));
                Liaisons.Add(new LiaisonDataCheck(Connexions.ConnexionMiwi, Carte.RecBeu));
                Liaisons.Add(new LiaisonDataCheck(Connexions.ConnexionMiwi, Carte.RecBoi));
                Liaisons.Add(new LiaisonDataCheck(Connexions.ConnexionMiwi, Carte.RecPi));

                Connexions.ConnexionMiwi.NouvelleTrameRecue += Liaisons[0].MessageRecu;
                Connexions.ConnexionMiwi.NouvelleTrameRecue += Liaisons[1].MessageRecu;
                Connexions.ConnexionMiwi.NouvelleTrameRecue += Liaisons[2].MessageRecu;
                Connexions.ConnexionMiwi.NouvelleTrameRecue += Liaisons[3].MessageRecu;

                Timer = new Timer();
                Timer.Interval = 200;
                Timer.Tick += new EventHandler(Timer_Tick);

                TimerIhm = new Timer();
                TimerIhm.Interval = 1000;
                TimerIhm.Tick += new EventHandler(TimerIhm_Tick);

                btnStart.Text = "Stop";

                Timer.Start();
                TimerIhm.Start();
            }
            else
            {
                Timer.Stop();
                Timer = null;
                TimerIhm.Stop();
                btnStart.Text = "Lancer";
            }
        }

        void TimerIhm_Tick(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                lblB1Corrects.Text = Liaisons[0].NombreMessagesCorrects + " -  " + (Liaisons[0].NombreMessagesCorrects * 100.0 / (double)Liaisons[0].NombreMessagesTotal).ToString("#.##");
                lblB1CorrompusEmission.Text = Liaisons[0].NombreMessagesCorrompusEmission + " -  " + (Liaisons[0].NombreMessagesCorrompusEmission * 100.0 / (double)Liaisons[0].NombreMessagesTotal).ToString("#.##");
                lblB1CorrompusReception.Text = Liaisons[0].NombreMessagesCorrompusReception + " -  " + (Liaisons[0].NombreMessagesCorrompusReception * 100.0 / (double)Liaisons[0].NombreMessagesTotal).ToString("#.##");
                lblB1Nombre.Text = Liaisons[0].NombreMessagesTotal.ToString();
                lblB1PerdusEmission.Text = Liaisons[0].NombreMessagesPerdusEmission + " -  " + (Liaisons[0].NombreMessagesPerdusEmission * 100.0 / (double)Liaisons[0].NombreMessagesTotal).ToString("#.##");
                lblB1PerdusReception.Text = Liaisons[0].NombreMessagesPerdusReception + " -  " + (Liaisons[0].NombreMessagesPerdusReception * 100.0 / (double)Liaisons[0].NombreMessagesTotal).ToString("#.##");

                lblB2Corrects.Text = Liaisons[1].NombreMessagesCorrects + " -  " + (Liaisons[1].NombreMessagesCorrects * 100.0 / (double)Liaisons[1].NombreMessagesTotal).ToString("#.##");
                lblB2CorrompusEmission.Text = Liaisons[1].NombreMessagesCorrompusEmission + " -  " + (Liaisons[1].NombreMessagesCorrompusEmission * 100.0 / (double)Liaisons[1].NombreMessagesTotal).ToString("#.##");
                lblB2CorrompusReception.Text = Liaisons[1].NombreMessagesCorrompusReception + " -  " + (Liaisons[1].NombreMessagesCorrompusReception * 100.0 / (double)Liaisons[1].NombreMessagesTotal).ToString("#.##");
                lblB2Nombre.Text = Liaisons[1].NombreMessagesTotal.ToString();
                lblB2PerdusEmission.Text = Liaisons[1].NombreMessagesPerdusEmission + " -  " + (Liaisons[1].NombreMessagesPerdusEmission * 100.0 / (double)Liaisons[1].NombreMessagesTotal).ToString("#.##");
                lblB2PerdusReception.Text = Liaisons[1].NombreMessagesPerdusReception + " -  " + (Liaisons[1].NombreMessagesPerdusReception * 100.0 / (double)Liaisons[1].NombreMessagesTotal).ToString("#.##");
                
                lblB3Corrects.Text = Liaisons[2].NombreMessagesCorrects + " -  " + (Liaisons[2].NombreMessagesCorrects * 100.0 / (double)Liaisons[2].NombreMessagesTotal).ToString("#.##");
                lblB3CorrompusEmission.Text = Liaisons[2].NombreMessagesCorrompusEmission + " -  " + (Liaisons[2].NombreMessagesCorrompusEmission * 100.0 / (double)Liaisons[2].NombreMessagesTotal).ToString("#.##");
                lblB3CorrompusReception.Text = Liaisons[2].NombreMessagesCorrompusReception + " -  " + (Liaisons[2].NombreMessagesCorrompusReception * 100.0 / (double)Liaisons[2].NombreMessagesTotal).ToString("#.##");
                lblB3Nombre.Text = Liaisons[2].NombreMessagesTotal.ToString();
                lblB3PerdusEmission.Text = Liaisons[2].NombreMessagesPerdusEmission + " -  " + (Liaisons[2].NombreMessagesPerdusEmission * 100.0 / (double)Liaisons[2].NombreMessagesTotal).ToString("#.##");
                lblB3PerdusReception.Text = Liaisons[2].NombreMessagesPerdusReception + " -  " + (Liaisons[2].NombreMessagesPerdusReception * 100.0 / (double)Liaisons[2].NombreMessagesTotal).ToString("#.##");

                lblPRCorrects.Text = Liaisons[3].NombreMessagesCorrects + " -  " + (Liaisons[3].NombreMessagesCorrects * 100.0 / (double)Liaisons[3].NombreMessagesTotal).ToString("#.##");
                lblPRCorrompusEmission.Text = Liaisons[3].NombreMessagesCorrompusEmission + " -  " + (Liaisons[3].NombreMessagesCorrompusEmission * 100.0 / (double)Liaisons[3].NombreMessagesTotal).ToString("#.##");
                lblPRCorrompusReception.Text = Liaisons[3].NombreMessagesCorrompusReception + " -  " + (Liaisons[3].NombreMessagesCorrompusReception * 100.0 / (double)Liaisons[3].NombreMessagesTotal).ToString("#.##");
                lblPRNombre.Text = Liaisons[3].NombreMessagesTotal.ToString();
                lblPRPerdusEmission.Text = Liaisons[3].NombreMessagesPerdusEmission + " -  " + (Liaisons[3].NombreMessagesPerdusEmission * 100.0 / (double)Liaisons[3].NombreMessagesTotal).ToString("#.##");
                lblPRPerdusReception.Text = Liaisons[3].NombreMessagesPerdusReception + " -  " + (Liaisons[3].NombreMessagesPerdusReception * 100.0 / (double)Liaisons[3].NombreMessagesTotal).ToString("#.##");
       
            }));
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Liaisons.Count; i++)
                Liaisons[i].EnvoiTest();
        }
    }
}
