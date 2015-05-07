using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    public class BrasPiedsGauche : BrasPieds
    {
        public override int Minimum { get { return 1; } }

        public override int Hauteur
        {
            get
            {
                Robots.GrosRobot.DemandeValeursAnalogiques(true);
                return (int)Robots.GrosRobot.ValeursAnalogiques[2];
            }
        }

        public override int PositionPinceBasDroiteFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceBasDroiteFerme; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceBasDroiteFerme = value; }
        }

        public override int PositionPinceBasDroiteOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceBasDroiteOuverte; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceBasDroiteOuverte = value; }
        }

        public override int PositionPinceBasGaucheFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceBasGaucheFermee; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceBasGaucheFermee = value; }
        }

        public override int PositionPinceBasGaucheOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceBasGaucheOuverte; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceBasGaucheOuverte = value; }
        }

        public override int PositionPinceHautDroiteFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceHautDroiteFerme; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceHautDroiteFerme = value; }
        }

        public override int PositionPinceHautDroiteOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceHautDroiteOuverte; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceHautDroiteOuverte = value; }
        }

        public override int PositionPinceHautGaucheFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceHautGaucheFermee; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceHautGaucheFermee = value; }
        }

        public override int PositionPinceHautGaucheOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasGauchePinceHautGaucheOuverte; }
            set { Config.CurrentConfig.PositionGRBrasGauchePinceHautGaucheOuverte = value; }
        }

        public override int PositionHauteurHaute
        {
            get { return Config.CurrentConfig.PositionGRPinceGaucheHauteurHaute; }
            set { Config.CurrentConfig.PositionGRPinceGaucheHauteurHaute = value; }
        }

        public override int PositionHauteurBasse
        {
            get { return Config.CurrentConfig.PositionGRPinceGaucheHauteurBasse; }
            set { Config.CurrentConfig.PositionGRPinceGaucheHauteurBasse = value; }
        }

        public override ServomoteurID ServoHautGauche { get { return ServomoteurID.AscenseurGauchePinceHautGauche; } }
        public override ServomoteurID ServoHautDroite { get { return ServomoteurID.AscenseurGauchePinceHautDroite; } }
        public override ServomoteurID ServoBasGauche { get { return ServomoteurID.AscenseurGauchePinceBasGauche; } }
        public override ServomoteurID ServoBasDroite { get { return ServomoteurID.AscenseurGauchePinceBasDroite; } }

        public override MoteurID MoteurHauteur { get { return MoteurID.AscenseurGauche; } }

        public override int DifferenceHauteurSwitchBas { get { return 200; } }
        public override int DifferenceHauteurBasHaut { get { return 1800; } }
        public override int DifferenceHauteurBas2 { get { return 200; } }
        public override int DifferenceHauteurBas3 { get { return 270; } }
    }
}
