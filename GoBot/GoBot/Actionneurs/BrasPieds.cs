using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Communications;
using GoBot.Devices;

namespace GoBot.Actionneurs
{
    public abstract class BrasPieds
    {
        private int nbPieds;

        public int NbPieds
        {
            get 
            { 
                return nbPieds;
            }
            set 
            { 
                nbPieds = value;
                NbPiedsChange(nbPieds);
            }
        }

        public bool Gobelet { get; set; }

        private bool ampoulePrechargeePosee = false;
        public bool AmpoulePrechargee 
        {
            get
            {
                if (this == Actionneur.BrasGobelet && !ampoulePrechargeePosee)
                    return true;
                else
                    return false;
            }
            set
            {
                ampoulePrechargeePosee = !value;
            }
        }
        public bool AmpouleSurSpot { get; set; }

        public delegate void NbPiedsChangeDelegate(int nbPieds);
        public event NbPiedsChangeDelegate NbPiedsChange;

        public abstract int Minimum { get; }
        public abstract int Hauteur { get; }

        public abstract ServomoteurID ServoHautGauche { get; }
        public abstract ServomoteurID ServoHautDroite { get; }
        public abstract ServomoteurID ServoBasGauche { get; }
        public abstract ServomoteurID ServoBasDroite { get; }

        public abstract MoteurID MoteurHauteur { get; }

        public abstract int DifferenceHauteurSwitchBas { get; }
        public abstract int DifferenceHauteurBasHaut { get; }
        public abstract int DifferenceHauteurBas2 { get; }
        public abstract int DifferenceHauteurBas3 { get; }

        public abstract int PositionPinceBasDroiteFermee { get; set; }
        public abstract int PositionPinceBasDroiteOuverte { get; set; }
        public abstract int PositionPinceBasGaucheFermee { get; set; }
        public abstract int PositionPinceBasGaucheOuverte { get; set; }

        public abstract int PositionPinceHautDroiteFermee { get; set; }
        public abstract int PositionPinceHautDroiteOuverte { get; set; }
        public abstract int PositionPinceHautGaucheFermee { get; set; }
        public abstract int PositionPinceHautGaucheOuverte { get; set; }

        public abstract int PositionHauteurHaute { get; set; }
        public abstract int PositionHauteurBasse { get; set; }
        public abstract int PositionHauteurDeposeEstrade { get; set; }
        public abstract int PositionHauteurPousseEstrade { get; set; }
        public abstract int PortAnalogiqueCapteur { get; }

        private Semaphore semSwitch;

        public BrasPieds()
        {
            Robots.GrosRobot.ChangementEtatCapteurOnOff += new Robot.ChangementEtatCapteurOnOffDelegate(GrosRobot_ChangementEtatCapteurOnOff);
            Gobelet = false;
            AmpoulePrechargee = true;
            AmpouleSurSpot = false;
        }

        void GrosRobot_ChangementEtatCapteurOnOff(CapteurOnOffID capteur, bool etat)
        {
            if ((capteur == CapteurOnOffID.SwitchBrasDroiteOrigine || capteur == CapteurOnOffID.SwitchBrasGaucheOrigine) && etat && semSwitch != null)
                semSwitch.Release();
        }

        public void FermerPinceBasGauche()
        {
            Robots.GrosRobot.BougeServo(ServoBasGauche, PositionPinceBasGaucheFermee);
        }

        public void FermerPinceBasDroite()
        {
            Robots.GrosRobot.BougeServo(ServoBasDroite, PositionPinceBasDroiteFermee);
        }

        public void OuvrirPinceBasGauche()
        {
            Robots.GrosRobot.BougeServo(ServoBasGauche, PositionPinceBasGaucheOuverte);
        }

        public void OuvrirPinceBasDroite()
        {
            Robots.GrosRobot.BougeServo(ServoBasDroite, PositionPinceBasDroiteOuverte);
        }

