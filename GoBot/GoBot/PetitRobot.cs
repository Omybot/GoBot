using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDP;
using System.Timers;
using GoBot.Actions;
using GoBot.UDP;
using System.Threading;
using GoBot.Calculs;
using GoBot.Calculs.Formes;

namespace GoBot
{
    static class PetitRobot
    {
        static Historique historique;
        public static Historique Historique { get { return historique; } }
        public static ConnexionCheck ConnexionCheck;
        static public Semaphore mutexDeplacement;
        public static System.Timers.Timer timerDemandePos;
        public static Position Position { get; set; }
        public static bool Evitement;

        public static int OffsetXAsserv { get; set; }
        public static int OffsetYAsserv { get; set; }

        static public bool avanceEnCours;
        static public bool reculeEnCours;

        static public int distanceRestante = 0;

        // variable poubelle
        public static int reculade = 0;
        public static int distanceRecule = 100;

        public const String Nom = "Irish";

        static public void Init()
        {
            OffsetXAsserv = 0;
            OffsetYAsserv = 0;
            historique = new Historique();
            ConnexionCheck = new ConnexionCheck(2000);
            ConnexionCheck.TestConnexion += TestConnexion;

            mutexDeplacement = new Semaphore(0, 1);

            timerDemandePos = new System.Timers.Timer();
            timerDemandePos.Elapsed += new ElapsedEventHandler(timerDemandeDeplacement_Elapsed);
            timerDemandePos.Interval = 100;
            timerDemandePos.Start();
            Evitement = true;
        }

        static void timerDemandeDeplacement_Elapsed(object sender, ElapsedEventArgs e)
        {
            Trame t = TrameFactory.PRDemandePosition();
            GrosRobot.connexionIo.SendMessage(t);
        }

