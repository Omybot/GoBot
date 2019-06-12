using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PageLogsEvents : UserControl
    {
        private Dictionary<IDRobot, Color> couleurRobot;
        private Dictionary<TypeLog, Color> couleurTypeLog;

        private Dictionary<IDRobot, bool> dicRobotsAutorises;
        private Dictionary<TypeLog, bool> dicTypesAutorises;

        private DateTime dateDebut;
        private DateTime datePrec;
        private DateTime datePrecAff;
        private System.Windows.Forms.Timer timerAffichage;
        private bool affichageTempsReel = false;
        private int compteur = 0;
        private EventsReplay Replay { get; set; }

        public PageLogsEvents()
        {
            InitializeComponent();

            dataGridViewLog.Columns.Add("Id", "Id");
            dataGridViewLog.Columns[0].Width = 50;
            dataGridViewLog.Columns.Add("Heure", "Heure");
            dataGridViewLog.Columns[1].Width = 80;
            dataGridViewLog.Columns.Add("Robot", "Robot");
            dataGridViewLog.Columns[2].Width = 80;
            dataGridViewLog.Columns.Add("Type", "Type");
            dataGridViewLog.Columns[3].Width = 80;
            dataGridViewLog.Columns.Add("Message", "Message");
            dataGridViewLog.Columns[4].Width = 520;

            couleurRobot = new Dictionary<IDRobot, Color>();
            couleurRobot.Add(IDRobot.GrosRobot, Color.LightBlue);

            couleurTypeLog = new Dictionary<TypeLog, Color>();
            couleurTypeLog.Add(TypeLog.Action, Color.Lavender);
            couleurTypeLog.Add(TypeLog.PathFinding, Color.Khaki);
            couleurTypeLog.Add(TypeLog.Strat, Color.IndianRed);

            dicRobotsAutorises = new Dictionary<IDRobot, bool>();
            dicTypesAutorises = new Dictionary<TypeLog, bool>();

            // L'ajout de champs déclenche le SetCheck event qui ajoute les éléments automatiquement dans le dictionnaire
            foreach (TypeLog type in Enum.GetValues(typeof(TypeLog)))
            {
                checkedListBoxEvents.Items.Add(type.ToString(), true);
            }
            foreach (IDRobot robot in Enum.GetValues(typeof(IDRobot)))
            {
                checkedListBoxRobots.Items.Add(robot.ToString(), true);
            }
            Replay = new EventsReplay();
        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichiers replay events (*.elog)|*.elog";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {

                foreach(String fichier in open.FileNames)
                {
                    ChargerLog(fichier);
                }
                Replay.Trier();
                Afficher();
            }
        }

        public void Clear()
        {
            Replay = new EventsReplay();
        }

        public void ChargerLog(String fichier)
        {
            EventsReplay replayTemp = new EventsReplay();
            replayTemp.Charger(fichier);

            foreach (HistoLigne t in replayTemp.Events)
                Replay.Events.Add(t);
        }

        public void Afficher()
        {
            try
            {
                dataGridViewLog.Rows.Clear();

                if (Replay.Events.Count > 0)
                {

                    dateDebut = Replay.Events[0].Heure;
                    datePrec = Replay.Events[0].Heure;
                    datePrecAff = Replay.Events[0].Heure;
                    compteur = 0;

                    for (int iTrame = 0; iTrame < Replay.Events.Count; iTrame++)
                        AfficherEvent(Replay.Events[iTrame]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de décoder tous les events contenus dans ce fichier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Afficher();
        }

        private void checkedListBoxRobots_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode)
            {
                String robotString = (String)checkedListBoxRobots.Items[e.Index];
                IDRobot robot = (IDRobot)Enum.Parse(typeof(IDRobot), robotString);

                dicRobotsAutorises[robot] = (e.NewValue == CheckState.Checked);
            }
        }

        private void checkedListBoxEvents_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode)
            {
                String typeString = (String)checkedListBoxEvents.Items[e.Index];
                TypeLog type = (TypeLog)Enum.Parse(typeof(TypeLog), typeString);

                dicTypesAutorises[type] = (e.NewValue == CheckState.Checked);
            }
        }

        private void dataGridViewLog_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex > 0 && e.ColumnIndex > 0)
                dataGridViewLog.CurrentCell = dataGridViewLog.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            if (!affichageTempsReel)
            {
                Replay = new EventsReplay();
                timerAffichage = new System.Windows.Forms.Timer();
                timerAffichage.Interval = 1000;
                timerAffichage.Tick += timerAffichage_Tick;
                timerAffichage.Start();

                Robots.GrosRobot.Historique.NouveauLog += Replay.AjouterEvent;
                
                btnCharger.Enabled = false;
                btnAfficher.Text = "Arrêter l'affichage";
                btnAfficher.Image = Properties.Resources.Pause16;
                affichageTempsReel = true;
            }
            else
            {
                timerAffichage.Stop();

                Robots.GrosRobot.Historique.NouveauLog -= Replay.AjouterEvent;

                btnCharger.Enabled = true;
                btnAfficher.Text = "Afficher temps réel";
                btnAfficher.Image = Properties.Resources.Play16;
                affichageTempsReel = false;
            }
        }

        void timerAffichage_Tick(object sender, EventArgs e)
        {
            int nbEvents = Replay.Events.Count;
            for (int i = compteur; i < nbEvents; i++)
                AfficherEvent(Replay.Events[i]);

            if(boxScroll.Checked && dataGridViewLog.Rows.Count > 10)
                dataGridViewLog.FirstDisplayedScrollingRowIndex = dataGridViewLog.RowCount - 1;
        }

        private void AfficherEvent(HistoLigne eventReplay)
        {
            String heure = "";

            if (rdoHeure.Checked)
                heure = eventReplay.Heure.ToString("hh:mm:ss:fff");
            if (rdoTempsDebut.Checked)
                heure = (eventReplay.Heure - dateDebut).ToString(@"hh\:mm\:ss\:fff");
            if (rdoTempsPrec.Checked)
                heure = (eventReplay.Heure - datePrec).ToString(@"hh\:mm\:ss\:fff");
            if (rdoTempsPrecAff.Checked)
                heure = (eventReplay.Heure - datePrecAff).ToString(@"hh\:mm\:ss\:fff");

            if (dicRobotsAutorises[eventReplay.Robot] && dicTypesAutorises[eventReplay.Type])
            {
                dataGridViewLog.Rows.Add(compteur, heure, eventReplay.Robot.ToString(), eventReplay.Type.ToString(), eventReplay.Message);
                datePrecAff = eventReplay.Heure;

                if (rdoRobot.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurRobot[eventReplay.Robot];
                else if (rdoType.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurTypeLog[eventReplay.Type];
            }

            compteur++;

            datePrec = eventReplay.Heure;
        }
    }
}
