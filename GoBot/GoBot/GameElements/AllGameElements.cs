using System.Collections.Generic;
using System.Linq;
using System.Collections;
using GoBot.BoardContext;

using Geometry.Shapes;

namespace GoBot.GameElements
{
    public class AllGameElements : IEnumerable<GameElement>
    {
        public delegate void ObstaclesChangedDelegate();
        public event ObstaclesChangedDelegate ObstaclesChanged;
        
        public AllGameElements()
        {
            // TODOEACHYEAR Ajouter ici tous les éléments dans les listes
        }

        public IEnumerable<GameElement> AllElements
        {
            get
            {
                IEnumerable<GameElement> elements = Enumerable.Empty<GameElement>();

                // TODOEACHYEAR Concaténer ici les listes d'éléments

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

        public void SetOpponents(List<RealPoint> positions)
        {
            // TODOEACHYEAR Mettre à jour ICI les éléments en fonction de la position des adversaires

            int opponentRadius = 150;
        }
    }
}
