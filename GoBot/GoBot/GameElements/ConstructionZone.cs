using GoBot.Geometry.Shapes;
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

        public ConstructionZone(RealPoint position, Color owner, double interTowerSpace) : base(position, owner, 80)
        {
            this.nextTowerPosition = position.Translation(-(interTowerSpace / Math.Abs(interTowerSpace)) * 220, 20);
            this.interTowerSpace = interTowerSpace;
            towers = new List<CubesTower>();
        }

        public void AddTower(CubesTower tower)
        {
            tower.Position = nextTowerPosition;
            nextTowerPosition = nextTowerPosition.Translation(interTowerSpace + (interTowerSpace / Math.Abs(interTowerSpace)) * CubesCross.KCubeSize, 0);
            towers.Add(tower);
        }

        public override bool ClickAction()
        {
            CubesTower t1 = new CubesTower(new RealPoint());
            t1.AddCube(CubesCross.CubeColor.Black);
            t1.AddCube(CubesCross.CubeColor.Blue);
            t1.AddCube(CubesCross.CubeColor.Green);
            t1.AddCube(CubesCross.CubeColor.Joker);
            t1.AddCube(CubesCross.CubeColor.Orange);

            AddTower(t1);

            return true;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            base.Paint(g, scale);

            foreach (CubesTower tower in towers)
                tower.Paint(g, scale);
        }
    }
}
