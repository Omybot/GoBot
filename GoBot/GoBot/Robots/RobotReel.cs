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

namespace GoBot
{
    class RobotReel : Robot
    {
        private Dictionary<SensorOnOffID, Semaphore> _lockSensorOnOff = new Dictionary<SensorOnOffID, Semaphore>();
        private Dictionary<SensorColorID, Semaphore> _lockSensorColor = new Dictionary<SensorColorID, Semaphore>();
        private Dictionary<UdpFrameFunction, Semaphore> _lockFrame = new Dictionary<UdpFrameFunction, Semaphore>();
        private Dictionary<MotorID, Semaphore> _lockMotor = new Dictionary<MotorID, Semaphore>();
        
        private bool _positionReceived = false;

        private List<double> _lastRecMoveLoad, _lastPwmLeft, _lastPwmRight;
        private Color _lastTeamColor;
        List<int>[] _lastPidTest;
        private String _lastLidarMeasure;
        private Position _lastLidarPosition;
        
        public Connection ConnectionAsser { get; set; }
        public override Position Position { get; set; }

        public RobotReel(IDRobot idRobot, Board asserBoard, double width, double lenght, double wheelSpacing, double diameter) : base(width, lenght, wheelSpacing, diameter)
        {
            AsserEnable = true;
            AsservBoard = asserBoard;
            IDRobot = idRobot;
            
            foreach (UdpFrameFunction o in Enum.GetValues(typeof(UdpFrameFunction)))
                _lockFrame.Add(o, new Semaphore(0, int.MaxValue));

            foreach (MotorID o in Enum.GetValues(typeof(MotorID)))
                _lockMotor.Add(o, new Semaphore(0, int.MaxValue));

            foreach (SensorOnOffID o in Enum.GetValues(typeof(SensorOnOffID)))
                _lockSensorOnOff.Add(o, new Semaphore(0, int.MaxValue));
            
            foreach (SensorColorID o in Enum.GetValues(typeof(SensorColorID)))
                _lockSensorColor.Add(o, new Semaphore(0, int.MaxValue));
            
            SpeedConfig.ParamChange += SpeedConfig_ParamChange;
        }

        public override void DeInit()
        {

        }

        private void SpeedConfig_ParamChange(bool lineAccelChange, bool lineDecelChange, bool lineSpeedChange, bool pivotAccelChange, bool pivotDecelChange, bool pivotSpeedChange)
        {
            if (lineSpeedChange)
            {
                Frame frame = UdpFrameFactory.VitesseLigne(SpeedConfig.LineSpeed, this);
                ConnectionAsser.SendMessage(frame);
                Historique.AjouterAction(new ActionVitesseLigne(this, SpeedConfig.LineSpeed));
            }
            if (lineAccelChange || lineDecelChange)
            {
                Frame frame = UdpFrameFactory.AccelLigne(SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration, this);
                ConnectionAsser.SendMessage(frame);
                Historique.AjouterAction(new ActionAccelerationLigne(this, SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration));
            }
            if (pivotSpeedChange)
            {
                Frame frame = UdpFrameFactory.VitessePivot(SpeedConfig.PivotSpeed, this);
                ConnectionAsser.SendMessage(frame);
                Historique.AjouterAction(new ActionVitessePivot(this, SpeedConfig.PivotSpeed));
            }
            if (pivotAccelChange || pivotDecelChange)
            {
                Frame frame = UdpFrameFactory.AccelPivot(SpeedConfig.PivotAcceleration, this);
                ConnectionAsser.SendMessage(frame);
                Historique.AjouterAction(new ActionAccelerationPivot(this, SpeedConfig.PivotAcceleration, SpeedConfig.PivotDeceleration));
            }
        }

        void RecGoBot_JackChange(bool state)
        {
            if (!state && StartTriggerEnable)
            {
                StartTriggerEnable = false;
                if (GameBoard.Strategy == null)
                    GameBoard.Strategy = new GoBot.Strategies.StrategyMatch();
                GameBoard.Strategy.ExecuteMatch();
            }
        }

        void RecGoBot_ColorChange(MatchColor state)
        {
            if (state == MatchColor.LeftBlue)
                _lastTeamColor = GameBoard.ColorLeftBlue;
            else if (state == MatchColor.RightYellow)
                _lastTeamColor = GameBoard.ColorRightYellow;

            GameBoard.MyColor = _lastTeamColor;

            _lockFrame[UdpFrameFunction.RetourCouleurEquipe]?.Release();
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);
            
