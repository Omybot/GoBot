using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
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
            //PositionsApprocheFusee.Add(new Position(170, new PointReel(399, 1287)));
            //PositionsApprocheFusee.Add(new Position(-112, new PointReel(1289, 377)));
            //PositionsApprocheFusee.Add(new Position(180 +112, new PointReel(3000 - 1289, 377)));
            //PositionsApprocheFusee.Add(new Position(10, new PointReel(3000 - 399, 1287)));
            PositionsApprocheFusee.Add(new Position(170, new RealPoint(399, 1287)));
            PositionsApprocheFusee.Add(new Position(-90, new RealPoint(1150, 405)));
            PositionsApprocheFusee.Add(new Position(-90, new RealPoint(3000 - 1150, 405)));
            PositionsApprocheFusee.Add(new Position(10, new RealPoint(3000 - 399, 1287)));

            // TODO2017 bonnes valeurs
            PositionsApprocheModuleFace = new List<Position>();
            //PositionsApprocheModuleFace.Add(new Position(-127, new PointReel(420, 891)));
            //PositionsApprocheModuleFace.Add(new Position(170, new PointReel(859, 1036)));
            //PositionsApprocheModuleFace.Add(new Position(-296, new PointReel(640, 1522)));
            //PositionsApprocheModuleFace.Add(new Position(45, new PointReel(642, 1142)));
            //PositionsApprocheModuleFace.Add(null);
            //PositionsApprocheModuleFace.Add(new Position(-217, new PointReel(1289, 377)));

            //PositionsApprocheModuleFace.Add(new Position(180 + 217, new PointReel(3000 - 1289, 377)));
            //PositionsApprocheModuleFace.Add(null);
            //PositionsApprocheModuleFace.Add(new Position(180 - 45, new PointReel(3000 - 642, 1142)));
            //PositionsApprocheModuleFace.Add(new Position(180 + 296, new PointReel(3000 - 640, 1522)));
            //PositionsApprocheModuleFace.Add(new Position(180 - 170, new PointReel(3000 - 859, 1036)));
            //PositionsApprocheModuleFace.Add(new Position(180+127, new PointReel(3000-420, 891)));


            PositionsApprocheModuleFace.Add(new Position(-127, new RealPoint(420, 891)));
            PositionsApprocheModuleFace.Add(new Position(170, new RealPoint(860, 1036)));
            PositionsApprocheModuleFace.Add(new Position(-296, new RealPoint(640, 1522)));
            //PositionsApprocheModuleFace.Add(new Position(45, new PointReel(642, 1142)));
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(new Position(-217, new RealPoint(1289, 377)));

            PositionsApprocheModuleFace.Add(new Position(180 + 217, new RealPoint(3000 - 1289, 377)));
            PositionsApprocheModuleFace.Add(null);
            PositionsApprocheModuleFace.Add(null);
            //PositionsApprocheModuleFace.Add(new Position(180 - 45, new PointReel(3000 - 642, 1142)));
            PositionsApprocheModuleFace.Add(new Position(180 + 296, new RealPoint(3000 - 640, 1522)));
            PositionsApprocheModuleFace.Add(new Position(180 - 170, new RealPoint(3000 - 859, 1036)));
            PositionsApprocheModuleFace.Add(new Position(180 + 127, new RealPoint(3000 - 420, 891)));
            
            PositionsApprocheModuleGauche = new List<Position>();
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(new Position(135, new RealPoint(833, 1163)));
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(null);
            PositionsApprocheModuleGauche.Add(new Position(-230, new RealPoint(1886, 400))); // 30 1823 746
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
            PositionsApprocheModuleDroite.Add(new Position(310, new RealPoint(1113, 400))); // 210 1177 746
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(new Position(180 - 135, new RealPoint(3000 - 833, 1163)));
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);
            PositionsApprocheModuleDroite.Add(null);

            PositionsApprocheDepose = new List<Position>();
            PositionsApprocheDepose.Add(new Position(-135, new RealPoint(757, 1257))); // 80mm à reculer
            PositionsApprocheDepose.Add(new Position(-90, new RealPoint(1500, 940)));
            PositionsApprocheDepose.Add(new Position(-135+90, new RealPoint(3000 - 757, 1257)));
        }
    }
}
