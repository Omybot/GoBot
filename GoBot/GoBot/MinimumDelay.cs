using System.Diagnostics;
using System.Threading;

namespace GoBot
{
    class MinimumDelay
    {
        private Stopwatch _lastCommandTime;
        private int _delay;

        public MinimumDelay(int delayMs)
        {
            _delay = delayMs;
        }

        public void Wait()
        {
            if (_lastCommandTime != null)
            {
                while (_lastCommandTime.ElapsedMilliseconds < _delay)
                    Thread.Sleep(1);
            }

            _lastCommandTime = Stopwatch.StartNew();
        }
    }
}
