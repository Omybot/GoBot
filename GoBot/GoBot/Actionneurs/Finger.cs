using System.Diagnostics;
using System.Threading;

namespace GoBot.Actionneurs
{
    abstract class Finger
    {
        public abstract void DoAirLock();
        public abstract void DoAirUnlock();
        public abstract void DoPositionHide();
        public abstract void DoPositionKeep();
        public abstract void DoPositionGrab();
        public abstract bool HasSomething();

        public void DoDemoGrab()
        {
            Stopwatch swMain = Stopwatch.StartNew();
            bool ok;

            while (swMain.Elapsed.TotalMinutes < 1)
            {
                while (!HasSomething())
                {
                    ok = false;
                    DoAirLock();
                    DoPositionGrab();

                    Stopwatch sw = Stopwatch.StartNew();

                    while (sw.ElapsedMilliseconds < 1000 && !ok)
                    {
                        Thread.Sleep(50);
                        ok = HasSomething();
                    }

                    if (ok)
                        DoPositionKeep();
                    else
                        DoPositionHide();

                    Thread.Sleep(1000);
                }

                Thread.Sleep(50);
            }

            DoPositionHide();
            DoAirUnlock();
        }
    }
}
