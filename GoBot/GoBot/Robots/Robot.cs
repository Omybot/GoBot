﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

using AStarFolder;

using Geometry;
using Geometry.Shapes;

using GoBot.Actionneurs;
using GoBot.Actions;
using GoBot.BoardContext;
using GoBot.PathFinding;
using GoBot.Threading;

namespace GoBot
{
    public abstract class Robot
    {
        // Communication
        public Board AsservBoard { get; protected set; }
        public Historique Historique { get; protected set; }
        public double BatterieVoltage { get; set; }
        public double BatterieIntensity { get; set; }

        // Constitution
        public IDRobot IDRobot { get; private set; }
        public string Name { get; private set; }

        public Robot(IDRobot id, string name)
        {
            IDRobot = id;
            Name = name;

            SpeedConfig = new SpeedConfig(500, 1000, 1000, 500, 1000, 1000);
            AsserStats = new AsserStats();
            IsSpeedAdvAdaptable = true;

            foreach (MotorID moteur in Enum.GetValues(typeof(MotorID)))
                MotorState.Add(moteur, false);

            foreach (SensorOnOffID o in Enum.GetValues(typeof(SensorOnOffID)))
                SensorsOnOffValue.Add(o, false);

            foreach (ActuatorOnOffID o in Enum.GetValues(typeof(ActuatorOnOffID)))
                ActuatorOnOffState.Add(o, false);

            foreach (SensorColorID o in Enum.GetValues(typeof(SensorColorID)))
                SensorsColorValue.Add(o, Color.Black);

            AnalogicPinsValue = new Dictionary<Board, List<double>>();
            AnalogicPinsValue.Add(Board.RecIO, new List<double>());
            AnalogicPinsValue.Add(Board.RecMove, new List<double>());

            for (int i = 0; i < 9; i++)
            {
                AnalogicPinsValue[Board.RecIO].Add(0);
                AnalogicPinsValue[Board.RecMove].Add(0);
            }

            NumericPinsValue = new Dictionary<Board, List<Byte>>();
            NumericPinsValue.Add(Board.RecIO, new List<byte>());
            NumericPinsValue.Add(Board.RecMove, new List<byte>());

            for (int i = 0; i < 3 * 2; i++)
            {
                NumericPinsValue[Board.RecIO].Add(0);
                NumericPinsValue[Board.RecMove].Add(0);
            }

            BatterieVoltage = 0;
            Graph = null;
            TrajectoryFailed = false;
            TrajectoryCutOff = false;
            TrajectoryRunning = null;
        }

        public virtual void ShowMessage(String message1, String message2)
        {

        }

        public override string ToString()
        {
            return Name;
        }

        #region Pinout

        public Dictionary<Board, List<double>> AnalogicPinsValue { get; protected set; }
        public Dictionary<Board, List<byte>> NumericPinsValue { get; protected set; }

        public abstract void ReadAnalogicPins(Board board, bool waitEnd = true);
        public abstract void ReadNumericPins(Board board, bool waitEnd = true);

        #endregion

        #region Management

        public abstract void Init();
        public abstract void DeInit();
        public abstract void EnablePower(bool on);
        public abstract List<double>[] DiagnosticCpuPwm(int valuesCount);
        public abstract List<int>[] DiagnosticPID(int steps, SensAR sens, int valuesCount);
        public abstract List<int>[] DiagnosticLine(int distance, SensAR sens);

        #endregion

        #region Moves

        public SpeedConfig SpeedConfig { get; protected set; }
        public List<Position> PositionsHistorical { get; protected set; }
        public AsserStats AsserStats { get; protected set; }
        public bool AsserEnable { get; protected set; }
        public abstract Position Position { get; protected set; }
        public RealPoint PositionTarget { get; protected set; }
        public bool IsInLineMove { get; protected set; }
        public bool IsSpeedAdvAdaptable { get; protected set; }


        public delegate void PositionChangedDelegate(Position position);
        public event PositionChangedDelegate PositionChanged;

