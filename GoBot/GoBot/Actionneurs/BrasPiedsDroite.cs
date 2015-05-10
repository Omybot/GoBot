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
                Robots.GrosRobot.DemandeValeursAnalogiquesIO(true);
                return (int)Robots.GrosRobot.ValeursAnalogiquesIO[0];
            } 
        }

        public override int PositionPinceBasDroiteFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitBasDroit.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurDroitBasDroit.PositionFerme = value; }
        }

        public override int PositionPinceBasDroiteOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitBasDroit.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurDroitBasDroit.PositionOuvert = value; }
        }

        public override int PositionPinceBasGaucheFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitBasGauche.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurDroitBasGauche.PositionFerme = value; }
        }

        public override int PositionPinceBasGaucheOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitBasGauche.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurDroitBasGauche.PositionOuvert = value; }
        }

        public override int PositionPinceHautDroiteFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitHautDroit.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurDroitHautDroit.PositionFerme = value; }
        }

        public override int PositionPinceHautDroiteOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitHautDroit.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurDroitHautDroit.PositionOuvert = value; }
        }

        public override int PositionPinceHautGaucheFermee
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitHautGauche.PositionFerme; }
            set { Config.CurrentConfig.ServoAscenseurDroitHautGauche.PositionFerme = value; }
        }

        public override int PositionPinceHautGaucheOuverte
        {
            get { return Config.CurrentConfig.ServoAscenseurDroitHautGauche.PositionOuvert; }
            set { Config.CurrentConfig.ServoAscenseurDroitHautGauche.PositionOuvert = value; }
        }

        public override int PositionHauteurHaute
        {
            get { return Config.CurrentConfig.AscenseurDroit.PositionHaute; }
            set { Config.CurrentConfig.AscenseurDroit.PositionHaute = value; }
        }

        public override int PositionHauteurBasse
        {
            get { return Config.CurrentConfig.AscenseurDroit.PositionAttrapage; }
            set { Config.CurrentConfig.AscenseurDroit.PositionAttrapage = value; }
        }

        public override ServomoteurID ServoHautGauche { get { return ServomoteurID.AscenseurDroitPinceHautGauche; } }
        public override ServomoteurID ServoHautDroite { get { return ServomoteurID.AscenseurDroitPinceHautDroite; } }
        public override ServomoteurID ServoBasGauche { get { return ServomoteurID.AscenseurDroitPinceBasGauche; } }
        public override ServomoteurID ServoBasDroite { get { return ServomoteurID.AscenseurDroitPinceBasDroite; } }

        public override MoteurID MoteurHauteur { get { return MoteurID.AscenseurDroit; } }

        public override int DifferenceHauteurSwitchBas { get { return -50; } }
        public override int DifferenceHauteurBasHaut { get { return -1850; } }
        public override int DifferenceHauteurBas2 { get { return -300; } }
        public override int DifferenceHauteurBas3 { get { return -330; } }

        public override void Verrouiller()
        {
            Config.CurrentConfig.ServoBalleVerrouillageDroit.Positionner(Config.CurrentConfig.ServoBalleVerrouillageDroit.PositionFerme);
        }

        public override void Deverrouiller()
        {
            Config.CurrentConfig.ServoBalleVerrouillageDroit.Positionner(Config.CurrentConfig.ServoBalleVerrouillageDroit.PositionOuvert);
        }

        public override void LibererBalle()
        {
            Config.CurrentConfig.ServoBalleVerrouillageDroit.Positionner(Config.CurrentConfig.ServoBalleVerrouillageDroit.PositionLibere);
        }
    }
}
