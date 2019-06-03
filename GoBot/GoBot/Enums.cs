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
        ExitLauncherRight = 0,
        LauncherRight = 1,
        CalibrationRight = 2,
        Unused03 = 3,

        FingerFront = 4,
        Unused05 = 5,
        Unused06 = 6,
        FingerBack = 7,

        CalibrationLeft= 8,
        LauncherLeft = 9,
        ExitLauncherLeft = 10,
        Unloader = 11,

        GoldClampRight = 12,
        GoldElevationRight = 13,
        WiperRight = 14,
        Unused15 = 15,

        ClampRight = 16,
        Unused17 = 17,
        Elevation = 18,
        ClampLeft = 19,

        GoldClampLeft = 20,
        GoldElevationLeft = 21,
        WiperLeft = 22,
        Unused23 = 23,
    }

    public enum MatchColor
    {
        LeftYellow,
        RightViolet
    }

    public enum MoteurID
    {
        FingerFront = 0, // RecIO
        FingerBack = 1, // RecIO
        AvailableOnRecIO2 = 2, // RecIO
        AvailableOnRecIO3 = 3, // RecIO

        Beacon = 0x10, // RecMove

        Gulp = 11, // RecMove
        AvailableOnRecMove12 = 12 // RecMove
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
        Ground = 0,
        Avoid = 1
    }

    public enum Board
    {
        PC = 0xA1,
        RecMove = 0xC1,
        RecIO = 0xC4,
        RecGB = 0xC2,
        RecCan = 0xC5
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

    public static class EnumExtensions
    {
        public static int Factor(this SensAR sens)
        {
            return sens == SensAR.Avant ? 1 : -1;
        }

        public static int Factor(this SensGD sens)
        {
            return sens == SensGD.Droite ? 1 : -1;
        }
    }
}