        protected void OnPositionChanged(Position position)
        {
            PositionChanged?.Invoke(position);
        }


        public virtual void MoveForward(int distance, bool waitEnd = true)
        {
            if (distance > 0)
                AsserStats.ForwardMoves.Add(distance);
            else
                AsserStats.BackwardMoves.Add(-distance);
        }

        public virtual void MoveBackward(int distance, bool waitEnd = true)
        {
            if (distance < 0)
                AsserStats.ForwardMoves.Add(distance);
            else
                AsserStats.BackwardMoves.Add(-distance);
        }

        public void Move(int distance, bool waitEnd = true)
        {
            if (distance > 0)
                MoveForward(distance, waitEnd);
            else
                MoveBackward(-distance, waitEnd);
        }

        public virtual void PivotLeft(AngleDelta angle, bool waitEnd = true)
        {
            AsserStats.LeftRotations.Add(angle);
        }

        public virtual void Pivot(AngleDelta angle, bool waitEnd = true)
        {
            if (angle > 0)
                PivotLeft(angle, waitEnd);
            else
                PivotRight(-angle, waitEnd);
        }

        public virtual void PivotRight(AngleDelta angle, bool waitEnd = true)
        {
            AsserStats.RightsRotations.Add(angle);
        }

        public void SetSpeedSlow()
        {
            SpeedConfig.SetParams(Config.CurrentConfig.ConfigLent);

            IsSpeedAdvAdaptable = false;
        }

        public void SetSpeedVerySlow()
        {
            SpeedConfig.SetParams(100, 500, 500, 100, 500, 500);

            IsSpeedAdvAdaptable = false;
        }

        public void SetSpeedVeryFast()
        {
            SpeedConfig.SetParams(800, 2500, 2500, 800, 2500, 2500);

            IsSpeedAdvAdaptable = false;
        }

        public void SetSpeedFast()
        {
            SpeedConfig.SetParams(Config.CurrentConfig.ConfigRapide);

            IsSpeedAdvAdaptable = true;
        }

        public void GoToAngle(AnglePosition angle, double marge = 0)
        {
            AngleDelta diff = angle - Position.Angle;
            if (Math.Abs(diff.InDegrees) > marge)
            {
                if (diff.InDegrees > 0)
                    PivotRight(diff.InDegrees);
                else
                    PivotLeft(-diff.InDegrees);
            }
        }

        public bool GoToPosition(Position dest)
        {
            Historique.Log("Lancement pathfinding pour aller en " + dest.ToString(), TypeLog.PathFinding);

            Trajectory traj = PathFinder.ChercheTrajectoire(Graph, GameBoard.ObstaclesAll, GameBoard.ObstaclesOpponents, Position, dest, Radius, Robots.MainRobot.Width / 2);

            if (traj == null)
                return false;

            RunTrajectory(traj);

            return !TrajectoryCutOff && !TrajectoryFailed;
        }

