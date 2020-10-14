using System.Collections.Generic;
using System.Linq;
using System.Collections;
using GoBot.BoardContext;

using Geometry.Shapes;
using System.Drawing;

namespace GoBot.GameElements
{
    public class AllGameElements : IEnumerable<GameElement>
    {
        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;

        private List<Buoy> _buoys;

        public AllGameElements()
        {
            // TODOEACHYEAR Ajouter ici tous les éléments dans les listes
            Color red = Color.FromArgb(187, 30, 16);
            Color green = Color.FromArgb(0, 111, 61);

            _buoys = new List<Buoy>();
            _buoys.Add(new Buoy(new RealPoint(-67, 1450), GameBoard.ColorLeftBlue, red, 36));
            _buoys.Add(new Buoy(new RealPoint(-67, 1525), GameBoard.ColorLeftBlue, green, 36));
            _buoys.Add(new Buoy(new RealPoint(-67, 1600), GameBoard.ColorLeftBlue, red, 36));
            _buoys.Add(new Buoy(new RealPoint(-67, 1675), GameBoard.ColorLeftBlue, green, 36));
            _buoys.Add(new Buoy(new RealPoint(-67, 1750), GameBoard.ColorLeftBlue, red, 36));

            _buoys.Add(new Buoy(new RealPoint(300, 400), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(300, 1200), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(450, 510), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(450, 1080), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(670, 100), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(950, 400), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(1100, 800), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(1270, 1200), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(1005, 1955), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(1065, 1650), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(1335, 1650), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(1395, 1955), GameBoard.ColorNeutral, green, 36));

            _buoys.Add(new Buoy(new RealPoint(700, -67), GameBoard.ColorLeftBlue, green, 36));
            _buoys.Add(new Buoy(new RealPoint(775, -67), GameBoard.ColorLeftBlue, Color.LightGray, 36));
            _buoys.Add(new Buoy(new RealPoint(850, -67), GameBoard.ColorLeftBlue, Color.LightGray, 36));
            _buoys.Add(new Buoy(new RealPoint(925, -67), GameBoard.ColorLeftBlue, Color.LightGray, 36));
            _buoys.Add(new Buoy(new RealPoint(1000, -67), GameBoard.ColorLeftBlue, red, 36));

            _buoys.Add(new Buoy(new RealPoint(3067, 1450), GameBoard.ColorLeftBlue, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3067, 1525), GameBoard.ColorLeftBlue, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3067, 1600), GameBoard.ColorLeftBlue, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3067, 1675), GameBoard.ColorLeftBlue, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3067, 1750), GameBoard.ColorLeftBlue, green, 36));

            _buoys.Add(new Buoy(new RealPoint(3000 - 300, 400), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 300, 1200), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 450, 510), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 450, 1080), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 670, 100), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 950, 400), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1100, 800), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1270, 1200), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1005, 1955), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1065, 1650), GameBoard.ColorNeutral, red, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1335, 1650), GameBoard.ColorNeutral, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1395, 1955), GameBoard.ColorNeutral, red, 36));

            _buoys.Add(new Buoy(new RealPoint(3000 - 700, -67), GameBoard.ColorLeftBlue, green, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 775, -67), GameBoard.ColorLeftBlue, Color.LightGray, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 850, -67), GameBoard.ColorLeftBlue, Color.LightGray, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 925, -67), GameBoard.ColorLeftBlue, Color.LightGray, 36));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1000, -67), GameBoard.ColorLeftBlue, red, 36));
        }

        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();

                // TODOEACHYEAR Concaténer ici les listes d'éléments
                elements = elements.Concat(_buoys);

                return elements;
            }
        }

        public IEnumerator<GameElement> GetEnumerator()
        {
            return AllElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return AllElements.GetEnumerator();
        }

        public IEnumerable<IShape> AsObstacles
        {
            get
            {
                List<IShape> obstacles = new List<IShape>();

                if (GameBoard.Strategy != null && GameBoard.Strategy.AvoidElements)
                {
                    // TODOEACHYEAR Ici ajouter à obstacles les elements à contourner
                }

                return obstacles;
            }
        }

        public IEnumerable<IShape> AsVisibleObstacles
        {
            get
            {
                List<IShape> obstacles = new List<IShape>();

                if (GameBoard.Strategy != null && GameBoard.Strategy.AvoidElements)
                {
                    
                }

                obstacles.AddRange(_buoys.Select(b => new Circle(b.Position, b.HoverRadius)));

                return obstacles;
            }
        }

        public void SetOpponents(List<RealPoint> positions)
        {
            // TODOEACHYEAR Mettre à jour ICI les éléments en fonction de la position des adversaires

            int opponentRadius = 150;

            foreach (Buoy b in _buoys)
            {
                if (positions.Exists(p => p.Distance(b.Position) < opponentRadius))
                    b.IsAvailable = false;
            }
        }
    }
}
