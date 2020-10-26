using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications.CAN
{
    static class CanFrameFactory
    {
        public static CanFrameFunction ExtractFunction(Frame frame)
        {
            return (CanFrameFunction)frame[2];
        }

        public static CanBoard ExtractBoard(Frame frame)
        {
            return (CanBoard)(frame[0] * 256 + frame[1]);
        }

        public static CanBoard ExtractSender(Frame frame, bool isInput)
        {
            return isInput ? ExtractBoard(frame) : CanBoard.PC;
        }

        public static CanBoard ExtractReceiver(Frame frame, bool isInput)
        {
            return isInput ? CanBoard.PC : ExtractBoard(frame);
        }

        public static ServomoteurID ExtractServomoteurID(Frame frame)
        {
            return (ServomoteurID)((int)(ExtractBoard(frame) - 1) * 4 + frame[3]);
        }

        public static int ExtractValue(Frame frame, int paramNo = 0)
        {
            return frame[4 + paramNo * 2] * 256 + frame[5 + paramNo * 2];
        }

        public static Frame BuildGetPosition(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.PositionAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildGetPositionMin(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.PositionMinAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildGetPositionMax(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.PositionMaxAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildGetSpeedMax(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.SpeedMaxAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildGetAcceleration(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.AccelerationAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildGetTorqueCurrent(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.TorqueCurrentAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildGetTorqueMax(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.TorqueMaxAsk;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildSetAcceleration(ServomoteurID id, int acceleration)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.AccelerationSet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(acceleration, true);
            tab[5] = ByteDivide(acceleration, false);

            return new Frame(tab);
        }

        public static Frame BuildSetPosition(ServomoteurID id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.PositionSet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            return new Frame(tab);
        }

        public static Frame BuildSetPositionMax(ServomoteurID id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.PositionMaxSet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            return new Frame(tab);
        }

        public static Frame BuildSetPositionMin(ServomoteurID id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.PositionMinSet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            return new Frame(tab);
        }

        public static Frame BuildSetSpeedMax(ServomoteurID id, int speed)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.SpeedMaxSet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(speed, true);
            tab[5] = ByteDivide(speed, false);

            return new Frame(tab);
        }

        public static Frame BuildSetTorqueMax(ServomoteurID id, int torque)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.TorqueMaxSet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(torque, true);
            tab[5] = ByteDivide(torque, false);

            return new Frame(tab);
        }

        public static Frame BuildSetTrajectory(ServomoteurID id, int position, int speed, int accel)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.TrajectorySet;
            tab[3] = GlobalIdToServoNo(id);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            tab[6] = ByteDivide(speed, true);
            tab[7] = ByteDivide(speed, false);
            tab[8] = ByteDivide(accel, true);
            tab[9] = ByteDivide(accel, false);

            return new Frame(tab);
        }

        public static Frame BuildDisableOutput(ServomoteurID id)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)GlobalIdToCanBoard(id);
            tab[2] = (byte)CanFrameFunction.DisableOutput;
            tab[3] = GlobalIdToServoNo(id);

            return new Frame(tab);
        }

        public static Frame BuildTestConnection(CanBoard board)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)board;
            tab[2] = (byte)CanFrameFunction.TestConnection;

            return new Frame(tab);
        }

        public static Frame BuildBeep(CanBoard board, int freqHz, int durationMs)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)board;
            tab[2] = (byte)CanFrameFunction.Buzzer;
            tab[3] = ByteDivide(freqHz, true);
            tab[4] = ByteDivide(freqHz, false);
            tab[5] = ByteDivide(durationMs, true);
            tab[6] = ByteDivide(durationMs, false);

            return new Frame(tab);
        }

        public static Frame BuildDebug(CanBoard board)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)board;
            tab[2] = (byte)CanFrameFunction.Debug;

            return new Frame(tab);
        }

        public static Frame BuildDebugAsk(CanBoard board)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = (byte)board;
            tab[2] = (byte)CanFrameFunction.DebugAsk;

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

        private static CanBoard GlobalIdToCanBoard(ServomoteurID servoGlobalId)
        {
            return (CanBoard)((int)servoGlobalId / 4 + 1);
        }

        private static byte GlobalIdToServoNo(ServomoteurID servoGlobalId)
        {
            return (byte)((int)servoGlobalId % 4);
        }
    }
}