        static public void ReceptionTrame(Trame trameRecue)
        {
            ConnexionCheck.MajConnexion();
            // Analyser la trame reçue
            // Analyser la trame reçue

            try
            {
                if (trameRecue[0] == (byte)Carte.RecPi)
                {
                    if (trameRecue[1] == (byte)TrameFactory.FonctionMove.FinDeplacement
                        || trameRecue[1] == (byte)TrameFactory.FonctionMove.FinRecallage)
                    {
                        try
                        {
                            mutexDeplacement.Release();
                        }
                        catch (Exception) { }
                    }

                    if (trameRecue[1] == (byte)TrameFactory.FonctionMove.DistanceRestante)
                    {
                        int distanceRestante = trameRecue[2] * 256 + trameRecue[3];
                    }

                    if (trameRecue[1] == (byte)TrameFactory.FonctionMove.PositionXYTeta)
                    {
                        short y = (short)(trameRecue[2] << 8 | trameRecue[3]);// 65536 - (trameRecue[2] * 256 + trameRecue[3]);
                        short x = (short)(trameRecue[4] << 8 | trameRecue[5]);// 65536 - (trameRecue[4] * 256 + trameRecue[5]);
                        short teta = (short)(trameRecue[6] << 8 | trameRecue[7]);
                        teta = (short)(-teta);

                        x = (short)(-x + OffsetXAsserv);
                        y = (short)(-y + OffsetYAsserv);

                        Position = new Position(new Angle(teta, AnglyeType.Degre), new PointReel(x, y));

                        if (PositionActualisee != null)
                        {
                            PositionActualisee(Position);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Trame erronée : " + trameRecue.ToString());
            }
        }

        public static void InterpreteurBalise_PositionEnnemisActualisee(InterpreteurBalise interprete)
        {
            if (Evitement)
            {
                List<PointReel> points = new List<PointReel>();

                double sinAngle = Math.Sin(Position.Angle.AngleRadians);
                double cosAngle = Math.Cos(Position.Angle.AngleRadians);

                PointReel pCentre = new PointReel(Position.Coordonnees.X + cosAngle * 350, Position.Coordonnees.Y + sinAngle * 350);
                Cercle cercleDetection = new Cercle(pCentre, 400);
                foreach (PointReel p in interprete.PositionsEnnemies)
                {
                    if (cercleDetection.contient(p))
                    {
                        if (avanceEnCours)
                        {
                            //mutexDeplacement.Release();
                            Console.WriteLine("STOP");
                            Stop(StopMode.Smooth);
                            avanceEnCours = false;
                        }
                        else if (!reculeEnCours)
                        {
                            PetitRobot.VitesseDeplacement = 300;
                            PetitRobot.AccelerationDeplacement = 300;
                            PetitRobot.Reculer(distanceRecule, false);
                            reculade += distanceRecule;
                            Console.WriteLine("Je recule");
                        }
                    }
                    else if (distanceRestante != 0)
                    {
                        PetitRobot.VitesseDeplacement = 600;
                        PetitRobot.AccelerationDeplacement = 2200;
                        int distance = distanceRestante + reculade;
                        distanceRestante = 0;
                        reculade = 0;

                        PetitRobot.Avancer(distance, false);
                    }
                }
            }
        }

        //Déclaration du délégué pour l’évènement de position des ennemis
        public delegate void PositionActuDelegate(Position position);
        //Déclaration de l’évènement utilisant le délégué
        public static event PositionActuDelegate PositionActualisee;

        static public void TestConnexion()
        {
            Trame trame = TrameFactory.TestConnexionMiwi(Carte.RecPi);
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void Avancer(int distance, bool attendre = true)
        {
            historique.AjouterAction(new PRAvanceAction(distance));

            Trame trame = TrameFactory.PRDeplacer(SensAR.Avant, distance);
            GrosRobot.connexionIo.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void Reculer(int distance, bool attendre = true)
        {
            historique.AjouterAction(new PRReculeAction(distance));

            Trame trame = TrameFactory.PRDeplacer(SensAR.Arriere, distance);
            GrosRobot.connexionIo.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void PivotGauche(int angle, bool attendre = true)
        {
            historique.AjouterAction(new PRPivotGaucheAction(angle));

            Trame trame = TrameFactory.PRPivot(SensGD.Gauche, angle);
            GrosRobot.connexionIo.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void PivotDroite(int angle, bool attendre = true)
        {
            historique.AjouterAction(new PRPivotDroiteAction(angle));

            Trame trame = TrameFactory.PRPivot(SensGD.Droite, angle);
            GrosRobot.connexionIo.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void Stop(StopMode mode = StopMode.Smooth)
        {
            historique.AjouterAction(new PRStopAction(mode));

            Trame trame = TrameFactory.PRStop(mode);
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void CoefficientsAsserv(int p, int i, int d)
        {
            Trame trame = TrameFactory.PRCoeffAsserv(p, i, d);
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle)
        {
            if (sensAr == SensAR.Avant)
            {
                if (sensGd == SensGD.Droite)
                    historique.AjouterAction(new PRVirageAvantDroiteAction(rayon, angle));
                else if (sensGd == SensGD.Gauche)
                    historique.AjouterAction(new PRVirageAvantGaucheAction(rayon, angle));
            }
            else if (sensAr == SensAR.Arriere)
            {
                if (sensGd == SensGD.Droite)
                    historique.AjouterAction(new PRVirageArriereDroiteAction(rayon, angle));
                else if (sensGd == SensGD.Gauche)
                    historique.AjouterAction(new PRVirageArriereGaucheAction(rayon, angle));
            }

            Trame trame = TrameFactory.PRVirage(sensAr, sensGd, rayon, angle);
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void GoToXY(int x, int y)
        {
            Trame trame = TrameFactory.PRGotoXY(x, y);
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void StopAlimentation()
        {
            Trame trame = TrameFactory.GRStopAlim();
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void DemandePosition()
        {
            Trame trame = TrameFactory.PRDemandePosition();
            GrosRobot.connexionIo.SendMessage(trame);
        }

        static public void Recallage(SensAR sens, bool attendre = true)
        {
            Trame trame = TrameFactory.PRRecallage(sens);
            GrosRobot.connexionIo.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void BougeBras(ServomoteurID servo, int position)
        {
            Trame trame = TrameFactory.PRBougeServomoteur(servo, position);
            GrosRobot.connexionIo.SendMessage(trame);
            Historique.AjouterAction(new PRServoAction(position, servo));
        }

        static public void BougeBrasDroite(int position)
        {
            Trame trame = TrameFactory.PRBougeServomoteur(ServomoteurID.PRBrasDroite, position);
            GrosRobot.connexionIo.SendMessage(trame);
            Historique.AjouterAction(new PRServoAction(position, ServomoteurID.PRBrasDroite));
        }

        static public void BougeBrasGauche(int position)
        {
            Trame trame = TrameFactory.PRBougeServomoteur(ServomoteurID.PRBrasGauche, position);
            GrosRobot.connexionIo.SendMessage(trame);
            Historique.AjouterAction(new PRServoAction(position, ServomoteurID.PRBrasGauche));
        }

        static public void ActiverPompe(PompeID pompe, bool actif)
        {
            Trame trame = TrameFactory.PRPompe(pompe, actif);
            GrosRobot.connexionIo.SendMessage(trame);
            Historique.AjouterAction(new PRPompeAction(actif, pompe));
        }

        static public void ActiverPompeDroite(bool actif)
        {
            ActiverPompe(PompeID.PRPompeDroite, actif);
        }

        static public void ActiverPompeGauche(bool actif)
        {
            ActiverPompe(PompeID.PRPompeGauche, actif);
        }

        static private int vitesseDeplacement;
        static public int VitesseDeplacement
        {
            get
            {
                return vitesseDeplacement;
            }
            set
            {
                Trame trame = TrameFactory.PRVitesseLigne(value);
                GrosRobot.connexionIo.SendMessage(trame);
                vitesseDeplacement = value;
                historique.AjouterAction(new PRVitesseLigneAction(value));
            }
        }

        static private int accelDeplacement;
        static public int AccelerationDeplacement
        {
            get
            {
                return accelDeplacement;
            }
            set
            {
                Trame trame = TrameFactory.PRAccelLigne(value);
                GrosRobot.connexionIo.SendMessage(trame);
                accelDeplacement = value;
                historique.AjouterAction(new PRAccelerationLigneAction(value));
            }
        }

        static private int vitessePivot;
        static public int VitessePivot
        {
            get
            {
                return vitessePivot;
            }
            set
            {
                Trame trame = TrameFactory.PRVitessePivot(value);
                GrosRobot.connexionIo.SendMessage(trame);
                vitessePivot = value;
                historique.AjouterAction(new PRVitessePivotAction(value));
            }
        }

        static private int accelPivot;
        static public int AccelerationPivot
        {
            get
            {
                return accelPivot;
            }
            set
            {
                Trame trame = TrameFactory.PRAccelPivot(value);
                GrosRobot.connexionIo.SendMessage(trame);
                accelPivot = value;
                historique.AjouterAction(new PRAccelerationPivotAction(value));
            }
        }

        #region Petits enchainements

        public static void AttraperGauche(int tempsMs = 600)
        {
            ActiverPompeGauche(true);
            BougeBrasGauche(Config.CurrentConfig.PosBrasGaucheDeplie);
            Thread.Sleep(tempsMs);
            BougeBrasGauche(Config.CurrentConfig.PosBrasGaucheReplie);
        }

        public static void RelacherGauche(int tempsMs = 600)
        {
            ActiverPompeGauche(false);
            BougeBrasGauche(Config.CurrentConfig.PosBrasGaucheDeplie);
            Thread.Sleep(400);
            BougeBrasGauche(Config.CurrentConfig.PosBrasGaucheRange);
            Thread.Sleep(200);
            BougeBrasGauche(Config.CurrentConfig.PosBrasGaucheDeplie);
            Thread.Sleep(200);
            BougeBrasGauche(Config.CurrentConfig.PosBrasGaucheRange);
        }

        public static void AttraperDroite(int tempsMs = 600)
        {
            ActiverPompeDroite(true);
            BougeBrasDroite(Config.CurrentConfig.PosBrasDroiteDeplie);
            Thread.Sleep(tempsMs);
            BougeBrasDroite(Config.CurrentConfig.PosBrasDroiteReplie);
        }

        public static void RelacherDroite(int tempsMs = 600)
        {
            ActiverPompeDroite(false);
            BougeBrasDroite(Config.CurrentConfig.PosBrasDroiteDeplie);
            Thread.Sleep(400);
            BougeBrasDroite(Config.CurrentConfig.PosBrasDroiteRange);
            Thread.Sleep(200);
            BougeBrasDroite(Config.CurrentConfig.PosBrasDroiteDeplie);
            Thread.Sleep(200);
            BougeBrasDroite(Config.CurrentConfig.PosBrasDroiteRange);
        }

        #endregion

        internal static void EnvoyerPID(int p, int i, int d)
        {
            Trame t = TrameFactory.PRCoeffAsserv(p, i, d);
            GrosRobot.connexionIo.SendMessage(t);
        }
    }
}
