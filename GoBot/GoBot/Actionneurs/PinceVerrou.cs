using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class PinceVerrou
    {
        public void Ranger()
        {
            Config.CurrentConfig.ServoVerrouDroite.Positionner(Config.CurrentConfig.ServoVerrouDroite.PositionRange);
            Config.CurrentConfig.ServoVerrouGauche.Positionner(Config.CurrentConfig.ServoVerrouGauche.PositionRange);
        }

        public void Ouvrir()
        {
            Config.CurrentConfig.ServoVerrouDroite.Positionner(Config.CurrentConfig.ServoVerrouDroite.PositionOuvert);
            Config.CurrentConfig.ServoVerrouGauche.Positionner(Config.CurrentConfig.ServoVerrouGauche.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoVerrouDroite.Positionner(Config.CurrentConfig.ServoVerrouDroite.PositionFerme);
            Config.CurrentConfig.ServoVerrouGauche.Positionner(Config.CurrentConfig.ServoVerrouGauche.PositionFerme);
        }

        public void FermerAvecEtape()
        {
            Ouvrir();
            Thread.Sleep(300);
            Fermer();
        }
    }
}
