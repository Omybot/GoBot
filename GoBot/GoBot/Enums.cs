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

        Chariot = 50,

        BloqueurBas = 106,
        BloqueurHaut = 107,
        Rehausseur = 3,

        Ejecteur = 114,

        BrasLunaireGauche = 26,
        BrasLunaireDroit = 24,

        ServoLunaireGaucheSerrageGauche = 102,
        ServoLunaireGaucheSerrageDroit = 103,

        ServoLunaireDroitSerrageGauche = 108,
        ServoLunaireDroitSerrageDroit = 111,

        Plaqueur = 23,

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
        Bouton1,
        Bouton2,
        Bouton3,
        Bouton4,
        Bouton5,
        Bouton6,
        Bouton7,
        Bouton8,
        Bouton9,
        Bouton10,
        Jack,
        CouleurEquipe,
        LSwitch1,
        LSwitch2,
        LSwitch3,
        LSwitch4,
    }

    public enum CapteurCouleurID
    {
        CouleurTube = 0
    }

    public enum CodeurID
    {
        Manuel = 0
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
        DebugA1 = 15,
        DebugA2 = 14,
        DebugA3 = 13,
        DebugA4 = 12,
        DebugA5 = 11,
        DebugA6 = 10,
        DebugA7 = 9,
        DebugA8 = 8,
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
