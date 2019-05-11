using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class AtomHandler
    {
        public void DoOpen()
        {
            Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionOpen);
            Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionOpen);
        }

        public void DoClose()
        {
            Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionClose);
            Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionClose);
        }

        public void DoFree()
        {
            Config.CurrentConfig.ServoClampLeft.SendPosition(Config.CurrentConfig.ServoClampLeft.PositionFree);
            Config.CurrentConfig.ServoClampRight.SendPosition(Config.CurrentConfig.ServoClampRight.PositionFree);
        }

        public void DoUp()
        {
            Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionInside);
        }

        public void DoDown()
        {
            Config.CurrentConfig.ServoElevation.SendPosition(Config.CurrentConfig.ServoElevation.PositionGround);
        }

        public void DoSwallow()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSwallow);
        }

        public void DoSpit()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSpit);
        }

        public void DoStop()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionStop);
        }

        public void DoGrab()
        {
            Actionneur.AtomStacker.DoPrepareFingerFront();

            // TODO le doigt doit se préparer
            DoSwallow();
            DoClose();
            Thread.Sleep(2000);
            DoStop();
            DoUp();
            Thread.Sleep(2000);
            DoFree();

            Actionneur.AtomStacker.DoStoreFingerFront();
            // TODO le doigt doit prendre le palet
            Thread.Sleep(400);
            DoDown();
            Thread.Sleep(400);
            DoFree();
        }
    }
}