        public abstract void PolarTrajectory(SensAR sens, List<RealPoint> points, bool waitEnd = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Turn(SensAR sensAr, SensGD sensGd, int radius, AngleDelta angle, bool waitEnd = true);
        public abstract void SetAsservOffset(Position newPosition);
        public virtual void Recalibration(SensAR sens, bool waitEnd = true, bool sendOffset = false)
        {
            int angle = 0;

            double toleranceXY = 30;
            double toleranceTheta = 3;

            double dist = (sens == SensAR.Avant ? Robots.MainRobot.LenghtFront : Robots.MainRobot.LenghtBack);

            if (waitEnd && sendOffset)
            {
                if (Position.Angle.IsOnArc(0 - toleranceTheta, 0 + toleranceTheta))
                    angle = 0;
                else if (Position.Angle.IsOnArc(90 - toleranceTheta, 90 + toleranceTheta))
                    angle = 90;
                else if (Position.Angle.IsOnArc(180 - toleranceTheta, 180 + toleranceTheta))
                    angle = 180;
                else if (Position.Angle.IsOnArc(270 - toleranceTheta, 270 + toleranceTheta))
                    angle = 270;

                if (Position.Coordinates.X < dist + toleranceXY && Position.Coordinates.X > dist - toleranceTheta)
                    SetAsservOffset(new Position(angle, new RealPoint(dist, Position.Coordinates.Y)));
                else if (Position.Coordinates.X > 3000 - dist)
                    SetAsservOffset(new Position(angle, new RealPoint(3000 - dist, Position.Coordinates.Y)));
                else if (Position.Coordinates.Y < dist)
                    SetAsservOffset(new Position(angle, new RealPoint(Position.Coordinates.X, dist)));
                else if (Position.Coordinates.Y > 2000 - dist)
                    SetAsservOffset(new Position(angle, new RealPoint(Position.Coordinates.X, 2000 - dist)));
            }
        }
        public abstract void SendPID(int p, int i, int d);
        public abstract void SendPIDCap(int p, int i, int d);
        public abstract void SendPIDSpeed(int p, int i, int d);

        #endregion

        #region PathFinding

        public Graph Graph { get; set; }
        public bool TrajectoryFailed { get; protected set; }
        public bool TrajectoryCutOff { get; protected set; }
        public Trajectory TrajectoryRunning { get; protected set; }

        public bool IsFarEnough(IShape target, IShape toAvoid, int margin = 0)
        {
            Type typeForme1 = target.GetType();
            Type typeForme2 = toAvoid.GetType();
            bool can;

            if (typeForme1.IsAssignableFrom(typeof(Segment)))
                if (typeForme2.IsAssignableFrom(typeof(Segment)))
                    can = ((Segment)target).Distance((Segment)toAvoid) > Radius + margin;
                else
                    can = ((Segment)target).Distance(toAvoid) > Radius + margin;
            else if (typeForme1.IsAssignableFrom(typeof(Circle)) && typeForme1.IsAssignableFrom(typeof(RealPoint)))
            {
                // très opportuniste
                RealPoint c = ((Circle)target).Center;
                RealPoint p = (RealPoint)toAvoid;
                double dx = c.X - p.X;
                double dy = c.Y - p.Y;

                can = dx * dx + dy * dy > margin * margin;
            }
            else
                can = target.Distance(toAvoid) > Radius + margin;

            return can;
        }

        public bool OpponentsTrajectoryCollision(IEnumerable<IShape> opponents)
        {
            bool ok = true;

            if (TrajectoryCutOff)
                ok = false;

            if (ok)
            {
                try
                {
                    // Teste si le chemin en cours de parcours est toujours franchissable
                    if (TrajectoryRunning != null && TrajectoryRunning.Lines.Count > 0)
                    {
                        List<Segment> segmentsTrajectoire = new List<Segment>();
                        // Calcule le segment entre nous et notre destination (permet de ne pas considérer un obstacle sur un tronçon déjà franchi)
                        Segment toNextPoint = new Segment(Position.Coordinates, new RealPoint(TrajectoryRunning.Lines[0].EndPoint));
                        segmentsTrajectoire.Add(toNextPoint);

                        for (int iSegment = 1; iSegment < TrajectoryRunning.Lines.Count; iSegment++)
                        {
                            segmentsTrajectoire.Add(TrajectoryRunning.Lines[iSegment]);
                        }

                        foreach (IShape opponent in opponents)
                        {
                            foreach (Segment segment in segmentsTrajectoire)
                            {
                                // Marge de 30mm pour être plus permissif sur le passage et ne pas s'arreter dès que l'adversaire approche
                                if (!IsFarEnough(toNextPoint, opponent, -30))
                                {
                                    // Demande de génération d'une nouvelle trajectoire
                                    Historique.Log("Trajectoire coupée, annulation", TypeLog.PathFinding);
                                    TrajectoryCutOff = true;
                                    TrajectoryRunning = null;

                                    if (IsInLineMove)
                                        Stop();
                                    ok = false;
                                    break;
                                }
                            }

                            if (!ok)
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    ok = false;
                }
            }

            return ok;
        }

        public void UpdateGraph(IEnumerable<IShape> obstacles)
        {
            lock (Graph)
            {
                foreach (Arc arc in Graph.Arcs)
                    arc.Passable = true;

                foreach (Node node in Graph.Nodes)
                    node.Passable = true;

                foreach (IShape obstacle in obstacles)
                {
                    // On ne désactive pas les arcs unitairement parce qu'on considère qu'ils sont trop courts pour qu'un arc non franchissable raccord 2 points franchissables
                    // Donc on ne teste que les noeuds non franchissables
                    for (int i = 0; i < Graph.Nodes.Count; i++)
                    {
                        Node n = Graph.Nodes[i];

                        if (n.Passable)
                        {
                            if (!IsFarEnough(obstacle, n.Position))
                            {
                                n.Passable = false;
                                // Désactivation des arcs connectés aux noeuds désactivés = 10 fois plus rapide que tester les arcs
                                foreach (Arc a in n.IncomingArcs) a.Passable = false;
                                foreach (Arc a in n.OutgoingArcs) a.Passable = false;
                            }
                        }
                    }
                }
            }
        }

        public bool RunTrajectory(Trajectory traj)
        {
            TrajectoryRunning = traj;
            TimeSpan estimatedDuration = traj.GetDuration(this);
            Stopwatch sw = Stopwatch.StartNew();

            TrajectoryCutOff = false;
            TrajectoryFailed = false;

            foreach (IAction action in traj.ConvertToActions(this))
            {
                if (!Execution.Shutdown)
                {
                    action.Executer();

                    if (TrajectoryCutOff || TrajectoryFailed)
                        break;

                    if (action is ActionAvance || action is ActionRecule)
                    {
                        Historique.Log("Noeud atteint " + TrajectoryRunning.Points[0].X.ToString("0") + ":" + TrajectoryRunning.Points[0].Y.ToString("0"), TypeLog.PathFinding);
                        TrajectoryRunning.RemovePoint(0);
                    }
                }
            }

            if (!Execution.Shutdown)
            {
                TrajectoryRunning = null;

                if (!TrajectoryCutOff && !TrajectoryFailed)
                {
                    Historique.Log("Trajectoire parcourue en " + (sw.ElapsedMilliseconds / 1000.0).ToString("0.0") + "s (durée théorique : " + (estimatedDuration.TotalSeconds).ToString("0.0") + "s)", TypeLog.PathFinding);

                    return true;
                }

                if (TrajectoryFailed)
                {
                    Historique.Log("Echec du parcours de la trajectoire (dérapage, blocage...)", TypeLog.PathFinding);

                    return false;
                }
            }

            return false;
        }

        #endregion

        #region Sensors

        public bool StartTriggerEnable { get; protected set; } = false;
        public Dictionary<SensorOnOffID, bool> SensorsOnOffValue { get; } = new Dictionary<SensorOnOffID, bool>();
        public Dictionary<SensorColorID, Color> SensorsColorValue { get; } = new Dictionary<SensorColorID, Color>();


        public delegate void SensorOnOffChangedDelegate(SensorOnOffID sensor, bool state);
        public event SensorOnOffChangedDelegate SensorOnOffChanged;

        public delegate void SensorColorChangedDelegate(SensorColorID sensor, Color color);
        public event SensorColorChangedDelegate SensorColorChanged;

        protected void OnSensorOnOffChanged(SensorOnOffID sensor, bool state)
        {
            SensorsOnOffValue[sensor] = state;
            SensorOnOffChanged?.Invoke(sensor, state);
        }

        protected void OnSensorColorChanged(SensorColorID sensor, Color color)
        {
            SensorsColorValue[sensor] = color;
            SensorColorChanged?.Invoke(sensor, color);
        }


        public abstract bool ReadSensorOnOff(SensorOnOffID sensor, bool waitEnd = true);
        public abstract Color ReadSensorColor(SensorColorID sensor, bool waitEnd = true);
        public abstract String ReadLidarMeasure(LidarID lidar, int timeout, out Position refPosition);
        public abstract bool ReadStartTrigger();

        public void EnableStartTrigger()
        {
            StartTriggerEnable = true;
        }


        #endregion

        #region Actuators

        public Dictionary<ActuatorOnOffID, bool> ActuatorOnOffState { get; } = new Dictionary<ActuatorOnOffID, bool>();
        public Dictionary<MotorID, bool> MotorState { get; } = new Dictionary<MotorID, bool>();


        public abstract void SetActuatorOnOffValue(ActuatorOnOffID actuator, bool on);

        public virtual void SetMotorAtPosition(MotorID motor, int position, bool waitEnd = false)
        {
            //Historique.AjouterAction(new ActionMoteur(this, position, motor));
        }

        public virtual void SetMotorAtOrigin(MotorID motor, bool waitEnd = false)
        {
            //TODO historique ?
        }

        public virtual void MotorWaitEnd(MotorID moteur)
        {

        }

        public virtual void SetMotorSpeed(MotorID moteur, SensGD sens, int vitesse)
        {
            if (MotorState.ContainsKey(moteur))
                MotorState[moteur] = vitesse == 0 ? false : true;
            Historique.AjouterAction(new ActionMoteur(this, vitesse, moteur));
        }

        public virtual void SetMotorReset(MotorID moteur)
        {
        }

        public virtual void SetMotorStop(MotorID moteur, StopMode mode)
        {
        }

        public virtual void SetMotorAcceleration(MotorID moteur, int acceleration)
        {
            Historique.AjouterAction(new ActionMoteur(this, acceleration, moteur));
        }

        public void ActuatorsStore()
        {
            Robots.MainRobot.SetAsservOffset(new Position(0, new RealPoint(1500, 1000)));

            // TODOEACHYEAR Lister les actionneurs à ranger pour préparer un match

            ThreadManager.CreateThread(link => { Actionneur.ElevatorLeft.DoStoreActuators(); }).StartThread();
            ThreadManager.CreateThread(link => { Actionneur.ElevatorRight.DoStoreActuators(); }).StartThread();

            Actionneur.FingerLeft.DoPositionHide();
            Actionneur.FingerRight.DoPositionHide();

            Actionneur.ElevatorLeft.DoGrabHide();
            Actionneur.ElevatorRight.DoGrabHide();

            Actionneur.Flags.DoCloseLeft();
            Actionneur.Flags.DoCloseRight();

            Actionneur.Lifter.DoStoreAll();
            Actionneur.Lifter.DoLifterPositionStore();
            Thread.Sleep(150);
            Actionneur.Lifter.DoTilterPositionStore();

            Thread.Sleep(1000);

            Devices.AllDevices.CanServos.DisableAll();
        }

        public void ActuatorsDeploy()
        {
            // TODOEACHYEAR Lister les actionneurs à déployer
        }

        #endregion

        #region Shape

        public double LenghtFront { get; private set; }
        public double LenghtBack { get; private set; }
        public double LenghtTotal => LenghtBack + LenghtFront;
        public double LenghtSquare => Math.Max(LenghtBack, LenghtFront) * 2;
        public double Width { get; private set; }
        public double Radius { get; private set; }
        public double Diameter => Radius * 2;
        public double WheelSpacing { get; private set; }

        public void SetDimensions(double width, double lenghtFront, double lenghtBack, double wheelSpacing, double diameter)
        {
            LenghtFront = lenghtFront;
            LenghtBack = lenghtBack;
            Width = width;
            WheelSpacing = wheelSpacing;
            Radius = diameter / 2;
        }

        public IShape GetBounds()
        {
            IShape contact = new PolygonRectangle(new RealPoint(Position.Coordinates.X - LenghtBack / 2, Position.Coordinates.Y - Width / 2), LenghtBack + LenghtFront, Width);
            contact = contact.Rotation(new AngleDelta(Position.Angle));

            return contact;
        }

        #endregion

    }
}
