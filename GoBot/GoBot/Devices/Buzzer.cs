using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications.CAN;

namespace GoBot.Devices
{
    public class Buzzer
    {
        private iCanSpeakable _communication;

        public Buzzer(iCanSpeakable comm)
        {
            _communication = comm;
        }

        public void Buzz(int freqHz, int durationMs)
        {
            _communication.SendFrame(CanFrameFactory.BuildBeep(CanBoard.CanAlim, freqHz, durationMs));
        }
    }
}
