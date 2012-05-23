using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDP;

namespace GoBot.UDP
{
    static class TrameFactory
    {
        public enum FonctionMove
        {
            Deplace = 0x01,
            Pivot = 0x03,
            Stop = 0x05,
            CoeffAsserv = 0x45,
            Virage = 0x04,
            GoToXY = 0x06,
            StopAlim = 0x90,
            DemandePos = 0x41,
            VitesseLigne = 0x32,
            AccelLigne = 0x33,
            VitessePivot = 0x34,
            AccelPivot = 0x35,
            Recallage = 0x10,
            FinRecallage = 0x11,
            FinDeplacement = 0x50,
            DistanceRestante = 0x60,
            PID = 0x45,
            PositionXYTeta = 0x67,
            OffsetPos = 0x46
        }

        public enum FonctionIo
        {
            BougeServo = 0x10,
            ResetServo = 0x11,
            VitesseServo = 0x12,
            EtatInterrupteur = 0x40,
            Transmettre = 0xA0,
            TestConnexion = 0xF0,
            CoupureAlim = 0xF1,
            DepartJack = 0x52,
            CapteurUrgence = 0x78,
            FinCapteurUrgence = 0x79
        }

        public enum FonctionCommune
        {
            ReglageServo = 0xE0,
            TestConnexion = 0xF0,
            Reset = 0xF2
        }

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

        public enum FonctionPi
        {
            Deplace = 0x01,
            Pivot = 0x03,
            Stop = 0x05,
            CoeffAsserv = 0x45,
            Virage = 0x04,
            GoToXY = 0x06,
            StopAlim = 0x90,
            DemandePos = 0x41,
            VitesseLigne = 0x32,
            AccelLigne = 0x33,
            VitessePivot = 0x34,
            AccelPivot = 0x35,
            Recallage = 0x10,
            TestConnexion = 0xF0,
            PositionXYTeta = 0x67,

            BougeServo = 0x10,
            ResetServo = 0x11,

            Pompe = 0x80,

            VitesseServo = 0x12,
            EtatInterrupteur = 0x40,
        }

        public enum FonctionBalise
        {
            Vitesse = 0x01,
            Detection = 0xE4,
            TestConnexion = 0xF0
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

        #region Gros robot
        
        public static Trame CoupureAlim()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.CoupureAlim;

            return new Trame(tab);
        }

