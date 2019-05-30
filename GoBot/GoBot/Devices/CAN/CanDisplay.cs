using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications.CAN;
using GoBot.Threading;
using System.Threading;

namespace GoBot.Devices.CAN
{
    /// <summary>
    /// Représente un afficheur LCD sur le bus CAN
    /// </summary>
    class CanDisplay
    {
        private iCanSpeakable _communication;
        private ThreadLink _loopSend;

        private int _lastSendedScore, _currentScore;

        public CanDisplay(iCanSpeakable comm)
        {
            _communication = comm;

            if (!Execution.DesignMode)
            {
                Plateau.ScoreChange += Plateau_ScoreChange;
                _loopSend = ThreadManager.CreateThread(link =>
                {
                    // Dans une boucle qui évite de spammer la carte qui ne bufferise pas les trames
                    if (_lastSendedScore != _currentScore)
                    {
                        _communication.SendFrame(CanFrameFactory.BuildSetScore(_currentScore));
                        _lastSendedScore = _currentScore;
                    }
                });
                _loopSend.Name = "Affichage score";
                _loopSend.StartInfiniteLoop(500);
            }
        }

        public void SetScore(int score)
        {
            _currentScore = score;
        }

        private void Plateau_ScoreChange(int score)
        {
            SetScore(score);
        }
    }
}
