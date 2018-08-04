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
    public class TestCircle
    {
        [TestMethod]
        public void TestConstructorStandard()
        {
            Circle c = new Circle(new RealPoint(10, 20), 30);

            Assert.AreEqual(10, c.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestConstructorZero()
        {
            Circle c = new Circle(new RealPoint(0, 0), 0);

            Assert.AreEqual(0, c.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(0, c.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(0, c.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestConstructorPositionNeg()
        {
            Circle c = new Circle(new RealPoint(-10, -20), 5);

            Assert.AreEqual(-10, c.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(-20, c.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(5, c.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestConstructorRadiusNeg()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(new RealPoint(0, 0), -5));
        }

        [TestMethod]
        public void TestConstructorCopy()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = new Circle(c1);

            Assert.AreEqual(10, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestTranslationStandard()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = c1.Translation(25, 35);

            Assert.AreEqual(10, c1.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c1.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c1.Radius, RealPoint.PRECISION);

            Assert.AreEqual(10 + 25, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20 + 35, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestTranslationZero()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = c1.Translation(0, 0);

            Assert.AreEqual(10, c1.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c1.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c1.Radius, RealPoint.PRECISION);

            Assert.AreEqual(10, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestTranslationNeg()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = c1.Translation(-10, -20);

            Assert.AreEqual(10, c1.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c1.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c1.Radius, RealPoint.PRECISION);

            Assert.AreEqual(0, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(0, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestSurfaceStandard()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = new Circle(new RealPoint(0, 0), 30);
            Circle c3 = new Circle(new RealPoint(50, 150), 45);

            Assert.AreEqual(2827.43, c1.Surface, RealPoint.PRECISION);
            Assert.AreEqual(2827.43, c2.Surface, RealPoint.PRECISION);
            Assert.AreEqual(6361.73, c3.Surface, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestSurfaceZero()
        {
            Circle c = new Circle(new RealPoint(10, 20), 0);

            Assert.AreEqual(0, c.Surface, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestBarycenterStandard()
        {
            Circle c = new Circle(new RealPoint(10, 20), 10);

            Assert.AreEqual(10, c.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c.Barycenter.Y, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestBarycenterZero()
        {
            Circle c = new Circle(new RealPoint(0, 0), 10);

            Assert.AreEqual(0, c.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(0, c.Barycenter.Y, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestBarycenterNeg()
        {
            Circle c = new Circle(new RealPoint(-10, -20), 10);

            Assert.AreEqual(-10, c.Barycenter.X, RealPoint.PRECISION);
            Assert.AreEqual(-20, c.Barycenter.Y, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestRotationFromBarycenter()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = c1.Rotation(90);

            Assert.AreEqual(10, c1.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c1.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c1.Radius, RealPoint.PRECISION);

            Assert.AreEqual(10, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestRotationFromZero()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = c1.Rotation(90, new RealPoint(0, 0));

            Assert.AreEqual(10, c1.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c1.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c1.Radius, RealPoint.PRECISION);

            Assert.AreEqual(-20, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(10, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestRotationFromStandard()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = c1.Rotation(-90, new RealPoint(5, 5));

            Assert.AreEqual(10, c1.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(20, c1.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c1.Radius, RealPoint.PRECISION);

            Assert.AreEqual(20, c2.Center.X, RealPoint.PRECISION);
            Assert.AreEqual(0, c2.Center.Y, RealPoint.PRECISION);
            Assert.AreEqual(30, c2.Radius, RealPoint.PRECISION);
        }
    }
}