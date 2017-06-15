using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelHokuyo : UserControl
    {
        public PanelHokuyo()
        {
            InitializeComponent();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!picDraw.RectangleToScreen(picDraw.ClientRectangle).Contains(MousePosition))
            {
                base.OnMouseWheel(e);
            }
            else
            {
                if (e.Delta > 0)
                    trackZoom.SetValue(trackZoom.Value * 0.90, true);
                else
                    trackZoom.SetValue(trackZoom.Value * 1.1, true);
            }
        }

        private void switchEnable_ChangementEtat(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(f => ThreadHokuyo());
        }

        private void ThreadHokuyo()
        {
            while (true)
            {
                List<PointReel> points = Actionneur.Hokuyo.GetRawMesure();
                List<Color> colors = new List<Color>();
                colors.Add(Color.Red);
                colors.Add(Color.Blue);
                colors.Add(Color.Green);
                colors.Add(Color.Pink);
                colors.Add(Color.Orange);
                colors.Add(Color.Purple);
                colors.Add(Color.White);

                if (points.Count > 0)
                {
                    Bitmap bmp = new Bitmap(picDraw.Width, picDraw.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    PaintScale scale = new PaintScale(trackZoom.Value / bmp.Height, bmp.Width / 2, bmp.Height / 2);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    g.DrawRectangle(Pens.Gray, 0, 0, bmp.Width - 1, bmp.Height - 1);
                    
                    if (boxScale.Checked)
                    {
                        for (int i = 100; i < 5000; i += 100)
                        {
                            new Cercle(new PointReel(), i).Paint(g, Color.Gray, 1, Color.Transparent, scale);
                        }
                    }

                    if (rdoOutline.Checked)
                    {
                        points.Add(new PointReel());
                        Polygone poly = new Polygone(points);
                        points.RemoveAt(points.Count - 1);
                        poly.Paint(g, Color.Red, 1, Color.LightGray, scale);
                    }
                    else if (rdoShadows.Checked)
                    {
                        points.Add(new PointReel());
                        Polygone poly = new Polygone(points);
                        points.RemoveAt(points.Count - 1);
                        g.FillRectangle(Brushes.LightGray, 0, 0, bmp.Width, bmp.Height);
                        poly.Paint(g, Color.Red, 1, Color.White, scale);
                    }
                    else if (rdoObjects.Checked)
                    {
                            foreach (PointReel p in points)
                            {
                                p.Paint(g, Color.Black, 3, Color.Red, scale);
                            }
                    }
                    else
                    {
                        foreach (PointReel p in points)
                        {
                            Segment s = new Segment(new PointReel(), p);
                            s.Paint(g, Color.Red, 1, Color.Transparent, scale);
                        }
                    }

                    if (boxGroup.Checked)
                    {
                        List<List<PointReel>> groups = points.GroupByDistance(50);
                        for (int i = 0; i < groups.Count; i++)
                        {
                            Cercle circle = groups[i].GetContainingCircle();
                            circle.Paint(g, Color.Black, 1, Color.Transparent, scale);
                            g.DrawString((circle.Rayon * 2).ToString("0"), new Font("Calibri", 9), Brushes.Black, scale.RealToScreenPosition(circle.Centre.Translation(circle.Rayon, 0)));
                        }
                    }
                    
                    picDraw.InvokeAuto(() => picDraw.Image = bmp);
                }
            }
        }

        private void PanelHokuyo_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                trackZoom.SetValue(1000);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            List<Cercle> cercles;
            do
            {
                List<PointReel> points = Actionneur.Hokuyo.GetRawMesure();

                List<List<PointReel>> groups = points.GroupByDistance(50);

                cercles = groups.Select(g => g.GetContainingCircle()).ToList();
                cercles = cercles.Where(c => c.Rayon > 20 && c.Rayon < 40).ToList();
            } while (cercles.Count == 0);

            PointReel nearest = cercles.OrderBy(c => c.Distance(new PointReel())).ToList()[0].Centre;

            Plateau.ObstaclesPlateau.Clear();
            Actionneur.GestionModuleSupervisee.AttraperModule(nearest);
        }
    }
}
