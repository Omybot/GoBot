using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using GoBot.Actions;
using System.Threading;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Drawing;
using System.Windows.Forms;
using GoBot.Communications;

namespace GoBot
{
    class RobotReel : Robot
    {
        public Semaphore semDeplacement;
        private Semaphore semPosition;

        private const int TIME_REFRESH_POS = 200;
        private DateTime DateRefreshPos { get; set; }

        private System.Timers.Timer timerPosition;

        public ConnexionUDP Connexion { get; set; }

        public override Position Position { get; set; }

        public bool Evitement;

        public Enchainements.Enchainement Enchainement { get; set; }
        public Color Couleur;

        public RobotReel(IDRobot idRobot, Carte carte)
        {
            Carte = carte;
            IDRobot = idRobot;
            ServomoteursConnectes = new List<byte>();
        }

        public override void Init()
        {
            Evitement = true;
            Couleur = Color.Purple;

            Historique = new Historique(IDRobot);

            semDeplacement = new Semaphore(0, int.MaxValue);
            semPosition = new Semaphore(0, int.MaxValue);
            DateRefreshPos = DateTime.Now;

            //Enchainement = new Enchainements.HomologationEnchainement();

            Connexion.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

            Position = new Calculs.Position(new Angle(0, AnglyeType.Degre), new PointReel(200, 300));
            PositionCible = Position.Coordonnees;

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
                if (trameRecue[1] == (byte)FonctionMove.FinDeplacement
                    || trameRecue[1] == (byte)FonctionMove.FinRecallage)
                {
                    semDeplacement.Release();
                }

                if (trameRecue[1] == (byte)FonctionMove.RetourPositionXYTeta)
                {
                    // Réception de la position mesurée par l'asservissement
                    try
                    {
                        double y = (double)((short)(trameRecue[2] << 8 | trameRecue[3]) / 10.0);
                        double x = (double)((short)(trameRecue[4] << 8 | trameRecue[5]) / 10.0);
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

                if (trameRecue[1] == (byte)FonctionMove.RetourPositionCodeurs)
                {
                    int nbPositions = trameRecue[2];

                    for (int i = 0; i < nbPositions; i++)
                    {
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

                        //Console.WriteLine("Retour " + codeurGauche + " positions codeurs");

                        retourTestPid[0].Add(codeurGauche);
                        retourTestPid[1].Add(codeurDroit);
                    }
                }

                if (trameRecue[1] == (byte)FonctionMove.RetourDiagnostic)
                {
                    int nbValeurs = trameRecue[2];

                    for (int i = 0; i < nbValeurs; i++)
                    {
                        double chargeCPU = (trameRecue[3 + i * 6] * 256 + trameRecue[4 + i * 6]) / 5000.0;
                        double chargePWMDroite = trameRecue[5 + i * 6] * 256 + trameRecue[6 + i * 6] - 4000;
                        double chargePWMGauche = trameRecue[7 + i * 6] * 256 + trameRecue[8 + i * 6] - 4000;


                        retourTestCharge[0].Add(chargeCPU);
                        retourTestCharge[1].Add(chargePWMDroite);
                        retourTestCharge[2].Add(chargePWMGauche);
                    }
                }
            }
            else if (trameRecue[0] == (byte)Carte.RecIO)
            {
                if (trameRecue[1] == (byte)FonctionIO.ReponseJack)
                {
                    jackBranche = trameRecue[2] == 1 ? true : false;
                    if (historiqueJack)
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRJack, jackBranche ? "branché" : "absent"));
                    if (semJack != null)
                        semJack.Release();
                }

                if (trameRecue[1] == (byte)FonctionIO.DepartJack)
                {
                    Plateau.Enchainement = new GoBot.Enchainements.EnchainementMatch();
                    Plateau.Enchainement.Executer();
                }

                if (trameRecue[1] == (byte)FonctionIO.ReponseCouleurEquipe)
                {
                    if (trameRecue[2] == 0)
                        Plateau.NotreCouleur = Plateau.CouleurJ1Rouge;
                    else if (trameRecue[2] == 1)
                        Plateau.NotreCouleur = Plateau.CouleurJ2Jaune;

                    //Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRCouleurBalle, "));
                }
            }
        }

        #region Déplacements

