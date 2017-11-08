using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Geometry.Shapes;
using GoBot.Geometry;
using AStarFolder;
using System.Threading;
using GoBot.Mouvements;
using GoBot.Enchainements;
using GoBot.Balises;
using GoBot.ElementsJeu;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelLogsTrames : UserControl
    {
        private ConnectionReplay replay;
        private Dictionary<Board, Color> couleurCarte;

        private DateTime dateDebut;
        private DateTime datePrec;
        private DateTime datePrecAff;
        private System.Windows.Forms.Timer timerAffichage;
        private bool affichageTempsReel = false;
        private int compteur = 0;
        private Thread threadReplay;

        public PanelLogsTrames()
        {
            InitializeComponent();

            chargement = true;

            dataGridViewLog.Columns.Add("Id", "Id");
            dataGridViewLog.Columns[0].Width = 40;
            dataGridViewLog.Columns.Add("Expediteur", "Expediteur");
            dataGridViewLog.Columns[1].Width = 60;
            dataGridViewLog.Columns.Add("Destinataire", "Destinataire");
            dataGridViewLog.Columns[2].Width = 60;
            dataGridViewLog.Columns.Add("Heure", "Heure");
            dataGridViewLog.Columns[3].Width = 80;
            dataGridViewLog.Columns.Add("Message", "Message");
            dataGridViewLog.Columns[4].Width = 320;
            dataGridViewLog.Columns.Add("Trame", "Trame");
            dataGridViewLog.Columns[5].Width = dataGridViewLog.Width - 18 - dataGridViewLog.Columns[0].Width - dataGridViewLog.Columns[1].Width - dataGridViewLog.Columns[2].Width - dataGridViewLog.Columns[3].Width - dataGridViewLog.Columns[4].Width;

            couleurCarte = new Dictionary<Board, Color>();
            couleurCarte.Add(Board.PC, Color.FromArgb(180, 245, 245));
            couleurCarte.Add(Board.RecMove, Color.FromArgb(143, 255, 143));
            couleurCarte.Add(Board.RecIO, Color.FromArgb(210, 254, 211));
            couleurCarte.Add(Board.RecGB, Color.FromArgb(219, 209, 233));


            // L'ajout de champs déclenche le SetCheck event qui ajoute les éléments automatiquement dans le dictionnaire
            if (Config.CurrentConfig.LogsFonctionsMove == null)
                Config.CurrentConfig.LogsFonctionsMove = new SerializableDictionary<FrameFunction, bool>();
            if (Config.CurrentConfig.LogsFonctionsIO == null)
                Config.CurrentConfig.LogsFonctionsIO = new SerializableDictionary<FrameFunction, bool>();
            if (Config.CurrentConfig.LogsFonctionsGB == null)
                Config.CurrentConfig.LogsFonctionsGB = new SerializableDictionary<FrameFunction, bool>();
            if (Config.CurrentConfig.LogsExpediteurs == null)
                Config.CurrentConfig.LogsExpediteurs = new SerializableDictionary<Board, bool>();
            if (Config.CurrentConfig.LogsDestinataires == null)
                Config.CurrentConfig.LogsDestinataires = new SerializableDictionary<Board, bool>();
            
            foreach (FrameFunction fonction in Enum.GetValues(typeof(FrameFunction)))
            {
                if (!Config.CurrentConfig.LogsFonctionsMove.ContainsKey(fonction))
                    Config.CurrentConfig.LogsFonctionsMove.Add(fonction, true);

                checkedListBoxMove.Items.Add(fonction.ToString(), Config.CurrentConfig.LogsFonctionsMove[fonction]);

                if (!Config.CurrentConfig.LogsFonctionsIO.ContainsKey(fonction))
                    Config.CurrentConfig.LogsFonctionsIO.Add(fonction, true);

                checkedListBoxIO.Items.Add(fonction.ToString(), Config.CurrentConfig.LogsFonctionsIO[fonction]);

                if (!Config.CurrentConfig.LogsFonctionsGB.ContainsKey(fonction))
                    Config.CurrentConfig.LogsFonctionsGB.Add(fonction, true);

                checkedListBoxGB.Items.Add(fonction.ToString(), Config.CurrentConfig.LogsFonctionsGB[fonction]);

            }
            
            foreach (Board carte in Enum.GetValues(typeof(Board)))
            {
                if (!Config.CurrentConfig.LogsExpediteurs.ContainsKey(carte))
                    Config.CurrentConfig.LogsExpediteurs.Add(carte, true);
                if (!Config.CurrentConfig.LogsDestinataires.ContainsKey(carte))
                    Config.CurrentConfig.LogsDestinataires.Add(carte, true);

                checkedListBoxExpediteur.Items.Add(carte.ToString(), Config.CurrentConfig.LogsExpediteurs[carte]);
                checkedListBoxDestinataire.Items.Add(carte.ToString(), Config.CurrentConfig.LogsDestinataires[carte]);
            }

            chargement = false;
            replay = new ConnectionReplay();
        }
        bool chargement;

        private void btnCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichiers replay trames (*" + ConnectionReplay.FileExtension + ")| *" + ConnectionReplay.FileExtension + "";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {

                foreach (String fichier in open.FileNames)
                {
                    ChargerLog(fichier);
                }
                replay.Sort();
                Afficher();
            }
        }

        public void Clear()
        {
            replay = new ConnectionReplay();
        }

        public void ChargerLog(String fichier)
        {
            ConnectionReplay replayTemp = new ConnectionReplay();
            replayTemp.Import(fichier);

            foreach (ReplayFrame t in replayTemp.Frames)
                replay.Frames.Add(t);
        }

        public void Afficher()
        {
            try
            {
                dataGridViewLog.Rows.Clear();

                dateDebut = replay.Frames[0].Date;
                datePrec = replay.Frames[0].Date;
                datePrecAff = replay.Frames[0].Date;
                compteur = 0;

                for (int iTrame = 0; iTrame < replay.Frames.Count; iTrame++)
                {
                    AfficherTrame(replay.Frames[iTrame]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de décoder toutes les trames contenues dans ce fichier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Afficher();
        }

        private void checkedListBoxGros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !chargement)
            {
                String fonctionString = (String)checkedListBoxMove.Items[e.Index];
                FrameFunction fonction = (FrameFunction)Enum.Parse(typeof(FrameFunction), fonctionString);

                Config.CurrentConfig.LogsFonctionsMove[fonction] = (e.NewValue == CheckState.Checked);
            }
        }

        private void dataGridViewLog_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex > 0 && e.ColumnIndex > 0)
                dataGridViewLog.CurrentCell = dataGridViewLog.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void nePlusAfficherCeTypeDeMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.SelectedRows.Count >= 1)
            {
                try
                {
                    foreach (DataGridViewRow ligne in dataGridViewLog.SelectedRows)
                    {
                        int index = ligne.Index;
                        ReplayFrame trameReplay = replay.Frames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];

                        Board carte = trameReplay.Frame.Board;

                        if (carte == Board.RecMove)
                        {
                            FrameFunction fonction = (FrameFunction)trameReplay.Frame[1];
                            checkedListBoxMove.Items.Remove(fonction.ToString());
                            checkedListBoxMove.Items.Add(fonction.ToString(), false);
                            Config.CurrentConfig.LogsFonctionsMove[fonction] = false;
                        }

                        if (carte == Board.RecIO)
                        {
                            FrameFunction fonction = (FrameFunction)trameReplay.Frame[1];
                            checkedListBoxIO.Items.Remove(fonction.ToString());
                            checkedListBoxIO.Items.Add(fonction.ToString(), false);
                            Config.CurrentConfig.LogsFonctionsIO[fonction] = false;
                        }

                        if (carte == Board.RecGB)
                        {
                            FrameFunction fonction = (FrameFunction)trameReplay.Frame[1];
                            checkedListBoxGB.Items.Remove(fonction.ToString());
                            checkedListBoxGB.Items.Add(fonction.ToString(), false);
                            Config.CurrentConfig.LogsFonctionsGB[fonction] = false;
                        }
                    }

                    Afficher();
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            if (!affichageTempsReel)
            {
                replay = new ConnectionReplay();
                timerAffichage = new System.Windows.Forms.Timer();
                timerAffichage.Interval = 1000;
                timerAffichage.Tick += timerAffichage_Tick;
                timerAffichage.Start();

                Connections.ConnectionMove.FrameReceived += new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, true));
                Connections.ConnectionMove.FrameSend += new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, false));

                Connections.ConnectionIO.FrameReceived += new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, true));
                Connections.ConnectionIO.FrameSend += new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, false));

                Connections.ConnectionGB.FrameReceived += new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, true));
                Connections.ConnectionGB.FrameSend += new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, false));

                btnRejouerTout.Enabled = false;
                btnRejouerSelection.Enabled = false;
                btnCharger.Enabled = false;
                btnAfficher.Text = "Arrêter l'affichage";
                btnAfficher.Image = GoBot.Properties.Resources.Pause;
                affichageTempsReel = true;
            }
            else
            {
                timerAffichage.Stop();

                Connections.ConnectionMove.FrameReceived -= new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, true));
                Connections.ConnectionMove.FrameSend -= new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, false));

                Connections.ConnectionIO.FrameReceived -= new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, true));
                Connections.ConnectionIO.FrameSend -= new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, false));

                Connections.ConnectionGB.FrameReceived -= new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, true));
                Connections.ConnectionGB.FrameSend -= new UDPConnection.NewFrameDelegate((frame) => replay.AddFrame(frame, false));

                btnRejouerTout.Enabled = true;
                btnRejouerSelection.Enabled = true;
                btnCharger.Enabled = true;
                btnAfficher.Text = "Afficher temps réel";
                btnAfficher.Image = GoBot.Properties.Resources.Play;
                affichageTempsReel = false;
            }
        }

        void timerAffichage_Tick(object sender, EventArgs e)
        {
            int nbTrames = replay.Frames.Count;
            for (int i = compteur; i < nbTrames; i++)
                AfficherTrame(replay.Frames[i]);

            if (boxScroll.Checked && dataGridViewLog.Rows.Count > 10)
                dataGridViewLog.FirstDisplayedScrollingRowIndex = dataGridViewLog.RowCount - 1;
        }

        private void AfficherTrame(ReplayFrame trameReplay)
        {
            String heure = "";
            try
            {
                Frame trame = trameReplay.Frame;

                if (rdoHeure.Checked)
                    heure = trameReplay.Date.ToString("hh:mm:ss:fff");
                if (rdoTempsDebut.Checked)
                    heure = (trameReplay.Date - dateDebut).ToString(@"hh\:mm\:ss\:fff");
                if (rdoTempsPrec.Checked)
                    heure = ((int)(trameReplay.Date - datePrec).TotalMilliseconds).ToString() + " ms";
                if (rdoTempsPrecAff.Checked)
                    heure = ((int)(trameReplay.Date - datePrecAff).TotalMilliseconds).ToString() + " ms";

                Board destinataire = trameReplay.IsInputFrame ? Board.PC : trame.Board;
                Board expediteur = trameReplay.IsInputFrame ? trame.Board : Board.PC;
                Board carte = trame.Board;

                if (carte == Board.PC)
                    throw new Exception();

                bool cartesAutorisees = false;
                if (Config.CurrentConfig.LogsDestinataires[destinataire] && Config.CurrentConfig.LogsExpediteurs[expediteur])
                    cartesAutorisees = true;

                bool fonctionAutorisee = false;
                if ((carte == Board.RecMove && Config.CurrentConfig.LogsFonctionsMove[(FrameFunction)trame[1]]) ||
                    trame[1] == 0xA1 ||
                    (carte == Board.RecIO && Config.CurrentConfig.LogsFonctionsIO[(FrameFunction)trame[1]]) ||
                    (carte == Board.RecGB && Config.CurrentConfig.LogsFonctionsGB[(FrameFunction)trame[1]]))
                    fonctionAutorisee = true;


                if (cartesAutorisees && fonctionAutorisee)
                {
                    dataGridViewLog.Rows.Add(compteur, expediteur.ToString(), destinataire.ToString(), heure, FrameDecoder.Decode(trame), trame.ToString());
                    datePrecAff = trameReplay.Date;

                    if (rdoCarte.Checked)
                        dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[carte];
                    else if (rdoDest.Checked)
                        dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[destinataire];
                    else if (rdoExp.Checked)
                        dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[expediteur];
                }
            }
            catch (Exception)
            {
                dataGridViewLog.Rows.Add(compteur, "?", "?", heure, "Inconnu !", trameReplay.Frame.ToString());
                dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
            }

            compteur++;

            datePrec = trameReplay.Date;
        }

        private void btnRejouerTout_Click(object sender, EventArgs e)
        {
            threadReplay = new Thread(replay.ReplayInputFrames);
            threadReplay.Start();
        }

        private void btnRejouerSelection_Click(object sender, EventArgs e)
        {
            ConnectionReplay replaySelection = new ConnectionReplay();

            if (dataGridViewLog.SelectedRows.Count >= 1)
            {
                try
                {
                    foreach (DataGridViewRow ligne in dataGridViewLog.SelectedRows)
                    {
                        int index = ligne.Index;
                        ReplayFrame trameReplay = replay.Frames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        replaySelection.AddFrame(trameReplay.Frame, trameReplay.IsInputFrame, trameReplay.Date);
                    }

                    replaySelection.Sort();
                    threadReplay = new Thread(replaySelection.ReplayInputFrames);
                    threadReplay.Start();
                }
                catch (Exception)
                {
                }
            }
        }

        private void checkedListBoxExpediteur_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !chargement)
            {
                String carteString = (String)checkedListBoxExpediteur.Items[e.Index];
                Board carte = (Board)Enum.Parse(typeof(Board), carteString);

                Config.CurrentConfig.LogsExpediteurs[carte] = (e.NewValue == CheckState.Checked);
            }
        }

        private void checkedListBoxDestinataire_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !chargement)
            {
                String carteString = (String)checkedListBoxDestinataire.Items[e.Index];
                Board carte = (Board)Enum.Parse(typeof(Board), carteString);

                Config.CurrentConfig.LogsDestinataires[carte] = (e.NewValue == CheckState.Checked);
            }
        }

        private void checkedListBoxGB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !chargement)
            {
                String fonctionString = (String)checkedListBoxGB.Items[e.Index];
                FrameFunction fonction = (FrameFunction)Enum.Parse(typeof(FrameFunction), fonctionString);

                Config.CurrentConfig.LogsFonctionsGB[fonction] = (e.NewValue == CheckState.Checked);
            }
        }

        private void checkedListBoxIO_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!Execution.DesignMode && !chargement)
            {
                String fonctionString = (String)checkedListBoxIO.Items[e.Index];
                FrameFunction fonction = (FrameFunction)Enum.Parse(typeof(FrameFunction), fonctionString);

                Config.CurrentConfig.LogsFonctionsIO[fonction] = (e.NewValue == CheckState.Checked);
            }
        }

        private void nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.SelectedRows.Count >= 1)
            {
                try
                {
                    foreach (DataGridViewRow ligne in dataGridViewLog.SelectedRows)
                    {
                        int index = ligne.Index;
                        ReplayFrame trameReplay = replay.Frames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        Frame trame = trameReplay.Frame;

                        Board expediteur = trameReplay.IsInputFrame ? trameReplay.Frame.Board : Board.PC;

                        checkedListBoxExpediteur.Items.Remove(expediteur.ToString());
                        checkedListBoxExpediteur.Items.Add(expediteur.ToString(), false);
                        Config.CurrentConfig.LogsExpediteurs[expediteur] = false;
                    }

                    Afficher();
                }
                catch (Exception)
                {
                }
            }
        }

        private void nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.SelectedRows.Count >= 1)
            {
                try
                {
                    foreach (DataGridViewRow ligne in dataGridViewLog.SelectedRows)
                    {
                        int index = ligne.Index;
                        ReplayFrame trameReplay = replay.Frames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];

                        Board destinataire = trameReplay.IsInputFrame ? Board.PC : trameReplay.Frame.Board;

                        checkedListBoxDestinataire.Items.Remove(destinataire.ToString());
                        checkedListBoxDestinataire.Items.Add(destinataire.ToString(), false);
                        Config.CurrentConfig.LogsDestinataires[destinataire] = false;
                    }

                    Afficher();
                }
                catch (Exception)
                {
                }
            }
        }

        private void nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.SelectedRows.Count >= 1)
            {
                try
                {
                    foreach (DataGridViewRow ligne in dataGridViewLog.SelectedRows)
                    {
                        int index = ligne.Index;
                        ReplayFrame trameReplay = replay.Frames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];

                        Board carte = trameReplay.Frame.Board;

                        checkedListBoxExpediteur.Items.Remove(carte.ToString());
                        checkedListBoxExpediteur.Items.Add(carte.ToString(), false);
                        Config.CurrentConfig.LogsExpediteurs[carte] = false;
                        checkedListBoxDestinataire.Items.Remove(carte.ToString());
                        checkedListBoxDestinataire.Items.Add(carte.ToString(), false);
                        Config.CurrentConfig.LogsDestinataires[carte] = false;
                    }

                    Afficher();
                }
                catch (Exception)
                {
                }
            }
        }

        private void nePlusAfficherTousCesMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridViewLog.Rows.Count; i++)
                    dataGridViewLog.Rows[i].Selected = true;

                nePlusAfficherCeTypeDeMessagesToolStripMenuItem_Click(null, null);
            }
        }

        private void copierLaTrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLog.Rows.Count > 0)
            {
                Clipboard.SetText((String)(dataGridViewLog.SelectedRows[0].Cells["Trame"].Value));
            }
        }

        private void btnCocher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxGB.Items.Count; i++)
                checkedListBoxGB.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxDestinataire.Items.Count; i++)
                checkedListBoxDestinataire.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxExpediteur.Items.Count; i++)
                checkedListBoxExpediteur.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxIO.Items.Count; i++)
                checkedListBoxIO.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxMove.Items.Count; i++)
                checkedListBoxMove.SetItemChecked(i, true);
        }

        private void btnDecocher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxGB.Items.Count; i++)
                checkedListBoxGB.SetItemChecked(i, false);
            for (int i = 0; i < checkedListBoxDestinataire.Items.Count; i++)
                checkedListBoxDestinataire.SetItemChecked(i, false);
            for (int i = 0; i < checkedListBoxExpediteur.Items.Count; i++)
                checkedListBoxExpediteur.SetItemChecked(i, false);
            for (int i = 0; i < checkedListBoxIO.Items.Count; i++)
                checkedListBoxIO.SetItemChecked(i, false);
            for (int i = 0; i < checkedListBoxMove.Items.Count; i++)
                checkedListBoxMove.SetItemChecked(i, false);
        }
    }
}
