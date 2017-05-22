using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.Mouvements
{
    static class PositionsMouvements
    {
        public static List<Position> PositionsApprocheFusee { get; private set; }

        public static List<Position> PositionsApprocheModuleFace { get; private set; }
        public static List<Position> PositionsApprocheModuleGauche { get; private set; }
        public static List<Position> PositionsApprocheModuleDroite { get; private set; }

        public static List<Position> PositionsApprocheDepose { get; private set; }

        static PositionsMouvements()
        {
            // Créer les positions des actions de jeu

            PositionsApprocheFusee = new List<Position>();
            PositionsApprocheFusee.Add(new Position(120, new PointReel(370, 1200)));
            PositionsApprocheFusee.Add(new Position(-90, new PointReel(1140, 300)));
            PositionsApprocheFusee.Add(new Position(-90, new PointReel(3000-1140, 300)));
            PositionsApprocheFusee.Add(new Position(60, new PointReel(3000-370, 1200)));

            // TODO2017 bonnes valeurs
            PositionsApprocheModuleFace = new List<Position>();
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);

            PositionsApprocheModuleGauche = new List<Position>();
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);

            PositionsApprocheModuleDroite = new List<Position>();
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);

            // TODO2017 bonnes valeurs
            PositionsApprocheDepose = new List<Position>();
            PositionsApprocheDepose.Add(new Position(60, new PointReel(720, 1200)));
            PositionsApprocheDepose.Add(new Position(60, new PointReel(1500, 950)));
            PositionsApprocheDepose.Add(new Position(60, new PointReel(3000 - 720, 1200)));
        }
    }
}
