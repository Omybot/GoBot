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
    public class TestCircleWithCircle
    {
        #region Contains

        [TestMethod]
        public void TestContainsStandard()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = new Circle(new RealPoint(20, 5), 80);
            Circle c3 = new Circle(new RealPoint(100, 220), 20);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsFalse(c1.Contains(c3));

            Assert.IsTrue(c2.Contains(c1));
            Assert.IsFalse(c2.Contains(c3));

            Assert.IsFalse(c3.Contains(c1));
            Assert.IsFalse(c3.Contains(c2));
        }

        [TestMethod]
        public void TestContainsPositionZero()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 30);
            Circle c2 = new Circle(new RealPoint(0, 0), 80);
            Circle c3 = new Circle(new RealPoint(100, 220), 20);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsFalse(c1.Contains(c3));

            Assert.IsTrue(c2.Contains(c1));
            Assert.IsFalse(c2.Contains(c3));

            Assert.IsFalse(c3.Contains(c1));
            Assert.IsFalse(c3.Contains(c2));
        }

        [TestMethod]
        public void TestContainsRadiusZero()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 0);
            Circle c2 = new Circle(new RealPoint(20, 5), 80);
            Circle c3 = new Circle(new RealPoint(100, 220), 20);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsFalse(c1.Contains(c3));

            Assert.IsTrue(c2.Contains(c1));
            Assert.IsFalse(c3.Contains(c1));
        }

        [TestMethod]
        public void TestContainsPositionNeg()
        {
            Circle c1 = new Circle(new RealPoint(-10, -20), 30);
            Circle c2 = new Circle(new RealPoint(-20, -5), 80);
            Circle c3 = new Circle(new RealPoint(-100, -220), 20);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsFalse(c1.Contains(c3));

            Assert.IsTrue(c2.Contains(c1));
            Assert.IsFalse(c2.Contains(c3));

            Assert.IsFalse(c3.Contains(c1));
            Assert.IsFalse(c3.Contains(c2));
        }

        [TestMethod]
        public void TestContainsSameX()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = new Circle(new RealPoint(10, 5), 80);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsTrue(c2.Contains(c1));
        }

        [TestMethod]
        public void TestContainsSameY()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = new Circle(new RealPoint(20, 20), 80);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsTrue(c2.Contains(c1));
        }

        [TestMethod]
        public void TestContainsSameCenter()
        {
            Circle c1 = new Circle(new RealPoint(10, 20), 30);
            Circle c2 = new Circle(new RealPoint(10, 20), 80);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsTrue(c2.Contains(c1));
        }

        [TestMethod]
        public void TestContainsSameCenterZero()
        {
            Circle c1 = new Circle(new RealPoint(0, 0), 30);
            Circle c2 = new Circle(new RealPoint(0, 0), 80);

            Assert.IsFalse(c1.Contains(c2));
            Assert.IsTrue(c2.Contains(c1));
        }

        #endregion

        #region Cross

        [TestMethod]
        public void TestCrossStandard()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 50);
            Circle c2 = new Circle(new RealPoint(55, 35), 40);
            Circle c3 = new Circle(new RealPoint(150, 20), 25);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsFalse(c1.Cross(c3));

            Assert.IsTrue(c2.Cross(c1));
            Assert.IsFalse(c2.Cross(c3));

            Assert.IsFalse(c3.Cross(c1));
            Assert.IsFalse(c3.Cross(c2));
        }

        [TestMethod]
        public void TestCrossSameX()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(20, 35), 15);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossSameY()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(35, 30), 15);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossAdjacentX()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(60, 30), 20);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossAdjacentY()
        {
            Circle c1 = new Circle(new RealPoint(30, 20), 20);
            Circle c2 = new Circle(new RealPoint(30, 60), 20);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossAdjacent()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(10, 10), 2.5);
            Circle c2 = new Circle(new RealPoint(13, 14), 2.5);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossRadiusZeroBoth()
        {
            Circle c1 = new Circle(new RealPoint(10, 10), 0);
            Circle c2 = new Circle(new RealPoint(10, 10), 0);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossRadiusZeroOnCircle()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(10, 10), 5);
            Circle c2 = new Circle(new RealPoint(13, 14), 0);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossRadiusZeroOnCenter()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(3, 4), 5);
            Circle c2 = new Circle(new RealPoint(0, 0), 0);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossSuperposed()
        {
            Circle c1 = new Circle(new RealPoint(5, 5), 5);
            Circle c2 = new Circle(new RealPoint(5, 5), 5);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));
        }

        [TestMethod]
        public void TestCrossPrecision()
        {
            Circle c1 = new Circle(new RealPoint(5, 5), 5);
            Circle c2 = new Circle(new RealPoint(5, 15), 5 + RealPoint.PRECISION);
            Circle c3 = new Circle(new RealPoint(5, 15), 5 - RealPoint.PRECISION);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsTrue(c2.Cross(c1));

            Assert.IsFalse(c1.Cross(c3));
            Assert.IsFalse(c3.Cross(c1));
        }

        [TestMethod]
        public void TestCrossNeg()
        {
            Circle c1 = new Circle(new RealPoint(-20, -30), 50);
            Circle c2 = new Circle(new RealPoint(-55, -35), 40);
            Circle c3 = new Circle(new RealPoint(-150, -20), 25);
            Circle c4 = new Circle(new RealPoint(150, 20), 25);

            Assert.IsTrue(c1.Cross(c2));
            Assert.IsFalse(c1.Cross(c3));
            Assert.IsFalse(c4.Cross(c3));

            Assert.IsTrue(c2.Cross(c1));
            Assert.IsFalse(c2.Cross(c3));
            Assert.IsFalse(c4.Cross(c3));

            Assert.IsFalse(c3.Cross(c1));
            Assert.IsFalse(c3.Cross(c2));
            Assert.IsFalse(c3.Cross(c4));
        }


        #endregion

        #region Distance

        [TestMethod]
        public void TestDistanceStandard()
        {
            Circle c1 = new Circle(new RealPoint(3, 4), 1);
            Circle c2 = new Circle(new RealPoint(6, 10), 1);

            Assert.AreEqual(4.71, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceSame()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(20, 30), 20);

            Assert.AreEqual(0, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceAdjacent()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(10, 10), 2.5);
            Circle c2 = new Circle(new RealPoint(13, 14), 2.5);

            Assert.AreEqual(0, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceRadiusZeroBoth()
        {
            Circle c1 = new Circle(new RealPoint(10, 10), 0);
            Circle c2 = new Circle(new RealPoint(10, 10), 0);

            Assert.AreEqual(0, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceRadiusZeroOnCircle()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(10, 10), 5);
            Circle c2 = new Circle(new RealPoint(13, 14), 0);

            Assert.AreEqual(0, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceRadiusZeroOnCenter()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(3, 4), 5);
            Circle c2 = new Circle(new RealPoint(0, 0), 0);

            Assert.AreEqual(0, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceCrossing()
        {
            Circle c1 = new Circle(new RealPoint(5, 6), 5);
            Circle c2 = new Circle(new RealPoint(6, 8), 5);

            Assert.AreEqual(0, c1.Distance(c2), RealPoint.PRECISION);
        }

        [TestMethod]
        public void TestDistanceCenterNeg()
        {
            Circle c1 = new Circle(new RealPoint(-20, -30), 5);
            Circle c2 = new Circle(new RealPoint(-55, -35), 4);

            Assert.AreEqual(26.35, c1.Distance(c2), RealPoint.PRECISION);
        }

        #endregion

        #region CrossingPoints

        [TestMethod]
        public void TestCrossingPointsStandard()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 50);
            Circle c2 = new Circle(new RealPoint(55, 35), 40);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(2, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(55.71, -4.99)));
            Assert.IsTrue(pts.Contains(new RealPoint(44.49, 73.59)));
        }

        [TestMethod]
        public void TestCrossingPointsSameX()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(20, 35), 20);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(2, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(39.84, 32.5)));
            Assert.IsTrue(pts.Contains(new RealPoint(0.16, 32.5)));
        }

        [TestMethod]
        public void TestCrossingPointsSameY()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(35, 30), 15);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(2, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(33.33, 15.09)));
            Assert.IsTrue(pts.Contains(new RealPoint(33.33, 44.91)));
        }

        [TestMethod]
        public void TestCrossingPointsAdjacentX()
        {
            Circle c1 = new Circle(new RealPoint(20, 30), 20);
            Circle c2 = new Circle(new RealPoint(60, 30), 20);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(1, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(40,30)));
        }

        [TestMethod]
        public void TestCrossingPointsAdjacentY()
        {
            Circle c1 = new Circle(new RealPoint(30, 20), 20);
            Circle c2 = new Circle(new RealPoint(30, 60), 20);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(1, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(30, 40)));
        }

        [TestMethod]
        public void TestCrossingPointsAdjacent()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(10, 10), 2.5);
            Circle c2 = new Circle(new RealPoint(13, 14), 2.5);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(1, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(11.5,12)));
        }

        [TestMethod]
        public void TestCrossingPointsRadiusZeroBoth()
        {
            Circle c1 = new Circle(new RealPoint(10, 10), 0);
            Circle c2 = new Circle(new RealPoint(10, 10), 0);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(1, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(10,10)));
        }

        [TestMethod]
        public void TestCrossingPointsRadiusZeroOnCircle()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(10, 10), 5);
            Circle c2 = new Circle(new RealPoint(13, 14), 0);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(1, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(13, 14)));
        }

        [TestMethod]
        public void TestCrossingPointsRadiusZeroOnCenter()
        {
            // 3² + 4² = 5², très pratique

            Circle c1 = new Circle(new RealPoint(3, 4), 5);
            Circle c2 = new Circle(new RealPoint(0, 0), 0);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(1, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(0, 0)));
        }

        [TestMethod]
        public void TestCrossingPointsSuperposed()
        {
            // Cas un peu particulier, les cercles se superposent don se croisent, mais on ne calcule pas de points de croisement car il y en une infinité

            Circle c1 = new Circle(new RealPoint(5, 5), 5);
            Circle c2 = new Circle(new RealPoint(5, 5), 5);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(0, pts.Count);
        }

        [TestMethod]
        public void TestCrossingPointsNeg()
        {
            Circle c1 = new Circle(new RealPoint(-20, -30), 50);
            Circle c2 = new Circle(new RealPoint(-55, -35), 40);

            List<RealPoint> pts = c1.GetCrossingPoints(c2);

            Assert.AreEqual(2, pts.Count);
            Assert.IsTrue(pts.Contains(new RealPoint(-44.49, -73.59)));
            Assert.IsTrue(pts.Contains(new RealPoint(-55.71, 4.99)));
        }

        #endregion
    }
}