using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications.CAN
{
    public enum CanFrameFunction
    {
        PositionAsk = 0x01,
        PositionResponse = 0x02,
        PositionSet = 0x03,
        PositionMinAsk = 0x04,
        PositionMinResponse = 0x05,
        PositionMinSet = 0x06,
        PositionMaxAsk = 0x07,
        PositionMaxResponse = 0x08,
        PositionMaxSet = 0x09,
        SpeedMaxAsk = 0x0A,
        SpeedMaxResponse = 0x0B,
        SpeedMaxSet = 0x0C,
        TorqueMaxAsk = 0x0D,
        TorqueMaxResponse = 0x0E,
        TorqueMaxSet = 0x0F,
        TorqueCurrentAsk = 0x10,
        TorqueCurrentResponse = 0x11,
        AccelerationAsk = 0x12,
        AccelerationResponse = 0x13,
        AccelerationSet = 0x14,
        TargetSet = 0x15,
        TrajectorySet = 0x16,
        DisableOutput = 0x17,

        SetScore = 0xA0,

        Debug = 0xF0,
        DebugAsk = 0xF1,
        DebugResponse = 0xF2,
    }

    public enum CanBoard
    {
        PC = 0x00,
        CanServo1 = 0x01,
        CanServo2 = 0x02,
        CanServo3 = 0x03,
        CanServo4 = 0x04,
        CanServo5 = 0x05,
        CanDisplay = 0x10
    }
}
