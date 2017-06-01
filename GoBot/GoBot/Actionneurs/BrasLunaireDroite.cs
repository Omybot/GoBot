using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class BrasLunaireDroite
    {
        public bool Charge { get; protected set; }

        public bool PresenceModule { get; private set; }

        public BrasLunaireDroite()
        {
            Devices.Devices.RecGoBot.ButtonChange += RecGoBot_ButtonChange;
        }

        void RecGoBot_ButtonChange(CapteurOnOffID btn, bool state)
        {
            if (btn == CapteurOnOffID.PresenceDroite)
                PresenceModule = state;
        }

        public void Ranger()
        {
            Config.CurrentConfig.ServoBrasLunaireDroit.Positionner(Config.CurrentConfig.ServoBrasLunaireDroit.PositionRange);
        }

        public void Monter()
        {
            Config.CurrentConfig.ServoBrasLunaireDroit.Positionner(Config.CurrentConfig.ServoBrasLunaireDroit.PositionStockage);
        }

        public void Descendre()
        {
            Config.CurrentConfig.ServoBrasLunaireDroit.Positionner(Config.CurrentConfig.ServoBrasLunaireDroit.PositionSortie);
        }

        public void DescendreSafe()
        {
            Config.CurrentConfig.ServoBrasLunaireDroit.Positionner(Config.CurrentConfig.ServoBrasLunaireDroit.PositionSortieSafe);
        }

        public void Ouvrir()
        {
            Config.CurrentConfig.ServoLunaireDroitSerrageDroit.Positionner(Config.CurrentConfig.ServoLunaireDroitSerrageDroit.PositionOuvert);
            Config.CurrentConfig.ServoLunaireDroitSerrageGauche.Positionner(Config.CurrentConfig.ServoLunaireDroitSerrageGauche.PositionOuvert);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoLunaireDroitSerrageDroit.Positionner(Config.CurrentConfig.ServoLunaireDroitSerrageDroit.PositionFerme);
            Config.CurrentConfig.ServoLunaireDroitSerrageGauche.Positionner(Config.CurrentConfig.ServoLunaireDroitSerrageGauche.PositionFerme);
        }

        private void LacheSiYaRien(object useless)
        {
            Thread.Sleep(1000);
            if (!PresenceModule)
            {
                Ouvrir();
                Descendre();
                Thread.Sleep(1000);

                Fermer();
                Ranger();
                Charge = false;
            }
        }

        public void Attraper()
        {
            Fermer();
            Thread.Sleep(100);
            Monter();
            Charge = true;

            //ThreadPool.QueueUserWorkItem(new WaitCallback(LacheSiYaRien));
        }

        public void Deposer()
        {
            Descendre();
            Thread.Sleep(300);
            Ouvrir();
            Thread.Sleep(50);
            Charge = false;
        }

        public void TransfertAvant()
        {
            int accelTmp = Robots.GrosRobot.SpeedConfig.LineDeceleration;

            Actionneur.BrasLunaire.Descendre();
            Actionneur.BrasLunaire.Ouvrir();
            Deposer();
            Robots.GrosRobot.Reculer(200);
            Fermer();
            Ranger();
            Robots.GrosRobot.PivotDroite(43);
            Robots.GrosRobot.SpeedConfig.LineDeceleration = 300;
            Actionneur.BrasLunaire.Avancer();
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.SpeedConfig.LineDeceleration = accelTmp;
            Actionneur.BrasLunaire.Fermer();
            Thread.Sleep(180);
        }
    }
}
