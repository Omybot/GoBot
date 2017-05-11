using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Composants
{
    public partial class ColorDisplay : UserControl
    {
        public ColorDisplay()
        {
            InitializeComponent();
        }

        public void SetColor(Color color)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    SetColor(color);
                }));
            }
            else
            {
                lblR.Text = color.R.ToString();
                lblG.Text = color.G.ToString();
                lblB.Text = color.B.ToString();

                picColor.Image = MakeColorZone(picColor.Size, color);

                picR.Image = MakeColorBar(picR.Size, Color.Red, color.R);
                picG.Image = MakeColorBar(picG.Size, Color.FromArgb(44, 208, 0), color.G);
                picB.Image = MakeColorBar(picB.Size, Color.FromArgb(10, 104, 199), color.B);
            }
        }

        private Image MakeColorZone(Size sz, Color color)
        {
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush brush = new SolidBrush(color);

            int margin = 2;

            g.FillEllipse(brush, new Rectangle(margin, margin, sz.Width - margin * 2, sz.Height - margin * 2));
            g.DrawEllipse(Pens.Black, new Rectangle(margin, margin, sz.Width - margin * 2, sz.Height - margin * 2));

            brush.Dispose();

            return bmp;
        }

        private Image MakeColorBar(Size sz, Color color, int value)
        {
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush brush = new SolidBrush(color);

            int margin = 2;
            int height = (int)((sz.Height - margin * 2) * value / 255.0);
            Rectangle rect = new Rectangle(margin, sz.Height - margin - height, sz.Width - margin * 2, height);

            GraphicsPath path = CreateMixRect(rect, new List<int> { Math.Min(5, height), Math.Min(5, height), 0, 0 });

            g.FillPath(brush, path);
            g.DrawPath(Pens.Black, path);

            brush.Dispose();

            return bmp;
        }

        private GraphicsPath CreateMixRect(Rectangle rct, List<int> rays)
        {
            GraphicsPath pth = new GraphicsPath();
            int dd = 1;
            
            if (rays[0] > 0)
                pth.AddArc(rct.X, rct.Y, rays[0] * 2, rays[0] * 2, 180, 90);

            pth.AddLine(rct.X + rays[0], rct.Y, rct.Right - dd - rays[1], rct.Y);

            if ((rays[1] > 0))
                pth.AddArc(rct.Right - dd - 2 * rays[1], rct.Y, rays[1] * 2, rays[1] * 2, 270, 90);

            pth.AddLine(rct.Right - dd, rct.Y + rays[1], rct.Right - dd, rct.Bottom - dd - rays[2]);

            if ((rays[2] > 0))
                pth.AddArc(rct.Right - dd - 2 * rays[2], rct.Bottom - dd - 2 * rays[2], rays[2] * 2, rays[2] * 2, 0, 90);

            pth.AddLine(rct.Right - dd - rays[2], rct.Bottom - dd, rct.X + rays[3], rct.Bottom - dd);

            if ((rays[3] > 0))
                pth.AddArc(rct.X, rct.Bottom - dd - 2 * rays[3], rays[3] * 2, rays[3] * 2, 90, 90);

            pth.AddLine(rct.X, rct.Bottom - dd - rays[3], rct.X, rct.Y + rays[0]);

            pth.CloseFigure();

            return pth;
            
        }
    }
}
