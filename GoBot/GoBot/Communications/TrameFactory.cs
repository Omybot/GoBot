using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    static class TrameFactory
    {
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

            DemandeCharge = 0x46,
            RetourCharge = 0x47,

            DemandePositionXYTeta = 0x30,
            RetourPositionXYTeta = 0x31,
            VitesseLigne = 0x32,
            AccelerationLigne = 0x33,
            VitessePivot = 0x34,
            AccelerationPivot = 0x35,
            CoeffAsservPID = 0x36,
            EnvoiPositionAbsolue = 0x37,

            VitesseAspirateur = 0x53,
            VitesseCanon = 0x54,
            Shutter = 0x55,
            Pompe = 0x56,
            VitesseCanonTours = 0x57,


            ServoPosition = 0x60,
            ServoVitesse = 0x61,

            ArmerJack = 0x70,
            DepartJack = 0x71,
            DemandeCouleurEquipe = 0x72,
            ReponseCouleurEquipe = 0x73,
            DemandeCouleur = 0x75,
            ReponseCouleur = 0x76,
            DemandePresence = 0x77,
            ReponsePresence = 0x78,
            DemandePresenceAssiette = 0x7A,
            ReponsePresenceAssiette = 0x7B,
            DemandeAspiRemonte = 0x7C,
            ReponseAspiRemonte = 0x7D,
            DemandeVitesseCanon = 0x7E,
            ReponseVitesseCanon = 0x7F,

            Alimentation = 0x80,
            AlimentationCamera = 0x81,

            TestConnexion = 0xF0,
            Reset = 0xF1,
            DemandeJack = 0xF3,
            ReponseJack = 0xF4
        }

        public enum FonctionMiwi
        {
            Transmettre = 0xA0,

            TestConnexion = 0xF0
        }

        /*public enum FonctionIo
        {
            BougeServo = 0x10,
            ResetServo = 0x11,
            VitesseServo = 0x12,
            EtatInterrupteur = 0x40,
            Transmettre = 0xA0,
            TestConnexion = 0xF0,
            CoupureAlim = 0xF1,
            CapteurUrgence = 0x78,
            FinCapteurUrgence = 0x79
        }*/

        /*public enum FonctionCommune
        {
            ReglageServo = 0xE0,
            TestConnexion = 0xF0,
            Reset = 0xF2
        }*/

        public enum FonctionReglageServo
        {
            TestConnexion = 0x00,
            GetTemperature = 0x10,
            GetCouple = 0x11,
            GetTension = 0x12,
            GetPosition = 0x14,
            GetVitesse = 0x15,
            SetPosition = 0x24,
            SetVitesse = 0x25,
            SetLed = 0x26,
            SetID = 0x27,
            SetBaudrate = 0x28,
            SetPositionMin = 0x29,
            SetPositionMax = 0x2A,
            SurveillerServo = 0x40,
            RechercheAuto = 0x42,
            Reset = 0x44
        }

        public enum FonctionBalise
        {
            Vitesse = 0x01,
            Detection = 0xE4,
            AckDetection = 0xE5,
            ErreurDetection = 0xE6,

            TestConnexion = 0xF0,
            Reset = 0xF2,
            TestEmission = 0xF4,
            TestEmissionReussi = 0xF5,
            TestEmissionCorrompu = 0xF6,
            TestEmissionPerdu = 0xF7
        }

        private static byte ByteDivide(int valeur, bool poidsFort)
        {
            byte b;
            if (poidsFort)
                b = (byte)(valeur >> 8);
            else
                b = (byte)(valeur & 0x00FF);
            return b;
        }

        public static Trame CoupureAlim(bool allume)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Alimentation;
            tab[2] = (byte)(allume ? 1 : 0);

            return new Trame(tab);
        }

        public static Trame Deplacer(SensAR sens, int distance)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Deplace;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);
            return new Trame(tab);
        }

        public static Trame OffsetPos(int offsetX, int offsetY, double offsetTeta)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.EnvoiPositionAbsolue;
            tab[2] = ByteDivide(offsetX, true);
            tab[3] = ByteDivide(offsetX, false);
            tab[4] = ByteDivide(offsetY, true);
            tab[5] = ByteDivide(offsetY, false);
            tab[6] = ByteDivide((int)(offsetTeta * 100), true);
            tab[7] = ByteDivide((int)(offsetTeta * 100), false);
            return new Trame(tab);
        }

        public static Trame Pivot(SensGD sens, double angle)
        {
            //angle = angle * Math.PI * 268.471260977282 / 2.0 / 180.0;
            byte[] tab = new byte[7];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Pivot;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide((int)(angle * 100.0), true);
            tab[4] = ByteDivide((int)(angle * 100.0), false);
            return new Trame(tab);
        }

        public static Trame GRStop(StopMode mode)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Stop;
            tab[2] = (byte)mode;
            return new Trame(tab);
        }

        public static Trame CoeffAsserv(int p, int i, int d)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.CoeffAsservPID;
            tab[2] = (byte)ByteDivide(p, true);
            tab[3] = (byte)ByteDivide(p, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d, true);
            tab[7] = (byte)ByteDivide(d, false);
            return new Trame(tab);
        }

        public static Trame Virage(SensAR sensAr, SensGD sensGd, int rayon, double angle)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Virage;
            tab[2] = (byte)sensAr;
            tab[3] = (byte)sensGd;
            tab[4] = (byte)ByteDivide(rayon, true);
            tab[5] = (byte)ByteDivide(rayon, false);
            tab[6] = (byte)ByteDivide((int)(angle * 100), true);
            tab[7] = (byte)ByteDivide((int)(angle * 100), false);
            return new Trame(tab);
        }

        public static Trame GotoXY(int x, int y)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.GoToXY;
            tab[2] = (byte)ByteDivide(x, true);
            tab[3] = (byte)ByteDivide(x, false);
            tab[4] = (byte)ByteDivide(y, true);
            tab[5] = (byte)ByteDivide(y, false);
            return new Trame(tab);
        }

        public static Trame ResetRecMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Reset;
            return new Trame(tab);
        }

        public static Trame DemandePosition()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePositionXYTeta;
            return new Trame(tab);
        }

        public static Trame VitesseLigne(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitesseLigne;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame AccelLigne(int accel)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.AccelerationLigne;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);
            return new Trame(tab);
        }

        public static Trame VitessePivot(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitessePivot;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame AccelPivot(int accel)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.AccelerationPivot;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);
            return new Trame(tab);
        }

        public static Trame Recallage(SensAR sens)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Recallage;
            tab[2] = (byte)sens;
            return new Trame(tab);
        }

        /*public static Trame BougeServomoteur(ServomoteurID servo, int position)
        {
            // 0x67 pour communication à 19200 bauds
            return ServoSetPosition(Carte.RecIo, (int)servo, 0x67, position);
        }*/

        public static Trame ServoPosition(ServomoteurID servo, int position)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.ServoPosition;
            tab[2] = (byte)servo;
            tab[3] = (byte)ByteDivide(position, true);
            tab[4] = (byte)ByteDivide(position, false);

            return new Trame(tab);
        }

        public static Trame ServoVitesse(ServomoteurID servo, int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.ServoVitesse;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            return new Trame(tab);
        }

        #region Réglage servomoteurs
        /*
        public static Trame ServoRechercheAuto(Carte carte)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.RechercheAuto;
            return new Trame(tab);
        }

        public static Trame ServoReset(Carte carte, int idServo)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.Reset;
            tab[3] = (byte)idServo;
            return new Trame(tab);
        }

        public static Trame ServoSurveille(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SurveillerServo;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }

        public static Trame ServoSetPosition(Carte carte, int idServo, int baudrate, int position)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetPosition;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)ByteDivide(position, true);
            tab[6] = (byte)ByteDivide(position, false);
            return new Trame(tab);
        }

        public static Trame ServoSetPositionMin(Carte carte, int idServo, int baudrate, int position)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetPositionMin;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)ByteDivide(position, true);
            tab[6] = (byte)ByteDivide(position, false);
            return new Trame(tab);
        }

        public static Trame ServoSetPositionMax(Carte carte, int idServo, int baudrate, int position)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetPositionMax;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)ByteDivide(position, true);
            tab[6] = (byte)ByteDivide(position, false);
            return new Trame(tab);
        }

        public static Trame ServoSetVitesse(Carte carte, int idServo, int baudrate, int vitesse)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetVitesse;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)ByteDivide(vitesse, true);
            tab[6] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame ServoSetLed(Carte carte, int idServo, int baudrate, bool allume)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetLed;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)(allume ? 1 : 0);
            return new Trame(tab);
        }

        public static Trame ServoSetId(Carte carte, int idServo, int baudrate, int newId)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetID;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)newId;
            return new Trame(tab);
        }

        public static Trame ServoSetBaudrate(Carte carte, int idServo, int baudrate, int nouveauBaudrate)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.SetBaudrate;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            tab[5] = (byte)nouveauBaudrate;
            return new Trame(tab);
        }

        public static Trame ServoTestConnexion(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.TestConnexion;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }

        public static Trame ServoGetTemperature(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.GetTemperature;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }

        public static Trame ServoGetCouple(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.GetCouple;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }

        public static Trame ServoGetTension(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.GetTension;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }

        public static Trame ServoGetPosition(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.GetPosition;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }

        public static Trame ServoGetVitesse(Carte carte, int idServo, int baudrate)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.ReglageServo;
            tab[2] = (byte)FonctionReglageServo.GetVitesse;
            tab[3] = (byte)idServo;
            tab[4] = (byte)baudrate;
            return new Trame(tab);
        }
        */
        #endregion

        public static Trame TestConnexionMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.TestConnexion;
            return new Trame(tab);
        }

        public static Trame TestConnexionMiwi()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.TestConnexion;
            return new Trame(tab);
        }

        public static Trame TestConnexionPi()
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.TestConnexion;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionMove.TestConnexion;
            return new Trame(tab);
        }
        
        public static Trame VitesseAspirateur(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitesseAspirateur;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }
        
        public static Trame VitesseCanon(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitesseCanon;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame Shutter(bool ouvert)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Shutter;
            tab[2] = (byte)(ouvert ? 0x01 : 0x00);
            return new Trame(tab);
        }

        public static Trame DemandePresenceBalle()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePresence;
            return new Trame(tab);
        }

        public static Trame DemandeCouleurBalle()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeCouleur;
            return new Trame(tab);
        }

        public static Trame DemandeCouleurEquipe()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeCouleurEquipe;
            return new Trame(tab);
        }

        public static Trame DemandeAspiRemonte()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeAspiRemonte;
            return new Trame(tab);
        }

        public static Trame DemandePresenceAssiette()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePresenceAssiette;
            return new Trame(tab);
        }

        public static Trame DemandeVitesseCanon()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeVitesseCanon;
            return new Trame(tab);
        }

        public static Trame ActiverPompe(bool actif)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Pompe;
            tab[2] = (byte)(actif ? 1 : 0);
            return new Trame(tab);
        }

        #region Balises

        public static Trame BaliseVitesse(Carte balise, int vitesse)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Vitesse;
            tab[4] = (byte)ByteDivide(vitesse, true);
            tab[5] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame BaliseReset(Carte balise)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Reset;
            return new Trame(tab);
        }

        public static Trame BaliseTestConnexion(Carte balise)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.TestConnexion;
            return new Trame(tab);
        }

        public static Trame BalisePositions(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Detection;
            return new Trame(tab);
        }

        public static Trame BaliseAck(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.AckDetection;
            return new Trame(tab);
        }

        public static Trame BaliseErreurDetection(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.ErreurDetection;
            return new Trame(tab);
        }

        #endregion


        public static Trame VitesseCanonTMin(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitesseCanonTours;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame EnvoiConsigneBrute(int consigne, SensAR sens = SensAR.Avant)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.EnvoiConsigneBrute;
            tab[2] = (byte)sens;
            tab[3] = (byte)ByteDivide(consigne, true);
            tab[4] = (byte)ByteDivide(consigne, false);
            return new Trame(tab);
        }

        public static Trame DemandePositionsCodeurs()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePositionsCodeurs;
            return new Trame(tab);
        }

        public static Trame ArmerJack()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.ArmerJack;
            return new Trame(tab);
        }

        public static Trame DemandeJack()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeJack;
            return new Trame(tab);
        }

        public static Trame DemandeChargeMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeCharge;
            return new Trame(tab);
        }

        public static String Decode(String trame)
        {
            return Decode(new Trame(trame));
        }

        public static String Decode(Trame trame)
        {
            String message = "";

            try
            {
                switch (trame[0])
                {
                    case (byte)Carte.RecMove:
                    case (byte)Carte.RecPi:
                        switch ((FonctionMove)trame[1])
                        {
                            case FonctionMove.AccelerationLigne:
                                int valeurAccelLigne = trame[2] * 256 + trame[3];
                                message = "Envoi accélération ligne : " + valeurAccelLigne;
                                break;
                            case FonctionMove.AccelerationPivot:
                                int valeurAccelPivot = trame[2] * 256 + trame[3];
                                message = "Envoi accélération pivot : " + valeurAccelPivot;
                                break;
                            case FonctionMove.Alimentation:
                                byte valeurAlimentation = trame[2];
                                message = "Envoi alimentation : " + (valeurAlimentation > 0 ? "On" : "Off");
                                break;
                            case FonctionMove.AlimentationCamera:
                                byte valeurAlimentationCamera = trame[2];
                                message = "Envoi alimentation camera : " + (valeurAlimentationCamera > 0 ? "On" : "Off");
                                break;
                            case FonctionMove.ArmerJack:
                                message = "Armage du jack";
                                break;
                            case FonctionMove.Blocage:
                                message = "Blocage détécté";
                                break;
                            case FonctionMove.CoeffAsservPID:
                                int valeurP = trame[2] * 256 + trame[3];
                                int valeurI = trame[4] * 256 + trame[5];
                                int valeurD = trame[6] * 256 + trame[7];
                                message = "Envoi PID : P=" + valeurP + " I=" + valeurI + " D=" + valeurD;
                                break;
                            case FonctionMove.DemandeCouleurEquipe:
                                message = "Demande couleur équipe";
                                break;
                            case FonctionMove.DemandeJack:
                                message = "Demande état jack";
                                break;
                            case FonctionMove.DemandePositionsCodeurs:
                                message = "Demande position codeurs";
                                break;
                            case FonctionMove.DemandePositionXYTeta:
                                message = "Demande position X Y Teta";
                                break;
                            case FonctionMove.DepartJack:
                                message = "Top départ jack";
                                break;
                            case FonctionMove.Deplace:
                                byte valeurAvance = trame[2];
                                int valeurDistanceAvance = trame[3] * 256 + trame[4];
                                message = (valeurAvance == (byte)SensAR.Avant ? "Avance" : "Recule") + " de " + valeurDistanceAvance + "mm";
                                break;
                            case FonctionMove.EnvoiConsigneBrute:
                                byte valeurConsigneBrute = trame[2];
                                int valeurDistanceConsigneBrute = trame[3] * 256 + trame[4];
                                message = (valeurConsigneBrute == (byte)SensAR.Avant ? "Avance" : "Recule") + " brut de " + valeurDistanceConsigneBrute + " pas codeurs";
                                break;
                            case FonctionMove.EnvoiPositionAbsolue:
                                int valeurPositionAbsolueX = trame[2] * 256 + trame[3];
                                int valeurPositionABsolueY = trame[4] * 256 + trame[5];
                                double valeurPositionAbsolueTeta = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Envoi position absolue X=" + valeurPositionAbsolueX + "mm Y=" + valeurPositionABsolueY + "mm Teta=" + valeurPositionAbsolueTeta + "°";
                                break;
                            case FonctionMove.FinDeplacement:
                                message = "Fin du déplacement";
                                break;
                            case FonctionMove.FinRecallage:
                                message = "Fin du recallage";
                                break;
                            case FonctionMove.Pivot:
                                byte valeurSensPivot = trame[2];
                                double valeurDistancePivot = (double)(trame[3] * 256 + trame[4]) / 100.0;
                                message = "Pivot " + (valeurSensPivot == (char)SensGD.Droite ? "droite" : "gauche") + " de " + valeurDistancePivot + "°";
                                break;
                            case FonctionMove.Recallage:
                                byte valeurSensRecallage = trame[2];
                                message = "Recallage " + (valeurSensRecallage == (char)SensAR.Avant ? "avant" : "arrière");
                                break;
                            case FonctionMove.ReponseCouleurEquipe:
                                byte valeurCouleurEquipe = trame[2];
                                message = "Retour couleur équipe : " + (valeurCouleurEquipe == 0 ? "rouge" : "jaune");
                                break;
                            case FonctionMove.ReponseJack:
                                byte valeurEtatJack = trame[2];
                                message = "Retour jack : " + (valeurEtatJack == 0 ? "débranché" : "branché");
                                break;
                            case FonctionMove.Reset:
                                message = "Envoi reset";
                                break;
                            case FonctionMove.RetourPositionCodeurs:
                                byte valeurPositionsCodeursNombre = trame[2];
                                message = "Retour positions codeurs : " + valeurPositionsCodeursNombre + " valeurs";
                                break;
                            case FonctionMove.RetourPositionXYTeta:
                                double valeurPositionX = (double)(trame[2] * 256 + trame[3]) / 10.0;
                                double valeurPositionY = (double)(trame[4] * 256 + trame[5]) / 10.0;
                                double valeurPositionTeta = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Retour position X Y Teta : X=" + valeurPositionX + "mm Y=" + valeurPositionY + "mm Teta=" + valeurPositionTeta + "°";
                                break;
                            case FonctionMove.ServoPosition:
                                byte valeurServoPositionId = trame[2];
                                int valeurServoPosition = trame[3] * 256 + trame[4];
                                message = "Envoi position servomoteur " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)valeurServoPositionId) + " à " + GoBot.Actions.Nommeur.Nommer(valeurServoPosition, (ServomoteurID)valeurServoPositionId); ;
                                break;
                            case FonctionMove.ServoVitesse:
                                byte valeurServoVitesseId = trame[2];
                                int valeurServoVitesse = trame[3] * 256 + trame[4];
                                String nomServoVitesse = GoBot.Actions.Nommeur.Nommer((ServomoteurID)valeurServoVitesseId);
                                message = "Envoi vitesse servomoteur " + nomServoVitesse + " à " + valeurServoVitesse;
                                break;
                            case FonctionMove.Stop:
                                String stopMode = ((StopMode)trame[2]).ToString();
                                message = "Envoi stop " + stopMode;
                                break;
                            case FonctionMove.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionMove.Virage:
                                SensAR valeurVirageSensAR = ((SensAR)trame[2]);
                                SensGD valeurVirageSensGD = ((SensGD)trame[3]);
                                int valeurVirageRayon = trame[4] * 256 + trame[5];
                                double valeurVirageAngle = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Envoi virage " + valeurVirageSensAR.ToString().ToLower() + " " + valeurVirageSensGD.ToString().ToLower() + " rayon=" + valeurVirageRayon + "mm angle=" + valeurVirageAngle + "°";
                                break;
                            case FonctionMove.VitesseLigne:
                                int valeurVitesseLigne = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse ligne " + valeurVitesseLigne;
                                break;
                            case FonctionMove.VitessePivot:
                                int valeurVitessePivot = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse pivot " + valeurVitessePivot;
                                break;
                            case FonctionMove.DemandeCharge:
                                message = "Demande charge";
                                break;
                            case FonctionMove.RetourCharge:
                                int nbValeurs = trame[2];
                                message = "Retour charge : " + nbValeurs + " valeurs";
                                break;
                            //case FonctionMove.VitesseAspirateur:
                            //    break;
                            //case FonctionMove.VitesseCanon:
                            //    break;
                            //case FonctionMove.VitesseCanonTours:
                            //    break;
                            //case FonctionMove.Shutter:
                            //    break;
                            //case FonctionMove.ReponseAspiRemonte:
                            //    break;
                            //case FonctionMove.ReponseCouleur:
                            //    break;
                            //case FonctionMove.ReponsePresence:
                            //    break;
                            //case FonctionMove.ReponsePresenceAssiette:
                            //    break;
                            //case FonctionMove.ReponseVitesseCanon:
                            //    break;
                            //case FonctionMove.Pompe:
                            //    break;
                            //case FonctionMove.GoToXY:
                            //    break;
                            //case FonctionMove.DemandePresence:
                            //    break;
                            //case FonctionMove.DemandePresenceAssiette:
                            //    break;
                            //case FonctionMove.DemandeVitesseCanon:
                            //    break;
                            //case FonctionMove.DemandeAspiRemonte:
                            //    break;
                            //case FonctionMove.DemandeCouleur:
                            //    break;
                            default:
                                return "Inconnu";
                        }
                        break;
                    case (byte)Carte.RecBeu:
                    case (byte)Carte.RecBoi:
                    case (byte)Carte.RecBun:
                        switch ((FonctionBalise)trame[1])
                        {
                            case FonctionBalise.Detection:
                                int valeurDetectionNombreTicksTour = trame[2] * 256 + trame[3];
                                byte valeurDetectionNombre1 = trame[4];
                                byte valeurDetectionNombre2 = trame[5];
                                message = "Tour balise : " + valeurDetectionNombreTicksTour + " ticks/tour. Capteur 1: " + valeurDetectionNombre1 + " angles, Capteur 2 : " + valeurDetectionNombre2 + " angles";
                                break;
                            case FonctionBalise.Reset:
                                message = "Envoi reset";
                                break;
                            case FonctionBalise.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionBalise.Vitesse:
                                int vitesse = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse pwm " + vitesse;
                                break;
                            //case FonctionBalise.ErreurDetection:
                            //    break;
                            //case FonctionBalise.AckDetection:
                            //    break;
                        }
                        break;
                    case (byte)Carte.RecMiwi:
                        switch ((FonctionBalise)trame[2])
                        {
                            case FonctionBalise.Detection:
                                int valeurDetectionNombreTicksTour = trame[2] * 256 + trame[3];
                                byte valeurDetectionNombre1 = trame[4];
                                byte valeurDetectionNombre2 = trame[5];
                                message = "Tour balise : " + valeurDetectionNombreTicksTour + " ticks/tour. Capteur 1: " + valeurDetectionNombre1 + " angles, Capteur 2 : " + valeurDetectionNombre2 + " angles";
                                break;
                            case FonctionBalise.Reset:
                                message = "Envoi reset";
                                break;
                            case FonctionBalise.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionBalise.Vitesse:
                                int vitesse = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse pwm " + vitesse;
                                break;
                            //case FonctionBalise.ErreurDetection:
                            //    break;
                            //case FonctionBalise.AckDetection:
                            //    break;
                        }
                        break;
                }
            }
            catch(Exception)
            {
                message = "Inconnu";
            }

            return message;
        }

        public static Carte Identifiant(Trame trame)
        {
            try
            {
                switch (trame[0])
                {
                    case (byte)Carte.RecMiwi:
                        switch ((FonctionMiwi)trame[1])
                        {
                            case FonctionMiwi.Transmettre:
                                return (Carte)trame[2];
                            default:
                                return Carte.RecMiwi;
                        }
                        return (Carte)trame[2];
                    default:
                        return (Carte)trame[0];
                }
            }
            catch (Exception)
            {
                return Carte.PC;
            }
        }
    }
}
