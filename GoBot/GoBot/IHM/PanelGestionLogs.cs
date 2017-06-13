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
using System.IO;

namespace GoBot.IHM
{
    public partial class PanelGestionLog : UserControl
    {
        private enum Columns : int
        {
            Date,
            Taille,
            TramesMove,
            TramesIO,
            TramesGB,
            Events
        }

        public PanelGestionLog()
        {
            InitializeComponent();

            dataSet = new DataSet();
            dataSet.Tables.Add();
            dataSet.Tables[0].Columns.Add("Date", typeof(DateTime));
            dataSet.Tables[0].Columns.Add("Taille", typeof(TailleDossier));
            dataSet.Tables[0].Columns.Add("Trames Move", typeof(int));
            dataSet.Tables[0].Columns.Add("Trames IO", typeof(int));
            dataSet.Tables[0].Columns.Add("Trames GoBot", typeof(int));
            dataSet.Tables[0].Columns.Add("Events", typeof(int));

            dataSetArchivage = new DataSet();
            dataSetArchivage.Tables.Add();
            dataSetArchivage.Tables[0].Columns.Add("Nom", typeof(String));
            dataSetArchivage.Tables[0].Columns.Add("Date", typeof(DateTime));
            dataSetArchivage.Tables[0].Columns.Add("Taille", typeof(TailleDossier));
            dataSetArchivage.Tables[0].Columns.Add("Trames Move", typeof(int));
            dataSetArchivage.Tables[0].Columns.Add("Trames IO", typeof(int));
            dataSetArchivage.Tables[0].Columns.Add("Trames GoBot", typeof(int));
            dataSetArchivage.Tables[0].Columns.Add("Events", typeof(int));
        }

        DataSet dataSet = null;
        DataSet dataSetArchivage = null;

        public static long FolderSize(string path)
        {
            long size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            IEnumerable<FileInfo> files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            return size;
        }

        private BackgroundWorker worker = new BackgroundWorker();
        private void PanelGestionLog_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.WorkerReportsProgress = true;
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();

                //dataGridViewHistoLog.DataSource = dataSet.Tables[0];
                //dataGridViewArchives.DataSource = dataSetArchivage.Tables[0];
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblDatePlusVieux.Text = plusVieux.ToString();
            lblNombreLogs.Text = nbLogs.ToString();
            TailleDossier tailleDossier = new TailleDossier(FolderSize(Config.PathData + "/Logs/"));
            lblTailleTotale.Text = tailleDossier.ToString();

            dataGridViewHistoLog.DataSource = dataSet.Tables[0];
            dataGridViewArchives.DataSource = dataSetArchivage.Tables[0];
            progressBar.Visible = false;
        }


        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private DateTime plusVieux = DateTime.Now;
        private int nbLogs;
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            plusVieux = DateTime.Now;

            int currentLog = 0;

            List<String> dossiers = (List<String>)Directory.EnumerateDirectories(Config.PathData + "/Logs/").ToList<String>();
            nbLogs = dossiers.Count;

            dossiers.Sort(OrdreAlphabetiqueInverse);

