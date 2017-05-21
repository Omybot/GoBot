﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Ejecteur
    {
        public bool CouleurPositionnee { get; private set; }

        public void RentrerEjecteur()
        {
            Config.CurrentConfig.ServoEjecteur.Positionner(Config.CurrentConfig.ServoEjecteur.PositionRentre);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ResetServoEjecteur), null);
        }

        private void ResetServoEjecteur(Object o)
        {
            // Pour pas qu'il grésille
            Thread.Sleep(500);
            Config.CurrentConfig.ServoEjecteur.Positionner(0);
        }

        public void SortirEjecteur()
        {
            Config.CurrentConfig.ServoEjecteur.Positionner(Config.CurrentConfig.ServoEjecteur.PositionSorti);
        }

        public void Ejecter()
        {
            SortirEjecteur();
            Thread.Sleep(275);
            RentrerEjecteur();
            CouleurPositionnee = false;
        }

        public void TournerGauche()
        {
            Config.CurrentConfig.MoteurOrientation.Positionner(Config.CurrentConfig.MoteurOrientation.ValeurTourneGauche);
        }

        public void TournerDroite()
        {
            Config.CurrentConfig.MoteurOrientation.Positionner(Config.CurrentConfig.MoteurOrientation.ValeurTourneDroite);
        }

        public void TournerStop()
        {
            Config.CurrentConfig.MoteurOrientation.Positionner(Config.CurrentConfig.MoteurOrientation.ValeurStop);
        }

        private delegate bool FindColorDelegate();

        public void PositionneCouleur()
        {
            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Positionne(IsYellow);
            else
                Positionne(IsBlue);
        }

        private void Positionne(FindColorDelegate CheckColor)
        {
            DemarrerCapteurCouleur();

            TournerGauche();
            for (int i = 0; i < 3; i++) //On veut plusieurs mesures bonnes histoire d'etre un peu plus sur
            {
                Thread.Sleep(10);
                while (!CheckColor())
                    Thread.Sleep(10);
            }
            Thread.Sleep(300);
            TournerStop();

            CouleurPositionnee = true;
        }

        private bool IsBlue()
        {
            Color col = Robots.GrosRobot.DemandeCapteurCouleur(CapteurCouleurID.CouleurTube);
            Console.WriteLine(col);
            return col.B > col.R * 2;
        }

        private bool IsYellow()
        {
            Color col = Robots.GrosRobot.DemandeCapteurCouleur(CapteurCouleurID.CouleurTube);
            return col.R > col.B;
        }

        private void DemarrerCapteurCouleur()
        {
            if (!Robots.GrosRobot.ActionneurActive[ActionneurOnOffID.AlimCapteurCouleur])
            {
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.AlimCapteurCouleur, true);
                Thread.Sleep(200);
            }
        }
    }
}
