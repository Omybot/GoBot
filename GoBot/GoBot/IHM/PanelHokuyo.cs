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
        private List<PointReel> _lastMeasure;

        public PanelHokuyo()
        {
            InitializeComponent();
            _lastMeasure = null;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!picWorld.RectangleToScreen(picWorld.ClientRectangle).Contains(MousePosition))
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
                _lastMeasure = Actionneur.Hokuyo.GetRawMesure();

                picWorld.Invalidate();
            }
        }

        private void PanelHokuyo_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                trackZoom.SetValue(1);
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

        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            picWorld.Dimensions.SetZoomFactor(trackZoom.Value);
        }

        private void picWorld_WorldChange()
        {
            picWorld.Invalidate();
        }

        private void picWorld_Paint(object sender, PaintEventArgs e)
        {
            List<PointReel> points = _lastMeasure;
            Graphics g = e.Graphics;

            if (picWorld.Width > 0 && picWorld.Height > 0)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.DrawRectangle(Pens.Gray, 0, 0, picWorld.Width - 1, picWorld.Height - 1);


                if (boxScale.Checked)
                {
                    for (int i = 100; i < 5000; i += 100)
                    {
                        new Cercle(new PointReel(), i).Paint(g, Color.Gray, picWorld.Dimensions.WorldScale.Factor < 1 ? 2 : 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                    }

                    if(picWorld.Dimensions.WorldScale.Factor < 1)
                    {
                        for (int i = 10; i < 5000; i += 10)
                        {
                            if (i % 100 != 0)
                            {
                                new Cercle(new PointReel(), i).Paint(g, Color.LightGray, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                            }
                        }
                    }
                }

                if (points?.Count > 0)
                {
                    if (rdoOutline.Checked)
                    {
                        points.Add(new PointReel());
                        Polygone poly = new Polygone(points);
                        points.RemoveAt(points.Count - 1);
                        poly.Paint(g, Color.Red, 1, Color.LightGray, picWorld.Dimensions.WorldScale);
                    }
                    else if (rdoShadows.Checked)
                    {
                        points.Add(new PointReel());
                        Polygone poly = new Polygone(points);
                        points.RemoveAt(points.Count - 1);
                        g.FillRectangle(Brushes.LightGray, 0, 0, picWorld.Width, picWorld.Height);
                        poly.Paint(g, Color.Red, 1, Color.White, picWorld.Dimensions.WorldScale);
                    }
                    else if (rdoObjects.Checked)
                    {
                        foreach (PointReel p in points)
                        {
                            p.Paint(g, Color.Black, 3, Color.Red, picWorld.Dimensions.WorldScale);
                        }
                    }
                    else
                    {
                        foreach (PointReel p in points)
                        {
                            Segment s = new Segment(new PointReel(), p);
                            s.Paint(g, Color.Red, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                        }
                    }

                    if (boxGroup.Checked)
                    {
                        List<List<PointReel>> groups = points.GroupByDistance(50);
                        for (int i = 0; i < groups.Count; i++)
                        {
                            Cercle circle = groups[i].GetContainingCircle();
                            circle.Paint(g, Color.Black, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                            g.DrawString((circle.Rayon * 2).ToString("0"), new Font("Calibri", 9), Brushes.Black, picWorld.Dimensions.WorldScale.RealToScreenPosition(circle.Centre.Translation(circle.Rayon, 0)));
                        }
                    }
                }
            }
        }

        private void picWorld_MouseMove(object sender, MouseEventArgs e)
        {
            lblMousePosition.Text = picWorld.Dimensions.WorldScale.ScreenToRealPosition(e.Location).ToString();
        }
    }
}
