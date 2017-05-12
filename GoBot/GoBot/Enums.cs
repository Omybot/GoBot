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

        BrasLunaireAvance = 1,
        BrasLunaireMonte = 20,

        Chariot = 50,

        BloqueurBas = 60,
        BloqueurHaut = 61,
        Rehausseur = 3,

        Ejecteur = 70,

        Tous = 254
    }

    public enum MoteurID
    {
        Orienteur = 0,
        Transfert = 1,
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
        Alimentation = 1
    }

    public enum ActionneurValeur
    {
        Alimentation = 1
    }

    public enum CapteurOnOffID
    {
        Jack = 0
    }

    public enum CapteurCouleur
    {
        CouleurTube = 0
    }

    public enum LidarID
    {
        LidarSol = 0
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
