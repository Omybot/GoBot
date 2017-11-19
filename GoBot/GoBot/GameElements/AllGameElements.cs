using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;

using GoBot.Geometry.Shapes;

namespace GoBot.GameElements
{
    public class AllGameElements : IEnumerable<GameElement>
    {
        public List<CubesCross> CubesCrosses { get; protected set; }
        public List<Distributor> Distributors { get; protected set; }
        public List<Flower> Flowers { get; protected set; }

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
            Distributors.Add(new Distributor(new RealPoint(78, 840), Plateau.CouleurGaucheVert, false));
            Distributors.Add(new Distributor(new RealPoint(610, 2000 - 78), Plateau.CouleurDroiteOrange, true));
            Distributors.Add(new Distributor(new RealPoint(3000 - 610, 2000 - 78), Plateau.CouleurGaucheVert, true));
            Distributors.Add(new Distributor(new RealPoint(3000 - 78, 840), Plateau.CouleurDroiteOrange, false));

            Distributors = new List<Distributor>();
            Distributors.Add(new Distributor(new RealPoint(78, 840), Plateau.CouleurGaucheVert, false));
            Distributors.Add(new Distributor(new RealPoint(610, 2000 - 78), Plateau.CouleurDroiteOrange, true));
            Distributors.Add(new Distributor(new RealPoint(3000 - 610, 2000 - 78), Plateau.CouleurGaucheVert, true));
            Distributors.Add(new Distributor(new RealPoint(3000 - 78, 840), Plateau.CouleurDroiteOrange, false));

            Flowers = new List<Flower>();
            Flowers.Add(new Flower(new RealPoint(1385, 2115), Plateau.CouleurGaucheVert));
            Flowers.Add(new Flower(new RealPoint(3000-1385, 2115), Plateau.CouleurDroiteOrange));
        }
        
        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();
                elements = elements.Concat(CubesCrosses);
                elements = elements.Concat(Distributors);
                elements = elements.Concat(Flowers);

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
    }
}
