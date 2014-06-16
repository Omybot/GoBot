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
using GoBot.Actionneur;

namespace GoBot
{
    class RobotReel : Robot
    {
        Dictionary<FonctionIO, Semaphore> SemaphoresIO = new Dictionary<FonctionIO, Semaphore>();
        Dictionary<CapteurOnOff, Semaphore> SemaphoresCapteurs = new Dictionary<CapteurOnOff, Semaphore>();
        Dictionary<FonctionMove, Semaphore> SemaphoresMove = new Dictionary<FonctionMove, Semaphore>();
        Dictionary<CapteurOnOff, bool> ValeursCapteurs = new Dictionary<CapteurOnOff, bool>();

        private DateTime DateRefreshPos { get; set; }

        public Connexion Connexion { get; set; }

        public override Position Position { get; set; }

        public bool Evitement;

        public Enchainements.Enchainement Enchainement { get; set; }
        public Color Couleur;

        public RobotReel(IDRobot idRobot, Carte carte)
        {
            Carte = carte;
            IDRobot = idRobot;
            ServomoteursConnectes = new List<byte>();

            foreach (FonctionIO fonction in Enum.GetValues(typeof(FonctionIO)))
                SemaphoresIO.Add(fonction, new Semaphore(0, int.MaxValue));

            foreach (FonctionMove fonction in Enum.GetValues(typeof(FonctionMove)))
                SemaphoresMove.Add(fonction, new Semaphore(0, int.MaxValue));

            foreach (CapteurOnOff fonction in Enum.GetValues(typeof(CapteurOnOff)))
            {
                SemaphoresCapteurs.Add(fonction, new Semaphore(0, int.MaxValue));
                ValeursCapteurs.Add(fonction, false);
            }
        }

        public override void Init()
        {
            Evitement = true;
            Couleur = Color.Purple;

            Historique = new Historique(IDRobot);

            DateRefreshPos = DateTime.Now;

            //Enchainement = new Enchainements.HomologationEnchainement();

            Connexion.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);
            if(this == Robots.GrosRobot)
                Connexions.ConnexionIO.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

            Position = new Calculs.Position(new Angle(270, AnglyeType.Degre), new PointReel(200 + 160, 150));
            PositionCible = null;

            HistoriqueCoordonnees = new List<Position>();
            Connexion.SendMessage(TrameFactory.DemandePositionContinue(100, this));
        }

        public override bool DemandeCapteurOnOff(CapteurOnOff capteur, bool attendre = true)
        {
            if (attendre)
                SemaphoresCapteurs[capteur] = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandeCapteurOnOff(capteur);
            Connexions.ConnexionIO.SendMessage(t);

            if (attendre)
                SemaphoresCapteurs[capteur].WaitOne(100);

            return ValeursCapteurs[capteur];
        }

        public void Delete()
        {
            //timerPosition.Stop();
        }

        public void DebutMatch()
        {
            Console.WriteLine("Goooooo");

            /*Enchainement = new Enchainements.Gerome4Enchainement();

            Enchainement.Couleur = Couleur;
            Enchainement.Executer();*/
        }

        Thread thActivationAsser;

        public void ActivationAsserv()
        {
            Thread.Sleep(1500);
            FailTrajectoire = true;
            Stop(StopMode.Abrupt);
            SemaphoresMove[FonctionMove.FinDeplacement].Release();
        }