        public void FermerPinceHautGauche()
        {
            Robots.GrosRobot.BougeServo(ServoHautGauche, PositionPinceHautGaucheFermee);
        }

        public void FermerPinceHautDroite()
        {
            Robots.GrosRobot.BougeServo(ServoHautDroite, PositionPinceHautDroiteFermee);
        }

        public void OuvrirPinceHautGauche()
        {
            Robots.GrosRobot.BougeServo(ServoHautGauche, PositionPinceHautGaucheOuverte);
        }

        public void OuvrirPinceHautDroite()
        {
            Robots.GrosRobot.BougeServo(ServoHautDroite, PositionPinceHautDroiteOuverte);
        }

        public void AscenseurHauteur(int position)
        {
            Robots.GrosRobot.MoteurPosition(MoteurHauteur, position);
        }

        public void AscenseurMonter()
        {
            Robots.GrosRobot.MoteurPosition(MoteurHauteur, PositionHauteurHaute);
        }

        public void AscenseurDescendre()
        {
            Robots.GrosRobot.MoteurPosition(MoteurHauteur, PositionHauteurBasse);
        }

        public void SouleverLegerement()
        {
            int position = (PositionHauteurHaute - PositionHauteurBasse) / 10 + PositionHauteurBasse;
            AscenseurHauteur(position);
        }

        public void FermerPinceBas()
        {
            FermerPinceBasDroite();
            FermerPinceBasGauche();
        }

        public void OuvrirPinceBas()
        {
            OuvrirPinceBasDroite();
            OuvrirPinceBasGauche();
        }

        public void FermerPinceHaut()
        {
            FermerPinceHautDroite();
            FermerPinceHautGauche();
        }

        public void OuvrirPinceHaut()
        {
            OuvrirPinceHautDroite();
            OuvrirPinceHautGauche();
        }

        public void Empiler(bool clic = false)
        {
            if (NbPieds == 4)
            {
            }

            else if (NbPieds == 0)
            {
                OuvrirPinceBas();
                Thread.Sleep(100);
                AscenseurDescendre();
                Thread.Sleep(350);
                if (clic)
                    ClicClic();
                else
                    FermerPinceBas();
                Thread.Sleep(300);
                OuvrirPinceHaut();
                Thread.Sleep(100);
                AscenseurMonter();
                Thread.Sleep(300);
                FermerPinceHaut();

                NbPieds++;
            }
            else if (NbPieds == 1)
            {
                OuvrirPinceBas();
                Thread.Sleep(100);
                AscenseurDescendre();
                Thread.Sleep(350);
                if (clic)
                    ClicClic();
                else
                    FermerPinceBas();
                Thread.Sleep(300);
                OuvrirPinceHaut();
                Thread.Sleep(100);
                AscenseurMonter();
                Thread.Sleep(250);
                FermerPinceHaut();

                NbPieds++;
            }
            else if (NbPieds == 2)
            {
                OuvrirPinceBas();
                Thread.Sleep(100);
                AscenseurDescendre();
                Thread.Sleep(350);
                if (clic)
                    ClicClic();
                else
                    FermerPinceBas();
                Thread.Sleep(300);
                OuvrirPinceHaut();
                Thread.Sleep(100);
                AscenseurMonter();
                Thread.Sleep(250);
                FermerPinceHaut();

                NbPieds++;
            }
            else if (NbPieds == 3)
            {
                OuvrirPinceBas();
                Thread.Sleep(100);
                AscenseurHauteur(PositionHauteurBasse + DifferenceHauteurBas2);
                Thread.Sleep(350);
                if (clic)
                    ClicClic();
                else
                    FermerPinceBas();
                Thread.Sleep(300);
                AscenseurHauteur(PositionHauteurBasse + DifferenceHauteurBas3);
                Thread.Sleep(300);

                NbPieds++;
            }
        }

