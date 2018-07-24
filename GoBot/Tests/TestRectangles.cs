using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoBot.Geometry.Shapes;

namespace Tests
{
    [TestClass]
    public class TestRectangle
    {

        [TestMethod]
        public void TestRectangleEqual()
        {
            Polygon r0 = new PolygonRectangle(new RealPoint(0, 0), 0, 0);

            Assert.AreEqual(r0, r0);
            Assert.AreEqual(r0, r0.Rotation(90));
            Assert.AreEqual(r0, r0.Rotation(-180));
            Assert.AreEqual(r0, r0.Rotation(-90));

            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 100, 100);
            Polygon r2 = new PolygonRectangle(new RealPoint(0, 0), 100, 100);

            Assert.AreEqual(r1, r1);
            Assert.AreEqual(r1, r2);
            Assert.AreEqual(r1, r2.Rotation(90));
            Assert.AreEqual(r1, r2.Rotation(180));
            Assert.AreEqual(r1, r2.Rotation(-90));

            r1 = new PolygonRectangle(new RealPoint(10, 10), 100, 100);
            r2 = new PolygonRectangle(new RealPoint(10, 10), 100, 100);

            Assert.AreEqual(r1, r1);
            Assert.AreEqual(r1, r2);
            Assert.AreEqual(r1, r2.Rotation(90));
            Assert.AreEqual(r1, r2.Rotation(180));
            Assert.AreEqual(r1, r2.Rotation(-90));

            r1 = new PolygonRectangle(new RealPoint(-10, -10), -100, -100);
            r2 = new PolygonRectangle(new RealPoint(-10, -10), -100, -100);

            Assert.AreEqual(r1, r1);
            Assert.AreEqual(r1, r2);
            Assert.AreEqual(r1, r2.Rotation(90));
            Assert.AreEqual(r1, r2.Rotation(180));
            Assert.AreEqual(r1, r2.Rotation(-90));
        }

        [TestMethod]
        public void TestRectangleDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            // Test avec segments confondus
            Segment s11 = new Segment( new RealPoint(0, 0), new RealPoint(0, 10) );
            Segment s12 = new Segment(new RealPoint(0, 10), new RealPoint(10, 10));
            Segment s13 = new Segment(new RealPoint(10, 10), new RealPoint(10, 0));
            Segment s14 = new Segment(new RealPoint(10, 0), new RealPoint(0, 0));

            Assert.AreEqual(0, r1.Distance(s11));
            Assert.AreEqual(0, r1.Distance(s12));
            Assert.AreEqual(0, r1.Distance(s13));
            Assert.AreEqual(0, r1.Distance(s14));

            // Test avec segments décales
            Segment s21 = new Segment(new RealPoint(20, 0), new RealPoint(20, 10));
            Segment s22 = new Segment(new RealPoint(-10, 0), new RealPoint(-10, 10));
            Segment s23 = new Segment(new RealPoint(0, -10), new RealPoint(10, -10));
            Segment s24 = new Segment(new RealPoint(0, 20), new RealPoint(10, 20));

            Assert.AreEqual(10, r1.Distance(s21));
            Assert.AreEqual(10, r1.Distance(s22));
            Assert.AreEqual(10, r1.Distance(s23));
            Assert.AreEqual(10, r1.Distance(s24));
        }
    }
}
