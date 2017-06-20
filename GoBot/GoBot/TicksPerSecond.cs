using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoBot
{
    class TicksPerSecond
    {
        private int _counter;
        private List<int> _measures;
        private Timer _timer;
        private double _lastValue;
        
        public int MeasuresCount { get; set; }

        public delegate void ValueChangeDelegate(double value);
        public event ValueChangeDelegate ValueChange;

        public TicksPerSecond()
        {
            _measures = new List<int>();
            _counter = 0;
            MeasuresCount = 10;
            _lastValue = -1;
        }

        public void Start()
        {
            if(_timer == null)
            {
                _counter = 0;
                _timer = new Timer(1000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
        }

        public void Stop()
        {
            if(_timer != null)
            {
                _timer.Stop();
                _timer = null;
                
                _measures.Clear();
                _lastValue = 0;
                ValueChange?.Invoke(_lastValue);
            }
        }

        public void AddTick()
        {
            _counter++;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _measures.Add(_counter);
            _counter = 0;

            if (_measures.Count > MeasuresCount)
                _measures.RemoveRange(0, _measures.Count - MeasuresCount);

            double newValue = _measures.Average();
            if (newValue != _lastValue)
            {
                _lastValue = newValue;
                ValueChange?.Invoke(_lastValue);
            }
        }
    }
}
