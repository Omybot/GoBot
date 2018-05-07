using System;
using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        // Exemple
        // public ServoAscenseurDroitBasDroit ServoAscenseurDroitBasDroit { get; set; }
        
        public MoteurPompeDroite MoteurPompeDroite { get; set; }
        public ValveDroite ValveDroite { get; set; }
        public ServoCoudeDroite ServoCoudeDroite { get; set; }
        public ServoPoignetDroite ServoPoignetDroite { get; set; }
        public ServoLateralDroite ServoLateralDroite { get; set; }

        public MoteurPompeGauche MoteurPompeGauche { get; set; }
        public ValveGauche ValveGauche { get; set; }
        public ServoCoudeGauche ServoCoudeGauche { get; set; }
        public ServoPoignetGauche ServoPoignetGauche { get; set; }
        public ServoLateralGauche ServoLateralGauche { get; set; }

        public ServoConvoyeurGauche ServoConvoyeurGauche { get; set; }
        public ServoConvoyeurCentre ServoConvoyeurCentre { get; set; }
        public ServoConvoyeurDroite ServoConvoyeurDroite { get; set; }

        public ServoBenneLiberation ServoBenneLiberation { get; set; }
        public ServoBenneOuverture ServoBenneOuverture { get; set; }

        public MoteurElevation MoteurElevation { get; set; }
    }
}

namespace GoBot.Actionneurs
{
    #region PositionableServo

    // Exemple :
    //public abstract class ServoAscenseurPince : PositionnableServo
    //{
    //    public int PositionOuvert { get; set; }
    //    public int PositionFerme { get; set; }
    //    public int PositionPousse { get; set; }
    //}

    //public class ServoAscenseurDroitHautDroit : ServoAscenseurPince
    //{
    //    public override ServomoteurID ID { get { return ServomoteurID.AscenseurDroitPinceHautDroite; } }
    //}
    

    public abstract class ServoConvoyeur : PositionableServo
    {
        public int PositionAvant { get; set; }
        public int PositionArriere { get; set; }
    }

    public abstract class ServoCoude : PositionableServo
    {
        public int PositionRange { get; set; }
        public int PositionApprocheHaute { get; set; }
        public int PositionApprocheBasse { get; set; }
        public int PositionPrise { get; set; }
        public int PositionTampon { get; set; }
    }

    public abstract class ServoPoignet : PositionableServo
    {
        public int PositionRange { get; set; }
        public int PositionPrise { get; set; }
    }

    public abstract class ServoLateral : PositionableServo
    {
        public int PositionGauche { get; set; }
        public int PositionCentre { get; set; }
        public int PositionDroite { get; set; }
        public int PositionStockage { get; set; }
    }

    public class ServoConvoyeurGauche : ServoConvoyeur
    {
        public override ServomoteurID ID => ServomoteurID.ConvoyeurGauche;
    }

    public class ServoConvoyeurDroite : ServoConvoyeur
    {
        public override ServomoteurID ID => ServomoteurID.ConvoyeurDroite;
    }

    public class ServoConvoyeurCentre : ServoConvoyeur
    {
        public override ServomoteurID ID => ServomoteurID.ConvoyeurCentre;
    }

    public class ServoCoudeGauche : ServoCoude
    {
        public override ServomoteurID ID => ServomoteurID.CoudeGauche;
    }

    public class ServoCoudeDroite : ServoCoude
    {
        public override ServomoteurID ID => ServomoteurID.CoudeDroite;
    }

    public class ServoPoignetGauche : ServoPoignet
    {
        public override ServomoteurID ID => ServomoteurID.PoignetGauche;
    }

    public class ServoPoignetDroite : ServoPoignet
    {
        public override ServomoteurID ID => ServomoteurID.PoignetDroite;
    }

    public class ServoLateralGauche : ServoLateral
    {
        public override ServomoteurID ID => ServomoteurID.LateralGauche;
    }

    public class ServoLateralDroite : ServoLateral
    {
        public override ServomoteurID ID => ServomoteurID.LateralDroite;
    }

    public class ValveGauche : PositionnableValve
    {
        public override MoteurID ID => MoteurID.ValveLeft;
    }

    public class ValveDroite : PositionnableValve
    {
        public override MoteurID ID => MoteurID.ValveRight;
    }

    public class ServoBenneLiberation : PositionableServo
    {
        public int PositionLiberation { get; set; }
        public int PositionMaintien { get; set; }

        public override ServomoteurID ID => ServomoteurID.BenneLiberation;
    }

    public class ServoBenneOuverture : PositionableServo
    {
        public int PositionOuvert { get; set; }
        public int PositionDeblocage { get; set; }
        public int PositionFerme { get; set; }

        public override ServomoteurID ID => ServomoteurID.BenneOuverture;
    }

    #endregion

    #region PositionableMotorSpeed

    public class MoteurPompeDroite : PositionnablePump
    {
        public override MoteurID ID { get { return MoteurID.PumpRight; } }
    }

    public class MoteurPompeGauche : PositionnablePump
    {
        public override MoteurID ID { get { return MoteurID.PumpLeft; } }
    }

    public class MoteurElevation : PositionableMotorSpeed
    {
        public override MoteurID ID { get { return MoteurID.Elevation; } }

        public int DeplacementDepose { get; set; }
        public int DeplacementRange { get; set; }

        public int Neutre { get; set; }

        public int PositionDepose { get; set; }
        public int PositionRange { get; set; }
    }

    #endregion
}
