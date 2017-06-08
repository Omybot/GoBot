﻿using GoBot.Actions;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.Communications;
using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;

namespace GoBot
{
    class RobotReel : Robot
    {
        Dictionary<CapteurOnOffID, Semaphore> SemaphoresCapteurs = new Dictionary<CapteurOnOffID, Semaphore>();
        Dictionary<CapteurCouleurID, Semaphore> SemaphoresCouleur = new Dictionary<CapteurCouleurID, Semaphore>();
        Dictionary<FonctionTrame, Semaphore> SemaphoresTrame = new Dictionary<FonctionTrame, Semaphore>();

        private DateTime DateRefreshPos { get; set; }
        private bool positionRecue = false;
        public Connexion Connexion { get; set; }

        public override Position Position { get; set; }

        public RobotReel(IDRobot idRobot, Carte carte) : base()
        {
            AsserActif = true;
            Carte = carte;
            IDRobot = idRobot;

            CapteurActive = new Dictionary<CapteurOnOffID, bool>();
            ActionneurActive = new Dictionary<ActionneurOnOffID, bool>();
            CapteursCouleur = new Dictionary<CapteurCouleurID, Color>();

            foreach (FonctionTrame fonction in Enum.GetValues(typeof(FonctionTrame)))
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

            ValeursAnalogiques = new Dictionary<Carte, List<double>>();
            ValeursAnalogiques.Add(Carte.RecIO, null);
            ValeursAnalogiques.Add(Carte.RecGB, null);
            ValeursAnalogiques.Add(Carte.RecMove, null);

            SpeedConfig.ParamChange += SpeedConfig_ParamChange;
        }

        private void SpeedConfig_ParamChange(bool lineAccelChange, bool lineDecelChange, bool lineSpeedChange, bool pivotAccelChange, bool pivotDecelChange, bool pivotSpeedChange)
        {
            if (lineSpeedChange)
            {
                Trame trame = TrameFactory.VitesseLigne(SpeedConfig.LineSpeed, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionVitesseLigne(this, SpeedConfig.LineSpeed));
            }
            if (lineAccelChange || lineDecelChange)
            {
                Trame trame = TrameFactory.AccelLigne(SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionAccelerationLigne(this, SpeedConfig.LineAcceleration, SpeedConfig.LineDeceleration));
            }
            if (pivotSpeedChange)
            {
                Trame trame = TrameFactory.VitessePivot(SpeedConfig.PivotSpeed, this);
                Connexion.SendMessage(trame);
                Historique.AjouterAction(new ActionVitessePivot(this, SpeedConfig.PivotSpeed));
            }
            if (pivotAccelChange)// || pivotDecelChange)
            {
                // TODO2018 : décélération en pivot =/= accélération
                Trame trame = TrameFactory.AccelPivot(SpeedConfig.PivotAcceleration, this);
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
                if (Plateau.Enchainement == null)
                    Plateau.Enchainement = new GoBot.Enchainements.EnchainementMatch();
                Plateau.Enchainement.Executer();
            }
        }

        void RecGoBot_ColorChange(MatchColor state)
        {
            if (state == MatchColor.LeftBlue)
                couleurEquipe = Plateau.CouleurGaucheBleu;
            else if (state == MatchColor.RightYellow)
                couleurEquipe = Plateau.CouleurDroiteJaune;

            Plateau.NotreCouleur = couleurEquipe;

            SemaphoresTrame[FonctionTrame.RetourCouleurEquipe].Release();
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);

            DateRefreshPos = DateTime.Now;
            
            Connexion.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

            if (this == Robots.GrosRobot)
                Connexions.ConnexionIO.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

            Connexions.ConnexionGB.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

