using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class BrasLunaireGauche
    {
        public bool Charge { get; protected set; }

        public bool PresenceModule { get; private set; }

        public BrasLunaireGauche()
        {
            Devices.Devices.RecGoBot.ButtonChange += RecGoBot_ButtonChange;
        }

        void RecGoBot_ButtonChange(CapteurOnOffID btn, bool state)
        {
            if (btn == CapteurOnOffID.PresenceGauche)
                PresenceModule = state;
        }

        public void Ranger()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionRange);
        }

        public void Monter()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionStockage);
        }

        public void Descendre()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionSortie);
        }

        public void DescendreSafe()
        {
            Config.CurrentConfig.ServoBrasLunaireGauche.Positionner(Config.CurrentConfig.ServoBrasLunaireGauche.PositionSortieSafe);
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
            int accelTmp = Robots.GrosRobot.AccelerationFinDeplacement;

            Actionneur.BrasLunaire.Descendre();
            Actionneur.BrasLunaire.Ouvrir();
            Deposer();
            Robots.GrosRobot.Reculer(200);
            Fermer();
            Ranger();
            Robots.GrosRobot.PivotGauche(43);
            Robots.GrosRobot.AccelerationFinDeplacement = 300;
            Actionneur.BrasLunaire.Avancer();
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.AccelerationFinDeplacement = accelTmp;
            Actionneur.BrasLunaire.Fermer();
            Thread.Sleep(180);
        }
    }
}
