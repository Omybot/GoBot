using Geometry;
using Geometry.Shapes;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace GoBot.Devices
{
    public class Hokuyo
    {
        #region Attributs

        private LidarID _id;

        private SerialPort _port;

        protected String _frameMeasure;
        protected String _frameDetails;
        protected String _frameSpecif;
        protected String _frameHighSentitivity, _frameLowSentitivity;

        protected String _romVendor, _romProduct, _romFirmware, _romProtocol, _romSerialNumber, _romModel;
        protected int _romMinDistance, _romMaxDistance, _romDivisions, _romFirstMeasure, _romLastMeasure, _romTotalMeasures, _romMotorSpeed;
        protected int _usefullMeasures;
        protected AngleDelta _scanRange, _resolution;

        protected int _distanceMinLimit, _distanceMaxLimit;

        protected Position _position;
        protected int _keepFrom, _keepTo;
        protected bool _invertRotation;

        private Semaphore _lock;
        private TicksPerSecond _measuresTicker;
        private ThreadLink _linkMeasures;

        private List<RealPoint> _lastMeasure;

        #endregion

        #region Propriétés

        public LidarID ID { get { return _id; } }

        public String Model { get { return _romModel; } }

        public AngleDelta ScanRange { get { return _scanRange; } }

        public AngleDelta DeadAngle { get { return new AngleDelta(360 - _scanRange); } }

        public int PointsCount { get { return _romTotalMeasures; } }

        public Position Position { get { return _position; } set { _position = value; } }

        public List<RealPoint> LastMeasure { get { return _lastMeasure; } }

        public int DistanceMaxLimit { get { return _distanceMaxLimit; } set { _distanceMaxLimit = value; } }

        public int KeepFrom
        {
            get { return _keepFrom; }
            set
            {
                _lock.WaitOne();
                _keepFrom = value;
                _frameMeasure = "MS" + _keepFrom.ToString("0000") + _keepTo.ToString("0000") + "00001\n";
                _lock.Release();
            }
        }

        public int KeepTo
        {
            get { return _keepTo; }
            set
            {
                _lock.WaitOne();
                _keepTo = value;
                _frameMeasure = "MS" + _keepFrom.ToString("0000") + _keepTo.ToString("0000") + "00001\n";
                _lock.Release();
            }
        }

        #endregion

        #region Constructeurs

        public Hokuyo(LidarID id)
        {
            _id = id;
            _lock = new Semaphore(1, 1);

            _distanceMaxLimit = 3999; // En dessous de 4000 parce que le protocole choisi seuille le maximum à 4000 niveau matos

            _position = new Position();

            _lastMeasure = null;
            _measuresTicker = new TicksPerSecond();
            _measuresTicker.ValueChange += _measuresPerSecond_ValueChange;

            _frameDetails = "VV\n";
            _frameSpecif = "PP\n";
            _frameLowSentitivity = "HS0\n";
            _frameHighSentitivity = "HS1\n";

            _invertRotation = false;
        }

        public Hokuyo(LidarID id, String portCom) : this(id)
        {
            _port = new SerialPort(portCom, 115200);
            _port.Open();

            IdentifyModel();
        }

        #endregion

        #region Evenements sortants

        public delegate void NewMeasureDelegate(List<RealPoint> measure);
        public event NewMeasureDelegate NewMeasure;

        public delegate void FrequencyChangeDelegate(double value);
        public event FrequencyChangeDelegate FrequencyChange;

        protected void OnNewMeasure(List<RealPoint> measure)
        {
            _measuresTicker.AddTick();
            NewMeasure?.Invoke(measure);
        }

        protected void OnFrequencyChange(double freq)
        {
            FrequencyChange?.Invoke(freq);
        }

        #endregion

        #region Evenements entrants

        private void _measuresPerSecond_ValueChange(double value)
        {
            OnFrequencyChange(value);
        }

        #endregion

        #region Fonctionnement externe

        public void StartLoopMeasure()
        {
            _measuresTicker.Start();
            _linkMeasures = ThreadManager.CreateThread(link => DoMeasure());
            _linkMeasures.Name = "Mesure Hokuyo " + _id.ToString();
            _linkMeasures.StartInfiniteLoop(new TimeSpan());
        }

        public void StopLoopMeasure()
        {
            _linkMeasures.Cancel();
            _measuresTicker.Stop();
        }

        public List<RealPoint> GetPoints()
        {
            return GetPoints(_position);
        }

        public List<RealPoint> GetRawPoints()
        {
            return GetPoints(new Position());
        }

        #endregion

        #region Fonctionnement interne

        private List<RealPoint> GetPoints(Position reference)
        {
            List<RealPoint> points = new List<RealPoint>();

            _lock.WaitOne();

            String reponse = GetMeasure();

            try
            {
                if (reponse != "")
                {
                    List<int> mesures = DecodeMessage(reponse);
                    points = ValuesToPositions(mesures, false, _distanceMinLimit, _distanceMaxLimit, reference);
                }
            }
            catch (Exception) { }

            _lock.Release();

            return points;
        }

        private void IdentifyModel()
        {
            SendMessage(_frameDetails);
            String response = GetResponse();

            List<String> details = response.Split(new char[] { '\n', ':', ';' }).ToList();

            _romVendor = details[3];
            _romProduct = details[6];
            _romFirmware = details[9];
            _romProtocol = details[12];
            _romSerialNumber = details[15];

            SendMessage(_frameSpecif);
            response = GetResponse();

            details = response.Split(new char[] { '\n', ':', ';' }).ToList();

            _romModel = details[3];
            _romMinDistance = int.Parse(details[6]);
            _romMaxDistance = int.Parse(details[9]);
            _romDivisions = int.Parse(details[12]);
            _romFirstMeasure = int.Parse(details[15]);
            _romLastMeasure = int.Parse(details[18]);
            _romTotalMeasures = int.Parse(details[21]) * 2 + 1;
            _romMotorSpeed = int.Parse(details[24]);

            _usefullMeasures = _romTotalMeasures - (_romTotalMeasures - (_romLastMeasure + 1)) - _romFirstMeasure;
            _resolution = 360.0 / _romDivisions;
            _scanRange = _resolution * _usefullMeasures;

            _keepFrom = _romFirstMeasure;
            _keepTo = _romFirstMeasure + _usefullMeasures - 1;

            _frameMeasure = "MS" + _keepFrom.ToString("0000") + _keepTo.ToString("0000") + "00001\n";
        }

        private String GetMeasure(int timeout = 500)
        {
            SendMessage(_frameMeasure);
            return GetResponse(timeout);
        }

        protected virtual void SendMessage(String msg)
        {
            _port.Write(msg);
        }

        protected virtual String GetResponse(int timeout = 500)
        {
            Stopwatch chrono = Stopwatch.StartNew();
            String reponse = "";

            do
            {
                reponse += _port.ReadExisting();
            } while (!reponse.Contains("\n\n") && chrono.ElapsedMilliseconds < timeout);

            chrono.Stop();

            if (chrono.ElapsedMilliseconds >= timeout)
                return "";
            else
                return reponse;
        }

        private void DoMeasure()
        {
            _lastMeasure = GetPoints();
            if (!_linkMeasures.Cancelled) OnNewMeasure(_lastMeasure);
        }

        //private List<RealPoint> ValuesToPositions(List<int> measures, int pointsCount, bool limitOnTable, int minDistance, int maxDistance, Position refPosition)
        //{
        //    List<RealPoint> positions = new List<RealPoint>();
        //    double stepAngular = ScanRange.InDegrees / pointsCount;

        //    for (int i = 0; i < measures.Count; i++)
        //    {
        //        AnglePosition angle = stepAngular * (i + _keepFrom);

        //        if (measures[i] > minDistance && (measures[i] < maxDistance || maxDistance == -1))
        //        {
        //            AnglePosition anglePoint = new AnglePosition(angle.InPositiveRadians - refPosition.Angle.InPositiveRadians - ScanRange.InRadians / 2 - Math.PI / 2, AngleType.Radian);

        //            RealPoint pos = new RealPoint(refPosition.Coordinates.X - anglePoint.Sin * measures[i], refPosition.Coordinates.Y - anglePoint.Cos * measures[i]);

        //            int marge = 20; // Marge en mm de distance de detection à l'exterieur de la table (pour ne pas jeter les mesures de la bordure qui ne collent pas parfaitement)
        //            if (!limitOnTable || (pos.X > -marge && pos.X < Plateau.Largeur + marge && pos.Y > -marge && pos.Y < Plateau.Hauteur + marge))
        //                positions.Add(pos);
        //        }
        //    }

        //    return positions;
        //}

        private List<RealPoint> ValuesToPositions(List<int> measures, bool limitOnTable, int minDistance, int maxDistance, Position refPosition)
        {
            List<RealPoint> positions = new List<RealPoint>();

            for (int i = 0; i < measures.Count; i++)
            {
                AnglePosition angle = _resolution * (i + _keepFrom);

                if (measures[i] > minDistance && (measures[i] < maxDistance || maxDistance == -1))
                {
                    AnglePosition anglePoint = new AnglePosition(angle.InPositiveRadians - refPosition.Angle.InPositiveRadians - ScanRange.InRadians / 2 - Math.PI / 2, AngleType.Radian);

                    RealPoint pos = new RealPoint(refPosition.Coordinates.X - anglePoint.Sin * measures[i], refPosition.Coordinates.Y - anglePoint.Cos * measures[i]);

                    int marge = 20; // Marge en mm de distance de detection à l'exterieur de la table (pour ne pas jeter les mesures de la bordure qui ne collent pas parfaitement)
                    if (!limitOnTable || (pos.X > -marge && pos.X < Plateau.Largeur + marge && pos.Y > -marge && pos.Y < Plateau.Hauteur + marge))
                        positions.Add(pos);
                }
            }

            return positions;
        }

        private List<int> DecodeMessage(String message)
        {
            List<int> values = new List<int>();

            String[] tab = message.Split(new char[] { '\n' });
            Boolean started = false;

            for (int i = 0; i < tab.Length - 2; i++)
            {
                if (tab[i].Length > 64) started = true;

                if (started)
                {
                    for (int j = 0; j < tab[i].Length - 1; j += 2)
                    {
                        int val = DecodeValue(tab[i].Substring(j, 2));
                        values.Add(val);
                    }
                }
            }

            if (values.Count >= _romTotalMeasures)
                values = values.GetRange(_keepFrom, _keepTo - _keepFrom);

            if (_invertRotation)
                values.Reverse();

            return values;
        }

        private int DecodeValue(String data)
        {
            int value = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                value <<= 6;
                value &= ~0x3f;
                value |= data[i] - 0x30;
            }
            return value;
        }

        #endregion
    }
}
