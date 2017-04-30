using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Ejecteur
    {
        public void RentrerEjecteur()
        {
            Config.CurrentConfig.ServoEjecteur.Positionner(Config.CurrentConfig.ServoEjecteur.PositionRentre);
        }

        public void SortirEjecteur()
        {
            Config.CurrentConfig.ServoEjecteur.Positionner(Config.CurrentConfig.ServoEjecteur.PositionSorti);
        }

        public void Ejecter()
        {
            SortirEjecteur();
            Thread.Sleep(200);
            RentrerEjecteur();
            Thread.Sleep(200);
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
    }
}
