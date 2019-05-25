using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class GoldGrabber
    {
        public void DoRightOpen()
        {
            Config.CurrentConfig.ServoClampGoldRight.SendPosition(Config.CurrentConfig.ServoClampGoldRight.PositionOpen);
        }

        public void DoRightClose()
        {
            Config.CurrentConfig.ServoClampGoldRight.SendPosition(Config.CurrentConfig.ServoClampGoldRight.PositionClose);
        }

        public void DoRightUp()
        {
            Config.CurrentConfig.ServoElevationGoldRight.SendPosition(Config.CurrentConfig.ServoElevationGoldRight.PositionApproach);
        }

        public void DoRightDown()
        {
            Config.CurrentConfig.ServoElevationGoldRight.SendPosition(Config.CurrentConfig.ServoElevationGoldRight.PositionLocking);
        }

        public void DoRightStore()
        {
            Config.CurrentConfig.ServoElevationGoldRight.SendPosition(Config.CurrentConfig.ServoElevationGoldRight.PositionStored);
        }

        public void DoGrabRight()
        {
            DoRightUp();
            Thread.Sleep(500);
            DoRightOpen();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(150);

            DoRightDown();
            Thread.Sleep(500);
            DoRightClose();
            Thread.Sleep(1000);

            DoRightUp();
            Thread.Sleep(500);
            Robots.GrosRobot.PivotGauche(5);


            Robots.GrosRobot.Reculer(150);
            Robots.GrosRobot.Rapide();

            DoRightStore();
        }

        public void DoDropRight()
        {
            DoRightUp();
            Thread.Sleep(500);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Avant);
            DoRightOpen();
            Thread.Sleep(500);
            Robots.GrosRobot.Reculer(100);
            DoRightClose();

            Config.CurrentConfig.ServoElevationGoldRight.SendPosition(17000);
            Robots.GrosRobot.Recallage(SensAR.Avant);
            Robots.GrosRobot.Reculer(100);

            DoRightClose();
            DoRightStore();
            Robots.GrosRobot.Rapide();
        }
    }
}
