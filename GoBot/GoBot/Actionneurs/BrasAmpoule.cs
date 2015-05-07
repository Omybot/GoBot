using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class BrasAmpoule
    {
        public void Monter()
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurAmpoule, 13000);
        }

        public void Descendre()
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurAmpoule, 700);
        }

        public void Ouvrir()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.PinceAmpoule, 585);
        }

        public void OuvrirAttrapage()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.PinceAmpoule, 500);
        }

        public void Fermer()
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.PinceAmpoule, 253);
        }

        public void Hauteur(int hauteur)
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.AscenseurAmpoule, hauteur);
        }

        public void AscenseurCalibration()
        {
            // TODO
        }
    }
}
