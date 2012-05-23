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
    static class GrosRobot
    {
        static public ConnexionUDP connexionIo = null;
        static public ConnexionUDP connexionMove = null;
        static private Semaphore mutexDeplacement;
        static private Semaphore mutexPosition;

        private const int TIME_REFRESH_POS = 200;
        static private DateTime DateRefreshPos { get; set; }
        static private Position position;
        public static Position Position
        {
            get
            {
                if ((DateTime.Now - DateRefreshPos).TotalMilliseconds > TIME_REFRESH_POS)
                {
                    DemandePosition();
                }
                return position;
            }
            set
            {
                position = value;
            }
        }

        public static int OffsetXAsserv { get; set; }
        public static int OffsetYAsserv { get; set; }

        public static bool Evitement;

        static Historique historique;
        public static Historique Historique { get { return historique; } }

        public const String Nom = "Montoise";

        static public Enchainements.Enchainement Enchainement { get; set; }
        static public Color Couleur;

        static public int distanceRestante = 0;

        static public void Init()
        {
            Evitement = true;
            Couleur = Color.Purple;

            OffsetXAsserv = 150;
            OffsetYAsserv = 150 + 129;

            connexionMove = new ConnexionUDP();
            connexionMove.Connexion(System.Net.IPAddress.Parse("10.1.0.11"), 12311, 12321);
            connexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);
            connexionMove.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMoveCheck_TestConnexion);

            connexionIo = new ConnexionUDP();
            connexionIo.Connexion(System.Net.IPAddress.Parse("10.1.0.12"), 12312, 12322);
            connexionIo.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);
            connexionIo.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionIoCheck_TestConnexion);

            historique = new Historique();

            mutexDeplacement = new Semaphore(0, int.MaxValue);
            mutexPosition = new Semaphore(0, int.MaxValue);
            DateRefreshPos = DateTime.Now;

            Enchainement = new Enchainements.HomologationEnchainement();
        }
        


        public static void CoupureAlim()
        {
            Trame t = TrameFactory.CoupureAlim();
            connexionIo.SendMessage(t);
        }

        static void ConnexionMoveCheck_TestConnexion()
        {
            connexionMove.SendMessage(TrameFactory.TestConnexion(Carte.RecMove));
        }

        static void ConnexionIoCheck_TestConnexion()
        {
            connexionIo.SendMessage(TrameFactory.TestConnexion(Carte.RecIo));
        }

        public static void DebutMatch()
        {
            Console.WriteLine("Goooooo");

            Enchainement = new Enchainements.Gerome4Enchainement();

            Enchainement.Couleur = Couleur;
            Enchainement.Executer();
        }

        static public void ReceptionTrame(Trame trameRecue)
        {
            // Analyser la trame reçue
            if (trameRecue[0] == (byte)Carte.RecMove)
            {
                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.FinDeplacement
                    || trameRecue[1] == (byte)TrameFactory.FonctionMove.FinRecallage)
                {
                    if (distanceRestante == 0)
                    {
                        try
                        {
                            mutexDeplacement.Release();
                        }
                        catch (Exception) { }
                    }
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.DistanceRestante)
                {
                    distanceRestante = trameRecue[2] * 256 + trameRecue[3];
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
                    DateRefreshPos = DateTime.Now;
                    mutexPosition.Release();

                    if (PositionActualisee != null)
                        PositionActualisee(Position);
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

        //Déclaration du délégué pour l’évènement de position des ennemis
        public delegate void PositionActuDelegate(Position position);
        //Déclaration de l’évènement utilisant le délégué
        public static event PositionActuDelegate PositionActualisee;

        static public void Avancer(int distance, bool attendre = true)
        {
            if (attendre)
                mutexDeplacement = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.GRDeplacer(SensAR.Avant, distance);
            connexionMove.SendMessage(trame);

            historique.AjouterActionThread(new GRAvanceAction(distance));

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta)
        {
            Trame trame = TrameFactory.GROffsetPos(offsetX, offsetY, offsetTeta);
            connexionMove.SendMessage(trame);
        }

        static public void AttraperDroite()
        {
            FermeBrasMilieuDroite();
            FermeBrasHautDroite();
            Thread.Sleep(500);
            OuvreBrasMilieuDroite();
            Thread.Sleep(100);
            OuvreBrasHautDroite();
        }

        static public void AttraperGauche()
        {
            FermeBrasMilieuGauche();
            FermeBrasHautGauche();
            Thread.Sleep(500);
            OuvreBrasMilieuGauche();
            Thread.Sleep(100);
            OuvreBrasHautGauche();
        }

        static public void Reculer(int distance, bool attendre = true)
        {
            if (attendre)
                mutexDeplacement = new Semaphore(0, int.MaxValue);

            historique.AjouterAction(new GRReculeAction(distance));

            Trame trame = TrameFactory.GRDeplacer(SensAR.Arriere, distance);
            connexionMove.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void PivotGauche(int angle, bool attendre = true)
        {
            if (attendre)
                mutexDeplacement = new Semaphore(0, int.MaxValue);

            historique.AjouterAction(new GRPivotGaucheAction(angle));
            Trame trame = TrameFactory.GRPivot(SensGD.Gauche, angle);

            connexionMove.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();

        }

        static public void PivotDroite(int angle, bool attendre = true)
        {
            if (attendre)
                mutexDeplacement = new Semaphore(0, int.MaxValue);

            historique.AjouterAction(new GRPivotDroiteAction(angle));
            Trame trame = TrameFactory.GRPivot(SensGD.Droite, angle);
            connexionMove.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void Stop(StopMode mode = StopMode.Smooth)
        {
            Trame trame = TrameFactory.GRStop(mode);

            connexionMove.SendMessage(trame);

            historique.AjouterActionThread(new GRStopAction(mode));
        }

        static public void CoefficientsAsserv(int p, int i, int d)
        {
            Trame trame = TrameFactory.GRCoeffAsserv(p, i, d);
            connexionMove.SendMessage(trame);
        }

        static public void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            if(attendre)
                mutexDeplacement = new Semaphore(0, int.MaxValue);

            if (sensAr == SensAR.Avant)
            {
                if (sensGd == SensGD.Droite)
                    historique.AjouterActionThread(new GRVirageAvantDroiteAction(rayon, angle));
                else if (sensGd == SensGD.Gauche)
                    historique.AjouterActionThread(new GRVirageAvantGaucheAction(rayon, angle));
            }
            else if (sensAr == SensAR.Arriere)
            {
                if (sensGd == SensGD.Droite)
                    historique.AjouterActionThread(new GRVirageArriereDroiteAction(rayon, angle));
                else if (sensGd == SensGD.Gauche)
                    historique.AjouterActionThread(new GRVirageArriereGaucheAction(rayon, angle));
            }

            Trame trame = TrameFactory.GRVirage(sensAr, sensGd, rayon, angle);
            connexionMove.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();

        }

        static public void GoToXY(int x, int y)
        {
            Trame trame = TrameFactory.GRGotoXY(x, y);
            connexionMove.SendMessage(trame);
        }

        static public void StopAlimentation()
        {
            Trame trame = TrameFactory.GRStopAlim();
            connexionMove.SendMessage(trame);
        }

        static public void DemandePosition(bool attendre = true)
        {
            if(attendre)
                mutexPosition = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.GRDemandePosition();
            connexionMove.SendMessage(t);

            if(attendre)
                mutexPosition.WaitOne();
        }

        static public void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                mutexDeplacement = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.GRRecallage(sens);
            connexionMove.SendMessage(trame);

            if (attendre)
                mutexDeplacement.WaitOne();
        }

        static public void BougeBras(ServomoteurID servo, int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(servo, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, servo));
        }

        static public void BougeBrasHautGauche(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBrasHautGauche, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBrasHautGauche));
        }

        static public void OuvreBrasHautGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasHautGauche(Config.CurrentConfig.PosPinceGaucheHautOuvert);
            else
                BougeBrasHautDroite(Config.CurrentConfig.PosPinceDroiteHautOuvert);
        }

        static public void DroitBrasBasGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasBasGauche(Config.CurrentConfig.PosPinceGaucheBasMilieu);
            else
                BougeBrasBasDroite(Config.CurrentConfig.PosPinceDroiteBasMilieu);
        }

        static public void DroitBrasBasDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasBasDroite(Config.CurrentConfig.PosPinceDroiteBasMilieu);
            else
                BougeBrasBasGauche(Config.CurrentConfig.PosPinceGaucheBasMilieu);
        }

        static public void FermeBrasHautGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasHautGauche(Config.CurrentConfig.PosPinceGaucheHautFerme);
            else
                BougeBrasHautDroite(Config.CurrentConfig.PosPinceDroiteHautFerme);
        }

        static public void BougeBrasMilieuGauche(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBrasMilieuGauche, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBrasMilieuGauche));
        }

        static public void OuvreBrasMilieuGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasMilieuGauche(Config.CurrentConfig.PosPinceGaucheMilieuOuvert);
            else
                BougeBrasMilieuDroite(Config.CurrentConfig.PosPinceDroiteMilieuOuvert);
        }

        static public void FermeBrasMilieuGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasMilieuGauche(Config.CurrentConfig.PosPinceGaucheMilieuFerme);
            else
                BougeBrasMilieuDroite(Config.CurrentConfig.PosPinceDroiteMilieuFerme);
        }

        static public void BougeBrasBasGauche(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBrasBasGauche, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBrasBasGauche));
        }

        static public void OuvreBrasBasGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasBasGauche(Config.CurrentConfig.PosPinceGaucheBasOuvert);
            else
                BougeBrasBasDroite(Config.CurrentConfig.PosPinceDroiteBasOuvert);
        }

        static public void FermeBrasBasGauche()
        {
            if (Couleur == Color.Purple)
                BougeBrasBasGauche(Config.CurrentConfig.PosPinceGaucheBasFerme);
            else
                BougeBrasBasDroite(Config.CurrentConfig.PosPinceDroiteBasFerme);
        }

        static public void BougeBrasHautDroite(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBrasHautDroite, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBrasHautDroite));
        }

        static public void OuvreBrasHautDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasHautDroite(Config.CurrentConfig.PosPinceDroiteHautOuvert);
            else
                BougeBrasHautGauche(Config.CurrentConfig.PosPinceGaucheHautOuvert);
        }

        static public void FermeBrasHautDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasHautDroite(Config.CurrentConfig.PosPinceDroiteHautFerme);
            else
                BougeBrasHautGauche(Config.CurrentConfig.PosPinceGaucheHautFerme);
        }

        static public void BougeBrasMilieuDroite(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBrasMilieuDroite, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBrasMilieuDroite));
        }

        static public void OuvreBrasMilieuDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasMilieuDroite(Config.CurrentConfig.PosPinceDroiteMilieuOuvert);
            else
                BougeBrasMilieuGauche(Config.CurrentConfig.PosPinceGaucheMilieuOuvert);
        }

        static public void FermeBrasMilieuDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasMilieuDroite(Config.CurrentConfig.PosPinceDroiteMilieuFerme);
            else
                BougeBrasMilieuGauche(Config.CurrentConfig.PosPinceGaucheMilieuFerme);
        }

        static public void BougeBrasBasDroite(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBrasBasDroite, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBrasBasDroite));
        }

        static public void OuvreBrasBasDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasBasDroite(Config.CurrentConfig.PosPinceDroiteBasOuvert);
            else
                BougeBrasBasGauche(Config.CurrentConfig.PosPinceGaucheBasOuvert);
        }

        static public void FermeBrasBasDroite()
        {
            if (Couleur == Color.Purple)
                BougeBrasBasDroite(Config.CurrentConfig.PosPinceDroiteBasFerme);
            else
                BougeBrasBasGauche(Config.CurrentConfig.PosPinceGaucheBasFerme);
        }

        static public void BougeBenne(int position)
        {
            Trame trame = TrameFactory.GRBougeServomoteur(ServomoteurID.GRBenne, position);
            connexionIo.SendMessage(trame);
            GrosRobot.Historique.AjouterAction(new GRServoAction(position, ServomoteurID.GRBenne));
        }

        static public void OuvrirBenne()
        {
            BougeBenne(Config.CurrentConfig.PosBenneOuvert);
        }

        static public void FermeBenne()
        {
            BougeBenne(Config.CurrentConfig.PosBenneFerme);
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
                Trame trame = TrameFactory.GRVitesseLigne(value);
                connexionMove.SendMessage(trame);
                vitesseDeplacement = value;
                historique.AjouterAction(new GRVitesseLigneAction(value));
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
                Trame trame = TrameFactory.GRAccelLigne(value);
                connexionMove.SendMessage(trame);
                accelDeplacement = value;
                historique.AjouterAction(new GRAccelerationLigneAction(value));
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
                Trame trame = TrameFactory.GRVitessePivot(value);
                connexionMove.SendMessage(trame);
                vitessePivot = value;
                historique.AjouterAction(new GRVitessePivotAction(value));
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
                Trame trame = TrameFactory.GRAccelPivot(value);
                connexionMove.SendMessage(trame);
                accelPivot = value;
                historique.AjouterAction(new GRAccelerationPivotAction(value));
            }
        }

        public static void EnvoyerPID(int p, int i, int d)
        {
            Trame trame = TrameFactory.GRPID(p, i, d);
            connexionMove.SendMessage(trame);
        }
    }
}
