using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices.CAN
{
    /// <summary>
    /// Représente un afficheur LCD sur le bus CAN
    /// </summary>
    class CanDisplay
    {
        private iCanSpeakable _communication;

        public CanDisplay(iCanSpeakable comm)
        {
            _communication = comm;

            if (!Execution.DesignMode)
            {
                Plateau.ScoreChange += Plateau_ScoreChange;
            }
        }

        public void SetScore(int score)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetScore(score), false);
        }

        private void Plateau_ScoreChange(object sender, EventArgs e)
        {
            SetScore(Plateau.Score);
        }
    }
}
