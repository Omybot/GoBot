﻿namespace GoBot.Communications.UDP
{
    public enum UdpFrameFunction
    {
        Debug = 0xEE,
        TestConnexion = 0xF0,
        TensionBatteries = 0xF5,
        Reset = 0xF1,
        Buzzer = 0xF3,

        DemandeCapteurOnOff = 0x74,
        RetourCapteurOnOff = 0x75,
        DemandeValeursAnalogiques = 0x76,
        RetourValeursAnalogiques = 0x77,
        DemandeValeursNumeriques = 0x78,
        RetourValeursNumeriques = 0x79,
        DemandeCapteurCouleur = 0x52,
        RetourCapteurCouleur = 0x53,
        DemandePositionCodeur = 0x21,
        RetourPositionCodeur = 0x22,

        MoteurOrigin = 0x63,
        MoteurResetPosition = 0x64,
        PilotageOnOff = 0x65,
        MoteurPosition = 0x66,
        MoteurVitesse = 0x67,
        MoteurAccel = 0x68,
        MoteurStop = 0x69,
        MoteurFin = 0x70,
        MoteurBlocage = 0x71,

        CommandeServo = 0x60,

        Deplace = 0x01,
        Pivot = 0x03,
        Virage = 0x04,
        Stop = 0x05,
        Recallage = 0x10,
        TrajectoirePolaire = 0x20,
        FinRecallage = 0x11,
        FinDeplacement = 0x12,
        Blocage = 0x13,

        AsserDemandePositionCodeurs = 0x43,
        AsserRetourPositionCodeurs = 0x44,
        AsserEnvoiConsigneBrutePosition = 0x45,
        DemandeChargeCPU_PWM = 0x46,
        RetourChargeCPU_PWM = 0x47,
        AsserIntervalleRetourPosition = 0x48,

        AsserDemandePositionXYTeta = 0x30,
        AsserRetourPositionXYTeta = 0x31,
        AsserVitesseDeplacement = 0x32,
        AsserAccelerationDeplacement = 0x33,
        AsserVitessePivot = 0x34,
        AsserAccelerationPivot = 0x35,
        AsserPID = 0x36,
        AsserEnvoiPositionAbsolue = 0x37,
        AsserPIDCap = 0x38,
        AsserPIDVitesse = 0x39,

        EnvoiUart1 = 0xA0,
        RetourUart1 = 0xA1,
        DemandeLidar = 0xA2,
        ReponseLidar = 0xA3,
        EnvoiUart2 = 0xA4,
        RetourUart2 = 0xA5,
        ChangementBaudrateUART = 0x61,

        AffichageLCD = 0xB0,

        EnvoiCAN = 0xC0,
        ReponseCAN = 0xC1,

        DetectionBalise = 0xE4,
        DetectionBaliseRapide = 0xE5
    }

    public enum ServoFunction
    {
        DemandePositionCible = 0x01,
        RetourPositionCible = 0x02,
        EnvoiPositionCible = 0x03,
        EnvoiBaudrate = 0x06,
        DemandeVitesseMax = 0x07,
        RetourVitesseMax = 0x08,
        EnvoiVitesseMax = 0x09,
        DemandeAllIn = 0x10,
        RetourAllIn = 0x11,
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
        RetourCoupleCourant = 0x61,
        DemandeStatusLevel = 0x62,
        RetourStatusLevel = 0x63,
        EnvoiTensionMax = 0x64,
        DemandeTensionMax = 0x65,
        RetourTensionMax = 0x66,
        EnvoiTensionMin = 0x67,
        DemandeTensionMin = 0x68,
        RetourTensionMin = 0x69,
        EnvoiTemperatureMax = 0x70,
        DemandeTemperatureMax = 0x71,
        RetourTemperatureMax = 0x72,
        EnvoiCoupleLimite = 0x73,
        DemandeCoupleLimite = 0x74,
        RetourCoupleLimite = 0x75
    }
}
