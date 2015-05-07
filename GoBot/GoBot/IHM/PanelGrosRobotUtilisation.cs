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

namespace GoBot.IHM
{
    public partial class PanelGrosRobotUtilisation : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotUtilisation()
        {
            InitializeComponent();
            ledBrasDroitSwitchHaut.Parent = pictureBoxBrasDroit;
            ledBrasDroitSwitchBas.Parent = pictureBoxBrasDroit;
            ledBarriereOptiqueDroite.Parent = pictureBoxBrasDroit;
            ledBrasDroitSwitchBas.SetBounds(ledBrasDroitSwitchBas.Left - pictureBoxBrasDroit.Left, ledBrasDroitSwitchBas.Top - pictureBoxBrasDroit.Top, ledBrasDroitSwitchBas.Width, ledBrasDroitSwitchBas.Height);
            ledBrasDroitSwitchHaut.SetBounds(ledBrasDroitSwitchHaut.Left - pictureBoxBrasDroit.Left, ledBrasDroitSwitchHaut.Top - pictureBoxBrasDroit.Top, ledBrasDroitSwitchHaut.Width, ledBrasDroitSwitchHaut.Height);
            ledBarriereOptiqueDroite.SetBounds(ledBarriereOptiqueDroite.Left - pictureBoxBrasDroit.Left, ledBarriereOptiqueDroite.Top - pictureBoxBrasDroit.Top, ledBarriereOptiqueDroite.Width, ledBarriereOptiqueDroite.Height);

            ledBrasGaucheSwitchHaut.Parent = pictureBoxBrasGauche;
            ledBrasGaucheSwitchBas.Parent = pictureBoxBrasGauche;
            ledBarriereOptiqueGauche.Parent = pictureBoxBrasGauche;
            ledBrasGaucheSwitchBas.SetBounds(ledBrasGaucheSwitchBas.Left - pictureBoxBrasGauche.Left, ledBrasGaucheSwitchBas.Top - pictureBoxBrasGauche.Top, ledBrasGaucheSwitchBas.Width, ledBrasGaucheSwitchBas.Height);
            ledBrasGaucheSwitchHaut.SetBounds(ledBrasGaucheSwitchHaut.Left - pictureBoxBrasGauche.Left, ledBrasGaucheSwitchHaut.Top - pictureBoxBrasGauche.Top, ledBrasGaucheSwitchHaut.Width, ledBrasGaucheSwitchHaut.Height);
            ledBarriereOptiqueGauche.SetBounds(ledBarriereOptiqueGauche.Left - pictureBoxBrasGauche.Left, ledBarriereOptiqueGauche.Top - pictureBoxBrasGauche.Top, ledBarriereOptiqueGauche.Width, ledBarriereOptiqueGauche.Height);

