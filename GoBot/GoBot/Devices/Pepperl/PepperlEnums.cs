using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    public enum PepperlCmd
    {
        [Description(PepperlConst.CmdReboot)]
        Reboot,
        [Description(PepperlConst.CmfFactoryReset)]
        FactoryReset,
        [Description(PepperlConst.CmdHandleUdp)]
        CreateChannelUDP,
        [Description(PepperlConst.CmdHandleTcp)]
        CreateChannelTCP,
        [Description(PepperlConst.CmdProtocolInfo)]
        ProtocolInfo,
        [Description(PepperlConst.CmdFeedWatchdog)]
        FeedWatchdog,
        [Description(PepperlConst.CmdListParameters)]
        ListParameters,
        [Description(PepperlConst.CmdGetParameter)]
        GetParameters,
        [Description(PepperlConst.CmdSetParameter)]
        SetParameters,
        [Description(PepperlConst.CmdResetParameter)]
        ResetParameters,
        [Description(PepperlConst.CmdReleaseHandle)]
        CloseChannel,
        [Description(PepperlConst.CmdStartScan)]
        ScanStart,
        [Description(PepperlConst.CmdStopScan)]
        ScanStop,
        [Description(PepperlConst.CmdGetScanConfig)]
        GetScanConfig,
        [Description(PepperlConst.CmdSetScanConfig)]
        SetScanConfig
    }

    public enum PepperlFreq
    {
        Hz10,
        Hz11,
        Hz13,
        Hz15,
        Hz16,
        Hz20,
        Hz23,
        Hz26,
        Hz30,
        Hz33,
        Hz35,
        Hz40,
        Hz46,
        Hz50
    }

    public enum PepperlFilter
    {
        [Description(PepperlConst.ValueFilterTypeNone)]
        None,
        [Description(PepperlConst.ValueFilterTypeAverage)]
        Average,
        [Description(PepperlConst.ValueFilterTypeMedian)]
        Median,
        [Description(PepperlConst.ValueFilterTypeMaximum)]
        Maximum,
        [Description(PepperlConst.ValueFilterTypeRemission)]
        Remission
    }

    public static class PepperEnumExtensions
    {
        public static string GetText(this PepperlCmd val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string GetText(this PepperlFilter val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static int SamplesPerScan(this PepperlFreq freq)
        {
            switch (freq)
            {
                case PepperlFreq.Hz10: return 8400;
                case PepperlFreq.Hz11: return 7200;
                case PepperlFreq.Hz13: return 6300;
                case PepperlFreq.Hz15: return 5600;
                case PepperlFreq.Hz16: return 5040;
                case PepperlFreq.Hz20: return 4200;
                case PepperlFreq.Hz23: return 3600;
                case PepperlFreq.Hz26: return 3150;
                case PepperlFreq.Hz30: return 2800;
                case PepperlFreq.Hz33: return 2520;
                case PepperlFreq.Hz35: return 2400;
                case PepperlFreq.Hz40: return 2100;
                case PepperlFreq.Hz46: return 1800;
                case PepperlFreq.Hz50: return 1680;
                default: return 0;
            }
        }

        public static int Frequency(this PepperlFreq freq)
        {
            switch (freq)
            {
                case PepperlFreq.Hz10: return 10;
                case PepperlFreq.Hz11: return 11;
                case PepperlFreq.Hz13: return 13;
                case PepperlFreq.Hz15: return 15;
                case PepperlFreq.Hz16: return 16;
                case PepperlFreq.Hz20: return 20;
                case PepperlFreq.Hz23: return 23;
                case PepperlFreq.Hz26: return 26;
                case PepperlFreq.Hz30: return 30;
                case PepperlFreq.Hz33: return 33;
                case PepperlFreq.Hz35: return 35;
                case PepperlFreq.Hz40: return 40;
                case PepperlFreq.Hz46: return 46;
                case PepperlFreq.Hz50: return 50;
                default: return 0;
            }
        }
    }
}
