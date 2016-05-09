using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class PinceBasLateralGauche
    {
        public void Ouvrir()
        {
            Config.CurrentConfig.ServoPinceBasLateralGaucheAvant.Positionner(Config.CurrentConfig.ServoPinceBasLateralGaucheAvant.PositionOuvert);
            Config.CurrentConfig.ServoPinceBasLateralGaucheArriere.Positionner(Config.CurrentConfig.ServoPinceBasLateralGaucheArriere.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoPinceBasLateralGaucheAvant.Positionner(Config.CurrentConfig.ServoPinceBasLateralGaucheAvant.PositionFerme);
            Config.CurrentConfig.ServoPinceBasLateralGaucheArriere.Positionner(Config.CurrentConfig.ServoPinceBasLateralGaucheArriere.PositionFerme);
        }

        public void Ranger()
        {
            Config.CurrentConfig.ServoPinceBasLateralGaucheAvant.Positionner(Config.CurrentConfig.ServoPinceBasLateralGaucheAvant.PositionRange);
            Config.CurrentConfig.ServoPinceBasLateralGaucheArriere.Positionner(Config.CurrentConfig.ServoPinceBasLateralGaucheArriere.PositionRange);
        }
    }

    class PinceBasLateralDroite
    {
        public void Ouvrir()
        {
            Config.CurrentConfig.ServoPinceBasLateralDroiteAvant.Positionner(Config.CurrentConfig.ServoPinceBasLateralDroiteAvant.PositionOuvert);
            Config.CurrentConfig.ServoPinceBasLateralDroiteArriere.Positionner(Config.CurrentConfig.ServoPinceBasLateralDroiteArriere.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoPinceBasLateralDroiteAvant.Positionner(Config.CurrentConfig.ServoPinceBasLateralDroiteAvant.PositionFerme);
            Config.CurrentConfig.ServoPinceBasLateralDroiteArriere.Positionner(Config.CurrentConfig.ServoPinceBasLateralDroiteArriere.PositionFerme);
        }

        public void Ranger()
        {
            Config.CurrentConfig.ServoPinceBasLateralDroiteAvant.Positionner(Config.CurrentConfig.ServoPinceBasLateralDroiteAvant.PositionRange);
            Config.CurrentConfig.ServoPinceBasLateralDroiteArriere.Positionner(Config.CurrentConfig.ServoPinceBasLateralDroiteArriere.PositionRange);
        }
    }
}
