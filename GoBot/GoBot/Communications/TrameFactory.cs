using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using GoBot.Calculs.Formes;
using GoBot.Devices;
using System.Drawing;
using GoBot.Calculs;

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

        static public Frame Debug(Carte carte, int numDebug)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            switch(carte)
            {
                case Carte.RecIO:
                    tab[1] = (byte)FonctionTrame.Debug;
                    break;
                case Carte.RecMove:
                    tab[1] = (byte)FonctionTrame.Debug;
                    break;
            }
            tab[2] = (byte)numDebug;

            return new Frame(tab);
        }

        static public Frame SetLed(LedID led, RecGoBot.LedStatus status)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.Led;
            tab[2] = (byte)led;
            tab[3] = (byte)status;

            return new Frame(tab);
        }

        static public Frame DemandeCapteurCouleur(CapteurCouleurID capteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.DemandeCapteurCouleur;
            tab[2] = (byte)capteur;

            return new Frame(tab);
        }

        static public Frame SetLedColor(Color color)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.CouleurLedRGB;
            tab[2] = (byte)0;
            tab[3] = (byte)color.R;
            tab[4] = (byte)color.G;
            tab[5] = (byte)color.B;

            return new Frame(tab);
        }

        static public Frame Buzz(int frequency, byte volume)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.Buzzer;
            tab[2] = (byte)ByteDivide(frequency, true);
            tab[3] = (byte)ByteDivide(frequency, false);
            tab[4] = (byte)volume;

            return new Frame(tab);
        }

        static public Frame ActionneurOnOff(ActionneurOnOffID actionneur, bool onOff)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.PilotageOnOff;
            tab[2] = (byte)actionneur;
            tab[3] = (byte)(onOff ? 1 : 0);

            return new Frame(tab);
        }

        static public Frame DemandeCapteurOnOff(CapteurOnOffID capteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.DemandeCapteurOnOff;
            tab[2] = (byte)capteur;

            return new Frame(tab);
        }

        static public Frame MoteurPosition(MoteurID moteur, int position)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.MoteurPosition;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(position, true);
            tab[4] = (byte)ByteDivide(position, false);

            return new Frame(tab);
        }

        static public Frame BaliseVitesse(int vitesse)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.MoteurPosition;
            tab[2] = (byte)MoteurID.Balise;
            tab[3] = (byte)ByteDivide(vitesse, true);
            tab[4] = (byte)ByteDivide(vitesse, false);

            return new Frame(tab);
        }

        static public Frame DemandeMesureLidar(LidarID lidar)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.DemandeLidar;
            tab[2] = (byte)lidar;

            return new Frame(tab);
        }

        static public Frame MoteurVitesse(MoteurID moteur, SensGD sens, int vitesse)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.MoteurVitesse;
            tab[2] = (byte)moteur;
            tab[3] = (byte)sens;
            tab[4] = (byte)ByteDivide(vitesse, true);
            tab[5] = (byte)ByteDivide(vitesse, false);

            return new Frame(tab);
        }

        static public Frame MoteurAcceleration(MoteurID moteur, int acceleration)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.MoteurAccel;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(acceleration, true);
            tab[4] = (byte)ByteDivide(acceleration, false);

            return new Frame(tab);
        }

        static public Frame ChangementBaudrate(ServoBaudrate baudrate)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.ChangementBaudrateUART;
            tab[2] = (byte)baudrate;

            return new Frame(tab);
        }

        static public Frame Deplacer(SensAR sens, int distance, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Deplace;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame OffsetPos(Position pos, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserEnvoiPositionAbsolue;
            tab[2] = ByteDivide((int)pos.Coordonnees.X, true);
            tab[3] = ByteDivide((int)pos.Coordonnees.X, false);
            tab[4] = ByteDivide((int)pos.Coordonnees.Y, true);
            tab[5] = ByteDivide((int)pos.Coordonnees.Y, false);
            tab[6] = ByteDivide((int)(pos.Angle.AngleDegresPositif * 100), true);
            tab[7] = ByteDivide((int)(pos.Angle.AngleDegresPositif * 100), false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Pivot(SensGD sens, Angle angle, Robot robot)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Pivot;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide((int)(angle * 100.0), true);
            tab[4] = ByteDivide((int)(angle * 100.0), false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Stop(StopMode mode, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Stop;
            tab[2] = (byte)mode;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandePositionContinue(int intervalle, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserIntervalleRetourPosition;
            tab[2] = (byte)(intervalle / 10.0);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame CoeffAsserv(int p, int i, int d, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserPID;
            tab[2] = (byte)ByteDivide(p, true);
            tab[3] = (byte)ByteDivide(p, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d, true);
            tab[7] = (byte)ByteDivide(d, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame CoeffAsservCap(int p, int i, int d, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserPIDCap;
            tab[2] = (byte)ByteDivide(p / 100, true);
            tab[3] = (byte)ByteDivide(p / 100, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d / 100, true);
            tab[7] = (byte)ByteDivide(d / 100, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame CoeffAsservVitesse(int p, int i, int d, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserPID;
            tab[2] = (byte)ByteDivide(p, true);
            tab[3] = (byte)ByteDivide(p, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d, true);
            tab[7] = (byte)ByteDivide(d, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Virage(SensAR sensAr, SensGD sensGd, int rayon, Angle angle, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Virage;
            tab[2] = (byte)sensAr;
            tab[3] = (byte)sensGd;
            tab[4] = (byte)ByteDivide(rayon, true);
            tab[5] = (byte)ByteDivide(rayon, false);
            tab[6] = (byte)ByteDivide((int)(angle * 100), true);
            tab[7] = (byte)ByteDivide((int)(angle * 100), false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame TrajectoirePolaire(SensAR sensAr, List<PointReel> points, Robot robot)
        {
            byte[] tab = new byte[5 + points.Count * 2 * 2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.TrajectoirePolaire;
            tab[2] = (byte)sensAr;
            tab[3] = (byte)ByteDivide(points.Count, true);
            tab[4] = (byte)ByteDivide(points.Count, false);
            for (int i = 0; i < points.Count; i++)
            {
                tab[5 + i * 4 + 0] = ByteDivide((int)(points[i].X * 10), true);
                tab[5 + i * 4 + 1] = ByteDivide((int)(points[i].X * 10), false);
                tab[5 + i * 4 + 2] = ByteDivide((int)(points[i].Y * 10), true);
                tab[5 + i * 4 + 3] = ByteDivide((int)(points[i].Y * 10), false);
            }

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame ResetRecMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.Reset;
            return new Frame(tab);
        }

        static public Frame DemandePosition(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserDemandePositionXYTeta;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame VitesseLigne(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserVitesseDeplacement;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame AccelLigne(int accelDebut, int accelFin, Robot robot)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserAccelerationDeplacement;
            tab[2] = (byte)ByteDivide(accelDebut, true);
            tab[3] = (byte)ByteDivide(accelDebut, false);
            tab[4] = (byte)ByteDivide(accelFin, true);
            tab[5] = (byte)ByteDivide(accelFin, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame VitessePivot(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserVitessePivot;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame AccelPivot(int accel, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserAccelerationPivot;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Recallage(SensAR sens, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Recallage;
            tab[2] = (byte)sens;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame TestConnexion(Carte carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.TestConnexion;
            return new Frame(tab);
        }

        static public Frame DemandeCouleurEquipe()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.DemandeCouleurEquipe;
            return new Frame(tab);
        }


        static public Frame EnvoiConsigneBrute(int consigne, SensAR sens, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserEnvoiConsigneBrutePosition;
            tab[2] = (byte)sens;
            tab[3] = (byte)ByteDivide(consigne, true);
            tab[4] = (byte)ByteDivide(consigne, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandePositionsCodeurs(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserDemandePositionCodeurs;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandeValeursAnalogiques(Carte carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.DemandeValeursAnalogiques;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandeCpuPwm(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.DemandeChargeCPU_PWM;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame EnvoyerUart(Carte carte, Frame trame)
        {
            byte[] tab = new byte[3 + trame.Length];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.EnvoiUart;
            tab[2] = (byte)trame.Length;
            for (int i = 0; i < trame.Length; i++)
                tab[3 + i] = trame[i];

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame CodeurPosition(Carte carte, CodeurID codeur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.DemandePositionCodeur;
            tab[2] = (byte)codeur;

            Frame retour = new Frame(tab);
            return retour;
        }

        #region Servomoteur

        static public Frame ServoDemandeErreurs(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeErreurs;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandePositionCible(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionCible;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiPositionCible(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionCible;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Frame(tab);
        }

        static public Frame ServoEnvoiBaudrate(ServomoteurID servo, ServoBaudrate baud, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiBaudrate;
            tab[3] = (byte)servo;
            tab[4] = (byte)baud;
            return new Frame(tab);
        }

        static public Frame ServoDemandeVitesseMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVitesseMax;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiVitesseMax(ServomoteurID servo, int vitesse, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiVitesseMax;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(vitesse, true);
            tab[5] = ByteDivide(vitesse, false);
            return new Frame(tab);
        }

        static public Frame ServoEnvoiId(ServomoteurID servo, char nouvelId, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiId;
            tab[3] = (byte)servo;
            tab[4] = (byte)nouvelId;
            return new Frame(tab);
        }

        static public Frame ServoReset(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.Reset;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeCoupleMaximum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleMaximum;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiCoupleMaximum(ServomoteurID servo, int couple, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleMaximum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(couple, true);
            tab[5] = ByteDivide(couple, false);
            return new Frame(tab);
        }

        static public Frame ServoEnvoiTensionMax(ServomoteurID servo, double tension, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiTensionMax;
            tab[3] = (byte)servo;
            tab[4] = (byte)(tension * 10);
            return new Frame(tab);
        }

        static public Frame ServoDemandeTemperatureMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTemperatureMax;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiTemperatureMax(ServomoteurID servo, int temperature, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiTemperatureMax;
            tab[3] = (byte)servo;
            tab[4] = (byte)temperature;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiTensionMin(ServomoteurID servo, double tension, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiTensionMin;
            tab[3] = (byte)servo;
            tab[4] = (byte)(tension * 10);
            return new Frame(tab);
        }

        static public Frame ServoDemandeCoupleActive(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleActive;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiCoupleActive(ServomoteurID servo, bool actif, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleActive;
            tab[3] = (byte)servo;
            tab[4] = (byte)(actif ? 1 : 0);
            return new Frame(tab);
        }

        static public Frame ServoDemandeTemperature(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTemperature;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeTension(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTension;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeTensionMin(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTensionMin;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeTensionMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTensionMax;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeMouvement(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeMouvement;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandePositionMinimum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionMinimum;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiPositionMinimum(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionMinimum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Frame(tab);
        }

        static public Frame ServoDemandePositionMaximum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionMaximum;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiPositionMaximum(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionMaximum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Frame(tab);
        }

        static public Frame ServoDemandeNumeroModele(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeNumeroModele;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeVersionFirmware(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVersionFirmware;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeLed(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeLed;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiLed(ServomoteurID servo, bool allume, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiLed;
            tab[3] = (byte)servo;
            tab[4] = (byte)(allume ? 1 : 0);
            return new Frame(tab);
        }

        static public Frame ServoDemandeConfigAlarmeLED(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigAlarmeLED;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiConfigAlarmeLED(ServomoteurID servo, bool inputVoltage, bool angleLimit, bool overheating, bool range, bool checksum, bool overload, bool instruction, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[11];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigAlarmeLED;
            tab[3] = (byte)servo;
            tab[4] = (byte)(inputVoltage ? 1 : 0);
            tab[5] = (byte)(angleLimit ? 1 : 0);
            tab[6] = (byte)(overheating ? 1 : 0);
            tab[7] = (byte)(range ? 1 : 0);
            tab[8] = (byte)(checksum ? 1 : 0);
            tab[9] = (byte)(overload ? 1 : 0);
            tab[10] = (byte)(instruction ? 1 : 0);
            return new Frame(tab);
        }

        static public Frame ServoDemandeConfigAlarmeShutdown(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigAlarmeShutdown;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiConfigAlarmeShutdown(ServomoteurID servo, bool inputVoltage, bool angleLimit, bool overheating, bool range, bool checksum, bool overload, bool instruction, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[11];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigAlarmeShutdown;
            tab[3] = (byte)servo;
            tab[4] = (byte)(inputVoltage ? 1 : 0);
            tab[5] = (byte)(angleLimit ? 1 : 0);
            tab[6] = (byte)(overheating ? 1 : 0);
            tab[7] = (byte)(range ? 1 : 0);
            tab[8] = (byte)(checksum ? 1 : 0);
            tab[9] = (byte)(overload ? 1 : 0);
            tab[10] = (byte)(instruction ? 1 : 0);
            return new Frame(tab);
        }

        static public Frame ServoDemandeConfigEcho(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigEcho;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiConfigEcho(ServomoteurID servo, char val, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigEcho;
            tab[3] = (byte)servo;
            tab[4] = (byte)val;
            return new Frame(tab);
        }

        static public Frame ServoDemandeComplianceParams(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeComplianceParams;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeAllIn(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeAllIn;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiComplianceParams(ServomoteurID servo, byte CCWSlope, byte CCWMargin, byte CWMargin, byte CWSlope, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiComplianceParams;
            tab[3] = (byte)servo;
            tab[4] = CCWSlope;
            tab[5] = CCWMargin;
            tab[6] = CWMargin;
            tab[7] = CWSlope;
            return new Frame(tab);
        }

        static public Frame ServoDemandePositionActuelle(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionActuelle;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeVitesseActuelle(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVitesseActuelle;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeCoupleActuel(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleCourant;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoDemandeCoupleLimite(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleLimite;
            tab[3] = (byte)servo;
            return new Frame(tab);
        }

        static public Frame ServoEnvoiCoupleLimite(ServomoteurID servo, int couple, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleLimite;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(couple, true);
            tab[5] = ByteDivide(couple, false);
            return new Frame(tab);
        }

        #endregion
        
    }
}
