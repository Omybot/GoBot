using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class PinceBasAvant
    {
        public void Ouvrir()
        {
            Config.CurrentConfig.ServoPinceBasAvantDroite.Positionner(Config.CurrentConfig.ServoPinceBasAvantDroite.PositionOuvert);
            Config.CurrentConfig.ServoPinceBasAvantGauche.Positionner(Config.CurrentConfig.ServoPinceBasAvantGauche.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoPinceBasAvantDroite.Positionner(Config.CurrentConfig.ServoPinceBasAvantDroite.PositionFerme);
            Config.CurrentConfig.ServoPinceBasAvantGauche.Positionner(Config.CurrentConfig.ServoPinceBasAvantGauche.PositionFerme);
        }

        public void Ranger()
        {
            Config.CurrentConfig.ServoPinceBasAvantDroite.Positionner(Config.CurrentConfig.ServoPinceBasAvantDroite.PositionRange);
            Config.CurrentConfig.ServoPinceBasAvantGauche.Positionner(Config.CurrentConfig.ServoPinceBasAvantGauche.PositionRange);
        }
    }
}
