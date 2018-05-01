using GoBot.Actions;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using GoBot.Communications;
using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using GoBot.Threading;
using GoBot.GameElements;

namespace GoBot
{
    class RobotReel : Robot
    {
        Dictionary<CapteurOnOffID, Semaphore> SemaphoresCapteurs = new Dictionary<CapteurOnOffID, Semaphore>();
        Dictionary<CapteurCouleurID, Semaphore> SemaphoresCouleur = new Dictionary<CapteurCouleurID, Semaphore>();
        Dictionary<FrameFunction, Semaphore> SemaphoresTrame = new Dictionary<FrameFunction, Semaphore>();

        private DateTime DateRefreshPos { get; set; }
        private bool positionRecue = false;
        public Connection Connexion { get; set; }

        public override Position Position { get; set; }

        public RobotReel(IDRobot idRobot, Board carte) : base()
        {
            AsserActif = true;
            Carte = carte;
            IDRobot = idRobot;

            CapteurActive = new Dictionary<CapteurOnOffID, bool>();
            ActionneurActive = new Dictionary<ActionneurOnOffID, bool>();
            CapteursCouleur = new Dictionary<CapteurCouleurID, Color>();

            foreach (FrameFunction fonction in Enum.GetValues(typeof(FrameFunction)))
                SemaphoresTrame.Add(fonction, new Semaphore(0, int.MaxValue));

            foreach (CapteurOnOffID fonction in Enum.GetValues(typeof(CapteurOnOffID)))
            {
                SemaphoresCapteurs.Add(fonction, new Semaphore(0, int.MaxValue));
                CapteurActive.Add(fonction, false);
            }

            foreach (ActionneurOnOffID fonction in Enum.GetValues(typeof(ActionneurOnOffID)))
            {
                ActionneurActive.Add(fonction, false);
            }

            foreach (CapteurCouleurID fonction in Enum.GetValues(typeof(CapteurCouleurID)))
            {
                SemaphoresCouleur.Add(fonction, new Semaphore(0, int.MaxValue));
                CapteursCouleur.Add(fonction, Color.Black);
            }

            ValeursAnalogiques = new Dictionary<Board, List<double>>();
            ValeursAnalogiques.Add(Board.RecIO, new List<double>());
            ValeursAnalogiques.Add(Board.RecGB, new List<double>());
            ValeursAnalogiques.Add(Board.RecMove, new List<double>());

            for (int i = 0; i < 9; i++)
            {
                ValeursAnalogiques[Board.RecIO].Add(0);
                ValeursAnalogiques[Board.RecGB].Add(0);
                ValeursAnalogiques[Board.RecMove].Add(0);
            }

            ValeursNumeriques = new Dictionary<Board, List<Byte>>();
            ValeursNumeriques.Add(Board.RecIO, new List<byte>());
            ValeursNumeriques.Add(Board.RecGB, new List<byte>());
            ValeursNumeriques.Add(Board.RecMove, new List<byte>());

            for (int i = 0; i < 3 * 2; i++)
            {
                ValeursNumeriques[Board.RecIO].Add(0);
                ValeursNumeriques[Board.RecGB].Add(0);
                ValeursNumeriques[Board.RecMove].Add(0);
            }

            SpeedConfig.ParamChange += SpeedConfig_ParamChange;
        }

        public override void Delete()
        {
            
        }

        private void SpeedConfig_ParamChange(bool lineAccelChange, bool lineDecelChange, bool lineSpeedChange, bool pivotAccelChange, bool pivotDecelChange, bool pivotSpeedChange)
        {
            if (lineSpeedChange)
            {
                Frame trame = FrameFactory.VitesseLigne(SpeedConfig.LineSpeed, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionVitesseLigne(this, SpeedConfig.LineSpeed));
            }
            if (lineAccelChange || lineDecelChange)
            {
                Frame trame = FrameFactory.AccelLigne(SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionAccelerationLigne(this, SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration));
            }
            if (pivotSpeedChange)
            {
                Frame trame = FrameFactory.VitessePivot(SpeedConfig.PivotSpeed, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionVitessePivot(this, SpeedConfig.PivotSpeed));
            }
            if (pivotAccelChange)// || pivotDecelChange)
            {
                // TODO2018 : décélération en pivot =/= accélération
                Frame trame = FrameFactory.AccelPivot(SpeedConfig.PivotAcceleration, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionAccelerationPivot(this, SpeedConfig.PivotAcceleration, SpeedConfig.PivotDeceleration));
            }
        }