            foreach (String dossier in dossiers)
            {
                if (Config.Shutdown)
                    return;

                currentLog++;
                String dossier1 = Path.GetFileName(dossier);
                DateTime date;

                int nbElements = 0;

                try
                {
                    String[] tab = dossier1.Split(new char[5] { '.', ' ', 'h', 'm', 's' });
                    date = new DateTime(Convert.ToInt16(tab[0]), Convert.ToInt16(tab[1]), Convert.ToInt16(tab[2]), Convert.ToInt16(tab[3]), Convert.ToInt16(tab[4]), Convert.ToInt16(tab[5]));

                    if (date < plusVieux)
                        plusVieux = date;

                    long taille = FolderSize(dossier);

                    Object[] datas = new Object[Enum.GetValues(typeof(Columns)).Length];

                    datas[(int)Columns.Date] = date;
                    datas[(int)Columns.Taille] = new TailleDossier(taille);
                    //TODO2018 ca marche plus ça avec les nouveaux fichiers
                    foreach (String fichier in Directory.EnumerateFiles(dossier))
                    {
                        if (Path.GetFileName(fichier) == "ActionsGros.elog")
                        {
                            EventsReplay r = new EventsReplay();
                            if (r.Charger(fichier))
                            {
                                datas[(int)Columns.Events] = r.Events.Count;
                                nbElements += r.Events.Count;
                            }
                            else
                                datas[(int)Columns.Events] = -1;
                        }
                        else if (Path.GetFileName(fichier) == "ConnexionGB.tlog")
                        {
                            ConnectionReplay r = new ConnectionReplay();
                            r.Import(fichier);
                            if (r.Import(fichier))
                            {
                                datas[(int)Columns.TramesGB] = r.Frames.Count;
                                nbElements += r.Frames.Count;
                            }
                            else
                                datas[(int)Columns.TramesGB] = -1;
                        }
                        else if (Path.GetFileName(fichier) == "ConnexionMove.tlog")
                        {
                            ConnectionReplay r = new ConnectionReplay();
                            r.Import(fichier);
                            if (r.Import(fichier))
                            {
                                datas[(int)Columns.TramesMove] = r.Frames.Count;
                                nbElements += r.Frames.Count;
                            }
                            else
                                datas[(int)Columns.TramesMove] = -1;
                        }
                        else if (Path.GetFileName(fichier) == "ConnexionIO.tlog")
                        {
                            ConnectionReplay r = new ConnectionReplay();
                            r.Import(fichier);
                            if (r.Import(fichier))
                            {
                                datas[(int)Columns.TramesIO] = r.Frames.Count;
                                nbElements += r.Frames.Count;
                            }
                            else
                                datas[(int)Columns.TramesIO] = -1;
                        }
                    }

                    // Si il n'y a aucune trame ni aucun evenement dans le dossier, on le supprime
                    if (nbElements == 0)
                        Directory.Delete(dossier);
                    else
                        dataSet.Tables[0].Rows.Add(datas);
                }
                catch (Exception)
                {
                }

                worker.ReportProgress((int)(currentLog * 100 / nbLogs));
            }

