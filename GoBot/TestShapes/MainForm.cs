using GoBot;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private bool _barycenterVisible = true;
        private bool _crossingPointsVisible = true;
        private bool _crossingColorVisible = true;
        private bool _containedColorVisible = true;
        private bool _gridVisible = true;

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
            DrawGrid(e.Graphics);

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

        private void DrawBarycenter(RealPoint pt, Graphics g)
        {
            if (_barycenterVisible)
            {
                pt?.Paint(g, Color.Black, 3, Color.Blue, WorldScale.Default());
            }
        }

        private void DrawCrossingPoint(RealPoint pt, Graphics g)
        {
            if (_crossingPointsVisible)
            {
                pt.Paint(g, Color.Black, 5, Color.Red, WorldScale.Default());
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

            shape.Paint(g, outlineColor, 1, fillColor, WorldScale.Default());
        }

        private void DrawGrid(Graphics g)
        {
            if (_gridVisible)
            {
                for (int i = 0; i < picWorld.Width; i += 10)
                    g.DrawLine(Pens.WhiteSmoke, i, 0, i, picWorld.Height);

                for (int i = 0; i < picWorld.Height; i += 10)
                    g.DrawLine(Pens.WhiteSmoke, 0, i, picWorld.Width, i);

                for (int i = 0; i < picWorld.Width; i += 100)
                    g.DrawLine(Pens.LightGray, i, 0, i, picWorld.Height);

                for (int i = 0; i < picWorld.Height; i += 100)
                    g.DrawLine(Pens.LightGray, 0, i, picWorld.Width, i);
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


        private void picWorld_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = picWorld.PointToClient(Cursor.Position);
            _currentShape = BuildCurrentShape(_shapeMode, _startPoint, _startPoint);

            picWorld.Invalidate();
        }

        private void picWorld_MouseMove(object sender, MouseEventArgs e)
        {
            RealPoint pos = picWorld.PointToClient(Cursor.Position);
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
                _shapes.Add(BuildCurrentShape(_shapeMode, _startPoint, picWorld.PointToClient(Cursor.Position)));
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
    }
}
