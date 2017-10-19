using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        // Exemple
        // public ServoAscenseurDroitBasDroit ServoAscenseurDroitBasDroit { get; set; }

        public ServoPinceLunaireSerrageGauche ServoPinceLunaireSerrageGauche { get; set; }
        public ServoPinceLunaireSerrageDroit ServoPinceLunaireSerrageDroit { get; set; }
        public ServoLunaireChariot ServoLunaireChariot { get; set; }
        public ServoLunaireMonte ServoLunaireMonte { get; set; }
        public ServoBloqueurBas ServoBloqueurBas { get; set; }
        public ServoBloqueurHaut ServoBloqueurHaut { get; set; }
        public ServoEjecteur ServoEjecteur { get; set; }
        public ServoRehausseur ServoRehausseur { get; set; }
        public MoteurOrientation MoteurOrientation { get; set; }
        public MoteurConvoyeur MoteurConvoyeur { get; set; }
        public ServoCalleur ServoCalleur { get; set; }

        public ServoBrasLunaireGauche ServoBrasLunaireGauche { get; set; }
        public ServoLunaireGaucheSerrageDroit ServoLunaireGaucheSerrageDroit { get; set; }
        public ServoLunaireGaucheSerrageGauche ServoLunaireGaucheSerrageGauche { get; set; }

        public ServoBrasLunaireDroit ServoBrasLunaireDroit { get; set; }
        public ServoLunaireDroitSerrageDroit ServoLunaireDroitSerrageDroit { get; set; }
        public ServoLunaireDroitSerrageGauche ServoLunaireDroitSerrageGauche { get; set; }

        public ServoPlaqueur ServoPlaqueur { get; set; }
        public ServoFusee ServoFusee { get; set; }
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

    public class ServoCalleur : PositionableServo
    {
        public int PositionCalle { get; set; }
        public int PositionRange { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.Calleur; } }
    }

    public class ServoFusee : PositionableServo
    {
        public int PositionArme { get; set; }
        public int PositionFeu { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.Fusee; } }
    }

    public class ServoPlaqueur : PositionableServo
    {
        public int PositionPlaque { get; set; }
        public int PositionRange { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.Plaqueur; } }
    }

    public abstract class ServoBrasLunaire : PositionableServo
    {
        public int PositionSortie { get; set; }
        public int PositionSortieSafe { get; set; }
        public int PositionRange { get; set; }
        public int PositionStockage { get; set; }
    }

    public class ServoBrasLunaireGauche : ServoBrasLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireGauche; } }
    }

    public class ServoBrasLunaireDroit : ServoBrasLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireDroit; } }
    }

    public class ServoLunaireChariot : PositionableServo
    {
        public int PositionSortie { get; set; }
        public int PositionStockage { get; set; }
        public int PositionRange { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireAvance; } }
    }

    public class ServoLunaireMonte : PositionableServo
    {
        public int PositionBas { get; set; }
        public int PositionMoyenne { get; set; }
        public int PositionHaut { get; set; }
        public override ServomoteurID ID { get { return ServomoteurID.BrasLunaireMonte; } }
    }

    public abstract class ServoPinceLunaire : PositionableServo
    {
        public int PositionOuvert { get; set; }
        public int PositionFerme { get; set; }
        public int PositionSemiFerme { get; set; }
    }

    public abstract class ServoBloqueur : PositionableServo
    {
        public int PositionRentre { get; set; }
        public int PositionSorti { get; set; }
    }

    public class ServoBloqueurHaut : ServoBloqueur
    {
        public override ServomoteurID ID { get { return ServomoteurID.BloqueurHaut; } }
    }

    public class ServoBloqueurBas : ServoBloqueur
    {
        public override ServomoteurID ID { get { return ServomoteurID.BloqueurBas; } }
    }

    public class ServoRehausseur : PositionableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.Rehausseur; } }
        public int PositionRange { get; set; }
        public int PositionBasse { get; set; }
        public int PositionHaute { get; set; }
    }

    public class ServoEjecteur : PositionableServo
    {
        public override ServomoteurID ID { get { return ServomoteurID.Ejecteur; } }
        public int PositionRentre { get; set; }
        public int PositionSorti { get; set; }
    }

    public class ServoPinceLunaireSerrageGauche : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireSerrageGauche; } }
    }

    public class ServoPinceLunaireSerrageDroit : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireSerrageDroit; } }
    }

    public class ServoLunaireDroitSerrageDroit : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireDroitSerrageDroit; } }
    }

    public class ServoLunaireDroitSerrageGauche : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireDroitSerrageGauche; } }
    }

    public class ServoLunaireGaucheSerrageDroit : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireGaucheSerrageDroit; } }
    }

    public class ServoLunaireGaucheSerrageGauche : ServoPinceLunaire
    {
        public override ServomoteurID ID { get { return ServomoteurID.ServoLunaireGaucheSerrageGauche; } }
    }

    #endregion

    #region PositionableMotorSpeed

    public class MoteurOrientation : PositionableMotorSpeed
    {
        public int ValeurTourneGauche { get; set; }
        public int ValeurTourneDroite { get; set; }
        public int ValeurStop { get; set; }

        public override MoteurID ID { get { return MoteurID.Orienteur; } }
    }

    public class MoteurConvoyeur : PositionableMotorSpeed
    {
        public int ValeurAvale { get; set; }
        public int ValeurRecrache { get; set; }
        public int ValeurStop { get; set; }

        public override MoteurID ID { get { return MoteurID.Transfert; } }
    }

    #endregion
}
