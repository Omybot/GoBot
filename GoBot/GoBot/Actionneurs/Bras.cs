using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    public class BrasGauche
    {
        public void Deployer()
        {
            Config.CurrentConfig.ServoBrasGauche.Positionner(Config.CurrentConfig.ServoBrasGauche.PositionDeploye);
        }
        public void Ranger()
        {
            Config.CurrentConfig.ServoBrasGauche.Positionner(Config.CurrentConfig.ServoBrasGauche.PositionRange);
        }
        public void Fermer()
        {
            Config.CurrentConfig.SerrageBrasGauche.Positionner(Config.CurrentConfig.SerrageBrasGauche.ValeurFermeture);
        }
        public void Ouvrir()
        {
            Config.CurrentConfig.SerrageBrasGauche.Positionner(Config.CurrentConfig.SerrageBrasGauche.ValeurOuverture);
        }
    }

    public class BrasDroite
    {
        public void Deployer()
        {
            Config.CurrentConfig.ServoBrasDroite.Positionner(Config.CurrentConfig.ServoBrasDroite.PositionDeploye);
        }
        public void Ranger()
        {
            Config.CurrentConfig.ServoBrasDroite.Positionner(Config.CurrentConfig.ServoBrasDroite.PositionRange);
        }
        public void Fermer()
        {
            Config.CurrentConfig.SerrageBrasDroite.Positionner(Config.CurrentConfig.SerrageBrasDroite.ValeurFermeture);
        }
        public void Ouvrir()
        {
            Config.CurrentConfig.SerrageBrasDroite.Positionner(Config.CurrentConfig.SerrageBrasDroite.ValeurOuverture);
        }
    }
}
