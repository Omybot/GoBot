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

        public override void Init()
        {
            Evitement = true;
            Couleur = Color.Purple;

            Historique = new Historique();

            semDeplacement = new Semaphore(0, int.MaxValue);
            semPosition = new Semaphore(0, int.MaxValue);
            DateRefreshPos = DateTime.Now;

            //Enchainement = new Enchainements.HomologationEnchainement();

            Connexion.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

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
                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.FinDeplacement
                    || trameRecue[1] == (byte)TrameFactory.FonctionMove.FinRecallage)
                {
                    semDeplacement.Release();
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponsePresence)
                {
                    presenceBalle = trameRecue[2] == 1 ? true : false;

                    if(historiquePresenceBalle)
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRPresenceBalle, (presenceBalle ? "quelque chose" : "rien")));

                    try
                    {
                        if(semCapteurPresence != null)
                            semCapteurPresence.Release();
                    }
                    catch(Exception)
                    {}
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponseCouleur)
                {
                    if (trameRecue.Length != 18)
                    {
                        Console.Error.WriteLine("Erreur de retour du capteur couleur.");
                        return;
                    }

                    int valCouleur1 = trameRecue[2] * 256 + trameRecue[3];
                    int valCouleur2 = trameRecue[4] * 256 + trameRecue[5];
                    int valCouleur3 = trameRecue[6] * 256 + trameRecue[7];
                    int valCouleur4 = trameRecue[8] * 256 + trameRecue[9];
                    int valCouleurAllume1 = trameRecue[10] * 256 + trameRecue[11];
                    int valCouleurAllume2 = trameRecue[12] * 256 + trameRecue[13];
                    int valCouleurAllume3 = trameRecue[14] * 256 + trameRecue[15];
                    int valCouleurAllume4 = trameRecue[16] * 256 + trameRecue[17];

                    Console.WriteLine("1|" + valCouleur1 + 
                        "\t\t2|" + valCouleur2 +
                        "\t\t3|" + valCouleur3 +
                        "\t\t4|" + valCouleur4 +
                        "\t\t5|" + valCouleurAllume1 +
                        "\t\t6|" + valCouleurAllume2 +
                        "\t\t7|" + valCouleurAllume3 +
                        "\t\t8|" + valCouleurAllume4 + "\t" + (valCouleur1+valCouleur2+valCouleur3+valCouleur4+valCouleurAllume1+valCouleurAllume2+valCouleurAllume3+valCouleurAllume4));

                    try
                    {
                        String couleur = "Blanc";
                            couleurBalle = Color.White;

                        if (valCouleurAllume4 > 23000)
                        {
                            couleurBalle = Color.Black;
                            couleur = "Rien";
                        }
                        else if (valCouleurAllume4 > 7000)
                        {
                            couleurBalle = Plateau.CouleurJ1Rouge;
                            couleur = "Rouge";
                        }
                        //else if (valCouleurAllume4 > 3200)
                        else if (valCouleurAllume4 > 1500)
                        {
                            couleurBalle = Plateau.CouleurJ2Jaune;
                            couleur = "Bleu";
                        }

                        couleur += " (" + valCouleurAllume4 + ")";

                        if (semCapteurCouleur != null)
                            semCapteurCouleur.Release();

                        //Console.Beep(valCouleurAllume4, 50);
                        if(historiqueCouleurBalle)
                            Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRCouleurBalle, couleur));
                    }
                    catch (Exception)
                    { }
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponseJack)
                {
                    jackBranche = trameRecue[2] == 1 ? true : false;
                    if (historiqueJack) 
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRJack, jackBranche ? "branché" : "absent"));
                    if(semJack != null)
                        semJack.Release();
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.RetourPositionXYTeta)
                {
                    // Réception de la position mesurée par l'asservissement
                    try
                    {
                        double y = (double)((short)(trameRecue[2] << 8 | trameRecue[3])/10.0);
                        double x = (double)((short)(trameRecue[4] << 8 | trameRecue[5])/10.0);
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

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponseAspiRemonte)
                {
                    aspiRemonte = trameRecue[2] == 1 ? true : false;
                    if (semAspiRemonte != null)
                        semAspiRemonte.Release();

                    if (historiqueAspiRemonte)
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRAspiRemonte, aspiRemonte ? "bien remonté" : "erreur"));
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.DepartJack)
                {
                    Plateau.Enchainement = new GoBot.Enchainements.EnchainementMatch();
                    Plateau.Enchainement.Executer();
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponseCouleurEquipe)
                {
                    if (trameRecue[2] == 0)
                        Plateau.NotreCouleur = Plateau.CouleurJ1Rouge;
                    else if (trameRecue[2] == 1)
                        Plateau.NotreCouleur = Plateau.CouleurJ2Jaune;

                    //Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRCouleurBalle, "));
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponseVitesseCanon)
                {
                    vitesseCanon = trameRecue[2] * 256 + trameRecue[3];
                    if (semVitesseCanon != null)
                        semVitesseCanon.Release();

                    if(historiqueVitesseCanon)
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRVitesseCanon, vitesseCanon + "tours/min"));
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponsePresenceAssiette)
                {
                    presenceAssiette = trameRecue[2] == 1 ? false : true;
                    if (semCapteurAssiette != null)
                        semCapteurAssiette.Release();

                    if (historiquePresenceAssiette)
                        Historique.AjouterAction(new ActionCapteur(this, CapteurID.GRPresenceAssiette, presenceAssiette ? "assiette" : "rien"));
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.RetourPositionCodeurs)
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
            }
        }

        #region Déplacements

        public override void Avancer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Avant, distance);
            Connexion.SendMessage(trame);

            Historique.AjouterAction(new ActionAvance(this, distance));

            if (attendre)
                semDeplacement.WaitOne();
            DeplacementLigne = false;
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta)
        {
            Trame trame = TrameFactory.OffsetPos(offsetX, offsetY, offsetTeta);
            Connexion.SendMessage(trame);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Historique.AjouterAction(new ActionRecule(this, distance));

            Trame trame = TrameFactory.Deplacer(SensAR.Arriere, distance);
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
            Trame trame = TrameFactory.Pivot(SensGD.Gauche, angle);

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
            Trame trame = TrameFactory.Pivot(SensGD.Droite, angle);
            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public override void Stop(StopMode mode = StopMode.Smooth)
        {
            Trame trame = TrameFactory.GRStop(mode);
            DeplacementLigne = false;

            Connexion.SendMessage(trame);
            
            Historique.AjouterAction(new ActionStop(this, mode));
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            if(attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionVirage(this, rayon, angle, sensAr, sensGd));

            Trame trame = TrameFactory.Virage(sensAr, sensGd, rayon, angle);
            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        public void GoToXY(int x, int y)
        {
            Trame trame = TrameFactory.GotoXY(x, y);
            Connexion.SendMessage(trame);
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterAction(new ActionRecallage(this, sens));
            Trame trame = TrameFactory.Recallage(sens);
            Connexion.SendMessage(trame);

            if (attendre)
                semDeplacement.WaitOne();
        }

        #endregion
        
        public override void EnvoyerPID(int p, int i, int d)
        {
            Trame trame = TrameFactory.CoeffAsserv(p, i, d);
            Connexion.SendMessage(trame);
        }

        public override void ArmerJack()
        {
            Connexion.SendMessage(TrameFactory.ArmerJack());
        }

        public bool DemandePosition(bool attendre = true)
        {
            if(attendre)
                semPosition = new Semaphore(0, int.MaxValue);

            Trame t = TrameFactory.DemandePosition();
            Connexion.SendMessage(t);

            if (attendre)
                return semPosition.WaitOne(1000);
            else
                return true;
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            base.BougeServo(servo, position);
            Trame trame = TrameFactory.ServoPosition(servo, position);
            Connexion.SendMessage(trame);
            Historique.AjouterAction(new ActionServo(this, position, servo));
        }
        
        public override void ActionneurOnOff(ActionneurOnOffID actionneur, bool on)
        {
            if (actionneur == ActionneurOnOffID.GRShutter)
            {
                Trame trame = TrameFactory.Shutter(on);
                Connexion.SendMessage(trame);
            }
            else if (actionneur == ActionneurOnOffID.GRAlimentation)
            {
                Trame trame = TrameFactory.CoupureAlim(on);
                Connexion.SendMessage(trame);
            }
            else if (actionneur == ActionneurOnOffID.GRPompe)
            {
                Trame trame = TrameFactory.ActiverPompe(on);
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
                Trame trame = TrameFactory.VitesseLigne(value);
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
                Trame trame = TrameFactory.AccelLigne(value);
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
                Trame trame = TrameFactory.VitessePivot(value);
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
                Trame trame = TrameFactory.AccelPivot(value);
                Connexion.SendMessage(trame);
                accelPivot = value;
                Historique.AjouterAction(new ActionAccelerationPivot(this, value));
            }
        }

        #endregion

        private Semaphore semCapteurPresence;
        private bool presenceBalle;
        private bool historiquePresenceBalle;
        public override bool GetPresenceBalle(bool historique = true)
        {
            historiquePresenceBalle = historique;
            semCapteurPresence = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandePresenceBalle());
            semCapteurPresence.WaitOne();
            return presenceBalle;
        }

        private Semaphore semCapteurCouleur;
        private Color couleurBalle;
        private bool historiqueCouleurBalle;
        public override Color GetCouleurBalle(bool historique = true)
        {
            historiqueCouleurBalle = historique;
            semCapteurCouleur = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandeCouleurBalle());
            semCapteurCouleur.WaitOne();
            return couleurBalle;
        }

        private Semaphore semCapteurAssiette;
        private bool presenceAssiette;
        private bool historiquePresenceAssiette;
        public override bool GetPresenceAssiette(bool historique = true)
        {
            historiquePresenceAssiette = historique;
            semCapteurAssiette = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandePresenceAssiette());
            semCapteurAssiette.WaitOne();
            return presenceAssiette;
        }

        private Semaphore semAspiRemonte;
        private bool aspiRemonte;
        private bool historiqueAspiRemonte;
        public override bool GetAspiRemonte(bool historique = true)
        {
            historiqueAspiRemonte = historique;
            semAspiRemonte = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandeAspiRemonte());
            semAspiRemonte.WaitOne();
            return aspiRemonte;
        }

        private Semaphore semVitesseCanon;
        private int vitesseCanon;
        private bool historiqueVitesseCanon;
        public override int GetVitesseCanon(bool historique = true)
        {
            historiqueVitesseCanon = historique;
            semVitesseCanon = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandeVitesseCanon());
            semVitesseCanon.WaitOne();
            return vitesseCanon;
        }

        public override void TourneMoteur(MoteurID moteur, int vitesse)
        {
            base.TourneMoteur(moteur, vitesse);

            if (moteur == MoteurID.GRCanon)
            {
                Trame trame = TrameFactory.VitesseCanon(vitesse);
                Connexion.SendMessage(trame);
            }
            else if (moteur == MoteurID.GRTurbineAspirateur)
            {
                Trame trame = TrameFactory.VitesseAspirateur(vitesse);
                Connexion.SendMessage(trame);
            }
            else if (moteur == MoteurID.GRCanonTMin)
            {
                Trame trame = TrameFactory.VitesseCanonTMin(vitesse);
                Connexion.SendMessage(trame);
            }

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
            Connexion.SendMessage(TrameFactory.DemandeJack());
            semJack.WaitOne();
            return jackBranche;
        }

        private List<int>[] retourTestPid;
        public override List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs)
        {
            retourTestPid = new List<int>[2];
            retourTestPid[0] = new List<int>();
            retourTestPid[1] = new List<int>();

            Trame trame = TrameFactory.EnvoiConsigneBrute(consigne, sens);
            Connexion.SendMessage(trame);

            trame = TrameFactory.DemandePositionsCodeurs();
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
    }
}
