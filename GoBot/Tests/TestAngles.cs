using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoBot.Geometry;

namespace Tests
{
    [TestClass]
    public class TestAngles
    {
        [TestMethod]
        public void TestAngleDeltaDegRad()
        {
            AngleDelta deg = new AngleDelta(720, AngleType.Degre);
            AngleDelta rad = new AngleDelta(Math.PI * 4, AngleType.Radian);

            Assert.AreEqual(deg, rad);
            Assert.AreEqual(deg, 720, AngleDelta.PRECISION);
        }

        [TestMethod]
        public void TestAngleDeltaTrigo()
        {
            double a = Math.PI / 2.54; // Arbitraire

            AngleDelta deg = new AngleDelta(a, AngleType.Radian);

            Assert.AreEqual(Math.Cos(a), deg.Cos, AngleDelta.PRECISION);
            Assert.AreEqual(Math.Sin(a), deg.Sin, AngleDelta.PRECISION);
            Assert.AreEqual(Math.Tan(a), deg.Tan, AngleDelta.PRECISION);
        }

        [TestMethod]
        public void TestAngleDeltaModulo()
        {
            Assert.AreEqual(10, new AngleDelta(10).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(10, new AngleDelta(370).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(0, new AngleDelta(0).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(180, new AngleDelta(180).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(-180, new AngleDelta(-180).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(0, new AngleDelta(360).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(-10, new AngleDelta(-10).Modulo(), AngleDelta.PRECISION);
            Assert.AreEqual(170, new AngleDelta(-190).Modulo(), AngleDelta.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionDegRad()
        {
            AnglePosition deg = new AnglePosition(90, AngleType.Degre);
            AnglePosition rad = new AnglePosition(Math.PI / 2, AngleType.Radian);

            Assert.AreEqual(deg, rad);
            Assert.AreEqual(deg, 90, AnglePosition.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionModulo()
        {
            AnglePosition a800 = new AnglePosition(800, AngleType.Degre);
            AnglePosition a80 = new AnglePosition(80, AngleType.Degre);

            Assert.AreEqual(a800, a80);
            Assert.AreEqual(80, a800.InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(80, a800.InPositiveDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(80.0 / 180.0 * Math.PI, a800.InRadians, AnglePosition.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionNeg()
        {
            AnglePosition a = new AnglePosition(-50, AngleType.Degre);

            Assert.AreEqual(-50, a.InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(310, a.InPositiveDegrees, AnglePosition.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionAdd()
        {
            AnglePosition a10 = new AnglePosition(10);
            AnglePosition a190 = new AnglePosition(190);
            AnglePosition a350 = new AnglePosition(350);
            AngleDelta da10 = new AngleDelta(10);
            AngleDelta da80 = new AngleDelta(80);
            AngleDelta da20 = new AngleDelta(20);

            Assert.AreEqual(0, (a350 + da10).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(10, (a350 + da20).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(-90, (a190 + da80).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(20, (a10 + da10).InDegrees, AnglePosition.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionSub1()
        {
            AnglePosition a30 = new AnglePosition(30);
            AnglePosition a350 = new AnglePosition(350);
            AngleDelta da30 = new AngleDelta(30);
            AngleDelta da350 = new AngleDelta(350);

            Assert.AreEqual(40, (a30 - da350).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(-40, (a350 - da30).InDegrees, AnglePosition.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionSub2()
        {
            AnglePosition a0 = new AnglePosition(0);
            AnglePosition a30 = new AnglePosition(30);
            AnglePosition a60 = new AnglePosition(60);
            AnglePosition a89 = new AnglePosition(89);
            AnglePosition a90 = new AnglePosition(90);
            AnglePosition a91 = new AnglePosition(91);
            AnglePosition a270 = new AnglePosition(270);
            AnglePosition a350 = new AnglePosition(350);
            AnglePosition a360 = new AnglePosition(360);

            Assert.AreEqual(-40, (a350 - a30).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(40, (a30 - a350).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(30, (a90 - a60).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(-30, (a60 - a90).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(0, (a0 - a360).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(180, (a90 - a270).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(-179, (a91 - a270).InDegrees, AnglePosition.PRECISION);
            Assert.AreEqual(179, (a89 - a270).InDegrees, AnglePosition.PRECISION);
        }

        [TestMethod]
        public void TestAnglePositionEqual()
        {
            AnglePosition a1, a2;

            a1 = new AnglePosition(90);
            a2 = new AnglePosition(90);
            Assert.AreEqual(a1, a2);

            a1 = new AnglePosition(0);
            a2 = new AnglePosition(0);
            Assert.AreEqual(a1, a2);

            a1 = new AnglePosition(-10);
            a2 = new AnglePosition(350);
            Assert.AreEqual(a1, a2);

            a1 = new AnglePosition(0);
            a2 = new AnglePosition(360);
            Assert.AreEqual(a1, a2);

            a1 = new AnglePosition(90);
            a2 = new AnglePosition(-270);
            Assert.AreEqual(a1, a2);
        }

        [TestMethod]
        public void TestAnglePositionNotEqual()
        {
            AnglePosition a1, a2;

            a1 = new AnglePosition(85);
            a2 = new AnglePosition(86);
            Assert.AreNotEqual(a1, a2);

            a1 = new AnglePosition(0);
            a2 = new AnglePosition(359);
            Assert.AreNotEqual(a1, a2);
        }

        [TestMethod]
        public void TestAnglePositionCenter()
        {
            Assert.AreEqual(45, AnglePosition.Center(0, 90));
            Assert.AreEqual(45 + 180, AnglePosition.CenterLongArc(0, 90));
            Assert.AreEqual(45, AnglePosition.CenterSmallArc(0, 90));

            Assert.AreEqual(45 + 180, AnglePosition.Center(90, 0));
            Assert.AreEqual(45 + 180, AnglePosition.CenterLongArc(90, 0));
            Assert.AreEqual(45, AnglePosition.CenterSmallArc(90, 0));

            Assert.AreEqual(30, AnglePosition.Center(-20, 80));
            Assert.AreEqual(30 + 180, AnglePosition.CenterLongArc(-20, 80));
            Assert.AreEqual(30, AnglePosition.CenterSmallArc(-20, 80));

            Assert.AreEqual(30 + 180, AnglePosition.Center(80, -20));
            Assert.AreEqual(30 + 180, AnglePosition.CenterLongArc(80, -20));
            Assert.AreEqual(30, AnglePosition.CenterSmallArc(80, -20));

            Assert.AreEqual(175, AnglePosition.Center(80, 270));
            Assert.AreEqual(175, AnglePosition.CenterLongArc(80, 270));
            Assert.AreEqual(175 + 180, AnglePosition.CenterSmallArc(80, 270));

            Assert.AreEqual(175 + 180, AnglePosition.Center(270, 80));
            Assert.AreEqual(175, AnglePosition.CenterLongArc(270, 80));
            Assert.AreEqual(175 + 180, AnglePosition.CenterSmallArc(270, 80));
        }

        [TestMethod]
        public void TestAnglePositionIsOnArc()
        {
            Assert.IsTrue(((AnglePosition)45).IsOnArc(0, 90));
            Assert.IsTrue(((AnglePosition)0).IsOnArc(0, 90));
            Assert.IsTrue(((AnglePosition)90).IsOnArc(0, 90));
            Assert.IsFalse(((AnglePosition)91).IsOnArc(0, 90));
            Assert.IsFalse(((AnglePosition)(-50)).IsOnArc(0, 90));

            Assert.IsFalse(((AnglePosition)45).IsOnArc(90, 0));
            Assert.IsTrue(((AnglePosition)0).IsOnArc(90, 0));
            Assert.IsTrue(((AnglePosition)90).IsOnArc(90, 0));
            Assert.IsTrue(((AnglePosition)91).IsOnArc(90, 0));
            Assert.IsTrue(((AnglePosition)(-50)).IsOnArc(90, 0));

            Assert.IsTrue(((AnglePosition)0).IsOnArc(-20, 20));
            Assert.IsFalse(((AnglePosition)(-40)).IsOnArc(-20, 20));

            Assert.IsFalse(((AnglePosition)0).IsOnArc(20, -20));
            Assert.IsTrue(((AnglePosition)(-40)).IsOnArc(20, -20));
        }
    }
}
