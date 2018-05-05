using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoBot.Actionneurs
{
    class Harvester
    {
        public enum Arm : byte
        {
            Left,
            Rigth
        }

        public void DoLeftPumpEnable()
        {
            Config.CurrentConfig.MoteurPompeGauche.SendPosition(Config.CurrentConfig.MoteurPompeGauche.PositionAspire);
            Config.CurrentConfig.ValveGauche.SendPosition(Config.CurrentConfig.ValveGauche.PositionFerme);
        }

        public void DoLeftPumpDisable()
        {
            Config.CurrentConfig.MoteurPompeGauche.SendPosition(Config.CurrentConfig.MoteurPompeGauche.PositionStop);
            Config.CurrentConfig.ValveGauche.SendPosition(Config.CurrentConfig.ValveGauche.PositionOuvert);
            ThreadManager.CreateThread(link =>
            {
                Thread.Sleep(500);
                Config.CurrentConfig.ValveGauche.SendPosition(Config.CurrentConfig.ValveGauche.PositionFerme);
            }).StartThread();
        }

        public void DoRightPumpEnable()
        {
            Config.CurrentConfig.MoteurPompeDroite.SendPosition(Config.CurrentConfig.MoteurPompeDroite.PositionAspire);
            Config.CurrentConfig.ValveDroite.SendPosition(Config.CurrentConfig.ValveDroite.PositionFerme);
        }

        public void DoRightPumpDisable()
        {
            Config.CurrentConfig.MoteurPompeDroite.SendPosition(Config.CurrentConfig.MoteurPompeDroite.PositionStop);
            Config.CurrentConfig.ValveDroite.SendPosition(Config.CurrentConfig.ValveDroite.PositionOuvert); ThreadManager.CreateThread(link =>
            {
                Thread.Sleep(500);
                Config.CurrentConfig.ValveDroite.SendPosition(Config.CurrentConfig.ValveDroite.PositionFerme);
            }).StartThread();
        }

        public void DoLeftArmOnLeftCube()
        {

        }

        public void DoLeftArmOnStorage()
        {

        }

        public void DoLeftArmOnCenterCube()
        {

        }

        public void DoRightArmOnRightCube()
        {

        }

        public void DoRightArmOnCenterCube()
        {

        }

        public void DoRightArmOnLeftCube()
        {

        }

        public void DoRightArmInLeftSlot()
        {

        }

        public void DoRightArmInCenterSlot()
        {

        }

        public void DoRightArmInRightSlot()
        {

        }

        public void DoLeftArmInLeftSlot()
        {

        }

        public void DoLeftArmInCenterSlot()
        {

        }
    }
}
