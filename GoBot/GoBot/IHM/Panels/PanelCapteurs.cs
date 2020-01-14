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

        private void btnColor_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.AlimCapteurCouleur, true);
                Robots.MainRobot.SensorColorChanged += GrosRobot_SensorColorChanged;
                tCouleur = new Timer();
                tCouleur.Tick += tCouleur_Tick;
                tCouleur.Interval = 50;
                tCouleur.Start();
            }
            else
            {
                Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.AlimCapteurCouleur, false);
                Robots.MainRobot.SensorColorChanged -= GrosRobot_SensorColorChanged;
                tCouleur.Stop();
                tCouleur.Dispose();
            }
        }

        void tCouleur_Tick(object sender, EventArgs e)
        {
            Robots.MainRobot.ReadSensorColor(SensorColorID.CouleurTube, false);
        }

        void GrosRobot_SensorColorChanged(SensorColorID capteur, Color couleur)
        {
            this.InvokeAuto(() =>
            {
                if (capteur == SensorColorID.CouleurTube)
                    picColor.SetColor(couleur);
            });
        }

        private void PanelCapteurs_Load(object sender, EventArgs e)
        {
            picColor.SetColor(Color.Black);
        }
    }
}
