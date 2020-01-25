using System;
using System.Collections.Generic;
using System.Linq;
using Geometry;
using System.Timers;
using Geometry.Shapes;
using System.Threading;
using GoBot.Actions;
using System.Drawing;
using System.Diagnostics;
using GoBot.Threading;
using GoBot.BoardContext;

namespace GoBot
{
    class RobotSimu : Robot
    {
        private Random _rand;
        private Semaphore _lockMove;
        private bool _highResolutionAsservissement;

        private Position _destination;
        private double _currentSpeed;
        private SensGD _sensPivot;
        private SensAR _sensMove;
        private bool _inRecalibration;
        private ThreadLink _linkAsserv, _linkLogPositions;

        private Position _currentPosition;

        private Stopwatch _asserChrono;
        private int _currentPolarPoint;
        private List<RealPoint> _polarTrajectory;

        private long _lastTimerTick;

        public override Position Position
        {
            get { return _currentPosition; }
            protected set { _currentPosition = value; _destination = value; }
        }

        public RobotSimu(IDRobot idRobot) : base(idRobot, "Robot Simu")
        {
            _highResolutionAsservissement = true;
            _rand = new Random();

            _linkAsserv = ThreadManager.CreateThread(link => Asservissement());
            _linkLogPositions = ThreadManager.CreateThread(link => LogPosition());

            _lockMove = new Semaphore(1, 1);
            _sensMove = SensAR.Avant;

            _inRecalibration = false;
            _asserChrono = null;
            _currentPolarPoint = -1;
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);
            PositionsHistorical = new List<Position>();
            Position = new Position(GoBot.Recalibration.StartPosition);

            PositionTarget = null;

