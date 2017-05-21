using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class Stockeur
    {
        public int ModulesCount
        {
            get
            {
                int count = 0;
                count += StockBas ? 1 : 0;
                count += StockMilieu ? 1 : 0;
                count += StockHaut ? 1 : 0;

                return count;
            }
        }

        private bool StockBas;
        private bool StockMilieu;
        private bool StockHaut;

        public bool Ejectable
        {
            get
            {
                return StockBas;
            }
        }


        public void Ranger(bool parallel)
        {
            if (parallel)
                ThreadPool.QueueUserWorkItem(new WaitCallback(Ranger), null);
            else
                Ranger(null);
        }

        private void Ranger(object o)
        {
            if (StockMilieu && !StockBas)
            {
                RelacheBas();
                Thread.Sleep(400);
                BloqueBas();
                StockMilieu = false;
                StockBas = true;
                Actionneur.Ejecteur.PositionneCouleur();
            }
            if (StockMilieu && !StockHaut)
            {
                RelacheHaut();
                PreparerRehausseur();
                Thread.Sleep(300);
                RelacheBas();
                MonterRehausseur();
                Thread.Sleep(400);
                BloqueHaut();
                BloqueBas();
                Thread.Sleep(300);
                RangerRehausseur();
                StockMilieu = false;
                StockHaut = true;
            }
        }

        public void Descendre()
        {
            if(StockBas)
            {
                return;
            }
            else if(StockMilieu)
            {
                PreparerRehausseur();
                Thread.Sleep(200);
                RelacheBas();
                Thread.Sleep(100);
                RangerRehausseur();
                Thread.Sleep(400);
                BloqueBas();
                StockMilieu = false;
                StockBas = true;
            }
            else if (StockHaut)
            {
                RelacheBas();
                MonterRehausseur();
                Thread.Sleep(600);
                RelacheHaut();
                Thread.Sleep(200);
                RangerRehausseur();
                Thread.Sleep(600);
                StockHaut = false;
                StockBas = true;
            }
        }

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