        public void AscenseurCalibration()
        {
            /*AscenseurVitesse = 10;
            semSwitch = new Semaphore(0, int.MaxValue);
            AscenseurHauteur(Minimum);
            semSwitch.WaitOne();
            int hauteur = Hauteur;
            PositionHauteurHaute = hauteur + DifferenceHauteurBasHaut;
            PositionHauteurBasse = hauteur + DifferenceHauteurSwitchBas;
            Console.WriteLine(PositionHauteurBasse);
            AscenseurVitesse = 2000;
            AscenseurMonter();
            Thread.Sleep(350);
            AscenseurDescendre();
            semSwitch = null;*/
        }

        public int AscenseurVitesse
        {
            set
            {
                Robots.GrosRobot.MoteurVitesse(MoteurHauteur, value);
            }
        }

        public int AscenseurAcceleration
        {
            set
            {
                Robots.GrosRobot.MoteurAcceleration(MoteurHauteur, value);
            }
        }

        public abstract void Verrouiller();

        public abstract void Deverrouiller();

        public abstract void LibererBalle();

        private bool piedPresent = false;
        public bool ElementPresentAuSol 
        { 
            get
            {
                return piedPresent;
            }
            set
            {
                if(piedPresent != value)
                {
                    piedPresent = value;
                    DetectionChange(piedPresent);
                }
            }
        }

        public delegate void DetectionChangeDelegate(bool detection);
        public event DetectionChangeDelegate DetectionChange;

        public void DeposeSpot(bool hauteur = false)
        {
            if (hauteur)
            {
                OuvrirPinceHaut();
                Thread.Sleep(300);
                AscenseurHauteur(PositionHauteurDeposeEstrade);
            }
            if (NbPieds == 4)
            {
                OuvrirPinceBas();
                OuvrirPinceHaut();
                Thread.Sleep(200);

                if (AmpoulePrechargee)
                {
                    LibererBalle();
                    Thread.Sleep(200);
                    AmpoulePrechargee = false;
                }

                Deverrouiller();

                Thread.Sleep(300);

                NbPieds = 0;
            }
            else if (NbPieds == 3)
            {
                if (AmpoulePrechargee)
                {
                    LibererBalle();
                    Thread.Sleep(300);
                    AmpoulePrechargee = false;
                }

                OuvrirPinceHaut();
                AscenseurDescendre();
                Thread.Sleep(500);

                OuvrirPinceBas();
                Thread.Sleep(200);
                Verrouiller();

                NbPieds = 0;
            }
            else if (NbPieds == 2)
            {
                if (AmpoulePrechargee)
                {
                    LibererBalle();
                    Thread.Sleep(300);
                    AmpoulePrechargee = false;
                }

                OuvrirPinceHaut();
                Thread.Sleep(300);
                AscenseurDescendre();
                Thread.Sleep(500);

                OuvrirPinceBas();
                Thread.Sleep(200);
                Verrouiller();

                NbPieds = 0;
            }
            else if (NbPieds == 1)
            {
                if (AmpoulePrechargee)
                {
                    FermerPinceHaut();
                    LibererBalle();
                    Thread.Sleep(300);
                    OuvrirPinceHaut();
                    Thread.Sleep(300);
                    AmpoulePrechargee = false;
                }

                AscenseurDescendre();
                Thread.Sleep(500);

                OuvrirPinceBas();
                OuvrirPinceHaut();
                Thread.Sleep(200);
                Deverrouiller();

                Thread.Sleep(200);

                NbPieds = 0;
            }

            AmpouleSurSpot = false;
        }

        public void DeposeGobelet(bool attendre = true)
        {
            OuvrirPinceBas();
            AscenseurDescendre();
            Gobelet = false;

            if (attendre)
                Thread.Sleep(500);
        }