        public override void Avancer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Avant, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionAvance(this, distance));

            if (attendre)
                semDeplacement.WaitOne();
            DeplacementLigne = false;
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta)
        {
            Trame trame = TrameFactory.OffsetPos(offsetX, offsetY, offsetTeta, this);
            Connexion.SendMessage(trame);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Historique.AjouterAction(new ActionRecule(this, distance));

            Trame trame = TrameFactory.Deplacer(SensAR.Arriere, distance, this);
            Connexion.SendMessage(trame);
            if (attendre)
                semDeplacement.WaitOne();

            DeplacementLigne = false;
        }

        public override void PivotGauche(double angle, bool attendre = true)
        {
            angle = Math.Round(angle, 2);
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));
            Trame trame = TrameFactory.Pivot(SensGD.Gauche, angle, this);

            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public override void PivotDroite(double angle, bool attendre = true)
        {
            angle = Math.Round(angle, 2);
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));
            Trame trame = TrameFactory.Pivot(SensGD.Droite, angle, this);
            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            Trame trame = TrameFactory.Stop(mode, this);
            DeplacementLigne = false;

            Connexion.SendMessage(trame);
            
            Historique.AjouterAction(new ActionStop(this, mode));
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            if(attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd));

            Trame trame = TrameFactory.Virage(sensAr, sensGd, rayon, angle, this);
            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public void GoToXY(int x, int y)
        {
            Trame trame = TrameFactory.GotoXY(x, y, this);
            Connexion.SendMessage(trame);
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionRecallage(this, sens));
            Trame trame = TrameFactory.Recallage(sens, this);
            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        #endregion
        
        public override void EnvoyerPID(int p, int i, int d)
        {
            Trame trame = TrameFactory.CoeffAsserv(p, i, d, this);
            Connexion.SendMessage(trame);
        }

        public override void ArmerJack()
        {
            Connexions.ConnexionIO.SendMessage(TrameFactory.ArmerJack());
        }

        public bool DemandePosition(bool attendre = true)
        {
            if(attendre)
                semPosition = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandePosition(this);
            Connexion.SendMessage(t);

            if (attendre)
                return semPosition.WaitOne(1000);
            else
                return true;
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            base.BougeServo(servo, position);
            Trame trame = TrameFactory.ServoEnvoiPositionCible(servo, position);
            Connexion.SendMessage(trame);
            Historique.AjouterAction(new ActionServo(this, position, servo));
        }

        public override void ServoVitesse(ServomoteurID servo, int vitesse)
        {
            Trame trame = TrameFactory.ServoEnvoiVitesseMax(servo, vitesse);
            Connexion.SendMessage(trame);
        }
        
        public override void ActionneurOnOff(ActionneurOnOffID actionneur, bool on)
        {
            if (actionneur == ActionneurOnOffID.GRAlimentation)
            {
                Trame trame = TrameFactory.CoupureAlim(on);
                Connexion.SendMessage(trame);
            }

            Historique.AjouterAction(new ActionOnOff(this, actionneur, on));
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
                Trame trame = TrameFactory.VitesseLigne(value, this);
                Connexion.SendMessage(trame);
                vitesseDeplacement = value;
                Historique.AjouterAction(new ActionVitesseLigne(this, value));
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
                Trame trame = TrameFactory.AccelLigne(value, this);
                Connexion.SendMessage(trame);
                accelDeplacement = value;
                Historique.AjouterAction(new ActionAccelerationLigne(this, value));
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
                Trame trame = TrameFactory.VitessePivot(value, this);
                Connexion.SendMessage(trame);
                vitessePivot = value;
                Historique.AjouterAction(new ActionVitessePivot(this, value));
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
                Trame trame = TrameFactory.AccelPivot(value, this);
                Connexion.SendMessage(trame);
                accelPivot = value;
                Historique.AjouterAction(new ActionAccelerationPivot(this, value));
            }
        }

        #endregion

        public override void TourneMoteur(MoteurID moteur, int vitesse)
        {
            base.TourneMoteur(moteur, vitesse);

            /*if (moteur == MoteurID.GRCanon)
            {
                Trame trame = TrameFactory.VitesseCanon(vitesse);
                Connexion.SendMessage(trame);
            }*/

            Historique.AjouterAction(new ActionMoteur(this, vitesse, moteur));
        }

        public override void AlimentationPuissance(bool on)
        {
            Trame trame = TrameFactory.CoupureAlim(on);
            Connexion.SendMessage(trame);
        }

        public override void Reset()
        {
            Connexion.SendMessage(TrameFactory.ResetRecMove());
            Thread.Sleep(1500);
        }

        private Semaphore semJack;
        private bool jackBranche;
        private bool historiqueJack;
        public override bool GetJack(bool historique = true)
        {
            historiqueJack = historique;
            semJack = new Semaphore(0, 1);
            Connexions.ConnexionIO.SendMessage(TrameFactory.DemandeJack());
            semJack.WaitOne();
            return jackBranche;
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

            while(retourTestPid[0].Count > nbValeurs)
                retourTestPid[0].RemoveAt(retourTestPid[0].Count - 1);

            while(retourTestPid[1].Count > nbValeurs)
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

            while (retourTestCharge[0].Count > nbValeurs)
                retourTestCharge[0].RemoveAt(retourTestCharge[0].Count - 1);

            while (retourTestCharge[1].Count > nbValeurs)
                retourTestCharge[1].RemoveAt(retourTestCharge[1].Count - 1);

            while (retourTestCharge[2].Count > nbValeurs)
                retourTestCharge[2].RemoveAt(retourTestCharge[2].Count - 1);


            return retourTestCharge;
        }
    }
}
