using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class AtomUnloader
    {


        public void DoUnloaderStore()
        {
            Config.CurrentConfig.ServoUnloader.SendPosition(Config.CurrentConfig.ServoUnloader.PositionStore);
        }

        public void DoUnloaderDock()
        {
            Config.CurrentConfig.ServoUnloader.SendPosition(Config.CurrentConfig.ServoUnloader.PositionDocking);
        }

        public void DoUnloaderUnload()
        {
            Config.CurrentConfig.ServoUnloader.SendPosition(Config.CurrentConfig.ServoUnloader.PositionUnload);
        }

        public void DoCalibrationLeftExit()
        {
            Config.CurrentConfig.ServoCalibrationLeft.SendPosition(Config.CurrentConfig.ServoCalibrationLeft.PositionCalibration);
        }

        public void DoCalibrationLeftStore()
        {
            Config.CurrentConfig.ServoCalibrationLeft.SendPosition(Config.CurrentConfig.ServoCalibrationLeft.PositionStored);
        }

        public void DoLauncherLeftOutside()
        {
            Config.CurrentConfig.ServoExitLauncherLeft.SendPosition(Config.CurrentConfig.ServoExitLauncherLeft.PositionOutside);
        }

        public void DoLauncherLeftInside()
        {
            Config.CurrentConfig.ServoExitLauncherLeft.SendPosition(Config.CurrentConfig.ServoExitLauncherLeft.PositionInside);
        }

        public void DoLauncherLeftLaunch()
        {
            Config.CurrentConfig.ServoLauncherLeft.SendPosition(Config.CurrentConfig.ServoLauncherLeft.PositionLaunch);
        }

        public void DoLauncherLeftStore()
        {
            Config.CurrentConfig.ServoLauncherLeft.SendPosition(Config.CurrentConfig.ServoLauncherLeft.PositionStored);
        }



        public void DoCalibrationRightExit()
        {
            Config.CurrentConfig.ServoCalibrationRight.SendPosition(Config.CurrentConfig.ServoCalibrationRight.PositionCalibration);
        }

        public void DoCalibrationRightStore()
        {
            Config.CurrentConfig.ServoCalibrationRight.SendPosition(Config.CurrentConfig.ServoCalibrationRight.PositionStored);
        }

        public void DoLauncherRightOutside()
        {
            Config.CurrentConfig.ServoExitLauncherRight.SendPosition(Config.CurrentConfig.ServoExitLauncherRight.PositionOutside);
        }

        public void DoLauncherRightInside()
        {
            Config.CurrentConfig.ServoExitLauncherRight.SendPosition(Config.CurrentConfig.ServoExitLauncherRight.PositionInside);
        }

        public void DoLauncherRightLaunch()
        {
            Config.CurrentConfig.ServoLauncherRight.SendPosition(Config.CurrentConfig.ServoLauncherRight.PositionLaunch);
        }

        public void DoLauncherRightStore()
        {
            Config.CurrentConfig.ServoLauncherRight.SendPosition(Config.CurrentConfig.ServoLauncherRight.PositionStored);
        }

        public void DoInit()
        {
            DoCalibrationLeftExit();
            Thread.Sleep(500);
            DoCalibrationLeftStore();
            Thread.Sleep(500);

            DoLauncherLeftOutside();
            Thread.Sleep(500);
            DoLauncherLeftLaunch();
            Thread.Sleep(500);
            DoLauncherLeftStore();
            Thread.Sleep(500);
            DoLauncherLeftInside();
            Thread.Sleep(500);

            DoUnloaderDock();
            Thread.Sleep(500);
            DoUnloaderStore();
            Thread.Sleep(500);

            DoLauncherRightOutside();
            Thread.Sleep(500);
            DoLauncherRightLaunch();
            Thread.Sleep(500);
            DoLauncherRightStore();
            Thread.Sleep(500);
            DoLauncherRightInside();
            Thread.Sleep(500);

            DoCalibrationRightExit();
            Thread.Sleep(500);
            DoCalibrationRightStore();
            Thread.Sleep(500);

            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoCalibrationLeft.ID].DisableOutput();
            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoCalibrationRight.ID].DisableOutput();

            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoExitLauncherLeft.ID].DisableOutput();
            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoExitLauncherRight.ID].DisableOutput();

            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoLauncherLeft.ID].DisableOutput();
            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoLauncherRight.ID].DisableOutput();

            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoUnloader.ID].DisableOutput();
        }

        public void DoLaunchPalet()
        {
            DoUnloaderDock();
            DoCalibrationLeftExit();
            DoLauncherLeftOutside();
            Robots.GrosRobot.Lent();
            Thread.Sleep(1000);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            
            Actionneur.AtomStacker.MoveFingerBack(0, true);
            Actionneur.AtomStacker.MoveFingerBack(17, false);

            DoLauncherLeftLaunch();
            Thread.Sleep(1000);
            DoLauncherLeftStore();
            Thread.Sleep(1000);
            DoLauncherLeftInside();
        }
    }
}
