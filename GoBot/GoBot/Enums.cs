using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    public enum SensAR
    {
        Avant = 0,
        Arriere = 1
    }

    public enum SensGD
    {
        Gauche = 2,
        Droite = 3
    }

    public enum StopMode
    {
        Freely = 0x00,
        Smooth = 0x01,
        Abrupt = 0x02
    }

    public enum ServomoteurID
    {
        PinceAmpoule = 4,

        AspirateurEpaule = 5,
        AspirateurCoude = 2,

        TapisBras = 50,
        TapisPinceGauche = 51,
        TapisPinceDroite = 52,

        BalleVerouillageGauche = 53,
        BalleVerouillageDroit = 54,

        AscenseurDroitPinceBasDroite = 10,
        AscenseurDroitPinceBasGauche = 11,
        AscenseurDroitPinceHautDroite = 12,
        AscenseurDroitPinceHautGauche = 13,

        AscenseurGauchePinceBasDroite = 14,
        AscenseurGauchePinceBasGauche = 15,
        AscenseurGauchePinceHautDroite = 16,
        AscenseurGauchePinceHautGauche = 17,

        Tous = 254
    }

    public enum MoteurID
    {
        AscenseurDroit = 1,
        AscenseurGauche = 0,
        Balise = 2,
        AscenseurAmpoule = 3
    }

    public enum CapteurID
    {
        Jack = 0,
        Balise = 1,
        BaliseRapide1 = 2,
        BaliseRapide2 = 3,
    }

    public enum ActionneurOnOffID
    {
        Alimentation = 1
    }

    public enum CapteurOnOffID
    {
        SwitchBrasDroitHaut = 0,
        SwitchBrasDroitBas = 1,
        OptiqueBrasDroit = 2,

        SwitchBrasGaucheHaut = 3,
        SwitchBrasGaucheBas = 4,
        OptiqueBrasGauche = 5,
        
        SwitchBrasDroiteOrigine = 6,
        SwitchBrasGaucheOrigine = 7
    }

    public enum Carte
    {
        PC = 0xA1,
        RecMove = 0xC1,
        RecMiwi = 0xC2,
        RecPi = 0xC3,
        RecIO = 0xC4,
        RecBun = 0xB1,
        RecBeu = 0xB2,
        RecBoi = 0xB3
    }

    public enum ServoBaudrate
    {
        b1000000 = 1,
        b500000 = 3,
        b400000 = 4,
        b250000 = 7,
        b200000 = 9,
        b115200 = 16,
        b57600 = 34,
        b19200 = 103,
        b9600 = 207
    }
}
