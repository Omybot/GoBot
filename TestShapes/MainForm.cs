using Geometry;
using Geometry.Shapes;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestShapes
{
    public partial class MainForm : Form
    {
        private enum ShapeMode
        {
            None,
            Rectangle,
            Circle,
            CircleFromCenter,
            Segment,
            Line,
            Zoom
        }

        private List<IShape> _shapes;
        private WorldScale _worldScale;

        private bool _barycenterVisible = true;
        private bool _crossingPointsVisible = true;
        private bool _crossingColorVisible = true;
        private bool _containedColorVisible = true;
        private bool _gridVisible = true;
        private bool _axesVisible = false;

        private ShapeMode _shapeMode;
        private RealPoint _startPoint;
        private IShape _currentShape;

        private PolygonRectangle _rectZoomOrg, _rectZoomFinal;

        ThreadLink _moveLoop;
        double _moveVertical, _moveHorizontal;
        double _moveZoom;

        public MainForm()
        {
            InitializeComponent();

            ThreadManager.Init();

            _shapeMode = ShapeMode.Rectangle;

            _shapes = new List<IShape>();

            _shapes.Add(new Line(new RealPoint(10, 10), new RealPoint(10, 100)));
            _shapes.Add(new Line(new RealPoint(20, 20), new RealPoint(100, 20)));

            //_shapes.Add(new Segment(new RealPoint(66.5, 9.9), new RealPoint(13.5, 84.2)));
            //_shapes.Add(new Segment(new RealPoint(46.6, 44), new RealPoint(30, 44)));

            //_shapes.Add(new Circle(new RealPoint(200, 200), 30));
            //_shapes.Add(new Circle(new RealPoint(250, 180), 30));
            //_shapes.Add(new Segment(new RealPoint(10, 10), new RealPoint(300, 300)));
            //_shapes.Add(new PolygonRectangle(new RealPoint(250, 250), 300, 50));
            //_shapes.Add(new Circle(new RealPoint(260, 500), 30));
            //_shapes.Add(new PolygonRectangle(new RealPoint(230, 400), 300, 40));
            //_shapes.Add(new Circle(new RealPoint(320, 420), 15));

            //_shapes.Add(new Circle(new RealPoint(100, 200), 15));
            //_shapes.Add(new Circle(new RealPoint(100, 200), 30));
            //_shapes.Add(new Circle(new RealPoint(100, 200), 45));
            //_shapes.Add(new Circle(new RealPoint(100, 200), 60));

            //_shapes.Add(new Circle(new RealPoint(80, 350), 15));
            //_shapes.Add(new Circle(new RealPoint(80 + 14, 350), 30));
            //_shapes.Add(new Circle(new RealPoint(80 + 14 + 14, 350), 45));
            //_shapes.Add(new Circle(new RealPoint(80 + 14 + 14 + 14, 350), 60));

            //_shapes.Add(new Circle(new RealPoint(80, 500), 15));
            //_shapes.Add(new Circle(new RealPoint(80 + 14, 500), 30));
            //_shapes.Add(new Circle(new RealPoint(80 + 14 + 14, 500), 45));
            //_shapes.Add(new Circle(new RealPoint(80 + 14 + 14 + 14, 500), 60));
            //_shapes.Add(new Segment(new RealPoint(80, 500), new RealPoint(180, 500)));

            //_shapes.Add(new PolygonRectangle(new RealPoint(230, 400), 300, 40).Rotation(45));
        }

        #region Peinture

        private void picWorld_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, +picWorld.Height);
            e.Graphics.ScaleTransform(1, -1);

            DrawGrid(e.Graphics);
            DrawAxes(e.Graphics);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            List<IShape> allShapes = new List<IShape>(_shapes);
            if (_currentShape != null) allShapes.Add(_currentShape);

            foreach (IShape shape in allShapes)
            {
                bool isContained = false;
                bool isCrossed = false;

                foreach (IShape otherShape in allShapes)
                {
                    if (otherShape != shape)
                    {
                        if (shape.Cross(otherShape))
                        {
                            isCrossed = true;
                            shape.GetCrossingPoints(otherShape).ForEach(p => DrawCrossingPoint(p, e.Graphics));
                        }
                        isContained = isContained || otherShape.Contains(shape);
                    }
                }

                DrawShape(shape, isCrossed, isContained, e.Graphics);
                DrawBarycenter(shape.Barycenter, e.Graphics);
            }

            if (_shapeMode == ShapeMode.Zoom && _rectZoomOrg != null)
            {
                if (_rectZoomOrg != null)
                {
                    Pen pen = new Pen(Color.Black);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    _rectZoomOrg.Paint(e.Graphics, Color.LightGray, 1, Color.Transparent, _worldScale);
                    pen.Dispose();
                }
                if (_rectZoomFinal != null)
                {
                    Pen pen = new Pen(Color.Black);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    _rectZoomFinal.Paint(e.Graphics, Color.DarkGray, 1, Color.Transparent, _worldScale);
                    pen.Dispose();
                }
            }
        }

        private void DrawAxes(Graphics g)
        {
            if (_axesVisible)
            {
                new Segment(new RealPoint(0, 0), new RealPoint(0, 150)).Paint(g, Color.Black, 3, Color.Transparent, _worldScale);
                new Segment(new RealPoint(0, 150), new RealPoint(5, 145)).Paint(g, Color.Black, 2, Color.Transparent, _worldScale);
                new Segment(new RealPoint(0, 150), new RealPoint(-5, 145)).Paint(g, Color.Black, 2, Color.Transparent, _worldScale);

                new Segment(new RealPoint(0, 0), new RealPoint(150, 0)).Paint(g, Color.Black, 3, Color.Transparent, _worldScale);
                new Segment(new RealPoint(150, 0), new RealPoint(145, 5)).Paint(g, Color.Black, 2, Color.Transparent, _worldScale);
                new Segment(new RealPoint(150, 0), new RealPoint(145, -5)).Paint(g, Color.Black, 2, Color.Transparent, _worldScale);

                RealPoint arc1 = _worldScale.RealToScreenPosition(new RealPoint(-80, -80));
                RealPoint arc2 = _worldScale.RealToScreenPosition(new RealPoint(80, 80));

                Rectangle r = new Rectangle((int)arc1.X, (int)arc1.Y, (int)(arc2.X - arc1.X), (int)(arc2.Y - arc1.Y));

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawArc(Pens.Black, r, 0, 90);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                RealPoint arrow1 = new RealPoint(1, 80);
                RealPoint arrow2 = new RealPoint(6, 85);
                RealPoint arrow3 = new RealPoint(6, 75);

                new Segment(arrow1, arrow2).Paint(g, Color.Black, 1, Color.Black, _worldScale);
                new Segment(arrow1, arrow3).Paint(g, Color.Black, 1, Color.Black, _worldScale);

                new RealPoint(0, 0).Paint(g, Color.Black, 3, Color.Black, _worldScale);
            }
        }

        private void DrawBarycenter(RealPoint pt, Graphics g)
        {
            if (_barycenterVisible)
            {
                pt?.Paint(g, Color.Black, 3, Color.Blue, _worldScale);
            }
        }

        private void DrawCrossingPoint(RealPoint pt, Graphics g)
        {
            if (_crossingPointsVisible)
            {
                pt.Paint(g, Color.Black, 5, Color.Red, _worldScale);
            }
        }

        private void DrawShape(IShape shape, bool isCrossed, bool isContained, Graphics g)
        {
            Color outlineColor = Color.Black;
            Color fillColor = Color.Transparent;

            if (_crossingColorVisible)
            {
                if (isCrossed)
                    outlineColor = Color.Red;
                else
                    outlineColor = Color.Green;
            }

            if (_containedColorVisible)
            {
                if (isContained)
                    fillColor = Color.FromArgb(100, Color.Green);
            }

            shape.Paint(g, outlineColor, 1, fillColor, _worldScale);
        }

        private void DrawGrid(Graphics g)
        {
            if (_gridVisible)
            {
                for (int i = -_worldScale.OffsetX / 10 * 10; i < picWorld.Width + _worldScale.OffsetX; i += 10)
                    new Segment(new RealPoint(i, -10000), new RealPoint(i, 10000)).Paint(g, Color.WhiteSmoke, 1, Color.Transparent, _worldScale);

                for (int i = -_worldScale.OffsetY / 10 * 10; i < picWorld.Height + _worldScale.OffsetY; i += 10)
                    new Segment(new RealPoint(-10000, i), new RealPoint(10000, i)).Paint(g, Color.WhiteSmoke, 1, Color.Transparent, _worldScale);

                new Segment(new RealPoint(0, -10000), new RealPoint(0, 10000)).Paint(g, Color.Black, 1, Color.Transparent, _worldScale);
                new Segment(new RealPoint(-10000, 0), new RealPoint(10000, 0)).Paint(g, Color.Black, 1, Color.Transparent, _worldScale);

                //for (int i = 0; i < picWorld.Width; i += 10)
                //    g.DrawLine(Pens.WhiteSmoke, i, 0, i, picWorld.Height);

                //for (int i = 0; i < picWorld.Height; i += 10)
                //    g.DrawLine(Pens.WhiteSmoke, 0, i, picWorld.Width, i);

                //for (int i = 0; i < picWorld.Width; i += 100)
                //    g.DrawLine(Pens.LightGray, i, 0, i, picWorld.Height);

                //for (int i = 0; i < picWorld.Height; i += 100)
                //    g.DrawLine(Pens.LightGray, 0, i, picWorld.Width, i);
            }
        }

        #endregion

        #region Actions IHM

        private void btnBarycenter_ValueChanged(object sender, bool value)
        {
            _barycenterVisible = value;
            picWorld.Invalidate();
        }

        private void btnCrossing_ValueChanged(object sender, bool value)
        {
            _crossingColorVisible = value;
            picWorld.Invalidate();
        }

        private void btnCrossingPoints_ValueChanged(object sender, bool value)
        {
            _crossingPointsVisible = value;
            picWorld.Invalidate();
        }

        private void btnContained_ValueChanged(object sender, bool value)
        {
            _containedColorVisible = value;
            picWorld.Invalidate();
        }

        private void btnGrid_ValueChanged(object sender, bool value)
        {
            _gridVisible = value;
            picWorld.Invalidate();
        }

        #endregion

        private RealPoint PicCoordinates()
        {
            RealPoint pt = picWorld.PointToClient(Cursor.Position);

            RealPoint output = new RealPoint();
            output.X = (-_worldScale.OffsetX + pt.X) * _worldScale.Factor;
            output.Y = ( + (picWorld.Height - pt.Y) - _worldScale.OffsetY) * _worldScale.Factor;

            Console.WriteLine(_worldScale.OffsetY + " / " + pt.Y);
            return output;
        }

        private void picWorld_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = PicCoordinates();

            if (_shapeMode == ShapeMode.Zoom)
            {
                _rectZoomOrg = new PolygonRectangle(_startPoint, 1, 1);
            }
            else
            {
                _currentShape = BuildCurrentShape(_shapeMode, _startPoint, _startPoint);
            }

            picWorld.Invalidate();
        }

        private void picWorld_MouseMove(object sender, MouseEventArgs e)
        {
            RealPoint pos = PicCoordinates();
            lblPosition.Text = "X = " + pos.X.ToString().PadLeft(4) + ": Y = " + pos.Y.ToString().PadLeft(4);

            if (_startPoint != null)
            {
                if (_shapeMode == ShapeMode.Zoom)
                {
                    double dx = pos.X - _startPoint.X;
                    double dy = pos.Y - _startPoint.Y;
                    double finalDx = dx;
                    double finalDy = dy;

                    _rectZoomOrg = new PolygonRectangle(_startPoint, dx, dy);

                    if (Math.Abs(dx / dy) > Math.Abs(picWorld.Width / picWorld.Height))
                        finalDx = Math.Sign(dx) * (picWorld.Width * (Math.Abs(dy) / picWorld.Height));
                    else
                        finalDy = Math.Sign(dy) * (picWorld.Height * (Math.Abs(dx) / picWorld.Width));

                    _rectZoomFinal = new PolygonRectangle(RealPoint.Shift(_startPoint, -(finalDx - dx) / 2, -(finalDy - dy) / 2), finalDx, finalDy);
                }
                else if (_shapeMode != ShapeMode.None)
                {
                    _currentShape = BuildCurrentShape(_shapeMode, _startPoint, pos);
                    lblItem.Text = _currentShape.GetType().Name + " : " + _currentShape.ToString();
                }

                picWorld.Invalidate();
            }
        }

        private void picWorld_MouseUp(object sender, MouseEventArgs e)
        {
            if (_startPoint != null)
            {
                if (_shapeMode == ShapeMode.Zoom)
                {
                    double dx = _rectZoomFinal.Points.Max(pt => pt.X) - _rectZoomFinal.Points.Min(pt => pt.X);
                    //dx = _worldScale.RealToScreenDistance(dx);
                    WorldScale finalScale = CreateWorldScale(dx / picWorld.Width, _rectZoomFinal.Barycenter);

                    _moveZoom = (_worldScale.Factor - finalScale.Factor) / 20;
                    _moveHorizontal = -finalScale.ScreenToRealDistance((finalScale.OffsetX - _worldScale.OffsetX) / 20);
                    _moveVertical = -finalScale.ScreenToRealDistance((finalScale.OffsetY - _worldScale.OffsetY) / 20);

                    _step = 0;
                    ThreadManager.CreateThread(o => ZoomStepParam()).StartLoop(20, 40);
                    //_worldScale = finalScale;

                    _startPoint = null;
                    _rectZoomFinal = null;
                    _rectZoomOrg = null;
                    _shapeMode = ShapeMode.None;
                    btnZoom.Checked = false;
                }
                else if (_shapeMode != ShapeMode.None)
                {
                    _shapes.Add(BuildCurrentShape(_shapeMode, _startPoint, PicCoordinates()));
                    lblItem.Text = "";

                    _currentShape = null;
                    _startPoint = null;
                }

                picWorld.Invalidate();
            }
        }

        private static IShape BuildCurrentShape(ShapeMode mode, RealPoint startPoint, RealPoint endPoint)
        {
            IShape output = null;

            switch (mode)
            {
                case ShapeMode.Rectangle:
                    output = new PolygonRectangle(startPoint, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                    break;
                case ShapeMode.Circle:
                    output = new Circle(new Segment(startPoint, endPoint).Barycenter, startPoint.Distance(endPoint) / 2);
                    break;
                case ShapeMode.CircleFromCenter:
                    output = new Circle(startPoint, startPoint.Distance(endPoint));
                    break;
                case ShapeMode.Segment:
                    output = new Segment(startPoint, endPoint);
                    break;
                case ShapeMode.Line:
                    output = new Line(startPoint, endPoint);
                    break;
            }

            return output;
        }

        private void btnRectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRectangle.Checked) _shapeMode = ShapeMode.Rectangle;
        }

        private void btnCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCircle.Checked) _shapeMode = ShapeMode.Circle;
        }

        private void btnCircleFromCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCircleFromCenter.Checked) _shapeMode = ShapeMode.CircleFromCenter;
        }

        private void btnSegment_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSegment.Checked) _shapeMode = ShapeMode.Segment;
        }

        private void btnLine_CheckedChanged(object sender, EventArgs e)
        {
            if (btnLine.Checked) _shapeMode = ShapeMode.Line;
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            _shapes.Clear();
            picWorld.Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_shapes.Count > 0)
            {
                _shapes.RemoveAt(_shapes.Count - 1);
                picWorld.Invalidate();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _worldScale = new WorldScale(1, picWorld.Width / 2, picWorld.Height / 2);
        }

        private void picWorld_SizeChanged(object sender, EventArgs e)
        {
            _worldScale = new WorldScale(1, picWorld.Width / 2, picWorld.Height / 2);

            //SetScreenSize(picWorld.Size);
            picWorld.Invalidate();
        }

        private void btnAxes_ValueChanged(object sender, bool value)
        {
            _axesVisible = value;
            picWorld.Invalidate();
        }

        private void btnZoomPlus_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(o => ZoomPlus()).StartLoop(20, 20);
        }

        private void btnZoomMinus_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(o => ZoomMinus()).StartLoop(20, 20);
        }

        private void btnZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (btnZoom.Checked) _shapeMode = ShapeMode.Zoom;
        }

        private WorldScale CreateWorldScale(double mmPerPixel, RealPoint center)
        {
            Console.WriteLine(center.ToString());
            int x = (int)(picWorld.Width / 2 - center.X / mmPerPixel);
            int y = (int)(picWorld.Height / 2 - center.Y / mmPerPixel);

            return new WorldScale(mmPerPixel, x, y);
        }

        private RealPoint GetCenter()
        {
            return _worldScale.ScreenToRealPosition(new RealPoint(picWorld.Width / 2, picWorld.Height / 2));
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(o => ZoomUp()).StartLoop(20, 20);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(o => ZoomDown()).StartLoop(20, 20);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(o => ZoomRight()).StartLoop(20, 20);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(o => ZoomLeft()).StartLoop(20, 20);
        }

        private void ZoomPlus()
        {
            _worldScale = CreateWorldScale(_worldScale.Factor * 0.97, GetCenter());
            picWorld.Invalidate();
        }

        private void ZoomMinus()
        {
            _worldScale = CreateWorldScale(_worldScale.Factor * (1 / 0.97), GetCenter());
            picWorld.Invalidate();
        }

        private void ZoomUp()
        {
            double dx = 0;
            double dy = _worldScale.ScreenToRealDistance(picWorld.Height / 60f);

            _worldScale = CreateWorldScale(_worldScale.Factor, RealPoint.Shift(GetCenter(), dx, dy));
            picWorld.Invalidate();
        }

        private void ZoomDown()
        {
            double dx = 0;
            double dy = -_worldScale.ScreenToRealDistance(picWorld.Height / 60f);

            _worldScale = CreateWorldScale(_worldScale.Factor, RealPoint.Shift(GetCenter(), dx, dy));
            picWorld.Invalidate();
        }

        private void ZoomLeft()
        {
            double dx = -_worldScale.ScreenToRealDistance(picWorld.Height / 60f);
            double dy = 0;

            _worldScale = CreateWorldScale(_worldScale.Factor, RealPoint.Shift(GetCenter(), dx, dy));
            picWorld.Invalidate();
        }

        private void ZoomRight()
        {
            double dx = _worldScale.ScreenToRealDistance(picWorld.Height / 60f);
            double dy = 0;

            _worldScale = CreateWorldScale(_worldScale.Factor, RealPoint.Shift(GetCenter(), dx, dy));
            picWorld.Invalidate();
        }

        private void ZoomStep()
        {
            double dx = _worldScale.ScreenToRealDistance(picWorld.Height / 60f) * _moveHorizontal;
            double dy = _worldScale.ScreenToRealDistance(picWorld.Height / 60f) * _moveVertical;

            _worldScale = CreateWorldScale(_worldScale.Factor + _moveZoom, RealPoint.Shift(GetCenter(), dx, dy));
            //_worldScale = CreateWorldScale(_worldScale.Factor + _moveZoom, GetCenter());

            picWorld.Invalidate();
        }

        int _step;

        private void ZoomStepParam()
        {
            if(_step < 20)
                _worldScale = CreateWorldScale(_worldScale.Factor, RealPoint.Shift(GetCenter(), _moveHorizontal, _moveVertical));
            else if(_step < 40)
                _worldScale = CreateWorldScale(_worldScale.Factor - _moveZoom, GetCenter());

            _step++;
            if(_step == 40)
            {
                _moveHorizontal = 0;
                _moveVertical = 0;
                _moveZoom = 0;
            }

            picWorld.Invalidate();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                _moveVertical = 0;
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                _moveHorizontal = 0;
            }

            if (_moveVertical == 0 && _moveHorizontal == 0 && _moveLoop != null)
            {
                _moveLoop.Cancel();
                _moveLoop.WaitEnd();
                _moveLoop = null;
            }
        }

        private void btnOrigin_Click(object sender, EventArgs e)
        {
            _worldScale = CreateWorldScale(_worldScale.Factor, new RealPoint());
            picWorld.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
                _moveVertical = -1;
            else if (keyData == Keys.Up)
                _moveVertical = 1;
            else if (keyData == Keys.Left)
                _moveHorizontal = -1;
            else if (keyData == Keys.Right)
                _moveHorizontal = 1;

            if ((_moveVertical != 0 || _moveHorizontal != 0) && _moveLoop == null)
            {
                _moveLoop = ThreadManager.CreateThread(o => ZoomStep());
                _moveLoop.StartInfiniteLoop(20);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

