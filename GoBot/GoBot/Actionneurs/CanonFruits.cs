using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    public static class CanonFruits
    {
        public static bool FruitComestible { get; set; }

        public static void Armer()
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRCanonPuissance, true);
        }

        public static void PousseBouchon()
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, true);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, false);
            Thread.Sleep(500);
        }

        public static void Tirer(bool tempo = true)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRCanonFruit, true);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            if (tempo)
                Thread.Sleep(1000);
            //Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRCanonPuissance, true);
        }

        public static void Baisser()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCanonInclinaison, 700);
        }

        public static void Monter()
        {
#if false 
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCanonInclinaison, 800);
#else //kudo
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCanonInclinaison, 750);
#endif
        }
    }
}
