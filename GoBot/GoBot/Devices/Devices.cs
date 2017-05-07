using GoBot.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    static class Devices
    {
        private static RecGoBot recGoBot;

        public static void Init()
        {
            recGoBot = new RecGoBot(Connexions.ConnexionGB);
        }

        public static RecGoBot RecGoBot
        {
            get
            {
                return recGoBot;
            }
        }
    }
}
