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

        BrasLunaireAvance = 108,
        BrasLunaireMonte = 20,

        Chariot = 50,

        BloqueurBas = 106,
        BloqueurHaut = 107,
        Rehausseur = 3,

        Ejecteur = 102,

        BrasLunaireGauche = 199, // TODO bon ID
        BrasLunaireDroit = 198, // TODO bon ID

        ServoLunaireGaucheSerrageGauche = 197, // TODO bon ID
        ServoLunaireGaucheSerrageDroit = 196, // TODO bon ID

        ServoLunaireDroitSerrageGauche = 195, // TODO bon ID
        ServoLunaireDroitSerrageDroit = 194, // TODO bon ID

        Plaqueur = 193, // TODO bon ID

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
        Debug1 = 1,
        Debug2 = 2,
        Debug3 = 3,
        Debug4 = 4,
        Debug5 = 5,
        Debug6 = 6,
        Debug7 = 7,
        Debug8 = 8,
        Debug9 = 9,
        Debug10 = 10,
        Debug11 = 11,
        Debug12 = 12,
        Debug13 = 13,
        Debug14 = 14,
        Debug15 = 15,
        Debug16 = 16
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
