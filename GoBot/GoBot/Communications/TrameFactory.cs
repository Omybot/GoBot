﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using GoBot.Calculs.Formes;
using GoBot.Devices;
using System.Drawing;

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
                    tab[1] = (byte)FonctionTrame.Debug;
                    break;
                case Carte.RecMove:
                    tab[1] = (byte)FonctionTrame.Debug;
                    break;
            }
            tab[2] = (byte)numDebug;

            return new Trame(tab);
        }

        static public Trame SetLed(RecGoBot.Leds led, RecGoBot.LedStatus status)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.Led;
            tab[2] = (byte)led;
            tab[3] = (byte)status;

            return new Trame(tab);
        }

        static public Trame DemandeCapteurCouleur(CapteurCouleurID capteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.DemandeCapteurCouleur;
            tab[2] = (byte)capteur;

            return new Trame(tab);
        }

        static public Trame SetLedColor(Color color)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.CouleurLedRGB;
            tab[2] = (byte)0;
            tab[3] = (byte)color.R;
            tab[4] = (byte)color.G;
            tab[5] = (byte)color.B;

            return new Trame(tab);
        }

        static public Trame Buzz(byte volume)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.Buzzer;
            tab[2] = (byte)volume;

            return new Trame(tab);
        }

        static public Trame ActionneurOnOff(ActionneurOnOffID actionneur, bool onOff)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.PilotageOnOff;
            tab[2] = (byte)actionneur;
            tab[3] = (byte)(onOff ? 1 : 0);

            return new Trame(tab);
        }

        static public Trame DemandeCapteurOnOff(CapteurOnOffID capteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.DemandeCapteurOnOff;
            tab[2] = (byte)capteur;

            return new Trame(tab);
        }

        static public Trame MoteurPosition(MoteurID moteur, int position)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.MoteurPosition;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(position, true);
            tab[4] = (byte)ByteDivide(position, false);

            return new Trame(tab);
        }

        static public Trame BaliseVitesse(int vitesse)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.MoteurPosition;
            tab[2] = (byte)MoteurID.Balise;
            tab[3] = (byte)ByteDivide(vitesse, true);
            tab[4] = (byte)ByteDivide(vitesse, false);

            return new Trame(tab);
        }

        static public Trame DemandeMesureLidar(LidarID lidar)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.DemandeLidar;
            tab[2] = (byte)lidar;

            return new Trame(tab);
        }

        static public Trame MoteurVitesse(MoteurID moteur, int vitesse)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.MoteurVitesse;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(vitesse, true);
            tab[4] = (byte)ByteDivide(vitesse, false);

            return new Trame(tab);
        }

        static public Trame MoteurAcceleration(MoteurID moteur, int acceleration)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.MoteurAccel;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(acceleration, true);
            tab[4] = (byte)ByteDivide(acceleration, false);

            return new Trame(tab);
        }

        static public Trame ChangementBaudrate(ServoBaudrate baudrate)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.ChangementBaudrateUART;
            tab[2] = (byte)baudrate;

            return new Trame(tab);
        }

        static public Trame Deplacer(SensAR sens, int distance, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Deplace;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame OffsetPos(int offsetX, int offsetY, double offsetTeta, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserEnvoiPositionAbsolue;
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
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Pivot;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide((int)(angle * 100.0), true);
            tab[4] = ByteDivide((int)(angle * 100.0), false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame Stop(StopMode mode, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Stop;
            tab[2] = (byte)mode;

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame DemandePositionContinue(int intervalle, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserIntervalleRetourPosition;
            tab[2] = (byte)(intervalle / 10.0);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame CoeffAsserv(int p, int i, int d, Robot robot)
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

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame CoeffAsservCap(int p, int i, int d, Robot robot)
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

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame CoeffAsservVitesse(int p, int i, int d, Robot robot)
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

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame Virage(SensAR sensAr, SensGD sensGd, int rayon, double angle, Robot robot)
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

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame TrajectoirePolaire(SensAR sensAr, List<PointReel> points, Robot robot)
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

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame ResetRecMove()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.Reset;
            return new Trame(tab);
        }

        static public Trame DemandePosition(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserDemandePositionXYTeta;

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame VitesseLigne(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserVitesseDeplacement;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame AccelLigne(int accelDebut, int accelFin, Robot robot)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserAccelerationDeplacement;
            tab[2] = (byte)ByteDivide(accelDebut, true);
            tab[3] = (byte)ByteDivide(accelDebut, false);
            tab[4] = (byte)ByteDivide(accelFin, true);
            tab[5] = (byte)ByteDivide(accelFin, false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame VitessePivot(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserVitessePivot;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame AccelPivot(int accel, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserAccelerationPivot;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame Recallage(SensAR sens, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.Recallage;
            tab[2] = (byte)sens;

            Trame retour = new Trame(tab);
            return retour;
        }
        
        static public Trame TestConnexionMove(bool bridageAsserv)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Carte.RecMove;
            tab[1] = (byte)FonctionTrame.TestConnexion;
            tab[2] = (byte)(bridageAsserv ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame TestConnexionIO()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.TestConnexion;
            return new Trame(tab);
        }

        static public Trame TestConnexionGB()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecGB;
            tab[1] = (byte)FonctionTrame.TestConnexion;
            return new Trame(tab);
        }

        static public Trame DemandeCouleurEquipe()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.DemandeCouleurEquipe;
            return new Trame(tab);
        }


        static public Trame EnvoiConsigneBrute(int consigne, SensAR sens, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserEnvoiConsigneBrutePosition;
            tab[2] = (byte)sens;
            tab[3] = (byte)ByteDivide(consigne, true);
            tab[4] = (byte)ByteDivide(consigne, false);

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame DemandePositionsCodeurs(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.AsserDemandePositionCodeurs;

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame DemandeValeursAnalogiques(Carte carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.DemandeValeursAnalogiques;

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame ArmerJack()
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)Carte.RecIO;
            tab[1] = (byte)FonctionTrame.ArmerJack;
            return new Trame(tab);
        }

        static public Trame DemandeCpuPwm(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.Carte;
            tab[1] = (byte)FonctionTrame.DemandeChargeCPU_PWM;

            Trame retour = new Trame(tab);
            return retour;
        }

        static public Trame EnvoyerUart(Carte carte, Trame trame)
        {
            byte[] tab = new byte[3 + trame.Length];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.EnvoiUart;
            tab[2] = (byte)trame.Length;
            for (int i = 0; i < trame.Length; i++)
                tab[3 + i] = trame[i];

            Trame retour = new Trame(tab);
            return retour;
        }

        #region Servomoteur

        static public Trame ServoDemandeErreurs(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeErreurs;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionCible(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionCible;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiPositionCible(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiPositionCible;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            return new Trame(tab);
        }

        static public Trame ServoEnvoiBaudrate(ServomoteurID servo, ServoBaudrate baud, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiBaudrate;
            tab[3] = (byte)servo;
            tab[4] = (byte)baud;
            return new Trame(tab);
        }

        static public Trame ServoDemandeVitesseMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVitesseMax;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiVitesseMax(ServomoteurID servo, int vitesse, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiVitesseMax;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(vitesse, true);
            tab[5] = ByteDivide(vitesse, false);
            return new Trame(tab);
        }

        static public Trame ServoEnvoiId(ServomoteurID servo, char nouvelId, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiId;
            tab[3] = (byte)servo;
            tab[4] = (byte)nouvelId;
            return new Trame(tab);
        }

        static public Trame ServoReset(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.Reset;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeCoupleMaximum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleMaximum;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiCoupleMaximum(ServomoteurID servo, int couple, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleMaximum;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(couple, true);
            tab[5] = ByteDivide(couple, false);
            return new Trame(tab);
        }

        static public Trame ServoEnvoiTensionMax(ServomoteurID servo, double tension, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiTensionMax;
            tab[3] = (byte)servo;
            tab[4] = (byte)(tension * 10);
            return new Trame(tab);
        }

        static public Trame ServoDemandeTemperatureMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTemperatureMax;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiTemperatureMax(ServomoteurID servo, int temperature, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiTemperatureMax;
            tab[3] = (byte)servo;
            tab[4] = (byte)temperature;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiTensionMin(ServomoteurID servo, double tension, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiTensionMin;
            tab[3] = (byte)servo;
            tab[4] = (byte)(tension * 10);
            return new Trame(tab);
        }

        static public Trame ServoDemandeCoupleActive(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleActive;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiCoupleActive(ServomoteurID servo, bool actif, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleActive;
            tab[3] = (byte)servo;
            tab[4] = (byte)(actif ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame ServoDemandeTemperature(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTemperature;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeTension(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTension;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeTensionMin(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTensionMin;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeTensionMax(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeTensionMax;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeMouvement(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeMouvement;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionMinimum(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionMinimum;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiPositionMinimum(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
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
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionMaximum;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiPositionMaximum(ServomoteurID servo, int position, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
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
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeNumeroModele;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeVersionFirmware(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVersionFirmware;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeLed(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeLed;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiLed(ServomoteurID servo, bool allume, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiLed;
            tab[3] = (byte)servo;
            tab[4] = (byte)(allume ? 1 : 0);
            return new Trame(tab);
        }

        static public Trame ServoDemandeConfigAlarmeLED(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigAlarmeLED;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiConfigAlarmeLED(ServomoteurID servo, bool inputVoltage, bool angleLimit, bool overheating, bool range, bool checksum, bool overload, bool instruction, Carte carte = Carte.RecIO)
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
            return new Trame(tab);
        }

        static public Trame ServoDemandeConfigAlarmeShutdown(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigAlarmeShutdown;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiConfigAlarmeShutdown(ServomoteurID servo, bool inputVoltage, bool angleLimit, bool overheating, bool range, bool checksum, bool overload, bool instruction, Carte carte = Carte.RecIO)
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
            return new Trame(tab);
        }

        static public Trame ServoDemandeConfigEcho(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeConfigEcho;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiConfigEcho(ServomoteurID servo, char val, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiConfigEcho;
            tab[3] = (byte)servo;
            tab[4] = (byte)val;
            return new Trame(tab);
        }

        static public Trame ServoDemandeComplianceParams(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeComplianceParams;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeAllIn(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeAllIn;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiComplianceParams(ServomoteurID servo, byte CCWSlope, byte CCWMargin, byte CWMargin, byte CWSlope, Carte carte = Carte.RecIO)
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
            return new Trame(tab);
        }

        static public Trame ServoDemandePositionActuelle(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandePositionActuelle;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeVitesseActuelle(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeVitesseActuelle;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeCoupleActuel(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleCourant;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoDemandeCoupleLimite(ServomoteurID servo, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.DemandeCoupleLimite;
            tab[3] = (byte)servo;
            return new Trame(tab);
        }

        static public Trame ServoEnvoiCoupleLimite(ServomoteurID servo, int couple, Carte carte = Carte.RecIO)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)carte;
            tab[1] = (byte)FonctionTrame.CommandeServo;
            tab[2] = (byte)FonctionServo.EnvoiCoupleLimite;
            tab[3] = (byte)servo;
            tab[4] = ByteDivide(couple, true);
            tab[5] = ByteDivide(couple, false);
            return new Trame(tab);
        }

        #endregion

        public static Carte Identifiant(Trame trame)
        {
            try
            {
                switch (trame[0])
                {
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
