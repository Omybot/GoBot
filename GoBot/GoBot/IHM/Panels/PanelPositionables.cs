using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

using GoBot.Actionneurs;

namespace GoBot.IHM
{
    public partial class PanelPositionables : UserControl
    {
        public Dictionary<String, PropertyInfo> _dicProperties;

        public PanelPositionables()
        {
            InitializeComponent();
        }

        private void PanelPositionables_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                cboPositionables.Items.AddRange(Config.Positionnables.ToArray());
            }
        }

        private void cboPositionables_SelectedValueChanged(object sender, EventArgs e)
        {
            Positionable positionnable = (Positionable)cboPositionables.SelectedItem;

            PropertyInfo[] properties = positionnable.GetType().GetProperties();

            List<String> positionsName = new List<string>();
            _dicProperties = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "ID")
                {
                    positionsName.Add(Config.PropertyNameToScreen(property) + " : " + property.GetValue(positionnable, null));
                    _dicProperties.Add(positionsName[positionsName.Count - 1], property);
                }
            }

            cboPositions.Items.Clear();
            cboPositions.Items.AddRange(positionsName.ToArray());

            trkPosition.Min = positionnable.Minimum;
            trkPosition.Max = positionnable.Maximum;

            btnSend.Enabled = true;
            btnSave.Enabled = false;
        }

        private void cboPositions_SelectedValueChanged(object sender, EventArgs e)
        {
            String[] tab = ((String)(cboPositions.SelectedItem)).Split(new char[]{':'});

            String position = tab[0].Trim();
            int valeur = Convert.ToInt32(tab[1].Trim());

            numPosition.Value = valeur;

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String[] tab = ((String)(cboPositions.SelectedItem)).Split(new char[] { ':' });

            String position = tab[0].Trim().ToLower();
            int valeur = Convert.ToInt32(tab[1].Trim());
            
            if (MessageBox.Show(this, "Êtes vous certain de vouloir sauvegarder la position " + position + " de l'actionneur " + cboPositionables.Text.ToLower() + " à " + numPosition.Value + " (anciennement " + valeur + ") ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int index = cboPositions.SelectedIndex;

                _dicProperties[(String)cboPositions.SelectedItem].SetValue((Positionable)cboPositionables.SelectedItem, (int)numPosition.Value, null);
                cboPositionables_SelectedValueChanged(null, null);

                cboPositions.SelectedIndex = index;

                Config.Save();
            }
        }

        private void trkPosition_TickValueChanged(object sender, double value)
        {
            numPosition.Value = (decimal)value;
            SendPosition();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendPosition();
        }

        private void SendPosition()
        {
            Positionable positionnable = (Positionable)cboPositionables.SelectedItem;
            positionnable?.SendPosition((int)numPosition.Value);
        }
    }
}
