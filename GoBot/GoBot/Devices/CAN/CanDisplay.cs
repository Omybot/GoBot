using GoBot.Communications.CAN;
using GoBot.Threading;
using GoBot.BoardContext;

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
                GameBoard.ScoreChange += Plateau_ScoreChange;
                
                // Dans une boucle qui évite de spammer la carte qui ne bufferise pas les trames
                _loopSend = ThreadManager.CreateThread(link => SendScore());
                _loopSend.Name = "Envoi du score";
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

        private void SendScore()
        {
            if (_lastSendedScore != _currentScore)
            {
                _communication.SendFrame(CanFrameFactory.BuildSetScore(_currentScore));
                _lastSendedScore = _currentScore;
            }
        }
    }
}
