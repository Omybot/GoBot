using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;
using System.Threading;

namespace GoBot.Actionneurs
{
    class BrasAmpoule
    {
        public void Monter()
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurAmpoule, Config.CurrentConfig.AscenseurAmpoule.PositionHaute);
        }

        public void Descendre()
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurAmpoule, Config.CurrentConfig.AscenseurAmpoule.PositionAttrapage);
        }

        public void Ouvrir()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.PinceAmpoule, Config.CurrentConfig.ServoAttrapageAmpoule.PositionOuvert);
        }

        public void Fermer()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.PinceAmpoule, Config.CurrentConfig.ServoAttrapageAmpoule.PositionFerme);
        }

        public void Hauteur(int hauteur)
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurAmpoule, hauteur);
        }

        public void AscenseurCalibration()
        {
            Fermer();
            Thread.Sleep(200);
            Monter();
            Thread.Sleep(200);

            Connexions.ConnexionIO.SendMessage(TrameFactory.CalibrationAscenseurAmpoule());
        }
    }
}
