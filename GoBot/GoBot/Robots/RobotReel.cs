using GoBot.Actions;
using Geometry;
using Geometry.Shapes;
using GoBot.Communications;
using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using GoBot.Threading;
using GoBot.Communications.UDP;
using GoBot.BoardContext;
using GoBot.Communications.CAN;
using GoBot.Strategies;
using GoBot.Actionneurs;
using GoBot.GameElements;

namespace GoBot
{
    class RobotReel : Robot
    {
        private Dictionary<SensorOnOffID, Semaphore> _lockSensorOnOff;
        private Dictionary<SensorColorID, Semaphore> _lockSensorColor;
        private Dictionary<UdpFrameFunction, Semaphore> _lockFrame;
        private Dictionary<MotorID, Semaphore> _lockMotor;

        private Dictionary<SensorColorID, Board> _boardSensorColor;
        private Dictionary<SensorOnOffID, Board> _boardSensorOnOff;
        private Dictionary<ActuatorOnOffID, Board> _boardActuatorOnOff;
        private Dictionary<MotorID, Board> _boardMotor;

        private Connection _asserConnection;
        private bool _positionReceived;

        private List<double> _lastRecMoveLoad, _lastPwmLeft, _lastPwmRight;
        List<int>[] _lastPidTest;
        private string _lastLidarMeasure;
        private Position _lastLidarPosition;

        public override Position Position { get; protected set; }

