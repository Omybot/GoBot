using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    public static class BrasPiedsDroite
    {
        public static void FermerPince()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDroitePinceDroite, Config.CurrentConfig.PositionGRDroitePinceDroiteFerme);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGauchePinceDroite, Config.CurrentConfig.PositionGRGauchePinceDroiteFerme);
        }

        public static void OuvrirPince()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDroitePinceDroite, Config.CurrentConfig.PositionGRDroitePinceDroiteFerme);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGauchePinceDroite, Config.CurrentConfig.PositionGRGauchePinceDroiteFerme);
        }

        public static void MonterBras()
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.GRAscenseurDroite, Config.CurrentConfig.PositionGRHautPinceDroite);
        }

        public static void DescendreBras()
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.GRAscenseurDroite, Config.CurrentConfig.PositionGRBasPinceDroite);
        }

        public static void Empiler()
        {
            OuvrirPince();
            DescendreBras();
            Thread.Sleep(500);
            FermerPince();
            Thread.Sleep(500);
            MonterBras();
        }
    }
}
