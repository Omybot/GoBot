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
        private List<Color> _loadOnRed;
        private List<Color> _loadOnGreen;

        public RandomDropOff(RealPoint position, Color color) : base(position, color, 200)
        {
            _loads = new List<List<Color>>();
        }

        public int LoadsCount => _loads.Count;

        public override void Paint(Graphics g, WorldScale scale)
        {
            base.Paint(g, scale);
            double x = (Owner == GameBoard.ColorLeftBlue ? 55 : 3000 - 55);
            double dx = (Owner == GameBoard.ColorLeftBlue ? 85 : -85);

            for (int i = 0; i < _loads.Count; i++)
                for (int j = 0; j < _loads[i].Count; j++)
                    new Circle(new RealPoint(x + dx * i, _position.Y - (j - 2) * 75), 36).Paint(g, Color.Black, 1, _loads[i][j], scale);

            x = _position.X + (Owner == GameBoard.ColorLeftBlue ? -100 : 100);
            dx = (Owner == GameBoard.ColorLeftBlue ? 85 : -85);

            if (_loadOnGreen != null)
                for (int j = 0; j < _loadOnGreen.Count; j++)
                    new Circle(new RealPoint(x + dx * j, _position.Y -260), 36).Paint(g, Color.Black, 1, _loadOnGreen[j], scale);
        }

        public void AddLoad(List<Color> load)
        {
            load = new List<Color>(load);

            if (Owner == GameBoard.ColorLeftBlue)
                load.Reverse();

            _loads.Add(load);
        }
    }
}
