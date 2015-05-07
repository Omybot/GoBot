using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Communications;

namespace GoBot.Actionneurs
{
    public abstract class BrasPieds
    {
        private int nbPieds;

        public int NbPieds
        {
            get { return nbPieds; }
            set { nbPieds = value; }
        }

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

        private Semaphore semSwitch;

        public BrasPieds()
        {
            Robots.GrosRobot.ChangementEtatCapteurOnOff += new Robot.ChangementEtatCapteurOnOffDelegate(GrosRobot_ChangementEtatCapteurOnOff);
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

        public void Empiler()
        {
            NbPieds++;

            if (NbPieds > 4)
                NbPieds = 1;

            OuvrirPinceBas();
            Thread.Sleep(100);

            if (NbPieds < 4)
                AscenseurDescendre();
            else
                AscenseurHauteur(PositionHauteurBasse + DifferenceHauteurBas2);

            Thread.Sleep(350);
            FermerPinceBas();
            Thread.Sleep(300);

            if (NbPieds < 4)
            {
                OuvrirPinceHaut();
                Thread.Sleep(100);
                AscenseurMonter();
            }

            if (NbPieds >= 2)
            {
                Thread.Sleep(300);
                FermerPinceHaut();
            }
            if (NbPieds == 4)
                AscenseurHauteur(PositionHauteurBasse + DifferenceHauteurBas3);
        }

        public void AscenseurCalibration()
        {
            AscenseurVitesse = 10;
            semSwitch = new Semaphore(0, 1);
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
            semSwitch = null;
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
    }
}