            ConnectionAsser.FrameReceived += new UDPConnection.NewFrameDelegate(ReceptionMessage);

            if (this == Robots.MainRobot)
                Connections.ConnectionIO.FrameReceived += new UDPConnection.NewFrameDelegate(ReceptionMessage);

            Connections.ConnectionGB.FrameReceived += new UDPConnection.NewFrameDelegate(ReceptionMessage);

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
            ConnectionAsser.SendMessage(UdpFrameFactory.DemandePositionContinue(100, this));

            AllDevices.RecGoBot.ColorChange += RecGoBot_ColorChange;
            AllDevices.RecGoBot.JackChange += RecGoBot_JackChange;
        }

        public override Color ReadSensorColor(SensorColorID capteur, bool attendre = true)
        {
            if (attendre)
                _lockSensorColor[capteur] = new Semaphore(0, int.MaxValue);

            Frame t = UdpFrameFactory.DemandeCapteurCouleur(capteur);
            Connections.ConnectionIO.SendMessage(t);

            if (attendre)
                _lockSensorColor[capteur].WaitOne(100);

            return SensorsColorValue[capteur];
        }

        public override bool ReadSensorOnOff(SensorOnOffID capteur, bool attendre = true)
        {
            if (attendre)
                _lockSensorOnOff[capteur] = new Semaphore(0, int.MaxValue);

            Frame t = UdpFrameFactory.DemandeCapteurOnOff(capteur);
            Connections.ConnectionGB.SendMessage(t);

            if (attendre)
                _lockSensorOnOff[capteur].WaitOne(1000);
            Console.WriteLine("Retour " + SensorsOnOffValue[capteur].ToString());
            return SensorsOnOffValue[capteur];
        }

        public void ReactivationAsserv(ThreadLink link)
        {
            link.RegisterName();

            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                AllDevices.RecGoBot.SetLed((LedID)i, RecGoBot.LedStatus.Rouge);

            AllDevices.RecGoBot.Buzz(7000, 200);

            Thread.Sleep(500);
            TrajectoryFailed = true;
            Stop(StopMode.Abrupt);
            _lockFrame[UdpFrameFunction.FinDeplacement]?.Release();

            AllDevices.RecGoBot.Buzz(0, 200);

            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                AllDevices.RecGoBot.SetLed((LedID)i, RecGoBot.LedStatus.Off);
        }

        public void ReceptionMessage(Frame frame)
        {
            // Analyser la trame reçue

            //Console.WriteLine(trameRecue.ToString());

            switch ((UdpFrameFunction)frame[1])
            {
                case UdpFrameFunction.MoteurFin:
                    _lockMotor[(MotorID)frame[2]]?.Release();
                    break;
                case UdpFrameFunction.MoteurBlocage:    // Idem avec bip
                    _lockMotor[(MotorID)frame[2]]?.Release();
                    AllDevices.RecGoBot.Buzz("..");
                    break;
                case UdpFrameFunction.Blocage:
                    ThreadManager.CreateThread(ReactivationAsserv).StartThread();
                    break;
                case UdpFrameFunction.FinDeplacement:
                case UdpFrameFunction.FinRecallage:        // Idem
                    Thread.Sleep(40); // TODO2018 ceci est une tempo ajoutée au pif de pwet parce qu'on avant envie alors voilà
                    Console.WriteLine("Déblocage déplacement " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond);
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
                    int nbValeurs = frame[2];

                    for (int i = 0; i < nbValeurs; i++)
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
                    Color couleur = Color.FromArgb(Math.Min(255, frame[3] * 1), Math.Min(255, frame[4] * 1), Math.Min(255, frame[5] * 1));

                    OnSensorColorChanged((SensorColorID)frame[2], couleur);
                    SensorsColorValue[(SensorColorID)frame[2]] = couleur;

                    _lockSensorColor[(SensorColorID)frame[2]]?.Release();
                    break;
                case UdpFrameFunction.RetourCapteurOnOff:
                    SensorOnOffID capteur = (SensorOnOffID)frame[2];


                    //if (trameRecue[2] == (byte)CapteurID.Balise)
                    //{
                    //    // Recomposition de la trame comme si elle venait d'une balise
                    //    String message = "B1 E4 " + trameRecue.ToString().Substring(9);
                    //    if (Plateau.Balise != null)
                    //        Plateau.Balise.connexion_NouvelleTrame(new Trame(message));
                    //}

                    //else if (trameRecue[2] == (byte)CapteurID.BaliseRapide1)
                    //{
                    //    // Recomposition de la trame comme si elle venait d'une balise
                    //    String message = "B1 E5 02 " + trameRecue.ToString().Substring(9);
                    //    if (Plateau.Balise != null)
                    //        Plateau.Balise.connexion_NouvelleTrame(new Trame(message));
                    //}

                    //else if (trameRecue[2] == (byte)CapteurID.BaliseRapide2)
                    //{
                    //    // Recomposition de la trame comme si elle venait d'une balise
                    //    String message = "B1 E5 01 " + trameRecue.ToString().Substring(9);
                    //    if (Plateau.Balise != null)
                    //        Plateau.Balise.connexion_NouvelleTrame(new Trame(message));
                    //}

                    //else
                    {

                        bool nouvelEtat = frame[3] > 0 ? true : false;

                        if (nouvelEtat != SensorsOnOffValue[capteur])
                            OnSensorOnOffChanged(capteur, nouvelEtat);

                        _lockSensorOnOff[capteur]?.Release();
                    }
                    break;
                case UdpFrameFunction.TensionBatteries:
                    BatterieVoltage = (double)(frame[2] * 256 + frame[3]) / 100.0;
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

                    String mess = "";
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
            }
        }

