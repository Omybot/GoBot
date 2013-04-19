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
using System.Drawing;
using System.Windows.Forms;

namespace GoBot
{
    class GrosRobot : Robot
    {
        public Semaphore semDeplacement;
        private Semaphore semPosition;

        public override int Taille { get { return 280; } }

        private const int TIME_REFRESH_POS = 200;
        private DateTime DateRefreshPos { get; set; }

        private System.Timers.Timer timerPosition;

        private Position position;
        public override Position Position
        {
            get
            {
                /*if ((DateTime.Now - DateRefreshPos).TotalMilliseconds > TIME_REFRESH_POS)
                {
                    DemandePosition();
                }*/
                return position;
            }
            protected set
            {
                position = value;
            }
        }

        public bool Evitement;

        public const String Nom = "Montoise";

        public Enchainements.Enchainement Enchainement { get; set; }
        public Color Couleur;

        public override void Init()
        {
            Evitement = true;
            Couleur = Color.Purple;

            Historique = new Historique();

            semDeplacement = new Semaphore(0, int.MaxValue);
            semPosition = new Semaphore(0, int.MaxValue);
            DateRefreshPos = DateTime.Now;

            Enchainement = new Enchainements.HomologationEnchainement();

            Connexions.ConnexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);
            Connexions.ConnexionIo.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

            Position = new Calculs.Position(new Angle(0, AnglyeType.Degre), new PointReel(200, 300));
            timerPosition = new System.Timers.Timer(200);
            timerPosition.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timerPosition.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DemandePosition();
        }

        public void Delete()
        {
            timerPosition.Stop();
        }

        public void DebutMatch()
        {
            Console.WriteLine("Goooooo");

            /*Enchainement = new Enchainements.Gerome4Enchainement();

            Enchainement.Couleur = Couleur;
            Enchainement.Executer();*/
        }

