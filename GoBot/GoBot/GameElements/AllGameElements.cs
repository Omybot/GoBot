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
        public AllGameElements()
        {
            CubesCrosses = new List<CubesCross>();
            CubesCrosses.Add(new CubesCross(CubesCrosses.Count, new RealPoint(300, 1190), true));
            CubesCrosses.Add(new CubesCross(CubesCrosses.Count, new RealPoint(850, 540), true));
            CubesCrosses.Add(new CubesCross(CubesCrosses.Count, new RealPoint(1100, 1500), true));
            CubesCrosses.Add(new CubesCross(CubesCrosses.Count, new RealPoint(1900, 1500), false));
            CubesCrosses.Add(new CubesCross(CubesCrosses.Count, new RealPoint(2150, 540), false));
            CubesCrosses.Add(new CubesCross(CubesCrosses.Count, new RealPoint(2700, 1190), false));
        }

        public List<CubesCross> CubesCrosses { get; protected set; }
        
        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();
                elements = elements.Concat(CubesCrosses);

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
