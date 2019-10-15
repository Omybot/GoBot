using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    public abstract class Lidar
    {
        private TicksPerSecond _measuresTicker;
        protected Position _position;
        protected bool _started;

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

        protected abstract void StartLoop();
        protected abstract void StopLoop();
        
        protected void OnNewMeasure(List<RealPoint> measure)
        {
            _measuresTicker.AddTick();
            NewMeasure?.Invoke(measure);
        }
        
        protected void OnFrequencyChange(double freq)
        {
            FrequencyChange?.Invoke(freq);
        }
    }
}
