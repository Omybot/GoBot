using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class MaintienDune
    {
        public void Ranger()
        {
            Config.CurrentConfig.ServoMaintienDroite.Positionner(Config.CurrentConfig.ServoMaintienDroite.PositionRange);
            Config.CurrentConfig.ServoMaintienGauche.Positionner(Config.CurrentConfig.ServoMaintienGauche.PositionRange);
        }

        public void Ouvrir()
        {
            Config.CurrentConfig.ServoMaintienDroite.Positionner(Config.CurrentConfig.ServoMaintienDroite.PositionOuvert);
            Config.CurrentConfig.ServoMaintienGauche.Positionner(Config.CurrentConfig.ServoMaintienGauche.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoMaintienDroite.Positionner(Config.CurrentConfig.ServoMaintienDroite.PositionFerme);
            Config.CurrentConfig.ServoMaintienGauche.Positionner(Config.CurrentConfig.ServoMaintienGauche.PositionFerme);
        }
    }
}
