using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Actionneurs;
using System.Reflection;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotReglage : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotReglage()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxReglage.DeployedChanged += new Composants.GroupBoxPlus.DeployedChangedDelegate(groupBoxReglage_Deploiement);
        }

        void groupBoxReglage_Deploiement(bool deploye)
        {
            Config.CurrentConfig.ReglageGROuvert = deploye;
        }

        private void PanelReglageGros_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                groupBoxReglage.Deploy(Config.CurrentConfig.ReglageGROuvert, false);

                comboBoxPositionnables.Items.AddRange(Config.Positionnables.ToArray());
            }
        }

        public Dictionary<String, PropertyInfo> dicProperties;

        private void comboBoxPositionnables_SelectedValueChanged(object sender, EventArgs e)
        {
            Positionable positionnable = (Positionable)comboBoxPositionnables.SelectedItem;

            PropertyInfo[] properties = positionnable.GetType().GetProperties();

            List<String> noms = new List<string>();
            dicProperties = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "ID")
                {
                    noms.Add(Config.PropertyNameToScreen(property) + " : " + property.GetValue(positionnable, null));
                    dicProperties.Add(noms[noms.Count - 1], property);
                }
            }

            comboBoxPosition.Items.Clear();
            comboBoxPosition.Items.AddRange(noms.ToArray());

            trackBarValeurPosition.Min = positionnable.Minimum;
            trackBarValeurPosition.Max = positionnable.Maximum;
        }

        private void comboBoxPosition_SelectedValueChanged(object sender, EventArgs e)
        {
            String[] tab = ((String)(comboBoxPosition.SelectedItem)).Split(new char[]{':'});

            String position = tab[0].Trim();
            int valeur = Convert.ToInt32(tab[1].Trim());

            numValeurPosition.Value = valeur;
        }

        private void btnSauvegarderPosition_Click(object sender, EventArgs e)
        {
            String[] tab = ((String)(comboBoxPosition.SelectedItem)).Split(new char[] { ':' });

            String position = tab[0].Trim().ToLower();
            int valeur = Convert.ToInt32(tab[1].Trim());
            
            if (MessageBox.Show("Êtes vous certain de vouloir sauvegarder la position " + position + " de l'actionneur " + comboBoxPositionnables.Text.ToLower() + " à " + numValeurPosition.Value + " (anciennement " + valeur + ") ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int index = comboBoxPosition.SelectedIndex;

                dicProperties[(String)comboBoxPosition.SelectedItem].SetValue((Positionable)comboBoxPositionnables.SelectedItem, (int)numValeurPosition.Value, null);
                comboBoxPositionnables_SelectedValueChanged(null, null);

                comboBoxPosition.SelectedIndex = index;

                Config.Save();
            }
        }

        private void trackBarValeurPosition_TickValueChanged(object sender, double value)
        {
            numValeurPosition.Value = (decimal)value;
            btnEnvoyerValeurPosition_Click(null, null);
        }

        private void btnEnvoyerValeurPosition_Click(object sender, EventArgs e)
        {
            Positionable positionnable = (Positionable)comboBoxPositionnables.SelectedItem;
            positionnable.SendPosition((int)numValeurPosition.Value);
        }
    }
}
