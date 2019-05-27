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
    abstract public class AtomUnloader
    {
        protected CanServo _servoUnloader;
        protected CanServo _servoCalibration;
        protected CanServo _servoExitLauncher;
        protected CanServo _servoLauncher;

        protected ServoUnloader _posUnloader;
        protected ServoCalibration _posCalibration;
        protected ServoExitLauncher _posExitLauncher;
        protected ServoLauncher _posLauncher;

        public AtomUnloader()
        {
            _servoUnloader = AllDevices.CanServos[ServomoteurID.Unloader];

            _posUnloader = Config.CurrentConfig.ServoUnloader;
        }

        public void DoUnloaderStore()
        {
            _servoUnloader.SetPosition(_posUnloader.PositionStore);
        }

        public void DoUnloaderDock()
        {
            _servoUnloader.SetPosition(_posUnloader.PositionDocking);
        }

        public void DoUnloaderUnload()
        {
            _servoUnloader.SetPosition(_posUnloader.PositionUnload);
        }

        public void DoCalibrationExit()
        {
            _servoCalibration.SetPosition(_posCalibration.PositionCalibration);
        }

        public void DoCalibrationStore()
        {
            _servoCalibration.SetPosition(_posCalibration.PositionStored);
        }

        public void DoLauncherOutside()
        {
            _servoExitLauncher.SetPosition(_posExitLauncher.PositionOutside);
        }

        public void DoLauncherInside()
        {
            _servoExitLauncher.SetPosition(_posExitLauncher.PositionInside);
        }

        public void DoLauncherLaunch()
        {
            _servoLauncher.SetPosition(_posLauncher.PositionLaunch);
        }

        public void DoLauncherPrepare()
        {
            _servoLauncher.SetPosition(_posLauncher.PositionStored);
        }
        
        public void DoInit()
        {
            DoUnloaderDock();
            Thread.Sleep(500);
            DoUnloaderStore();
            Thread.Sleep(500);

            DoCalibrationExit();
            Thread.Sleep(500);
            DoCalibrationStore();
            Thread.Sleep(500);

            DoLauncherOutside();
            Thread.Sleep(500);
            DoLauncherLaunch();
            Thread.Sleep(500);
            DoLauncherPrepare();
            Thread.Sleep(500);
            DoLauncherInside();
            Thread.Sleep(500);
            
            _servoCalibration.DisableOutput();
            _servoExitLauncher.DisableOutput();
            _servoLauncher.DisableOutput();
            _servoUnloader.DisableOutput();
        }

        public void DoLaunchPalet()
        {
            DoUnloaderDock();
            DoCalibrationExit();
            DoLauncherOutside();
            Robots.GrosRobot.Lent();

            Thread.Sleep(1000);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            
            Actionneur.AtomStacker.MoveFingerBack(0, true);
            Actionneur.AtomStacker.MoveFingerBack(17, false);

            DoLauncherLaunch();
            Thread.Sleep(1000);
            DoLauncherPrepare();
            Thread.Sleep(1000);
            DoLauncherInside();
        }
    }

    public class AtomUnloaderLeft : AtomUnloader
    {
        public AtomUnloaderLeft()
        {
            _servoCalibration = AllDevices.CanServos[ServomoteurID.CalibrationLeft];
            _servoExitLauncher = AllDevices.CanServos[ServomoteurID.ExitLauncherLeft];
            _servoLauncher = AllDevices.CanServos[ServomoteurID.LauncherLeft];

            _posCalibration = Config.CurrentConfig.ServoCalibrationLeft;
            _posLauncher = Config.CurrentConfig.ServoLauncherLeft;
            _posExitLauncher = Config.CurrentConfig.ServoExitLauncherLeft;
        }
    }

    public class AtomUnloaderRight : AtomUnloader
    {
        public AtomUnloaderRight()
        {
            _servoCalibration = AllDevices.CanServos[ServomoteurID.CalibrationRight];
            _servoExitLauncher = AllDevices.CanServos[ServomoteurID.ExitLauncherRight];
            _servoLauncher = AllDevices.CanServos[ServomoteurID.LauncherRight];
            
            _posCalibration = Config.CurrentConfig.ServoCalibrationRight;
            _posLauncher = Config.CurrentConfig.ServoLauncherRight;
            _posExitLauncher = Config.CurrentConfig.ServoExitLauncherRight;
        }
    }
}
