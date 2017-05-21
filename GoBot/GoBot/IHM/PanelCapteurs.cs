using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelCapteurs : UserControl
    {
        Timer tCouleur;

        public PanelCapteurs()
        {
            InitializeComponent();
        }

        private void btnColor_ChangementEtat(object sender, EventArgs e)
        {
            if (btnColor.Actif)
            {
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.AlimCapteurCouleur, true);
                Robots.GrosRobot.CapteurCouleurChange += GrosRobot_CapteurCouleurChange;
                tCouleur = new Timer();
                tCouleur.Tick += tCouleur_Tick;
                tCouleur.Interval = 50;
                tCouleur.Start();
            }
            else
            {
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.AlimCapteurCouleur, false);
                Robots.GrosRobot.CapteurCouleurChange -= GrosRobot_CapteurCouleurChange;
                tCouleur.Stop();
                tCouleur.Dispose();
            }
        }

        void tCouleur_Tick(object sender, EventArgs e)
        {
            Robots.GrosRobot.DemandeCapteurCouleur(CapteurCouleurID.CouleurTube, false);
        }

        void GrosRobot_CapteurCouleurChange(CapteurCouleurID capteur, Color couleur)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    GrosRobot_CapteurCouleurChange(capteur, couleur);
                }));
            }
            else
            {
                if (capteur == CapteurCouleurID.CouleurTube)
                    picColor.SetColor(couleur);
            }
        }

        private void PanelCapteurs_Load(object sender, EventArgs e)
        {
            picColor.SetColor(Color.Black);
        }
    }
}
