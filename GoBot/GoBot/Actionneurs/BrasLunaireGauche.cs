using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class BrasLunaireGauche
    {
        public void Monter()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionRange);
        }

        public void Stocker()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionStockage);
        }

        public void Descendre()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionSortie);
        }

        public void Ouvrir()
        {
            Config.CurrentConfig.ServoLunaireGaucheSerrageDroit.Positionner(Config.CurrentConfig.ServoLunaireGaucheSerrageDroit.PositionOuvert);
            Config.CurrentConfig.ServoLunaireGaucheSerrageGauche.Positionner(Config.CurrentConfig.ServoLunaireGaucheSerrageGauche.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoLunaireGaucheSerrageDroit.Positionner(Config.CurrentConfig.ServoLunaireGaucheSerrageDroit.PositionFerme);
            Config.CurrentConfig.ServoLunaireGaucheSerrageGauche.Positionner(Config.CurrentConfig.ServoLunaireGaucheSerrageGauche.PositionFerme);
        }

        public void Attraper()
        {
            Fermer();
            Stocker();
        }
    }
}
