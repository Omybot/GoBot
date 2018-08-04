using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Shapes;

namespace GeometryTester
{
    [TestClass]
    public class TestRectangleWithRectangle
    {
        #region Contains

        [TestMethod]
        public void TestRectanglesContainsSameRectangle()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);
            Polygon r2 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            Assert.IsTrue(r1.Contains(r2));
        }

        [TestMethod]
        public void TestRectanglesContainsRectangleWithSameSide()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);
            Polygon r2 = new PolygonRectangle(new RealPoint(0, 2), 10, 5);

            Assert.IsTrue(r1.Contains(r2));
        }

        [TestMethod]
        public void TestRectanglesContainsSmallerRectangle()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);
            Polygon r2 = new PolygonRectangle(new RealPoint(2, 2), 8, 5);

            Assert.IsTrue(r1.Contains(r2));
        }

        #endregion

        #region Cross

        #endregion

        #region Distance

        [TestMethod]
        public void TestRectanglesDistanceSameSide()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            // Polygones décalés vérticalements OU horizontalement + coincidence segment
            Polygon r11 = new PolygonRectangle(new RealPoint(10, 0), 10, 10);
            Polygon r12 = new PolygonRectangle(new RealPoint(-10, 0), 10, 10);
            Polygon r13 = new PolygonRectangle(new RealPoint(0, 10), 10, 10);
            Polygon r14 = new PolygonRectangle(new RealPoint(0, -10), 10, 10);

            Assert.AreEqual(0, r1.Distance(r11), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(r12), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(r13), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(r14), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestRectanglesDistanceSameCorner()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            // Polygones décalés vérticalements ou horizontalement + coincidence coin
            Polygon r11 = new PolygonRectangle(new RealPoint(10, 0), 10, 10);
            Polygon r12 = new PolygonRectangle(new RealPoint(-10, 0), 10, 10);
            Polygon r13 = new PolygonRectangle(new RealPoint(0, 10), 10, 10);
            Polygon r14 = new PolygonRectangle(new RealPoint(0, -10), 10, 10);

            Assert.AreEqual(0, r1.Distance(r11), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(r12), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(r13), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(r14), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestRectanglesDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            // Polygones décalés vérticalements ET horizontalement
            Polygon r11 = new PolygonRectangle(new RealPoint(20, 20), 10, 10);
            Polygon r12 = new PolygonRectangle(new RealPoint(-20, -20), 10, 10);
            Polygon r13 = new PolygonRectangle(new RealPoint(-20, -20), 10, 10);

            Assert.AreEqual(Math.Sqrt(10 * 10 + 10 * 10), r1.Distance(r11));
            Assert.AreEqual(Math.Sqrt(10 * 10 + 10 * 10), r1.Distance(r12));
        }

        [TestMethod]
        public void TestCrossRectanglesDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            Polygon r11 = new PolygonRectangle(new RealPoint(5, 5), 10, 10);        // Rectangles qui se croisent sur 2 points

            Assert.AreEqual(0, r1.Distance(r11));

            Polygon r12 = new PolygonRectangle(new RealPoint(2, 2), 6, 6);          // Rectangles imbriqués

            Assert.AreEqual(0, r1.Distance(r12));                                   // Test imbrication rectangle A dans B
            Assert.AreEqual(0, r12.Distance(r1));                                   // Test imbrication rectangle B dans A                                   
        }

        #endregion
    }
}