        public RobotReel(IDRobot id, Board asserBoard) : base(id, "Robot")
        {
            AsserEnable = true;
            AsservBoard = asserBoard;

            _asserConnection = Connections.UDPBoardConnection[AsservBoard];
            _positionReceived = false;

            _lockFrame = new Dictionary<UdpFrameFunction, Semaphore>();
            foreach (UdpFrameFunction o in Enum.GetValues(typeof(UdpFrameFunction)))
                _lockFrame.Add(o, new Semaphore(0, int.MaxValue));

            _lockMotor = new Dictionary<MotorID, Semaphore>();
            foreach (MotorID o in Enum.GetValues(typeof(MotorID)))
                _lockMotor.Add(o, new Semaphore(0, int.MaxValue));

            _lockSensorOnOff = new Dictionary<SensorOnOffID, Semaphore>();
            foreach (SensorOnOffID o in Enum.GetValues(typeof(SensorOnOffID)))
                _lockSensorOnOff.Add(o, new Semaphore(0, int.MaxValue));

            _lockSensorColor = new Dictionary<SensorColorID, Semaphore>();
            foreach (SensorColorID o in Enum.GetValues(typeof(SensorColorID)))
                _lockSensorColor.Add(o, new Semaphore(0, int.MaxValue));

            _boardSensorColor = new Dictionary<SensorColorID, Board>();
            _boardSensorColor.Add(SensorColorID.BuoyRight, Board.RecMove);
            _boardSensorColor.Add(SensorColorID.BuoyLeft, Board.RecIO);

            _boardSensorOnOff = new Dictionary<SensorOnOffID, Board>();
            _boardSensorOnOff.Add(SensorOnOffID.StartTrigger, Board.RecMove);
            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorLeftBack, Board.RecMove);
            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorLeftFront, Board.RecMove);
            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorRightBack, Board.RecIO);
            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorRightFront, Board.RecIO);
            _boardSensorOnOff.Add(SensorOnOffID.PresenceBuoyRight, Board.RecIO);

            _boardActuatorOnOff = new Dictionary<ActuatorOnOffID, Board>();
            _boardActuatorOnOff.Add(ActuatorOnOffID.PowerSensorColorBuoyRight, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumLeftBack, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumLeftFront, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumLeftBack, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumLeftFront, Board.RecIO);
            _boardActuatorOnOff.Add(ActuatorOnOffID.PowerSensorColorBuoyLeft, Board.RecIO);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumRightBack, Board.RecIO);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumRightFront, Board.RecIO);
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumRightBack, Board.RecIO);
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumRightFront, Board.RecMove);

            // Petit robot
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumLeft, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumRight, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.OpenVacuumBack, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumLeft, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumRight, Board.RecMove);
            _boardActuatorOnOff.Add(ActuatorOnOffID.MakeVacuumBack, Board.RecMove);

            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorLeft, Board.RecMove);
            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorRight, Board.RecMove);
            _boardSensorOnOff.Add(SensorOnOffID.PressureSensorBack, Board.RecMove);

            _boardMotor = new Dictionary<MotorID, Board>();
            _boardMotor.Add(MotorID.ElevatorLeft, Board.RecIO);
            _boardMotor.Add(MotorID.ElevatorRight, Board.RecIO);

            SpeedConfig.ParamChange += SpeedConfig_ParamChange;
        }

        public override void DeInit()
        {

        }

        public override void ShowMessage(string message1, String message2)
        {
            Pepperl display = ((Pepperl)AllDevices.LidarAvoid);
            display.ShowMessage(message1, message2);
            display.SetFrequency(PepperlFreq.Hz50);
        }

        private void SpeedConfig_ParamChange(bool lineAccelChange, bool lineDecelChange, bool lineSpeedChange, bool pivotAccelChange, bool pivotDecelChange, bool pivotSpeedChange)
        {
            if (lineSpeedChange)
            {
                Frame frame = UdpFrameFactory.VitesseLigne(SpeedConfig.LineSpeed, this);
                _asserConnection.SendMessage(frame);
                Historique.AjouterAction(new ActionVitesseLigne(this, SpeedConfig.LineSpeed));
            }
            if (lineAccelChange || lineDecelChange)
            {
                Frame frame = UdpFrameFactory.AccelLigne(SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration, this);
                _asserConnection.SendMessage(frame);
                Historique.AjouterAction(new ActionAccelerationLigne(this, SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration));
            }
            if (pivotSpeedChange)
            {
                Frame frame = UdpFrameFactory.VitessePivot(SpeedConfig.PivotSpeed, this);
                _asserConnection.SendMessage(frame);
                Historique.AjouterAction(new ActionVitessePivot(this, SpeedConfig.PivotSpeed));
            }
            if (pivotAccelChange || pivotDecelChange)
            {
                Frame frame = UdpFrameFactory.AccelPivot(SpeedConfig.PivotAcceleration, this);
                _asserConnection.SendMessage(frame);
                Historique.AjouterAction(new ActionAccelerationPivot(this, SpeedConfig.PivotAcceleration, SpeedConfig.PivotDeceleration));
            }
        }

        private void SetStartTrigger(bool state)
        {
            if (!state && StartTriggerEnable)
            {
                StartTriggerEnable = false;

                if (GameBoard.Strategy == null)
                {
                    if (Config.CurrentConfig.IsMiniRobot)
                        GameBoard.Strategy = new StrategyMini();
                    else
                        GameBoard.Strategy = new StrategyMatch();
                }

                GameBoard.Strategy.ExecuteMatch();
            }
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);

            Connections.ConnectionCan.FrameReceived += ReceptionCanMessage;

            _asserConnection.FrameReceived += ReceptionUdpMessage;

            if (this == Robots.MainRobot)
                Connections.ConnectionIO.FrameReceived += ReceptionUdpMessage;

            //Connections.ConnectionsCan[CanBoard.CanAlim].FrameReceived += ReceptionCanMessage;

            if (this == Robots.MainRobot)
            {
                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Position = new Position(0, new RealPoint(240, 1000));
                else
                    Position = new Position(180, new RealPoint(3000 - 240, 1000));
            }
            else
            {
                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Position = new Position(0, new RealPoint(480, 1000));
                else
                    Position = new Position(180, new RealPoint(3000 - 480, 1000));
            }

            PositionTarget = null; //TODO2018 Init commun à la simu

            PositionsHistorical = new List<Position>();
            _asserConnection.SendMessage(UdpFrameFactory.DemandePositionContinue(50, this));
        }

        public override Color ReadSensorColor(SensorColorID sensor, bool wait = true)
        {
            if (wait) _lockSensorColor[sensor] = new Semaphore(0, int.MaxValue);

            Frame t = UdpFrameFactory.DemandeCapteurCouleur(_boardSensorColor[sensor], sensor);
            Connections.UDPBoardConnection[_boardSensorColor[sensor]].SendMessage(t);

            if (wait) _lockSensorColor[sensor].WaitOne(100);

            return SensorsColorValue[sensor];
        }

        public override bool ReadSensorOnOff(SensorOnOffID sensor, bool wait = true)
        {
            if (wait) _lockSensorOnOff[sensor] = new Semaphore(0, int.MaxValue);

            Frame t = UdpFrameFactory.DemandeCapteurOnOff(_boardSensorOnOff[sensor], sensor);
            Connections.UDPBoardConnection[_boardSensorOnOff[sensor]].SendMessage(t);

            if (wait) _lockSensorOnOff[sensor].WaitOne(100);

            return SensorsOnOffValue[sensor];
        }

        public void AsyncAsserEnable(ThreadLink link)
        {
            link.RegisterName();

            //TODO2020AllDevices.RecGoBot.Buzz(7000, 200);

            Thread.Sleep(500);
            TrajectoryFailed = true;
            Stop(StopMode.Abrupt);
            _lockFrame[UdpFrameFunction.FinDeplacement]?.Release();

            //TODO2020AllDevices.RecGoBot.Buzz(0, 200);
        }

        public void ReceptionCanMessage(Frame frame)
        {
            switch (CanFrameFactory.ExtractFunction(frame))
            {
                case CanFrameFunction.BatterieVoltage:
                    BatterieVoltage = (frame[3] * 256 + frame[4]) / 1000f;
                    BatterieIntensity = (frame[5] * 256 + frame[6]) / 1000f;
                    break;
            }
        }

        public void ReceptionUdpMessage(Frame frame)
        {
            // Analyser la trame reçue

            //Console.WriteLine(trameRecue.ToString());

            switch ((UdpFrameFunction)frame[1])
            {
                case UdpFrameFunction.RetourTension:
                    //BatterieVoltage = (frame[2] * 256 + frame[3]) / 100f;
                    break;
                case UdpFrameFunction.MoteurFin:
                    _lockMotor[(MotorID)frame[2]]?.Release();
                    break;
                case UdpFrameFunction.MoteurBlocage:    // Idem avec bip
                    _lockMotor[(MotorID)frame[2]]?.Release();
                    //TODO2020AllDevices.RecGoBot.Buzz("..");
                    break;
                case UdpFrameFunction.Blocage:
                    ThreadManager.CreateThread(AsyncAsserEnable).StartThread();
                    break;
                case UdpFrameFunction.FinDeplacement:
                case UdpFrameFunction.FinRecallage:        // Idem
                    Thread.Sleep(40); // TODO2018 ceci est une tempo ajoutée au pif de pwet parce qu'on avant envie alors voilà
                    IsInLineMove = false;
                    _lockFrame[UdpFrameFunction.FinDeplacement]?.Release();
                    break;
                case UdpFrameFunction.AsserRetourPositionXYTeta:
                    // Réception de la position mesurée par l'asservissement
                    try
                    {
                        double y = (double)((short)(frame[2] << 8 | frame[3]) / 10.0);
                        double x = (double)((short)(frame[4] << 8 | frame[5]) / 10.0);
                        double teta = (frame[6] << 8 | frame[7]) / 100.0 - 180;
                        teta = (-teta);
                        y = -y;
                        x = -x;

                        Position nouvellePosition = new Position(teta, new RealPoint(x, y));

                        if (Position.Coordinates.Distance(nouvellePosition.Coordinates) < 300 || !_positionReceived)
                        {
                            // On reçoit la position du robot
                            // On la prend si elle est pas très éloignée de la position précédente ou si je n'ai jamais reçu de position
                            Position = nouvellePosition;
                        }
                        else
                        {
                            // On pense avoir une meilleure position à lui redonner parce que la position reçue est loin de celle qu'on connait alors qu'on l'avait reçue du robot
                            SetAsservOffset(Position);
                        }

                        _positionReceived = true;

                        _lockFrame[UdpFrameFunction.AsserDemandePositionXYTeta]?.Release();

                        lock (PositionsHistorical)
                        {
                            PositionsHistorical.Add(new Position(teta, new RealPoint(x, y)));

                            while (PositionsHistorical.Count > 1200)
                                PositionsHistorical.RemoveAt(0);
                        }

                        OnPositionChanged(Position);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Erreur dans le retour de position asservissement.");
                    }
                    break;
                case UdpFrameFunction.AsserRetourPositionCodeurs:
                    int nbPositions = frame[2];

                    for (int i = 0; i < nbPositions; i++)
                    {
                        // TODO2018 peut mieux faire, décaller les bits
                        int gauche1 = frame[3 + i * 8];
                        int gauche2 = frame[4 + i * 8];
                        int gauche3 = frame[5 + i * 8];
                        int gauche4 = frame[6 + i * 8];

                        int codeurGauche = gauche1 * 256 * 256 * 256 + gauche2 * 256 * 256 + gauche3 * 256 + gauche4;

                        int droite1 = frame[7 + i * 8];
                        int droite2 = frame[8 + i * 8];
                        int droite3 = frame[9 + i * 8];
                        int droite4 = frame[10 + i * 8];

                        int codeurDroit = droite1 * 256 * 256 * 256 + droite2 * 256 * 256 + droite3 * 256 + droite4;

                        _lastPidTest[0].Add(codeurGauche);
                        _lastPidTest[1].Add(codeurDroit);
                    }
                    break;
                case UdpFrameFunction.RetourChargeCPU_PWM:
                    int valsCount = frame[2];

                    for (int i = 0; i < valsCount; i++)
                    {
                        double cpuLoad = (frame[3 + i * 6] * 256 + frame[4 + i * 6]) / 5000.0;
                        double pwmLeft = frame[5 + i * 6] * 256 + frame[6 + i * 6] - 4000;
                        double pwmRight = frame[7 + i * 6] * 256 + frame[8 + i * 6] - 4000;


                        _lastRecMoveLoad.Add(cpuLoad);
                        _lastPwmLeft.Add(pwmLeft);
                        _lastPwmRight.Add(pwmRight);
                    }
                    break;
                case UdpFrameFunction.RetourCapteurCouleur:
                    //TODO2018 : multiplier par 2 pour obtenir de belles couleurs ?

                    SensorColorID sensorColor = (SensorColorID)frame[2];

                    Color newColor = Color.FromArgb(Math.Min(255, frame[3] * 1), Math.Min(255, frame[4] * 1), Math.Min(255, frame[5] * 1));

                    if (newColor != SensorsColorValue[sensorColor])
                        OnSensorColorChanged(sensorColor, newColor);

                    _lockSensorColor[(SensorColorID)frame[2]]?.Release();
                    break;
                case UdpFrameFunction.RetourCapteurOnOff:
                    SensorOnOffID sensorOnOff = (SensorOnOffID)frame[2];

                    bool newState = frame[3] > 0 ? true : false;

                    if (sensorOnOff == SensorOnOffID.StartTrigger)
                        SetStartTrigger(newState);

                    if (sensorOnOff == SensorOnOffID.PresenceBuoyRight && newState && Actionneur.ElevatorRight.Armed)
                    {
                        Actionneur.ElevatorRight.Armed = false;
                        Actionneur.ElevatorRight.DoSequencePickupColorThread(Buoy.Red);
                    }

                    if (newState != SensorsOnOffValue[sensorOnOff])
                        OnSensorOnOffChanged(sensorOnOff, newState);

                    _lockSensorOnOff[sensorOnOff]?.Release();

                    break;
                case UdpFrameFunction.RetourValeursNumeriques:
                    Board numericBoard = (Board)frame[0];

                    lock (NumericPinsValue)
                    {
                        NumericPinsValue[numericBoard][0] = (Byte)frame[2];
                        NumericPinsValue[numericBoard][1] = (Byte)frame[3];
                        NumericPinsValue[numericBoard][2] = (Byte)frame[4];
                        NumericPinsValue[numericBoard][3] = (Byte)frame[5];
                        NumericPinsValue[numericBoard][4] = (Byte)frame[6];
                        NumericPinsValue[numericBoard][5] = (Byte)frame[7];
                    }

                    _lockFrame[UdpFrameFunction.RetourValeursNumeriques]?.Release();
                    break;

                case UdpFrameFunction.RetourValeursAnalogiques:
                    Board analogBoard = (Board)frame[0];

                    const double toVolts = 0.0008056640625;

                    List<double> values = new List<double>();
                    AnalogicPinsValue[analogBoard][0] = ((frame[2] * 256 + frame[3]) * toVolts);
                    AnalogicPinsValue[analogBoard][1] = ((frame[4] * 256 + frame[5]) * toVolts);
                    AnalogicPinsValue[analogBoard][2] = ((frame[6] * 256 + frame[7]) * toVolts);
                    AnalogicPinsValue[analogBoard][3] = ((frame[8] * 256 + frame[9]) * toVolts);
                    AnalogicPinsValue[analogBoard][4] = ((frame[10] * 256 + frame[11]) * toVolts);
                    AnalogicPinsValue[analogBoard][5] = ((frame[12] * 256 + frame[13]) * toVolts);
                    AnalogicPinsValue[analogBoard][6] = ((frame[14] * 256 + frame[15]) * toVolts);
                    AnalogicPinsValue[analogBoard][7] = ((frame[16] * 256 + frame[17]) * toVolts);
                    AnalogicPinsValue[analogBoard][8] = ((frame[18] * 256 + frame[19]) * toVolts);

                    _lockFrame[UdpFrameFunction.RetourValeursAnalogiques]?.Release();
                    break;
                case UdpFrameFunction.ReponseLidar:
                    int lidarID = frame[2];

                    if (_lastLidarMeasure == null)
                        _lastLidarMeasure = "";

                    string mess = "";
                    int decallageEntete = 3;

                    if (_lastLidarMeasure.Length == 0)
                    {
                        // C'est le début de la trame à recomposer, et au début y'a la position de la prise de mesure à lire !

                        double y = (double)((short)(frame[3] << 8 | frame[4]) / 10.0);
                        double x = (double)((short)(frame[5] << 8 | frame[6]) / 10.0);
                        double teta = (frame[7] << 8 | frame[8]) / 100.0 - 180;

                        _lastLidarPosition = new Position(-teta, new RealPoint(-x, -y));
                        decallageEntete += 6;
                    }

                    for (int i = decallageEntete; i < frame.Length; i++)
                    {
                        _lastLidarMeasure += (char)frame[i];
                        mess += (char)frame[i];
                    }

                    if (Regex.Matches(_lastLidarMeasure, "\n\n").Count == 2)
                    {
                        _lockFrame[UdpFrameFunction.ReponseLidar]?.Release();
                    }
                    break;
                case UdpFrameFunction.RetourCouleurEquipe:
                    GameBoard.MyColor = frame[2] == 0 ? GameBoard.ColorLeftBlue : GameBoard.ColorRightYellow;
                    if (Config.CurrentConfig.IsMiniRobot) StartTriggerEnable = true;
                    break;
            }
        }

        #region Déplacements

        public override void SetAsservOffset(Position newPosition)
        {
            Position.Copy(newPosition);
            newPosition.Angle = -newPosition.Angle; // Repère angulaire du robot inversé

            Frame frame = UdpFrameFactory.OffsetPos(newPosition, this);
            _asserConnection.SendMessage(frame);

            OnPositionChanged(Position);
        }

        public override void MoveForward(int distance, bool wait = true)
        {
            //TODO2018 : FOnction de déplacement communes avec Simu sur l'historique etc, à voir, le recallage de Simu se fait en avancant...
            base.MoveForward(distance, wait);

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            IsInLineMove = true;

            Frame frame;
            if (distance < 0)
                frame = UdpFrameFactory.Deplacer(SensAR.Arriere, -distance, this);
            else
                frame = UdpFrameFactory.Deplacer(SensAR.Avant, distance, this);

            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionAvance(this, distance));

            if (wait)
            {
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.LineDuration(distance).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
            }
        }

        public override void MoveBackward(int distance, bool wait = true)
        {
            base.MoveBackward(distance, wait);

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            IsInLineMove = true;

            Frame frame;
            if (distance < 0)
                frame = UdpFrameFactory.Deplacer(SensAR.Avant, -distance, this);
            else
                frame = UdpFrameFactory.Deplacer(SensAR.Arriere, distance, this);

            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionRecule(this, distance));

            if (wait)
            {
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.LineDuration(distance).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
            }
        }

        public override void PivotLeft(AngleDelta angle, bool wait = true)
        {
            base.PivotLeft(angle, wait);

            angle = Math.Round(angle, 2);

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.Pivot(SensGD.Gauche, angle, this);
            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));

            if (wait)
            {
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.PivotDuration(angle, Entraxe).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
            }
        }

        public override void PivotRight(AngleDelta angle, bool wait = true)
        {
            base.PivotRight(angle, wait);

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.Pivot(SensGD.Droite, angle, this);
            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));

            if (wait)
            {
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.PivotDuration(angle, Entraxe).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
            }
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            AsserEnable = (mode != StopMode.Freely);

            IsInLineMove = false;

            Frame frame = UdpFrameFactory.Stop(mode, this);
            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionStop(this, mode));
        }

        public override void Turn(SensAR sensAr, SensGD sensGd, int radius, AngleDelta angle, bool wait = true)
        {
            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.Virage(sensAr, sensGd, radius, angle, this);
            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionVirage(this, radius, angle, sensAr, sensGd));

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
        }

        public override void PolarTrajectory(SensAR sens, List<RealPoint> points, bool wait = true)
        {
            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.TrajectoirePolaire(sens, points, this);
            _asserConnection.SendMessage(frame);

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
        }

        public override void Recalibration(SensAR sens, bool wait = true, bool sendOffset = false)
        {
            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.Recallage(sens, this);
            _asserConnection.SendMessage(frame);

            Historique.AjouterAction(new ActionRecallage(this, sens));

            if (wait) _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();

            base.Recalibration(sens, wait, sendOffset);
        }

        #endregion

        public override void SendPID(int p, int i, int d)
        {
            Frame frame = UdpFrameFactory.CoeffAsserv(p, i, d, this);
            _asserConnection.SendMessage(frame);
        }

        public override void SendPIDCap(int p, int i, int d)
        {
            Frame frame = UdpFrameFactory.CoeffAsservCap(p, i, d, this);
            _asserConnection.SendMessage(frame);
        }

        public override void SendPIDSpeed(int p, int i, int d)
        {
            Frame frame = UdpFrameFactory.CoeffAsservVitesse(p, i, d, this);
            _asserConnection.SendMessage(frame);
        }

        public Position ReadPosition()
        {
            _lockFrame[UdpFrameFunction.AsserRetourPositionCodeurs] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.DemandePosition(this);
            _asserConnection.SendMessage(frame);

            _lockFrame[UdpFrameFunction.AsserRetourPositionXYTeta].WaitOne(100);

            return Position;
        }

        public override void ReadAnalogicPins(Board board, bool wait = true)
        {
            if (wait) _lockFrame[UdpFrameFunction.RetourValeursAnalogiques] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.DemandeValeursAnalogiques(board);
            Connections.UDPBoardConnection[board].SendMessage(frame);

            if (wait) _lockFrame[UdpFrameFunction.RetourValeursAnalogiques].WaitOne(100);
        }

        public override void ReadNumericPins(Board board, bool wait = true)
        {
            if (wait) _lockFrame[UdpFrameFunction.RetourValeursNumeriques] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.DemandeValeursNumeriques(board);
            Connections.UDPBoardConnection[board].SendMessage(frame);

            if (wait) _lockFrame[UdpFrameFunction.RetourValeursNumeriques].WaitOne(100);
        }

        public override void SetActuatorOnOffValue(ActuatorOnOffID actuator, bool on)
        {
            ActuatorOnOffState[actuator] = on;

            Frame frame = UdpFrameFactory.ActionneurOnOff(_boardActuatorOnOff[actuator], actuator, on);
            Connections.UDPBoardConnection[_boardActuatorOnOff[actuator]].SendMessage(frame);

            Historique.AjouterAction(new ActionOnOff(this, actuator, on));
        }

        public override void SetMotorAtPosition(MotorID motor, int position, bool wait)
        {
            base.SetMotorAtPosition(motor, position);

            if (wait) _lockMotor[motor] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.MoteurPosition(_boardMotor[motor], motor, position);
            Connections.UDPBoardConnection[_boardMotor[motor]].SendMessage(frame);

            if (wait) _lockMotor[motor].WaitOne(5000);
        }

        public override void MotorWaitEnd(MotorID motor)
        {
            base.MotorWaitEnd(motor);

            _lockMotor[motor].WaitOne(5000);
        }

        public override void SetMotorAtOrigin(MotorID motor, bool wait)
        {
            base.SetMotorAtOrigin(motor);

            if (wait) _lockMotor[motor] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.MoteurOrigin(_boardMotor[motor], motor);
            Connections.UDPBoardConnection[_boardMotor[motor]].SendMessage(frame);

            if (wait) _lockMotor[motor].WaitOne(30000);
        }

        public override void SetMotorSpeed(MotorID motor, SensGD sens, int speed)
        {
            base.SetMotorSpeed(motor, sens, speed);

            Frame trame = UdpFrameFactory.MoteurVitesse(_boardMotor[motor], motor, sens, speed);
            Connections.UDPBoardConnection[_boardMotor[motor]].SendMessage(trame);
        }

        public override void SetMotorReset(MotorID motor)
        {
            base.SetMotorReset(motor);

            Frame trame = UdpFrameFactory.MoteurResetPosition(_boardMotor[motor], motor);
            Connections.UDPBoardConnection[_boardMotor[motor]].SendMessage(trame);
        }

        public override void SetMotorStop(MotorID motor, StopMode mode)
        {
            base.SetMotorStop(motor, mode);

            Frame trame = UdpFrameFactory.MoteurStop(_boardMotor[motor], motor, mode);
            Connections.UDPBoardConnection[_boardMotor[motor]].SendMessage(trame);
        }

        public override void SetMotorAcceleration(MotorID motor, int acceleration)
        {
            base.SetMotorAcceleration(motor, acceleration);

            Frame trame = UdpFrameFactory.MoteurAcceleration(_boardMotor[motor], motor, acceleration);
            Connections.UDPBoardConnection[_boardMotor[motor]].SendMessage(trame);
        }

        public override void EnablePower(bool on)
        {
            // TODOEACHYEAR : couper tout manuellement

            Stop(StopMode.Freely);
        }

        public override bool ReadStartTrigger()
        {
            return ReadSensorOnOff(SensorOnOffID.StartTrigger, true);
        }

        public override List<int>[] DiagnosticPID(int steps, SensAR sens, int pointsCount)
        {
            _lastPidTest = new List<int>[2];
            _lastPidTest[0] = new List<int>();
            _lastPidTest[1] = new List<int>();

            Frame frame = UdpFrameFactory.EnvoiConsigneBrute(steps, sens, this);
            _asserConnection.SendMessage(frame);

            frame = UdpFrameFactory.DemandePositionsCodeurs(this);
            while (_lastPidTest[0].Count < pointsCount)
            {
                _asserConnection.SendMessage(frame);
                Thread.Sleep(30);
            }

            List<int>[] output = new List<int>[2];
            output[0] = _lastPidTest[0].GetRange(0, pointsCount);
            output[1] = _lastPidTest[1].GetRange(0, pointsCount);

            return output;
        }

        public override List<int>[] DiagnosticLine(int distance, SensAR sens)
        {
            _lastPidTest = new List<int>[2];
            _lastPidTest[0] = new List<int>();
            _lastPidTest[1] = new List<int>();

            _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame frame = UdpFrameFactory.Deplacer(sens, distance, this);
            _asserConnection.SendMessage(frame);

            frame = UdpFrameFactory.DemandePositionsCodeurs(this);

            while (!_lockFrame[UdpFrameFunction.FinDeplacement].WaitOne(0))
            {
                _asserConnection.SendMessage(frame);
                Thread.Sleep(30);
            }

            List<int>[] output = new List<int>[2];
            output[0] = new List<int>(_lastPidTest[0]);
            output[1] = new List<int>(_lastPidTest[1]);

            return output;
        }

        public override List<double>[] DiagnosticCpuPwm(int pointsCount)
        {
            _lastRecMoveLoad = new List<double>();
            _lastPwmLeft = new List<double>();
            _lastPwmRight = new List<double>();

            Frame frame = UdpFrameFactory.DemandeCpuPwm(this);
            while (_lastRecMoveLoad.Count <= pointsCount)
            {
                _asserConnection.SendMessage(frame);
                Thread.Sleep(30);
            }

            // Supprime d'éventuelles valeurs supplémentaires
            while (_lastRecMoveLoad.Count > pointsCount)
                _lastRecMoveLoad.RemoveAt(_lastRecMoveLoad.Count - 1);

            while (_lastPwmLeft.Count > pointsCount)
                _lastPwmLeft.RemoveAt(_lastPwmLeft.Count - 1);

            while (_lastPwmRight.Count > pointsCount)
                _lastPwmRight.RemoveAt(_lastPwmRight.Count - 1);

            return new List<double>[3] { _lastRecMoveLoad, _lastPwmLeft, _lastPwmRight };
        }

        public void EnvoyerUart(Board byBoard, Frame frame)
        {
            Frame frameUdp = UdpFrameFactory.EnvoyerUart1(byBoard, frame);
            Connections.UDPBoardConnection[byBoard].SendMessage(frameUdp);
        }

        public override String ReadLidarMeasure(LidarID lidar, int timeout, out Position refPosition)
        {
            _lastLidarMeasure = "";

            _lockFrame[UdpFrameFunction.ReponseLidar] = new Semaphore(0, int.MaxValue);
            Connections.ConnectionMove.SendMessage(UdpFrameFactory.DemandeMesureLidar(lidar));
            _lockFrame[UdpFrameFunction.ReponseLidar].WaitOne(timeout);

            refPosition = _lastLidarPosition;

            return _lastLidarMeasure;
        }
    }
}
