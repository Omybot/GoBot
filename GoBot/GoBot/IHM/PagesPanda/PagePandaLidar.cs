using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Geometry.Shapes;
using GoBot.Devices;
using GoBot.BoardContext;
using System.Drawing.Drawing2D;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaLidar : UserControl
    {
        private Lidar _selectedLidar;
        private List<RealPoint> _measureObjects, _measureBoard;

        private Bitmap _background;
        private RectangleF _backgroundRect;

        private bool _enableBoard;
        private bool _showLines, _showPoints;

        private bool _enableGroup;

        private bool _running;

        public PagePandaLidar()
        {
            InitializeComponent();
            _measureObjects = null;
            _selectedLidar = null;

            picWorld.Dimensions.SetZoomFactor(5);

            _enableGroup = false;
            _enableBoard = true;
            _showPoints = true;
            _showLines = false;
            _running = false;
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
                    picWorld.Dimensions.SetZoomFactor(picWorld.Dimensions.WorldScale.Factor * 0.8);
                else
                    picWorld.Dimensions.SetZoomFactor(picWorld.Dimensions.WorldScale.Factor * 1.25);
            }
        }

        private void lidar_NewMeasure(List<RealPoint> measure)
        {
            List<IShape> obstacles = GameBoard.ObstaclesBoardConstruction.ToList();
            List<RealPoint> tmpObjects, tmpBoard;

            if (!_enableBoard)
            {
                tmpObjects = measure.Where(o => GameBoard.IsInside(o, 50)).ToList();
                tmpObjects = tmpObjects.Where(p => !obstacles.Exists(o => o.Distance(p) < 30)).ToList();

                tmpBoard = measure.Where(p => !tmpObjects.Contains(p)).ToList();
                _measureObjects = tmpObjects.Select(p => new RealPoint(p.X - _selectedLidar.Position.Coordinates.X, p.Y - _selectedLidar.Position.Coordinates.Y)).ToList();
                _measureBoard = tmpBoard.Select(p => new RealPoint(p.X - _selectedLidar.Position.Coordinates.X, p.Y - _selectedLidar.Position.Coordinates.Y)).ToList();
            }
            else
            {
                _measureObjects = measure.Select(p => new RealPoint(p.X - _selectedLidar.Position.Coordinates.X, p.Y - _selectedLidar.Position.Coordinates.Y)).ToList();
                _measureBoard = null;
            }

            picWorld.Invalidate();
        }

        private void PanelLidar_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnTrap.Focus();
                _running = false;
                _selectedLidar = null;
            }
        }

        private void picWorld_WorldChange()
        {
            picWorld.Invalidate();
        }

        private Bitmap GenerateBackground()
        {
            Bitmap b = new Bitmap(picWorld.Width, picWorld.Height);
            Graphics g = Graphics.FromImage(b);

            if (picWorld.Width > 0 && picWorld.Height > 0)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                PolygonRectangle bounds = new PolygonRectangle(picWorld.Dimensions.WorldRect);

                for (int i = 100; i < 5000; i += 100)
                {
                    Circle c = new Circle(new RealPoint(), i);
                    if (c.Cross(bounds) || bounds.Contains(c))
                    {
                        c.Paint(g, i % 1000 == 0 ? Color.LightGray : Color.DimGray, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                    }
                }

                if (picWorld.Dimensions.WorldScale.Factor < 1 && !picWorld.Moving)
                {
                    for (int i = 10; i < 5000; i += 10)
                    {
                        if (i % 100 != 0)
                        {
                            Circle c = new Circle(new RealPoint(), i);
                            if (c.Cross(bounds) || bounds.Contains(c))
                            {
                                c.Paint(g, Color.FromArgb(60, 60, 60), 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                            }
                        }
                    }
                }
            }

            g.Dispose();

            return b;
        }

        private void picWorld_Paint(object sender, PaintEventArgs e)
        {
            if (_background == null || _backgroundRect != picWorld.Dimensions.WorldRect)
            {
                _background = GenerateBackground();
                _backgroundRect = picWorld.Dimensions.WorldRect;
            }

            Bitmap background = _background;

            List<RealPoint> pointsObjects = _measureObjects;
            List<RealPoint> pointsBoard = _measureBoard;

            Graphics g = e.Graphics;

            if (picWorld.Width > 0 && picWorld.Height > 0)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.DrawImage(background, 0, 0);

                if (picWorld.Moving)
                {
                    int diam = 100;
                    Point p = picWorld.Dimensions.WorldScale.RealToScreenPosition(picWorld.ClickedPoint);
                    //g.FillEllipse(Brushes.White, p.X - diam / 2, p.Y - diam / 2, diam, diam);

                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(p.X - diam / 2, p.Y - diam / 2, diam, diam);
                    PathGradientBrush b = new PathGradientBrush(path);
                    b.CenterPoint = p;
                    b.CenterColor = Color.White;
                    b.SurroundColors = new[] { Color.Transparent };
                    b.FocusScales = new PointF(0, 0);

                    g.FillEllipse(b, p.X - diam / 2, p.Y - diam / 2, diam, diam);
                    b.Dispose();
                    path.Dispose();
                }

                if (pointsBoard?.Count > 0)
                {
                    if (_showPoints)
                    {
                        foreach (RealPoint p in pointsBoard)
                        {
                            p.Paint(g, Color.DarkRed, 3, Color.Red, picWorld.Dimensions.WorldScale);
                        }
                    }
                    if (_showLines)
                    {
                        foreach (RealPoint p in pointsBoard)
                        {
                            Segment s = new Segment(new RealPoint(), p);
                            s.Paint(g, Color.Red, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                        }
                    }
                }

                if (pointsObjects?.Count > 0)
                {
                    if (_showPoints)
                    {
                        foreach (RealPoint p in pointsObjects)
                        {
                            p.Paint(g, Color.DarkGreen, 3, Color.Lime, picWorld.Dimensions.WorldScale);
                        }
                    }
                    if (_showLines)
                    {
                        foreach (RealPoint p in pointsObjects)
                        {
                            Segment s = new Segment(new RealPoint(), p);
                            s.Paint(g, Color.Lime, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                        }
                    }

                    if (_enableGroup)
                    {
                        //points = points.Where(o => GameBoard.IsInside(o)).ToList();
                        List<List<RealPoint>> groups = pointsObjects.GroupByDistance(80);

                        //for (int i = 0; i < groups.Count; i++)
                        //{
                        //    Circle circle = groups[i].FitCircle();
                        //    if (circle.Radius < 100 && groups[i].Count > 4)
                        //    {
                        //        circle.Paint(g, Color.White, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                        //    }
                        //}

                        for (int i = 0; i < groups.Count; i++)
                        {
                            if (groups[i].Count > 4)
                            {
                                RealPoint center = groups[i].GetBarycenter();
                                double var = Math.Sqrt(groups[i].Average(p => p.Distance(center) * p.Distance(center))) * 2;
                                new Circle(center, var).Paint(g, var > 35 ? Color.Lime : Color.Red, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                            }
                        }

                        //Plateau.Detections = shapes;
                    }
                    else
                    {
                        //Plateau.Detections = new List<IShape>(points);
                    }
                }
            }
        }

        public void LidarEnable(bool lidarEnable)
        {
            if (_selectedLidar != null && !lidarEnable && _running)
            {
                _selectedLidar.NewMeasure -= lidar_NewMeasure;
                _running = false;
            }

            if (lidarEnable && !_running)
            {
                if (_selectedLidar != null)
                {
                    _selectedLidar.NewMeasure += lidar_NewMeasure;
                    if (!_selectedLidar.Activated)
                        _selectedLidar.StartLoopMeasure();
                    _running = true;
                }
            }
        }

        private void picWorld_StopMove()
        {
            _background = GenerateBackground();
            picWorld.Invalidate();
        }

        private void picWorld_StartMove()
        {
            picWorld.Invalidate();
        }

        private void btnZoomPlus_Click(object sender, EventArgs e)
        {
            picWorld.Dimensions.SetZoomFactor(picWorld.Dimensions.WorldScale.Factor * 0.8);

            btnTrap.Focus();
        }

        private void btnZoomMinus_Click(object sender, EventArgs e)
        {
            picWorld.Dimensions.SetZoomFactor(picWorld.Dimensions.WorldScale.Factor * 1.25);

            btnTrap.Focus();
        }

        private void btnZoomReset_Click(object sender, EventArgs e)
        {
            picWorld.Dimensions.SetZoomFactor(5);
            picWorld.Dimensions.SetWorldCenter(new RealPoint(0, 0));

            btnTrap.Focus();
        }

        private void SetLidar(Lidar lidar)
        {
            if (_selectedLidar != lidar)
            {
                if (_selectedLidar != null)
                {
                    _selectedLidar.NewMeasure -= lidar_NewMeasure;
                    if (_selectedLidar == AllDevices.LidarGround)
                        _selectedLidar.StopLoopMeasure();
                }

                _selectedLidar = lidar;

                if (_selectedLidar != null)
                {
                    _selectedLidar.NewMeasure += lidar_NewMeasure;
                    if (_selectedLidar == AllDevices.LidarGround)
                        _selectedLidar.StartLoopMeasure();
                }

                _measureObjects = null;
                _measureBoard = null;
                picWorld.Invalidate();
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            _enableGroup = !_enableGroup;
            btnGroup.Image = _enableGroup ? Properties.Resources.LidarGroup : Properties.Resources.LidarGroupDisable;
        }

        private void btnLidarAvoid_Click(object sender, EventArgs e)
        {
            SetLidar(AllDevices.LidarAvoid);
        }

        private void btnLidarGround_Click(object sender, EventArgs e)
        {
            SetLidar(AllDevices.LidarGround);
        }

        private void btnEnableBoard_Click(object sender, EventArgs e)
        {
            _enableBoard = !_enableBoard;

            btnEnableBoard.Image = _enableBoard ? Properties.Resources.LidarBoardOn : Properties.Resources.LidarBoardOff;

            btnTrap.Focus();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            _showPoints = !_showPoints;
            _showLines = !_showLines;

            btnPoints.Image = _showPoints ? Properties.Resources.LidarPoints : Properties.Resources.LidarLines;

            btnTrap.Focus();
        }
    }
}