        void RecGoBot_JackChange(bool state)
        {
            Devices.Devices.RecGoBot.SetLed(LedID.DebugB1, state ? RecGoBot.LedStatus.Vert : RecGoBot.LedStatus.Rouge);

            if (!state && JackArme)
            {
                JackArme = false;
                if (Plateau.Strategy == null)
                    Plateau.Strategy = new GoBot.Strategies.StrategyMatch();
                Plateau.Strategy.ExecuteMatch();
            }
        }

        void RecGoBot_ColorChange(MatchColor state)
        {
            if (state == MatchColor.LeftBlue)
                couleurEquipe = Plateau.CouleurGaucheVert;
            else if (state == MatchColor.RightYellow)
                couleurEquipe = Plateau.CouleurDroiteOrange;

            Plateau.NotreCouleur = couleurEquipe;

            SemaphoresTrame[FrameFunction.RetourCouleurEquipe]?.Release();
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);

            DateRefreshPos = DateTime.Now;
            
            Connexion.FrameReceived += new UDPConnection.NewFrameDelegate(ReceptionMessage);

            if (this == Robots.GrosRobot)
                Connections.ConnectionIO.FrameReceived += new UDPConnection.NewFrameDelegate(ReceptionMessage);

            Connections.ConnectionGB.FrameReceived += new UDPConnection.NewFrameDelegate(ReceptionMessage);

