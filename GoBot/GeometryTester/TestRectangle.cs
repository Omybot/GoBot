using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Shapes;

namespace GeometryTester
{
    [TestClass]
    public class TestRectangle
    {
        [TestMethod]
        public void TestConstructorZero()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 0, 0);

            Assert.AreEqual(4, r1.Sides.Count);

            Assert.IsTrue(r1.Points.Contains(new RealPoint(0,0)));
        }

        [TestMethod]
        public void TestConstructorStandard()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 20), 5, 10);

            Assert.AreEqual(4, r1.Sides.Count);

            Assert.IsTrue(r1.Points.Contains(new RealPoint(10, 20)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(10 + 5, 20)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(10, 20 + 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(10 + 5, 20 + 10)));
        }

        [TestMethod]
        public void TestConstructorStandardWithOrigin()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 5, 10);

            Assert.AreEqual(4, r1.Sides.Count);

            Assert.IsTrue(r1.Points.Contains(new RealPoint(0, 0)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(0, 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(5, 0)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(5, 10)));
        }

        [TestMethod]
        public void TestConstructorPositionNeg()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(-10, -20), 5, 10);

            Assert.AreEqual(4, r1.Sides.Count);

            Assert.IsTrue(r1.Points.Contains(new RealPoint(-10, -20)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(-10 + 5, -20)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(-10, -20 + 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(-10 + 5, -20 + 10)));
        }

        [TestMethod]
        public void TestConstructorSizeNeg()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, -20), -5, -10);

            Assert.AreEqual(4, r1.Sides.Count);

            Assert.IsTrue(r1.Points.Contains(new RealPoint(10, -20)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(10 - 5, -20)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(10, -20 - 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(10 - 5, -20 - 10)));
        }

        [TestMethod]
        public void TestConstructorCopy()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, -20), -5, 10);
            //Polygon r2 = new Polygon(r1);

            //Assert.AreEqual(4, r1.Sides.Count);

            //Assert.IsTrue(r1.Points.Contains(new RealPoint(10, -20)));
            //Assert.IsTrue(r1.Points.Contains(new RealPoint(10 - 5, -20)));
            //Assert.IsTrue(r1.Points.Contains(new RealPoint(10, -20 + 10)));
            //Assert.IsTrue(r1.Points.Contains(new RealPoint(10 - 5, -20 + 10)));

            //Assert.AreEqual(4, r2.Sides.Count);

            //Assert.IsTrue(r2.Points.Contains(new RealPoint(10, -20)));
            //Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 5, -20)));
            //Assert.IsTrue(r2.Points.Contains(new RealPoint(10, -20 + 10)));
            //Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 5, -20 + 10)));
        }

        [TestMethod]
        public void TestTranslationStandard()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, -20), -5, 10);
            Polygon r2 = r1.Translation(10, 20);

            Assert.AreEqual(4, r2.Sides.Count);
            Assert.AreEqual(r1.Barycenter.X + 10, r2.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(r1.Barycenter.Y+20, r2.Barycenter.Y, RealPoint.PRECISION);

            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 + 10, -20 + 20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 + 10 - 5, -20 + 20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 + 10, -20 + 10 + 20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 + 10 - 5, -20 + 10 + 20)));
        }

        [TestMethod]
        public void TestTranslationZero()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, -20), -5, 10);
            Polygon r2 = r1.Translation(0, 0);
            
            Assert.AreEqual(r1, r2);

            Assert.AreEqual(4, r2.Sides.Count);

            Assert.IsTrue(r2.Points.Contains(new RealPoint(10, -20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 5, -20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10, -20 + 10)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 5, -20 + 10)));
        }

        [TestMethod]
        public void TestTranslationNeg()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, -20), -5, 10);
            Polygon r2 = r1.Translation(-10, -20);

            Assert.AreEqual(4, r2.Sides.Count);

            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 10, -20 - 20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 5 - 10, -20 - 20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 10, -20 + 10 - 20)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(10 - 5 - 10, -20 + 10 - 20)));

        }

        [TestMethod]
        public void TestSurfaceStandard()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 20), 10, 20);
            Polygon r2 = new PolygonRectangle(new RealPoint(0, 0), 5, -5);
            Polygon r3 = new PolygonRectangle(new RealPoint(-10, -5), -10, -20);

            Assert.AreEqual(10 * 20, r1.Surface, RealPoint.PRECISION);
            Assert.AreEqual(5 * 5, r2.Surface, RealPoint.PRECISION);
            Assert.AreEqual(10 * 20, r3.Surface, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestSurfaceZero()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 0), 0, 0);
            Polygon r2 = new PolygonRectangle(new RealPoint(0, 0), 0, 0);
            Polygon r3 = new PolygonRectangle(new RealPoint(-10, 0), 0, 0);

            Assert.AreEqual(0, r1.Surface, RealPoint.PRECISION);
            Assert.AreEqual(0, r2.Surface, RealPoint.PRECISION);
            Assert.AreEqual(0, r3.Surface, RealPoint.PRECISION);
        }
        
        [TestMethod]
        public void TestBarycenterStandard()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 20), 10, 20);

            Assert.AreEqual(15, r1.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(30, r1.Barycenter.Y, RealPoint.PRECISION);

            Polygon r2 = new PolygonRectangle(new RealPoint(10, 20), -10, -20);

            Assert.AreEqual(5, r2.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(10, r2.Barycenter.Y, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestBarycenterZero()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 0, 0);

            Assert.AreEqual(0, r1.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Barycenter.Y, RealPoint.PRECISION);

            Polygon r2 = new PolygonRectangle(new RealPoint(-5, -5), 10, 10);

            Assert.AreEqual(0, r2.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(0, r2.Barycenter.Y, RealPoint.PRECISION);

            Polygon r3 = new PolygonRectangle(new RealPoint(5, 5), -10, -10);

            Assert.AreEqual(0, r3.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(0, r3.Barycenter.Y, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestBarycenterNeg()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(-20, -30), 10, 20);

            Assert.AreEqual(-15, r1.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-20, r1.Barycenter.Y, RealPoint.PRECISION);

            Polygon r2 = new PolygonRectangle(new RealPoint(-20, -20), -10, -20);

            Assert.AreEqual(-25, r2.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-30, r2.Barycenter.Y, RealPoint.PRECISION);

            Polygon r3 = new PolygonRectangle(new RealPoint(-10, -20), 10, 20);

            Assert.AreEqual(-5, r3.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-10, r3.Barycenter.Y, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestRotationFromBarycenter()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 10), 10, 20);
            Polygon r2 = r1.Rotation(90);
            Polygon r3 = r1.Rotation(180);
            Polygon r4 = r1.Rotation(-90);
            Polygon r5 = r1.Rotation(-180);

            Assert.AreEqual(4, r1.Sides.Count);
            Assert.AreEqual(15, r1.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r1.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 - 5, 20 + 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 - 5, 20 - 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 + 5, 20 + 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 + 5, 20 - 10)));

            Assert.AreEqual(4, r2.Sides.Count);
            Assert.AreEqual(15, r2.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r2.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 - 10, 20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 - 10, 20 - 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 + 10, 20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 + 10, 20 - 5)));

            Assert.AreEqual(4, r3.Sides.Count);
            Assert.AreEqual(15, r3.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r3.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r3.Points.Contains(new RealPoint(15 - 5, 20 + 10)));
            Assert.IsTrue(r3.Points.Contains(new RealPoint(15 - 5, 20 - 10)));
            Assert.IsTrue(r3.Points.Contains(new RealPoint(15 + 5, 20 + 10)));
            Assert.IsTrue(r3.Points.Contains(new RealPoint(15 + 5, 20 - 10)));

            Assert.AreEqual(4, r4.Sides.Count);
            Assert.AreEqual(15, r4.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r4.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 - 10, 20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 - 10, 20 - 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 + 10, 20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 + 10, 20 - 5)));

            Assert.AreEqual(4, r5.Sides.Count);
            Assert.AreEqual(15, r5.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r5.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r5.Points.Contains(new RealPoint(15 - 5, 20 + 10)));
            Assert.IsTrue(r5.Points.Contains(new RealPoint(15 - 5, 20 - 10)));
            Assert.IsTrue(r5.Points.Contains(new RealPoint(15 + 5, 20 + 10)));
            Assert.IsTrue(r5.Points.Contains(new RealPoint(15 + 5, 20 - 10)));
        }

        [TestMethod]
        public void TestRotationFromZero()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 10), 10, 20);
            Polygon r2 = r1.Rotation(90, new RealPoint(0, 0));
            Polygon r3 = r1.Rotation(180, new RealPoint(0, 0));
            Polygon r4 = r1.Rotation(-90, new RealPoint(0, 0));
            Polygon r5 = r1.Rotation(-180, new RealPoint(0, 0));

            Assert.AreEqual(4, r1.Sides.Count);
            Assert.AreEqual(15, r1.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r1.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 - 5, 20 + 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 - 5, 20 - 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 + 5, 20 + 10)));
            Assert.IsTrue(r1.Points.Contains(new RealPoint(15 + 5, 20 - 10)));

            Assert.AreEqual(4, r2.Sides.Count);
            Assert.AreEqual(15, r2.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-20, r2.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 - 10, -20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 - 10, -20 - 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 + 10, -20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(15 + 10, -20 - 5)));

            Assert.AreEqual(4, r3.Sides.Count);
            Assert.AreEqual(-15, r3.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-20, r3.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r3.Points.Contains(new RealPoint(-15 - 5, -20 + 10)));
            Assert.IsTrue(r3.Points.Contains(new RealPoint(-15 - 5, -20 - 10)));
            Assert.IsTrue(r3.Points.Contains(new RealPoint(-15 + 5, -20 + 10)));
            Assert.IsTrue(r3.Points.Contains(new RealPoint(-15 + 5, -20 - 10)));

            Assert.AreEqual(4, r4.Sides.Count);
            Assert.AreEqual(-15, r4.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, r4.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r2.Points.Contains(new RealPoint(-15 - 10, 20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(-15 - 10, 20 - 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(-15 + 10, 20 + 5)));
            Assert.IsTrue(r2.Points.Contains(new RealPoint(-15 + 10, 20 - 5)));

            Assert.AreEqual(4, r5.Sides.Count);
            Assert.AreEqual(-15, r5.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-20, r5.Barycenter.Y, RealPoint.PRECISION);
            Assert.IsTrue(r5.Points.Contains(new RealPoint(-15 - 5, -20 + 10)));
            Assert.IsTrue(r5.Points.Contains(new RealPoint(-15 - 5, -20 - 10)));
            Assert.IsTrue(r5.Points.Contains(new RealPoint(-15 + 5, -20 + 10)));
            Assert.IsTrue(r5.Points.Contains(new RealPoint(-15 + 5, -20 - 10)));
        }
    }
}
