using GoBot.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices.CAN
{
    static class CanFrameFactory
    {
        public static CanFunction ExtractFunction(Frame frame)
        {
            return (CanFunction)frame[2];
        }

        public static CanBoard ExtractCanBoard(Frame frame)
        {
            return (CanBoard)(frame[0] * 256 + frame[1]);
        }

        public static int ExtractServoGlobalId(Frame frame)
        {
            return (int)(ExtractCanBoard(frame) - 1) * 4 + frame[3];
        }

        public static int ExtractValue(Frame frame, int paramNo = 0)
        {
            return frame[4 + paramNo * 2] * 256 + frame[5 + paramNo * 2];
        }

        public static Frame BuildGetPosition(int servoGlobalId)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.PositionAsk;
            tab[3] = GlobalIdToServoNo(servoGlobalId);

            return new Frame(tab);
        }

        public static Frame BuildGetPositionMin(int servoGlobalId)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.PositionMinAsk;
            tab[3] = GlobalIdToServoNo(servoGlobalId);

            return new Frame(tab);
        }

        public static Frame BuildGetPositionMax(int servoGlobalId)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.PositionMaxAsk;
            tab[3] = GlobalIdToServoNo(servoGlobalId);

            return new Frame(tab);
        }

        public static Frame BuildGetSpeed(int servoGlobalId)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.SpeedAsk;
            tab[3] = GlobalIdToServoNo(servoGlobalId);

            return new Frame(tab);
        }

        public static Frame BuildGetTorqueCurrent(int servoGlobalId)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.TorqueCurrentAsk;
            tab[3] = GlobalIdToServoNo(servoGlobalId);

            return new Frame(tab);
        }

        public static Frame BuildGetTorqueMax(int servoGlobalId)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.TorqueMaxAsk;
            tab[3] = GlobalIdToServoNo(servoGlobalId);

            return new Frame(tab);
        }

        public static Frame BuildSetPosition(int servoGlobalId, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.PositionSet;
            tab[3] = GlobalIdToServoNo(servoGlobalId);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            return new Frame(tab);
        }

        public static Frame BuildSetPositionMax(int servoGlobalId, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.PositionMaxSet;
            tab[3] = GlobalIdToServoNo(servoGlobalId);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            return new Frame(tab);
        }

        public static Frame BuildSetPositionMin(int servoGlobalId, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.PositionMinSet;
            tab[3] = GlobalIdToServoNo(servoGlobalId);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            return new Frame(tab);
        }

        public static Frame BuildSetSpeed(int servoGlobalId, int speed)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.SpeedSet;
            tab[3] = GlobalIdToServoNo(servoGlobalId);
            tab[4] = ByteDivide(speed, true);
            tab[5] = ByteDivide(speed, false);

            return new Frame(tab);
        }

        public static Frame BuildSetTorqueMax(int servoGlobalId, int torque)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.TorqueMaxSet;
            tab[3] = GlobalIdToServoNo(servoGlobalId);
            tab[4] = ByteDivide(torque, true);
            tab[5] = ByteDivide(torque, false);

            return new Frame(tab);
        }

        public static Frame BuildSetTrajectory(int servoGlobalId, int position, int speed, int accel)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(servoGlobalId);
            tab[2] = (byte)CanFunction.TrajectorySet;
            tab[3] = GlobalIdToServoNo(servoGlobalId);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            tab[6] = ByteDivide(speed, true);
            tab[7] = ByteDivide(speed, false);
            tab[8] = ByteDivide(accel, true);
            tab[9] = ByteDivide(accel, false);

            return new Frame(tab);
        }

        public static Frame BuildSetScore(int score)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)CanBoard.Display;
            tab[2] = (byte)CanFunction.SetScore;
            tab[3] = 0x00;
            tab[4] = ByteDivide(score, true);
            tab[5] = ByteDivide(score, false);

            return new Frame(tab);
        }

        private static byte ByteDivide(int valeur, bool mostSignifiantBit)
        {
            byte b;
            if (mostSignifiantBit)
                b = (byte)(valeur >> 8);
            else
                b = (byte)(valeur & 0x00FF);
            return b;
        }

        private static CanBoard GlobalIdToCanBoard(int servoGlobalId)
        {
            return (CanBoard)(servoGlobalId / 4 + 1);
        }

        private static byte GlobalIdToServoNo(int servoGlobalId)
        {
            return (byte)(servoGlobalId % 4);
        }
    }
}