            if (Directory.Exists(Config.PathData + "/Archives/"))
            {
                foreach (String dossier in Directory.EnumerateDirectories(Config.PathData + "/Archives/"))
                {
                    if (Config.Shutdown)
                        return;

                    currentLog++;
                    String dossier1 = Path.GetFileName(dossier);
                    DateTime date;

                    try
                    {
                        String[] tab = dossier1.Split(new char[5] { '.', ' ', 'h', 'm', 's' });
                        date = new DateTime(Convert.ToInt16(tab[0]), Convert.ToInt16(tab[1]), Convert.ToInt16(tab[2]), Convert.ToInt16(tab[3]), Convert.ToInt16(tab[4]), Convert.ToInt16(tab[5]));

                        if (date < plusVieux)
                            plusVieux = date;

                        long taille = FolderSize(dossier);

                        Object[] datas = new Object[Enum.GetValues(typeof(Columns)).Length+1];

                        datas[(int)Columns.Date + 1] = date;
                        datas[(int)Columns.Taille + 1] = new TailleDossier(taille);

                        foreach (String fichier in Directory.EnumerateFiles(dossier))
                        {
                            if (Path.GetFileName(fichier) == "ActionsGros.elog")
                            {
                                EventsReplay r = new EventsReplay();
                                if (r.Charger(fichier))
                                    datas[(int)Columns.Events + 1] = r.Events.Count;
                                else
                                    datas[(int)Columns.Events + 1] = -1;
                            }
                            else if (Path.GetFileName(fichier) == "ConnexionGB.tlog")
                            {
                                ConnectionReplay r = new ConnectionReplay();
                                r.Import(fichier);
                                if (r.Import(fichier))
                                    datas[(int)Columns.TramesGB + 1] = r.Frames.Count;
                                else
                                    datas[(int)Columns.TramesGB + 1] = -1;
                            }
                            else if (Path.GetFileName(fichier) == "ConnexionMove.tlog")
                            {
                                ConnectionReplay r = new ConnectionReplay();
                                r.Import(fichier);
                                if (r.Import(fichier))
                                    datas[(int)Columns.TramesMove + 1] = r.Frames.Count;
                                else
                                    datas[(int)Columns.TramesMove + 1] = -1;
                            }
                            else if (Path.GetFileName(fichier) == "ConnexionIO.tlog")
                            {
                                ConnectionReplay r = new ConnectionReplay();
                                r.Import(fichier);
                                if (r.Import(fichier))
                                    datas[(int)Columns.TramesIO + 1] = r.Frames.Count;
                                else
                                    datas[(int)Columns.TramesIO + 1] = -1;
                            }
                            else if (Path.GetFileName(fichier) == "Archivage")
                            {
                                StreamReader reader = new StreamReader(fichier);
                                datas[0] = reader.ReadLine();
                                reader.Close();
                            }
                        }

                        dataSetArchivage.Tables[0].Rows.Add(datas);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private int OrdreAlphabetiqueInverse(String a, String b)
        {
            return a.CompareTo(b) * -1;
        }

        private void btnOuvrirDossier_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistoLog.SelectedRows.Count > 0)
            {
                DateTime ligne = (DateTime)dataGridViewHistoLog.SelectedRows[0].Cells["Date"].Value;
                String dossier = Config.PathData + "\\Logs\\" + ligne.Year.ToString("0000") + "." + ligne.Month.ToString("00") + "." + ligne.Day.ToString("00") + " " + ligne.Hour.ToString("00") + "h" + ligne.Minute.ToString("00") + "m" + ligne.Second.ToString("00") + "s";
                System.Diagnostics.Process.Start("explorer.exe", dossier);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistoLog.SelectedRows.Count > 0)
            {
                String listeDossiers = "";
                for (int i = 0; i < dataGridViewHistoLog.SelectedRows.Count && i <= 20; i++)
                {
                    DateTime ligne = (DateTime)dataGridViewHistoLog.SelectedRows[i].Cells["Date"].Value;
                    listeDossiers += Config.PathData + "\\Logs\\" + ligne.Year.ToString("0000") + "." + ligne.Month.ToString("00") + "." + ligne.Day.ToString("00") + " " + ligne.Hour.ToString("00") + "h" + ligne.Minute.ToString("00") + "m" + ligne.Second.ToString("00") + "s" + Environment.NewLine;

                    if (i == 20)
                        listeDossiers += "... Et " + (dataGridViewHistoLog.SelectedRows.Count - i) + " autres dossiers ...";
                }
                if (MessageBox.Show("Êtes vous sûr de vouloir supprimer le(s) dossier(s) de log suivant(s) ?" + Environment.NewLine + Environment.NewLine + listeDossiers + " ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    for (int i = dataGridViewHistoLog.SelectedRows.Count - 1; i >= 0; i--)
                    {
                        DateTime ligne = (DateTime)dataGridViewHistoLog.SelectedRows[i].Cells["Date"].Value;
                        String dossier = Config.PathData + "\\Logs\\" + ligne.Year.ToString("0000") + "." + ligne.Month.ToString("00") + "." + ligne.Day.ToString("00") + " " + ligne.Hour.ToString("00") + "h" + ligne.Minute.ToString("00") + "m" + ligne.Second.ToString("00") + "s" + Environment.NewLine;

                        Directory.Delete(dossier, true);
                        dataGridViewHistoLog.Rows.RemoveAt(dataGridViewHistoLog.SelectedRows[i].Index);
                    }
                }
            }
        }

        private void dataGridViewHistoLog_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewHistoLog.SelectedRows.Count > 0)
            {
                dataGridViewFichiersLog.Rows.Clear();

                DateTime ligne = (DateTime)dataGridViewHistoLog.SelectedRows[0].Cells["Date"].Value;
                String dossier = Config.PathData + "\\Logs\\" + ligne.Year.ToString("0000") + "." + ligne.Month.ToString("00") + "." + ligne.Day.ToString("00") + " " + ligne.Hour.ToString("00") + "h" + ligne.Minute.ToString("00") + "m" + ligne.Second.ToString("00") + "s";

                lblFichiers.Text = "Fichiers du " + ligne.ToString();

                if (Directory.Exists(dossier))
                {
                    foreach (String fichier in Directory.EnumerateFiles(dossier))
                    {
                        String extension = Path.GetExtension(fichier);
                        if (extension == ConnectionReplay.FileExtension || extension == ".elog")
                        {
                            dataGridViewFichiersLog.Rows.Add(Path.GetFileName(fichier), fichier);
                        }
                    }
                }
            }
        }

