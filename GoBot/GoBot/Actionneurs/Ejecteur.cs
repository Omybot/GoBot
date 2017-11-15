using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Ejecteur
    {
        public bool Charge { get; set; }

        public bool CouleurPositionnee { get; private set; }

        public Ejecteur()
        {
            Charge = false;
        }

        public void CouperEjecteur()
        {
            Config.CurrentConfig.ServoEjecteur.SendPosition(0);
        }


        public void RentrerEjecteur(bool autoReset = true)
        {
            Config.CurrentConfig.ServoEjecteur.SendPosition(Config.CurrentConfig.ServoEjecteur.PositionRentre);
            if (autoReset)
            //    ResetServoEjecteur(null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ResetServoEjecteur), null);
        }

        private void ResetServoEjecteur(Object o)
        {
            // Pour pas qu'il grésille
            Thread.Sleep(500);
            CouperEjecteur();
        }

        public void SortirEjecteur()
        {
            Config.CurrentConfig.ServoEjecteur.SendPosition(Config.CurrentConfig.ServoEjecteur.PositionSorti);
        }

        public void Ejecter()
        {
            SortirEjecteur();
            Thread.Sleep(500);
            RentrerEjecteur();
            CouleurPositionnee = false;
            Charge = false;
        }

        public void EjecterBonneCouleur()
        {
            if (Charge)
            {
                PositionnerCouleur();
                Ejecter();
            }
        }

        public void TournerGauche()
        {
            Config.CurrentConfig.MoteurOrientation.SendPosition(Config.CurrentConfig.MoteurOrientation.ValeurTourneGauche);
        }

        public void TournerDroite()
        {
            Config.CurrentConfig.MoteurOrientation.SendPosition(Config.CurrentConfig.MoteurOrientation.ValeurTourneDroite);
        }

        public void TournerStop()
        {
            Config.CurrentConfig.MoteurOrientation.SendPosition(Config.CurrentConfig.MoteurOrientation.ValeurStop);
        }

        private delegate bool FindColorDelegate();

        public void PositionnerCouleur()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurDroiteOrange)
                Positionne(IsYellow);
            else
                Positionne(IsBlue);
        }

        private void Positionne(FindColorDelegate CheckColor)
        {
            DemarrerCapteurCouleur();

            TournerGauche();

            int detections = 0;
            Stopwatch sw = Stopwatch.StartNew();

            while (detections < 3 && sw.ElapsedMilliseconds < 2000)
            { 
                Thread.Sleep(10);
                if (CheckColor())
                    detections++;
            }

            Thread.Sleep(300);
            TournerStop();
        }

        private bool IsBlue()
        {
            Color col = Robots.GrosRobot.DemandeCapteurCouleur(CapteurCouleurID.CouleurTube);
            return col.B > col.R * 2;
        }

        private bool IsYellow()
        {
            Color col = Robots.GrosRobot.DemandeCapteurCouleur(CapteurCouleurID.CouleurTube);
            return col.R > col.B * 2;
        }

        public void DemarrerCapteurCouleur()
        {
            if (!Robots.GrosRobot.ActionneurActive[ActionneurOnOffID.AlimCapteurCouleur])
            {
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.AlimCapteurCouleur, true);
                Thread.Sleep(200);
            }
        }
    }
}
