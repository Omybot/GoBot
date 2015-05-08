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
            get { return Config.CurrentConfig.ServoAscenseurGaucheBasDroit.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurGaucheBasDroit.PositionFerme = value; }
        }

        public override int PositionPinceBasDroiteOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheBasDroit.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurGaucheBasDroit.PositionOuvert = value; }
        }

        public override int PositionPinceBasGaucheFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheBasGauche.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurGaucheBasGauche.PositionFerme = value; }
        }

        public override int PositionPinceBasGaucheOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheBasGauche.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurGaucheBasGauche.PositionOuvert = value; }
        }

        public override int PositionPinceHautDroiteFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheHautDroit.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurGaucheHautDroit.PositionFerme = value; }
        }

        public override int PositionPinceHautDroiteOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheHautDroit.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurGaucheHautDroit.PositionOuvert = value; }
        }

        public override int PositionPinceHautGaucheFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheHautGauche.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurGaucheHautGauche.PositionFerme = value; }
        }

        public override int PositionPinceHautGaucheOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurGaucheHautGauche.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurGaucheHautGauche.PositionOuvert = value; }
        }

        public override int PositionHauteurHaute
        {
            get { return Config.CurrentConfig.AscenseurGauche.PositionHaute; }
            set { Config.CurrentConfig.AscenseurGauche.PositionHaute = value; }
        }

        public override int PositionHauteurBasse
        {
            get { return Config.CurrentConfig.AscenseurGauche.PositionAttrapage; }
            set { Config.CurrentConfig.AscenseurGauche.PositionAttrapage = value; }
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
