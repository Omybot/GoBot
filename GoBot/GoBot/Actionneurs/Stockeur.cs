using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Stockeur
    {
        public void BloqueHaut()
        {
            Config.CurrentConfig.ServoBloqueurHaut.Positionner(Config.CurrentConfig.ServoBloqueurHaut.PositionSorti);
        }

        public void BloqueBas()
        {
            Config.CurrentConfig.ServoBloqueurBas.Positionner(Config.CurrentConfig.ServoBloqueurBas.PositionSorti);
        }

        public void RelacheHaut()
        {
            Config.CurrentConfig.ServoBloqueurHaut.Positionner(Config.CurrentConfig.ServoBloqueurHaut.PositionRentre);
        }

        public void RelacheBas()
        {
            Config.CurrentConfig.ServoBloqueurBas.Positionner(Config.CurrentConfig.ServoBloqueurBas.PositionRentre);
        }

        public void RangerRehausseur()
        {
            Config.CurrentConfig.ServoRehausseur.Positionner(Config.CurrentConfig.ServoRehausseur.PositionRange);
        }

        public void PreparerRehausseur()
        {
            Config.CurrentConfig.ServoRehausseur.Positionner(Config.CurrentConfig.ServoRehausseur.PositionBasse);
        }

        public void MonterRehausseur()
        {
            Config.CurrentConfig.ServoRehausseur.Positionner(Config.CurrentConfig.ServoRehausseur.PositionHaute);
        }

        public void StockerPremierModule()
        {
            BloqueBas();
            Thread.Sleep(500);
            RelacheHaut();
            Thread.Sleep(500);
            PreparerRehausseur();
            Thread.Sleep(500);
            MonterRehausseur();
            Thread.Sleep(500);
            BloqueHaut();
            Thread.Sleep(500);
            RangerRehausseur();
        }

        public void StockerDeuxiemeModule()
        {
            RelacheBas();
            Thread.Sleep(500);
            BloqueBas();
        }

        public void StockerTroisiemeModule()
        {
            RelacheBas();
            Thread.Sleep(500);
            BloqueBas();
        }
    }
}
