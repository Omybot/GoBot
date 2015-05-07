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

        private void btnBrasDroitPinceBasDroiteOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurDroitPinceBasDroite, (int)numBrasDroitPinceBasDroite.Value);
        }

        private void btnBrasDroitPinceBasDroiteFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceBasDroiteFerme = (int)numBrasDroitPinceBasDroite.Value;
        }

        private void btnBrasDroitPinceBasDroiteOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceBasDroiteOuverte = (int)numBrasDroitPinceBasDroite.Value;
        }

        private void btnBrasDroitPinceBasGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurDroitPinceBasGauche, (int)numBrasDroitPinceBasGauche.Value);
        }

        private void btnBrasDroitPinceBasGaucheFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceBasGaucheFermee = (int)numBrasDroitPinceBasGauche.Value;
        }

        private void btnBrasDroitPinceBasGaucheOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceBasGaucheOuverte = (int)numBrasDroitPinceBasGauche.Value;
        }

        private void btnPinceDroiteHauteurOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurDroit, (int)numPinceDroiteHauteur.Value);
        }

        private void btnPinceDroiteHauteurHaute_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRPinceDroiteHauteurHaute = (int)numPinceDroiteHauteur.Value;
        }

        private void btnPinceDroiteHauteurBasse_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRPinceDroiteHauteurBasse = (int)numPinceDroiteHauteur.Value;
        }

        private void trackBarPlusHauteurDroite_TickValueChanged(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.AscenseurHauteur((int)trackBarPlusHauteurDroite.Value);
        }

        private void btnBrasDroitPinceHautDroiteOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurDroitPinceHautDroite, (int)numBrasDroitPinceHautDroite.Value);
        }

        private void btnBrasDroitPinceHautGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurDroitPinceHautGauche, (int)numBrasDroitPinceHautGauche.Value);
        }

        private void btnBrasDroitPinceHautDroiteFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceHautDroiteFerme = (int)numBrasDroitPinceHautDroite.Value;
        }

        private void btnBrasDroitPinceHautGaucheFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceHautGaucheFermee = (int)numBrasDroitPinceHautGauche.Value;
        }

        private void btnBrasDroitPinceHautDroiteOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceHautDroiteOuverte = (int)numBrasDroitPinceHautDroite.Value;
        }

        private void btnBrasDroitPinceHautGaucheOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasDroitPinceHautGaucheOuverte = (int)numBrasDroitPinceHautGauche.Value;
        }

        // Bras gauche

        private void btnBrasGauchePinceBasDroiteOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurGauchePinceBasDroite, (int)numBrasGauchePinceBasDroite.Value);
        }

        private void btnBrasGauchePinceBasDroiteFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceBasDroiteFerme = (int)numBrasGauchePinceBasDroite.Value;
        }

        private void btnBrasGauchePinceBasDroiteOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceBasDroiteOuverte = (int)numBrasGauchePinceBasDroite.Value;
        }

        private void btnBrasGauchePinceBasGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurGauchePinceBasGauche, (int)numBrasGauchePinceBasGauche.Value);
        }

        private void btnBrasGauchePinceBasGaucheFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceBasGaucheFermee = (int)numBrasGauchePinceBasGauche.Value;
        }

        private void btnBrasGauchePinceBasGaucheOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceBasGaucheOuverte = (int)numBrasGauchePinceBasGauche.Value;
        }

        private void btnBrasGauchePinceHautDroiteOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurGauchePinceHautDroite, (int)numBrasGauchePinceHautDroite.Value);
        }

        private void btnBrasGauchePinceHautDroiteFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceHautDroiteFerme = (int)numBrasGauchePinceHautDroite.Value;
        }

        private void btnBrasGauchePinceHautDroiteOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceHautDroiteOuverte = (int)numBrasGauchePinceHautDroite.Value;
        }

        private void btnBrasGauchePinceHautGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.AscenseurGauchePinceHautGauche, (int)numBrasGauchePinceHautGauche.Value);
        }

        private void btnBrasGauchePinceHautGaucheFermee_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceHautGaucheFermee = (int)numBrasGauchePinceHautGauche.Value;
        }

        private void btnBrasGauchePinceHautGaucheOuverte_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBrasGauchePinceHautGaucheOuverte = (int)numBrasGauchePinceHautGauche.Value;
        }

        private void btnPinceGaucheHauteurOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurGauche, (int)numPinceGaucheHauteur.Value);
        }

        private void btnPinceGaucheHauteurHaute_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRPinceGaucheHauteurHaute = (int)numPinceGaucheHauteur.Value;
        }

        private void btnPinceGaucheHauteurBasse_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRPinceGaucheHauteurBasse = (int)numPinceGaucheHauteur.Value;
        }

        private void trackBarPlusHauteurGauche_TickValueChanged(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsGauche.AscenseurHauteur((int)trackBarPlusHauteurGauche.Value);
        }

        private void btnCalibDroit_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.AscenseurCalibration();
        }

        private void btnCalibGauche_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsGauche.AscenseurCalibration();
        }

        private void btnVitesseBrasDroit_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.AscenseurVitesse = (int)numVitesseBrasDroit.Value;
        }

        private void btnAccelerationBrasDroit_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsDroite.AscenseurAcceleration = (int)numAccelerationBrasDroit.Value;
        }

        private void btnVitesseBrasGauche_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsGauche.AscenseurVitesse = (int)numVitesseBrasGauche.Value;
        }

        private void btnAccelerationBrasGauche_Click(object sender, EventArgs e)
        {
            Actionneur.BrasPiedsGauche.AscenseurAcceleration = (int)numAccelerationBrasGauche.Value;
        }

        private void trackBarAmpoule_TickValueChanged(object sender, EventArgs e)
        {
            lblPositionAmpoule.Text = trackBarAmpoule.Value.ToString();
            Actionneur.BrasAmpoule.Hauteur((int)trackBarAmpoule.Value);
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
