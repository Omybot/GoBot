using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.Mouvements
{
    public class PositionLancement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Angle { get; set; }
        public int PuissanceTir { get; set; }
        public Color Couleur { get; set; }
    }

    static class PositionsMouvements
    {
        public static Dictionary<int, Position> PositionGrosFeuxBordure { get; private set; }
        public static Dictionary<int, Position> PositionArbres { get; private set; }
        public static Dictionary<int, Position> PositionGrosTorches { get; private set; }
        public static Dictionary<int, List<Position>> PositionTorche { get; private set; }
        public static Dictionary<int, Position> PositionFoyersCoins { get; private set; }
        public static Dictionary<int, Position> PositionsLances { get; private set; }
        public static List<Position> PositionsFresque { get; private set; }
        public static List<Position> PositionsFilet { get; private set; }
        public static List<Position> PositionsMammouths { get; private set; }
        public static List<Position> PositionsFoyerCentral { get; private set; }

        static PositionsMouvements()
        {
            // Créer les positions des actions de jeu
            PositionGrosFeuxBordure = new Dictionary<int, Position>();
            PositionGrosFeuxBordure.Add(15, new Position(new Angle(0), new PointReel(3000 - 175 - Robots.GrosRobot.Longueur / 2, 800)));
            PositionGrosFeuxBordure.Add(8, new Position(new Angle(90), new PointReel(1700, 2000 - 175 - Robots.GrosRobot.Longueur / 2)));
            PositionGrosFeuxBordure.Add(7, new Position(new Angle(90), new PointReel(1300, 2000 - 175 - Robots.GrosRobot.Longueur / 2)));
            PositionGrosFeuxBordure.Add(0, new Position(new Angle(180), new PointReel(175 + Robots.GrosRobot.Longueur / 2, 800)));

            PositionTorche = new Dictionary<int, List<Position>>();
            PositionTorche.Add(0, new List<Position>());
            PositionTorche[0].Add(new Position(90, new PointReel(900, 864)));
            PositionTorche[0].Add(new Position(-90, new PointReel(900, 1336)));
            PositionTorche[0].Add(new Position(0, new PointReel(664, 1100)));

            PositionTorche.Add(1, new List<Position>());
            PositionTorche[1].Add(new Position(90, new PointReel(2100, 864)));
            PositionTorche[1].Add(new Position(-90, new PointReel(2100, 1336)));
            PositionTorche[1].Add(new Position(180, new PointReel(2336, 1100)));

            PositionArbres = new Dictionary<int, Position>();
            //PositionArbres.Add(0, new Position(-90, new PointReel(700, 1500)));
            PositionArbres.Add(0, new Position(-16.66, new PointReel(439, 1167)));
            //PositionArbres.Add(1, new Position(-60, new PointReel(995, 1489))); // 60° 19sec
            //PositionArbres.Add(1, new Position(-90, new PointReel(700, 1500)));
            //PositionArbres.Add(1, new Position(-90, new PointReel(692, 1527))); // 30sec
            PositionArbres.Add(1, new Position(-43, new PointReel(1041, 1682)));
            //PositionArbres.Add(2, new Position(-137, new PointReel(1959, 1674)));
            PositionArbres.Add(2, new Position(-106.66, new PointReel(2167, 1561)));
           // PositionArbres.Add(3, new Position(-60, new PointReel(995, 1489)));
            PositionArbres.Add(3, new Position(43.34, new PointReel(2665, 987)));

            PositionFoyersCoins = new Dictionary<int, Position>();
            PositionFoyersCoins.Add(0, new Position(139, new PointReel(327, 1693)));
            PositionFoyersCoins.Add(1, new Position(41, new PointReel(2673, 1693)));

            PositionsLances = new Dictionary<int, Position>();
            PositionsLances.Add(1, new Position(-90, new PointReel(720, 400)));
            PositionsLances.Add(2, new Position(-90, new PointReel(3000 - 720, 400)));

            PositionsFresque = new List<Position>();
            PositionsFresque.Add(new Position(90, new PointReel(1250, 234)));
            PositionsFresque.Add(new Position(90, new PointReel(1750, 234)));

            PositionsFilet = new List<Position>();
            PositionsFilet.Add(new Position(-125 + 180, new PointReel(2600, 600)));
            PositionsFilet.Add(new Position(-70 + 180, new PointReel(1900, 600)));
            PositionsFilet.Add(new Position(-125 + 180, new PointReel(1100, 600)));
            PositionsFilet.Add(new Position(-70 + 180, new PointReel(400, 600)));

            PositionsMammouths = new List<Position>();
            PositionsMammouths.Add(new Position(0, new PointReel(850, 0)));
            PositionsMammouths.Add(new Position(0, new PointReel(2150, 0)));

            PositionsFoyerCentral = new List<Position>();
            //PositionsFoyerCentral.Add(new Position(0, new PointReel(1500 - 200 - Robots.GrosRobot.Longueur / 2, 1050)));
            //PositionsFoyerCentral.Add(new Position(180, new PointReel(1500 + 200 + Robots.GrosRobot.Longueur / 2, 1050)));
            PositionsFoyerCentral.Add(new Position(-90, new PointReel(1500, 1050 + 300 + Robots.GrosRobot.Longueur / 2)));
            PositionsFoyerCentral.Add(new Position(90, new PointReel(1500, 1050 - 300 - Robots.GrosRobot.Longueur / 2)));
        }
    }
}
