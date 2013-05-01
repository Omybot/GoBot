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
    class RobotReel : Robot
    {
        public Semaphore semDeplacement;
        private Semaphore semPosition;

        public override int Longueur { get; set; }
        public override int Largeur { get; set; }

        private const int TIME_REFRESH_POS = 200;
        private DateTime DateRefreshPos { get; set; }

        private System.Timers.Timer timerPosition;

        public override String Nom { get; set; }

        public ConnexionUDP Connexion { get; set; }

        public override Position Position { get; set; }

        public bool Evitement;

        public Enchainements.Enchainement Enchainement { get; set; }
        public Color Couleur;

        public override void Init()
        {
            Nom = "GrosRobot";
            Evitement = true;
            Couleur = Color.Purple;

            Historique = new Historique();

            semDeplacement = new Semaphore(0, int.MaxValue);
            semPosition = new Semaphore(0, int.MaxValue);
            DateRefreshPos = DateTime.Now;

            //Enchainement = new Enchainements.HomologationEnchainement();

            Connexion.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionMessage);

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

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.ReponsePresence)
                {
                    presenceBalle = trameRecue[2] == 1 ? true : false;
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
                    //presenceBalle = trameRecue[2] == 1 ? true : false;
                    couleurBalle = (trameRecue[2] * 256 + trameRecue[3]).ToString();
                    try
                    {
                        if (semCapteurCouleur != null)
                            semCapteurCouleur.Release();
                    }
                    catch (Exception)
                    { }
                }

                if (trameRecue[1] == (byte)TrameFactory.FonctionMove.PositionXYTeta)
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
            }
            /*if (trameRecue[0] == (byte)Carte.RecIo)
            {
                if (trameRecue[1] == (byte)TrameFactory.FonctionIo.DepartJack)
                {
                    DebutMatch();
                }
            }*/
            /*if (trameRecue[0] == (byte)Carte.RecPi)
            {
                //PetitRobot.ReceptionTrame(trameRecue);
            }*/
        }

        #region Déplacements

        public override void Avancer(int distance, bool attendre = true)
        {
            if (attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            DeplacementLigne = true;
            Trame trame = TrameFactory.Deplacer(SensAR.Avant, distance);
            Connexion.SendMessage(trame);

            Historique.AjouterActionThread(new ActionAvance(this, distance));

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

            Connexion.SendMessage(trame);
            
            Historique.AjouterActionThread(new ActionStop(this, mode));
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            if(attendre)
                semDeplacement = new Semaphore(0, int.MaxValue);

            Historique.AjouterActionThread(new ActionVirage(this, rayon, angle, sensAr, sensGd));

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

            Historique.AjouterActionThread(new ActionRecallage(this, sens));
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

        public override void Allimentation(bool allume)
        {
            Trame t = TrameFactory.CoupureAlim(allume);
            Connexion.SendMessage(t);
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
            Trame trame = TrameFactory.ServoPosition(servo, position);
            Connexion.SendMessage(trame);
            Historique.AjouterAction(new ActionServo(this, position, servo));
        }
        
        public override void AspirerBalles()
        {
            Trame trame = TrameFactory.AspirerBalle();
            Connexion.SendMessage(trame);
            //Historique.AjouterAction(new ActionServo(this, position, servo));
        }
        
        public override void EjecterBalles()
        {
            Trame trame = TrameFactory.EjecterBalle();
            Connexion.SendMessage(trame);
            //Historique.AjouterAction(new ActionServo(this, position, servo));
        }
        
        public override void AspirerVitesse(int vitesse)
        {
            Trame trame = TrameFactory.VitesseAspirateur(vitesse);
            Connexion.SendMessage(trame);
            //Historique.AjouterAction(new ActionServo(this, position, servo));
        }
        
        public override void CanonVitesse(int vitesse)
        {
            Trame trame = TrameFactory.VitesseCanon(vitesse);
            Connexion.SendMessage(trame);
            //Historique.AjouterAction(new ActionServo(this, position, servo));
        }
        
        public override void Shutter(bool ouvert)
        {
            Trame trame = TrameFactory.Shutter(ouvert);
            Connexion.SendMessage(trame);
            //Historique.AjouterAction(new ActionServo(this, position, servo));
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
        public override bool PresenceBalle()
        {
            semCapteurPresence = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandePresenceBalle());
            semCapteurPresence.WaitOne();
            return presenceBalle;
        }

        private Semaphore semCapteurCouleur;
        private String couleurBalle;
        public override String CouleurBalle()
        {
            semCapteurCouleur = new Semaphore(0, 1);
            Connexion.SendMessage(TrameFactory.DemandeCouleurBalle());
            semCapteurCouleur.WaitOne();
            return couleurBalle;
        }
    }
}
