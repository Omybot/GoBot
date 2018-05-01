using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelLogThreads : UserControl
    {
        private System.Windows.Forms.Timer _timerDisplay;

        public PanelLogThreads()
        {
            InitializeComponent();
        }

        private void PanelLogThreads_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                dataGridViewLog.Columns.Add("Id", "Id");
                dataGridViewLog.Columns[0].Width = 30;
                dataGridViewLog.Columns.Add("Nom", "Nom");
                dataGridViewLog.Columns[1].Width = 200;
                dataGridViewLog.Columns.Add("Etat", "Etat");
                dataGridViewLog.Columns[2].Width = 140;
                dataGridViewLog.Columns.Add("Début", "Début");
                dataGridViewLog.Columns[3].Width = 50;
                dataGridViewLog.Columns.Add("Fin", "Fin");
                dataGridViewLog.Columns[4].Width = 50;
                dataGridViewLog.Columns.Add("Durée", "Durée");
                dataGridViewLog.Columns[5].Width = 75;
                dataGridViewLog.Columns.Add("Executions", "Executions");
                dataGridViewLog.Columns[6].Width = 65;
            }
        }

        private void _timerDisplay_Tick(object sender, EventArgs e)
        {
            dataGridViewLog.Rows.Clear();

            foreach (ThreadLink link in ThreadManager.ThreadsLink)
            {
                int row = dataGridViewLog.Rows.Add(
                    link.Id.ToString(), 
                    link.Name, 
                    GetLinkState(link), 
                    link.Started ? link.StartDate.ToString("HH:mm:ss") : "", 
                    link.Ended ? link.EndDate.ToString("HH:mm:ss") : "", 
                    link.Duration.ToString(@"hh\:mm\:ss\.fff"), 
                    (link.LoopsCount > 0 ? link.LoopsCount.ToString() : "") + (link.LoopsTarget > 0 ? " / " + link.LoopsTarget.ToString() : ""));

                dataGridViewLog.Rows[row].DefaultCellStyle.BackColor = GetLinkColor(link);
            }
        }

        private string GetLinkState(ThreadLink link)
        {
            String state = "";

            if (!link.Started)
                state = "Initialisé";
            else if (link.Ended)
                state = "Terminé";
            else if (link.Cancelled)
                state = "Annulé";
            else if (link.LoopPaused)
                state = "En pause";
            else
                state = "En cours d'execution";

            return state;
        }

        private ColorPlus GetLinkColor(ThreadLink link)
        {
            ColorPlus color;

            if (!link.Started)
                color = ColorPlus.GetVeryLight(Color.Purple);
            else if (link.Ended)
                color = Color.LightGray;
            else if (link.Cancelled)
                color = ColorPlus.GetVeryLight(Color.Red);
            else if (link.LoopPaused)
                color = ColorPlus.GetVeryLight(Color.Orange);
            else
                color = ColorPlus.GetVeryLight(Color.Green);

            return color;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(_timerDisplay == null || _timerDisplay.Enabled == false)
            {
                _timerDisplay = new Timer();
                _timerDisplay.Interval = 1000;
                _timerDisplay.Tick += _timerDisplay_Tick;
                _timerDisplay.Start();

                btnStart.Text = "Stop";
                btnStart.Image = Properties.Resources.Pause16;
            }
            else
            {
                _timerDisplay.Stop();

                btnStart.Text = "Afficher";
                btnStart.Image = Properties.Resources.Play16;
            }
        }
    }
}
