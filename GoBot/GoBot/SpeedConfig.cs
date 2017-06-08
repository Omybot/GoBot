﻿using GoBot.Calculs;
using GoBot.PathFinding;
using System;

namespace GoBot
{
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
                    OnParamChange(true, false, false, false, false, false);
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
                    OnParamChange(false, true, false, false, false, false);
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
                    OnParamChange(false, false, true, false, false, false);
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

        public int LineDuration(int distance)
        {
            return DistanceDuration(distance, LineAcceleration, LineSpeed, LineDeceleration);
        }

        public int PivotDuration(Angle angle, double axialDistance)
        {
            return DistanceDuration((int)((Math.PI * axialDistance) / 360 * angle.AngleDegresPositif), PivotAcceleration, PivotSpeed, PivotDeceleration);
        }

        public int TrajectoryDuration(Trajectoire traj)
        {
            return traj.Duree;
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

        #endregion

        #region Private

        private int DistanceDuration(int distance, int acceleration, int maxSpeed, int decceleration)
        {
            if (distance == 0)
                return 0;

            double durationAccel, durationMaxSpeed, durationBraking;
            double distanceAccel, distanceMaxSpeed, distanceBraking;

            distanceAccel = (maxSpeed * maxSpeed) / (double)(2 * acceleration);
            distanceBraking = (maxSpeed * maxSpeed) / (double)(2 * decceleration);

            if (distanceAccel + distanceBraking < distance)
            {
                distanceMaxSpeed = distance - distanceAccel - distanceBraking;

                durationAccel = maxSpeed / (double)acceleration;
                durationBraking = maxSpeed / (double)decceleration;
                durationMaxSpeed = distanceMaxSpeed / (double)maxSpeed;
            }
            else
            {
                distanceMaxSpeed = 0;
                durationMaxSpeed = 0;

                double rapport = decceleration / (double)acceleration;
                distanceBraking = (int)(distance / (rapport + 1));
                distanceAccel = distance - distanceBraking;

                durationAccel = Math.Sqrt((2 * distanceAccel) / (double)acceleration);
                durationBraking = Math.Sqrt((2 * distanceBraking) / (double)(decceleration));
            }

            return (int)((durationAccel + durationMaxSpeed + durationBraking) * 1000);
        }

        #endregion
    }
}