        public static void TransfererBalle()
        {
            Actionneur.BrasSpot.OuvrirPinceHaut();
            Actionneur.BrasSpot.Deverrouiller();
            Actionneur.BrasGobelet.OuvrirPinceBas();
            Actionneur.BrasGobelet.OuvrirPinceHaut();
            Actionneur.BrasGobelet.AscenseurDescendre();

            bool gobeletPose = Actionneur.BrasGobelet.Gobelet;
            Actionneur.BrasGobelet.Gobelet = false;

            if (Actionneur.BrasSpot.NbPieds < 4)
            {
                Actionneur.BrasSpot.AscenseurDescendre();
                Thread.Sleep(400);
            }

            Actionneur.BrasSpot.OuvrirPinceBas();
            Thread.Sleep(300);

            Robots.GrosRobot.Reculer(100);
            Actionneur.BrasGobelet.FermerPinceBas();
            if (gobeletPose)
                Thread.Sleep(100);

            if(Actionneur.BrasGobelet == Actionneur.BrasPiedsDroite)
                Robots.GrosRobot.PivotGauche(39);
            else
                Robots.GrosRobot.PivotDroite(39);

            Actionneur.BrasGobelet.OuvrirPinceBas();
            Robots.GrosRobot.Avancer(100);

            Actionneur.BrasGobelet.NbPieds = Actionneur.BrasSpot.NbPieds;
            Actionneur.BrasSpot.NbPieds = 0;

            if (Actionneur.BrasGobelet.NbPieds < 4)
            {
                Actionneur.BrasGobelet.FermerPinceBas();
                Thread.Sleep(300);
                Actionneur.BrasGobelet.AscenseurMonter();
                Thread.Sleep(500);
                Actionneur.BrasGobelet.FermerPinceHaut();
                Thread.Sleep(300);
            }
            else
            {
                Actionneur.BrasGobelet.FermerPinceBas();
                Actionneur.BrasGobelet.FermerPinceHaut();
            }

            int nbSpots = Actionneur.BrasGobelet.NbPieds;
            Actionneur.BrasGobelet.DeposeSpot();

            Robots.GrosRobot.Reculer(100);
            Actionneur.BrasGobelet.FermerPinceBas();

            if (Actionneur.BrasGobelet == Actionneur.BrasPiedsDroite)
                Robots.GrosRobot.PivotDroite(39);
            else
                Robots.GrosRobot.PivotGauche(39);

            Actionneur.BrasGobelet.OuvrirPinceBas();
            if (gobeletPose)
                Thread.Sleep(100);
            Robots.GrosRobot.Avancer(100);

            Actionneur.BrasSpot.NbPieds = nbSpots;
            Actionneur.BrasSpot.AmpouleSurSpot = true;

            if(gobeletPose)
            {
                Actionneur.BrasGobelet.FermerPinceBas();
                Actionneur.BrasGobelet.Verrouiller();
                Thread.Sleep(250);
                Actionneur.BrasGobelet.SouleverLegerement();
                Actionneur.BrasGobelet.Gobelet = true;
            }
            else
            {
                Actionneur.BrasGobelet.FermerPinceBas();
                Actionneur.BrasGobelet.FermerPinceHaut();
                Actionneur.BrasGobelet.Verrouiller();
                Actionneur.BrasGobelet.AscenseurMonter();
            }

            Actionneur.BrasSpot.FermerPinceBas();

            if (Actionneur.BrasSpot.NbPieds < 4)
            {
                Thread.Sleep(500);
                Actionneur.BrasSpot.AscenseurMonter();
            }
            Thread.Sleep(500);

            Actionneur.BrasSpot.FermerPinceHaut();
            Actionneur.BrasSpot.LibererBalle();
        }

        public void ClicClic()
        {
            FermerPinceBas();
            Thread.Sleep(50);
            Robots.GrosRobot.Reculer(20);
            OuvrirPinceBas();
            Thread.Sleep(20);
            Robots.GrosRobot.Avancer(20);
            FermerPinceBas();
            Thread.Sleep(50);
        }

        public bool AsserKO { get; set; }
    }
}
