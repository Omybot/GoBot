using Geometry;
using Geometry.Shapes;
using GoBot.Movements;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GoBot.GameElements
{
    public abstract class GameElement
    {
        protected RealPoint position;
        protected bool isAvailable;
        protected bool isHover;
        protected int hoverRadius;
        protected Color color;

        /// <summary>
        /// Obtient ou définit si l'élement de jeu est parti et donc n'est plus disponible
        /// </summary>
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        /// <summary>
        /// Obtient ou définir la couleur de l'action (joueur propriétaire ou blanc)
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Position du centre de l'action
        /// </summary>
        public RealPoint Position
        {
            get { return position; }
            set { position = value; }
        }
        
        /// <summary>
        /// Obtient ou définit si l'action est actuellement survolée par la souris
        /// </summary>
        public bool IsHover
        {
            get { return isHover; }
            set { isHover = value; }
        }
        
        /// <summary>
        /// Obtient ou définit le rayon du srvol de la souris
        /// </summary>
        public int HoverRadius
        {
            get { return hoverRadius; }
            set { hoverRadius = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="position">Position de l'élément</param>
        /// <param name="color">Couleur d'appartenance de l'élément</param>
        /// <param name="hoverRadius">Rayon de survol de l'élément</param>
        public GameElement(RealPoint position, Color color, int hoverRadius)
        {
            this.hoverRadius = hoverRadius;
            this.position = position;
            this.color = color;
            this.isAvailable = true;
        }

        /// <summary>
        /// Peint l'élément sur le Graphic donné à l'échelle donnée
        /// </summary>
        /// <param name="g">Graphic sur lequel peindre</param>
        /// <param name="scale">Echelle de peinture</param>
        public abstract void Paint(Graphics g, WorldScale scale);

        /// <summary>
        /// Action à executer au clic de la souris
        /// </summary>
        /// <returns>Vrai si l'éction a été correctement executée</returns>
        public virtual bool ClickAction()
        {
            IEnumerable<Movement> movements = Plateau.Strategy.Movements.Where(m => m.Element == this);

            if(movements.Count() > 0)
            {
                Movement move = movements.OrderBy(m => m.GlobalCost).First();
                return move.Execute();
            }

            return false;
        }
    }
}
