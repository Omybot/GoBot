using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;

namespace GoBot.Devices
{
    public class Hokuyo
    {
        #region Attributs

        private LidarID _id;

        private SerialPort _port;
        private String _frameMeasure, _frameDetails;

        private String _model;
        private int _pointsCount, _pointsOffset, _maxDistance;
        private AngleDelta _scanRange;
        private Position _position;

        private Semaphore _lock;
        private TicksPerSecond _measuresTicker;
        private ThreadLink _linkMeasures;

        private List<RealPoint> _lastMeasure;

        #endregion

        #region Propriétés

        public LidarID ID { get { return _id; } }

        public String Model { get { return _model; } }

        public AngleDelta ScanRange { get { return _scanRange; } }

        public AngleDelta DeadAngle { get { return new AngleDelta(360 - _scanRange); } }

        public int PointsCount { get { return _pointsCount; } }

        public Position Position { get { return _position; } set { _position = value; } }

        public List<RealPoint> LastMeasure { get { return _lastMeasure; } }

        #endregion

        #region Constructeurs

        public Hokuyo(LidarID id, String portCom)
        {
            _id = id;
            _lock = new Semaphore(1, 1);

            _maxDistance = 3999; // En dessous de 4000 parce que le protocole choisi seuille le maximum à 4000 niveau matos

            _position = new Position();

            _lastMeasure = null;
            _measuresTicker = new TicksPerSecond();
            _measuresTicker.ValueChange += _measuresPerSecond_ValueChange;

            _port = new SerialPort(portCom, 115200);
            _port.Open();

            _frameDetails = "VV\n00P\n";

            IdentifyModel();

            _frameMeasure = "MS0000" + _pointsCount.ToString("0000") + "00001";
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
            List<RealPoint> points = new List<RealPoint>();

            _lock.WaitOne();

            Position refPosition = new Position();
            String reponse = GetMeasure();

            try
            {
                if (reponse != "")
                {
                    List<int> mesures = DecodeMessage(reponse);
                    mesures.RemoveRange(0, _pointsOffset);
                    points = ValuesToPositions(mesures, false, 150, _maxDistance, refPosition);
                }
            }
            catch (Exception) { }

            _lock.Release();

            return points;
        }

        public List<RealPoint> GetRawPoints()
        {
            List<RealPoint> points = new List<RealPoint>();

            _lock.WaitOne();

            String reponse = GetMeasure();

            try
            {
                if (reponse != "")
                {
                    List<int> mesures = DecodeMessage(reponse);
                    mesures.RemoveRange(0, _pointsOffset);
                    points = ValuesToPositions(mesures, false, 150, _maxDistance, new Position());
                }
            }
            catch (Exception) { }

            _lock.Release();

            return points;
        }

        #endregion

        #region Fonctionnement interne
        
        private void IdentifyModel()
        {
            _port.WriteLine(_frameDetails);
            String details = GetResponse();

            if (details.Contains("UBG-04LX-F01"))
            {
                // Hokuyo bleu
                _model = "UBG-04LX-F01";
                _pointsCount = 725;
                _scanRange = 240;
                _pointsOffset = 44;
            }
            else if (details.Contains("URG-04LX-UG01"))
            {
                // Petit Hokuyo
                _model = "URG-04LX-UG01";
                _pointsCount = 725;
                _scanRange = 240;
                _pointsOffset = 44;
            }
            else if (details.Contains("UTM-30LX"))
            {
                // Grand hokuyo
                _model = "UTM-30LX";
                _pointsCount = 1080;
                _scanRange = 270;
                _pointsOffset = 0;
            }
        }

        private String GetMeasure(int timeout = 500)
        {
            _port.WriteLine(_frameMeasure);
            return GetResponse(timeout);
        }

        private String GetResponse(int timeout = 500)
        {
            Stopwatch chrono = Stopwatch.StartNew();
            String reponse = "";

            do
            {
                reponse += _port.ReadExisting();
            } while (Regex.Matches(reponse, "\n\n").Count < 2 && chrono.ElapsedMilliseconds < timeout);

            if (chrono.ElapsedMilliseconds > timeout)
                return "";
            else
                return reponse;
        }

        private void DoMeasure()
        {
            _lastMeasure = GetPoints();
            if(!_linkMeasures.Cancelled) OnNewMeasure(_lastMeasure);
        }

        private List<RealPoint> ValuesToPositions(List<int> measures, bool limitOnTable, int minDistance, int maxDistance, Position refPosition)
        {
            List<RealPoint> positions = new List<RealPoint>();
            double stepAngular = ScanRange.InDegrees / (double)measures.Count;

            for (int i = 0; i < measures.Count; i++)
            {
                AnglePosition angle = stepAngular * i;

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