        #region Déplacements

        public override void MoveForward(int distance, bool attendre = true)
        {
            //TODO2018 : FOnction de déplacement communes avec Simu sur l'historique etc, à voir, le recallage de Simu se fait en avancant...
            //TODO2018 : En finir avec Avancer Reculer PivotGauche PivotDroite et se contenter de Move & Turn avec des négatifs qui font le job
            base.MoveForward(distance, attendre);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            IsInLineMove = true;
            Frame trame = UdpFrameFactory.Deplacer(SensAR.Avant, distance, this);
            ConnectionAsser.SendMessage(trame);

            Historique.AjouterAction(new ActionAvance(this, distance));

            if (attendre)
            {
                int duration = (int)SpeedConfig.LineDuration(distance).TotalMilliseconds;
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.LineDuration(distance).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
            }

            IsInLineMove = false;
        }

        public override void SetAsservOffset(Position newPosition)
        {
            Position.Copy(newPosition);
            newPosition.Angle = -newPosition.Angle; // Repère angulaire du robot inversé
            Frame trame = UdpFrameFactory.OffsetPos(newPosition, this);
            ConnectionAsser.SendMessage(trame);
            OnPositionChanged(Position);
        }

        public override void MoveBackward(int distance, bool attendre = true)
        {
            base.MoveBackward(distance, attendre);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            IsInLineMove = true;
            Frame trame = UdpFrameFactory.Deplacer(SensAR.Arriere, distance, this);
            ConnectionAsser.SendMessage(trame);

            Historique.AjouterAction(new ActionRecule(this, distance));

            if (attendre)
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.LineDuration(distance).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();

            IsInLineMove = false;
        }

