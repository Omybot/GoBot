using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM.IHMPetitRobot
{
    public partial class PanelBras : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelBras()
        {
            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            InitializeComponent();

            tailleMax = groupPinces.Height;
            tailleMin = 39;

            Deployer(Config.CurrentConfig.PincesPROuvert);

            if (Config.CurrentConfig.PincesPrecisPROuvert)
                tabControl.SelectedIndex = 1;
        }

        public void Init()
        {
            trackBrasDroite.SetValue(Config.CurrentConfig.PosBrasDroiteActuel);
            trackBrasGauche.SetValue(Config.CurrentConfig.PosBrasGaucheActuel);
        }

        private void trackBrasDroite_ValueChanged()
        {
            int valeur = (int)trackBrasDroite.Value;
            lblBrasDroite.Text = valeur + "";
        }

        private void trackBrasGauche_ValueChanged()
        {
            int valeur = (int)trackBrasGauche.Value;
            lblBrasGauche.Text = valeur + "";
        }

        private void trackBrasDroite_TickValueChanged()
        {
            int valeur = (int)trackBrasDroite.Value;
            //PetitRobot.BougeBrasDroite(valeur);
            Config.CurrentConfig.PosBrasDroiteActuel = valeur;

            if (valeur < Config.CurrentConfig.PosBrasDroiteRange)
                trackBarBrasDroiteUtil.SetValue(0, false);
            else if (valeur < Config.CurrentConfig.PosBrasDroiteRange)
                trackBarBrasDroiteUtil.SetValue(1, false);
            else
                trackBarBrasDroiteUtil.SetValue(2, false);
        }

        private void trackBrasGauche_TickValueChanged()
        {
            int valeur = (int)trackBrasGauche.Value;
            //PetitRobot.BougeBrasGauche(valeur);
            Config.CurrentConfig.PosBrasGaucheActuel = valeur;

            if (valeur < Config.CurrentConfig.PosBrasGaucheRange)
                trackBarBrasGaucheUtil.SetValue(0, false);
            else if (valeur < Config.CurrentConfig.PosBrasGaucheRange)
                trackBarBrasGaucheUtil.SetValue(1, false);
            else
                trackBarBrasGaucheUtil.SetValue(2, false);
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupPinces.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupPinces.Controls)
                    c.Visible = false;
                btnTaille.Visible = true;

                groupPinces.Height = tailleMin;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupPinces.Controls)
                    c.Visible = true;
                btnTaille.Visible = true;

                groupPinces.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.PincesPROuvert = deployer;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                Config.CurrentConfig.PincesBooleenPROuvert = true;
                Config.CurrentConfig.PincesPrecisPROuvert = false;
            }
            else
            {
                Config.CurrentConfig.PincesBooleenPROuvert = false;
                Config.CurrentConfig.PincesPrecisPROuvert = true;
            }
        }

        private void EnregistrerPositionReplie(object sender, EventArgs e)
        {
            Control c = contextMenuStrip.SourceControl;

            if (c == trackBrasDroite)
                Config.CurrentConfig.PosBrasDroiteReplie = (int)trackBrasDroite.Value;
            else if (c == trackBrasGauche)
                Config.CurrentConfig.PosBrasGaucheReplie = (int)trackBrasGauche.Value;

            led.On(true, true);
        }

        private void EnregistrerPositionDeplie(object sender, EventArgs e)
        {
            Control c = contextMenuStrip.SourceControl;

            if (c == trackBrasDroite)
                Config.CurrentConfig.PosBrasDroiteDeplie = (int)trackBrasDroite.Value;
            else if (c == trackBrasGauche)
                Config.CurrentConfig.PosBrasGaucheDeplie = (int)trackBrasGauche.Value;

            led.On(true, true);
        }

        private void EnregistrerPositionRange(object sender, EventArgs e)
        {
            Control c = contextMenuStrip.SourceControl;

            if (c == trackBrasDroite)
                Config.CurrentConfig.PosBrasDroiteRange = (int)trackBrasDroite.Value;
            else if (c == trackBrasGauche)
                Config.CurrentConfig.PosBrasGaucheRange = (int)trackBrasGauche.Value;

            led.On(true, true);
        }

        private void switchBoutonPompeGauche_ChangementEtat(bool actif)
        {
            //PetitRobot.ActiverPompeGauche(actif);
        }

        private void switchBoutonPompeDroite_ChangementEtat(bool actif)
        {
            //PetitRobot.ActiverPompeDroite(actif);
        }

        private void trackBarBrasGaucheUtil_TickValueChanged()
        {
            if (trackBarBrasGaucheUtil.Value == 0)
            {
                trackBrasGauche.SetValue(Config.CurrentConfig.PosBrasGaucheReplie);
            }
            else if (trackBarBrasGaucheUtil.Value == 1)
            {
                trackBrasGauche.SetValue(Config.CurrentConfig.PosBrasGaucheRange);
            }
            else if (trackBarBrasGaucheUtil.Value == 2)
            {
                trackBrasGauche.SetValue(Config.CurrentConfig.PosBrasGaucheDeplie);
            }
        }

        private void trackBarBrasDroiteUtil_TickValueChanged()
        {
            if (trackBarBrasDroiteUtil.Value == 0)
            {
                trackBrasDroite.SetValue(Config.CurrentConfig.PosBrasDroiteReplie);
            }
            else if (trackBarBrasDroiteUtil.Value == 1)
            {
                trackBrasDroite.SetValue(Config.CurrentConfig.PosBrasDroiteRange);
            }
            else if (trackBarBrasDroiteUtil.Value == 2)
            {
                trackBrasDroite.SetValue(Config.CurrentConfig.PosBrasDroiteDeplie);
            }
        }
    }
}
