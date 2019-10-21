using Geometry;
using Geometry.Shapes;
using GoBot.Communications;
using System.Collections.Generic;

namespace GoBot.Devices
{
    public abstract class Lidar
    {
        private TicksPerSecond _measuresTicker;

        protected bool _connected;
        protected Position _position;
        protected bool _started;
        
        public delegate void NewMeasureHandler(List<RealPoint> measure);
        public delegate void FrequencyChangeHandler(double value);
        public delegate void ConnectionChangeHandler(bool connected);

        public event NewMeasureHandler NewMeasure;
        public event FrequencyChangeHandler FrequencyChange;
        public event ConnectionChangeHandler ConnectionChange;

        public Lidar()
        {
            _connected = false;
            _measuresTicker = new TicksPerSecond();
            _measuresTicker.ValueChange += OnFrequencyChange;
            _position = new Position();
            _started = false;
        }

        public Position Position { get { return _position; } set { _position = new Position(value); } }
        
        public AngleDelta DeadAngle { get { return 0; } } //TODO

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

        protected void SetConnected(bool connected)
        {
            if(_connected != connected)
            {
                _connected = connected;
                OnConnectionChange(_connected);
            }
        }
        
        protected void OnNewMeasure(List<RealPoint> measure)
        {
            _measuresTicker.AddTick();
            NewMeasure?.Invoke(measure);
        }

        protected void OnFrequencyChange(double freq)
        {
            FrequencyChange?.Invoke(freq);
        }

        protected void OnConnectionChange(bool connected)
        {
            ConnectionChange?.Invoke(connected);
        }
    }
}
