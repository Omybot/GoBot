using GoBot.Communications;
using GoBot.Devices;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    public abstract class GoldGrabber
    {
        protected CanServo _servoClamp;
        protected CanServo _servoElevation;

        protected ServoClampGold _posClamp;
        protected ServoElevationGold _posElevation;

        public GoldGrabber()
        {
        }

        public void DoOpen()
        {
            _servoClamp.SetPosition(_posClamp.PositionOpen);
        }

        public void DoClose()
        {
            _servoClamp.SetPosition(_posClamp.PositionClose);
        }

        public void DoUp()
        {
            _servoElevation.SetPosition(_posElevation.PositionApproach);
        }

        public void DoDown()
        {
            _servoElevation.SetPosition(_posElevation.PositionLocking);
        }

        public void DoStore()
        {
            _servoElevation.SetPosition(_posElevation.PositionStored);
        }

        public void DoGrab()
        {
            DoUp();
            Thread.Sleep(500);
            DoOpen();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(150);

            DoDown();
            Thread.Sleep(500);
            DoClose();
            Thread.Sleep(1000);

            DoUp();
            Thread.Sleep(500);
            Robots.GrosRobot.PivotGauche(5);


            Robots.GrosRobot.Reculer(150);
            Robots.GrosRobot.Rapide();

            DoStore();
        }

        public void DoDrop()
        {
            DoUp();
            Thread.Sleep(500);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Avant);
            DoOpen();
            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(100);
            DoClose();

            Config.CurrentConfig.ServoElevationGoldRight.SendPosition(17000);
            Robots.GrosRobot.Recallage(SensAR.Avant);
            Robots.GrosRobot.Reculer(100);

            DoClose();
            DoStore();
            Robots.GrosRobot.Rapide();
        }

        public void DoInit()
        {
            DoUp();
            Thread.Sleep(500);
            DoOpen();
            Thread.Sleep(500);
            DoClose();
            Thread.Sleep(500);
            DoStore();
            Thread.Sleep(500);

            _servoElevation.DisableOutput();
            _servoClamp.DisableOutput();
        }
    }

    public class GoldGrabberLeft : GoldGrabber
    {
        public GoldGrabberLeft()
        {
            _servoClamp = AllDevices.CanServos[ServomoteurID.GoldClampLeft];
            _servoElevation = AllDevices.CanServos[ServomoteurID.GoldElevationLeft];

            _posClamp = Config.CurrentConfig.ServoClampGoldLeft;
            _posElevation = Config.CurrentConfig.ServoElevationGoldLeft;
        }
    }

    public class GoldGrabberRight : GoldGrabber
    {
        public GoldGrabberRight()
        {
            _servoClamp = AllDevices.CanServos[ServomoteurID.GoldClampLeft];
            _servoElevation = AllDevices.CanServos[ServomoteurID.GoldElevationLeft];

            _posClamp = Config.CurrentConfig.ServoClampGoldLeft;
            _posElevation = Config.CurrentConfig.ServoElevationGoldLeft;
        }
    }
}