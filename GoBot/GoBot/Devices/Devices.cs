using GoBot.Communications;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    static class Devices
    {
        private static RecGoBot _recGoBot;
        private static CanServos _canServos;
        private static CanDisplay _canDisplay;

        public static void Init()
        {
            _recGoBot = new RecGoBot(Board.RecGB);
            _canServos = new CanServos(Connections.ConnectionCan);
            _canDisplay = new CanDisplay(Connections.ConnectionCan);
        }

        public static RecGoBot RecGoBot
        {
            get
            {
                return _recGoBot;
            }
        }

        public static CanServos CanServos
        {
            get
            {
                return _canServos;
            }
        }
    }
}
