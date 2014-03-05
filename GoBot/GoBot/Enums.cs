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
        GRCoude = 1,
        GREpaule = 2,
        GRPinceDroite = 3,
        GRPinceGauche = 4,
        GRTous = 255,

        PRTous = 255
    }

    public enum MoteurID
    {
        GRCanon = 0,
        GRCanonTMin = 2,
        GRTurbineAspirateur = 1
    }

    public enum CapteurID
    {
        GRPresenceBalle = 0,
        GRCouleurBalle = 1,
        GRPresenceAssiette = 2,
        GRAspiRemonte = 3,
        GRVitesseCanon = 4,
        GRJack
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
