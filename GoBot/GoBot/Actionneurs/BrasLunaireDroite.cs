using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class BrasLunaireDroite
    {
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

        public void Attraper()
        {
            Fermer();
            Monter();
        }

        public void Depose()
        {
            Descendre();
            Thread.Sleep(300);
            Ouvrir();
            Thread.Sleep(50);
        }

        public void TransfertAvant()
        {
            int accelTmp = Robots.GrosRobot.AccelerationFinDeplacement;

            Depose();
            Robots.GrosRobot.Reculer(200);
            Fermer();
            Ranger();
            Robots.GrosRobot.PivotDroite(43);
            Robots.GrosRobot.AccelerationFinDeplacement = 300;
            Robots.GrosRobot.Avancer(100);
            Robots.GrosRobot.AccelerationFinDeplacement = accelTmp;
            Actionneur.BrasLunaire.Fermer();
        }
    }
}