        public static Trame GRDeplacer(SensAR sens, int distance)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Deplace;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);
            return new Trame(tab);
        }

        public static Trame GROffsetPos(int offsetX, int offsetY, int offsetTeta)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.OffsetPos;
            tab[2] = ByteDivide(offsetX, true);
            tab[3] = ByteDivide(offsetX, false);
            tab[4] = ByteDivide(offsetY, true);
            tab[5] = ByteDivide(offsetY, false);
            tab[6] = ByteDivide(offsetTeta, true);
            tab[7] = ByteDivide(offsetTeta, false);
            return new Trame(tab);
        }

        public static Trame GRPivot(SensGD sens, int distance)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Pivot;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);
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

        public static Trame GRCoeffAsserv(int p, int i, int d)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.CoeffAsserv;
            tab[2] = (byte)ByteDivide(p, true);
            tab[3] = (byte)ByteDivide(p, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d, true);
            tab[7] = (byte)ByteDivide(d, false);
            return new Trame(tab);
        }

        public static Trame GRVirage(SensAR sensAr, SensGD sensGd, int rayon, int distance)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Virage;
            tab[2] = (byte)sensAr;
            tab[3] = (byte)sensGd;
            tab[4] = (byte)ByteDivide(rayon, true);
            tab[5] = (byte)ByteDivide(rayon, false);
            tab[6] = (byte)ByteDivide(distance, true);
            tab[7] = (byte)ByteDivide(distance, false);
            return new Trame(tab);
        }

        public static Trame GRGotoXY(int x, int y)
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

        public static Trame GRStopAlim()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Stop;
            return new Trame(tab);
        }

        public static Trame ResetRecMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionCommune.Reset;
            return new Trame(tab);
        }

        public static Trame GRDemandePosition()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.PositionXYTeta;
            return new Trame(tab);
        }

        public static Trame GRVitesseLigne(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitesseLigne;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame GRAccelLigne(int accel)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.AccelLigne;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);
            return new Trame(tab);
        }

        public static Trame GRVitessePivot(int vitesse)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitessePivot;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame GRAccelPivot(int accel)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.AccelPivot;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);
            return new Trame(tab);
        }

        public static Trame GRRecallage(SensAR sens)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Recallage;
            tab[2] = (byte)sens;
            return new Trame(tab);
        }

        public static Trame GRBougeServomoteur(ServomoteurID servo, int position)
        {
            // 0x67 pour communication à 19200 bauds
            return ServoSetPosition(Carte.RecIo, (int)servo, 0x67, position);
        }

        #endregion

        #region Petit robot

        public static Trame PRDeplacer(SensAR sens, int distance)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Deplace;
            tab[4] = (byte)sens;
            tab[5] = ByteDivide(distance, true);
            tab[6] = ByteDivide(distance, false);
            return new Trame(tab);
        }

        public static Trame PRPivot(SensGD sens, int distance)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Pivot;
            tab[4] = (byte)sens;
            tab[5] = ByteDivide(distance, true);
            tab[6] = ByteDivide(distance, false);
            return new Trame(tab);
        }

        public static Trame PRStop(StopMode mode)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Stop;
            tab[4] = (byte)mode;
            return new Trame(tab);
        }

        public static Trame PRCoeffAsserv(int p, int i, int d)
        {
            byte[] tab = new byte[10];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.CoeffAsserv;
            tab[4] = (byte)ByteDivide(p, true);
            tab[5] = (byte)ByteDivide(p, false);
            tab[6] = (byte)ByteDivide(i, true);
            tab[7] = (byte)ByteDivide(i, false);
            tab[8] = (byte)ByteDivide(d, true);
            tab[9] = (byte)ByteDivide(d, false);
            return new Trame(tab);
        }

        public static Trame PRVirage(SensAR sensAr, SensGD sensGd, int rayon, int distance)
        {
            byte[] tab = new byte[10];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Virage;
            tab[4] = (byte)sensAr;
            tab[5] = (byte)sensGd;
            tab[6] = (byte)ByteDivide(rayon, true);
            tab[7] = (byte)ByteDivide(rayon, false);
            tab[8] = (byte)ByteDivide(distance, true);
            tab[9] = (byte)ByteDivide(distance, false);
            return new Trame(tab);
        }

        public static Trame PRGotoXY(int x, int y)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.GoToXY;
            tab[4] = (byte)ByteDivide(x, true);
            tab[5] = (byte)ByteDivide(x, false);
            tab[6] = (byte)ByteDivide(y, true);
            tab[7] = (byte)ByteDivide(y, false);
            return new Trame(tab);
        }

        public static Trame PRStopAlim()
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Stop;
            return new Trame(tab);
        }

        public static Trame PRDemandePosition()
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.PositionXYTeta;
            return new Trame(tab);
        }

        public static Trame PRVitesseLigne(int vitesse)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.VitesseLigne;
            tab[4] = (byte)ByteDivide(vitesse, true);
            tab[5] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame PRAccelLigne(int accel)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.AccelLigne;
            tab[4] = (byte)ByteDivide(accel, true);
            tab[5] = (byte)ByteDivide(accel, false);
            return new Trame(tab);
        }

        public static Trame PRVitessePivot(int vitesse)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.VitessePivot;
            tab[4] = (byte)ByteDivide(vitesse, true);
            tab[5] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame PRAccelPivot(int accel)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.AccelPivot;
            tab[4] = (byte)ByteDivide(accel, true);
            tab[5] = (byte)ByteDivide(accel, false);
            return new Trame(tab);
        }

        public static Trame PRRecallage(SensAR sens)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Recallage;
            tab[4] = (byte)sens;
            return new Trame(tab);
        }

        public static Trame PRBougeServomoteur(ServomoteurID servo, int position)
        {
            // 0x67 pour communication à 19200 bauds
            Trame t = ServoSetPosition(Carte.RecIo, (int)servo, 0x67, position);
            byte[] tab = new byte[t.Length + 2];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;

            for (int i = 1; i < t.Length; i++)
                tab[2 + i] = t[i];

            return new Trame(tab);
        }

        public static Trame PRPompe(PompeID pompe, bool actif)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionPi.Pompe;
            tab[4] = (byte)pompe;
            tab[5] = (byte)(actif ? 1 : 0);
            return new Trame(tab);
        }

        public static Trame TestConnexionMiwi(Carte carte)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)carte;
            tab[3] = (byte)FonctionCommune.TestConnexion;
            return new Trame(tab);
        }

        #endregion
        
        #region Réglage servomoteurs

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

        #endregion


        public static Trame TestConnexion(Carte carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionCommune.TestConnexion;
            return new Trame(tab);
        }

        public static Trame BaliseVitesse(Carte balise, int vitesse)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Vitesse;
            tab[4] = (byte)ByteDivide(vitesse, true);
            tab[5] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        public static Trame BaliseReset(Carte balise)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionCommune.Reset;
            return new Trame(tab);
        }

        public static Trame BaliseTestConnexion(Carte balise)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.TestConnexion;
            return new Trame(tab);
        }

        public static Trame BalisePositions(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIo;
            tab[1] = (byte)FonctionIo.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Detection;
            return new Trame(tab);
        }

        public static Trame GRPID(int p, int i, int d)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.PID;
            tab[2] = (byte)ByteDivide(p, true);
            tab[3] = (byte)ByteDivide(p, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d, true);
            tab[7] = (byte)ByteDivide(d, false);
            return new Trame(tab);
        }
    }
}
