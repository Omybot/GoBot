using Geometry;
using Geometry.Shapes;
using GoBot.Communications;
using System.Collections.Generic;

namespace GoBot.Devices
{
    public abstract class Lidar
    {
        private TicksPerSecond _measuresTicker;
        
        protected Position _position;
        protected bool _started;
        protected ConnectionChecker _checker;
        
        public delegate void NewMeasureHandler(List<RealPoint> measure);
        public delegate void FrequencyChangeHandler(double value);

        public event NewMeasureHandler NewMeasure;
        public event FrequencyChangeHandler FrequencyChange;

        public Lidar()
        {
            _measuresTicker = new TicksPerSecond();
            _measuresTicker.ValueChange += OnFrequencyChange;
            _position = new Position();
            _started = false;
            _checker = new ConnectionChecker(null);
            _checker.Start();
        }

        public Position Position { get { return _position; } set { _position = new Position(value); } }
        
        public abstract AngleDelta DeadAngle { get; }

        public ConnectionChecker ConnectionChecker { get { return _checker; } }

        public abstract bool Activated { get; }

        public void StartLoopMeasure()
        {
            if (!_started)
            {
                _measuresTicker.Start();
                _started = true;
                StartLoop();
            }
        }

        public void StopLoopMeasure()
        {
            if (_started)
            {
                _measuresTicker.Stop();
                _started = false;
                StopLoop();
            }
        }

        protected abstract bool StartLoop();
        protected abstract void StopLoop();
                
        protected void OnNewMeasure(List<RealPoint> measure)
        {
            _measuresTicker.AddTick();
            _checker.NotifyAlive();
            NewMeasure?.Invoke(measure);
        }

        protected void OnFrequencyChange(double freq)
        {
            FrequencyChange?.Invoke(freq);
        }
    }
}
