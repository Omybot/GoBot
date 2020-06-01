using Geometry;
using Geometry.Shapes;
using GoBot.BoardContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    class LidarSimu : Lidar
    {
        private List<double> _distances;
        private Threading.ThreadLink _link;
        private AngleDelta _scanRange;
        private int _pointsCount;
        private double _noise;
        private Random _rand;

        public LidarSimu() : base()
        {
            _distances = Enumerable.Repeat(1500d, 360 * 3).ToList();
            _scanRange = 360;
            _pointsCount = 360 * 3;
            _noise = 5;
            _rand = new Random();
        }

        protected override bool StartLoop()
        {
            _link = Threading.ThreadManager.CreateThread(link => UpdateDetection());
            _link.StartInfiniteLoop(50);

            return true;
        }

        protected override void StopLoop()
        {
            _link.Cancel();
            _link.WaitEnd();
            _link = null;
        }

        protected void UpdateDetection()
        {
            //List<RealPoint> measures = ValuesToPositions(_distances, false, 50, 5000, _position);
            List<RealPoint> measures = Detection(_position);
            this.OnNewMeasure(measures);

            Random r = new Random();
            for (int i = 0; i < _distances.Count; i++)
                _distances[i] = (_distances[(i - 1 + _distances.Count) % _distances.Count] + _distances[i] + _distances[(i + 1) % _distances.Count]) / 3 + r.NextDouble() * 3 - 1.5;
        }

        private List<RealPoint> ValuesToPositions(List<double> measures, bool limitOnTable, int minDistance, int maxDistance, Position refPosition)
        {
            List<RealPoint> positions = new List<RealPoint>();
            AngleDelta resolution = _scanRange / _pointsCount;

            for (int i = 0; i < measures.Count; i++)
            {
                AnglePosition angle = resolution * i;

                if (measures[i] > minDistance && (measures[i] < maxDistance || maxDistance == -1))
                {
                    AnglePosition anglePoint = new AnglePosition(angle.InPositiveRadians - refPosition.Angle.InPositiveRadians - _scanRange.InRadians / 2 - Math.PI / 2, AngleType.Radian);

                    RealPoint pos = new RealPoint(refPosition.Coordinates.X - anglePoint.Sin * measures[i], refPosition.Coordinates.Y - anglePoint.Cos * measures[i]);

                    int marge = 20; // Marge en mm de distance de detection à l'exterieur de la table (pour ne pas jeter les mesures de la bordure qui ne collent pas parfaitement)
                    if (!limitOnTable || (pos.X > -marge && pos.X < GameBoard.Width + marge && pos.Y > -marge && pos.Y < GameBoard.Height + marge))
                        positions.Add(pos);
                }
            }

            return positions;
        }

        private List<RealPoint> Detection(Position refPosition)
        {
            List<RealPoint> positions = new List<RealPoint>();
            AngleDelta resolution = _scanRange / _pointsCount;
            int dist = 10000;

            List<IShape> obstacles = new List<IShape>();
            obstacles.AddRange(GameBoard.ObstaclesLidarGround);

            for (int i = 0; i < _pointsCount; i++)
            {
                AnglePosition angle = resolution * i;

                AnglePosition anglePoint = new AnglePosition(angle.InPositiveRadians - refPosition.Angle.InPositiveRadians - _scanRange.InRadians / 2 - Math.PI / 2, AngleType.Radian);

                RealPoint pos = new RealPoint(refPosition.Coordinates.X - anglePoint.Sin * dist, refPosition.Coordinates.Y - anglePoint.Cos * dist);

                positions.Add(GetDetectionLinePoint(new Segment(refPosition.Coordinates, pos), obstacles));

            }

            return positions;
        }

        private RealPoint GetDetectionLinePoint(Segment seg, IEnumerable<IShape> obstacles)
        {
            RealPoint closest = null;
            double minDistance = double.MaxValue;

            foreach (IShape s in obstacles)
            {
                List<RealPoint> pts = s.GetCrossingPoints(seg);
                foreach (RealPoint p in pts)
                {
                    double newDistance = seg.StartPoint.Distance(p);
                    if (newDistance < minDistance)
                    {
                        minDistance = newDistance;
                        closest = p;
                    }
                }
            }

            Direction d = Maths.GetDirection(seg.StartPoint, closest);
            d.distance += (_rand.NextDouble() * _noise * 2 - _noise);
            closest = Maths.GetDestination(seg.StartPoint, d);

            return closest;
        }
    }
}
