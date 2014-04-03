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
        public PanelGestionLog()
        {
            InitializeComponent();

            dataGridViewHistoLog.Columns.Add("Date", "Date");
        }

        private void PanelGestionLog_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                foreach (String dossier in Directory.EnumerateDirectories(Config.PathData + "/Logs/"))
                {
                    String dossier1 = Path.GetFileName(dossier);
                    //2014.03.24 21h58m12;
                    DateTime date;
                    try
                    {
                        String[] tab = dossier1.Split(new char[4] { '.', ' ', 'h', 'm' });
                        date = new DateTime(Convert.ToInt16(tab[0]), Convert.ToInt16(tab[1]), Convert.ToInt16(tab[2]), Convert.ToInt16(tab[3]), Convert.ToInt16(tab[4]), Convert.ToInt16(tab[5]));
                        dataGridViewHistoLog.Rows.Add(date.ToLongDateString() + " " + date.ToLongTimeString());
                    }
                    catch(Exception)
                    {
                        dataGridViewHistoLog.Rows.Add(dossier);
                    }
                }
            }
        }
    }
}