        private void dataGridViewFichiersLog_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewFichiersLog.SelectedRows.Count > 0)
            {
                String fichier = (String)(dataGridViewFichiersLog.Rows[dataGridViewFichiersLog.SelectedRows[0].Index].Cells["Chemin"].Value);
                FenGoBot.Instance.ChargerReplay(fichier);
            }
        }

        private void btnArchivage_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistoLog.SelectedRows.Count > 0)
            {
                DateTime ligne = (DateTime)dataGridViewHistoLog.SelectedRows[0].Cells["Date"].Value;
                String dossier = Config.PathData + "\\Logs\\" + ligne.Year.ToString("0000") + "." + ligne.Month.ToString("00") + "." + ligne.Day.ToString("00") + " " + ligne.Hour.ToString("00") + "h" + ligne.Minute.ToString("00") + "m" + ligne.Second.ToString("00") + "s";
                String nomCourt = Path.GetFileName(dossier);
                FenNomArchivage fen = new FenNomArchivage();
                fen.Nom = ligne.ToString();
                fen.ShowDialog();

                if (!fen.OK)
                    return;

                Directory.Move(dossier, Config.PathData + "\\Archives\\" + nomCourt);
                StreamWriter writer = new StreamWriter(Config.PathData + "\\Archives\\" + nomCourt + "\\Archivage");
                writer.Write(fen.Nom);
                writer.Close();

                Object[] datas = new Object[Enum.GetValues(typeof(Columns)).Length + 1];

                datas[0] = fen.Nom;

                for (int i = 0; i < Enum.GetValues(typeof(Columns)).Length; i++)
                    datas[i + 1] = dataGridViewHistoLog.SelectedRows[0].Cells[i].Value;

                dataGridViewHistoLog.Rows.RemoveAt(dataGridViewHistoLog.SelectedRows[0].Index);

                dataSetArchivage.Tables[0].Rows.Add(datas);
            }
        }

        private void dataGridViewArchives_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewArchives.SelectedRows.Count > 0)
            {
                dataGridViewFichiersLog.Rows.Clear();

                DateTime ligne = (DateTime)dataGridViewArchives.SelectedRows[0].Cells["Date"].Value;
                String dossier = Config.PathData + "\\Archives\\" + ligne.Year.ToString("0000") + "." + ligne.Month.ToString("00") + "." + ligne.Day.ToString("00") + " " + ligne.Hour.ToString("00") + "h" + ligne.Minute.ToString("00") + "m" + ligne.Second.ToString("00") + "s";

                lblFichiers.Text = "Fichiers du " + ligne.ToString();

                if (Directory.Exists(dossier))
                {
                    foreach (String fichier in Directory.EnumerateFiles(dossier))
                    {
                        String extension = Path.GetExtension(fichier);
                        if (extension == ConnectionReplay.FileExtension || extension == ".elog")
                        {
                            dataGridViewFichiersLog.Rows.Add(Path.GetFileName(fichier), fichier);
                        }
                    }
                }
            }
        }
    }

    class TailleDossier : IComparable
    {
        String taille;
        long tailleOctets;

        public TailleDossier(long t)
        {
            tailleOctets = t;

            long tailleModif = tailleOctets;

            String extension = " o";
            if (tailleModif > 1024)
            {
                tailleModif /= 1024;
                extension = " ko";
            }
            if (tailleModif > 1024)
            {
                tailleModif /= 1024;
                extension = " mo";
            }

            taille = tailleModif + extension;
        }

        public override string ToString()
        {
            return taille;
        }

        public int CompareTo(object obj)
        {
            TailleDossier autre = (TailleDossier)obj;

            if (autre.tailleOctets > tailleOctets)
                return 1;
            if (autre.tailleOctets == tailleOctets)
                return 0;

            return -1;
        }
    }
}
