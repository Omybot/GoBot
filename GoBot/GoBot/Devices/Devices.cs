using GoBot.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    static class Devices
    {
        private static RecGoBot _recGoBot;
        private static ServosCan _servosCan;

        public static void Init()
        {
            _recGoBot = new RecGoBot(Board.RecGB);
            _servosCan = new ServosCan(Board.RecCan);
        }

        public static RecGoBot RecGoBot
        {
            get
            {
                return _recGoBot;
            }
        }

        public static ServosCan ServosCan
        {
            get
            {
                return _servosCan;
            }
        }
    }
}
