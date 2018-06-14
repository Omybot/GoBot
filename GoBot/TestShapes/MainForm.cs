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
        private List<IShape> _shapes;

        private bool _barycenterVisible = true;
        private bool _crossingPointsVisible = true;
        private bool _crossingColorVisible = true;
        private bool _containedColorVisible = true;

        public MainForm()
        {
            InitializeComponent();

            _shapes = new List<IShape>();

            _shapes.Add(new Circle(new RealPoint(200, 200), 30));
            _shapes.Add(new Circle(new RealPoint(250, 180), 30));
            _shapes.Add(new Segment(new RealPoint(0, 0), new RealPoint(300, 300)));
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
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (IShape shape in _shapes)
            {
                bool isContained = false;
                bool isCrossed = false;

                foreach (IShape otherShape in _shapes)
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
                pt.Paint(g, Color.Black, 3, Color.Blue, WorldScale.Default());
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

        #endregion
    }
}
