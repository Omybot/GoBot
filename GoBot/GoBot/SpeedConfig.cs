using Geometry;
using GoBot.PathFinding;
using System;
using System.IO;

namespace GoBot
{
    [Serializable]
    public class SpeedConfig
    {
        #region Core

        private int _lineAcceleration;
        private int _lineDeceleration;
        private int _lineSpeed;
        private int _pivotAcceleration;
        private int _pivotDeceleration;
        private int _pivotSpeed;

        #endregion

        #region Constructors

        public SpeedConfig(int lineSpeed, int lineAccel, int lineDecel, int pivotSpeed, int pivotAccel, int pivotDecel)
        {
            SetParams(lineSpeed, lineAccel, lineDecel, pivotSpeed, pivotAccel, pivotDecel);
        }

        public SpeedConfig()
        {
            SetParams(500, 500, 500, 500, 500, 500);
        }

        #endregion

        #region Properties

        public int LineAcceleration
        {
            get { return _lineAcceleration; }
            set
            {
                if (_lineAcceleration != value)
                {
                    _lineAcceleration = value;
                    OnParamChange(true, false, false, false, false, false);
                }
            }
        }

        public int LineDeceleration
        {
            get { return _lineDeceleration; }
            set
            {
                if (_lineDeceleration != value)
                {
                    _lineDeceleration = value;
                    OnParamChange(false, true, false, false, false, false);
                }
            }
        }

        public int LineSpeed
        {
            get { return _lineSpeed; }
            set
            {
                if (_lineSpeed != value)
                {
                    _lineSpeed = value;
                    OnParamChange(false, false, true, false, false, false);
                }
            }
        }

        public int PivotAcceleration
        {
            get { return _pivotAcceleration; }
            set
            {
                if (_pivotAcceleration != value)
                {
                    _pivotAcceleration = value;
                    OnParamChange(false, false, false, true, false, false);
                }
            }
        }

        public int PivotDeceleration
        {
            get { return _pivotDeceleration; }
            set
            {
                if (_pivotDeceleration != value)
                {
                    _pivotDeceleration = value;
                    OnParamChange(false, false, false, false, true, false);
                }
            }
        }

        public int PivotSpeed
        {
            get { return _pivotSpeed; }
            set
            {
                if (_pivotSpeed != value)
                {
                    _pivotSpeed = value;
                    OnParamChange(false, false, false, false, false, true);
                }
            }
        }

        #endregion

        #region Events

        public delegate void ParamChangeDelegate(bool lineAccelChange, bool lineDecelChange, bool lineSpeedChange, bool pivotAccelChange, bool pivotDecelChange, bool pivotSpeedChange);
        public event ParamChangeDelegate ParamChange;

        protected void OnParamChange(bool lineAccelChange, bool lineDecelChange, bool lineSpeedChange, bool pivotAccelChange, bool pivotDecelChange, bool pivotSpeedChange)
        {
            ParamChange?.Invoke(lineAccelChange, lineDecelChange, lineSpeedChange, pivotAccelChange, pivotDecelChange, pivotSpeedChange);
        }

        #endregion

        #region Public

        public TimeSpan LineDuration(int distance)
        {
            TimeSpan accel, maxSpeed, braking;
            return DistanceDuration((int)distance, LineAcceleration, LineSpeed, LineDeceleration, out accel, out maxSpeed, out braking);
        }

        public TimeSpan LineDuration(int distance, out TimeSpan accelDuration, out TimeSpan maxSpeedDuration, out TimeSpan brakingDuration)
        {
            return DistanceDuration((int)distance, LineAcceleration, LineSpeed, LineDeceleration, out accelDuration, out maxSpeedDuration, out brakingDuration);
        }

        public TimeSpan PivotDuration(AngleDelta angle, double axialDistance)
        {
            double dist = (Math.PI * axialDistance) / 360 * Math.Abs(angle.InDegrees);
            TimeSpan accel, maxSpeed, braking;
            return DistanceDuration((int)dist, PivotAcceleration, PivotSpeed, PivotDeceleration, out accel, out maxSpeed, out braking);
        }

        public TimeSpan PivotDuration(AngleDelta angle, double axialDistance, out TimeSpan accelDuration, out TimeSpan maxSpeedDuration, out TimeSpan brakingDuration)
        {
            double dist = (Math.PI * axialDistance) / 360 * Math.Abs(angle.InDegrees);
            return DistanceDuration((int)dist, PivotAcceleration, PivotSpeed, PivotDeceleration, out accelDuration, out maxSpeedDuration, out brakingDuration);
        }

        public void SetParams(int lineSpeed, int lineAccel, int lineDecel, int pivotSpeed, int pivotAccel, int pivotDecel)
        {
            _lineSpeed = lineSpeed;
            _lineAcceleration = lineAccel;
            _lineDeceleration = lineDecel;
            _pivotSpeed = pivotSpeed;
            _pivotAcceleration = pivotAccel;
            _pivotDeceleration = pivotDecel;

            OnParamChange(true, true, true, true, true, true);
        }

        public void SetParams(SpeedConfig config)
        {
            _lineSpeed = config.LineSpeed;
            _lineAcceleration = config.LineAcceleration;
            _lineDeceleration = config.LineDeceleration;
            _pivotSpeed = config.PivotSpeed;
            _pivotAcceleration = config.PivotAcceleration;
            _pivotDeceleration = config.PivotDeceleration;

            OnParamChange(true, true, true, true, true, true);
        }

        #endregion

        #region Private

        private TimeSpan DistanceDuration(int distance, int acceleration, int maxSpeed, int deceleration, out TimeSpan accelDuration, out TimeSpan maxSpeedDuration, out TimeSpan brakingDuration)
        {
            if (distance == 0 || acceleration == 0 || deceleration == 0 || maxSpeed == 0)
            {
                accelDuration = new TimeSpan();
                maxSpeedDuration = new TimeSpan();
                brakingDuration = new TimeSpan();
                return new TimeSpan();
            }
            else
            {

                double durationAccel, durationMaxSpeed, durationBraking;
                double distanceAccel, distanceMaxSpeed, distanceBraking;

                distanceAccel = (maxSpeed * maxSpeed) / (double)(2 * acceleration);
                distanceBraking = (maxSpeed * maxSpeed) / (double)(2 * deceleration);

                if (distanceAccel + distanceBraking < distance)
                {
                    distanceMaxSpeed = distance - distanceAccel - distanceBraking;

                    durationAccel = maxSpeed / (double)acceleration;
                    durationBraking = maxSpeed / (double)deceleration;
                    durationMaxSpeed = distanceMaxSpeed / (double)maxSpeed;
                }
                else
                {
                    distanceMaxSpeed = 0;
                    durationMaxSpeed = 0;

                    double rapport = deceleration / (double)acceleration;
                    distanceBraking = (int)(distance / (rapport + 1));
                    distanceAccel = distance - distanceBraking;

                    durationAccel = Math.Sqrt((2 * distanceAccel) / (double)acceleration);
                    durationBraking = Math.Sqrt((2 * distanceBraking) / (double)(deceleration));
                }

                accelDuration = new TimeSpan(0, 0, 0, 0, (int) (1000 * durationAccel));
                maxSpeedDuration = new TimeSpan(0, 0, 0, 0, (int)(1000 * durationMaxSpeed));
                brakingDuration = new TimeSpan(0, 0, 0, 0, (int)(1000 * durationBraking));

            }

            return accelDuration + maxSpeedDuration + brakingDuration;
        }

        #endregion

    }
}
