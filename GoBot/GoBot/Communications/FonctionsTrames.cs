using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    public enum FonctionIO
    {
        CommandeServo = 0x60,

        ArmerJack = 0x70,
        DepartJack = 0x71,
        DemandeCouleurEquipe = 0x72,
        ReponseCouleurEquipe = 0x73,
        DemandeCapteurOnOff = 0x74,
        RetourCapteurOnOff = 0x75,
        AspirationPompe = 0x78,

        Alimentation = 0x80,

        ActionneurOnOff = 0x65,
        MoteurPosition = 0x66,

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
        Recallage = 0x10,
        FinRecallage = 0x11,
        FinDeplacement = 0x12,
        Blocage = 0x13,

        DemandePositionsCodeurs = 0x43,
        RetourPositionCodeurs = 0x44,
        EnvoiConsigneBrute = 0x45,

        DemandeDiagnostic = 0x46,
        RetourDiagnostic = 0x47,

        DemandePositionContinue = 0x48,

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
        RetourTestConnexion = 0xF5,
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

        ActionneurOnOff = 0x65,
        Moteur = 0x66,

        DemandeDiagnostic = 0x46,
        RetourDiagnostic = 0x47,

        DemandePositionContinue = 0x48,

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
        RetourTestConnexion = 0xF5,
        Reset = 0xF1,
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
        RetourErreurs = 0x59,
        DemandeCoupleCourant = 0x60,
        RetourCoupleCourant = 0x61
    }

    public enum FonctionMiwi
    {
        Transmettre = 0xA0,
        Acquittement = 0xA1,

        Debug = 0xEE,

        TestConnexion = 0xF0,
        RetourTestConnexion = 0xF5
    }

    public enum FonctionBalise
    {
        Vitesse = 0x01,
        Detection = 0xE4,

        InclinaisonFace = 0x11,
        InclinaisonProfil = 0x10,

        Debug = 0xEE,

        TestConnexion = 0xF0,
        RetourTestConnexion = 0xF5,
        Reset = 0xF1,
        Initialisation = 0xF3,
    }
}
