using System.Collections.Generic;
using System.Linq;
using System.Collections;
using GoBot.BoardContext;

using Geometry.Shapes;
using System.Drawing;
using Geometry;
using System;

namespace GoBot.GameElements
{
    public class AllGameElements : IEnumerable<GameElement>
    {
        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;

        private List<Buoy> _buoys;
        private List<GroundedZone> _groundedZones;
        private List<RandomDropOff> _randomDropoff;
        private List<ColorDropOff> _colorDropoff;
        private List<LightHouse> _lightHouses;
        private GameElementZone _randomPickup;

        public AllGameElements()
        {
            // TODOEACHYEAR Ajouter ici tous les éléments dans les listes

            _buoys = new List<Buoy>();
            _buoys.Add(new Buoy(new RealPoint(-67, 1450), GameBoard.ColorLeftBlue, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(-67, 1525), GameBoard.ColorLeftBlue, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(-67, 1600), GameBoard.ColorLeftBlue, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(-67, 1675), GameBoard.ColorLeftBlue, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(-67, 1750), GameBoard.ColorLeftBlue, Buoy.Red));

            _buoys.Add(new Buoy(new RealPoint(3000 - 700, -67), GameBoard.ColorLeftBlue, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 775, -67), GameBoard.ColorLeftBlue, Color.LightGray));
            _buoys.Add(new Buoy(new RealPoint(3000 - 850, -67), GameBoard.ColorLeftBlue, Color.LightGray));
            _buoys.Add(new Buoy(new RealPoint(3000 - 925, -67), GameBoard.ColorLeftBlue, Color.LightGray));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1000, -67), GameBoard.ColorLeftBlue, Buoy.Red));

            _buoys.Add(new Buoy(new RealPoint(700, -67), GameBoard.ColorLeftBlue, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(775, -67), GameBoard.ColorLeftBlue, Color.LightGray));
            _buoys.Add(new Buoy(new RealPoint(850, -67), GameBoard.ColorLeftBlue, Color.LightGray));
            _buoys.Add(new Buoy(new RealPoint(925, -67), GameBoard.ColorLeftBlue, Color.LightGray));
            _buoys.Add(new Buoy(new RealPoint(1000, -67), GameBoard.ColorLeftBlue, Buoy.Red));

            _buoys.Add(new Buoy(new RealPoint(3067, 1450), GameBoard.ColorLeftBlue, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3067, 1525), GameBoard.ColorLeftBlue, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3067, 1600), GameBoard.ColorLeftBlue, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3067, 1675), GameBoard.ColorLeftBlue, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3067, 1750), GameBoard.ColorLeftBlue, Buoy.Green));

            _buoys.Add(new Buoy(new RealPoint(300, 400), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(300, 1200), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(450, 510), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(450, 1080), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(670, 100), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(950, 400), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(1100, 800), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(1270, 1200), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(1005, 1955), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(1065, 1650), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(1335, 1650), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(1395, 1955), GameBoard.ColorNeutral, Buoy.Green));

            _buoys.Add(new Buoy(new RealPoint(3000 - 300, 400), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 300, 1200), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3000 - 450, 510), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3000 - 450, 1080), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 670, 100), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 950, 400), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1100, 800), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1270, 1200), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1005, 1955), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1065, 1650), GameBoard.ColorNeutral, Buoy.Red));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1335, 1650), GameBoard.ColorNeutral, Buoy.Green));
            _buoys.Add(new Buoy(new RealPoint(3000 - 1395, 1955), GameBoard.ColorNeutral, Buoy.Red));

            _groundedZones = new List<GroundedZone>();
            _groundedZones.Add(new GroundedZone(new RealPoint(-70, 1600), Color.White, _buoys.GetRange(0, 5)));
            _groundedZones.Add(new GroundedZone(new RealPoint(3000 - 850, -70), Color.White, _buoys.GetRange(5, 5)));
            _groundedZones.Add(new GroundedZone(new RealPoint(850, -70), Color.White, _buoys.GetRange(10, 5)));
            _groundedZones.Add(new GroundedZone(new RealPoint(3000 + 70, 1600), Color.White, _buoys.GetRange(15, 5)));

            _randomDropoff = new List<RandomDropOff>();
            _randomDropoff.Add(new RandomDropOff(new RealPoint(200, 800), GameBoard.ColorLeftBlue));
            _randomDropoff.Add(new RandomDropOff(new RealPoint(3000 - 200, 800), GameBoard.ColorRightYellow));

            _colorDropoff = new List<ColorDropOff>();
            _colorDropoff.Add(new ColorDropOff(new RealPoint(1200, 2000 - 150), GameBoard.ColorRightYellow, 
                _buoys.Find(b => b.Position.Distance(new RealPoint(1065, 1650)) < 1),
                _buoys.Find(b => b.Position.Distance(new RealPoint(1335, 1650)) < 1),
                _buoys.Find(b => b.Position.Distance(new RealPoint(1005, 1955)) < 1),
                _buoys.Find(b => b.Position.Distance(new RealPoint(1395, 1955)) < 1)));
            _colorDropoff.Add(new ColorDropOff(new RealPoint(1800, 2000 - 150), GameBoard.ColorLeftBlue, 
                _buoys.Find(b => b.Position.Distance(new RealPoint(3000 - 1065, 1650)) < 1),
                _buoys.Find(b => b.Position.Distance(new RealPoint(3000 - 1335, 1650)) < 1),
                _buoys.Find(b => b.Position.Distance(new RealPoint(3000 - 1005, 1955)) < 1),
                _buoys.Find(b => b.Position.Distance(new RealPoint(3000 - 1395, 1955)) < 1)));

            _lightHouses = new List<LightHouse>();
            _lightHouses.Add(new LightHouse(new RealPoint(325, -122), GameBoard.ColorLeftBlue));
            _lightHouses.Add(new LightHouse(new RealPoint(3000 - 325, -122), GameBoard.ColorRightYellow));

            _randomPickup = new GameElementZone(new RealPoint(1500, 0), Color.White, 500);

            GenerateRandomBuoys();
        }

        private void GenerateRandomBuoys()
        {
            Circle zone = new Circle(new RealPoint(1500, 0),  500);
            List<Circle> randoms = new List<Circle>();

            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                RealPoint random = new RealPoint(r.Next(1000, 1500) + (i < 3 ? 0 : 500), r.Next(36, 500-36));
                Circle c = new Circle(random, 36);
                if (zone.Contains(c) && !randoms.Exists(o => random.Distance(o) < 36+2))
                {
                    _buoys.Add(new Buoy(random, Color.White, i % 2 == 0 ? Buoy.Green : Buoy.Red, true));
                    randoms.Add(c);
                }
                else
                    i -= 1;
            }
        }

        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();

                // TODOEACHYEAR Concaténer ici les listes d'éléments
                elements = elements.Concat(_buoys);
                elements = elements.Concat(_groundedZones);
                elements = elements.Concat(_randomDropoff);
                elements = elements.Concat(_colorDropoff);
                elements = elements.Concat(_lightHouses);
                elements = elements.Concat(new List<GameElement>() { _randomPickup });

                return elements;
            }
        }

        public Buoy FindBuoy(RealPoint pos)
        {
            return _buoys.OrderBy(b => b.Position.Distance(pos)).First();
        }

        public void RemoveBuoy(Buoy b)
        {
            _buoys.Remove(b);
        }

        public List<Buoy> Buoys => _buoys;
        public List<Buoy> BuoysForLeft => _buoys.Where(b => b.Position.X < 1800 && b.Position.Y < 1500 && !RandomPickup.Contains(b.Position)).ToList();
        public List<Buoy> BuoysForRight => _buoys.Where(b => b.Position.X > 1200 && b.Position.Y < 1500 && !RandomPickup.Contains(b.Position)).ToList();
        public List<GroundedZone> GroundedZones => _groundedZones;
        public List<RandomDropOff> RandomDropoffs => _randomDropoff;
        public List<ColorDropOff> ColorDropoffs => _colorDropoff;
        public List<LightHouse> LightHouses => _lightHouses;
        public GameElementZone RandomPickup => _randomPickup;

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

            //foreach (Buoy b in _buoys)
            //{
            //    if (positions.Exists(p => p.Distance(b.Position) < opponentRadius))
            //        b.IsAvailable = false;
            //}
        }
    }
}
