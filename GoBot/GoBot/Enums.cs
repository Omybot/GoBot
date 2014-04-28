﻿using System;
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
        GRFeuxCoude = 18,
        GRFruitsCoude = 2,
        GRFruitsEpaule = 4,
        GRFeuxPoignet = 1,

        Tous = 255,

        //zLibre2 = 2,
        zLibre3 = 3,
        //zLibre4 = 4,
        zLibre5 = 5,
        zLibre6 = 6,
        zLibre7 = 7,
        zLibre8 = 8,
        zLibre9 = 9,
        zLibre10 = 10,
        zLibre11 = 11,
        zLibre12 = 12,
        zLibre13 = 13,
        zLibre14 = 14,
        zLibre15 = 15,
        zLibre16 = 16,
        zLibre17 = 17,
        //zLibre18 = 18,
        zLibre19 = 19,
        zLibre20 = 20,
        zLibre21 = 21,
        zLibre22 = 22,
        zLibre23 = 23,
        zLibre24 = 24,
        zLibre25 = 25,
        zLibre26 = 26,
        zLibre27 = 27,
        zLibre28 = 28,
        zLibre29 = 29,
        zLibre30 = 30,
        zLibre31 = 31,
        zLibre32 = 32,
        zLibre33 = 33,
        zLibre34 = 34,
        zLibre35 = 35,
        zLibre36 = 36,
        zLibre37 = 37,
        zLibre38 = 38,
        zLibre39 = 39,
        zLibre40 = 40,
        zLibre41 = 41,
        zLibre42 = 42,
        zLibre43 = 43,
        zLibre44 = 44,
        zLibre45 = 45,
        zLibre46 = 46,
        zLibre47 = 47,
        zLibre48 = 48,
        zLibre49 = 49,
        zLibre50 = 50,
        zLibre51 = 51,
        zLibre52 = 52,
        zLibre53 = 53,
        zLibre54 = 54,
        zLibre55 = 55,
        zLibre56 = 56,
        zLibre57 = 57,
        zLibre58 = 58,
        zLibre59 = 59,
        zLibre60 = 60,
        zLibre61 = 61,
        zLibre62 = 62,
        zLibre63 = 63,
        zLibre64 = 64,
        zLibre65 = 65,
        zLibre66 = 66,
        zLibre67 = 67,
        zLibre68 = 68,
        zLibre69 = 69,
        zLibre70 = 70,
        zLibre71 = 71,
        zLibre72 = 72,
        zLibre73 = 73,
        zLibre74 = 74,
        zLibre75 = 75,
        zLibre76 = 76,
        zLibre77 = 77,
        zLibre78 = 78,
        zLibre79 = 79,
        zLibre80 = 80,
        zLibre81 = 81,
        zLibre82 = 82,
        zLibre83 = 83,
        zLibre84 = 84,
        zLibre85 = 85,
        zLibre86 = 86,
        zLibre87 = 87,
        zLibre88 = 88,
        zLibre89 = 89,
        zLibre90 = 90,
        zLibre91 = 91,
        zLibre92 = 92,
        zLibre93 = 93,
        zLibre94 = 94,
        zLibre95 = 95,
        zLibre96 = 96,
        zLibre97 = 97,
        zLibre98 = 98,
        zLibre99 = 99,
        zLibre100 = 100,
        zLibre101 = 101,
        zLibre102 = 102,
        zLibre103 = 103,
        zLibre104 = 104,
        zLibre105 = 105,
        zLibre106 = 106,
        zLibre107 = 107,
        zLibre108 = 108,
        zLibre109 = 109,
        zLibre110 = 110,
        zLibre111 = 111,
        zLibre112 = 112,
        zLibre113 = 113,
        zLibre114 = 114,
        zLibre115 = 115,
        zLibre116 = 116,
        zLibre117 = 117,
        zLibre118 = 118,
        zLibre119 = 119,
        zLibre120 = 120,
        zLibre121 = 121,
        zLibre122 = 122,
        zLibre123 = 123,
        zLibre124 = 124,
        zLibre125 = 125,
        zLibre126 = 126,
        zLibre127 = 127,
        zLibre128 = 128,
        zLibre129 = 129,
        zLibre130 = 130,
        zLibre131 = 131,
        zLibre132 = 132,
        zLibre133 = 133,
        zLibre134 = 134,
        zLibre135 = 135,
        zLibre136 = 136,
        zLibre137 = 137,
        zLibre138 = 138,
        zLibre139 = 139,
        zLibre140 = 140,
        zLibre141 = 141,
        zLibre142 = 142,
        zLibre143 = 143,
        zLibre144 = 144,
        zLibre145 = 145,
        zLibre146 = 146,
        zLibre147 = 147,
        zLibre148 = 148,
        zLibre149 = 149,
        zLibre150 = 150,
        zLibre151 = 151,
        zLibre152 = 152,
        zLibre153 = 153,
        zLibre154 = 154,
        zLibre155 = 155,
        zLibre156 = 156,
        zLibre157 = 157,
        zLibre158 = 158,
        zLibre159 = 159,
        zLibre160 = 160,
        zLibre161 = 161,
        zLibre162 = 162,
        zLibre163 = 163,
        zLibre164 = 164,
        zLibre165 = 165,
        zLibre166 = 166,
        zLibre167 = 167,
        zLibre168 = 168,
        zLibre169 = 169,
        zLibre170 = 170,
        zLibre171 = 171,
        zLibre172 = 172,
        zLibre173 = 173,
        zLibre174 = 174,
        zLibre175 = 175,
        zLibre176 = 176,
        zLibre177 = 177,
        zLibre178 = 178,
        zLibre179 = 179,
        zLibre180 = 180,
        zLibre181 = 181,
        zLibre182 = 182,
        zLibre183 = 183,
        zLibre184 = 184,
        zLibre185 = 185,
        zLibre186 = 186,
        zLibre187 = 187,
        zLibre188 = 188,
        zLibre189 = 189,
        zLibre190 = 190,
        zLibre191 = 191,
        zLibre192 = 192,
        zLibre193 = 193,
        zLibre194 = 194,
        zLibre195 = 195,
        zLibre196 = 196,
        zLibre197 = 197,
        zLibre198 = 198,
        zLibre199 = 199,
        zLibre200 = 200,
        zLibre201 = 201,
        zLibre202 = 202,
        zLibre203 = 203,
        zLibre204 = 204,
        zLibre205 = 205,
        zLibre206 = 206,
        zLibre207 = 207,
        zLibre208 = 208,
        zLibre209 = 209,
        zLibre210 = 210,
        zLibre211 = 211,
        zLibre212 = 212,
        zLibre213 = 213,
        zLibre214 = 214,
        zLibre215 = 215,
        zLibre216 = 216,
        zLibre217 = 217,
        zLibre218 = 218,
        zLibre219 = 219,
        zLibre220 = 220,
        zLibre221 = 221,
        zLibre222 = 222,
        zLibre223 = 223,
        zLibre224 = 224,
        zLibre225 = 225,
        zLibre226 = 226,
        zLibre227 = 227,
        zLibre228 = 228,
        zLibre229 = 229,
        zLibre230 = 230,
        zLibre231 = 231,
        zLibre232 = 232,
        zLibre233 = 233,
        zLibre234 = 234,
        zLibre235 = 235,
        zLibre236 = 236,
        zLibre237 = 237,
        zLibre238 = 238,
        zLibre239 = 239,
        zLibre240 = 240,
        zLibre241 = 241,
        zLibre242 = 242,
        zLibre243 = 243,
        zLibre244 = 244,
        zLibre245 = 245,
        zLibre246 = 246,
        zLibre247 = 247,
        zLibre248 = 248,
        zLibre249 = 249,
        zLibre250 = 250,
        zLibre251 = 251,
        zLibre252 = 252,
        zLibre253 = 253,
        //zLibre254 = 254,
        //zLibre255 = 255
    }

    public enum MoteurID
    {
        /*GRCanon = 0,
        GRCanonTMin = 2,
        GRTurbineAspirateur = 1*/
        GREpauleFeu = 0x00
    }

    public enum CapteurID
    {
       /* GRPresenceBalle = 0,
        GRCouleurBalle = 1,
        GRPresenceAssiette = 2,
        GRAspiRemonte = 3,
        GRVitesseCanon = 4,
        */
        GRJack
    }

    public enum ActionneurOnOffID
    {
        /*GRShutter = 0,
        GRAlimentation = 1,
        GRPompe = 2*/
        GRElectrovanneFeu = 2,
        GRAlimentation = 1,
        GRPompeFeu = 0,
        GRPinceDroite = 0x10,
        GRPinceGauche = 0x11,
        GRCanonFruit = 0x03
    }

    public enum CapteurOnOff
    {
        GRPresenceBouchon = 0x00
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

    public enum FonctionIO
    {
        CommandeServo = 0x60,

        ArmerJack = 0x70,
        DepartJack = 0x71,
        DemandeCouleurEquipe = 0x72,
        ReponseCouleurEquipe = 0x73,

        Alimentation = 0x80,
        AlimentationCamera = 0x81,
        DemandeTension = 0x82,
        ReponseTension = 0x83,

        ActionneurOnOff = 0x65,
        Moteur = 0x66,

        DemandeCapteurOnOff = 0x74,
        RetourCapteurOnOff = 0x75,

        Debug = 0xEE,

        TestConnexion = 0xF0,
        RetourTestConnexion = 0xF5,
        Reset = 0xF1,
        DemandeJack = 0xF3,
        ReponseJack = 0xF4,
    }

    public enum FonctionMove
    {
        Deplace = 0x01,
        Pivot = 0x03,
        Virage = 0x04,
        Stop = 0x05,
        GoToXY = 0x06,
        Recallage = 0x10,
        FinRecallage = 0x11,
        FinDeplacement = 0x12,
        Blocage = 0x13,

        DemandePositionsCodeurs = 0x43,
        RetourPositionCodeurs = 0x44,
        EnvoiConsigneBrute = 0x45,

        DemandeDiagnostic = 0x46,
        RetourDiagnostic = 0x47,

        DemandePositionXYTeta = 0x30,
        RetourPositionXYTeta = 0x31,
        VitesseLigne = 0x32,
        AccelerationLigne = 0x33,
        VitessePivot = 0x34,
        AccelerationPivot = 0x35,
        CoeffAsservPID = 0x36,
        EnvoiPositionAbsolue = 0x37,

        CommandeServo = 0x60,

        Debug = 0xEE,

        TestConnexion = 0xF0,
        Reset = 0xF1
    }

    public enum FonctionPi
    {
        Deplace = 0x01,
        Pivot = 0x03,
        Virage = 0x04,
        Stop = 0x05,
        GoToXY = 0x06,
        Recallage = 0x10,
        FinRecallage = 0x11,
        FinDeplacement = 0x12,
        Blocage = 0x13,

        DemandePositionsCodeurs = 0x43,
        RetourPositionCodeurs = 0x44,
        EnvoiConsigneBrute = 0x45,

        DemandeDiagnostic = 0x46,
        RetourDiagnostic = 0x47,

        DemandePositionXYTeta = 0x30,
        RetourPositionXYTeta = 0x31,
        VitesseLigne = 0x32,
        AccelerationLigne = 0x33,
        VitessePivot = 0x34,
        AccelerationPivot = 0x35,
        CoeffAsservPID = 0x36,
        EnvoiPositionAbsolue = 0x37,

        CommandeServo = 0x60,

        Debug = 0xEE,

        TestConnexion = 0xF0,
        Reset = 0xF1,

        TestEmission = 0xD4,
        TestEmissionReussi = 0xD5,
        TestEmissionCorrompu = 0xD6,
        TestEmissionPerdu = 0xD7
    }

    public enum FonctionServo
    {
        DemandePositionCible = 0x01,
        RetourPositionCible = 0x02,
        EnvoiPositionCible = 0x03,
        DemandeBaudrate = 0x04,
        RetourBaudrate = 0x05,
        EnvoiBaudrate = 0x06,
        DemandeVitesseMax = 0x07,
        RetourVitesseMax = 0x08,
        EnvoiVitesseMax = 0x09,
        DemandeId = 0x10,
        RetourId = 0x11,
        EnvoiId = 0x12,
        Reset = 0x13,
        DemandeCoupleMaximum = 0x14,
        RetourCoupleMaximum = 0x15,
        EnvoiCoupleMaximum = 0x16,
        DemandeCoupleActive = 0x17,
        RetourCoupleActive = 0x18,
        EnvoiCoupleActive = 0x19,
        DemandeTension = 0x20,
        RetourTension = 0x21,
        DemandeTemperature = 0x22,
        RetourTemperature = 0x23,
        DemandeMouvement = 0x24,
        RetourMouvement = 0x25,
        DemandePositionMinimum = 0x26,
        RetourPositionMinimum = 0x27,
        EnvoiPositionMinimum = 0x28,
        DemandePositionMaximum = 0x29,
        RetourPositionMaximum = 0x30,
        EnvoiPositionMaximum = 0x31,
        DemandeNumeroModele = 0x32,
        RetourNumeroModele = 0x33,
        DemandeVersionFirmware = 0x34,
        RetourVersionFirmware = 0x35,
        DemandeLed = 0x36,
        RetourLed = 0x37,
        EnvoiLed = 0x38,
        DemandeConfigAlarmeLED = 0x42,
        RetourConfigAlarmeLED = 0x43,
        EnvoiConfigAlarmeLED = 0x44,
        DemandeConfigAlarmeShutdown = 0x45,
        RetourConfigAlarmeShutdown = 0x46,
        EnvoiConfigAlarmeShutdown = 0x47,
        DemandeConfigEcho = 0x48,
        RetourConfigEcho = 0x49,
        EnvoiConfigEcho = 0x50,
        DemandeComplianceParams = 0x51,
        RetourComplianceParams = 0x52,
        EnvoiComplianceParams = 0x53,
        DemandePositionActuelle = 0x54,
        RetourPositionActuelle = 0x55,
        DemandeVitesseActuelle = 0x56,
        RetourVitesseActuelle = 0x57,
        DemandeErreurs = 0x58,
        RetourErreurs = 0x59
    }

    public enum FonctionMiwi
    {
        Transmettre = 0xA0,

        Debug = 0xEE,

        TestConnexion = 0xF0
    }

    public enum FonctionBalise
    {
        Vitesse = 0x01,
        Detection = 0xE4,
        ErreurDetection = 0xE6,

        InclinaisonFace = 0x10,
        InclinaisonProfil = 0x11,

        Debug = 0xEE,

        TestConnexion = 0xF0,
        RetourTestConnexion = 0xF5,
        Reset = 0xF2,
        TestEmission = 0xD4,
        TestEmissionReussi = 0xD5,
        TestEmissionCorrompu = 0xD6,
        TestEmissionPerdu = 0xD7
    }
}
