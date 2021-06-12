using Geometry;
using Geometry.Shapes;
using GoBot.BoardContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.GameElements
{
    public class RandomDropOff : GameElementZone
    {
        private List<List<Color>> _loads;
        private List<Color> _loadOnTop;
        private List<Color> _loadOnBottom;

        public RandomDropOff(RealPoint position, Color color) : base(position, color, 200)
        {
            _loads = new List<List<Color>>();

            _loadOnTop = null;
            _loadOnBottom = null;
        }

        public int LoadsCount => _loads.Count;
        public bool HasLoadOnTop => _loadOnTop != null;
        public bool HasLoadOnBottom => _loadOnBottom != null;

        public override void Paint(Graphics g, WorldScale scale)
        {
            base.Paint(g, scale);
            double x = (Owner == GameBoard.ColorLeftBlue ? 55 : 3000 - 55);
            double dx = (Owner == GameBoard.ColorLeftBlue ? 85 : -85);

            for (int i = 0; i < _loads.Count; i++)
                for (int j = 0; j < _loads[i].Count; j++)
                    new Circle(new RealPoint(x + dx * i, _position.Y - (j - 2) * 75), 36).Paint(g, Color.Black, 1, _loads[i][j], scale);

            x = _position.X + (Owner == GameBoard.ColorLeftBlue ? -130 : 130);
            dx = (Owner == GameBoard.ColorLeftBlue ? 85 : -85);

            if (_loadOnTop != null)
                for (int j = 0; j < _loadOnTop.Count; j++)
                    new Circle(new RealPoint(x + dx * j, _position.Y - 280), 36).Paint(g, Color.Black, 1, _loadOnTop[j], scale);

            if (_loadOnBottom != null)
                for (int j = 0; j < _loadOnBottom.Count; j++)
                    new Circle(new RealPoint(x + dx * j, _position.Y + 280), 36).Paint(g, Color.Black, 1, _loadOnBottom[j], scale);
        }

        public void AddLoad(List<Color> load)
        {
            if (load != null)
            {
                load = new List<Color>(load);

                if (Owner == GameBoard.ColorLeftBlue)
                    load.Reverse();

                _loads.Add(load);
            }
        }

        public void SetLoadTop(List<Color> load)
        {
            _loadOnTop = new List<Color>(load);
        }

        public void SetLoadBottom(List<Color> load)
        {
            _loadOnBottom = new List<Color>(load);
            _loadOnBottom.Reverse();
        }
    }
}
