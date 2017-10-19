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
                count += stockBas ? 1 : 0;
                count += stockMilieu ? 1 : 0;
                count += stockHaut ? 1 : 0;

                return count;
            }
        }

        private bool stockBas;
        private bool stockMilieu;
        private bool stockHaut;


        public bool Stockable
        {
            get
            {
                return !stockMilieu;
            }
        }

        public void Ejecter()
        {
            stockBas = false;
            Actionneur.Ejecteur.Charge = true;
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
            if (stockMilieu && !stockHaut)
            {
                RelacheHaut();
                MonterRehausseur();
                Thread.Sleep(400);
                BloquerHaut();
                BloqueBas();
                Thread.Sleep(300);
                RangerRehausseur();
                stockMilieu = false;
                stockHaut = true;
                Actionneur.Ejecteur.Charge = true;
            }
            if (stockMilieu && !stockBas)
            {
                Actionneur.Ejecteur.RentrerEjecteur(false);
                RangerRehausseur();
                RelacheBas();
                Thread.Sleep(200);
                BloqueBas();
                stockMilieu = false;
                stockBas = true;
                Actionneur.Ejecteur.PositionnerCouleur();
                Actionneur.Ejecteur.Charge = true;
                Actionneur.Ejecteur.CouperEjecteur();
            }
        }

        public void Descendre()
        {
            if(stockBas)
            {
                return;
            }
            else if(stockMilieu)
            {
                Actionneur.Ejecteur.RentrerEjecteur(false);
                PreparerRehausseur();
                Thread.Sleep(200);
                RelacheBas();
                Thread.Sleep(200);
                RangerRehausseur();
                Thread.Sleep(200);
                BloqueBas();
                stockMilieu = false;
                stockBas = true;
                BloquerHaut();
                Actionneur.Ejecteur.CouperEjecteur();
            }
            else if (stockHaut)
            {
                Actionneur.Ejecteur.RentrerEjecteur(false);
                RelacheBas();
                MonterRehausseur();
                Thread.Sleep(400);
                RelacheHaut();
                Thread.Sleep(75);
                RangerRehausseur();
                Thread.Sleep(500);
                stockHaut = false;
                stockBas = true;
                BloqueBas();
                BloquerHaut();
                Actionneur.Ejecteur.CouperEjecteur();
            }
        }

        public void RangerCalleur()
        {
            Config.CurrentConfig.ServoCalleur.SendPosition(Config.CurrentConfig.ServoCalleur.PositionRange);
        
}

        public void CallerCalleur()
        {
            Config.CurrentConfig.ServoCalleur.SendPosition(Config.CurrentConfig.ServoCalleur.PositionCalle);
        }

        public void Avaler()
        {
            if (!stockBas)
                PreparerRehausseur();
            BloqueBas();
            stockMilieu = true;
        }

        public void BloquerHaut()
        {
            Config.CurrentConfig.ServoBloqueurHaut.SendPosition(Config.CurrentConfig.ServoBloqueurHaut.PositionSorti);
        }

        public void BloqueBas()
        {
            Config.CurrentConfig.ServoBloqueurBas.SendPosition(Config.CurrentConfig.ServoBloqueurBas.PositionSorti);
        }

        public void RelacheHaut()
        {
            Config.CurrentConfig.ServoBloqueurHaut.SendPosition(Config.CurrentConfig.ServoBloqueurHaut.PositionRentre);
        }

        public void RelacheBas()
        {
            Config.CurrentConfig.ServoBloqueurBas.SendPosition(Config.CurrentConfig.ServoBloqueurBas.PositionRentre);
        }

        public void RangerRehausseur()
        {
            Config.CurrentConfig.ServoRehausseur.SendPosition(Config.CurrentConfig.ServoRehausseur.PositionRange);
        }

        public void PreparerRehausseur()
        {
            Config.CurrentConfig.ServoRehausseur.SendPosition(Config.CurrentConfig.ServoRehausseur.PositionBasse);
        }

        public void MonterRehausseur()
        {
            Config.CurrentConfig.ServoRehausseur.SendPosition(Config.CurrentConfig.ServoRehausseur.PositionHaute);
        }

        public void Caller()
        {
            CallerCalleur();
            Thread.Sleep(400);
            RangerCalleur();
        }

        public void MilieuVersBas()
        {
            RelacheBas();
            RangerRehausseur();
            Thread.Sleep(200);
            BloqueBas();
            stockMilieu = false;
            stockBas = true;
        }
    }
}
