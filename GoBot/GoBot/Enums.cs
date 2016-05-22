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
        PinceBasLateralGaucheAvant = 100,
        PinceBasLateralGaucheArriere = 101,
        PinceBasLateralDroiteAvant = 102,
        PinceBasLateralDroiteArriere = 103,
        PinceBasGauche = 4,
        PinceBasDroite = 2,
        BrasDroite = 3,
        BrasGauche= 9,
        MaintienDroite = 19,
        MaintienGauche = 20,
        VerrouGauche = 22,
        VerrouDroite = 17,
        Tous = 254
    }

    public enum MoteurID
    {
        BrasGauche = 1,
        BrasDroite = 0,
        Balise = 2,
        PompeBarre = 3
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
        //SwitchBrasDroitHaut = 0,
        //SwitchBrasDroitBas = 1,
        //OptiqueBrasDroit = 2,

        //SwitchBrasGaucheHaut = 3,
        //SwitchBrasGaucheBas = 4,
        //OptiqueBrasGauche = 5,
        
        //SwitchBrasDroiteOrigine = 6,
        //SwitchBrasGaucheOrigine = 7
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
