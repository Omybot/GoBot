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
            Virage = 0x04,
            Stop = 0x05,
            GoToXY = 0x06,
            Recallage = 0x10,
            FinRecallage = 0x11,
            FinDeplacement = 0x12,
            Blocage = 0x70,

            DemandePositionsCodeurs = 0x43,
            RetourPositionCodeurs = 0x44,
            EnvoiConsigneBrute = 0x45,

            DemandePositionXYTeta = 0x30,
            RetourPositionXYTeta = 0x31,
            VitesseLigne = 0x32,
            AccelLigne = 0x33,
            VitessePivot = 0x34,
            AccelPivot = 0x35,
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
            Transmettre = 0xA0
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
            TestConnexion = 0xF0,
            Reset = 0xF2
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
            tab[1] = (byte)FonctionMove.AccelLigne;
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
            tab[1] = (byte)FonctionMove.AccelPivot;
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
    }
}
