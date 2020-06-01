﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Geometry.Shapes;
using GoBot.Devices;
using GoBot.BoardContext;
using System.Diagnostics;
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

        public PagePandaLidar()
        {
            InitializeComponent();
            _measureObjects = null;
            _selectedLidar = null;

            picWorld.Dimensions.SetZoomFactor(5);

            _enableBoard = true;
            _showPoints = true;
            _showLines = false;
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

        private void switchEnable_ValueChanged(object sender, bool value)
        {
            if (_selectedLidar != null)
            {
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
                    _selectedLidar.NewMeasure += lidar_NewMeasure;
                    _selectedLidar.StartLoopMeasure();
                }
            }
        }

        private void lidar_NewMeasure(List<RealPoint> measure)
        {
            List<IShape> obstacles = GameBoard.ObstaclesBoardConstruction.ToList();

            if (!_enableBoard)
            {
                _measureObjects = measure.Where(o => GameBoard.IsInside(o, 50)).ToList();
                _measureObjects = _measureObjects.Where(p => !obstacles.Exists(o => o.Distance(p) < 30)).ToList();

                _measureBoard = measure.Where(p => !_measureObjects.Contains(p)).ToList();
                _measureBoard = _measureBoard.Select(p => new RealPoint(p.X - _selectedLidar.Position.Coordinates.X, p.Y - _selectedLidar.Position.Coordinates.Y)).ToList();
            }
            else
            {
                _measureObjects = measure;
                _measureBoard = null;
            }

            _measureObjects = _measureObjects.Select(p => new RealPoint(p.X - _selectedLidar.Position.Coordinates.X, p.Y - _selectedLidar.Position.Coordinates.Y)).ToList();

            picWorld.Invalidate();
        }

        private void PanelLidar_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                cboLidar.Items.Add("Ground");
                cboLidar.Items.Add("Avoid");
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
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

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
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

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
                            p.Paint(g, Color.Black, 3, Color.Red, picWorld.Dimensions.WorldScale);
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
                            p.Paint(g, Color.Black, 3, Color.Lime, picWorld.Dimensions.WorldScale);
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

                    if (boxGroup.Checked)
                    {
                        //points = points.Where(o => GameBoard.IsInside(o)).ToList();
                        List<List<RealPoint>> groups = pointsObjects.GroupByDistance(80, -1);

                        List<Color> colors = new List<Color>() { Color.Blue, Color.Green, Color.Red, Color.Brown };

                        List<IShape> shapes = new List<IShape>();

                        for (int i = 0; i < groups.Count; i++)
                        {
                            Circle circle = groups[i].FitCircle();
                            if (circle.Radius < 100 && groups[i].Count > 4)// && i < colors.Count)
                            {
                                //Line line = groups[i].FitLine();
                                //Segment line = groups[i].FitSegment();

                                shapes.Add(circle);

                                circle.Paint(g, Color.White, 1, Color.Transparent, picWorld.Dimensions.WorldScale);
                                g.DrawString((circle.Radius * 2).ToString("0") + "mm / " + (groups[i].FitCircleScore(circle) * 100).ToString("0") + "% / " + (groups[i].FitLineCorrelation()).ToString("0.00") + "%", new Font("Calibri", 9), new SolidBrush(colors[i % colors.Count]), picWorld.Dimensions.WorldScale.RealToScreenPosition(circle.Center.Translation(circle.Radius, 0)));

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

        private void btnEnableBoard_Click(object sender, EventArgs e)
        {
            _enableBoard = !_enableBoard;

            btnEnableBoard.Image = _enableBoard ? Properties.Resources.LidarBoardOn : Properties.Resources.LidarBoardOff;

            btnTrap.Focus();
        }

        private void btnLines_Click(object sender, EventArgs e)
        {
            _showPoints = false;
            _showLines = true;

            btnPoints.Image = GoBot.Properties.Resources.LidarPoints;
            btnLines.Image = GoBot.Properties.Resources.LidarLinesOn;

            btnTrap.Focus();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            _showPoints = true;
            _showLines = false;

            btnPoints.Image = GoBot.Properties.Resources.LidarPointsOn;
            btnLines.Image = GoBot.Properties.Resources.LidarLines;

            btnTrap.Focus();
        }
    }
}