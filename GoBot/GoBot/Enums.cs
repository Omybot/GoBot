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
        GRAspirateur = 16,
        GRDebloqueur = 0,
        GRGrandBras = 2,
        GRPetitBras = 3,
        GRBrasGauche = 4,
        GRBrasDroit = 1,
        GRCamera = 5,
        GRServoAssiette = 6,

        PRBrasDroit = 18,
        PRBrasGauche = 17,
        PRBrasAvant = 1,
        PRBrasArriere = 20,
        PRBrasAvantGauche = 30,
        PRBrasAvantDroit = 31,
        PRBrasArriereGauche = 32,
        PRBrasArriereDroit = 33
    }

    public enum MoteurID
    {
        GRCanon = 0,
        GRTurbineAspirateur = 1
    }

    public enum CapteurID
    {
        GRPresenceBalle = 0,
        GRCouleurBalle = 1,
        GRPresenceAssiette = 2,
        GRAspiRemonte = 3,
        GRVitesseCanon = 4
    }

    public enum ActionneurOnOffID
    {
        GRShutter = 0,
        GRAlimentation = 1,
        GRPompe = 2
    }

    public enum Carte
    {
        PC = 0xA1,
        RecMove = 0xC1,
        RecMiwi = 0xC2,
        RecPi = 0xC3,
        RecBun = 0xB1,
        RecBeu = 0xB2,
        RecBoi = 0xB3
    }

    public enum CapteurBalise
    {
        CapteurHaut = 1,
        CapteurBas = 0
    }
}
