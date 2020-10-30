using Geometry;
using Geometry.Shapes;
using GoBot.BoardContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GoBot.GameElements
{
    public class ColorDropOff : GameElementZone
    {
        private List<Color> _loadOnRed; // 0 = Contre la bordure ...1...2...3 = vers la table
        private List<Color> _loadOnGreen;

        private Buoy _buoyOutside1, _buoyOutside2;
        private Buoy _buoyInside1, _buoyInside2;

        private Color _pendingLeft, _pendingRight;
        private RealPoint _pendingLeftPos, _pendingRightPos;

        public ColorDropOff(RealPoint position, Color color, Buoy buoyOutside1, Buoy buoyOutside2, Buoy buoyInside1, Buoy buoyInside2) : base(position, color, 150)
        {
            _loadOnRed = Enumerable.Repeat(Color.Transparent, 5).ToList();
            _loadOnGreen = Enumerable.Repeat(Color.Transparent, 5).ToList();

            _buoyOutside1 = buoyOutside1;
            _buoyOutside2 = buoyOutside2;
            _buoyInside1 = buoyInside1;
            _buoyInside2 = buoyInside2;

            _pendingLeft = Color.Transparent;
            _pendingRight = Color.Transparent;
        }

        public int LoadsOnRed => _loadOnRed.Count(c => c != Color.Transparent);
        public int LoadsOnGreen => _loadOnGreen.Count(c => c != Color.Transparent);

        public void SetPendingLeft(Color c, RealPoint point)
        {
            _pendingLeft = c;
            _pendingLeftPos = point;
        }

        public void SetPendingRight(Color c, RealPoint point)
        {
            _pendingRight = c;
            _pendingRightPos = point;
        }

        public void RemovePending()
        {
            _pendingLeft = Color.Transparent;
            _pendingRight = Color.Transparent;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            base.Paint(g, scale);

            double x = _position.X - 110;
            double y = 2000 - 10 - 85/2;
            double dy = -85;

            if (_loadOnGreen != null)
                for (int j = 0; j < _loadOnGreen.Count; j++)
                    if (_loadOnGreen[j] != Color.Transparent)
                        new Circle(new RealPoint(x, y + dy * j), 36).Paint(g, Color.Black, 1, _loadOnGreen[j], scale);

            x = _position.X + 110;

            if (_loadOnRed != null)
                for (int j = 0; j < _loadOnRed.Count; j++)
                    if (_loadOnRed[j] != Color.Transparent)
                        new Circle(new RealPoint(x, y + dy * j), 36).Paint(g, Color.Black, 1, _loadOnRed[j], scale);

            if (_pendingLeft != Color.Transparent)
                new Circle(_pendingLeftPos, 36).Paint(g, Color.Black, 1, _pendingLeft, scale);

            if (_pendingRight != Color.Transparent)
                new Circle(_pendingRightPos, 36).Paint(g, Color.Black, 1, _pendingRight, scale);
        }

        public void SetBuoyOnRed(Color c, int level)
        {
            if (level < _loadOnRed.Count)
                _loadOnRed[level] = c;
        }

        public void SetBuoyOnGreen(Color c, int level)
        {
            if (level < _loadOnGreen.Count)
                _loadOnGreen[level] = c;
        }

        public int GetAvailableLevel()
        {
            return Math.Max(_loadOnRed.FindIndex(c => c == Color.Transparent), _loadOnGreen.FindIndex(c => c == Color.Transparent));
        }

        public bool HasInsideBuoys => _buoyInside1.IsAvailable || _buoyInside2.IsAvailable;
        public bool HasOutsideBuoys => _buoyOutside1.IsAvailable || _buoyOutside2.IsAvailable;

        public void TakeInsideBuoys()
        {
            _buoyInside1.IsAvailable = false;
            _buoyInside2.IsAvailable = false;
        }

        public void TakeOutsideBuoys()
        {
            _buoyOutside1.IsAvailable = false;
            _buoyOutside2.IsAvailable = false;
        }
    }
}
