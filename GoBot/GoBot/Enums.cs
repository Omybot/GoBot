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
        ServoLunaireSerrageGauche = 100,
        ServoLunaireSerrageDroit = 101,

        BrasLunaireAvance = 112,
        BrasLunaireMonte = 20,

        BloqueurBas = 107,
        BloqueurHaut = 106,
        Rehausseur = 3,

        Ejecteur = 117,

        BrasLunaireGauche = 26,
        BrasLunaireDroit = 24,

        ServoLunaireGaucheSerrageGauche = 102,
        ServoLunaireGaucheSerrageDroit = 103,

        ServoLunaireDroitSerrageGauche = 104,
        ServoLunaireDroitSerrageDroit = 105,

        Plaqueur = 23,

        Calleur = 110,

        Fusee = 116,

        Tous = 254
    }

    public enum MatchColor
    {
        LeftBlue,
        RightYellow
    }

    public enum MoteurID
    {
        Orienteur = 4,
        Transfert = 3,
        Balise = 2,
    }

    public enum CapteurID
    {
        Balise = 1,
        BaliseRapide1 = 2,
        BaliseRapide2 = 3
    }

    public enum ActionneurOnOffID
    {
        AlimCapteurCouleur = 1
    }

    public enum CapteurOnOffID
    {
        Bouton2 = 0,
        Bouton4 = 1,
        Bouton1 = 2,
        Bouton3 = 3,
        Bouton10 = 4,
        Bouton8 = 5,
        Bouton9 = 6,
        Bouton7 = 7,
        Bouton6 = 8,
        CouleurEquipe = 9,
        Jack = 10,
        Bouton5 = 11,
        LSwitch1 = 12,
        LSwitch2 = 13,
        LSwitch3 = 14,
        LSwitch4 = 15,
        ChaiPas = 16,
        ChaiPlus = 17,
        PresenceDroite = 18,
        PresenceGauche = 19,
        PresenceCentre = 0x51,
        PresenceOnSaitPasOu = 0x52
    }

    public enum CapteurCouleurID
    {
        CouleurTube = 0
    }

    public enum CodeurID
    {
        Manuel = 1
    }

    public enum LedRgbID
    {
        CouleurMatch = 0
    }

    public enum BaliseID
    {
        Principale = 0
    }

    public enum LedID
    {
        DebugA1 = 8,
        DebugA2 = 9,
        DebugA3 = 10,
        DebugA4 = 11,
        DebugA5 = 12,
        DebugA6 = 13,
        DebugA7 = 14,
        DebugA8 = 15,

        DebugB8 = 7,
        DebugB7 = 6,
        DebugB6 = 5,
        DebugB5 = 4,
        DebugB4 = 3,
        DebugB3 = 2,
        DebugB2 = 1,
        DebugB1 = 0
    }

    public enum LidarID
    {
        ScanSol = 0
    }

    public enum Carte
    {
        PC = 0xA1,
        RecMove = 0xC1,
        RecIO = 0xC4,
        RecGB = 0xC2,
        Balise = 0xB1
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
