using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs.Formes;
using GoBot.Calculs;
using AStarFolder;
using System.Threading;
using GoBot.Mouvements;
using GoBot.Enchainements;
using GoBot.Balises;
using GoBot.ElementsJeu;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelLogs : UserControl
    {
        private Replay replay;
        private Dictionary<Carte, Color> couleurCarte;
        private Dictionary<TrameFactory.FonctionMove, bool> dicMessagesMoveAutorises;
        private Dictionary<TrameFactory.FonctionMove, bool> dicMessagesPiAutorises;
        private Dictionary<TrameFactory.FonctionBalise, bool> dicMessagesBaliseAutorises;

        public PanelLogs()
        {
            InitializeComponent();
            
            dataGridViewLog.Columns.Add("Id", "Id");
            dataGridViewLog.Columns[0].Width = 40;
            dataGridViewLog.Columns.Add("Expediteur", "Expediteur");
            dataGridViewLog.Columns[1].Width = 60;
            dataGridViewLog.Columns.Add("Destinataire", "Destinataire");
            dataGridViewLog.Columns[2].Width = 60;
            dataGridViewLog.Columns.Add("Heure", "Heure");
            dataGridViewLog.Columns[3].Width = 80;
            dataGridViewLog.Columns.Add("Message", "Message");
            dataGridViewLog.Columns[4].Width = 400;
            dataGridViewLog.Columns.Add("Trame", "Trame");
            dataGridViewLog.Columns[5].Width = 285;

            couleurCarte = new Dictionary<Carte, Color>();
            couleurCarte.Add(Carte.PC, Color.FromArgb(255, 235, 230));
            couleurCarte.Add(Carte.RecMove, Color.FromArgb(204, 255, 204));
            couleurCarte.Add(Carte.RecPi, Color.FromArgb(255, 204, 230));
            couleurCarte.Add(Carte.RecBun, Color.FromArgb(226, 226, 255));
            couleurCarte.Add(Carte.RecBeu, Color.FromArgb(202, 202, 255));
            couleurCarte.Add(Carte.RecBoi, Color.FromArgb(176, 176, 255));

            dicMessagesMoveAutorises = new Dictionary<TrameFactory.FonctionMove, bool>();
            dicMessagesPiAutorises = new Dictionary<TrameFactory.FonctionMove, bool>();
            dicMessagesBaliseAutorises = new Dictionary<TrameFactory.FonctionBalise, bool>();

            // L'ajout de champs déclenche le SetCheck event qui ajoute les éléments automatiquement dans le dictionnaire
            foreach (TrameFactory.FonctionMove fonction in Enum.GetValues(typeof(TrameFactory.FonctionMove)))
            {
                checkedListBoxGros.Items.Add(fonction.ToString(), true);
                checkedListBoxPetit.Items.Add(fonction.ToString(), true);
            }
            foreach (TrameFactory.FonctionBalise fonction in Enum.GetValues(typeof(TrameFactory.FonctionBalise)))
            { 
                checkedListBoxBalise.Items.Add(fonction.ToString(), true);
            }

        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichiers replay trames (*.tlog)|*.tlog";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                replay = new Replay();

                foreach(String fichier in open.FileNames)
                {
                    ChargerLog(fichier);
                }
            }

            replay.Trier();
            Afficher();
        }

        private void ChargerLog(String fichier)
        {
            Replay replayTemp = new Replay();
            replayTemp.Charger(fichier);

            foreach (TrameReplay t in replayTemp.Trames)
                replay.Trames.Add(t);
        }

        private void Afficher()
        {
            try
            {
                dataGridViewLog.Rows.Clear();

                DateTime dateDebut = replay.Trames[0].Date;
                DateTime datePrec = replay.Trames[0].Date;
                DateTime datePrecAff = replay.Trames[0].Date;

                for (int iTrame = 0; iTrame < replay.Trames.Count; iTrame++)
                {
                    Trame trame = new Trame(replay.Trames[iTrame].Trame);
                    Carte destinataire = replay.Trames[iTrame].Entrant ? Carte.PC : TrameFactory.Identifiant(trame);
                    Carte expediteur = replay.Trames[iTrame].Entrant ? TrameFactory.Identifiant(trame) : Carte.PC;

                    String heure = "";

                    if (rdoHeure.Checked)
                        heure = replay.Trames[iTrame].Date.ToString("hh:mm:ss:fff");
                    if (rdoTempsDebut.Checked)
                        heure = (replay.Trames[iTrame].Date - dateDebut).ToString(@"hh\:mm\:ss\:fff");
                    if (rdoTempsPrec.Checked)
                        heure = (replay.Trames[iTrame].Date - datePrec).ToString(@"hh\:mm\:ss\:fff");
                    if (rdoTempsPrecAff.Checked)
                        heure = (replay.Trames[iTrame].Date - datePrecAff).ToString(@"hh\:mm\:ss\:fff");

                    Carte carte = (Carte)trame[0];
                    if (carte == Carte.RecMiwi)
                        carte = (Carte)trame[2];

                    if (carte == Carte.RecMove && dicMessagesMoveAutorises[(TrameFactory.FonctionMove)trame[1]])
                    {
                        dataGridViewLog.Rows.Add(iTrame, expediteur.ToString(), destinataire.ToString(), heure, TrameFactory.Decode(trame), trame.ToString());
                        datePrecAff = replay.Trames[iTrame].Date;

                        if (rdoCarte.Checked)
                            dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[carte];
                        else if (rdoDest.Checked)
                            dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[destinataire];
                        else if (rdoExp.Checked)
                            dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[expediteur];
                    }

                    datePrec = replay.Trames[iTrame].Date;
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
            String fonctionString = (String)checkedListBoxGros.Items[e.Index];
            TrameFactory.FonctionMove fonction = (TrameFactory.FonctionMove)Enum.Parse(typeof(TrameFactory.FonctionMove), fonctionString);

            dicMessagesMoveAutorises[fonction] = (e.NewValue == CheckState.Checked);
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
                        TrameReplay trameReplay = replay.Trames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        Trame trame = new Trame(trameReplay.Trame);

                        Carte carte = (Carte)(trame[0]);
                        if (carte == Carte.RecMiwi)
                            carte = (Carte)trame[2];

                        if (carte == Carte.RecMove)
                        {
                            TrameFactory.FonctionMove fonction = (TrameFactory.FonctionMove)trame[1];
                            checkedListBoxGros.Items.Remove(fonction.ToString());
                            checkedListBoxGros.Items.Add(fonction.ToString(), false);
                            dicMessagesMoveAutorises[fonction] = false;
                        }

                        if (carte == Carte.RecPi)
                        {
                            TrameFactory.FonctionMove fonction = (TrameFactory.FonctionMove)trame[1];
                            checkedListBoxPetit.Items.Remove(fonction.ToString());
                            checkedListBoxPetit.Items.Add(fonction.ToString(), false);
                            dicMessagesPiAutorises[fonction] = false;
                        }

                        if (carte == Carte.RecBun || carte == Carte.RecBeu || carte == Carte.RecBoi)
                        {
                            TrameFactory.FonctionBalise fonction = (TrameFactory.FonctionBalise)trame[3];
                            checkedListBoxBalise.Items.Remove(fonction.ToString());
                            checkedListBoxBalise.Items.Add(fonction.ToString(), false);
                            dicMessagesBaliseAutorises[fonction] = false;
                        }
                    }

                    Afficher();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
