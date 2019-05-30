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
        protected CanServo _servoWiper;

        protected ServoClampGold _posClamp;
        protected ServoElevationGold _posElevation;
        protected ServoWiper _posWiper;

        protected bool _loaded;

        public GoldGrabber()
        {
            _loaded = false;
        }

        public bool Loaded { get => _loaded; set => _loaded = value; }

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
            DoWiperSide();
            Thread.Sleep(250);
            DoWiperStore();
            Thread.Sleep(250);
            DoUp();
            Thread.Sleep(500);
            DoOpen();
            Thread.Sleep(500);
            DoClose();
            Thread.Sleep(500);
            DoStore();
            Thread.Sleep(500);

            _servoElevation.DisableOutput(500);
            _servoClamp.DisableOutput(500);
            _servoWiper.DisableOutput(500);
        }

        public void DoDisableElevation()
        {
            _servoElevation.DisableOutput();
        }

        public void DoCalibEject()
        {
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Avant);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(80);
            Actionneur.GoldGrabberLeft.DoUp();
            Actionneur.GoldGrabberRight.DoUp();
            Thread.Sleep(700);
            Robots.GrosRobot.Reculer(100);
            Actionneur.GoldGrabberLeft.DoStore();
            Actionneur.GoldGrabberRight.DoStore();
        }

        public void DoWiperStore()
        {
            _servoWiper.SetPosition(_posWiper.PositionStore);
        }

        public void DoWiperSide()
        {
            _servoWiper.SetPosition(_posWiper.PositionSide);
        }
    }

    public class GoldGrabberLeft : GoldGrabber
    {
        public GoldGrabberLeft()
        {
            _servoClamp = AllDevices.CanServos[ServomoteurID.GoldClampLeft];
            _servoElevation = AllDevices.CanServos[ServomoteurID.GoldElevationLeft];
            _servoWiper = AllDevices.CanServos[ServomoteurID.WiperLeft];

            _posClamp = Config.CurrentConfig.ServoClampGoldLeft;
            _posElevation = Config.CurrentConfig.ServoElevationGoldLeft;
            _posWiper = Config.CurrentConfig.ServoWiperLeft;
        }
    }

    public class GoldGrabberRight : GoldGrabber
    {
        public GoldGrabberRight()
        {
            _servoClamp = AllDevices.CanServos[ServomoteurID.GoldClampRight];
            _servoElevation = AllDevices.CanServos[ServomoteurID.GoldElevationRight];
            _servoWiper = AllDevices.CanServos[ServomoteurID.WiperRight];

            _posClamp = Config.CurrentConfig.ServoClampGoldRight;
            _posElevation = Config.CurrentConfig.ServoElevationGoldRight;
            _posWiper = Config.CurrentConfig.ServoWiperRight;
        }
    }
}