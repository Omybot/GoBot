using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    static class PositionsMouvements
    {
        public static Dictionary<int, Position> PositionPetitBougie { get; private set; }
        public static Dictionary<int, Position> PositionGrosBougie { get; private set; }
        public static Dictionary<int, Position> PositionPetitCadeau { get; private set; }
        public static Dictionary<int, Position> PositionGrosCadeau { get; private set; }

        static PositionsMouvements()
        {
            PositionPetitBougie = new Dictionary<int, Position>();
            PositionPetitBougie.Add(1, new Position(new Angle(-253), new PointReel(2132, 122)));
            PositionPetitBougie.Add(3, new Position(new Angle(-247.5), new PointReel(2097, 247)));
            PositionPetitBougie.Add(5, new Position(new Angle(-232.5), new PointReel(2013, 394)));
            PositionPetitBougie.Add(6, new Position(new Angle(-217.5), new PointReel(1894, 513)));
            PositionPetitBougie.Add(7, new Position(new Angle(-202.5), new PointReel(1747, 597)));
            PositionPetitBougie.Add(9, new Position(new Angle(-187.5), new PointReel(1584, 641)));
            PositionPetitBougie.Add(19, new Position(new Angle(-172.5), new PointReel(1416, 641)));
            PositionPetitBougie.Add(17, new Position(new Angle(-157.5), new PointReel(1253, 597)));
            PositionPetitBougie.Add(16, new Position(new Angle(-142.5), new PointReel(1106, 513)));
            PositionPetitBougie.Add(15, new Position(new Angle(-127.5), new PointReel(987, 394)));
            PositionPetitBougie.Add(13, new Position(new Angle(-112.5), new PointReel(903, 247)));
            PositionPetitBougie.Add(11, new Position(new Angle(-106.6), new PointReel(868, 122)));

            PositionGrosBougie = new Dictionary<int, Position>();
            PositionGrosBougie.Add(0, new Position(new Angle(116.14), new PointReel(2126, 231)));
            PositionGrosBougie.Add(1, new Position(new Angle(137.24), new PointReel(2116, 259)));
            PositionGrosBougie.Add(2, new Position(new Angle(127.65), new PointReel(2029, 405)));
            PositionGrosBougie.Add(3, new Position(new Angle(117.34), new PointReel(2110, 296)));
            PositionGrosBougie.Add(4, new Position(new Angle(142.94), new PointReel(1874, 568)));
            PositionGrosBougie.Add(5, new Position(new Angle(131.85), new PointReel(2014, 438)));
            PositionGrosBougie.Add(6, new Position(new Angle(140.73), new PointReel(1901, 542)));
            PositionGrosBougie.Add(7, new Position(new Angle(157.11), new PointReel(1733, 606)));
            PositionGrosBougie.Add(8, new Position(new Angle(161.41), new PointReel(1650, 656)));
            PositionGrosBougie.Add(9, new Position(new Angle(173.95), new PointReel(1564, 643)));
            PositionGrosBougie.Add(10, new Position(new Angle(-110.49), new PointReel(851, 155)));
            PositionGrosBougie.Add(11, new Position(new Angle(-125.47), new PointReel(795, 188)));
            PositionGrosBougie.Add(12, new Position(new Angle(-121.66), new PointReel(925, 340)));
            PositionGrosBougie.Add(13, new Position(new Angle(-116.72), new PointReel(879, 242)));
            PositionGrosBougie.Add(14, new Position(new Angle(-142.42), new PointReel(1092, 533)));
            PositionGrosBougie.Add(15, new Position(new Angle(-125.78), new PointReel(945, 375)));
            PositionGrosBougie.Add(16, new Position(new Angle(-139.53), new PointReel(1059, 501)));
            PositionGrosBougie.Add(17, new Position(new Angle(-153.4), new PointReel(1206, 593)));
            PositionGrosBougie.Add(18, new Position(new Angle(-164.2), new PointReel(1321, 640)));
            PositionGrosBougie.Add(19, new Position(new Angle(-168.73), new PointReel(1381, 642)));
            
            /*PositionGrosBougie.Add(0, new Position(new Angle(-249.12), new PointReel(2157, 188)));
            PositionGrosBougie.Add(1, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(2, new Position(new Angle(-226.44), new PointReel(2037, 421)));
            PositionGrosBougie.Add(3, new Position(new Angle(-241.59), new PointReel(2128, 266)));
            PositionGrosBougie.Add(4, new Position(new Angle(-203.84), new PointReel(1834, 595)));
            PositionGrosBougie.Add(5, new Position(new Angle(-226.44), new PointReel(2037, 421)));
            PositionGrosBougie.Add(6, new Position(new Angle(-211.30), new PointReel(1908, 547)));
            PositionGrosBougie.Add(7, new Position(new Angle(-196.1), new PointReel(1751, 634)));
            PositionGrosBougie.Add(8, new Position(new Angle(-181.02), new PointReel(1599, 678)));
            PositionGrosBougie.Add(9, new Position(new Angle(-181.02), new PointReel(1599, 678)));
            PositionGrosBougie.Add(10, new Position(new Angle(-110.88), new PointReel(863, 188)));
            PositionGrosBougie.Add(11, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(12, new Position(new Angle(-112.59), new PointReel(898, 331)));
            PositionGrosBougie.Add(13, new Position(new Angle(-105.59), new PointReel(863, 245)));
            PositionGrosBougie.Add(14, new Position(new Angle(-141.9), new PointReel(1071, 531)));
            PositionGrosBougie.Add(15, new Position(new Angle(-120.59), new PointReel(948, 401)));
            PositionGrosBougie.Add(16, new Position(new Angle(-141.9), new PointReel(1071, 531)));
            PositionGrosBougie.Add(17, new Position(new Angle(-150.73), new PointReel(1224, 624)));
            PositionGrosBougie.Add(18, new Position(new Angle(-158.33), new PointReel(1309, 655)));
            PositionGrosBougie.Add(19, new Position(new Angle(-165.87), new PointReel(1397, 675)));*/

            PositionPetitCadeau = new Dictionary<int, Position>();
            for (int i = 0; i < 8; i++)
                PositionPetitCadeau.Add(i, new Position(new Angle(0), new PointReel(Plateau.PositionsCadeaux[i].X, Plateau.PositionsCadeaux[i].Y - 141)));

            PositionGrosCadeau = new Dictionary<int, Position>();
            for (int i = 1; i < 7; i++)
                PositionGrosCadeau.Add(i, new Position(new Angle(0), new PointReel(Plateau.PositionsCadeaux[i].X, Plateau.PositionsCadeaux[i].Y - 200)));
                    
            PositionGrosCadeau.Add(0, new Position(new Angle(15), new PointReel(Plateau.PositionsCadeaux[0].X + 35, Plateau.PositionsCadeaux[0].Y - 200)));
            PositionGrosCadeau.Add(7, new Position(new Angle(-15), new PointReel(Plateau.PositionsCadeaux[7].X - 35, Plateau.PositionsCadeaux[7].Y - 200)));
        }
    }
}
