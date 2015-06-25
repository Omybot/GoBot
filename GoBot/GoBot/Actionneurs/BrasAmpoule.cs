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
        public bool PinceFermee { get; set; }

        public BrasAmpoule()
        {
            AmpouleChargee = false;
            PinceFermee = false;
        }

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
            PinceFermee = false;
        }

        public void Fermer()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.PinceAmpoule, Config.CurrentConfig.ServoAttrapageAmpoule.PositionFerme);
            PinceFermee = true;
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

        public void DescendrePosePied(int p)
        {
            if (p == 1)
            {
                Hauteur(Config.CurrentConfig.AscenseurAmpoule.PositionPoseSur1Pied);
            }
            if (p == 2)
            {
                Hauteur(Config.CurrentConfig.AscenseurAmpoule.PositionPoseSur2Pied);
            }
            if (p == 3)
            {
                Hauteur(Config.CurrentConfig.AscenseurAmpoule.PositionPoseSur3Pied);
            }
        }

        public bool AmpouleChargee { get; set; }
    }
}