        public void ReceptionMessage(Trame trameRecue)
        {
            // Analyser la trame reçue

            if ((trameRecue[0] == (byte)Carte.RecMove && this == Robots.GrosRobot) || (trameRecue[0] == (byte)Carte.RecPi && this == Robots.PetitRobot))
            {
                if (trameRecue[0] == (byte)Carte.RecPi && trameRecue[1] == (byte)FonctionPi.RetourTestConnexion)
                {
                    // Uniquement sur le petit robot : Retour de la tension sur RecPi
                    TensionPack1 = (double)((trameRecue[2] * 256 + trameRecue[3]) / 100.0);
                    TensionPack2 = (double)((trameRecue[4] * 256 + trameRecue[5]) / 100.0);
                }

                if (trameRecue[1] == (byte)FonctionMove.Blocage)
                {
                    thActivationAsser = new Thread(ActivationAsserv);
                    thActivationAsser.Start();
                }

                if (trameRecue[1] == (byte)FonctionMove.FinDeplacement
                    || trameRecue[1] == (byte)FonctionMove.FinRecallage)
                {
                    Console.WriteLine("Déblocage déplacement " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond); 
                    SemaphoresMove[FonctionMove.FinDeplacement].Release();
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
                        SemaphoresMove[FonctionMove.DemandePositionXYTeta].Release();

                        HistoriqueCoordonnees.Add(new Position(teta, new PointReel(x, y)));
                        while (HistoriqueCoordonnees.Count > 3000)
                            HistoriqueCoordonnees.RemoveAt(0);
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
                        double chargePWMGauche = trameRecue[5 + i * 6] * 256 + trameRecue[6 + i * 6] - 4000;
                        double chargePWMDroite = trameRecue[7 + i * 6] * 256 + trameRecue[8 + i * 6] - 4000;


                        retourTestCharge[0].Add(chargeCPU);
                        retourTestCharge[1].Add(chargePWMGauche);
                        retourTestCharge[2].Add(chargePWMDroite);
                    }
                }
            }
            else if (trameRecue[0] == (byte)Carte.RecIO)
            {
                if (trameRecue[1] == (byte)FonctionIO.AspirationPompe && AspirationAutomatique)
                {
                    VitesseDeplacement = Config.CurrentConfig.GRVitesseLigneLent;
                    BrasFeux.RangerFeu();
                    VitesseDeplacement = Config.CurrentConfig.GRVitesseLigneRapide;
                }
                if (trameRecue[1] == (byte)FonctionIO.RetourCapteurOnOff)
                {
                    CapteurOnOff capteur = (CapteurOnOff)trameRecue[2];
                    ValeursCapteurs[capteur] = trameRecue[3] > 0 ? true : false;
                    if (SemaphoresCapteurs[capteur] != null)
                        SemaphoresCapteurs[capteur].Release();
                }

                if (trameRecue[1] == (byte)FonctionIO.RetourTestConnexion)
                {
                    TensionPack1 = (double)(trameRecue[2] * 256 + trameRecue[3]) / 100.0;
                    TensionPack2 = (double)(trameRecue[4] * 256 + trameRecue[5]) / 100.0;
                }

                if (trameRecue[1] == (byte)FonctionIO.ReponseJack)
                {
                    jackBranche = trameRecue[2] == 1 ? true : false;

                    if (historiqueJack)
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRJack, jackBranche ? "branché" : "absent"));

