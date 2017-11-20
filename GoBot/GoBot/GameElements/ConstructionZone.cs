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
        public List<List<CubesCross.CubeColor>> towers;

        public ConstructionZone(RealPoint position, Color owner) : base(position, owner, 80)
        {
            towers = new List<List<CubesCross.CubeColor>>();
        }

        public override bool ClickAction()
        {
            return true;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
        }
    }
}
