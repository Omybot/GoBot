using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;

using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class AllGameElements : IEnumerable<GameElement>
    {
        public List<CubesCross> CubesCrosses { get; protected set; }
        public List<Distributor> Distributors { get; protected set; }
        public List<Flower> Flowers { get; protected set; }
        public List<ConstructionZone> ConstructionZones { get; protected set; }
        public List<CubesTower> CubesTowers { get; protected set; }
        public List<DomoticBoard> DomoticBoards { get; protected set; }

        private Dictionary<CubesCross, int> cubesProximityCounter;

        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;

        public AllGameElements()
        {
            CubesCrosses = new List<CubesCross>();
            CubesCrosses.Add(new CubesCross(new RealPoint(300, 1190), true));
            CubesCrosses.Add(new CubesCross(new RealPoint(850, 540), true));
            CubesCrosses.Add(new CubesCross(new RealPoint(1100, 1500), true));
            CubesCrosses.Add(new CubesCross(new RealPoint(1900, 1500), false));
            CubesCrosses.Add(new CubesCross(new RealPoint(2150, 540), false));
            CubesCrosses.Add(new CubesCross(new RealPoint(2700, 1190), false));

            Distributors = new List<Distributor>();
            Distributors.Add(new Distributor(new RealPoint(78, 840), Plateau.CouleurGaucheVert, false, 180));
            Distributors.Add(new Distributor(new RealPoint(610, 2000 - 78), Plateau.CouleurDroiteOrange, true, 90));
            Distributors.Add(new Distributor(new RealPoint(3000 - 610, 2000 - 78), Plateau.CouleurGaucheVert, true, 90));
            Distributors.Add(new Distributor(new RealPoint(3000 - 78, 840), Plateau.CouleurDroiteOrange, false, 0));

            Flowers = new List<Flower>();
            Flowers.Add(new Flower(new RealPoint(1385, 2115), Plateau.CouleurGaucheVert));
            Flowers.Add(new Flower(new RealPoint(3000 - 1385, 2115), Plateau.CouleurDroiteOrange));

            ConstructionZones = new List<ConstructionZone>();
            ConstructionZones.Add(new ConstructionZone(new RealPoint(675-130, 80), Plateau.CouleurGaucheVert));
            ConstructionZones.Add(new ConstructionZone(new RealPoint(675+150, 80), Plateau.CouleurGaucheVert));
            ConstructionZones.Add(new ConstructionZone(new RealPoint(3000 - 675 - 150, 80), Plateau.CouleurDroiteOrange));
            ConstructionZones.Add(new ConstructionZone(new RealPoint(3000 - 675 + 130, 80), Plateau.CouleurDroiteOrange));

            CubesTowers = new List<CubesTower>();

            DomoticBoards = new List<DomoticBoard>();
            DomoticBoards.Add(new DomoticBoard(new RealPoint(170, -120), Plateau.CouleurGaucheVert));
            DomoticBoards.Add(new DomoticBoard(new RealPoint(3000-170, -120), Plateau.CouleurDroiteOrange));

            cubesProximityCounter = new Dictionary<CubesCross, int>();
        }
        
        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();
                elements = elements.Concat(CubesCrosses);
                elements = elements.Concat(Distributors);
                elements = elements.Concat(Flowers);
                elements = elements.Concat(ConstructionZones);
                elements = elements.Concat(CubesTowers);
                elements = elements.Concat(DomoticBoards);

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

                if (Plateau.Strategy != null && Plateau.Strategy.AvoidElements)
                {
                    foreach (CubesCross cross in CubesCrosses)
                    {
                        if (cross.IsAvailable && cross.CubesCount > 2)
                        {
                            obstacles.Add(cross.AsObstacle);
                        }
                    }
                }

                return obstacles;
            }
        }

        public void SetOpponents(List<RealPoint> positions)
        {
            // Mettre à jour ICI les éléments en fonction de la position des adversaires

            int opRadius = 150;
            int crossRadius = 85;

            foreach (CubesCross cross in CubesCrosses)
            {
                if(cross.IsAvailable && positions.Exists(p => p.Distance(cross.Position) < opRadius + crossRadius))
                {
                    if (!cubesProximityCounter.ContainsKey(cross))
                        cubesProximityCounter.Add(cross, 0);

                    cubesProximityCounter[cross] += 3;
                }
            }

            foreach (CubesCross cross in cubesProximityCounter.Keys.ToList())
            {
                cubesProximityCounter[cross] -= 1;

                if (cubesProximityCounter[cross] <= 0)
                    cubesProximityCounter.Remove(cross);
                else if (cubesProximityCounter[cross] > 20)
                {
                    cubesProximityCounter.Remove(cross);
                    cross.IsAvailable = false;
                }
            }
        }
    }
}
