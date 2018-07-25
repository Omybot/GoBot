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
    public class Flower : GameElement
    {
        private DateTime explodeTime;
        
        public Flower(RealPoint position, Color owner) : base(position, owner, 80)
        {

        }

        public override bool ClickAction()
        {
            base.ClickAction();

            isAvailable = false;
            explodeTime = DateTime.Now;

            return true;
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            bool exploding = DateTime.Now - explodeTime < new TimeSpan(0, 0, 1);

            if (isAvailable)
            {
                Rectangle rct = scale.RealToScreenRect(new RectangleF((float)position.X - 150 / 2, (float)position.Y - 150 / 2, 150, 150));
                using (Brush brush = new SolidBrush(color))
                    g.FillEllipse(brush, rct);

                if (isHover)
                    g.DrawEllipse(Pens.White, rct);
                else
                    g.DrawEllipse(Pens.Black, rct);

            }

            if (exploding)
            {
                Point imageCorner = scale.RealToScreenPosition(position);
                imageCorner.X -= Properties.Resources.Explode.Width / 2;
                imageCorner.Y -= Properties.Resources.Explode.Height / 2;
                g.DrawImage(Properties.Resources.Explode, new Rectangle(imageCorner, Properties.Resources.Explode.Size));
            }
        }
    }
}
