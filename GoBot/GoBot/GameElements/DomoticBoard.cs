using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.Geometry.Shapes;

namespace GoBot.GameElements
{
    public class DomoticBoard : GameElement
    {
        public DomoticBoard(RealPoint position, Color color) : base(position, color, 60)
        {
        }

        public override void Paint(Graphics g, WorldScale scale)
        {
            Rectangle r = scale.RealToScreenRect(new RectangleF((float)position.X - 95, (float)position.Y - 60, 190, 120));
            
            if(isAvailable)
            {
                g.FillRectangle(Brushes.Black, r);
            }
            else
            {
                g.FillRectangle(Brushes.White, r);
                Pen pen = new Pen(Color.Black);
                pen.Width = 3;
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                g.DrawRectangle(pen, r);
                pen.Dispose();
                
                g.DrawString("Omybot", new Font("Jokerman", 8), Brushes.Red, r.X + 3, r.Y + 6);
            }

            if (isAvailable && isHover)
            {
                Pen pen = new Pen(Color.White);
                pen.Width = 3;
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                g.DrawRectangle(pen, r);
                pen.Dispose();
            }
        }

        public override bool ClickAction()
        {
            isAvailable = false;

            return base.ClickAction();
        }
    }
}
