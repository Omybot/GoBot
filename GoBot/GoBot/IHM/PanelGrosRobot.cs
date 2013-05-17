using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM
{
    public partial class PanelGrosRobot : UserControl
    {
        private Dictionary<TypeLog, Color> CouleursLog { get; set; }

        public PanelGrosRobot()
        {
            InitializeComponent();

            panelHistorique.Deployer(Config.CurrentConfig.HistoriqueGROuvert);
            CouleursLog = new Dictionary<TypeLog, Color>();
            CouleursLog.Add(TypeLog.Action, Color.Blue);
            CouleursLog.Add(TypeLog.PathFinding, Color.Green);
            CouleursLog.Add(TypeLog.Strat, Color.Red);
        }

        public void Init()
        {
            panelDeplacement.Robot = Robots.GrosRobot;
            panelDeplacement.Init();
            panelHistorique.setHistorique(Robots.GrosRobot.Historique);
            Robots.GrosRobot.Historique.NouveauLog += new Historique.DelegateLog(MAJLog);
        }

        private void AddText(String message, Color couleur)
        {
            String texte = message + Environment.NewLine;
            txtLog.SuspendLayout();

            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectedText = texte;

            txtLog.SelectionStart = txtLog.TextLength - texte.Length + 1;
            txtLog.SelectionLength = texte.Length;
            txtLog.SelectionColor = couleur;

            txtLog.ResumeLayout();

            txtLog.Select(txtLog.TextLength, 0);

            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void MAJLog(HistoLigne ligne)
        {
            this.Invoke(new EventHandler(delegate
                {
                    if ((boxStrat.Checked && ligne.Type == TypeLog.Strat) ||
                        (boxActions.Checked && ligne.Type == TypeLog.Action) ||
                        (boxPathFinding.Checked && ligne.Type == TypeLog.PathFinding))
                    {
                        TimeSpan t = new TimeSpan();
                        if (Plateau.Enchainement != null && Plateau.Enchainement.DebutMatch != null)
                            t = ligne.Heure - Plateau.Enchainement.DebutMatch;
                        AddText((boxHeure.Checked ? t.Minutes + ":" + t.Seconds + ":" + t.Milliseconds : "") + " > " + ligne.Message, CouleursLog[ligne.Type]);
                    }
                }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Config.Save();
            Control parent = Parent;
            while(parent.Parent != null)
                parent = parent.Parent;

            if(parent != null)
                parent.Dispose();
        }

        private void panelHistorique_Resize(object sender, EventArgs e)
        {
            if (panelHistorique.Height > 50)
                Config.CurrentConfig.HistoriqueGROuvert = true;
            else
                Config.CurrentConfig.HistoriqueGROuvert = false;
        }

        private void boxStrat_CheckedChanged(object sender, EventArgs e)
        {
            MAJLog();
        }

        private void boxActions_CheckedChanged(object sender, EventArgs e)
        {
            MAJLog();
        }

        private void boxHeure_CheckedChanged(object sender, EventArgs e)
        {
            MAJLog();
        }

        private void MAJLog()
        {
            txtLog.Clear();

            Robots.GrosRobot.Historique.HistoriqueLignes.Sort();
            Robots.GrosRobot.Historique.HistoriqueLignes.Sort();

            for(int i = 0; i < Robots.GrosRobot.Historique.HistoriqueLignes.Count; i++)
            {
                HistoLigne ligne = Robots.GrosRobot.Historique.HistoriqueLignes[i];

                AddText((boxHeure.Checked ? ligne.Heure.Minute + ":" + ligne.Heure.Second + ":" + ligne.Heure.Millisecond : "") + " > " + ligne.Message, CouleursLog[ligne.Type]);
            }
        }
    }
}
