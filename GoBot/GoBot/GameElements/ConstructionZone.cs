using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBot.GameElements
{
    public class ConstructionZone : GameElementZone
    {
        private List<CubesTower> towers;
        private RealPoint nextTowerPosition;
        private double interTowerSpace;

        public ConstructionZone(RealPoint position, Color owner) : base(position, owner, 80)
        {
            this.interTowerSpace = 75;
            this.nextTowerPosition = position.Translation(-interTowerSpace, 0);
            towers = new List<CubesTower>();
        }

        public int TowersCount => towers.Count;

        public void AddTower(CubesTower tower)
        {
            tower.Position = nextTowerPosition;
            nextTowerPosition = nextTowerPosition.Translation(interTowerSpace, 0);
            towers.Add(tower);
        }

        public override bool ClickAction()
        {
            Movements.MovementBuilding move = new Movements.MovementBuilding(this);

            return move.Execute();
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            base.Paint(g, scale);

            foreach (CubesTower tower in towers)
                tower.Paint(g, scale);
        }
    }
}
