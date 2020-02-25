using System;
using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// Détermine la couleur actuellement affichée
        /// </summary>
        /// <param name="color">Couleur affichée</param>
        public void SetColor(Color c)
        {
            this.InvokeAuto(() =>
            {
                ColorPlus color = c;
                lblR.Text = color.Red.ToString();
                lblG.Text = color.Green.ToString();
                lblB.Text = color.Blue.ToString();

                lblH.Text = ((int)(color.Hue)).ToString();
                lblS.Text = ((int)(color.Saturation * 255)).ToString();
                lblL.Text = ((int)(color.Lightness * 255)).ToString();

                picColor.Image = MakeColorZone(picColor.Size, color);

                picR.Image = MakeColorBar(picR.Size, Color.Red, color.Red);
                picG.Image = MakeColorBar(picG.Size, Color.FromArgb(44, 208, 0), color.Green);
                picB.Image = MakeColorBar(picB.Size, Color.FromArgb(10, 104, 199), color.Blue);

                picH.Image = MakeColorBarRainbow(picR.Size, color.Hue);
                picS.Image = MakeColorBar2(picG.Size, ColorPlus.FromHsl(color.Hue, 0, 0.5), ColorPlus.FromHsl(color.Hue, 1, 0.5), (int)(color.Saturation * 255));
                picL.Image = MakeColorBar2(picB.Size, ColorPlus.FromHsl(color.Hue, 1, 0), ColorPlus.FromHsl(color.Hue, 1, 1), (int)(color.Lightness * 255));
            });
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

        private Image MakeColorBar2(Size sz, ColorPlus colorBottom, ColorPlus colorTop, float value)
        {
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, bmp.Height), new Point(0, 0), colorBottom, colorTop);

            int margin = 2;
            int height = (int)(sz.Height - margin * 2);
            Rectangle rect = new Rectangle(margin, sz.Height - margin - height, sz.Width - margin * 2, height);

            GraphicsPath path = CreateMixRect(rect, new List<int> { Math.Min(2, height), Math.Min(2, height), Math.Min(2, height), Math.Min(2, height) });

            g.FillPath(brush, path);
            g.DrawPath(Pens.Black, path);

            height = (int)((sz.Height - margin * 2 - 2) * (1 - value / 255.0)) + 2;
            g.DrawLine(Pens.Black, 0, height - 1, bmp.Width, height - 1);
            g.DrawLine(Pens.White, 0, height, bmp.Width, height);
            g.DrawLine(Pens.Black, 0, height + 1, bmp.Width, height + 1);

            brush.Dispose();

            return bmp;
        }

        private Image MakeColorBarRainbow(Size sz, double hue)
        {
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int margin = 2;
            int totalHeight = (int)(sz.Height - margin * 2);
            Rectangle rect = new Rectangle(margin, sz.Height - margin - totalHeight, sz.Width - margin * 2, totalHeight);

            GraphicsPath path = CreateMixRect(rect, new List<int> { Math.Min(2, totalHeight), Math.Min(2, totalHeight), Math.Min(2, totalHeight), Math.Min(2, totalHeight) });

            int height = (int)((sz.Height - margin * 2 - 2) * (1 - hue / 360)) + 2;
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, height + totalHeight/2), new Point(0, height + totalHeight + totalHeight / 2), Color.White, Color.Black);

            ColorBlend colors = new ColorBlend(7);
            colors.Colors = new Color[] { Color.Red, Color.Yellow, Color.Lime, Color.Cyan, Color.Blue, Color.Magenta, Color.Red };
            colors.Positions = new float[] { 0 / 6f, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 6 / 6f };

            brush.InterpolationColors = colors;

            g.FillPath(brush, path);
            g.DrawPath(Pens.Black, path);

            height = (int)(sz.Height /2);

            g.DrawLine(Pens.Black, 0, height - 1, bmp.Width, height - 1);
            g.DrawLine(Pens.White, 0, height, bmp.Width, height);
            g.DrawLine(Pens.Black, 0, height + 1, bmp.Width, height + 1);

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
