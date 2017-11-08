using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Geometry.Shapes;
using AStarFolder;
using System.Threading;

namespace GoBot.Enchainements
{
    class EnchainementAllerRetour : Enchainement
    {
        protected override void ThreadGros()
        {
            Robots.GrosRobot.SpeedConfig.SetParams(500, 2000, 2000, 800, 2000, 2000);

            Plateau.Balise.VitesseRotation(150);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                Robots.GrosRobot.Virage(SensAR.Avant, SensGD.Gauche, 232, 70);
            else
                Robots.GrosRobot.Virage(SensAR.Avant, SensGD.Droite, 232, 70);

            while (true)
            {
                Robots.GrosRobot.PathFinding(399, 1287, 170, 0, true);
                Robots.GrosRobot.PathFinding(3000-399, 1287, 10, 0, true);
            }
        }
    }
}
