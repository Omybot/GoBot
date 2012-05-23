using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM.IHMGrosRobot
{
    public partial class PanelPinces : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelPinces()
        {
            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            InitializeComponent();

            tailleMax = groupPinces.Height;
            tailleMin = 39;

            Deployer(Config.CurrentConfig.PincesGROuvert);

            if (Config.CurrentConfig.PincesPrecisGROuvert)
                tabControl.SelectedIndex = 1;
        }

        public void Init()
        {
            trackBrasBasDroite.SetValue(Config.CurrentConfig.PosPinceDroiteBasActuelle);
            trackBrasMilieuDroite.SetValue(Config.CurrentConfig.PosPinceDroiteMilieuActuelle);
            trackBrasHautDroite.SetValue(Config.CurrentConfig.PosPinceDroiteHautActuelle);
            trackBrasBasGauche.SetValue(Config.CurrentConfig.PosPinceGaucheBasActuelle);
            trackBrasMilieuGauche.SetValue(Config.CurrentConfig.PosPinceGaucheMilieuActuelle);
            trackBrasHautGauche.SetValue(Config.CurrentConfig.PosPinceGaucheHautActuelle);
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

            Config.CurrentConfig.PincesGROuvert = deployer;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                Config.CurrentConfig.PincesBooleenGROuvert = true;
                Config.CurrentConfig.PincesPrecisGROuvert = false;
            }
            else
            {
                Config.CurrentConfig.PincesBooleenGROuvert = false;
                Config.CurrentConfig.PincesPrecisGROuvert = true;
            }
        }
        
        private void enregistrerCommeOuvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = contextMenuStrip.SourceControl;

            if (c == trackBrasHautDroite)
                Config.CurrentConfig.PosPinceDroiteHautOuvert = (int)trackBrasHautDroite.Value;
            else if (c == trackBrasMilieuDroite)
                Config.CurrentConfig.PosPinceDroiteMilieuOuvert = (int)trackBrasMilieuDroite.Value;
            else if (c == trackBrasBasDroite)
                Config.CurrentConfig.PosPinceDroiteBasOuvert = (int)trackBrasBasDroite.Value;
            else if (c == trackBrasHautGauche)
                Config.CurrentConfig.PosPinceGaucheHautOuvert = (int)trackBrasHautGauche.Value;
            else if (c == trackBrasMilieuGauche)
                Config.CurrentConfig.PosPinceGaucheMilieuOuvert = (int)trackBrasMilieuGauche.Value;
            else if (c == trackBrasBasGauche)
                Config.CurrentConfig.PosPinceGaucheBasOuvert = (int)trackBrasBasGauche.Value;
            else if (c == trackBarBenne)
                Config.CurrentConfig.PosBenneOuvert = (int)trackBarBenne.Value;

            led.On(true, true);
        }

        private void enregistrerCommeFerméToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = contextMenuStrip.SourceControl;

            if (c == trackBrasHautDroite)
                Config.CurrentConfig.PosPinceDroiteHautFerme = (int)trackBrasHautDroite.Value;
            else if (c == trackBrasMilieuDroite)
                Config.CurrentConfig.PosPinceDroiteMilieuFerme = (int)trackBrasMilieuDroite.Value;
            else if (c == trackBrasBasDroite)
                Config.CurrentConfig.PosPinceDroiteBasFerme = (int)trackBrasBasDroite.Value;
            else if (c == trackBrasHautGauche)
                Config.CurrentConfig.PosPinceGaucheHautFerme = (int)trackBrasHautGauche.Value;
            else if (c == trackBrasMilieuGauche)
                Config.CurrentConfig.PosPinceGaucheMilieuFerme = (int)trackBrasMilieuGauche.Value;
            else if (c == trackBrasBasGauche)
                Config.CurrentConfig.PosPinceGaucheBasFerme = (int)trackBrasBasGauche.Value;
            else if (c == trackBarBenne)
                Config.CurrentConfig.PosBenneFerme = (int)trackBarBenne.Value;

            led.On(true, true);
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupPinces.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        #region HautGauche

        private void switchHautGauche_ChangementEtat(bool actif)
        {
            if (actif)
            {
                trackBrasHautGauche.SetValue(Config.CurrentConfig.PosPinceGaucheHautOuvert);
                pictureBoxHautGauche.Image = global::GoBot.Properties.Resources.HautDroiteOuvert;
            }
            else
            {
                trackBrasHautGauche.SetValue(Config.CurrentConfig.PosPinceGaucheHautFerme);
                pictureBoxHautGauche.Image = global::GoBot.Properties.Resources.HautDroiteFerme;
            }
        }

        private void trackBrasHautGauche_TickValueChanged()
        {
            GrosRobot.BougeBrasHautGauche((int)trackBrasHautGauche.Value);
            Config.CurrentConfig.PosPinceGaucheHautActuelle = (int)trackBrasHautGauche.Value;
        }

        private void trackBrasHautGauche_ValueChanged()
        {
            lblBrasHautGauche.Text = (int)trackBrasHautGauche.Value + "";

            if (trackBrasHautGauche.Value > Config.CurrentConfig.PosPinceGaucheHautFerme)
            {
                pictureBoxHautGauche2.Image = global::GoBot.Properties.Resources.HautDroiteFerme;
                switchHautGauche.setActif(false, false);
            }
            else if (trackBrasHautGauche.Value <= Config.CurrentConfig.PosPinceGaucheHautOuvert)
            {
                pictureBoxHautGauche2.Image = global::GoBot.Properties.Resources.HautDroiteOuvert;
                switchHautGauche.setActif(true, false);
            }
        }

        #endregion

        #region MilieuGauche

        private void switchMilieuGauche_ChangementEtat(bool actif)
        {
            if (actif)
            {
                trackBrasMilieuGauche.SetValue(Config.CurrentConfig.PosPinceGaucheMilieuOuvert);
                pictureBoxMilieuGauche.Image = global::GoBot.Properties.Resources.MilieuDroiteOuvert;
            }
            else
            {
                trackBrasMilieuGauche.SetValue(Config.CurrentConfig.PosPinceGaucheMilieuFerme);
                pictureBoxMilieuGauche.Image = global::GoBot.Properties.Resources.MilieuDroiteFerme;
            }
        }

        private void trackBrasMilieuGauche_TickValueChanged()
        {
            GrosRobot.BougeBrasMilieuGauche((int)trackBrasMilieuGauche.Value);
            Config.CurrentConfig.PosPinceGaucheMilieuActuelle = (int)trackBrasMilieuGauche.Value;
        }

        private void trackBrasMilieuGauche_ValueChanged()
        {
            lblBrasMilieuGauche.Text = (int)trackBrasMilieuGauche.Value + "";

            if (trackBrasMilieuGauche.Value > Config.CurrentConfig.PosPinceGaucheMilieuFerme)
            {
                pictureBoxMilieuGauche2.Image = global::GoBot.Properties.Resources.MilieuDroiteFerme;
                switchMilieuGauche.setActif(false, false);
            }
            else if (trackBrasMilieuGauche.Value <= Config.CurrentConfig.PosPinceGaucheMilieuOuvert)
            {
                pictureBoxMilieuGauche2.Image = global::GoBot.Properties.Resources.MilieuDroiteOuvert;
                switchMilieuGauche.setActif(true, false);
            }
        }

        #endregion

        #region BasGauche
        
        private void switchBasGauche_ChangementEtat(bool actif)
        {
            if (actif)
            {
                trackBrasBasGauche.SetValue(Config.CurrentConfig.PosPinceGaucheBasOuvert);
                pictureBoxBasGauche.Image = global::GoBot.Properties.Resources.BasDroiteOuvert;
            }
            else
            {
                trackBrasBasGauche.SetValue(Config.CurrentConfig.PosPinceGaucheBasFerme);
                pictureBoxBasGauche.Image = global::GoBot.Properties.Resources.BasDroiteFerme;
            }
        }

        private void trackBrasBasGauche_TickValueChanged()
        {
            GrosRobot.BougeBrasBasGauche((int)trackBrasBasGauche.Value);
            Config.CurrentConfig.PosPinceGaucheBasActuelle = (int)trackBrasBasGauche.Value;
        }

        private void trackBrasBasGauche_ValueChanged()
        {
            lblBrasBasGauche.Text = (int)trackBrasBasGauche.Value + "";

            if (trackBrasBasGauche.Value > Config.CurrentConfig.PosPinceGaucheBasFerme)
            {
                pictureBoxBasGauche2.Image = global::GoBot.Properties.Resources.BasDroiteFerme;
                switchBasGauche.setActif(false, false);
            }
            else if (trackBrasBasGauche.Value <= Config.CurrentConfig.PosPinceGaucheBasOuvert)
            {
                pictureBoxBasGauche2.Image = global::GoBot.Properties.Resources.BasDroiteOuvert;
                switchBasGauche.setActif(true, false);
            }
        }

        #endregion

        #region BasDroite

        private void switchBasDroite_ChangementEtat(bool actif)
        {
            if (actif)
            {
                trackBrasBasDroite.SetValue(Config.CurrentConfig.PosPinceDroiteBasOuvert);
                pictureBoxBasDroite.Image = global::GoBot.Properties.Resources.BasGaucheOuvert;
            }
            else
            {
                trackBrasBasDroite.SetValue(Config.CurrentConfig.PosPinceDroiteBasFerme);
                pictureBoxBasDroite.Image = global::GoBot.Properties.Resources.BasGaucheFerme;
            }
        }

        private void trackBrasBasDroite_TickValueChanged()
        {
            GrosRobot.BougeBrasBasDroite((int)trackBrasBasDroite.Value);
            Config.CurrentConfig.PosPinceDroiteBasActuelle = (int)trackBrasBasDroite.Value;
        }

        private void trackBrasBasDroite_ValueChanged()
        {
            lblBrasBasDroite.Text = (int)trackBrasBasDroite.Value + "";

            if (trackBrasBasDroite.Value < Config.CurrentConfig.PosPinceDroiteBasFerme)
            {
                pictureBoxBasDroite2.Image = global::GoBot.Properties.Resources.BasGaucheFerme;
                switchBasDroite.setActif(false, false);
            }
            else if (trackBrasBasDroite.Value >= Config.CurrentConfig.PosPinceDroiteBasOuvert)
            {
                pictureBoxBasDroite2.Image = global::GoBot.Properties.Resources.BasGaucheOuvert;
                switchBasDroite.setActif(true, false);
            }
        }

        #endregion

        #region MilieuDroite

        private void switchMilieuDroite_ChangementEtat(bool actif)
        {
            if (actif)
            {
                trackBrasMilieuDroite.SetValue(Config.CurrentConfig.PosPinceDroiteMilieuOuvert);
                pictureBoxMilieuDroite.Image = global::GoBot.Properties.Resources.MilieuGaucheOuvert;
            }
            else
            {
                trackBrasMilieuDroite.SetValue(Config.CurrentConfig.PosPinceDroiteMilieuFerme);
                pictureBoxMilieuDroite.Image = global::GoBot.Properties.Resources.MilieuGaucheFerme;
            }
        }

        private void trackBrasMilieuDroite_TickValueChanged()
        {
            GrosRobot.BougeBrasMilieuDroite((int)trackBrasMilieuDroite.Value);
            Config.CurrentConfig.PosPinceDroiteMilieuActuelle = (int)trackBrasMilieuDroite.Value;
        }

        private void trackBrasMilieuDroite_ValueChanged()
        {
            lblBrasMilieuDroite.Text = (int)trackBrasMilieuDroite.Value + "";

            if (trackBrasMilieuDroite.Value < Config.CurrentConfig.PosPinceDroiteMilieuFerme)
            {
                pictureBoxMilieuDroite2.Image = global::GoBot.Properties.Resources.MilieuGaucheFerme;
                switchMilieuDroite.setActif(false, false);
            }
            else if (trackBrasMilieuDroite.Value >= Config.CurrentConfig.PosPinceDroiteMilieuOuvert)
            {
                pictureBoxMilieuDroite2.Image = global::GoBot.Properties.Resources.MilieuGaucheOuvert;
                switchMilieuDroite.setActif(true, false);
            }
        }

        #endregion

        #region HautDroite

        private void switchHautDroite_ChangementEtat(bool actif)
        {
            if (actif)
            {
                trackBrasHautDroite.SetValue(Config.CurrentConfig.PosPinceDroiteHautOuvert);
                pictureBoxHautDroite.Image = global::GoBot.Properties.Resources.HautGaucheOuvert;
            }
            else
            {
                trackBrasHautDroite.SetValue(Config.CurrentConfig.PosPinceDroiteHautFerme);
                pictureBoxHautDroite.Image = global::GoBot.Properties.Resources.HautGaucheFerme;
            }
        }

        private void trackBrasHautDroite_TickValueChanged()
        {
            GrosRobot.BougeBrasHautDroite((int)trackBrasHautDroite.Value);
            Config.CurrentConfig.PosPinceDroiteHautActuelle = (int)trackBrasHautDroite.Value;
        }

        private void trackBrasHautDroite_ValueChanged()
        {
            lblBrasHautDroite.Text = (int)trackBrasHautDroite.Value + "";

            if (trackBrasHautDroite.Value < Config.CurrentConfig.PosPinceDroiteHautFerme)
            {
                pictureBoxHautDroite2.Image = global::GoBot.Properties.Resources.HautGaucheFerme;
                switchHautDroite.setActif(false, false);
            }
            else if (trackBrasHautDroite.Value >= Config.CurrentConfig.PosPinceDroiteHautOuvert)
            {
                pictureBoxHautDroite2.Image = global::GoBot.Properties.Resources.HautGaucheOuvert;
                switchHautDroite.setActif(true, false);
            }
        }

        #endregion

        private void switchBoutonGauche_ChangementEtat(bool actif)
        {
            switchMilieuGauche.setActif(actif);
            switchHautGauche.setActif(actif);
        }

        private void switchBoutonBenne_ChangementEtat_1(bool actif)
        {
            if (actif)
            {
                trackBarBenne.SetValue(Config.CurrentConfig.PosBenneOuvert);
            }
            else
            {
                trackBarBenne.SetValue(Config.CurrentConfig.PosBenneFerme);
            }
        }

        private void trackBarBenne_ValueChanged_1()
        {
            lblBenne.Text = (int)trackBarBenne.Value + "";

            /*if (trackBarBenne.Value < Config.CurrentConfig.PosBenneFerme)
            {
                switchBoutonBenne.setActif(false, false);
            }
            else if (trackBrasHautDroite.Value >= Config.CurrentConfig.PosBenneOuvert)
            {
                switchBoutonBenne.setActif(true, false);
            }*/
        }

        private void trackBarBenne_TickValueChanged_1()
        {
            GrosRobot.BougeBenne((int)trackBarBenne.Value);
            Config.CurrentConfig.PosBenneActuelle = (int)trackBarBenne.Value;

        }

        private void enregistrerCommeDroitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Control c = contextMenuStrip.SourceControl;

            if (c == trackBrasBasDroite)
            {
                Config.CurrentConfig.PosPinceDroiteBasMilieu = (int)trackBrasBasDroite.Value;

                led.On(true, true);
            }
            else if (c == trackBrasBasGauche)
            {
                Config.CurrentConfig.PosPinceGaucheBasMilieu = (int)trackBrasBasGauche.Value;

                led.On(true, true);
            }

        }

    }
}
