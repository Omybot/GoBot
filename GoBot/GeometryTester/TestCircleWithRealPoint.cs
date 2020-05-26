using Geometry.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryTester
{
    [TestClass]
    public class TestCircleWithRealPoint
    {
        #region Contains

        [TestMethod]
        public void TestContainsStandard()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(11, 21);
            RealPoint p2 = new RealPoint(11, 60);
            RealPoint p3 = new RealPoint(11, -60);

            Assert.IsTrue(c1.Contains(p1));
            Assert.IsFalse(c1.Contains(p2));
            Assert.IsFalse(c1.Contains(p3));
        }

        [TestMethod]
        public void TestContainsCenter()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 20);

            Assert.IsTrue(c1.Contains(p1));
        }

        [TestMethod]
        public void TestContainsBorderOrtho()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 50);
            RealPoint p2 = new RealPoint(10, -10);
            RealPoint p3 = new RealPoint(-20, 20);
            RealPoint p4 = new RealPoint(40, 20);

            Assert.IsTrue(c1.Contains(p1));
            Assert.IsTrue(c1.Contains(p2));
            Assert.IsTrue(c1.Contains(p3));
            Assert.IsTrue(c1.Contains(p4));
        }

        [TestMethod]
        public void TestContainsBorderDiagonal()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10 + Math.Sin(Math.PI / 3) * 30, 20 + Math.Cos(Math.PI / 3) * 30);

            Assert.IsTrue(c1.Contains(p1));
        }

        [TestMethod]
        public void TestContainsOrigin()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            Assert.IsTrue(c1.Contains(p1));
        }

        [TestMethod]
        public void TestContainsOriginDot()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 0);
            RealPoint p1 = c1.Center;

            Assert.IsTrue(p1.Contains(c1));
        }

        [TestMethod]
        public void TestContainsDot()
        {
            Circle c1 = new Circle(new RealPoint(42, 42), 0);
            RealPoint p1 = c1.Center;

            Assert.IsTrue(p1.Contains(c1));
        }

        [TestMethod]
        public void TestContainsCircle()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            Assert.IsFalse(p1.Contains(c1));
        }

        #endregion

        #region Cross
        [TestMethod]

        public void TestCrossCenter()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 20);

            Assert.IsFalse(c1.Cross(p1));
        }

        [TestMethod]
        public void TestCrossBorderOrtho()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 50);
            RealPoint p2 = new RealPoint(10, -10);
            RealPoint p3 = new RealPoint(-20, 20);
            RealPoint p4 = new RealPoint(40, 20);

            Assert.IsTrue(c1.Cross(p1));
            Assert.IsTrue(c1.Cross(p2));
            Assert.IsTrue(c1.Cross(p3));
            Assert.IsTrue(c1.Cross(p4));
        }

        [TestMethod]
        public void TestCrossBorderDiagonal()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10 + Math.Sin(Math.PI / 3) * 30, 20 + Math.Cos(Math.PI / 3) * 30);

            Assert.IsTrue(c1.Cross(p1));
        }

        [TestMethod]
        public void TestCrossOrigin()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            Assert.IsFalse(c1.Cross(p1));
        }

        [TestMethod]
        public void TestCrossOriginDot()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 0);
            RealPoint p1 = c1.Center;

            Assert.IsTrue(p1.Cross(c1));
        }

        [TestMethod]
        public void TestCrossDot()
        {
            Circle c1 = new Circle(new RealPoint(42, 42), 0);
            RealPoint p1 = c1.Center;

            Assert.IsTrue(p1.Cross(c1));
        }

        [TestMethod]
        public void TestCrossCircle()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            Assert.IsFalse(p1.Cross(c1));
        }

        #endregion

        #region CrossingPoints
        [TestMethod]

        public void TestCrossingPointsCenter()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 20);

            List<RealPoint> points = c1.GetCrossingPoints(p1);
            Assert.AreEqual(0, points.Count);
        }

        [TestMethod]
        public void TestCrossingPointsBorderOrtho()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 50);
            RealPoint p2 = new RealPoint(10, -10);
            RealPoint p3 = new RealPoint(-20, 20);
            RealPoint p4 = new RealPoint(40, 20);

            List<RealPoint> points1 = c1.GetCrossingPoints(p1);
            List<RealPoint> points2 = c1.GetCrossingPoints(p2);
            List<RealPoint> points3 = c1.GetCrossingPoints(p3);
            List<RealPoint> points4 = c1.GetCrossingPoints(p4);

            Assert.AreEqual(1, points1.Count);
            Assert.AreEqual(1, points2.Count);
            Assert.AreEqual(1, points3.Count);
            Assert.AreEqual(1, points4.Count);

            Assert.AreEqual(points1[0], p1);
            Assert.AreEqual(points2[0], p2);
            Assert.AreEqual(points3[0], p3);
            Assert.AreEqual(points4[0], p4);
        }

        [TestMethod]
        public void TestCrossingPointsBorderDiagonal()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10 + Math.Sin(Math.PI / 3) * 30, 20 + Math.Cos(Math.PI / 3) * 30);

            List<RealPoint> points1 = c1.GetCrossingPoints(p1);
            Assert.AreEqual(1, points1.Count);
            Assert.AreEqual(points1[0], p1);
        }

        [TestMethod]
        public void TestCrossingPointsOrigin()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            List<RealPoint> points1 = c1.GetCrossingPoints(p1);
            Assert.AreEqual(0, points1.Count);
        }

        [TestMethod]
        public void TestCrossingPointsOriginDot()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 0);
            RealPoint p1 = c1.Center;

            List<RealPoint> points1 = c1.GetCrossingPoints(p1);
            Assert.AreEqual(1, points1.Count);
            Assert.AreEqual(points1[0], p1);
        }

        [TestMethod]
        public void TestCrossingPointsDot()
        {
            Circle c1 = new Circle(new RealPoint(42, 42), 0);
            RealPoint p1 = c1.Center;

            List<RealPoint> points1 = c1.GetCrossingPoints(p1);
            Assert.AreEqual(1, points1.Count);
            Assert.AreEqual(points1[0], p1);
        }

        [TestMethod]
        public void TestCrossingPointsCircle()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            List<RealPoint> points1 = c1.GetCrossingPoints(p1);
            Assert.AreEqual(0, points1.Count);
        }
        #endregion

        #region Distance

        [TestMethod]
        public void TestDistanceStandard()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(11, 21);
            RealPoint p2 = new RealPoint(11, 60);
            RealPoint p3 = new RealPoint(11, -60);

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
            Assert.AreEqual(10.0125, c1.Distance(p2), RealPoint.PRECISION);
            Assert.AreEqual(50.0062, c1.Distance(p3), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceCenter()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 20);

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceBorderOrtho()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10, 50);
            RealPoint p2 = new RealPoint(10, -10);
            RealPoint p3 = new RealPoint(-20, 20);
            RealPoint p4 = new RealPoint(40, 20);

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
            Assert.AreEqual(0, c1.Distance(p2), RealPoint.PRECISION);
            Assert.AreEqual(0, c1.Distance(p3), RealPoint.PRECISION);
            Assert.AreEqual(0, c1.Distance(p4), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceBorderDiagonal()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            RealPoint p1 = new RealPoint(10 + Math.Sin(Math.PI / 3) * 30, 20 + Math.Cos(Math.PI / 3) * 30);

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceOrigin()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 1);
            RealPoint p1 = c1.Center;

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceOriginDot()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 0);
            RealPoint p1 = c1.Center;

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceDot()
        {
            Circle c1 = new Circle(new RealPoint(42, 42), 0);
            RealPoint p1 = c1.Center;

            Assert.AreEqual(0, c1.Distance(p1), RealPoint.PRECISION);
        }

        #endregion

    }
}
