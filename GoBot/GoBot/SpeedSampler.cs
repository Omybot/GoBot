using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    class SpeedSample
    {
        private List<double> _pos, _speed;
        private List<TimeSpan> _times;

        public SpeedSample(List<TimeSpan> times, List<double> positions, List<double> speeds)
        {
            _times = times;
            _pos = positions;
            _speed = speeds;
        }

        public List<double> Positions { get { return _pos; } }
        public List<double> Speeds { get { return _speed; } }
        public List<TimeSpan> Times { get { return _times; } }
        public TimeSpan Duration { get { return _times[_times.Count - 1] - _times[0]; } }
        public bool Valid { get { return _pos.Count > 0; } }
    }

    class SpeedSampler
    {
        private SpeedConfig _config;

        public SpeedSampler(SpeedConfig config)
        {
            _config = config;
        }

        public SpeedSample SampleLine(int startPos, int endPos, int samplesCnt)
        {
            TimeSpan accelDuration, maxSpeedDuration, brakingDuration, totalDuration;
            totalDuration = _config.LineDuration(Math.Abs(endPos - startPos), out accelDuration, out maxSpeedDuration, out brakingDuration);

            TimeSpan division = new TimeSpan(totalDuration.Ticks / samplesCnt);

            List<double> speeds = new List<double>();
            List<double> positions = new List<double>();
            List<TimeSpan> times = new List<TimeSpan>();

            double currentSpeed = 0, currentPosition = startPos;
            int direction = ((endPos - startPos) > 0 ? 1 : -1);
            double accelPerDiv = (_config.LineAcceleration * division.TotalSeconds) * direction;
            TimeSpan currentTime = new TimeSpan();

            while (speeds.Count < samplesCnt)
            {
                speeds.Add(currentSpeed);
                positions.Add(currentPosition);
                times.Add(currentTime);

                currentTime += division;

                if (currentTime < accelDuration)
                    currentSpeed += accelPerDiv;
                else if (currentTime > accelDuration + maxSpeedDuration)
                    currentSpeed -= accelPerDiv;
                else
                    currentSpeed = _config.LineSpeed * direction;

                if(direction < 0)
                    currentSpeed = Math.Min(0, Math.Max(currentSpeed, _config.LineSpeed *direction));
                else
                    currentSpeed = Math.Max(0, Math.Min(currentSpeed, _config.LineSpeed * direction));

                currentPosition += currentSpeed;
            }

            return new SpeedSample(times, positions, speeds);
        }
    }
}
