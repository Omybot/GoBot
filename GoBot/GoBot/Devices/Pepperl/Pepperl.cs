using Geometry;
using Geometry.Shapes;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using GoBot.BoardContext;
using System.Threading;

namespace GoBot.Devices
{
    class Pepperl : Lidar
    {
        IPAddress _ip;
        PepperlManager _manager;

        PepperlFreq _freq;
        PepperlFilter _filter;
        int _filterWidth;

        ThreadLink _feedLink;

        List<RealPoint> _lastMeasure;
        Mutex _lockMeasure;

        public Pepperl(IPAddress ip)
        {
            _ip = ip;
            _manager = new PepperlManager(ip, 32123);
            _manager.NewMeasure += _manager_NewMeasure;
            _freq = PepperlFreq.Hz35;
            _filter = PepperlFilter.None;
            _filterWidth = 2;

            _checker.SendConnectionTest += _checker_SendConnectionTest;
        }

        private void _checker_SendConnectionTest(Communications.Connection sender)
        {
            if (!_checker.Connected && _started)
            {
                // On est censés être connectés mais en fait non, donc on essaie de relancer
                lock (this)
                {
                    // TODO : ou pas... ça déconne on dirait
                    //StopLoop();
                    //StartLoop();
                }
            }
        }
        public override AngleDelta DeadAngle => 0;

        public override bool Activated => _feedLink != null && _feedLink.Running;

        public int PointsPerScan { get { return _freq.SamplesPerScan() / (_filter == PepperlFilter.None ? 1 : _filterWidth); } }

        public AngleDelta Resolution { get { return new AngleDelta(new AngleDelta(360).InRadians / PointsPerScan, AngleType.Radian); } }

        public PepperlFreq Frequency { get { return _freq; } }
        public PepperlFilter Filter { get { return _filter; } }
        public int FilterWidth { get { return _filterWidth; } }

        public double PointsDistanceAt(double distance)
        {
            return distance * Resolution.InRadians;
        }

        private void _manager_NewMeasure(List<PepperlManager.PepperlPoint> measure, Geometry.AnglePosition startAngle, Geometry.AngleDelta resolution)
        {
            List<RealPoint> points = ValuesToPositions(measure.Select(p => p.distance).ToList(), startAngle, resolution, false, 0, 5000, _position);
            _lastMeasure = new List<RealPoint>(points);
            _lockMeasure?.ReleaseMutex();

            OnNewMeasure(points);
        }

        public void ShowMessage(String txt1, String txt2)
        {
            _manager.ShowMessage(txt1, txt2);
        }

        public void SetFrequency(PepperlFreq freq)
        {
            _freq = freq;
            _manager.SetFrequency(freq);
        }

        public void SetFilter(PepperlFilter filter, int size)
        {
            _filter = filter;
            _filterWidth = size;
            _manager.SetFilter(_filter, _filterWidth);
        }

        protected override bool StartLoop()
        {
            bool ok;

            if (_manager.CreateChannelUDP())
            {
                _feedLink = ThreadManager.CreateThread(link => FeedWatchDog());
                _feedLink.Name = "R2000 Watchdog";
                _feedLink.StartInfiniteLoop(1000);
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        protected override void StopLoop()
        {
            if (_feedLink != null)
            {
                _manager.CloseChannelUDP();
                _feedLink.Cancel();
                _feedLink.WaitEnd();
                _feedLink = null;
            }
        }

        public void Reboot()
        {
            _manager.Reboot();
        }

        public AngleDelta ScanRange { get { return 360; } }

        private List<RealPoint> ValuesToPositions(List<uint> measures, AnglePosition startAngle, AngleDelta resolution, bool limitOnTable, int minDistance, int maxDistance, Position refPosition)
        {
            List<RealPoint> positions = new List<RealPoint>();

            for (int i = 0; i < measures.Count; i++)
            {
                AnglePosition angle = resolution * i;

                if (measures[i] > minDistance && (measures[i] < maxDistance || maxDistance == -1))
                {
                    AnglePosition anglePoint = new AnglePosition(angle.InPositiveRadians - refPosition.Angle.InPositiveRadians - ScanRange.InRadians / 2 - Math.PI / 2, AngleType.Radian);

                    RealPoint pos = new RealPoint(refPosition.Coordinates.X - anglePoint.Sin * measures[i], refPosition.Coordinates.Y - anglePoint.Cos * measures[i]);

                    int marge = 20; // Marge en mm de distance de detection à l'exterieur de la table (pour ne pas jeter les mesures de la bordure qui ne collent pas parfaitement)
                    if (!limitOnTable || (pos.X > -marge && pos.X < GameBoard.Width + marge && pos.Y > -marge && pos.Y < GameBoard.Height + marge))
                        positions.Add(pos);
                }
            }

            return positions;
        }

        private void FeedWatchDog()
        {
            _manager.FeedWatchDog();
        }

        public override List<RealPoint> GetPoints()
        {
            _lockMeasure = new Mutex();
            _lockMeasure.WaitOne();
            _lockMeasure.Dispose();
            _lockMeasure = null;

            return new List<RealPoint>(_lastMeasure);
        }
    }
}
