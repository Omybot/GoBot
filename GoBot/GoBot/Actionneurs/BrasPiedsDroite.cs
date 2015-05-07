using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    public class BrasPiedsDroite : BrasPieds
    {
        public override int Minimum { get { return 4000; } }

        public override int Hauteur 
        { 
            get 
            {
                Robots.GrosRobot.DemandeValeursAnalogiques(true);
                return (int)Robots.GrosRobot.ValeursAnalogiques[0];
            } 
        }

        public override int PositionPinceBasDroiteFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceBasDroiteFerme; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceBasDroiteFerme = value; }
        }

        public override int PositionPinceBasDroiteOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceBasDroiteOuverte; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceBasDroiteOuverte = value; }
        }

        public override int PositionPinceBasGaucheFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceBasGaucheFermee; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceBasGaucheFermee = value; }
        }

        public override int PositionPinceBasGaucheOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceBasGaucheOuverte; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceBasGaucheOuverte = value; }
        }

        public override int PositionPinceHautDroiteFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceHautDroiteFerme; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceHautDroiteFerme = value; }
        }

        public override int PositionPinceHautDroiteOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceHautDroiteOuverte; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceHautDroiteOuverte = value; }
        }

        public override int PositionPinceHautGaucheFermee
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceHautGaucheFermee; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceHautGaucheFermee = value; }
        }

        public override int PositionPinceHautGaucheOuverte
        {
            get { return Config.CurrentConfig.PositionGRBrasDroitPinceHautGaucheOuverte; }
            set { Config.CurrentConfig.PositionGRBrasDroitPinceHautGaucheOuverte = value; }
        }

        public override int PositionHauteurHaute
        {
            get { return Config.CurrentConfig.PositionGRPinceDroiteHauteurHaute; }
            set { Config.CurrentConfig.PositionGRPinceDroiteHauteurHaute = value; }
        }

        public override int PositionHauteurBasse
        {
            get { return Config.CurrentConfig.PositionGRPinceDroiteHauteurBasse; }
            set { Config.CurrentConfig.PositionGRPinceDroiteHauteurBasse = value; }
        }

        public override ServomoteurID ServoHautGauche { get { return ServomoteurID.AscenseurDroitPinceHautGauche; } }
        public override ServomoteurID ServoHautDroite { get { return ServomoteurID.AscenseurDroitPinceHautDroite; } }
        public override ServomoteurID ServoBasGauche { get { return ServomoteurID.AscenseurDroitPinceBasGauche; } }
        public override ServomoteurID ServoBasDroite { get { return ServomoteurID.AscenseurDroitPinceBasDroite; } }

        public override MoteurID MoteurHauteur { get { return MoteurID.AscenseurDroit; } }

        public override int DifferenceHauteurSwitchBas { get { return -50; } }
        public override int DifferenceHauteurBasHaut { get { return -1850; } }
        public override int DifferenceHauteurBas2 { get { return -200; } }
        public override int DifferenceHauteurBas3 { get { return -270; } }
    }
}
