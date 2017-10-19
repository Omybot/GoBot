using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace GoBot.Actionneurs
{
    class BrasLunaire
    {
        public bool ModuleCharge { get; protected set; }

        public bool CapteurPresence
        {
            get
            {
                return Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.PresenceCentre);
            }
        }

        public void MonterStockage()
        {
            Config.CurrentConfig.ServoLunaireMonte.SendPosition(Config.CurrentConfig.ServoLunaireMonte.PositionMoyenne);
        }

        public void Avancer()
        {
            Config.CurrentConfig.ServoLunaireChariot.SendPosition(Config.CurrentConfig.ServoLunaireChariot.PositionSortie);
        }

        public void Reculer()
        {
            Config.CurrentConfig.ServoLunaireChariot.SendPosition(Config.CurrentConfig.ServoLunaireChariot.PositionRange);
        }

        public void ReculerStockage()
        {
            Config.CurrentConfig.ServoLunaireChariot.SendPosition(Config.CurrentConfig.ServoLunaireChariot.PositionStockage);
        }

        public void Monter()
        {
            Config.CurrentConfig.ServoLunaireMonte.SendPosition(Config.CurrentConfig.ServoLunaireMonte.PositionHaut);
        }

        public void Descendre()
        {
            Config.CurrentConfig.ServoLunaireMonte.SendPosition(Config.CurrentConfig.ServoLunaireMonte.PositionBas);
        }

        public void Ouvrir()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.SendPosition(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionOuvert);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.SendPosition(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionOuvert);
        }

        public void SemiFermer()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.SendPosition(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionSemiFerme);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.SendPosition(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionSemiFerme);
        }

        public void Fermer()
        {
            Config.CurrentConfig.ServoPinceLunaireSerrageDroit.SendPosition(Config.CurrentConfig.ServoPinceLunaireSerrageDroit.PositionFerme);
            Config.CurrentConfig.ServoPinceLunaireSerrageGauche.SendPosition(Config.CurrentConfig.ServoPinceLunaireSerrageGauche.PositionFerme);
        }

        /// <summary>
        /// Le module doit être déjà présenté dans la pince
        /// </summary>
        public bool AttraperModuleEtTransferer()
        {
            Fermer();
            Thread.Sleep(150);
            for (int i = 0; i < 3; i++)
                Monter();
            Reculer();
            Thread.Sleep(500);
            Ouvrir();
            ModuleCharge = false;

            bool capteur = Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.PresenceCentre);
            Console.WriteLine("LE CAPTEUR A DIT " + capteur.ToString());
            return capteur;
        }

        /// <summary>
        /// Le module doit être déjà présenté dans la pince
        /// </summary>
        public void AttraperModuleEtStocker()
        {
            Fermer();
            Thread.Sleep(200);
            Avancer();
            Monter();
            Thread.Sleep(100);
            ModuleCharge = Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOffID.PresenceCentre);

            if (!ModuleCharge)
                Reculer();
        }

        public void TransfererStock()
        {
            Actionneur.BrasLunaire.Reculer();
            Thread.Sleep(250);
            Actionneur.BrasLunaire.Ouvrir();
            ModuleCharge = false;
        }
    }
}
