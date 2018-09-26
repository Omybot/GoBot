using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            Line
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

        public MainForm()
        {
            InitializeComponent();

            _shapeMode = ShapeMode.Rectangle;

            _shapes = new List<IShape>();

            _shapes.Add(new Circle(new RealPoint(200, 200), 30));
            _shapes.Add(new Circle(new RealPoint(250, 180), 30));
            _shapes.Add(new Segment(new RealPoint(10, 10), new RealPoint(300, 300)));
            _shapes.Add(new PolygonRectangle(new RealPoint(250, 250), 300, 50));
            _shapes.Add(new Circle(new RealPoint(260, 500), 30));
            _shapes.Add(new PolygonRectangle(new RealPoint(230, 400), 300, 40));
            _shapes.Add(new Circle(new RealPoint(320, 420), 15));

            _shapes.Add(new Circle(new RealPoint(100, 200), 15));
            _shapes.Add(new Circle(new RealPoint(100, 200), 30));
            _shapes.Add(new Circle(new RealPoint(100, 200), 45));
            _shapes.Add(new Circle(new RealPoint(100, 200), 60));

            _shapes.Add(new Circle(new RealPoint(80, 350), 15));
            _shapes.Add(new Circle(new RealPoint(80 + 14, 350), 30));
            _shapes.Add(new Circle(new RealPoint(80 + 14 + 14, 350), 45));
            _shapes.Add(new Circle(new RealPoint(80 + 14 + 14 + 14, 350), 60));

            _shapes.Add(new Circle(new RealPoint(80, 500), 15));
            _shapes.Add(new Circle(new RealPoint(80 + 14, 500), 30));
            _shapes.Add(new Circle(new RealPoint(80 + 14 + 14, 500), 45));
            _shapes.Add(new Circle(new RealPoint(80 + 14 + 14 + 14, 500), 60));
            _shapes.Add(new Segment(new RealPoint(80, 500), new RealPoint(180, 500)));

            _shapes.Add(new PolygonRectangle(new RealPoint(230, 400), 300, 40).Rotation(45));
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
            pt.X -= _worldScale.OffsetX;
            pt.Y -= _worldScale.OffsetY;

            pt.Y = -pt.Y;
            return pt;
        }

        private void picWorld_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = PicCoordinates();
            _currentShape = BuildCurrentShape(_shapeMode, _startPoint, _startPoint);

            picWorld.Invalidate();
        }

        private void picWorld_MouseMove(object sender, MouseEventArgs e)
        {
            RealPoint pos = PicCoordinates();
            lblPosition.Text = "X = " + pos.X.ToString().PadLeft(4) + ": Y = " + pos.Y.ToString().PadLeft(4);

            if (_startPoint != null)
            {
                _currentShape = BuildCurrentShape(_shapeMode, _startPoint, pos);
                lblItem.Text = _currentShape.GetType().Name + " : "+  _currentShape.ToString();
                picWorld.Invalidate();
            }
        }

        private void picWorld_MouseUp(object sender, MouseEventArgs e)
        {
            if (_startPoint != null)
            {
                _shapes.Add(BuildCurrentShape(_shapeMode, _startPoint, PicCoordinates()));
                lblItem.Text = "";

                _currentShape = null;
                _startPoint = null;
                
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
            picWorld.Invalidate();
        }

        private void btnAxes_ValueChanged(object sender, bool value)
        {
            _axesVisible = value;
            picWorld.Invalidate();
        }

        private void btnZoomPlus_Click(object sender, EventArgs e)
        {
            _worldScale = new WorldScale(_worldScale.Factor *0.85, picWorld.Width / 2, picWorld.Height / 2);
            picWorld.Invalidate();
        }

        private void btnZoomMinus_Click(object sender, EventArgs e)
        {
            _worldScale = new WorldScale(_worldScale.Factor * 1.2, picWorld.Width / 2, picWorld.Height / 2);
            picWorld.Invalidate();
        }
    }
}