            if (this == Robots.GrosRobot)
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                    Position = new Calculs.Position(new Angle(0, AnglyeType.Degre), new PointReel(240, 1000));
                else
                    Position = new Calculs.Position(new Angle(180, AnglyeType.Degre), new PointReel(3000 - 240, 1000));
            }
            else
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                    Position = new Calculs.Position(new Angle(0, AnglyeType.Degre), new PointReel(480, 1000));
                else
                    Position = new Calculs.Position(new Angle(180, AnglyeType.Degre), new PointReel(3000 - 480, 1000));
            }

            PositionCible = null; //TODO2018 Init commun à la simu

            HistoriqueCoordonnees = new List<Position>();
            Connexion.SendMessage(TrameFactory.DemandePositionContinue(100, this));

            Devices.Devices.RecGoBot.ColorChange += RecGoBot_ColorChange;
            Devices.Devices.RecGoBot.JackChange += RecGoBot_JackChange;
        }

        public override Color DemandeCapteurCouleur(CapteurCouleurID capteur, bool attendre = true)
        {
            if (attendre)
                SemaphoresCouleur[capteur] = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandeCapteurCouleur(capteur);
            Connexions.ConnexionIO.SendMessage(t);

            if (attendre)
                SemaphoresCouleur[capteur].WaitOne(100);

            return CapteursCouleur[capteur];
        }

        public override bool DemandeCapteurOnOff(CapteurOnOffID capteur, bool attendre = true)
        {
            if (attendre)
                SemaphoresCapteurs[capteur] = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandeCapteurOnOff(capteur);
            Connexions.ConnexionGB.SendMessage(t);

            if (attendre)
                SemaphoresCapteurs[capteur].WaitOne(1000);
            Console.WriteLine("Retour " + CapteurActive[capteur].ToString());
            return CapteurActive[capteur];
        }

        public void Delete()
        {
            // TODO2018 utile ?
            //timerPosition.Stop();
        }

        Thread thActivationAsser;

        public void ReactivationAsserv()
        {
            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                Devices.Devices.RecGoBot.SetLed((LedID)i, RecGoBot.LedStatus.Rouge);

            Devices.Devices.RecGoBot.Buzz(7000, 200);

            Thread.Sleep(500);
            TrajectoireEchouee = true;
            Stop(StopMode.Abrupt);
            SemaphoresTrame[FonctionTrame.FinDeplacement].Release();

            Devices.Devices.RecGoBot.Buzz(0, 200);

            for (LedID i = LedID.DebugB1; i <= LedID.DebugA1; i++)
                Devices.Devices.RecGoBot.SetLed((LedID)i, RecGoBot.LedStatus.Off);
        }

        public void ReceptionMessage(Trame trameRecue)
        {
            // Analyser la trame reçue

            //Console.WriteLine(trameRecue.ToString());

            switch ((FonctionTrame)trameRecue[1])
            {
                case FonctionTrame.Blocage:
                    thActivationAsser = new Thread(ReactivationAsserv);
                    thActivationAsser.Start();
                    break;
                case FonctionTrame.FinDeplacement:
                case FonctionTrame.FinRecallage:        // Idem
                    Thread.Sleep(40); // TODO2018 ceci est une tempo ajoutée au pif de pwet parce qu'on avant envie alors voilà
                    Console.WriteLine("Déblocage déplacement " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond);
                    SemaphoresTrame[FonctionTrame.FinDeplacement].Release();
                    break;
                case FonctionTrame.AsserRetourPositionXYTeta:
                    // Réception de la position mesurée par l'asservissement
                    try
                    {
                        double y = (double)((short)(trameRecue[2] << 8 | trameRecue[3]) / 10.0);
                        double x = (double)((short)(trameRecue[4] << 8 | trameRecue[5]) / 10.0);
                        double teta = (trameRecue[6] << 8 | trameRecue[7]) / 100.0 - 180;
                        teta = (-teta);
                        y = -y;
                        x = -x;

                        Position nouvellePosition = new Position(new Angle(teta, AnglyeType.Degre), new PointReel(x, y));

                        if (Position.Coordonnees.Distance(nouvellePosition.Coordonnees) < 300 || !positionRecue)
                        {
                            Position = nouvellePosition;
                            //Position.Coordonnees.Placer(nouvellePosition.Coordonnees.X, nouvellePosition.Coordonnees.Y); //TODO2018 ca servait pas à réenvoyer la position au robot ça ?
                        }
                        //else
                        //    ReglerOffsetAsserv((int)Position.Coordonnees.X, (int)Position.Coordonnees.Y, -Position.Angle);

                        positionRecue = true;

                        DateRefreshPos = DateTime.Now;
                        SemaphoresTrame[FonctionTrame.AsserDemandePositionXYTeta].Release();

                        lock (HistoriqueCoordonnees)
                        {
                            HistoriqueCoordonnees.Add(new Position(teta, new PointReel(x, y)));

                            while (HistoriqueCoordonnees.Count > 1200)
                                HistoriqueCoordonnees.RemoveAt(0);
                        }

                        if (Plateau.Balise != null)
                            Plateau.Balise.Position = Position;

                        ChangerPosition(Position);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Erreur dans le retour de position asservissement.");
                    }
                    break;
                case FonctionTrame.AsserRetourPositionCodeurs:
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
                case FonctionTrame.RetourChargeCPU_PWM:
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
                case FonctionTrame.RetourCapteurCouleur:
                    //TODO2018 : multiplier par 2 pour obtenir de belles couleurs ?
                    Color couleur = Color.FromArgb(Math.Min(255, trameRecue[3]*1), Math.Min(255, trameRecue[4]*1), Math.Min(255, trameRecue[5] * 1));

                    ChangeCouleurCapteur((CapteurCouleurID)trameRecue[2], couleur);
                    CapteursCouleur[(CapteurCouleurID)trameRecue[2]] = couleur;
                    if (SemaphoresCouleur[(CapteurCouleurID)trameRecue[2]] != null)
                        SemaphoresCouleur[(CapteurCouleurID)trameRecue[2]].Release();
                    break;
                case FonctionTrame.ReponseLidar:
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

                        positionMesureLidar = new Position(teta, new PointReel(x, y));
                        decallageEntete += 6;
                    }

                    for (int i = decallageEntete; i < trameRecue.Length; i++)
                    {
                        mesureLidar += (char)trameRecue[i];
                        mess += (char)trameRecue[i];
                    }

                    if (Regex.Matches(mesureLidar, "\n\n").Count == 2)
                    {
                        SemaphoresTrame[FonctionTrame.ReponseLidar].Release();
                    }
                    break;
                case FonctionTrame.RetourCapteurOnOff:
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
                case FonctionTrame.TensionBatteries:
                    BatterieVoltage = (double)(trameRecue[2] * 256 + trameRecue[3]) / 100.0;
                    break;
                case FonctionTrame.RetourValeursAnalogiques:
                    Carte carte = (Carte)trameRecue[0];

                    double valeurAnalogique1 = (trameRecue[2] * 256 + trameRecue[3]);
                    double valeurAnalogique2 = (trameRecue[4] * 256 + trameRecue[5]);
                    double valeurAnalogique3 = (trameRecue[6] * 256 + trameRecue[7]);
                    double valeurAnalogique4 = (trameRecue[8] * 256 + trameRecue[9]);
                    double valeurAnalogique5 = (trameRecue[10] * 256 + trameRecue[11]);
                    double valeurAnalogique6 = (trameRecue[12] * 256 + trameRecue[13]);
                    double valeurAnalogique7 = (trameRecue[14] * 256 + trameRecue[15]);
                    double valeurAnalogique8 = (trameRecue[16] * 256 + trameRecue[17]);
                    double valeurAnalogique9 = (trameRecue[18] * 256 + trameRecue[19]);

                    double valeurAnalogique1V = valeurAnalogique1 * 0.0008056640625;
                    double valeurAnalogique2V = valeurAnalogique2 * 0.0008056640625;
                    double valeurAnalogique3V = valeurAnalogique3 * 0.0008056640625;
                    double valeurAnalogique4V = valeurAnalogique4 * 0.0008056640625;
                    double valeurAnalogique5V = valeurAnalogique5 * 0.0008056640625;
                    double valeurAnalogique6V = valeurAnalogique6 * 0.0008056640625;
                    double valeurAnalogique7V = valeurAnalogique7 * 0.0008056640625;
                    double valeurAnalogique8V = valeurAnalogique8 * 0.0008056640625;
                    double valeurAnalogique9V = valeurAnalogique9 * 0.0008056640625;

                    List<double> values = new List<double>();
                    values.Add(valeurAnalogique1V);
                    values.Add(valeurAnalogique2V);
                    values.Add(valeurAnalogique3V);
                    values.Add(valeurAnalogique4V);
                    values.Add(valeurAnalogique5V);
                    values.Add(valeurAnalogique6V);
                    values.Add(valeurAnalogique7V);
                    values.Add(valeurAnalogique8V);
                    values.Add(valeurAnalogique9V);
                    ValeursAnalogiques[carte] = values;

                    if (SemaphoresTrame[FonctionTrame.RetourValeursAnalogiques] != null)
                        SemaphoresTrame[FonctionTrame.RetourValeursAnalogiques].Release();
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
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Avant, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionAvance(this, distance));

            int tempsParcours = SpeedConfig.LineDuration(distance);

            if (attendre)
                if (!SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne(tempsParcours + 1000))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique

            DeplacementLigne = false;
        }

        public override void ReglerOffsetAsserv(Position newPosition)
        {
            Position.Copie(newPosition);
            Trame trame = TrameFactory.OffsetPos(newPosition, this);
            Connexion.SendMessage(trame);
            ChangerPosition(Position);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            base.Reculer(distance, attendre);

            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Arriere, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionRecule(this, distance));

            int tempsParcours = SpeedConfig.LineDuration(distance);

            if (attendre)
                if (!SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne(tempsParcours + 1000))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique

            DeplacementLigne = false;
        }

        public override void PivotGauche(Angle angle, bool attendre = true)
        {
            base.PivotGauche(angle, attendre);

            angle = Math.Round(angle, 2);

            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.Pivot(SensGD.Gauche, angle, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));

            int tempsParcours = SpeedConfig.PivotDuration(angle, Entraxe);

            if (attendre)
                if (!SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne(tempsParcours + 1000))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
            DeplacementLigne = false;
        }

        public override void PivotDroite(Angle angle, bool attendre = true)
        {
            base.PivotDroite(angle, attendre);

            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.Pivot(SensGD.Droite, angle, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));

            int tempsParcours = SpeedConfig.PivotDuration(angle, Entraxe);

            if (attendre)
                if (!SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne(tempsParcours + 1000))
                    Thread.Sleep(1000); // Tempo de secours, on a jamais reçu la fin de trajectoire après la fin du délai théorique
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            AsserActif = (mode != StopMode.Freely);

            Trame trame = TrameFactory.Stop(mode, this);
            DeplacementLigne = false;

            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionStop(this, mode));
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, Angle angle, bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd));

            Trame trame = TrameFactory.Virage(sensAr, sensGd, rayon, angle, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne();
        }

        public override void TrajectoirePolaire(SensAR sens, List<PointReel> points, bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            //Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd)); TODO

            Trame trame = TrameFactory.TrajectoirePolaire(sens, points, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne();
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionRecallage(this, sens));
            Trame trame = TrameFactory.Recallage(sens, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FonctionTrame.FinDeplacement].WaitOne();
        }

        #endregion

        public override void EnvoyerPID(int p, int i, int d)
        {
            Trame trame = TrameFactory.CoeffAsserv(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public override void EnvoyerPIDCap(int p, int i, int d)
        {
            Trame trame = TrameFactory.CoeffAsservCap(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public override void EnvoyerPIDVitesse(int p, int i, int d)
        {
            Trame trame = TrameFactory.CoeffAsservVitesse(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public bool DemandePosition(bool attendre = true)
        {
            if (!Connexion.ConnexionCheck.Connecte)
                return false;

            if (attendre)
                SemaphoresTrame[FonctionTrame.AsserRetourPositionCodeurs] = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandePosition(this);
            Connexion.SendMessage(t);

            if (attendre)
                return SemaphoresTrame[FonctionTrame.AsserRetourPositionXYTeta].WaitOne(1000);// semPosition.WaitOne(1000);
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
                Trame trame = TrameFactory.ServoEnvoiPositionCible(servo, position);
                Connexions.ConnexionIO.SendMessage(trame);
            }
        }

        public override void DemandeValeursAnalogiques(Carte carte, bool attendre = true)
        {
            if (!Connexions.ConnexionParCarte[carte].ConnexionCheck.Connecte)
                return;

            if (attendre)
                SemaphoresTrame[FonctionTrame.RetourValeursAnalogiques] = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.DemandeValeursAnalogiques(carte);
            Connexions.ConnexionParCarte[carte].SendMessage(trame);

            if (attendre)
                SemaphoresTrame[FonctionTrame.RetourValeursAnalogiques].WaitOne(1000);
        }

        public override void ServoVitesse(ServomoteurID servo, int vitesse)
        {
            Trame trame = TrameFactory.ServoEnvoiVitesseMax(servo, vitesse);
            Connexions.ConnexionIO.SendMessage(trame);
        }

        public override void ActionneurOnOff(ActionneurOnOffID actionneur, bool on)
        {
            ActionneurActive[actionneur] = on;
            Trame trame = TrameFactory.ActionneurOnOff(actionneur, on);
            Connexions.ConnexionIO.SendMessage(trame);

            Historique.AjouterAction(new ActionOnOff(this, actionneur, on));
        }

        public override void MoteurPosition(MoteurID moteur, int position)
        {
            base.MoteurPosition(moteur, position);

            Trame trame = TrameFactory.MoteurPosition(moteur, position);
            Connexion.SendMessage(trame);
        }

        public override void MoteurVitesse(MoteurID moteur, SensGD sens, int vitesse)
        {
            base.MoteurVitesse(moteur, sens, vitesse);

            Trame trame = TrameFactory.MoteurVitesse(moteur, sens, vitesse);
            Connexions.ConnexionIO.SendMessage(trame);
        }

        public override void MoteurAcceleration(MoteurID moteur, int acceleration)
        {
            base.MoteurAcceleration(moteur, acceleration);

            Trame trame = TrameFactory.MoteurAcceleration(moteur, acceleration);
            Connexions.ConnexionIO.SendMessage(trame);
        }

        public override void AlimentationPuissance(bool on)
        {
            // TODO : couper tout manuellement
            Stop(StopMode.Freely);
        }

        public override void Reset()
        {
            Connexion.SendMessage(TrameFactory.ResetRecMove());
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
            SemaphoresTrame[FonctionTrame.ReponseLidar] = new Semaphore(0, int.MaxValue);
            Connexions.ConnexionMove.SendMessage(TrameFactory.DemandeMesureLidar(lidar));
            SemaphoresTrame[FonctionTrame.ReponseLidar].WaitOne(timeout);
            refPosition = positionMesureLidar;
            return mesureLidar;
        }

        private Color couleurEquipe;
        private bool historiqueCouleurEquipe;
        public override Color GetCouleurEquipe(bool historique = true)
        {
            historiqueCouleurEquipe = historique;
            SemaphoresTrame[FonctionTrame.RetourCouleurEquipe] = new Semaphore(0, int.MaxValue);
            Connexions.ConnexionIO.SendMessage(TrameFactory.DemandeCouleurEquipe());
            SemaphoresTrame[FonctionTrame.RetourCouleurEquipe].WaitOne(50);
            return couleurEquipe;
        }

        List<int>[] retourTestPid;
        public override List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs)
        {
            retourTestPid = new List<int>[2];
            retourTestPid[0] = new List<int>();
            retourTestPid[1] = new List<int>();

            Trame trame = TrameFactory.EnvoiConsigneBrute(consigne, sens, this);
            Connexion.SendMessage(trame);

            trame = TrameFactory.DemandePositionsCodeurs(this);
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

            Trame trame = TrameFactory.DemandeCpuPwm(this);
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

        public void EnvoyerUart(Carte carte, Trame trame)
        {
            Trame trameUart = TrameFactory.EnvoyerUart(carte, trame);
            Connexions.ConnexionParCarte[carte].SendMessage(trameUart);
        }
    }
}