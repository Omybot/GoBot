using Geometry;
using Geometry.Shapes;
using GoBot.Devices;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace GoBot.Communications.UDP
{
    static class UdpFrameFactory
    {
        static public UdpFrameFunction ExtractFunction(Frame frame)
        {
            return (UdpFrameFunction)frame[1];
        }

        static public Board ExtractBoard(Frame frame)
        {
            return (Board)frame[0];
        }

        static public Board ExtractSender(Frame frame, bool isInput)
        {
            return isInput ? (Board)frame[0] : Board.PC;
        }

        static public Board ExtractReceiver(Frame frame, bool isInput)
        {
            return isInput ? Board.PC : (Board)frame[0];
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

        static public Frame Debug(Board carte, int numDebug)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            switch(carte)
            {
                case Board.RecIO:
                    tab[1] = (byte)UdpFrameFunction.Debug;
                    break;
                case Board.RecMove:
                    tab[1] = (byte)UdpFrameFunction.Debug;
                    break;
            }
            tab[2] = (byte)numDebug;

            return new Frame(tab);
        }

        static public Frame DemandeCapteurCouleur(SensorColorID capteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.DemandeCapteurCouleur;
            tab[2] = (byte)capteur;

            return new Frame(tab);
        }

        static public Frame DemandeMesureLidar(LidarID lidar)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Board.RecMove;
            tab[1] = (byte)UdpFrameFunction.DemandeLidar;
            tab[2] = (byte)lidar;

            return new Frame(tab);
        }

        static public Frame ActionneurOnOff(ActuatorOnOffID actionneur, bool onOff)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.PilotageOnOff;
            tab[2] = (byte)actionneur;
            tab[3] = (byte)(onOff ? 1 : 0);

            return new Frame(tab);
        }

        static public Frame DemandeCapteurOnOff(Board board, SensorOnOffID capteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)board;
            tab[1] = (byte)UdpFrameFunction.DemandeCapteurOnOff;
            tab[2] = (byte)capteur;

            return new Frame(tab);
        }

        static public Frame MoteurPosition(MotorID moteur, int position)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.MoteurPosition;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(position, true);
            tab[4] = (byte)ByteDivide(position, false);

            return new Frame(tab);
        }

        static public Frame MoteurStop(MotorID moteur, StopMode mode)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.MoteurStop;
            tab[2] = (byte)moteur;
            tab[3] = (byte)mode;

            return new Frame(tab);
        }

        static public Frame BaliseVitesse(int vitesse)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Board.RecMove;
            tab[1] = (byte)UdpFrameFunction.MoteurPosition;
            tab[2] = (byte)MotorID.Beacon;
            tab[3] = (byte)ByteDivide(vitesse, true);
            tab[4] = (byte)ByteDivide(vitesse, false);

            return new Frame(tab);
        }

        static public Frame MoteurVitesse(Board board, MotorID moteur, SensGD sens, int vitesse)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)board;
            tab[1] = (byte)UdpFrameFunction.MoteurVitesse;
            tab[2] = (byte)moteur;
            tab[3] = (byte)sens;
            tab[4] = (byte)ByteDivide(vitesse, true);
            tab[5] = (byte)ByteDivide(vitesse, false);

            return new Frame(tab);
        }

        static public Frame MoteurAcceleration(MotorID moteur, int acceleration)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.MoteurAccel;
            tab[2] = (byte)moteur;
            tab[3] = (byte)ByteDivide(acceleration, true);
            tab[4] = (byte)ByteDivide(acceleration, false);

            return new Frame(tab);
        }

        static public Frame MoteurResetPosition(MotorID moteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.MoteurResetPosition;
            tab[2] = (byte)moteur;

            return new Frame(tab);
        }

        static public Frame MoteurOrigin(MotorID moteur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.MoteurOrigin;
            tab[2] = (byte)moteur;

            return new Frame(tab);
        }

        static public Frame ChangementBaudrate(ServoBaudrate baudrate)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)Board.RecIO;
            tab[1] = (byte)UdpFrameFunction.ChangementBaudrateUART;
            tab[2] = (byte)baudrate;

            return new Frame(tab);
        }

        static public Frame Deplacer(SensAR sens, int distance, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.Deplace;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide(distance, true);
            tab[4] = ByteDivide(distance, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame OffsetPos(Position pos, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserEnvoiPositionAbsolue;
            tab[2] = ByteDivide((int)pos.Coordinates.X, true);
            tab[3] = ByteDivide((int)pos.Coordinates.X, false);
            tab[4] = ByteDivide((int)pos.Coordinates.Y, true);
            tab[5] = ByteDivide((int)pos.Coordinates.Y, false);
            tab[6] = ByteDivide((int)(pos.Angle.InPositiveDegrees * 100), true);
            tab[7] = ByteDivide((int)(pos.Angle.InPositiveDegrees * 100), false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Pivot(SensGD sens, AngleDelta angle, Robot robot)
        {
            byte[] tab = new byte[7];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.Pivot;
            tab[2] = (byte)sens;
            tab[3] = ByteDivide((int)(angle * 100.0), true);
            tab[4] = ByteDivide((int)(angle * 100.0), false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Stop(StopMode mode, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.Stop;
            tab[2] = (byte)mode;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandePositionContinue(int intervalle, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserIntervalleRetourPosition;
            tab[2] = (byte)(intervalle / 10.0);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame CoeffAsserv(int p, int i, int d, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserPID;
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
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserPIDCap;
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
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserPID;
            tab[2] = (byte)ByteDivide(p, true);
            tab[3] = (byte)ByteDivide(p, false);
            tab[4] = (byte)ByteDivide(i, true);
            tab[5] = (byte)ByteDivide(i, false);
            tab[6] = (byte)ByteDivide(d, true);
            tab[7] = (byte)ByteDivide(d, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Virage(SensAR sensAr, SensGD sensGd, int rayon, AngleDelta angle, Robot robot)
        {
            byte[] tab = new byte[8];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.Virage;
            tab[2] = (byte)sensAr;
            tab[3] = (byte)sensGd;
            tab[4] = (byte)ByteDivide(rayon, true);
            tab[5] = (byte)ByteDivide(rayon, false);
            tab[6] = (byte)ByteDivide((int)(angle * 100), true);
            tab[7] = (byte)ByteDivide((int)(angle * 100), false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame TrajectoirePolaire(SensAR sensAr, List<RealPoint> points, Robot robot)
        {
            byte[] tab = new byte[5 + points.Count * 2 * 2];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.TrajectoirePolaire;
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
            tab[0] = (byte)Board.RecMove;
            tab[1] = (byte)UdpFrameFunction.Reset;
            return new Frame(tab);
        }

        static public Frame DemandePosition(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserDemandePositionXYTeta;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame VitesseLigne(int vitesse, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserVitesseDeplacement;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame AccelLigne(int accelDebut, int accelFin, Robot robot)
        {
            byte[] tab = new byte[6];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserAccelerationDeplacement;
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
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserVitessePivot;
            tab[2] = (byte)ByteDivide(vitesse, true);
            tab[3] = (byte)ByteDivide(vitesse, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame AccelPivot(int accel, Robot robot)
        {
            byte[] tab = new byte[4];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserAccelerationPivot;
            tab[2] = (byte)ByteDivide(accel, true);
            tab[3] = (byte)ByteDivide(accel, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame Recallage(SensAR sens, Robot robot)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.Recallage;
            tab[2] = (byte)sens;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame TestConnexion(Board carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.TestConnexion;
            return new Frame(tab);
        }

        static public Frame EnvoiConsigneBrute(int consigne, SensAR sens, Robot robot)
        {
            byte[] tab = new byte[5];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserEnvoiConsigneBrutePosition;
            tab[2] = (byte)sens;
            tab[3] = (byte)ByteDivide(consigne, true);
            tab[4] = (byte)ByteDivide(consigne, false);

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandePositionsCodeurs(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.AsserDemandePositionCodeurs;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandeValeursAnalogiques(Board carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.DemandeValeursAnalogiques;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandeValeursNumeriques(Board carte)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.DemandeValeursNumeriques;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame DemandeCpuPwm(Robot robot)
        {
            byte[] tab = new byte[2];
            tab[0] = (byte)robot.AsservBoard;
            tab[1] = (byte)UdpFrameFunction.DemandeChargeCPU_PWM;

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame EnvoyerUart1(Board carte, Frame trame)
        {
            byte[] tab = new byte[3 + trame.Length];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.EnvoiUart1;
            tab[2] = (byte)trame.Length;
            for (int i = 0; i < trame.Length; i++)
                tab[3 + i] = trame[i];

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame EnvoyerCAN(Board carte, Frame trame)
        {
            byte[] tab = new byte[3 + trame.Length];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.EnvoiCAN;
            tab[2] = (byte)trame.Length;
            for (int i = 0; i < trame.Length; i++)
                tab[3 + i] = trame[i];

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame EnvoyerUart2(Board carte, Frame trame)
        {
            byte[] tab = new byte[3 + trame.Length];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.EnvoiUart2;
            tab[2] = (byte)trame.Length;
            for (int i = 0; i < trame.Length; i++)
                tab[3 + i] = trame[i];

            Frame retour = new Frame(tab);
            return retour;
        }

        static public Frame CodeurPosition(Board carte, CodeurID codeur)
        {
            byte[] tab = new byte[3];
            tab[0] = (byte)carte;
            tab[1] = (byte)UdpFrameFunction.DemandePositionCodeur;
            tab[2] = (byte)codeur;

            Frame retour = new Frame(tab);
            return retour;
        }
    }
}
