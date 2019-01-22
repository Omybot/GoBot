using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Utils
{
    class DetectionAnalyzer
    {
        private List<IShape> _obstacles;
        private IShape _bounds;
        private double _precision;

        public DetectionAnalyzer()
        {
            _obstacles = new List<IShape>();
            _bounds = new PolygonRectangle(new RealPoint(0, 0), 3000, 2000);
            _precision = 10;
        }

        public List<RealPoint> KeepInsideBounds(List<RealPoint> detection)
        {
            return detection.GetPointsInside(_bounds).ToList();
        }

        public List<RealPoint> RemoveObstacles(List<RealPoint> detection)
        {
            return detection.Where(o => _obstacles.Min(s => s.Distance(o)) < _precision).ToList();
        }
    }
}
