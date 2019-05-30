using GoBot.Communications;
using GoBot.Devices;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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

        protected byte _maskSensor;

        protected bool _loaded;
        protected bool _needCalibration;

        public GoldGrabber()
        {
            _loaded = false;
            _needCalibration = false;
        }

        public bool Loaded { get => _loaded; set => _loaded = value; }
        public bool NeedCalibration { get => _needCalibration; set => _needCalibration = value; }

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

        public bool GoldIsPresent()
        {
            Robots.GrosRobot.DemandeValeursNumeriques(Board.RecMove, true);
            return (Robots.GrosRobot.ValeursNumeriques[Board.RecMove][2] & _maskSensor) > 0;
        }

        public void DoDetect()
        {
            if (GoldIsPresent())
                MessageBox.Show("Oui");
            else
                MessageBox.Show("Non");
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

            _servoElevation.DisableOutput(1000);
            _servoClamp.DisableOutput(1000);
            _servoWiper.DisableOutput(1000);
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

            _maskSensor = 0b01000000;
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

            _maskSensor = 0b00100000;
        }
    }
}