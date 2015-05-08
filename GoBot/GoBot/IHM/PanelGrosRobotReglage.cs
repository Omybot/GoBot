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

            groupBoxReglage.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxReglage_Deploiement);
        }

        void groupBoxReglage_Deploiement(bool deploye)
        {
            Config.CurrentConfig.ReglageGROuvert = deploye;
        }

        private void PanelReglageGros_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                groupBoxReglage.Deployer(Config.CurrentConfig.ReglageGROuvert, false);

                comboBoxPositionnables.Items.AddRange(Config.Positionnables.ToArray());
            }
        }

        public Dictionary<String, PropertyInfo> dicProperties;

        private void comboBoxPositionnables_SelectedValueChanged(object sender, EventArgs e)
        {
            Positionnable positionnable = (Positionnable)comboBoxPositionnables.SelectedItem;

            PropertyInfo[] properties = positionnable.GetType().GetProperties();

            List<String> noms = new List<string>();
            dicProperties = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "ID")
                {
                    noms.Add(PropertyNameToScreen(property) + " - " + property.GetValue(positionnable, null));
                    dicProperties.Add(noms[noms.Count - 1], property);
                }
            }

            comboBoxPosition.Items.Clear();
            comboBoxPosition.Items.AddRange(noms.ToArray());

            trackBarValeurPosition.Min = positionnable.Minimum;
            trackBarValeurPosition.Max = positionnable.Maximum;
        }

        public string PropertyNameToScreen(PropertyInfo property)
        {
            String typeName = property.Name;
            String nom = "";

            foreach (char c in typeName)
            {
                char ch = c;
                if (c <= 'Z')
                    nom += " " + (char)(c + 32);
                else
                    nom += c;
            }

            nom = typeName.Substring(0, 1) + nom.Substring(2);

            return nom;
        }

        private void comboBoxPosition_SelectedValueChanged(object sender, EventArgs e)
        {
            String[] tab = ((String)(comboBoxPosition.SelectedItem)).Split(new char[] { '-' });

            String position = tab[0].Trim();
            int valeur = Convert.ToInt32(tab[1].Trim());

            numValeurPosition.Value = valeur;
        }

        private void btnSauvegarderPosition_Click(object sender, EventArgs e)
        {
            String[] tab = ((String)(comboBoxPosition.SelectedItem)).Split(new char[] { '-' });

            String position = tab[0].Trim().ToLower();
            int valeur = Convert.ToInt32(tab[1].Trim());


            if (MessageBox.Show("Êtes vous certain de vouloir sauvegarder la position " + position + " de l'actionneur " + comboBoxPositionnables.Text.ToLower() + " à " + numValeurPosition.Value + " (anciennement " + valeur + ") ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int index = comboBoxPosition.SelectedIndex;

                dicProperties[(String)comboBoxPosition.SelectedItem].SetValue((Positionnable)comboBoxPositionnables.SelectedItem, (int)numValeurPosition.Value, null);
                comboBoxPositionnables_SelectedValueChanged(null, null);

                comboBoxPosition.SelectedIndex = index;
            }
        }

        private void trackBarValeurPosition_TickValueChanged(object sender, EventArgs e)
        {
            numValeurPosition.Value = (decimal)trackBarValeurPosition.Value;
            btnEnvoyerValeurPosition_Click(null, null);
        }

        private void btnEnvoyerValeurPosition_Click(object sender, EventArgs e)
        {
            Positionnable positionnable = (Positionnable)comboBoxPositionnables.SelectedItem;
            positionnable.Positionner((int)numValeurPosition.Value);
        }
    }
}
