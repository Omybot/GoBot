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
    public partial class PanelLogsTrames : UserControl
    {
        private Replay replay;
        private Dictionary<Carte, Color> couleurCarte;
        private Dictionary<TrameFactory.FonctionMove, bool> dicMessagesMoveAutorises;
        private Dictionary<TrameFactory.FonctionMove, bool> dicMessagesPiAutorises;
        private Dictionary<TrameFactory.FonctionBalise, bool> dicMessagesBaliseAutorises;
        private Dictionary<Carte, bool> dicExpediteurAutorises;
        private Dictionary<Carte, bool> dicDestinataireAutorises;

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
            dicDestinataireAutorises = new Dictionary<Carte, bool>();
            dicExpediteurAutorises = new Dictionary<Carte, bool>();

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
            foreach (Carte carte in Enum.GetValues(typeof(Carte)))
            {
                checkedListBoxExpediteur.Items.Add(carte.ToString(), true);
                checkedListBoxDestinataire.Items.Add(carte.ToString(), true);
            }

            replay = new Replay();
        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichiers replay trames (*.tlog)|*.tlog";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {

                foreach(String fichier in open.FileNames)
                {
                    ChargerLog(fichier);
                }
                replay.Trier();
                Afficher();
            }
        }

        public void Clear()
        {
            replay = new Replay();
        }

        public void ChargerLog(String fichier)
        {
            Replay replayTemp = new Replay();
            replayTemp.Charger(fichier);

            foreach (TrameReplay t in replayTemp.Trames)
                replay.Trames.Add(t);
        }

        public void Afficher()
        {
            try
            {
                dataGridViewLog.Rows.Clear();

                dateDebut = replay.Trames[0].Date;
                datePrec = replay.Trames[0].Date;
                datePrecAff = replay.Trames[0].Date;
                compteur = 0;

                for (int iTrame = 0; iTrame < replay.Trames.Count; iTrame++)
                {
                    AfficherTrame(replay.Trames[iTrame]);
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
            if (!Config.DesignMode)
            {
                String fonctionString = (String)checkedListBoxGros.Items[e.Index];
                TrameFactory.FonctionMove fonction = (TrameFactory.FonctionMove)Enum.Parse(typeof(TrameFactory.FonctionMove), fonctionString);

                dicMessagesMoveAutorises[fonction] = (e.NewValue == CheckState.Checked);
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
                        TrameReplay trameReplay = replay.Trames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        Trame trame = new Trame(trameReplay.Trame);

                        Carte carte = trame.Carte;

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

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            if (!affichageTempsReel)
            {
                replay = new Replay();
                timerAffichage = new System.Windows.Forms.Timer();
                timerAffichage.Interval = 1000;
                timerAffichage.Tick += timerAffichage_Tick;
                timerAffichage.Start();

                Connexions.ConnexionMiwi.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionMiwi.NouvelleTrameEnvoyee += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                Connexions.ConnexionMove.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionMove.NouvelleTrameEnvoyee += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                Connexions.ConnexionPi.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionPi.NouvelleTrameEnvoyee += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                btnRejouerTout.Enabled = false;
                btnRejouerSelection.Enabled = false;
                btnCharger.Enabled = false;
                btnAfficher.Text = "Arrêter l'affichage";
                affichageTempsReel = true;
            }
            else
            {
                timerAffichage.Stop();

                Connexions.ConnexionMiwi.NouvelleTrameRecue -= new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionMiwi.NouvelleTrameEnvoyee -= new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                Connexions.ConnexionMove.NouvelleTrameRecue -= new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionMove.NouvelleTrameEnvoyee -= new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                Connexions.ConnexionPi.NouvelleTrameRecue -= new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionPi.NouvelleTrameEnvoyee -= new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                btnRejouerTout.Enabled = true;
                btnRejouerSelection.Enabled = true;
                btnCharger.Enabled = true;
                btnAfficher.Text = "Afficher temps réel";
                affichageTempsReel = false;
            }
        }

        void timerAffichage_Tick(object sender, EventArgs e)
        {
            int nbTrames = replay.Trames.Count;
            for (int i = compteur; i < nbTrames; i++)
                AfficherTrame(replay.Trames[i]);

            if(boxScroll.Checked && dataGridViewLog.Rows.Count > 10)
                dataGridViewLog.FirstDisplayedScrollingRowIndex = dataGridViewLog.RowCount - 1;
        }

        private void AfficherTrame(TrameReplay trameReplay)
        {
            Trame trame = new Trame(trameReplay.Trame);

            String heure = "";

            if (rdoHeure.Checked)
                heure = trameReplay.Date.ToString("hh:mm:ss:fff");
            if (rdoTempsDebut.Checked)
                heure = (trameReplay.Date - dateDebut).ToString(@"hh\:mm\:ss\:fff");
            if (rdoTempsPrec.Checked)
                heure = (trameReplay.Date - datePrec).ToString(@"hh\:mm\:ss\:fff");
            if (rdoTempsPrecAff.Checked)
                heure = (trameReplay.Date - datePrecAff).ToString(@"hh\:mm\:ss\:fff");

            Carte destinataire = trameReplay.Entrant ? Carte.PC : TrameFactory.Identifiant(trame);
            Carte expediteur = trameReplay.Entrant ? TrameFactory.Identifiant(trame) : Carte.PC;
            Carte carte = trame.Carte;

            bool cartesAutorisees = false;
            if (dicDestinataireAutorises[destinataire] && dicExpediteurAutorises[expediteur])
                cartesAutorisees = true;

            bool fonctionAutorisee = false;
            if ((carte == Carte.RecMove && dicMessagesMoveAutorises[(TrameFactory.FonctionMove)trame[1]]) ||
               (carte == Carte.RecPi && dicMessagesPiAutorises[(TrameFactory.FonctionMove)trame[3]]) ||
               ((carte == Carte.RecBun || carte == Carte.RecBeu || carte == Carte.RecBoi) && dicMessagesBaliseAutorises[(TrameFactory.FonctionBalise)trame[3]]))
                fonctionAutorisee = true;

            if (cartesAutorisees && fonctionAutorisee)
            {
                dataGridViewLog.Rows.Add(compteur, expediteur.ToString(), destinataire.ToString(), heure, TrameFactory.Decode(trame), trame.ToString());
                datePrecAff = trameReplay.Date;

                if (rdoCarte.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[carte];
                else if (rdoDest.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[destinataire];
                else if (rdoExp.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[expediteur];
            }

            compteur++;

            datePrec = trameReplay.Date;
        }

        private void btnRejouerTout_Click(object sender, EventArgs e)
        {
            threadReplay = new Thread(replay.Rejouer);
            threadReplay.Start();
        }

        private void btnRejouerSelection_Click(object sender, EventArgs e)
        {
            Replay replaySelection = new Replay();

            if (dataGridViewLog.SelectedRows.Count >= 1)
            {
                try
                {
                    foreach (DataGridViewRow ligne in dataGridViewLog.SelectedRows)
                    {
                        int index = ligne.Index;
                        TrameReplay trameReplay = replay.Trames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        if (trameReplay.Entrant)
                            replaySelection.AjouterTrameEntrante(new Trame(trameReplay.Trame), trameReplay.Date);
                        else
                            replaySelection.AjouterTrameSortante(new Trame(trameReplay.Trame), trameReplay.Date);
                    }

                    replaySelection.Trier();
                    threadReplay = new Thread(replaySelection.Rejouer);
                    threadReplay.Start();
                }
                catch (Exception)
                {
                }
            }
        }

        private void checkedListBoxExpediteur_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String carteString = (String)checkedListBoxExpediteur.Items[e.Index];
            Carte carte = (Carte)Enum.Parse(typeof(Carte), carteString);

            dicExpediteurAutorises[carte] = (e.NewValue == CheckState.Checked);
        }

        private void checkedListBoxDestinataire_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String carteString = (String)checkedListBoxDestinataire.Items[e.Index];
            Carte carte = (Carte)Enum.Parse(typeof(Carte), carteString);

            dicDestinataireAutorises[carte] = (e.NewValue == CheckState.Checked);
        }

        private void checkedListBoxBalise_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String fonctionString = (String)checkedListBoxBalise.Items[e.Index];
            TrameFactory.FonctionBalise fonction = (TrameFactory.FonctionBalise)Enum.Parse(typeof(TrameFactory.FonctionBalise), fonctionString);

            dicMessagesBaliseAutorises[fonction] = (e.NewValue == CheckState.Checked);
        }

        private void checkedListBoxPetit_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String fonctionString = (String)checkedListBoxPetit.Items[e.Index];
            TrameFactory.FonctionMove fonction = (TrameFactory.FonctionMove)Enum.Parse(typeof(TrameFactory.FonctionMove), fonctionString);

            dicMessagesPiAutorises[fonction] = (e.NewValue == CheckState.Checked);
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
                        TrameReplay trameReplay = replay.Trames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        Trame trame = new Trame(trameReplay.Trame);

                        Carte expediteur = trameReplay.Entrant ? TrameFactory.Identifiant(trame) : Carte.PC;

                        checkedListBoxExpediteur.Items.Remove(expediteur.ToString());
                        checkedListBoxExpediteur.Items.Add(expediteur.ToString(), false);
                        dicExpediteurAutorises[expediteur] = false;
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
                        TrameReplay trameReplay = replay.Trames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        Trame trame = new Trame(trameReplay.Trame);

                        Carte destinataire = trameReplay.Entrant ? Carte.PC : TrameFactory.Identifiant(trame);

                        checkedListBoxDestinataire.Items.Remove(destinataire.ToString());
                        checkedListBoxDestinataire.Items.Add(destinataire.ToString(), false);
                        dicDestinataireAutorises[destinataire] = false;
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
                        TrameReplay trameReplay = replay.Trames[Convert.ToInt32(dataGridViewLog["Id", index].Value)];
                        Trame trame = new Trame(trameReplay.Trame);

                        Carte carte = trame.Carte;

                        checkedListBoxExpediteur.Items.Remove(carte.ToString());
                        checkedListBoxExpediteur.Items.Add(carte.ToString(), false);
                        dicExpediteurAutorises[carte] = false;
                        checkedListBoxDestinataire.Items.Remove(carte.ToString());
                        checkedListBoxDestinataire.Items.Add(carte.ToString(), false);
                        dicDestinataireAutorises[carte] = false;
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
    }
}
