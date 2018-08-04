using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Shapes;

namespace GeometryTester
{
    [TestClass]
    public class TestRectangleWithSegment
    {
        #region Contains

        [TestMethod]
        public void TestRectangleContainsSegmentDiagonal()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 10), 10, 20);

            Segment s1 = new Segment(new RealPoint(10, 10), new RealPoint(10, 20));

            Assert.IsTrue(r1.Contains(s1));

        }

        [TestMethod]
        public void TestRectangleContainsSegmentLine()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 10), 10, 20);

            Segment s1 = new Segment(new RealPoint(10, 10), new RealPoint(20, 10));
            Segment s2 = new Segment(new RealPoint(20, 10), new RealPoint(20, 30));
            Segment s3 = new Segment(new RealPoint(20, 30), new RealPoint(10, 30));
            Segment s4 = new Segment(new RealPoint(10, 30), new RealPoint(10, 10));

            Assert.IsTrue(r1.Contains(s1));
            Assert.IsTrue(r1.Contains(s2));
            Assert.IsTrue(r1.Contains(s3));
            Assert.IsTrue(r1.Contains(s4));
        }

        [TestMethod]
        public void TestRectangleContainsSegment()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 10), 10, 20);

            Segment s1 = new Segment(new RealPoint(15, 10), new RealPoint(15, 30));
            Segment s2 = new Segment(new RealPoint(10, 20), new RealPoint(20, 20));
            Segment s3 = new Segment(new RealPoint(12, 12), new RealPoint(18, 28));
            Segment s4 = new Segment(new RealPoint(12, 28), new RealPoint(18, 12));

            Assert.IsTrue(r1.Contains(s1));
            Assert.IsTrue(r1.Contains(s2));
            Assert.IsTrue(r1.Contains(s3));
            Assert.IsTrue(r1.Contains(s4));
        }

        [TestMethod]
        public void TestRectangleNotContainsSegment()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(10, 10), 10, 20);

            Segment s1 = new Segment(new RealPoint(5, 10), new RealPoint(15, 30));
            Segment s2 = new Segment(new RealPoint(10, 42), new RealPoint(20, 20));
            Segment s3 = new Segment(new RealPoint(0, 0), new RealPoint(0, 28));
            Segment s4 = new Segment(new RealPoint(-5, 8), new RealPoint(0, -5));
            Segment s5 = new Segment(new RealPoint(-5, 8), new RealPoint(10, 10));

            Assert.IsFalse(r1.Contains(s1));
            Assert.IsFalse(r1.Contains(s2));
            Assert.IsFalse(r1.Contains(s3));
            Assert.IsFalse(r1.Contains(s4));
            Assert.IsFalse(r1.Contains(s5));
        }

        #endregion

        #region Cross

        [TestMethod]
        public void TestRectangleCrossSegment()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            Segment s1 = new Segment(new RealPoint(0, 0), new RealPoint(0, 10));
            Segment s2 = new Segment(new RealPoint(-5, 5), new RealPoint(15, 5));
            Segment s3 = new Segment(new RealPoint(-5, 5), new RealPoint(5, 5));
            Segment s4 = new Segment(new RealPoint(-5, 5), new RealPoint(0, 5));
            Segment s5 = new Segment(new RealPoint(-5, 5), new RealPoint(0, 0));
            Segment s6 = new Segment(new RealPoint(-5, -5), new RealPoint(0, 5));
            Segment s7 = new Segment(new RealPoint(0, 0), new RealPoint(10, 10));

            Assert.IsTrue(r1.Cross(s1));
            Assert.IsTrue(r1.Cross(s2));
            Assert.IsTrue(r1.Cross(s3));
            Assert.IsTrue(r1.Cross(s4));
            Assert.IsTrue(r1.Cross(s5));
            Assert.IsTrue(r1.Cross(s6));
            Assert.IsTrue(r1.Cross(s7));
        }

        #endregion

        #region Distance
        
        [TestMethod]
        public void TestRectangleSegmentDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            // Test avec segments confondus
            Segment s11 = new Segment(new RealPoint(0, 0), new RealPoint(0, 10));
            Segment s12 = new Segment(new RealPoint(0, 10), new RealPoint(10, 10));
            Segment s13 = new Segment(new RealPoint(10, 10), new RealPoint(10, 0));
            Segment s14 = new Segment(new RealPoint(10, 0), new RealPoint(0, 0));

            Assert.AreEqual(0, r1.Distance(s11), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(s12), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(s13), RealPoint.PRECISION);
            Assert.AreEqual(0, r1.Distance(s14), RealPoint.PRECISION);

            // Test avec segments décales
            Segment s21 = new Segment(new RealPoint(20, 0), new RealPoint(20, 10));
            Segment s22 = new Segment(new RealPoint(-10, 0), new RealPoint(-10, 10));
            Segment s23 = new Segment(new RealPoint(0, -10), new RealPoint(10, -10));
            Segment s24 = new Segment(new RealPoint(0, 20), new RealPoint(10, 20));

            Assert.AreEqual(10, r1.Distance(s21), RealPoint.PRECISION);
            Assert.AreEqual(10, r1.Distance(s22), RealPoint.PRECISION);
            Assert.AreEqual(10, r1.Distance(s23), RealPoint.PRECISION);
            Assert.AreEqual(10, r1.Distance(s24), RealPoint.PRECISION);
        }

        #endregion
    }
}