            _linkAsserv.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, _highResolutionAsservissement ? 1 : 16));
            _linkLogPositions.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 100));
        }

        public override void DeInit()
        {
            _linkAsserv.Cancel();
            _linkLogPositions.Cancel();

            _linkAsserv.WaitEnd();
            _linkLogPositions.WaitEnd();
        }

        public override string ReadLidarMeasure(LidarID lidar, int timeout, out Position refPosition)
        {
            refPosition = new Position(_currentPosition);

            // Pas de simulation de LIDAR

            return "";
        }

        private void LogPosition()
        {
            _linkLogPositions.RegisterName();

            lock (PositionsHistorical)
            {
                PositionsHistorical.Add(new Position(Position.Angle, new RealPoint(Position.Coordinates.X, Position.Coordinates.Y)));

                while (PositionsHistorical.Count > 1200)
                    PositionsHistorical.RemoveAt(0);
            }
        }

        private double GetCurrentLineBreakDistance()
        {
            return (_currentSpeed * _currentSpeed) / (2 * SpeedConfig.LineDeceleration);
        }

        private double GetCurrentAngleBreakDistance()
        {
            return (_currentSpeed * _currentSpeed) / (2 * SpeedConfig.PivotDeceleration);
        }

        private double DistanceBetween(List<RealPoint> points, int from, int to)
        {
            double distance = 0;

            for (int i = from + 1; i <= to; i++)
                distance += points[i - 1].Distance(points[i]);

            return distance;
        }

        private void Asservissement()
        {
            _linkAsserv.RegisterName();

            // Calcul du temps écoulé depuis la dernière mise à jour de la position
            double interval = 0;

            if (_asserChrono != null)
            {
                long currentTick = _asserChrono.ElapsedMilliseconds;
                interval = currentTick - _lastTimerTick;
                _lastTimerTick = currentTick;
            }
            else
                _asserChrono = Stopwatch.StartNew();

            if (interval > 0)
            {
                _lockMove.WaitOne();

                if (_currentPolarPoint >= 0)
                {
                    double distanceBeforeNext = Position.Coordinates.Distance(_polarTrajectory[_currentPolarPoint]);
                    double distanceBeforeEnd = distanceBeforeNext;

                    distanceBeforeEnd += DistanceBetween(_polarTrajectory, _currentPolarPoint, _polarTrajectory.Count - 1);

                    if (distanceBeforeEnd > GetCurrentAngleBreakDistance())
                        _currentSpeed = Math.Min(SpeedConfig.LineSpeed, _currentSpeed + SpeedConfig.LineAcceleration / (1000.0 / interval));
                    else
                        _currentSpeed = _currentSpeed - SpeedConfig.LineDeceleration / (1000.0 / interval);

                    double distanceToRun = _currentSpeed / (1000.0 / interval);

                    double distanceTested = distanceBeforeNext;

                    bool changePoint = false;
                    while (distanceTested < distanceToRun && _currentPolarPoint < _polarTrajectory.Count - 1)
                    {
                        _currentPolarPoint++;
                        distanceTested += _polarTrajectory[_currentPolarPoint - 1].Distance(_polarTrajectory[_currentPolarPoint]);
                        changePoint = true;
                    }

                    Segment segment;
                    Circle circle;

                    if (changePoint)
                    {
                        segment = new Segment(_polarTrajectory[_currentPolarPoint - 1], _polarTrajectory[_currentPolarPoint]);
                        circle = new Circle(_polarTrajectory[_currentPolarPoint - 1], distanceToRun - (distanceTested - _polarTrajectory[_currentPolarPoint - 1].Distance(_polarTrajectory[_currentPolarPoint])));
                    }
                    else
                    {
                        segment = new Segment(Position.Coordinates, _polarTrajectory[_currentPolarPoint]);
                        circle = new Circle(Position.Coordinates, distanceToRun);
                    }

                    RealPoint newPos = segment.GetCrossingPoints(circle)[0];
                    AngleDelta a = -Maths.GetDirection(newPos, _polarTrajectory[_currentPolarPoint]).angle;
                    _currentPosition = new Position(new AnglePosition(a), newPos);
                    OnPositionChanged(Position);

                    if (_currentPolarPoint == _polarTrajectory.Count - 1)
                    {
                        _currentPolarPoint = -1;
                        _destination.Copy(Position);
                    }
                }
                else
                {
                    bool needLine = _destination.Coordinates.Distance(Position.Coordinates) > 0;
                    bool needAngle = Math.Abs(_destination.Angle - Position.Angle) > 0.01;

                    if (needAngle)
                    {
                        AngleDelta diff = Math.Abs(_destination.Angle - Position.Angle);

                        double speedWithAcceleration = Math.Min(SpeedConfig.PivotSpeed, _currentSpeed + SpeedConfig.PivotAcceleration / (1000.0 / interval));
                        double remainingDistanceWithAcceleration = CircleArcLenght(WheelSpacing, diff) - (_currentSpeed + speedWithAcceleration) / 2 / (1000.0 / interval);

                        if (remainingDistanceWithAcceleration > DistanceFreinage(speedWithAcceleration))
                        {
                            double distParcourue = (_currentSpeed + speedWithAcceleration) / 2 / (1000.0 / interval);
                            AngleDelta angleParcouru = (360 * distParcourue) / (Math.PI * WheelSpacing);

                            _currentSpeed = speedWithAcceleration;

                            Position.Angle += (_sensPivot.Factor() * angleParcouru);
                        }
                        else if (_currentSpeed > 0)
                        {
                            double speedWithDeceleration = Math.Max(0, _currentSpeed - SpeedConfig.PivotDeceleration / (1000.0 / interval));
                            double distParcourue = (_currentSpeed + speedWithDeceleration) / 2 / (1000.0 / interval);
                            AngleDelta angleParcouru = (360 * distParcourue) / (Math.PI * WheelSpacing);

                            _currentSpeed = speedWithDeceleration;

                            Position.Angle += (_sensPivot.Factor() * angleParcouru);
                        }
                        else
                        {
                            Position.Copy(_destination);
                        }

                        OnPositionChanged(Position);
                    }
                    else if (needLine)
                    {
                        double speedWithAcceleration = Math.Min(SpeedConfig.LineSpeed, _currentSpeed + SpeedConfig.LineAcceleration / (1000.0 / interval));
                        double remainingDistanceWithAcceleration = Position.Coordinates.Distance(_destination.Coordinates) - (_currentSpeed + speedWithAcceleration) / 2 / (1000.0 / interval);

                        // Phase accélération ou déccélération
                        if (remainingDistanceWithAcceleration > DistanceFreinage(speedWithAcceleration))
                        {
                            double distance = (_currentSpeed + speedWithAcceleration) / 2 / (1000.0 / interval);
                            _currentSpeed = speedWithAcceleration;

                            Position.Move(distance * _sensMove.Factor());
                        }
                        else if (_currentSpeed > 0)
                        {
                            double speedWithDeceleration = Math.Max(0, _currentSpeed - SpeedConfig.LineDeceleration / (1000.0 / interval));
                            double distance = Math.Min(_destination.Coordinates.Distance(Position.Coordinates), (_currentSpeed + speedWithDeceleration) / 2 / (1000.0 / interval));
                            _currentSpeed = speedWithDeceleration;

                            Position.Move(distance * _sensMove.Factor());
                        }
                        else
                        {
                            // Si on est déjà à l'arrêt on force l'équivalence de la position avec la destination.

                            Position.Copy(_destination);
                            IsInLineMove = false;
                        }

                        OnPositionChanged(Position);
                    }
                }

                _lockMove.Release();
            }
        }

        private double DistanceFreinage(Double speed)
        {
            return (speed * speed) / (2 * SpeedConfig.LineDeceleration);
        }

        private double CircleArcLenght(double diameter, AngleDelta arc)
        {
            return Math.Abs(arc.InDegrees) / 360 * Math.PI * diameter;
        }

        public override void MoveForward(int distance, bool wait = true)
        {
            base.MoveForward(distance, wait);

            IsInLineMove = true;

            if (distance > 0)
            {
                if (!_inRecalibration)
                    Historique.AjouterAction(new ActionAvance(this, distance));
                _sensMove = SensAR.Avant;
            }
            else
            {
                if (!_inRecalibration)
                    Historique.AjouterAction(new ActionRecule(this, -distance));
                _sensMove = SensAR.Arriere;
            }

            _destination = new Position(Position.Angle, new RealPoint(Position.Coordinates.X + distance * Position.Angle.Cos, Position.Coordinates.Y + distance * Position.Angle.Sin));

            // TODO2018 attente avec un sémaphore ?
            if (wait)
                while ((Position.Coordinates.X != _destination.Coordinates.X ||
                    Position.Coordinates.Y != _destination.Coordinates.Y) && !Execution.Shutdown)
                    Thread.Sleep(10);
        }

        public override void MoveBackward(int distance, bool wait = true)
        {
            MoveForward(-distance, wait);
        }

        public override void PivotLeft(AngleDelta angle, bool wait = true)
        {
            base.PivotLeft(angle, wait);

            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));

            _destination = new Position(Position.Angle - angle, new RealPoint(Position.Coordinates.X, Position.Coordinates.Y));
            _sensPivot = SensGD.Gauche;

            if (wait)
                while (Position.Angle != _destination.Angle)
                    Thread.Sleep(10);
        }

        public override void PivotRight(AngleDelta angle, bool wait = true)
        {
            base.PivotRight(angle, wait);

            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));

            _destination = new Position(Position.Angle + angle, new RealPoint(Position.Coordinates.X, Position.Coordinates.Y));
            _sensPivot = SensGD.Droite;

            if (wait)
                while (Position.Angle != _destination.Angle)
                    Thread.Sleep(10);
        }

        public override void Stop(StopMode mode)
        {
            Historique.AjouterAction(new ActionStop(this, mode));

            _lockMove.WaitOne();

            if (mode == StopMode.Smooth)
            {
                Position nouvelleDestination = new Position(Position.Angle, new RealPoint(_currentPosition.Coordinates.X, _currentPosition.Coordinates.Y));

                if (IsInLineMove)
                {
                    if (_sensMove == SensAR.Avant)
                        nouvelleDestination.Move(GetCurrentLineBreakDistance());
                    else
                        nouvelleDestination.Move(-GetCurrentLineBreakDistance());
                }

                _destination = nouvelleDestination;
            }
            else if (mode == StopMode.Abrupt)
            {
                _currentSpeed = 0;
                _destination = Position;
            }
            _lockMove.Release();
        }

        public override void Turn(SensAR sensAr, SensGD sensGd, int rayon, AngleDelta angle, bool wait = true)
        {
            // TODO2018
        }

        public override void PolarTrajectory(SensAR sens, List<RealPoint> points, bool wait = true)
        {
            _polarTrajectory = points;
            _currentPolarPoint = 0;

            while (wait && _currentPolarPoint != -1)
                Thread.Sleep(10);
        }

        public override void SetAsservOffset(Position newPosition)
        {
            Position = new Position(newPosition.Angle, newPosition.Coordinates);
            PositionTarget?.Set(Position.Coordinates);

            OnPositionChanged(Position);
        }

        public override void Recalibration(SensAR sens, bool wait = true)
        {
            _inRecalibration = true;

            Historique.AjouterAction(new ActionRecallage(this, sens));

            if (wait)
                RecalProcedure(sens);
            else
                ThreadManager.CreateThread(link => RecalProcedure(sens)).StartThread();
        }

        private void RecalProcedure(SensAR sens)
        {
            int realAccel = SpeedConfig.LineAcceleration;
            int realDecel = SpeedConfig.LineAcceleration;

            SpeedConfig.LineAcceleration = 50000;
            SpeedConfig.LineDeceleration = 50000;

            IShape contact = GetBounds();

            while (Position.Coordinates.X - Lenght / 2 > 0 &&
                Position.Coordinates.X + Lenght / 2 < GameBoard.Width &&
                Position.Coordinates.Y - Lenght / 2 > 0 &&
                Position.Coordinates.Y + Lenght / 2 < GameBoard.Height &&
                !GameBoard.ObstaclesAll.ToList().Exists(o => o.Cross(contact)))
            {
                if (sens == SensAR.Arriere)
                    MoveBackward(1);
                else
                    MoveForward(1);

                contact = GetBounds();
            }

            SpeedConfig.LineAcceleration = realAccel;
            SpeedConfig.LineDeceleration = realDecel;

            _inRecalibration = false;
        }

        public override bool ReadSensorOnOff(SensorOnOffID sensor, bool wait = true)
        {
            // TODO
            return true;
        }

        public override Color ReadSensorColor(SensorColorID sensor, bool wait = true)
        {
            ColorPlus c = Color.White;
            int i = DateTime.Now.Millisecond + DateTime.Now.Second * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Hour * 60 * 60 * 1000;
            int max = 999 + 59 * 1000 + 59 * 60 * 1000 + 23 * 60 * 60 * 1000;

            i %= (15 * 1000);
            max %= (15 * 1000);

            int steps = 10;
            int maxColor = 255 * steps;

            i = (int)Math.Floor(i / (max / (float)maxColor));

            switch (i / 255)
            {
                case 0:
                    c = ColorPlus.FromRgb(255, i % 255, 0); break;
                case 1:
                    c = ColorPlus.FromRgb(255 - i % 255, 255, 0); break;
                case 2:
                    c = ColorPlus.FromRgb(0, 255, i % 255); break;
                case 3:
                    c = ColorPlus.FromRgb(0, 255 - i % 255, 255); break;
                case 4:
                    c = ColorPlus.FromRgb(i % 255, 0, 255); break;
                case 5:
                    c = ColorPlus.FromRgb(255, 0, 255 - i % 255); break;
                case 6:
                    c = ColorPlus.FromRgb(255 - i % 255, 0, 0); break;
                case 7:
                    c = ColorPlus.FromRgb(i % 255, i % 255, i % 255); break;
                case 8:
                    c = ColorPlus.FromRgb(255 - i % 255 / 2, 255 - i % 255 / 2, 255 - i % 255 / 2); break;
                case 9:
                    c = ColorPlus.FromHsl(0, i % 255 / 255f, 0.5); break;
            }

            OnSensorColorChanged(sensor, c);
            return SensorsColorValue[sensor];
        }

        public override void SendPID(int p, int i, int d)
        {
            // TODO
        }

        public override void SendPIDCap(int p, int i, int d)
        {
            // TODO
        }

        public override void SendPIDSpeed(int p, int i, int d)
        {
            // TODO
        }

        public override void SetActuatorOnOffValue(ActuatorOnOffID actuator, bool on)
        {
            // TODO
            Historique.AjouterAction(new ActionOnOff(this, actuator, on));
        }

        public override void SetMotorAtPosition(MotorID motor, int vitesse, bool wait)
        {
            base.SetMotorAtPosition(motor, vitesse);
        }

        public override void SetMotorSpeed(MotorID motor, SensGD sens, int speed)
        {
            base.SetMotorSpeed(motor, sens, speed);
        }

        public override void SetMotorAcceleration(MotorID motor, int acceleration)
        {
            base.SetMotorAcceleration(motor, acceleration);
        }

        public override void EnablePower(bool on)
        {
            // TODO
            if (!on)
            {
                /*VitesseDeplacement = 0;
                AccelerationDeplacement = 0;
                VitessePivot = 0;
                AccelerationPivot = 0;*/
            }
        }

        public override void Reset()
        {
            // TODO
        }

        public override bool ReadStartTrigger()
        {
            return true;
        }

        public override List<int>[] DiagnosticPID(int steps, SensAR sens, int pointsCount)
        {
            List<int>[] output = new List<int>[2];
            output[0] = new List<int>();
            output[1] = new List<int>();

            for (double i = 0; i < pointsCount; i++)
            {
                output[0].Add((int)(Math.Sin((i + DateTime.Now.Millisecond) / 100.0 * Math.PI) * steps * 10000000 / (i * i * i)));
                output[1].Add((int)(Math.Sin((i + DateTime.Now.Millisecond) / 100.0 * Math.PI) * steps * 10000000 / (i * i * i) + 10));
            }

            return output;
        }

        public override List<double>[] DiagnosticCpuPwm(int pointsCount)
        {
            List<double> cpuLoad, pwmLeft, pwmRight;

            cpuLoad = new List<double>();
            pwmLeft = new List<double>();
            pwmRight = new List<double>();

            for (int i = 0; i < pointsCount; i++)
            {
                cpuLoad.Add((Math.Sin(i / (double)pointsCount * Math.PI * 2) / 2 + 0.5) * 0.2 + _rand.NextDouble() * 0.2 + 0.3);
                pwmLeft.Add(Math.Sin((DateTime.Now.Millisecond + i + DateTime.Now.Second * 1000) % 1500 / (double)1500 * Math.PI * 2) * 3800 + (_rand.NextDouble() - 0.5) * 400);
                pwmRight.Add(Math.Sin((DateTime.Now.Millisecond + i + DateTime.Now.Second * 1000) % 5000 / (double)5000 * Math.PI * 2) * 3800 + (_rand.NextDouble() - 0.5) * 400);
            }

            Thread.Sleep(pointsCount);

            return new List<double>[3] { cpuLoad, pwmLeft, pwmRight };
        }

        public override void ReadAnalogicPins(Board board, bool wait)
        {
            List<double> values = Enumerable.Range(1, 9).Select(o => o + _rand.NextDouble()).ToList();
            AnalogicPinsValue[board] = values;
        }

        public override void ReadNumericPins(Board board, bool wait)
        {
            for (int i = 0; i < 3 * 2; i++)
                NumericPinsValue[board][i] = (byte)((DateTime.Now.Second * 1000 + DateTime.Now.Millisecond) / 60000.0 * 255);
        }
    }
}
