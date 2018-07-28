using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Shapes;

namespace GeometryTester
{
    [TestClass]
    public class TestRectangle
    {
        [TestMethod]                // Test bidon histoire de charger les librairies et vérifier temps execution des tests suivants
        public void DummyTest()
        {
            Polygon r0 = new PolygonRectangle(new RealPoint(0, 0), 0, 0);
            Assert.AreEqual(r0, r0.Rotation(90));
        }

        // Tests d'égalité entre plusieurs rectangles
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

        // Tests de distance entre rectangles et segments
        [TestMethod]
        public void TestRectangleSegmentDistance()
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

        // Tests de distance entre plusieurs rectangles
        [TestMethod]
        public void TestRectanglesDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            // Polygones décalés vérticalements OU horizontalement + coincidence segment
            Polygon r11 = new PolygonRectangle(new RealPoint(10, 0), 10, 10);
            Polygon r12 = new PolygonRectangle(new RealPoint(-10, 0), 10, 10);
            Polygon r13 = new PolygonRectangle(new RealPoint(0, 10), 10, 10);
            Polygon r14 = new PolygonRectangle(new RealPoint(0, -10), 10, 10);

            Assert.AreEqual(0, r1.Distance(r11));
            Assert.AreEqual(0, r1.Distance(r12));
            Assert.AreEqual(0, r1.Distance(r13));
            Assert.AreEqual(0, r1.Distance(r14));

            // Polygones décalés vérticalements ou horizontalement + coincidence coin
            Polygon r21 = new PolygonRectangle(new RealPoint(10, 0), 10, 10);
            Polygon r22 = new PolygonRectangle(new RealPoint(-10, 0), 10, 10);
            Polygon r23 = new PolygonRectangle(new RealPoint(0, 10), 10, 10);
            Polygon r24 = new PolygonRectangle(new RealPoint(0, -10), 10, 10);

            Assert.AreEqual(0, r1.Distance(r21));
            Assert.AreEqual(0, r1.Distance(r22));
            Assert.AreEqual(0, r1.Distance(r23));
            Assert.AreEqual(0, r1.Distance(r24));

            // Polygones décalés vérticalements ET horizontalement
            Polygon r31 = new PolygonRectangle(new RealPoint(20, 20), 10, 10);
            Polygon r32 = new PolygonRectangle(new RealPoint(-20, -20), 10, 10);
            Polygon r33 = new PolygonRectangle(new RealPoint(-20, -20), 10, 10);

            Assert.AreEqual( Math.Sqrt(10*10+10*10), r1.Distance(r31));
            Assert.AreEqual( Math.Sqrt(10*10+10*10), r1.Distance(r32));

        }

        // Tests de distance entre plusieurs rectangles qui se croisent
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

        // Tests de distance entre rectangle et Cercle
        [TestMethod]
        public void TestRectangleAndCircleDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            Circle c11 = new Circle(new RealPoint(0, 0), 10);

            Assert.AreEqual(0, r1.Distance(c11));
            Assert.AreEqual(0, c11.Distance(r1));

        }

        // Tests de distance entre rectangle et Cercle imbriqués
        [TestMethod]
        public void TestCrossRectangleAndCircleDistance()
        {
            Polygon r1 = new PolygonRectangle(new RealPoint(0, 0), 10, 10);

            Circle c11 = new Circle( new RealPoint(5, 5), 2 );

            Assert.AreEqual(0, r1.Distance(c11));
            Assert.AreEqual(0, c11.Distance(r1));

        }

    }
}