            if(!Config.DesignMode)
                Robots.GrosRobot.ChangementEtatCapteurOnOff += new Robot.ChangementEtatCapteurOnOffDelegate(GrosRobot_ChangementEtatCapteurOnOff);

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxUtilisation.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxUtilisation_Deploiement);
        }

        void GrosRobot_ChangementEtatCapteurOnOff(CapteurOnOffID capteur, bool etat)
        {
            switch (capteur)
            {
                case CapteurOnOffID.SwitchBrasDroitBas:
                    if (etat)
                        ledBrasDroitSwitchBas.CouleurVert();
                    else
                        ledBrasDroitSwitchBas.CouleurRouge();
                    break;
                case CapteurOnOffID.SwitchBrasDroitHaut:
                    if (etat)
                        ledBrasDroitSwitchHaut.CouleurVert();
                    else
                        ledBrasDroitSwitchHaut.CouleurRouge();
                    break;
                case CapteurOnOffID.SwitchBrasGaucheBas:
                    if (etat)
                        ledBrasGaucheSwitchBas.CouleurVert();
                    else
                        ledBrasGaucheSwitchBas.CouleurRouge();
                    break;
                case CapteurOnOffID.SwitchBrasGaucheHaut:
                    if (etat)
                        ledBrasGaucheSwitchHaut.CouleurVert();
                    else
                        ledBrasGaucheSwitchHaut.CouleurRouge();
                    break;
                case CapteurOnOffID.OptiqueBrasDroit:
                    if (etat)
                        ledBarriereOptiqueDroite.CouleurVert();
                    else
                        ledBarriereOptiqueDroite.CouleurRouge();
                    break;
                case CapteurOnOffID.OptiqueBrasGauche:
                    if (etat)
                        ledBarriereOptiqueGauche.CouleurVert();
                    else
                        ledBarriereOptiqueGauche.CouleurRouge();
                    break;
                case CapteurOnOffID.SwitchBrasDroiteOrigine:
                    if (etat)
                        imgOrigineDroite.Visible = true;
                    else
                        imgOrigineDroite.Visible = false;
                    break;
                case CapteurOnOffID.SwitchBrasGaucheOrigine:
                    if (etat)
                        imgOrigineGauche.Visible = true;
                    else
                        imgOrigineGauche.Visible = false;
                    break;
            }
        }

        void groupBoxUtilisation_Deploiement(bool deploye)
        {
            Config.CurrentConfig.UtilisationGROuvert = deploye;
        }

        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            groupBoxUtilisation.Deployer(Config.CurrentConfig.UtilisationGROuvert, false);
            switchBoutonPuissance.SetActif(true, false);
            DessineBrasDroit();
            DessineBrasGauche();
        }

        private void switchBoutonPuissance_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.AlimentationPuissance(switchBoutonPuissance.Actif);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.SwitchBrasDroiteOrigine);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.OptiqueBrasDroit);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.OptiqueBrasGauche);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.SwitchBrasDroitBas);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.SwitchBrasDroitHaut);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.SwitchBrasGaucheBas);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.SwitchBrasGaucheHaut);
            Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.SwitchBrasGaucheOrigine);
            //Robots.GrosRobot.Diagnostic();
        }

        bool brasGauchePinceMontee = false;
        bool brasGauchePinceHautGaucheFermee = false;
        bool brasGauchePinceHautDroiteFermee = false;
        bool brasGauchePinceBasGaucheFermee = false;
        bool brasGauchePinceBasDroiteFermee = false;

        bool brasDroitPinceMontee = false;
        bool brasDroitPinceHautGaucheFermee = false;
        bool brasDroitPinceHautDroiteFermee = false;
        bool brasDroitPinceBasGaucheFermee = false;
        bool brasDroitPinceBasDroiteFermee = false;

        private void btnHauteurBrasGauche_Click(object sender, EventArgs e)
        {
            brasGauchePinceMontee = !brasGauchePinceMontee;

            if (brasGauchePinceMontee)
            {
                btnOuvertureBrasGauchePinceBasGauche.Top -= 34;
                btnOuvertureBrasGauchePinceBasDroite.Top -= 34;
                ledBrasGaucheSwitchBas.Top -= 34;
                btnBrasGaucheOuverturePincesBas.Top -= 24;
                btnHauteurBrasGauche.Image = Properties.Resources.Recule;
                Actionneur.BrasPiedsGauche.AscenseurMonter();
            }
            else
            {
                btnOuvertureBrasGauchePinceBasGauche.Top += 34;
                btnOuvertureBrasGauchePinceBasDroite.Top += 34;
                ledBrasGaucheSwitchBas.Top += 34;
                btnBrasGaucheOuverturePincesBas.Top += 24;
                btnHauteurBrasGauche.Image = Properties.Resources.Avance;
                Actionneur.BrasPiedsGauche.AscenseurDescendre();
            }

            DessineBrasGauche();
        }

        private void btnOuvertureBrasGauchePinceBasDroite_Click(object sender, EventArgs e)
        {
            brasGauchePinceBasDroiteFermee = !brasGauchePinceBasDroiteFermee;

            if (brasGauchePinceBasDroiteFermee)
            {
                Actionneur.BrasPiedsGauche.FermerPinceBasDroite();
                btnOuvertureBrasGauchePinceBasDroite.Image = Properties.Resources.VirageArGa;
                btnBrasGaucheOuverturePincesBas.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasGauchePinceBasGaucheFermee)
                    btnBrasGaucheOuverturePincesBas.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsGauche.OuvrirPinceBasDroite();
                btnOuvertureBrasGauchePinceBasDroite.Image = Properties.Resources.VirageArDr;
            }

            DessineBrasGauche();
        }

        private void DessineBrasGauche()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.Rail);
            Graphics g = Graphics.FromImage(bmp);

            int hauteur = brasGauchePinceMontee ? 31 : 65;

            if (brasGauchePinceBasDroiteFermee)
                g.DrawImage(Properties.Resources.PinceGaucheFermee, 0, hauteur, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceGaucheOuverte, 0, hauteur, 40, 59);

            if (brasGauchePinceBasGaucheFermee)
                g.DrawImage(Properties.Resources.PinceDroiteFermee, 39, hauteur, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceDroiteOuverte, 39, hauteur, 40, 59);

            if (brasGauchePinceHautDroiteFermee)
                g.DrawImage(Properties.Resources.PinceGaucheFermee, 0, 0, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceGaucheOuverte, 0, 0, 40, 59);

            if (brasGauchePinceHautGaucheFermee)
                g.DrawImage(Properties.Resources.PinceDroiteFermee, 39, 0, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceDroiteOuverte, 39, 0, 40, 59);

            pictureBoxBrasGauche.Image = bmp;
        }

        private void DessineBrasDroit()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.Rail);
            Graphics g = Graphics.FromImage(bmp);

            int hauteur = brasDroitPinceMontee ? 31 : 65;

            if (brasDroitPinceBasDroiteFermee)
                g.DrawImage(Properties.Resources.PinceGaucheFermee, 0, hauteur, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceGaucheOuverte, 0, hauteur, 40, 59);

            if (brasDroitPinceBasGaucheFermee)
                g.DrawImage(Properties.Resources.PinceDroiteFermee, 39, hauteur, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceDroiteOuverte, 39, hauteur, 40, 59);

            if (brasDroitPinceHautDroiteFermee)
                g.DrawImage(Properties.Resources.PinceGaucheFermee, 0, 0, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceGaucheOuverte, 0, 0, 40, 59);

            if (brasDroitPinceHautGaucheFermee)
                g.DrawImage(Properties.Resources.PinceDroiteFermee, 39, 0, 40, 59);
            else
                g.DrawImage(Properties.Resources.PinceDroiteOuverte, 39, 0, 40, 59);

            pictureBoxBrasDroit.Image = bmp;
        }

        private void btnOuvertureBrasGauchePinceBasGauche_Click(object sender, EventArgs e)
        {
            brasGauchePinceBasGaucheFermee = !brasGauchePinceBasGaucheFermee;

            if (brasGauchePinceBasGaucheFermee)
            {
                Actionneur.BrasPiedsGauche.FermerPinceBasGauche();
                btnOuvertureBrasGauchePinceBasGauche.Image = Properties.Resources.VirageArDr;
                btnBrasGaucheOuverturePincesBas.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasGauchePinceBasDroiteFermee)
                    btnBrasGaucheOuverturePincesBas.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsGauche.OuvrirPinceBasGauche();
                btnOuvertureBrasGauchePinceBasGauche.Image = Properties.Resources.VirageArGa;
            }

            DessineBrasGauche();
        }

        private void btnOuvertureBrasGauchePinceHautGauche_Click(object sender, EventArgs e)
        {
            brasGauchePinceHautGaucheFermee = !brasGauchePinceHautGaucheFermee;

            if (brasGauchePinceHautGaucheFermee)
            {
                Actionneur.BrasPiedsGauche.FermerPinceHautGauche();
                btnOuvertureBrasGauchePinceHautGauche.Image = Properties.Resources.VirageArDr;
                btnBrasGaucheOuverturePincesHaut.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasGauchePinceHautDroiteFermee)
                    btnBrasGaucheOuverturePincesHaut.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsGauche.OuvrirPinceHautGauche();
                btnOuvertureBrasGauchePinceHautGauche.Image = Properties.Resources.VirageArGa;
            }

            DessineBrasGauche();
        }

        private void btnOuvertureBrasGauchePinceHautDroite_Click(object sender, EventArgs e)
        {
            brasGauchePinceHautDroiteFermee = !brasGauchePinceHautDroiteFermee;

            if (brasGauchePinceHautDroiteFermee)
            {
                Actionneur.BrasPiedsGauche.FermerPinceHautDroite();
                btnOuvertureBrasGauchePinceHautDroite.Image = Properties.Resources.VirageArGa;
                btnBrasGaucheOuverturePincesHaut.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasGauchePinceHautGaucheFermee)
                    btnBrasGaucheOuverturePincesHaut.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsGauche.OuvrirPinceHautDroite();
                btnOuvertureBrasGauchePinceHautDroite.Image = Properties.Resources.VirageArDr;
            }

            DessineBrasGauche();
        }




        private void btnOuvertureBrasDroitPinceHautGauche_Click(object sender, EventArgs e)
        {
            brasDroitPinceHautGaucheFermee = !brasDroitPinceHautGaucheFermee;

            if (brasDroitPinceHautGaucheFermee)
            {
                Actionneur.BrasPiedsDroite.FermerPinceHautGauche();
                btnOuvertureBrasDroitPinceHautGauche.Image = Properties.Resources.VirageArDr;
                btnBrasDroitOuverturePincesHaut.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasDroitPinceHautDroiteFermee)
                    btnBrasDroitOuverturePincesHaut.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsDroite.OuvrirPinceHautGauche();
                btnOuvertureBrasDroitPinceHautGauche.Image = Properties.Resources.VirageArGa;
            }

            DessineBrasDroit();
        }

        private void btnHauteurBrasDroit_Click(object sender, EventArgs e)
        {
            brasDroitPinceMontee = !brasDroitPinceMontee;

            if (brasDroitPinceMontee)
            {
                btnOuvertureBrasDroitPinceBasGauche.Top -= 34;
                btnOuvertureBrasDroitPinceBasDroite.Top -= 34;
                ledBrasDroitSwitchBas.Top -= 34;
                btnBrasDroitOuverturePincesBas.Top -= 24;
                btnHauteurBrasDroit.Image = Properties.Resources.Recule;
                Actionneur.BrasPiedsDroite.AscenseurMonter();
            }
            else
            {
                btnOuvertureBrasDroitPinceBasGauche.Top += 34;
                btnOuvertureBrasDroitPinceBasDroite.Top += 34;
                ledBrasDroitSwitchBas.Top += 34;
                btnBrasDroitOuverturePincesBas.Top += 24;
                btnHauteurBrasDroit.Image = Properties.Resources.Avance;
                Actionneur.BrasPiedsDroite.AscenseurDescendre();
            }

            DessineBrasDroit();
        }

        private void btnOuvertureBrasDroitPinceHautDroite_Click(object sender, EventArgs e)
        {
            brasDroitPinceHautDroiteFermee = !brasDroitPinceHautDroiteFermee;

            if (brasDroitPinceHautDroiteFermee)
            {
                Actionneur.BrasPiedsDroite.FermerPinceHautDroite();
                btnOuvertureBrasDroitPinceHautDroite.Image = Properties.Resources.VirageArGa;
                btnBrasDroitOuverturePincesHaut.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasDroitPinceHautGaucheFermee)
                    btnBrasDroitOuverturePincesHaut.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsDroite.OuvrirPinceHautDroite();
                btnOuvertureBrasDroitPinceHautDroite.Image = Properties.Resources.VirageArDr;
            }

            DessineBrasDroit();
        }

        private void btnOuvertureBrasDroitPinceBasGauche_Click(object sender, EventArgs e)
        {
            brasDroitPinceBasGaucheFermee = !brasDroitPinceBasGaucheFermee;

            if (brasDroitPinceBasGaucheFermee)
            {
                Actionneur.BrasPiedsDroite.FermerPinceBasGauche();
                btnOuvertureBrasDroitPinceBasGauche.Image = Properties.Resources.VirageArDr;
                btnBrasDroitOuverturePincesBas.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasDroitPinceBasDroiteFermee)
                    btnBrasDroitOuverturePincesBas.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsDroite.OuvrirPinceBasGauche();
                btnOuvertureBrasDroitPinceBasGauche.Image = Properties.Resources.VirageArGa;
            }

            DessineBrasDroit();
        }

        private void btnOuvertureBrasDroitPinceBasDroite_Click(object sender, EventArgs e)
        {
            brasDroitPinceBasDroiteFermee = !brasDroitPinceBasDroiteFermee;

            if (brasDroitPinceBasDroiteFermee)
            {
                Actionneur.BrasPiedsDroite.FermerPinceBasDroite();
                btnOuvertureBrasDroitPinceBasDroite.Image = Properties.Resources.VirageArGa;
                btnBrasDroitOuverturePincesBas.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                if (!brasDroitPinceBasGaucheFermee)
                    btnBrasDroitOuverturePincesBas.Image = Properties.Resources.FermerPince;
                Actionneur.BrasPiedsDroite.OuvrirPinceBasDroite();
                btnOuvertureBrasDroitPinceBasDroite.Image = Properties.Resources.VirageArDr;
            }

            DessineBrasDroit();
        }

        private void btnBrasDroitOuverturePincesHaut_Click(object sender, EventArgs e)
        {
            if (brasDroitPinceHautDroiteFermee || brasDroitPinceHautGaucheFermee)
            {
                brasDroitPinceHautDroiteFermee = false;
                Actionneur.BrasPiedsDroite.OuvrirPinceHautDroite();
                btnOuvertureBrasDroitPinceHautDroite.Image = Properties.Resources.VirageArDr;

                brasDroitPinceHautGaucheFermee = false;
                Actionneur.BrasPiedsDroite.OuvrirPinceHautGauche();
                btnOuvertureBrasDroitPinceHautGauche.Image = Properties.Resources.VirageArGa;

                btnBrasDroitOuverturePincesHaut.Image = Properties.Resources.FermerPince;
            }
            else
            {
                brasDroitPinceHautDroiteFermee = true;
                Actionneur.BrasPiedsDroite.FermerPinceHautDroite();
                btnOuvertureBrasDroitPinceHautDroite.Image = Properties.Resources.VirageArGa;

                brasDroitPinceHautGaucheFermee = true;
                Actionneur.BrasPiedsDroite.FermerPinceHautGauche();
                btnOuvertureBrasDroitPinceHautGauche.Image = Properties.Resources.VirageArDr;

                btnBrasDroitOuverturePincesHaut.Image = Properties.Resources.OuvrirPince;
            }

            DessineBrasDroit();
        }

        private void btnBrasDroitOuverturePincesBas_Click(object sender, EventArgs e)
        {
            if (brasDroitPinceBasDroiteFermee || brasDroitPinceBasGaucheFermee)
            {
                brasDroitPinceBasDroiteFermee = false;
                Actionneur.BrasPiedsDroite.OuvrirPinceBasDroite();
                btnOuvertureBrasDroitPinceBasDroite.Image = Properties.Resources.VirageArDr;

                brasDroitPinceBasGaucheFermee = false;
                Actionneur.BrasPiedsDroite.OuvrirPinceBasGauche();
                btnOuvertureBrasDroitPinceBasGauche.Image = Properties.Resources.VirageArGa;

                btnBrasDroitOuverturePincesBas.Image = Properties.Resources.FermerPince;
            }
            else
            {
                brasDroitPinceBasDroiteFermee = true;
                Actionneur.BrasPiedsDroite.FermerPinceBasDroite();
                btnOuvertureBrasDroitPinceBasDroite.Image = Properties.Resources.VirageArGa;

                brasDroitPinceBasGaucheFermee = true;
                Actionneur.BrasPiedsDroite.FermerPinceBasGauche();
                btnOuvertureBrasDroitPinceBasGauche.Image = Properties.Resources.VirageArDr;

                btnBrasDroitOuverturePincesBas.Image = Properties.Resources.OuvrirPince;
            }

            DessineBrasDroit();
        }

        private void btnBrasGaucheOuverturePincesHaut_Click(object sender, EventArgs e)
        {
            if (brasGauchePinceHautDroiteFermee || brasGauchePinceHautGaucheFermee)
            {
                brasGauchePinceHautDroiteFermee = false;
                Actionneur.BrasPiedsGauche.OuvrirPinceHautDroite();
                btnOuvertureBrasGauchePinceHautDroite.Image = Properties.Resources.VirageArDr;

                brasGauchePinceHautGaucheFermee = false;
                Actionneur.BrasPiedsGauche.OuvrirPinceHautGauche();
                btnOuvertureBrasGauchePinceHautGauche.Image = Properties.Resources.VirageArGa;

                btnBrasGaucheOuverturePincesHaut.Image = Properties.Resources.FermerPince;
            }
            else
            {
                brasGauchePinceHautDroiteFermee = true;
                Actionneur.BrasPiedsGauche.FermerPinceHautDroite();
                btnOuvertureBrasGauchePinceHautDroite.Image = Properties.Resources.VirageArGa;

                brasGauchePinceHautGaucheFermee = true;
                Actionneur.BrasPiedsGauche.FermerPinceHautGauche();
                btnOuvertureBrasGauchePinceHautGauche.Image = Properties.Resources.VirageArDr;

                btnBrasGaucheOuverturePincesHaut.Image = Properties.Resources.OuvrirPince;
            }

            DessineBrasGauche();
        }

        private void btnBrasGaucheOuverturePincesBas_Click(object sender, EventArgs e)
        {
            if (brasGauchePinceBasDroiteFermee || brasGauchePinceBasGaucheFermee)
            {
                brasGauchePinceBasDroiteFermee = false;
                Actionneur.BrasPiedsGauche.OuvrirPinceBasDroite();
                btnOuvertureBrasGauchePinceBasDroite.Image = Properties.Resources.VirageArGa;

                brasGauchePinceBasGaucheFermee = false;
                Actionneur.BrasPiedsGauche.OuvrirPinceBasGauche();
                btnOuvertureBrasGauchePinceBasGauche.Image = Properties.Resources.VirageArDr;

                btnBrasGaucheOuverturePincesBas.Image = Properties.Resources.FermerPince;
            }
            else
            {
                brasGauchePinceBasDroiteFermee = true;
                Actionneur.BrasPiedsGauche.FermerPinceBasDroite();
                btnOuvertureBrasGauchePinceBasDroite.Image = Properties.Resources.VirageArDr;

                brasGauchePinceBasGaucheFermee = true;
                Actionneur.BrasPiedsGauche.FermerPinceBasGauche();
                btnOuvertureBrasGauchePinceBasGauche.Image = Properties.Resources.VirageArGa;

                btnBrasGaucheOuverturePincesBas.Image = Properties.Resources.OuvrirPince;
            }

            DessineBrasGauche();
        }

        private bool pinceMontee = false;
        private bool pinceOuverte = true;

        private void btnOuvrirPince_Click(object sender, EventArgs e)
        {
            if (pinceOuverte)
            {
                Actionneur.BrasAmpoule.Fermer();
                btnOuvrirPince.Image = Properties.Resources.OuvrirPince;
            }
            else
            {
                Actionneur.BrasAmpoule.Ouvrir();
                btnOuvrirPince.Image = Properties.Resources.FermerPince;
            }

            pinceOuverte = !pinceOuverte;
            DessinePince();
        }

        private void btnMonterPince_Click(object sender, EventArgs e)
        {
            if (pinceMontee)
            {
                Actionneur.BrasAmpoule.Descendre();
                btnMonterPince.Image = Properties.Resources.Avance;
                btnOuvrirPince.Top += 70;
            }
            else
            {
                Actionneur.BrasAmpoule.Monter();
                btnMonterPince.Image = Properties.Resources.Recule;
                btnOuvrirPince.Top -= 70;
            }

            pinceMontee = !pinceMontee;
            DessinePince();
        }

        private void DessinePince()
        {
            if(pinceOuverte)
            {
                if (pinceMontee)
                    pictureBoxPinceBalle.Image = Properties.Resources.PinceOuverteHaut;
                else
                    pictureBoxPinceBalle.Image = Properties.Resources.PinceOuverteBas;
            }
            else
            {
                if (pinceMontee)
                    pictureBoxPinceBalle.Image = Properties.Resources.PinceFermeeHaut;
                else
                    pictureBoxPinceBalle.Image = Properties.Resources.PinceFermeeBas;
            }
        }

        private void btnCalibrationAscenseurDroit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous effectuer une calibration de l'ascenseur ? Toutes les positions sauvegardées seront recalculées.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Actionneur.BrasPiedsDroite.AscenseurCalibration();
            }
        }

        private void btnCalibrationAscenseurGauche_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous effectuer une calibration de l'ascenseur ? Toutes les positions sauvegardées seront recalculées.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Actionneur.BrasPiedsGauche.AscenseurCalibration();
            }
        }

        private void btnCalibrationAscenseurAmpoule_Click(object sender, EventArgs e)
        {
            Actionneur.BrasAmpoule.AscenseurCalibration();
        }
    }
}
