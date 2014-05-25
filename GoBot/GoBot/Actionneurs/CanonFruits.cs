using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneur
{
    public static class CanonFruits
    {
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
            if (tempo)
                Thread.Sleep(500);
        }

        public static void Baisser()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCanonInclinaison, 700);
        }

        public static void Monter()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCanonInclinaison, 800);
        }
    }
}
