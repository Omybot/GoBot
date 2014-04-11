using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    static class TrameFactory
    {
        private static byte ByteDivide(int valeur, bool poidsFort)
        {
            byte b;
            if (poidsFort)
                b = (byte)(valeur >> 8);
            else
                b = (byte)(valeur & 0x00FF);
            return b;
        }

        static public Trame CoupureAlim(bool allume)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.Alimentation;
            tab[2] = (byte)(allume ? 1 : 0);

            return new Trame(tab);
        }

        static public Trame ActionneurOnOff(ActionneurOnOffID actionneur, bool onOff)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.ActionneurOnOff;
            tab[2] = (byte)actionneur;
            tab[3] = (byte)(onOff ? 1 : 0);

            return new Trame(tab);
        }

        static public Trame MoteurVitesse(MoteurID moteur, int vitesse)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.Moteur;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(vitesse, true);
            tab[4] = (byte)ByteDivide(vitesse, false);

            return new Trame(tab);
        }

        static public Trame Deplacer(SensAR sens, int distance, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionMove.Deplace;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame OffsetPos(int offsetX, int offsetY, double offsetTeta, Robot robot)
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

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame Pivot(SensGD sens, double angle, Robot robot)
        {
            //angle = angle * Math.PI * 268.471260977282 / 2.0 / 180.0;
            byte[] tab = new byte[7];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Pivot;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide((int)(angle * 100.0), true);
            tab[4] = ByteDivide((int)(angle * 100.0), false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame Stop(StopMode mode, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Stop;
            tab[2] = (byte)mode;

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame CoeffAsserv(int p, int i, int d, Robot robot)
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

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame Virage(SensAR sensAr, SensGD sensGd, int rayon, double angle, Robot robot)
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

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame GotoXY(int x, int y, Robot robot)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.GoToXY;
            tab[2] = (byte)ByteDivide(x, true);
            tab[3] = (byte)ByteDivide(x, false);
            tab[4] = (byte)ByteDivide(y, true);
            tab[5] = (byte)ByteDivide(y, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame ResetRecMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Reset;
            return new Trame(tab);
        }

        static public Trame DemandePosition(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePositionXYTeta;

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame VitesseLigne(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitesseLigne;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame AccelLigne(int accel, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.AccelerationLigne;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame VitessePivot(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.VitessePivot;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame AccelPivot(int accel, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.AccelerationPivot;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame Recallage(SensAR sens, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Recallage;
            tab[2] = (byte)sens;

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        /*static public Trame BougeServomoteur(ServomoteurID servo, int position)
        {
            // 0x67 pour communication à 19200 bauds
            return ServoSetPosition(Carte.RecIo, (int)servo, 0x67, position);
        }*/
        
        static public Trame TestConnexionMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.TestConnexion;
            return new Trame(tab);
        }

        static public Trame TestConnexionMiwi()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.TestConnexion;
            return new Trame(tab);
        }

        static public Trame TestConnexionPi()
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.TestConnexion;
            tab[2] = (byte)Carte.RecPi;
            tab[3] = (byte)FonctionMove.TestConnexion;
            return new Trame(tab);
        }

        static public Trame TestConnexionIO()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.TestConnexion;
            return new Trame(tab);
        }

        static public Trame DemandeCouleurEquipe()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.DemandeCouleurEquipe;
            return new Trame(tab);
        }

        #region Balises

        static public Trame BaliseVitesse(Carte balise, int vitesse)
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

        static public Trame BaliseReset(Carte balise)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Reset;
            return new Trame(tab);
        }

        static public Trame BaliseTestConnexion(Carte balise)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.TestConnexion;
            return new Trame(tab);
        }

        static public Trame BalisePositions(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.Detection;
            return new Trame(tab);
        }

        static public Trame BaliseAck(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.AckDetection;
            return new Trame(tab);
        }

        static public Trame BaliseErreurDetection(Carte balise)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)balise;
            tab[3] = (byte)FonctionBalise.ErreurDetection;
            return new Trame(tab);
        }

        #endregion


        static public Trame EnvoiConsigneBrute(int consigne, SensAR sens, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.EnvoiConsigneBrute;
            tab[2] = (byte)sens;
            tab[3] = (byte)ByteDivide(consigne, true);
            tab[4] = (byte)ByteDivide(consigne, false);

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame DemandePositionsCodeurs(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePositionsCodeurs;

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame ArmerJack()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.ArmerJack;
            return new Trame(tab);
        }

        static public Trame DemandeJack()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.DemandeJack;
            return new Trame(tab);
        }

        static public Trame DemandeCpuPwm(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandeDiagnostic;

            Trame retour = new Trame(tab);
            if (robot == Robots.PetitRobot)
                retour = new Trame("C2 A0 C3 " + retour.ToString().Substring(2));

            return retour;
        }

        static public Trame TestEmission(Carte carte, byte id)
        {
            byte[] tab = new byte[21];
            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)carte;
            tab[3] = (byte)FonctionBalise.TestEmission;
            tab[4] = id;
            tab[5] = 0x00;
            tab[6] = 0x01;
            tab[7] = 0x02;
            tab[8] = 0x03;
            tab[9] = 0x04;
            tab[10] = 0x05;
            tab[11] = 0x06;
            tab[12] = 0x07;
            tab[13] = 0x08;
            tab[14] = 0x09;
            tab[15] = 0x0A;
            tab[16] = 0x0B;
            tab[17] = 0x0C;
            tab[18] = 0x0D;
            tab[19] = 0x0E;
            tab[20] = 0x0F;

            return new Trame(tab);
        }

        #region Servomoteur

        static public Trame ServoDemandeErreurs(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeErreurs;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionCible(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionCible;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiPositionCible(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionCible;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Trame(tab);
        }

        static public Trame ServoDemandeBaudrate(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeBaudrate;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiBaudrate(ServomoteurID servo, ServoBaudrate baud, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiBaudrate;
            tab[3] = (byte)servo;
            tab[4] = (byte)baud;
            return new Trame(tab);
        }

        static public Trame ServoDemandeVitesseMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVitesseMax;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiVitesseMax(ServomoteurID servo, int vitesse, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiVitesseMax;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(vitesse, true);
            tab[5] = ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        static public Trame ServoDemandeId(Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeId;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiId(ServomoteurID servo, char nouvelId, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiId;
            tab[3] = (byte)servo;
            tab[4] = (byte)nouvelId;
            return new Trame(tab);
        }

        static public Trame ServoReset(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.Reset;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeCoupleMaximum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleMaximum;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiCoupleMaximum(ServomoteurID servo, int couple, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleMaximum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(couple, true);
            tab[5] = ByteDivide(couple, false);
            return new Trame(tab);
        }

        static public Trame ServoDemandeCoupleActive(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleActive;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiCoupleActive(ServomoteurID servo, bool actif, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleActive;
            tab[3] = (byte)servo;
            tab[4] = (byte)(actif ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame ServoDemandeTemperature(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTemperature;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeTension(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTension;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeMouvement(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeMouvement;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionMinimum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionMinimum;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiPositionMinimum(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionMinimum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionMaximum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionMaximum;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiPositionMaximum(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionMaximum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Trame(tab);
        }

        static public Trame ServoDemandeNumeroModele(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeNumeroModele;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeVersionFirmware(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVersionFirmware;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeLed(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeLed;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiLed(ServomoteurID servo, bool allume, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiLed;
            tab[3] = (byte)servo;
            tab[4] = (byte)(allume ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame ServoDemandeConfigAlarmeLED(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigAlarmeLED;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiConfigAlarmeLED(ServomoteurID servo, bool inputVoltage, bool angleLimit, bool overheating, bool range, bool checksum, bool overload, bool instruction, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[11];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigAlarmeLED;
            tab[3] = (byte)servo;
            tab[4] = (byte)(inputVoltage ? 1 : 0);
            tab[5] = (byte)(angleLimit ? 1 : 0);
            tab[6] = (byte)(overheating ? 1 : 0);
            tab[7] = (byte)(range ? 1 : 0);
            tab[8] = (byte)(checksum ? 1 : 0);
            tab[9] = (byte)(overload ? 1 : 0);
            tab[10] = (byte)(instruction ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame ServoDemandeConfigAlarmeShutdown(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigAlarmeShutdown;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiConfigAlarmeShutdown(ServomoteurID servo, bool inputVoltage, bool angleLimit, bool overheating, bool range, bool checksum, bool overload, bool instruction, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[11];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigAlarmeShutdown;
            tab[3] = (byte)servo;
            tab[4] = (byte)(inputVoltage ? 1 : 0);
            tab[5] = (byte)(angleLimit ? 1 : 0);
            tab[6] = (byte)(overheating ? 1 : 0);
            tab[7] = (byte)(range ? 1 : 0);
            tab[8] = (byte)(checksum ? 1 : 0);
            tab[9] = (byte)(overload ? 1 : 0);
            tab[10] = (byte)(instruction ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame ServoDemandeConfigEcho(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigEcho;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiConfigEcho(ServomoteurID servo, char val, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigEcho;
            tab[3] = (byte)servo;
            tab[4] = (byte)val;
            return new Trame(tab);
        }

        static public Trame ServoDemandeComplianceParams(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeComplianceParams;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiComplianceParams(ServomoteurID servo, byte CCWSlope, byte CCWMargin, byte CWMargin, byte CWSlope, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiComplianceParams;
            tab[3] = (byte)servo;
            tab[4] = CCWSlope;
            tab[5] = CCWMargin;
            tab[6] = CWMargin;
            tab[7] = CWSlope;
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionActuelle(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionActuelle;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeVitesseActuelle(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionIO.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVitesseActuelle;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        #endregion

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
                    case (byte)Carte.RecIO:
                        switch ((FonctionIO)trame[1])
                        {
                            case FonctionIO.ArmerJack:
                                message = "Armage du jack";
                                break;
                            case FonctionIO.DemandeCouleurEquipe:
                                message = "Demande couleur équipe";
                                break;
                            case FonctionIO.DemandeJack:
                                message = "Demande état jack";
                                break;
                            case FonctionIO.DepartJack:
                                message = "Top départ jack";
                                break;
                            case FonctionIO.ReponseCouleurEquipe:
                                byte valeurCouleurEquipe = trame[2];
                                message = "Retour couleur équipe : " + (valeurCouleurEquipe == 0 ? "rouge" : "jaune");
                                break;
                            case FonctionIO.ReponseJack:
                                byte valeurEtatJack = trame[2];
                                message = "Retour jack : " + (valeurEtatJack == 0 ? "débranché" : "branché");
                                break;
                            case FonctionIO.Alimentation:
                                byte valeurAlimentation = trame[2];
                                message = "Envoi alimentation : " + (valeurAlimentation > 0 ? "On" : "Off");
                                break;
                            case FonctionIO.AlimentationCamera:
                                byte valeurAlimentationCamera = trame[2];
                                message = "Envoi alimentation camera : " + (valeurAlimentationCamera > 0 ? "On" : "Off");
                                break;
                            case FonctionIO.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionIO.CommandeServo:
                                switch ((FonctionServo)trame[2])
                                {
                                    case FonctionServo.DemandeBaudrate:
                                        message = "Demande baudrate servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeComplianceParams:
                                        message = "Demande compliance servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeConfigAlarmeLED:
                                        message = "Demande config alarme LED servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeConfigAlarmeShutdown:
                                        message = "Demande config alarme shutdown servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeConfigEcho:
                                        message = "Demande config echo servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeCoupleActive:
                                        message = "Demande couple actif servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeCoupleMaximum:
                                        message = "Demande couple max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeId:
                                        message = "Demande ID servo";
                                        break;
                                    case FonctionServo.DemandeLed:
                                        message = "Demande état LED servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeMouvement:
                                        message = "Demande mouvelement servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeNumeroModele:
                                        message = "Demande numéro modèle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionActuelle:
                                        message = "Demand eposition actuelle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionCible:
                                        message = "Demande position cible servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionMaximum:
                                        message = "Demande position maximum servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionMinimum:
                                        message = "Demande position minimum servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeTemperature:
                                        message = "Demande température servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeTension:
                                        message = "Demande tension servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeVersionFirmware:
                                        message = "Demande version firmware servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeVitesseActuelle:
                                        message = "Demande vitesse actuelle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeVitesseMax:
                                        message = "Demande vitesse max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.EnvoiBaudrate:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " baudrate " + ((ServoBaudrate)trame[4]).ToString();
                                        break;
                                    case FonctionServo.EnvoiComplianceParams:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " compliance CCWSlope=" + trame[4] + " CCWMargin=" + trame[5] + " CWSlope=" + trame[6] + " CWMargin=" + trame[7];
                                        break;
                                    case FonctionServo.EnvoiConfigAlarmeLED:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme LED : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.EnvoiConfigAlarmeShutdown:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme shutdown : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.EnvoiConfigEcho:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config echo  à " + trame[4];
                                        break;
                                    case FonctionServo.EnvoiCoupleActive:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple " + (trame[4] > 0 ? "Activé" : "Désactivé");
                                        break;
                                    case FonctionServo.EnvoiCoupleMaximum:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple maximum " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.EnvoiId:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " ID " + trame[4];
                                        break;
                                    case FonctionServo.EnvoiLed:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " LED " + (trame[4] > 0 ? "On" : "Off"); ;
                                        break;
                                    case FonctionServo.EnvoiPositionCible:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position " + GoBot.Actions.Nommeur.Nommer(trame[4] * 256 + trame[5], (ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.EnvoiPositionMaximum:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position maximum " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.EnvoiPositionMinimum:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position minimum " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.EnvoiVitesseMax:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse max " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
                                        break;
                                    case FonctionServo.Reset:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " reset";
                                        break;
                                    case FonctionServo.RetourBaudrate:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " baudrate = " + ((ServoBaudrate)(trame[4])).ToString();
                                        break;
                                    case FonctionServo.RetourComplianceParams:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " compliance : CCWSlope=" + trame[4] + " CCWMargin=" + trame[5] + " CWSlope=" + trame[6] + " CWMargin=" + trame[7];
                                        break;
                                    case FonctionServo.RetourConfigAlarmeLED:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme LED : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.RetourConfigAlarmeShutdown:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme shutdown : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.RetourConfigEcho:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config echo = " + trame[4];
                                        break;
                                    case FonctionServo.RetourCoupleActive:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple = " + (trame[4] > 0 ? "On" : "Off");
                                        break;
                                    case FonctionServo.RetourCoupleMaximum:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple maximum = " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourId:
                                        message = "Retour servo ID = " + trame[3];
                                        break;
                                    case FonctionServo.RetourLed:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " LED " + (trame[4] > 0 ? "On" : "Off");
                                        break;
                                    case FonctionServo.RetourMouvement:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " mouvement : " + (trame[4] > 0 ? "En cours" : "Terminé");
                                        break;
                                    case FonctionServo.RetourNumeroModele:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " numéro modèle : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionActuelle:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position actuelle : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionCible:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position cible : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionMaximum:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position maximum : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionMinimum:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position minimum : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourTemperature:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " température : " + trame[4] + "°C";
                                        break;
                                    case FonctionServo.RetourTension:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension : " + ((double)trame[4] / 10.0) + "V";
                                        break;
                                    case FonctionServo.RetourVersionFirmware:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " version firmware : " + trame[4];
                                        break;
                                    case FonctionServo.RetourVitesseActuelle:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse actuelle : " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
                                        break;
                                    case FonctionServo.RetourVitesseMax:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse maximum : " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
                                        break;
                                    case FonctionServo.DemandeErreurs:
                                        message = "Demande erreurs servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.RetourErreurs:
                                        String listeErreurs = "";
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " erreurs : ";
                                        if (trame[4] > 0)
                                            listeErreurs += "AngleLimit, ";
                                        if (trame[5] > 0)
                                            listeErreurs += "Checksum, ";
                                        if (trame[6] > 0)
                                            listeErreurs += "InputVoltage, ";
                                        if (trame[7] > 0)
                                            listeErreurs += "Instruction, ";
                                        if (trame[8] > 0)
                                            listeErreurs += "Overheating, ";
                                        if (trame[9] > 0)
                                            listeErreurs += "Overload, ";
                                        if (trame[10] > 0)
                                            listeErreurs += "Range, ";

                                        if (listeErreurs.Length == 0)
                                            message += "Aucune";
                                        else
                                            message += listeErreurs.Substring(0, listeErreurs.Length - 2);
                                        break;
                                }
                                break;
                        }
                        break;

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
                            case FonctionMove.Blocage:
                                message = "Blocage détécté";
                                break;
                            case FonctionMove.CoeffAsservPID:
                                int valeurP = trame[2] * 256 + trame[3];
                                int valeurI = trame[4] * 256 + trame[5];
                                int valeurD = trame[6] * 256 + trame[7];
                                message = "Envoi PID : P=" + valeurP + " I=" + valeurI + " D=" + valeurD;
                                break;
                            case FonctionMove.DemandePositionsCodeurs:
                                message = "Demande position codeurs";
                                break;
                            case FonctionMove.DemandePositionXYTeta:
                                message = "Demande position X Y Teta";
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
                            case FonctionMove.DemandeDiagnostic:
                                message = "Demande charge";
                                break;
                            case FonctionMove.RetourDiagnostic:
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
                            case FonctionBalise.TestEmission:
                                message = "Test d'émission n°" + trame[2];
                                break;
                            case FonctionBalise.TestEmissionCorrompu:
                                message = "Test d'émission n°" + trame[2] + " corrompu";
                                break;
                            case FonctionBalise.TestEmissionPerdu:
                                message = "Test d'émission n°" + trame[2] + " perdu";
                                break;
                            case FonctionBalise.TestEmissionReussi:
                                message = "Test d'émission n°" + trame[2] + " réussi";
                                break;
                        }
                        break;
                    case (byte)Carte.RecMiwi:
                        switch ((FonctionMiwi)trame[1])
                        {
                            case FonctionMiwi.Transmettre:
                                byte[] octets = trame.ToTabBytes();
                                byte[] octetsExtrait = new byte[octets.Length - 1];
                                for (int i = 2; i < octets.Length; i++)
                                    octetsExtrait[i - 2] = octets[i];

                                Trame trameInterne = new Trame(octetsExtrait);
                                message = Decode(trameInterne);
                                break;
                            case FonctionMiwi.TestConnexion:
                                message = "Test connexion";
                                break;
                        }
                        break;
                    default:
                        message = "Inconnu";
                        break;
                }
            }
            catch (Exception)
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
