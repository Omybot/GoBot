using GoBot.GameElements;
using GoBot.Geometry.Shapes;
using GoBot.Threading;
using GoBot.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoBot.GameElements.CubesCross;

namespace GoBot.Actionneurs
{
    class PatternReader
    {
        private CubesPattern _pattern;

        private LimitedQueue<double> _measures;
        private double _period;

        private int _errors;

        private ThreadLink _linkPolling;
        
        public delegate void PatternChangedDelegate(CubesPattern pattern);
        public event PatternChangedDelegate PatternChanged;

        public CubesPattern Pattern
        {
            get { return _pattern; }
        }

        public double Period
        {
            get { return _period; }
        }

        public PatternReader()
        {
            _pattern = new CubesPattern();

            _measures = new LimitedQueue<double>(10);

            _errors = 0;
        }

        public CubesPattern ReadPattern()
        {
            _pattern = Robots.GrosRobot.DemandeCapteurPattern();
            return _pattern;
        }

        public void StartPolling()
        {
            _linkPolling = ThreadManager.StartInfiniteLoop(f => AskRefresh(), new TimeSpan(0, 0, 0, 0, 100));
        }

        public void StopPolling()
        {
            _linkPolling.Cancel();
            _linkPolling.WaitEnd();
            _linkPolling = null;
        }
        
        private void AskRefresh()
        {
            _linkPolling?.RegisterName();
            Robots.GrosRobot.DemandeCapteurPattern(false);
        }

        public void Paint(Graphics g, WorldScale scale)
        {
            _pattern.Paint(g, new RealPoint(1500 - KCubeSize * 1.5, -20), scale);
        }

        public void SetPeriod(int rawPeriod)
        {
            double newPeriod = rawPeriod * 0.0016;

            if (newPeriod > 8.5 && newPeriod < 20.5)
            {
                _period = newPeriod;
                _measures.Enqueue(_period);

                CubesPattern newPattern = GuessPattern();
                if (!newPattern.IsSame(_pattern))
                {
                    _pattern = newPattern;
                    OnPatternChanged();

                }
            }
            else
            {
                _errors++;
                Console.WriteLine(_errors + " erreurs");
            }

        }

        protected void OnPatternChanged()
        {
            PatternChanged(_pattern);
        }

        protected CubesPattern GuessPattern()
        {
            List<double> measures = new List<double>(_measures);

            measures.Sort();

            CubesPattern output = new CubesPattern();

            if (_measures.Count > 0)
            {
                double period = measures[measures.Count / 2];

                if (_period > 9.5)
                {
                    if (_period < 10.5)
                        output = new CubesPattern(CubeColor.Orange, CubeColor.Black, CubeColor.Green);
                    else if (_period < 11.5)
                        output = new CubesPattern(CubeColor.Yellow, CubeColor.Black, CubeColor.Blue);
                    else if (_period < 12.5)
                        output = new CubesPattern(CubeColor.Blue, CubeColor.Green, CubeColor.Orange);
                    else if (_period < 13.5)
                        output = new CubesPattern(CubeColor.Yellow, CubeColor.Green, CubeColor.Black);
                    else if (_period < 14.5)
                        output = new CubesPattern(CubeColor.Black, CubeColor.Yellow, CubeColor.Orange);
                    else if (_period < 15.5)
                        output = new CubesPattern(CubeColor.Green, CubeColor.Yellow, CubeColor.Blue);
                    else if (_period < 16.5)
                        output = new CubesPattern(CubeColor.Blue, CubeColor.Orange, CubeColor.Black);
                    else if (_period < 17.5)
                        output = new CubesPattern(CubeColor.Green, CubeColor.Orange, CubeColor.Yellow);
                    else if (_period < 18.5)
                        output = new CubesPattern(CubeColor.Black, CubeColor.Blue, CubeColor.Green);
                    else if (_period < 19.5)
                        output = new CubesPattern(CubeColor.Orange, CubeColor.Blue, CubeColor.Yellow);
                }
            }

            return output;
        }
    }
}
