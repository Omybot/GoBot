using Geometry;
using GoBot.Communications;
using GoBot.Communications.UDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GoBot.Devices
{
    public class PepperlManager
    {
        public struct PepperlPoint
        {
            public uint distance;
            public ushort amplitude;

            public override string ToString()
            {
                return distance.ToString() + "mm - " + Math.Round(amplitude / 40.95f, 0).ToString() + "%";
            }
        }

        private IPAddress _ip;
        private int _port;
        private String _handle;
        private TimeSpan _timeout;

        private PepperlComm _comm;
        private UDPConnection _udp;

        List<PepperlPoint> _currentMeasure;
        int _currentScan;

        public delegate void NewMeasureHandler(List<PepperlPoint> measure, AnglePosition startAngle, AngleDelta resolution);
        public event NewMeasureHandler NewMeasure;

        public PepperlManager(IPAddress ip, int port)
        {
            _ip = ip;
            _port = port;
            _currentScan = -1;
            _timeout = new TimeSpan(0, 0, 10);

            _comm = new PepperlComm(_ip);
        }

        protected void OnNewMeasure(List<PepperlPoint> measure, AnglePosition startAngle, AngleDelta resolution)
        {
            NewMeasure?.Invoke(_currentMeasure, startAngle, resolution);
            _currentMeasure = null;
        }

        public void Reboot()
        {
            _comm.SendCommand(PepperlCmd.Reboot);
        }

        public bool CreateChannelUDP()
        {
            bool ok = false;

            try
            {
                Dictionary<String, String> rep = _comm.SendCommand(PepperlCmd.CreateChannelUDP,
                                        PepperlConst.ParamUdpAddress, FindMyIP().ToString(),
                                        PepperlConst.ParamUdpPort, _port.ToString(),
                                        PepperlConst.ParamUdpWatchdog, PepperlConst.ValueUdpWatchdogOn,
                                        PepperlConst.ParamUdpWatchdogTimeout, _timeout.TotalMilliseconds.ToString(),
                                        PepperlConst.ParamUdpPacketType, PepperlConst.ValueUdpPacketTypeDistanceAmplitudeCompact);

                if (rep != null)
                {
                    _handle = rep[PepperlConst.ParamUdpHandle];

                    if (_handle != "")
                    {
                        _udp = new UDPConnection();
                        _udp.Connect(_ip, _port, _port + 1);
                        _udp.StartReception();
                        _udp.FrameReceived += _udp_FrameReceived;

                        _comm.SendCommand(PepperlCmd.ScanStart,
                                            PepperlConst.ParamUdpHandle, _handle);

                        ok = true;
                    }
                }
            }
            catch (Exception)
            {
                ok = false;

                if (_udp != null && _udp.Connected)
                {
                    _udp.Close();
                    _udp = null;
                }
            }

            return ok;
        }

        public void CloseChannelUDP()
        {
            _comm.SendCommand(PepperlCmd.ScanStop,
                                PepperlConst.ParamUdpHandle, _handle);

            _udp?.Close();
            _udp = null;

            _handle = null;
        }

        private void _udp_FrameReceived(Frame frame)
        {
            int addr = 0;

            ushort magic = (ushort)Read(frame, ref addr, 2);
            ushort packetType = (ushort)Read(frame, ref addr, 2);
            uint packetSize = (uint)Read(frame, ref addr, 4);
            ushort headerSize = (ushort)Read(frame, ref addr, 2);
            ushort scanNumber = (ushort)Read(frame, ref addr, 2);
            ushort packetNumber = (ushort)Read(frame, ref addr, 2);
            long timestampRaw = (long)Read(frame, ref addr, 8);
            long timestampSync = (long)Read(frame, ref addr, 8);
            uint statusFlag = (uint)Read(frame, ref addr, 4);
            uint scanFrequency = (uint)Read(frame, ref addr, 4);
            ushort numPointsScan = (ushort)Read(frame, ref addr, 2);
            ushort numPointsPacket = (ushort)Read(frame, ref addr, 2);
            ushort firstIndex = (ushort)Read(frame, ref addr, 2);
            int firstAngle = ReadInt(frame, ref addr);
            int angularIncrement = ReadInt(frame, ref addr);
            uint iqInput = (uint)Read(frame, ref addr, 4);
            uint iqOverload = (uint)Read(frame, ref addr, 4);
            long iqTimestampRaw = (long)Read(frame, ref addr, 8);
            long iqTimestampSync = (long)Read(frame, ref addr, 8);

            if (firstIndex == 0)
            {
                _currentMeasure = new List<PepperlPoint>();
                _currentScan = scanNumber;
            }

            if (_currentMeasure != null && _currentScan == scanNumber)
            {
                String type = ((char)packetType).ToString();

                if (type == PepperlConst.ValueUdpPacketTypeDistance)
                {
                    for (int iPt = 0; iPt < numPointsPacket; iPt++)
                        _currentMeasure.Add(ReadMeasureA(frame, ref addr));
                }
                else if (type == PepperlConst.ValueUdpPacketTypeDistanceAmplitude)
                {
                    for (int iPt = 0; iPt < numPointsPacket; iPt++)
                        _currentMeasure.Add(ReadMeasureB(frame, ref addr));
                }
                else if (type == PepperlConst.ValueUdpPacketTypeDistanceAmplitudeCompact)
                {
                    for (int iPt = 0; iPt < numPointsPacket; iPt++)
                        _currentMeasure.Add(ReadMeasureC(frame, ref addr));
                }

                if (_currentMeasure.Count == numPointsScan)
                {
                    OnNewMeasure(_currentMeasure, firstAngle / 10000f, angularIncrement / 10000f);
                    _currentMeasure = null;
                }
            }

            // TODO vérification CRC32C ?
        }

        public void FeedWatchDog()
        {
            _comm.SendCommand(PepperlCmd.FeedWatchdog,
                              PepperlConst.ParamFeedWatchdogHandle, _handle);
        }

        public void ShowMessage(String txt1, String txt2)
        {
            _comm.SetParameters(PepperlConst.ParamHmiMode, PepperlConst.ValueHmiModeSoftText,
                                PepperlConst.ParamHmiSoftText1, txt1,
                                PepperlConst.ParamHmiSoftText2, txt2);
        }

        public void SetFrequency(PepperlFreq freq)
        {
            _comm.SetParameters(PepperlConst.ParamScanFrequency, freq.Frequency().ToString(),
                                PepperlConst.ParamSamplesPerScan, freq.SamplesPerScan().ToString());
        }

        public void SetFilter(PepperlFilter filter, int size)
        {
            _comm.SetParameters(PepperlConst.ParamFilterType, filter.GetText(),
                                PepperlConst.ParamFilterWidth, size.ToString());
        }

        private IPAddress FindMyIP()
        {
            return Dns.GetHostAddresses(Dns.GetHostName()).ToList().First(ip => ip.ToString().StartsWith("10.1.0."));
        }

        private long Read(Frame frame, ref int index, int lenght)
        {
            long val = 0;

            for (int i = index + lenght - 1; i >= index; i--)
            {
                val = val << 8;
                val += frame[i];
            }

            index += lenght;

            return val;
        }

        private int ReadInt(Frame frame, ref int index)
        {
            int val = frame[index] | frame[index + 1] << 8 | frame[index + 2] << 16 | frame[index + 3] << 24;

            index += 4;

            return val;
        }

        private PepperlPoint ReadMeasureA(Frame f, ref int i)
        {
            PepperlPoint p;

            p.distance = (uint)Read(f, ref i, 4);
            p.amplitude = 0xFFF;

            if (p.distance == 0xFFFFFFFF) p.distance = 0;

            return p;
        }

        private PepperlPoint ReadMeasureB(Frame f, ref int i)
        {
            PepperlPoint p;
            p.distance = (uint)Read(f, ref i, 4);
            p.amplitude = (ushort)Read(f, ref i, 2);

            if (p.distance == 0xFFFFF) p.distance = 0;

            return p;
        }

        private PepperlPoint ReadMeasureC(Frame f, ref int i)
        {
            long val = Read(f, ref i, 4);

            PepperlPoint p;
            p.distance = (uint)(val & 0xFFFFF);
            p.amplitude = (ushort)(val >> 20);

            if (p.distance == 0xFFFFF) p.distance = 0;

            return p;
        }
    }
}