                    SemaphoresIO[FonctionIO.ReponseJack].Release();
                }

                if (trameRecue[1] == (byte)FonctionIO.DepartJack)
                {
                    Plateau.Enchainement = new GoBot.Enchainements.EnchainementMatch();
                    Plateau.Enchainement.Executer();
                }

                if (trameRecue[1] == (byte)FonctionIO.ReponseCouleurEquipe)
                {
                    if (trameRecue[2] == 0)
                        couleurEquipe = Plateau.CouleurGaucheRouge;
                    else if (trameRecue[2] == 1)
                        couleurEquipe = Plateau.CouleurDroiteJaune;

                    Plateau.NotreCouleur = couleurEquipe;

                    SemaphoresIO[FonctionIO.ReponseCouleurEquipe].Release();
                }
            }
        }

        #region Déplacements

        public override void Avancer(int distance, bool attendre = true)
        {
            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement] = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Avant, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionAvance(this, distance));

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement].WaitOne();

            DeplacementLigne = false;
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, double offsetTeta)
        {
            //PositionCible = new PointReel(offsetX, offsetY);
            Trame trame = TrameFactory.OffsetPos(offsetX, offsetY, offsetTeta, this);
            Connexion.SendMessage(trame);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement] = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Arriere, distance, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionRecule(this, distance));

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement].WaitOne();

            DeplacementLigne = false;
        }

        public override void PivotGauche(double angle, bool attendre = true)
        {
            angle = Math.Round(angle, 2);

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.Pivot(SensGD.Gauche, angle, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement].WaitOne();

            DeplacementLigne = false;
        }

        public override void PivotDroite(double angle, bool attendre = true)
        {
            angle = Math.Round(angle, 2);

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Trame trame = TrameFactory.Pivot(SensGD.Droite, angle, this);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement].WaitOne();
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
                SemaphoresMove[FonctionMove.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd));

            Trame trame = TrameFactory.Virage(sensAr, sensGd, rayon, angle, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement].WaitOne();
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement] = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionRecallage(this, sens));
            Trame trame = TrameFactory.Recallage(sens, this);
            Connexion.SendMessage(trame);

            if (attendre)
                SemaphoresMove[FonctionMove.FinDeplacement].WaitOne();
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
            if (!Connexion.ConnexionCheck.Connecte)
                return false;

            if(attendre)
                SemaphoresMove[FonctionMove.RetourPositionCodeurs] = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandePosition(this);
            Connexion.SendMessage(t);

            if (attendre)
                return SemaphoresMove[FonctionMove.RetourPositionXYTeta].WaitOne(1000);// semPosition.WaitOne(1000);
            else
                return true;
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            base.BougeServo(servo, position);

            if (this == Robots.GrosRobot)
            {
                Trame trame = TrameFactory.ServoEnvoiPositionCible(servo, position);
                Connexions.ConnexionIO.SendMessage(trame);
            }
            else
            {
                Trame trame = TrameFactory.ServoEnvoiPositionCible(servo, position, GoBot.Carte.RecPi);
                Connexion.SendMessage(trame);
            }
            Historique.AjouterAction(new ActionServo(this, position, servo));
        }

        public override void ServoVitesse(ServomoteurID servo, int vitesse)
        {
            Trame trame = TrameFactory.ServoEnvoiVitesseMax(servo, vitesse);
            Connexions.ConnexionIO.SendMessage(trame);
        }
        
        public override void ActionneurOnOff(ActionneurOnOffID actionneur, bool on)
        {
            if (this == Robots.GrosRobot)
            {
                Trame trame = TrameFactory.ActionneurOnOff(actionneur, on);
                Connexions.ConnexionIO.SendMessage(trame);
            }
            else
            {
                Trame trame = TrameFactory.ActionneurOnOff(actionneur, on, true);
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

        public override void MoteurPosition(MoteurID moteur, int position)
        {
            base.MoteurPosition(moteur, position);

            if (this == Robots.GrosRobot)
            {
                Trame trame = TrameFactory.MoteurPosition(moteur, position);
                Connexions.ConnexionIO.SendMessage(trame);
            }
            else
            {
                Trame trame = TrameFactory.MoteurPosition(moteur, position, true);
                Connexion.SendMessage(trame);
            }

            Historique.AjouterAction(new ActionMoteur(this, position, moteur));
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

        private bool jackBranche;
        private bool historiqueJack;
        public override bool GetJack(bool historique = true)
        {
            historiqueJack = historique;
            SemaphoresIO[FonctionIO.ReponseJack] = new Semaphore(0, 1);
            Connexions.ConnexionIO.SendMessage(TrameFactory.DemandeJack());
            SemaphoresIO[FonctionIO.ReponseJack].WaitOne(50);
            return jackBranche;
        }

        private Color couleurEquipe;
        private bool historiqueCouleurEquipe;
        public override Color GetCouleurEquipe(bool historique = true)
        {
            historiqueCouleurEquipe = historique;
            SemaphoresIO[FonctionIO.ReponseCouleurEquipe] = new Semaphore(0, 1);
            Connexions.ConnexionIO.SendMessage(TrameFactory.DemandeCouleurEquipe());
            SemaphoresIO[FonctionIO.ReponseCouleurEquipe].WaitOne(50);
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

            // Supprime d'éventuelles valeurs supplémentaires
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
