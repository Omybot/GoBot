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
    public partial class PanelLogsEvents : UserControl
    {
        private Dictionary<Robot, Color> couleurRobot;
        private Dictionary<TypeLog, Color> couleurTypeLog;

        private Dictionary<Robot, bool> dicRobotsAutorises;
        private Dictionary<TypeLog, bool> dicTypesAutorises;

        private DateTime dateDebut;
        private DateTime datePrec;
        private DateTime datePrecAff;
        private System.Windows.Forms.Timer timerAffichage;
        private bool affichageTempsReel = false;
        private int compteur = 0;

        public PanelLogsEvents()
        {
            InitializeComponent();

            dataGridViewLog.Columns.Add("Id", "Id");
            dataGridViewLog.Columns[0].Width = 40;
            dataGridViewLog.Columns.Add("Heure", "Heure");
            dataGridViewLog.Columns[1].Width = 40;
            dataGridViewLog.Columns.Add("Type", "Type");
            dataGridViewLog.Columns[2].Width = 60;
            dataGridViewLog.Columns.Add("Robot", "Robot");
            dataGridViewLog.Columns[3].Width = 80;
            dataGridViewLog.Columns.Add("Message", "Message");
            dataGridViewLog.Columns[4].Width = 400;

            couleurRobot = new Dictionary<Robot, Color>();
            couleurRobot.Add(Robots.GrosRobot, Color.LightBlue);
            couleurRobot.Add(Robots.PetitRobot, Color.LightGreen);

            couleurTypeLog = new Dictionary<TypeLog, Color>();
            couleurTypeLog.Add(TypeLog.Action, Color.Lavender);
            couleurTypeLog.Add(TypeLog.PathFinding, Color.Khaki);
            couleurTypeLog.Add(TypeLog.Strat, Color.IndianRed);

            dicRobotsAutorises = new Dictionary<Robot, bool>();
            dicTypesAutorises = new Dictionary<TypeLog, bool>();

            checkedListBoxRobots.Items.Add("Gros robot", true);
            checkedListBoxRobots.Items.Add("Petit robot", true);

            // L'ajout de champs déclenche le SetCheck event qui ajoute les éléments automatiquement dans le dictionnaire
            foreach (TypeLog type in Enum.GetValues(typeof(TypeLog)))
            {
                checkedListBoxEvents.Items.Add(type.ToString(), true);
            }
        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichiers replay events (*.elog)|*.elog";
            open.Multiselect = true;
            /*if (open.ShowDialog() == DialogResult.OK)
            {
                replay = new Replay();

                foreach(String fichier in open.FileNames)
                {
                    ChargerLog(fichier);
                }
                replay.Trier();
                Afficher();
            }*/
        }

        private void ChargerLog(String fichier)
        {
            /*Replay replayTemp = new Replay();
            replayTemp.Charger(fichier);

            foreach (TrameReplay t in replayTemp.Trames)
                replay.Trames.Add(t);*/
        }

        private void Afficher()
        {
            /*try
            {
                dataGridViewLog.Rows.Clear();

                dateDebut = replay.Trames[0].Date;
                datePrec = replay.Trames[0].Date;
                datePrecAff = replay.Trames[0].Date;
                compteur = 0;

                for (int iTrame = 0; iTrame < replay.Trames.Count; iTrame++)
                {
                    AfficherEvent(replay.Trames[iTrame]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de décoder toutes les trames contenues dans ce fichier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Afficher();
        }

        private void checkedListBoxGros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*String fonctionString = (String)checkedListBoxGros.Items[e.Index];
            TrameFactory.FonctionMove fonction = (TrameFactory.FonctionMove)Enum.Parse(typeof(TrameFactory.FonctionMove), fonctionString);

            dicMessagesMoveAutorises[fonction] = (e.NewValue == CheckState.Checked);*/
        }

        private void dataGridViewLog_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex > 0 && e.ColumnIndex > 0)
                dataGridViewLog.CurrentCell = dataGridViewLog.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void nePlusAfficherCeTypeDeMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (dataGridViewLog.SelectedRows.Count >= 1)
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
            }*/
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            /*if (!affichageTempsReel)
            {
                replay = new Replay();
                timerAffichage = new System.Windows.Forms.Timer();
                timerAffichage.Interval = 1000;
                timerAffichage.Tick += timerAffichage_Tick;
                timerAffichage.Start();
                Robots.GrosRobot.Historique.NouvelleAction += Historique_NouvelleAction;
                Connexions.ConnexionMiwi.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionMiwi.NouvelleTrameEnvoyee += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

                Connexions.ConnexionMove.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
                Connexions.ConnexionMove.NouvelleTrameEnvoyee += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameSortante);

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

                btnRejouerTout.Enabled = true;
                btnRejouerSelection.Enabled = true;
                btnCharger.Enabled = true;
                btnAfficher.Text = "Afficher temps réel";
                affichageTempsReel = false;
            }*/
        }

        void Historique_NouvelleAction(Actions.IAction action)
        {
            throw new NotImplementedException();
        }

        void timerAffichage_Tick(object sender, EventArgs e)
        {
            /*int nbTrames = replay.Trames.Count;
            for (int i = compteur; i < nbTrames; i++)
                AfficherEvent(replay.Trames[i]);

            if(boxScroll.Checked && dataGridViewLog.Rows.Count > 10)
                dataGridViewLog.FirstDisplayedScrollingRowIndex = dataGridViewLog.RowCount - 1;*/
        }

        private void AfficherEvent(TrameReplay trameReplay)
        {
            Trame trame = new Trame(trameReplay.Trame);
            Carte destinataire = trameReplay.Entrant ? Carte.PC : TrameFactory.Identifiant(trame);
            Carte expediteur = trameReplay.Entrant ? TrameFactory.Identifiant(trame) : Carte.PC;

            String heure = "";

            if (rdoHeure.Checked)
                heure = trameReplay.Date.ToString("hh:mm:ss:fff");
            if (rdoTempsDebut.Checked)
                heure = (trameReplay.Date - dateDebut).ToString(@"hh\:mm\:ss\:fff");
            if (rdoTempsPrec.Checked)
                heure = (trameReplay.Date - datePrec).ToString(@"hh\:mm\:ss\:fff");
            if (rdoTempsPrecAff.Checked)
                heure = (trameReplay.Date - datePrecAff).ToString(@"hh\:mm\:ss\:fff");

            Carte carte = (Carte)trame[0];
            if (carte == Carte.RecMiwi)
                carte = (Carte)trame[2];

            /*if (carte == Carte.RecMove && dicMessagesMoveAutorises[(TrameFactory.FonctionMove)trame[1]])
            {
                dataGridViewLog.Rows.Add(compteur, expediteur.ToString(), destinataire.ToString(), heure, TrameFactory.Decode(trame), trame.ToString());
                datePrecAff = trameReplay.Date;

                if (rdoRobot.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[carte];
                else if (rdoDest.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[destinataire];
                else if (rdoType.Checked)
                    dataGridViewLog.Rows[dataGridViewLog.Rows.Count - 1].DefaultCellStyle.BackColor = couleurCarte[expediteur];
            }*/

            compteur++;

            datePrec = trameReplay.Date;
        }
    }
}
