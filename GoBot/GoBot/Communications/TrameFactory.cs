using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;

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

        static public Trame Debug(Carte carte, int numDebug)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            switch(carte)
            {
                case Carte.RecIO:
                    tab[1] = (byte)FonctionIO.Debug;
                    break;
                case Carte.RecMove:
                    tab[1] = (byte)FonctionMove.Debug;
                    break;
                case Carte.RecMiwi:
                    tab[1] = (byte)FonctionMiwi.Debug;
                    break;
                case Carte.RecBun:
                case Carte.RecBeu:
                case Carte.RecBoi:
                    tab[1] = (byte)FonctionBalise.Debug;
                    break;
            }
            tab[2] = (byte)numDebug;

            return new Trame(tab);
        }

        static public Trame DemandeTension()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionIO.DemandeTension;

            return new Trame(tab);
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
            return retour;
        }

        static public Trame Stop(StopMode mode, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Stop;
            tab[2] = (byte)mode;

            Trame retour = new Trame(tab);
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
            return retour;
        }

        static public Trame Recallage(SensAR sens, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.Recallage;
            tab[2] = (byte)sens;

            Trame retour = new Trame(tab);
            return retour;
        }
        
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
            byte[] tab = new byte[4];
            tab[0] = (byte)balise;
            tab[1] = (byte)FonctionBalise.Vitesse;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        static public Trame BaliseReset(Carte balise)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)balise;
            tab[1] = (byte)FonctionBalise.Reset;
            return new Trame(tab);
        }

        static public Trame BaliseTestConnexion(Carte balise)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)balise;
            tab[1] = (byte)FonctionBalise.TestConnexion;
            return new Trame(tab);
        }

        static public Trame BaliseErreurDetection(Carte balise)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)balise;
            tab[1] = (byte)FonctionBalise.ErreurDetection;
            return new Trame(tab);
        }

        static public Trame BaliseInclinaisonFace(Carte balise, int position)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)balise;
            tab[1] = (byte)FonctionBalise.InclinaisonFace;
            tab[2] = ByteDivide(position, true);
            tab[3] = ByteDivide(position, false);
            return new Trame(tab);
        }

        static public Trame BaliseInclinaisonProfil(Carte balise, int position)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)balise;
            tab[1] = (byte)FonctionBalise.InclinaisonProfil;
            tab[2] = ByteDivide(position, true);
            tab[3] = ByteDivide(position, false);
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
            return retour;
        }

        static public Trame DemandePositionsCodeurs(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionMove.DemandePositionsCodeurs;

            Trame retour = new Trame(tab);
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
            return retour;
        }

        static public Trame TestEmission(Carte carte, byte id)
        {
            byte[] tab = new byte[19];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionBalise.TestEmission;
            tab[2] = id;
            tab[3] = 0x00;
            tab[4] = 0x01;
            tab[5] = 0x02;
            tab[6] = 0x03;
            tab[7] = 0x04;
            tab[8] = 0x05;
            tab[9] = 0x06;
            tab[10] = 0x07;
            tab[11] = 0x08;
            tab[12] = 0x09;
            tab[13] = 0x0A;
            tab[14] = 0x0B;
            tab[15] = 0x0C;
            tab[16] = 0x0D;
            tab[17] = 0x0E;
            tab[18] = 0x0F;

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
