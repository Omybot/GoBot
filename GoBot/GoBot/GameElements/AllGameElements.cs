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
        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;

        public AllGameElements()
        {
            
        }
        
        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();

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
                    // Ici ajouter à obstacles les elements à contourner
                }

                return obstacles;
            }
        }

        public void SetOpponents(List<RealPoint> positions)
        {
            // Mettre à jour ICI les éléments en fonction de la position des adversaires

            int opponentRadius = 150;
        }
    }
}
