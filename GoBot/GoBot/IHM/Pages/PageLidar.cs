using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Geometry.Shapes;
using GoBot.Devices;
using GoBot.BoardContext;

namespace GoBot.IHM.Pages
{
    public partial class PageLidar : UserControl
    {
        private Lidar _selectedLidar;
        private List<RealPoint> _lastMeasure;

        public PageLidar()
        {
            InitializeComponent();
            _lastMeasure = null;
            _selectedLidar = null;
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

        private void switchEnable_ValueChanged(object sender, bool value)
        {
            if (_selectedLidar != null)
            {
                _selectedLidar.FrequencyChange -= lidar_FrequencyChange;
                _selectedLidar.NewMeasure -= lidar_NewMeasure;
                _selectedLidar.StartLoopMeasure();
            }

            if (value)
            {
                if ((String)cboLidar.Text == "Ground")
                    _selectedLidar = AllDevices.LidarGround;
                else if ((String)cboLidar.Text == "Avoid")
                    _selectedLidar = AllDevices.LidarAvoid;
                else
                    _selectedLidar = null;

                if (_selectedLidar != null)
                {
                    _selectedLidar.FrequencyChange += lidar_FrequencyChange;
                    _selectedLidar.NewMeasure += lidar_NewMeasure;
                    _selectedLidar.StartLoopMeasure();
                }
            }
        }

        private void lidar_NewMeasure(List<RealPoint> measure)
        {
            _lastMeasure = measure;
            picWorld.Invalidate();
        }

        private void PanelLidar_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                trackZoom.SetValue(1);

                cboLidar.Items.Add("Ground");
                cboLidar.Items.Add("Avoid");
            }
        }

        private void lidar_FrequencyChange(double value)
        {
            lblMeasuresPerSecond.InvokeAuto(() => lblMeasuresPerSecond.Text = value.ToString("0.00") + " mesures/s");
        }

        private void trackZoom_ValueChanged(object sender, double value)
        {
            picWorld.Dimensions.SetZoomFactor(value);
        }

        private void picWorld_WorldChange()
        {
            picWorld.Invalidate();
        }

        private void picWorld_Paint(object sender, PaintEventArgs e)
        {
            List<RealPoint> points = _lastMeasure;
            Graphics g = e.Graphics;

            if (picWorld.Width > 0 && picWorld.Height > 0)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.DrawRectangle(Pens.Gray, 0, 0, picWorld.Width - 1, picWorld.Height - 1);


                if (boxScale.Checked)
                {
                    for (int i = 100; i < 5000; i += 100)
                    {
                        new Circle(new RealPoint(), i).Paint(g, Color.Gray, picWorld.Dimensions.WorldScale.Factor < 1 ? 2 : 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                    }

                    if (picWorld.Dimensions.WorldScale.Factor < 1)
                    {
                        for (int i = 10; i < 5000; i += 10)
                        {
                            if (i % 100 != 0)
                            {
                                new Circle(new RealPoint(), i).Paint(g, Color.LightGray, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                            }
                        }
                    }
                }

                if (points?.Count > 0)
                {
                    if (rdoOutline.Checked)
                    {
                        points.Add(new RealPoint());
                        Polygon poly = new Polygon(points);
                        points.RemoveAt(points.Count - 1);
                        poly.Paint(g, Color.Red, 1, Color.LightGray, picWorld.Dimensions.WorldScale);
                    }
                    else if (rdoShadows.Checked)
                    {
                        points.Add(new RealPoint());
                        Polygon poly = new Polygon(points);
                        points.RemoveAt(points.Count - 1);
                        g.FillRectangle(Brushes.LightGray, 0, 0, picWorld.Width, picWorld.Height);
                        poly.Paint(g, Color.Red, 1, Color.White, picWorld.Dimensions.WorldScale);
                    }
                    else if (rdoObjects.Checked)
                    {
                        foreach (RealPoint p in points)
                        {
                            p.Paint(g, Color.Black, 3, Color.Red, picWorld.Dimensions.WorldScale);
                        }
                    }
                    else
                    {
                        foreach (RealPoint p in points)
                        {
                            Segment s = new Segment(new RealPoint(), p);
                            s.Paint(g, Color.Red, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                        }
                    }

                    if (boxGroup.Checked)
                    {
                        points = points.Where(o => GameBoard.IsInside(o)).ToList();
                        List<List<RealPoint>> groups = points.GroupByDistance(50, 20);

                        List<Color> colors = new List<Color>() { Color.Blue, Color.Green, Color.Red, Color.Brown };

                        List<IShape> shapes = new List<IShape>();

                        for (int i = 0; i < groups.Count; i++)
                        {
                            if (groups[i].Count > 5 && i < colors.Count)
                            {
                                Circle circle = groups[i].FitCircle();
                                //Line line = groups[i].FitLine();
                                //Segment line = groups[i].FitSegment();

                                shapes.Add(circle);

                                circle.Paint(g, colors[i], 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                                g.DrawString((circle.Radius * 2).ToString("0") + "mm / " + (groups[i].FitCircleScore(circle) * 100).ToString("0") + "% / " + (groups[i].FitLineCorrelation()).ToString("0.00") + "%", new Font("Calibri", 9), new SolidBrush(colors[i]), picWorld.Dimensions.WorldScale.RealToScreenPosition(circle.Center.Translation(circle.Radius, 0)));

                                //line.Paint(g, colors[i], 1, Color.Transparent, picWorld.Dimensions.WorldScale);

                            }
                        }

                        //Plateau.Detections = shapes;
                    }
                    else
                    {
                        //Plateau.Detections = new List<IShape>(points);
                    }

                    new Circle(_selectedLidar.Position.Coordinates, 20).Paint(g, Color.Black, 1, Color.White, picWorld.Dimensions.WorldScale);
                }
            }
        }

        private void picWorld_MouseMove(object sender, MouseEventArgs e)
        {
            lblMousePosition.Text = picWorld.Dimensions.WorldScale.ScreenToRealPosition(e.Location).ToString();
        }
    }
}