        public override void PivotLeft(AngleDelta angle, bool attendre = true)
        {
            base.PivotLeft(angle, attendre);

            angle = Math.Round(angle, 2);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame trame = UdpFrameFactory.Pivot(SensGD.Gauche, angle, this);
            ConnectionAsser.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));

            if (attendre)
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.PivotDuration(angle, Entraxe).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
            IsInLineMove = false;
        }

        public override void PivotRight(AngleDelta angle, bool attendre = true)
        {
            base.PivotRight(angle, attendre);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame trame = UdpFrameFactory.Pivot(SensGD.Droite, angle, this);
            ConnectionAsser.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));

            if (attendre)
                //if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.PivotDuration(angle, Entraxe).TotalMilliseconds))
                //    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            AsserEnable = (mode != StopMode.Freely);

            Frame trame = UdpFrameFactory.Stop(mode, this);
            IsInLineMove = false;

            ConnectionAsser.SendMessage(trame);

            Historique.AjouterAction(new ActionStop(this, mode));
        }

        public override void Turn(SensAR sensAr, SensGD sensGd, int rayon, AngleDelta angle, bool attendre = true)
        {
            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd));

            Frame trame = UdpFrameFactory.Virage(sensAr, sensGd, rayon, angle, this);
            ConnectionAsser.SendMessage(trame);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
        }

        public override void PolarTrajectory(SensAR sens, List<RealPoint> points, bool attendre = true)
        {
            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            //Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd)); TODO

            Frame trame = UdpFrameFactory.TrajectoirePolaire(sens, points, this);
            ConnectionAsser.SendMessage(trame);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
        }

        public override void Recalibration(SensAR sens, bool attendre = true)
        {
            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionRecallage(this, sens));
            Frame trame = UdpFrameFactory.Recallage(sens, this);
            ConnectionAsser.SendMessage(trame);

            if (attendre)
                _lockFrame[UdpFrameFunction.FinDeplacement].WaitOne();
        }

        #endregion

        public override void SendPID(int p, int i, int d)
        {
            Frame trame = UdpFrameFactory.CoeffAsserv(p, i, d, this);
            ConnectionAsser.SendMessage(trame);
        }

        public override void SendPIDCap(int p, int i, int d)
        {
            Frame trame = UdpFrameFactory.CoeffAsservCap(p, i, d, this);
            ConnectionAsser.SendMessage(trame);
        }

        public override void SendPIDSpeed(int p, int i, int d)
        {
            Frame trame = UdpFrameFactory.CoeffAsservVitesse(p, i, d, this);
            ConnectionAsser.SendMessage(trame);
        }

        public bool DemandePosition(bool attendre = true)
        {
            if (!ConnectionAsser.ConnectionChecker.Connected)
                return false;

            if (attendre)
                _lockFrame[UdpFrameFunction.AsserRetourPositionCodeurs] = new Semaphore(0, int.MaxValue);

            Frame t = UdpFrameFactory.DemandePosition(this);
            ConnectionAsser.SendMessage(t);

            if (attendre)
                return _lockFrame[UdpFrameFunction.AsserRetourPositionXYTeta].WaitOne(1000);// semPosition.WaitOne(1000);
            else
                return true;
        }

        public override void ReadAnalogicPins(Board carte, bool attendre = true)
        {
            if (!Connections.UDPBoardConnection[carte].ConnectionChecker.Connected)
                return;

            if (attendre)
                _lockFrame[UdpFrameFunction.RetourValeursAnalogiques] = new Semaphore(0, int.MaxValue);

            Frame trame = UdpFrameFactory.DemandeValeursAnalogiques(carte);
            Connections.UDPBoardConnection[carte].SendMessage(trame);

            if (attendre)
                _lockFrame[UdpFrameFunction.RetourValeursAnalogiques].WaitOne(1000);
        }

        public override void ReadNumericPins(Board carte, bool attendre = true)
        {
            if (!Connections.UDPBoardConnection[carte].ConnectionChecker.Connected)
                return;

            if (attendre)
                _lockFrame[UdpFrameFunction.RetourValeursNumeriques] = new Semaphore(0, int.MaxValue);

            Frame trame = UdpFrameFactory.DemandeValeursNumeriques(carte);
            Connections.UDPBoardConnection[carte].SendMessage(trame);

            if (attendre)
                _lockFrame[UdpFrameFunction.RetourValeursNumeriques].WaitOne(1000);
        }

        public override void SetActuatorOnOffValue(ActuatorOnOffID actionneur, bool on)
        {
            ActuatorOnOffState[actionneur] = on;
            Frame trame = UdpFrameFactory.ActionneurOnOff(actionneur, on);
            Connections.ConnectionIO.SendMessage(trame);

            Historique.AjouterAction(new ActionOnOff(this, actionneur, on));
        }

        public override void SetMotorAtPosition(MotorID moteur, int position, bool waitEnd)
        {
            base.SetMotorAtPosition(moteur, position);

            _lockMotor[moteur] = new Semaphore(0, int.MaxValue);

            Frame trame = UdpFrameFactory.MoteurPosition(moteur, position);
            Connections.ConnectionIO.SendMessage(trame);

            if (waitEnd)
                _lockMotor[moteur].WaitOne(5000);
        }

        public override void MotorWaitEnd(MotorID moteur)
        {
            base.MotorWaitEnd(moteur);

            _lockMotor[moteur].WaitOne(5000);
        }

        public override void SetMotorAtOrigin(MotorID moteur, bool waitEnd)
        {
            base.SetMotorAtOrigin(moteur);

            _lockMotor[moteur] = new Semaphore(0, int.MaxValue);

            Frame trame = UdpFrameFactory.MoteurOrigin(moteur);
            Connections.ConnectionIO.SendMessage(trame);

            if (waitEnd)
                _lockMotor[moteur].WaitOne(5000);
        }

        public override void SetMotorSpeed(MotorID moteur, SensGD sens, int vitesse)
        {
            base.SetMotorSpeed(moteur, sens, vitesse);

            if (moteur == MotorID.AvailableOnRecMove12 || moteur == MotorID.Gulp)
            {
                Frame trame = UdpFrameFactory.MoteurVitesse(Board.RecMove, moteur, sens, vitesse);
                Connections.ConnectionMove.SendMessage(trame);
            }
            else
            {
                Frame trame = UdpFrameFactory.MoteurVitesse(Board.RecIO, moteur, sens, vitesse);
                Connections.ConnectionIO.SendMessage(trame);
            }
        }

        public override void SetMotorAcceleration(MotorID moteur, int acceleration)
        {
            base.SetMotorAcceleration(moteur, acceleration);

            Frame trame = UdpFrameFactory.MoteurAcceleration(moteur, acceleration);
            Connections.ConnectionIO.SendMessage(trame);
        }

        public override void EnablePower(bool on)
        {
            // TODOEACHYEAR : couper tout manuellement
            Stop(StopMode.Freely);
        }

        public override void Reset()
        {
            ConnectionAsser.SendMessage(UdpFrameFactory.ResetRecMove());
            Thread.Sleep(1500);
        }

        public override bool ReadStartTrigger()
        {
            return ReadSensorOnOff(SensorOnOffID.Jack, true);
        }

        public override Color ReadMyColor()
        {
            _lockFrame[UdpFrameFunction.RetourCouleurEquipe] = new Semaphore(0, int.MaxValue);
            Connections.ConnectionGB.SendMessage(UdpFrameFactory.DemandeCouleurEquipe());
            _lockFrame[UdpFrameFunction.RetourCouleurEquipe].WaitOne(50);
            return _lastTeamColor;
        }

        public override List<int>[] DiagnosticPID(int consigne, SensAR sens, int ptsCount)
        {
            _lastPidTest = new List<int>[2];
            _lastPidTest[0] = new List<int>();
            _lastPidTest[1] = new List<int>();

            Frame frame = UdpFrameFactory.EnvoiConsigneBrute(consigne, sens, this);
            ConnectionAsser.SendMessage(frame);

            frame = UdpFrameFactory.DemandePositionsCodeurs(this);
            while (_lastPidTest[0].Count < ptsCount)
            {
                ConnectionAsser.SendMessage(frame);
                Thread.Sleep(30);
            }

            while (_lastPidTest[0].Count > ptsCount)
                _lastPidTest[0].RemoveAt(_lastPidTest[0].Count - 1);

            while (_lastPidTest[1].Count > ptsCount)
                _lastPidTest[1].RemoveAt(_lastPidTest[1].Count - 1);

            return _lastPidTest;
        }

        public override List<double>[] DiagnosticCpuPwm(int ptsCount)
        {
            _lastRecMoveLoad = new List<double>();
            _lastPwmLeft = new List<double>();
            _lastPwmRight = new List<double>();

            Frame frame = UdpFrameFactory.DemandeCpuPwm(this);
            while (_lastRecMoveLoad.Count <= ptsCount)
            {
                ConnectionAsser.SendMessage(frame);
                Thread.Sleep(30);
            }

            // Supprime d'éventuelles valeurs supplémentaires
            while (_lastRecMoveLoad.Count > ptsCount)
                _lastRecMoveLoad.RemoveAt(_lastRecMoveLoad.Count - 1);

            while (_lastPwmLeft.Count > ptsCount)
                _lastPwmLeft.RemoveAt(_lastPwmLeft.Count - 1);

            while (_lastPwmRight.Count > ptsCount)
                _lastPwmRight.RemoveAt(_lastPwmRight.Count - 1);
            
            return new List<double>[3]{ _lastRecMoveLoad, _lastPwmLeft, _lastPwmRight};
        }

        public void EnvoyerUart(Board byBoard, Frame frame)
        {
            Frame trameUart = UdpFrameFactory.EnvoyerUart1(byBoard, frame);
            Connections.UDPBoardConnection[byBoard].SendMessage(trameUart);
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