        public void ReceptionMessage(Trame trameRecue)
        {
            // Analyser la trame reçue
            if (trameRecue[0] == (byte)Carte.RecMove)
            {
                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.FinDeplacement
                    || trameRecue[1] == (byte)TrameFactory.FonctionMove.FinRecallage)
                {
                    semDeplacement.Release();
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.PositionXYTeta)
                {
                    // Réception de la position mesurée par l'asservissement
                    try
                    {
                        int y = (short)(trameRecue[2] << 8 | trameRecue[3]);
                        int x = (short)(trameRecue[4] << 8 | trameRecue[5]);
                        double teta = (trameRecue[6] << 8 | trameRecue[7]) / 100.0 - 180;
                        teta = (-teta);
                        y = -y;
                        x = -x;

                        Position = new Position(new Angle(teta, AnglyeType.Degre), new PointReel(x, y));
                        DateRefreshPos = DateTime.Now;
                        semPosition.Release();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Erreur dans le retour de position asservissement.");
                    }
                }
            }
            if (trameRecue[0] == (byte)Carte.RecIo)
            {
                if (trameRecue[1] == (byte)TrameFactory.FonctionIo.DepartJack)
                {
                    DebutMatch();
                }
            }
            if (trameRecue[0] == (byte)Carte.RecPi)
            {
                PetitRobot.ReceptionTrame(trameRecue);
            }
        }

        #region Déplacements

        public override void Avancer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.GRDeplacer(SensAR.Avant, distance);
            Connexions.ConnexionMove.SendMessage(trame);

            Historique.AjouterActionThread(new GRAvanceAction(distance));

            if (attendre)
                semDeplacement.WaitOne();
            DeplacementLigne = false;
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta)
        {
            Trame trame = TrameFactory.GROffsetPos(offsetX, offsetY, offsetTeta);
            Connexions.ConnexionMove.SendMessage(trame);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Historique.AjouterAction(new GRReculeAction(distance));

            Trame trame = TrameFactory.GRDeplacer(SensAR.Arriere, distance);
            Connexions.ConnexionMove.SendMessage(trame);
            if (attendre)
                semDeplacement.WaitOne();

            DeplacementLigne = false;
        }

        public override void PivotGauche(double angle, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new GRPivotGaucheAction(angle));
            Trame trame = TrameFactory.GRPivot(SensGD.Gauche, angle);

            Connexions.ConnexionMove.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();

        }

        public override void PivotDroite(double angle, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new GRPivotDroiteAction(angle));
            Trame trame = TrameFactory.GRPivot(SensGD.Droite, angle);
            Connexions.ConnexionMove.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            Trame trame = TrameFactory.GRStop(mode);

            Connexions.ConnexionMove.SendMessage(trame);
            
            Historique.AjouterActionThread(new GRStopAction(mode));
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            if(attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            if (sensAr == SensAR.Avant)
            {
                if (sensGd == SensGD.Droite)
                    Historique.AjouterActionThread(new GRVirageAvantDroiteAction(rayon, angle));
                else if (sensGd == SensGD.Gauche)
                    Historique.AjouterActionThread(new GRVirageAvantGaucheAction(rayon, angle));
            }
            else if (sensAr == SensAR.Arriere)
            {
                if (sensGd == SensGD.Droite)
                    Historique.AjouterActionThread(new GRVirageArriereDroiteAction(rayon, angle));
                else if (sensGd == SensGD.Gauche)
                    Historique.AjouterActionThread(new GRVirageArriereGaucheAction(rayon, angle));
            }

            Trame trame = TrameFactory.GRVirage(sensAr, sensGd, rayon, angle);
            Connexions.ConnexionMove.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public void GoToXY(int x, int y)
        {
            Trame trame = TrameFactory.GRGotoXY(x, y);
            Connexions.ConnexionMove.SendMessage(trame);
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.GRRecallage(sens);
            Connexions.ConnexionMove.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        #endregion
        
        public override void EnvoyerPID(int p, int i, int d)
        {
            Trame trame = TrameFactory.GRPID(p, i, d);
            Connexions.ConnexionMove.SendMessage(trame);
        }

        public override void CoupureAlim()
        {
            Trame t = TrameFactory.CoupureAlim();
            Connexions.ConnexionIo.SendMessage(t);
        }

        public void DemandePosition(bool attendre = true)
        {
            if(attendre)
                semPosition = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.GRDemandePosition();
            Connexions.ConnexionMove.SendMessage(t);

            if(attendre)
                semPosition.WaitOne();
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(servo, position);
            Connexions.ConnexionIo.SendMessage(trame);
            Historique.AjouterAction(new GRServoAction(position, servo));
        }

        #region Parametres deplacement

        private int vitesseDeplacement;
        public override int VitesseDeplacement
        {
            get
            {
                return vitesseDeplacement;
            }
            set
            {
                Trame trame = TrameFactory.GRVitesseLigne(value);
                Connexions.ConnexionMove.SendMessage(trame);
                vitesseDeplacement = value;
                Historique.AjouterAction(new GRVitesseLigneAction(value));
            }
        }

        private int accelDeplacement;
        public override int AccelerationDeplacement
        {
            get
            {
                return accelDeplacement;
            }
            set
            {
                Trame trame = TrameFactory.GRAccelLigne(value);
                Connexions.ConnexionMove.SendMessage(trame);
                accelDeplacement = value;
                Historique.AjouterAction(new GRAccelerationLigneAction(value));
            }
        }

        private int vitessePivot;
        public override int VitessePivot
        {
            get
            {
                return vitessePivot;
            }
            set
            {
                Trame trame = TrameFactory.GRVitessePivot(value);
                Connexions.ConnexionMove.SendMessage(trame);
                vitessePivot = value;
                Historique.AjouterAction(new GRVitessePivotAction(value));
            }
        }

        private int accelPivot;
        public override int AccelerationPivot
        {
            get
            {
                return accelPivot;
            }
            set
            {
                Trame trame = TrameFactory.GRAccelPivot(value);
                Connexions.ConnexionMove.SendMessage(trame);
                accelPivot = value;
                Historique.AjouterAction(new GRAccelerationPivotAction(value));
            }
        }

        #endregion


    }
}
