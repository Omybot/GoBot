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
        /*GRBrasHautGauche = 0x05,
        GRBrasMilieuGauche = 0x01,
        GRBrasBasGauche = 0x02,
        GRBrasBasDroite = 0x10,
        GRBrasMilieuDroite = 0x04,
        GRBrasHautDroite = 0x00,
        GRBenne = 0x14,

        PRBrasDroite = 0x11,
        PRBrasGauche = 0x12*/

        GRAspirateur = 16,
        GRDebloqueur = 0,
        GRGrandBras = 2, //?
        GRPetitBras = 3, // ?
        PRBras = 30, // ?
        GRBrasGauche = 4,
        GRBrasDroit = 1,
        GRCamera = 5
    }

    public enum PompeID
    {
        PRPompeDroite = 0x00,
        PRPompeGauche = 0x01
    }

    public enum Carte
    {
        PC = 0xA1,
        RecMove = 0xC1,
        RecMiwi = 0xC2,
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