            if (this == Robots.GrosRobot)
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                    Position = new Position(new Angle(0, AnglyeType.Degre), new RealPoint(240, 1000));
                else
                    Position = new Position(new Angle(180, AnglyeType.Degre), new RealPoint(3000 - 240, 1000));
            }
            else
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                    Position = new Position(new Angle(0, AnglyeType.Degre), new RealPoint(480, 1000));
                else
                    Position = new Position(new Angle(180, AnglyeType.Degre), new RealPoint(3000 - 480, 1000));
            }

            PositionCible = null; //TODO2018 Init commun à la simu

            HistoriqueCoordonnees = new List<Position>();
            Connexion.SendMessage(FrameFactory.DemandePositionContinue(100, this));

            Devices.Devices.RecGoBot.ColorChange += RecGoBot_ColorChange;
            Devices.Devices.RecGoBot.JackChange += RecGoBot_JackChange;
        }

        public override Color DemandeCapteurCouleur(CapteurCouleurID capteur, bool attendre = true)
        {
            if (attendre)
                SemaphoresCouleur[capteur] = new Semaphore(0, int.MaxValue);

            Frame t = FrameFactory.DemandeCapteurCouleur(capteur);
            Connections.ConnectionIO.SendMessage(t);

            if (attendre)
                SemaphoresCouleur[capteur].WaitOne(100);

            return CapteursCouleur[capteur];
        }

        public override CubesPattern DemandeCapteurPattern(bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FrameFunction.DemandeCapteurPattern] = new Semaphore(0, int.MaxValue);

            Frame t = FrameFactory.DemandeCapteurPattern();
            Connections.ConnectionMove.SendMessage(t);

            if (attendre)
                SemaphoresTrame[FrameFunction.DemandeCapteurPattern].WaitOne(100);

            return Actionneurs.Actionneur.PatternReader.Pattern;
        }

        public override bool DemandeCapteurOnOff(CapteurOnOffID capteur, bool attendre = true)
        {
            if (attendre)
                SemaphoresCapteurs[capteur] = new Semaphore(0, int.MaxValue);

            Frame t = FrameFactory.DemandeCapteurOnOff(capteur);
            Connections.ConnectionGB.SendMessage(t);

            if (attendre)
                SemaphoresCapteurs[capteur].WaitOne(1000);
            Console.WriteLine("Retour " + CapteurActive[capteur].ToString());
            return CapteurActive[capteur];
        }

        public void ReactivationAsserv(ThreadLink link)
        {
            link.RegisterName();

            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                Devices.Devices.RecGoBot.SetLed((LedID)i, RecGoBot.LedStatus.Rouge);

            Devices.Devices.RecGoBot.Buzz(7000, 200);

            Thread.Sleep(500);
            TrajectoireEchouee = true;
            Stop(StopMode.Abrupt);
            SemaphoresTrame[FrameFunction.FinDeplacement]?.Release();

            Devices.Devices.RecGoBot.Buzz(0, 200);

            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                Devices.Devices.RecGoBot.SetLed((LedID)i, RecGoBot.LedStatus.Off);
        }

        public void ReceptionMessage(Frame trameRecue)
        {
            // Analyser la trame reçue

            //Console.WriteLine(trameRecue.ToString());

            switch ((FrameFunction)trameRecue[1])
            {
                case FrameFunction.Blocage:
                    ThreadManager.StartThread(link => ReactivationAsserv(link));
                    break;
                case FrameFunction.FinDeplacement:
                case FrameFunction.FinRecallage:        // Idem
                    Thread.Sleep(40); // TODO2018 ceci est une tempo ajoutée au pif de pwet parce qu'on avant envie alors voilà
                    Console.WriteLine("Déblocage déplacement " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond);
                    SemaphoresTrame[FrameFunction.FinDeplacement]?.Release();
                    break;
                case FrameFunction.AsserRetourPositionXYTeta:
                    // Réception de la position mesurée par l'asservissement
                    try
                    {
                        double y = (double)((short)(trameRecue[2] << 8 | trameRecue[3]) / 10.0);
                        double x = (double)((short)(trameRecue[4] << 8 | trameRecue[5]) / 10.0);
                        double teta = (trameRecue[6] << 8 | trameRecue[7]) / 100.0 - 180;
                        teta = (-teta);
                        y = -y;
                        x = -x;

                        Position nouvellePosition = new Position(new Angle(teta, AnglyeType.Degre), new RealPoint(x, y));

                        if (Position.Coordinates.Distance(nouvellePosition.Coordinates) < 300 || !positionRecue)
                        {
                            Position = nouvellePosition;
                            //Position.Coordonnees.Placer(nouvellePosition.Coordonnees.X, nouvellePosition.Coordonnees.Y); //TODO2018 ca servait pas à réenvoyer la position au robot ça ?
                        }
                        //else
                        //    ReglerOffsetAsserv((int)Position.Coordonnees.X, (int)Position.Coordonnees.Y, -Position.Angle);

                        positionRecue = true;

                        DateRefreshPos = DateTime.Now;
                        SemaphoresTrame[FrameFunction.AsserDemandePositionXYTeta]?.Release();

                        lock (HistoriqueCoordonnees)
                        {
                            HistoriqueCoordonnees.Add(new Position(teta, new RealPoint(x, y)));

                            while (HistoriqueCoordonnees.Count > 1200)
                                HistoriqueCoordonnees.RemoveAt(0);
                        }

                        if (Plateau.Balise != null)
                            Plateau.Balise.Position = Position;

                        OnPositionChange(Position);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Erreur dans le retour de position asservissement.");
                    }
                    break;
                case FrameFunction.AsserRetourPositionCodeurs:
                    int nbPositions = trameRecue[2];

                    for (int i = 0; i < nbPositions; i++)
                    {
                        // TODO2018 peut mieux faire, décaller les bits
                        int gauche1 = trameRecue[3 + i * 8];
                        int gauche2 = trameRecue[4 + i * 8];
                        int gauche3 = trameRecue[5 + i * 8];
                        int gauche4 = trameRecue[6 + i * 8];

                        int codeurGauche = gauche1 * 256 * 256 * 256 + gauche2 * 256 * 256 + gauche3 * 256 + gauche4;

                        int droite1 = trameRecue[7 + i * 8];
                        int droite2 = trameRecue[8 + i * 8];
                        int droite3 = trameRecue[9 + i * 8];
                        int droite4 = trameRecue[10 + i * 8];

                        int codeurDroit = droite1 * 256 * 256 * 256 + droite2 * 256 * 256 + droite3 * 256 + droite4;

                        retourTestPid[0].Add(codeurGauche);
                        retourTestPid[1].Add(codeurDroit);
                    }
                    break;
                case FrameFunction.RetourChargeCPU_PWM:
                    int nbValeurs = trameRecue[2];

                    for (int i = 0; i < nbValeurs; i++)
                    {
                        double chargeCPU = (trameRecue[3 + i * 6] * 256 + trameRecue[4 + i * 6]) / 5000.0;
                        double chargePWMGauche = trameRecue[5 + i * 6] * 256 + trameRecue[6 + i * 6] - 4000;
                        double chargePWMDroite = trameRecue[7 + i * 6] * 256 + trameRecue[8 + i * 6] - 4000;


                        retourTestCharge[0].Add(chargeCPU);
                        retourTestCharge[1].Add(chargePWMGauche);
                        retourTestCharge[2].Add(chargePWMDroite);
                    }
                    break;
                case FrameFunction.RetourCapteurCouleur:
                    //TODO2018 : multiplier par 2 pour obtenir de belles couleurs ?
                    Color couleur = Color.FromArgb(Math.Min(255, trameRecue[3]*1), Math.Min(255, trameRecue[4]*1), Math.Min(255, trameRecue[5] * 1));

                    ChangeCouleurCapteur((CapteurCouleurID)trameRecue[2], couleur);
                    CapteursCouleur[(CapteurCouleurID)trameRecue[2]] = couleur;

                    SemaphoresCouleur[(CapteurCouleurID)trameRecue[2]]?.Release();
                    break;
                case FrameFunction.RetourCapteurPattern:
                    
                    Actionneurs.Actionneur.PatternReader.SetPeriod(trameRecue[2] * 256 + trameRecue[3]);

                    SemaphoresTrame[FrameFunction.DemandeCapteurPattern]?.Release();
                    break;
                case FrameFunction.ReponseLidar:
                    int lidarID = trameRecue[2];

                    if (mesureLidar == null)
                        mesureLidar = "";

                    String mess = "";
                    int decallageEntete = 3;

                    if (mesureLidar.Length == 0)
                    {
                        // C'est le début de la trame à recomposer, et au début y'a la position de la prise de mesure à lire !

                        double y = (double)((short)(trameRecue[3] << 8 | trameRecue[4]) / 10.0);
                        double x = (double)((short)(trameRecue[5] << 8 | trameRecue[6]) / 10.0);
                        double teta = (trameRecue[7] << 8 | trameRecue[8]) / 100.0 - 180;

                        positionMesureLidar = new Position(teta, new RealPoint(x, y));
                        decallageEntete += 6;
                    }

                    for (int i = decallageEntete; i < trameRecue.Length; i++)
                    {
                        mesureLidar += (char)trameRecue[i];
                        mess += (char)trameRecue[i];
                    }

                    if (Regex.Matches(mesureLidar, "\n\n").Count == 2)
                    {
                        SemaphoresTrame[FrameFunction.ReponseLidar]?.Release();
                    }
                    break;
                case FrameFunction.RetourCapteurOnOff:
                    CapteurOnOffID capteur = (CapteurOnOffID)trameRecue[2];


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
                        
                        bool nouvelEtat = trameRecue[3] > 0 ? true : false;

                        if (nouvelEtat != CapteurActive[capteur])
                            ChangerEtatCapteurOnOff(capteur, nouvelEtat);
                        
                        SemaphoresCapteurs[capteur]?.Release();
                    }
                    break;
                case FrameFunction.TensionBatteries:
                    BatterieVoltage = (double)(trameRecue[2] * 256 + trameRecue[3]) / 100.0;
                    break;
                case FrameFunction.RetourValeursNumeriques:
                    Board numericBoard = (Board)trameRecue[0];

                    lock (ValeursNumeriques)
                    {
                        ValeursNumeriques[numericBoard][0] = (Byte)trameRecue[2];
                        ValeursNumeriques[numericBoard][1] = (Byte)trameRecue[3];
                        ValeursNumeriques[numericBoard][2] = (Byte)trameRecue[4];
                        ValeursNumeriques[numericBoard][3] = (Byte)trameRecue[5];
                        ValeursNumeriques[numericBoard][4] = (Byte)trameRecue[6];
                        ValeursNumeriques[numericBoard][5] = (Byte)trameRecue[7];
                    }
                    
                    SemaphoresTrame[FrameFunction.RetourValeursNumeriques]?.Release();
                    break;

                case FrameFunction.RetourValeursAnalogiques:
                    Board analogBoard = (Board)trameRecue[0];
                    
                    const double toVolts = 0.0008056640625;

                    List<double> values = new List<double>();
                    ValeursAnalogiques[analogBoard][0] = ((trameRecue[2] * 256 + trameRecue[3]) * toVolts);
                    ValeursAnalogiques[analogBoard][1] = ((trameRecue[4] * 256 + trameRecue[5]) * toVolts);
                    ValeursAnalogiques[analogBoard][2] = ((trameRecue[6] * 256 + trameRecue[7]) * toVolts);
                    ValeursAnalogiques[analogBoard][3] = ((trameRecue[8] * 256 + trameRecue[9]) * toVolts);
                    ValeursAnalogiques[analogBoard][4] = ((trameRecue[10] * 256 + trameRecue[11]) * toVolts);
                    ValeursAnalogiques[analogBoard][5] = ((trameRecue[12] * 256 + trameRecue[13]) * toVolts);
                    ValeursAnalogiques[analogBoard][6] = ((trameRecue[14] * 256 + trameRecue[15]) * toVolts);
                    ValeursAnalogiques[analogBoard][7] = ((trameRecue[16] * 256 + trameRecue[17]) * toVolts);
                    ValeursAnalogiques[analogBoard][8] = ((trameRecue[18] * 256 + trameRecue[19]) * toVolts);
                    
                    SemaphoresTrame[FrameFunction.RetourValeursAnalogiques]?.Release();
                    break;
            }
        }

        #region Déplacements

        public override void Avancer(int distance, bool attendre = true)
        {
            //TODO2018 : FOnction de déplacement communes avec Simu sur l'historique etc, à voir, le recallage de Simu se fait en avancant...
            //TODO2018 : En finir avec Avancer Reculer PivotGauche PivotDroite et se contenter de Move & Turn avec des négatifs qui font le job
            base.Avancer(distance, attendre);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Frame trame = FrameFactory.Deplacer(SensAR.Avant, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionAvance(this, distance));
            
            if (attendre)
                if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.LineDuration(distance).TotalMilliseconds))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique

            DeplacementLigne = false;
        }

        public override void ReglerOffsetAsserv(Position newPosition)
        {
            Position.Copy(newPosition);
            Frame trame = FrameFactory.OffsetPos(newPosition, this);
            Connexion.SendMessage(trame);
            OnPositionChange(Position);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            base.Reculer(distance, attendre);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Frame trame = FrameFactory.Deplacer(SensAR.Arriere, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionRecule(this, distance));
            
            if (attendre)
                if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.LineDuration(distance).TotalMilliseconds))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique

            DeplacementLigne = false;
        }

        public override void PivotGauche(Angle angle, bool attendre = true)
        {
            base.PivotGauche(angle, attendre);

            angle = Math.Round(angle, 2);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame trame = FrameFactory.Pivot(SensGD.Gauche, angle, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));
            
            if (attendre)
                if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.PivotDuration(angle, Entraxe).TotalMilliseconds))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
            DeplacementLigne = false;
        }

        public override void PivotDroite(Angle angle, bool attendre = true)
        {
            base.PivotDroite(angle, attendre);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Frame trame = FrameFactory.Pivot(SensGD.Droite, angle, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));
            
            if (attendre)
                if (!SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne((int)SpeedConfig.PivotDuration(angle, Entraxe).TotalMilliseconds))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            AsserActif = (mode != StopMode.Freely);

            Frame trame = FrameFactory.Stop(mode, this);
            DeplacementLigne = false;

            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionStop(this, mode));
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, Angle angle, bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd));

            Frame trame = FrameFactory.Virage(sensAr, sensGd, rayon, angle, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne();
        }

        public override void TrajectoirePolaire(SensAR sens, List<RealPoint> points, bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            //Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd)); TODO

            Frame trame = FrameFactory.TrajectoirePolaire(sens, points, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne();
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionRecallage(this, sens));
            Frame trame = FrameFactory.Recallage(sens, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FrameFunction.FinDeplacement].WaitOne();
        }

        #endregion

        public override void EnvoyerPID(int p, int i, int d)
        {
            Frame trame = FrameFactory.CoeffAsserv(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public override void EnvoyerPIDCap(int p, int i, int d)
        {
            Frame trame = FrameFactory.CoeffAsservCap(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public override void EnvoyerPIDVitesse(int p, int i, int d)
        {
            Frame trame = FrameFactory.CoeffAsservVitesse(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public bool DemandePosition(bool attendre = true)
        {
            if (!Connexion.ConnectionChecker.Connected)
                return false;

            if (attendre)
                SemaphoresTrame[FrameFunction.AsserRetourPositionCodeurs] = new Semaphore(0, int.MaxValue);

            Frame t = FrameFactory.DemandePosition(this);
            Connexion.SendMessage(t);

            if (attendre)
                return SemaphoresTrame[FrameFunction.AsserRetourPositionXYTeta].WaitOne(1000);// semPosition.WaitOne(1000);
            else
                return true;
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            base.BougeServo(servo, position);

            // Envoi à la pololu si c'est un servo géré par la carte
            int idPololu = Servomoteur.idServoPololu(servo);
            if (idPololu != -1)
                PololuMiniUart.setTarget((byte)idPololu, (ushort)position);
            // Sinon en UDP aux cartes elecs
            else
            {
                Frame trame = FrameFactory.ServoEnvoiPositionCible(servo, position);
                Connections.ConnectionIO.SendMessage(trame);
            }
        }

        public override void DemandeValeursAnalogiques(Board carte, bool attendre = true)
        {
            if (!Connections.BoardConnection[carte].ConnectionChecker.Connected)
                return;

            if (attendre)
                SemaphoresTrame[FrameFunction.RetourValeursAnalogiques] = new Semaphore(0, int.MaxValue);

            Frame trame = FrameFactory.DemandeValeursAnalogiques(carte);
            Connections.BoardConnection[carte].SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FrameFunction.RetourValeursAnalogiques].WaitOne(1000);
        }

        public override void DemandeValeursNumeriques(Board carte, bool attendre = true)
        {
            if (!Connections.BoardConnection[carte].ConnectionChecker.Connected)
                return;

            if (attendre)
                SemaphoresTrame[FrameFunction.RetourValeursNumeriques] = new Semaphore(0, int.MaxValue);

            Frame trame = FrameFactory.DemandeValeursNumeriques(carte);
            Connections.BoardConnection[carte].SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FrameFunction.RetourValeursNumeriques].WaitOne(1000);
        }

        public override void ServoVitesse(ServomoteurID servo, int vitesse)
        {
            Frame trame = FrameFactory.ServoEnvoiVitesseMax(servo, vitesse);
            Connections.ConnectionIO.SendMessage(trame);
        }

        public override void ActionneurOnOff(ActionneurOnOffID actionneur, bool on)
        {
            ActionneurActive[actionneur] = on;
            Frame trame = FrameFactory.ActionneurOnOff(actionneur, on);
            Connections.ConnectionIO.SendMessage(trame);

            Historique.AjouterAction(new ActionOnOff(this, actionneur, on));
        }

        public override void MoteurPosition(MoteurID moteur, int position)
        {
            base.MoteurPosition(moteur, position);

            Frame trame = FrameFactory.MoteurPosition(moteur, position);
            Connexion.SendMessage(trame);
        }

        public override void MoteurVitesse(MoteurID moteur, SensGD sens, int vitesse)
        {
            base.MoteurVitesse(moteur, sens, vitesse);

            Frame trame = FrameFactory.MoteurVitesse(moteur, sens, vitesse);
            Connections.ConnectionIO.SendMessage(trame);
        }

        public override void MoteurAcceleration(MoteurID moteur, int acceleration)
        {
            base.MoteurAcceleration(moteur, acceleration);

            Frame trame = FrameFactory.MoteurAcceleration(moteur, acceleration);
            Connections.ConnectionIO.SendMessage(trame);
        }

        public override void AlimentationPuissance(bool on)
        {
            // TODO : couper tout manuellement
            Stop(StopMode.Freely);
        }

        public override void Reset()
        {
            Connexion.SendMessage(FrameFactory.ResetRecMove());
            Thread.Sleep(1500);
        }

        public override bool GetJack()
        {
            return DemandeCapteurOnOff(CapteurOnOffID.Jack, true);
        }

        private String mesureLidar;
        private Position positionMesureLidar;

        public override String GetMesureLidar(LidarID lidar, int timeout, out Position refPosition)
        {
            mesureLidar = "";
            SemaphoresTrame[FrameFunction.ReponseLidar] = new Semaphore(0, int.MaxValue);
            Connections.ConnectionMove.SendMessage(FrameFactory.DemandeMesureLidar(lidar));
            SemaphoresTrame[FrameFunction.ReponseLidar].WaitOne(timeout);
            refPosition = positionMesureLidar;
            return mesureLidar;
        }

        private Color couleurEquipe;
        private bool historiqueCouleurEquipe;
        public override Color GetCouleurEquipe(bool historique = true)
        {
            historiqueCouleurEquipe = historique;
            SemaphoresTrame[FrameFunction.RetourCouleurEquipe] = new Semaphore(0, int.MaxValue);
            Connections.ConnectionIO.SendMessage(FrameFactory.DemandeCouleurEquipe());
            SemaphoresTrame[FrameFunction.RetourCouleurEquipe].WaitOne(50);
            return couleurEquipe;
        }

        List<int>[] retourTestPid;
        public override List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs)
        {
            retourTestPid = new List<int>[2];
            retourTestPid[0] = new List<int>();
            retourTestPid[1] = new List<int>();

            Frame trame = FrameFactory.EnvoiConsigneBrute(consigne, sens, this);
            Connexion.SendMessage(trame);

            trame = FrameFactory.DemandePositionsCodeurs(this);
            while (retourTestPid[0].Count < nbValeurs)
            {
                Connexion.SendMessage(trame);
                Thread.Sleep(30);
            }

            while (retourTestPid[0].Count > nbValeurs)
                retourTestPid[0].RemoveAt(retourTestPid[0].Count - 1);

            while (retourTestPid[1].Count > nbValeurs)
                retourTestPid[1].RemoveAt(retourTestPid[1].Count - 1);

            return retourTestPid;
        }

        List<double>[] retourTestCharge;
        public override List<double>[] DiagnosticCpuPwm(int nbValeurs)
        {
            retourTestCharge = new List<double>[3];
            retourTestCharge[0] = new List<double>();
            retourTestCharge[1] = new List<double>();
            retourTestCharge[2] = new List<double>();

            Frame trame = FrameFactory.DemandeCpuPwm(this);
            while (retourTestCharge[0].Count <= nbValeurs)
            {
                Connexion.SendMessage(trame);
                Thread.Sleep(30);
            }

            // Supprime d'éventuelles valeurs supplémentaires
            while (retourTestCharge[0].Count > nbValeurs)
                retourTestCharge[0].RemoveAt(retourTestCharge[0].Count - 1);

            while (retourTestCharge[1].Count > nbValeurs)
                retourTestCharge[1].RemoveAt(retourTestCharge[1].Count - 1);

            while (retourTestCharge[2].Count > nbValeurs)
                retourTestCharge[2].RemoveAt(retourTestCharge[2].Count - 1);


            return retourTestCharge;
        }

        public void EnvoyerUart(Board carte, Frame trame)
        {
            Frame trameUart = FrameFactory.EnvoyerUart(carte, trame);
            Connections.BoardConnection[carte].SendMessage(trameUart);
        }
    }
}
