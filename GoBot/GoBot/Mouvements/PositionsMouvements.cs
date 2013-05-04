﻿using System;
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
            PositionGrosBougie.Add(0, new Position(new Angle(109.23), new PointReel(2146, 209)));
            //PositionGrosBougie.Add(0, new Position(new Angle(-162.13), new PointReel(1765, 790)));
            PositionGrosBougie.Add(1, new Position(new Angle(118.71), new PointReel(2194, 229)));
            PositionGrosBougie.Add(2, new Position(new Angle(125.82), new PointReel(2014 ,433)));
            PositionGrosBougie.Add(3, new Position(new Angle(112.67), new PointReel(2117, 284)));
            PositionGrosBougie.Add(4, new Position(new Angle(132.54), new PointReel(1883, 584)));
            PositionGrosBougie.Add(5, new Position(new Angle(125.12), new PointReel(2030, 430)));
            PositionGrosBougie.Add(6, new Position(new Angle(142.44), new PointReel(1891, 557)));
            PositionGrosBougie.Add(7, new Position(new Angle(157.53), new PointReel(1739, 639)));
            PositionGrosBougie.Add(8, new Position(new Angle(171.3), new PointReel(1597, 672)));
            PositionGrosBougie.Add(9, new Position(new Angle(174.92), new PointReel(1569, 675)));
            PositionGrosBougie.Add(10, new Position(new Angle(-116.17), new PointReel(862, 193)));
            PositionGrosBougie.Add(11, new Position(new Angle(-124.89), new PointReel(806, 205)));
            PositionGrosBougie.Add(12, new Position(new Angle(-118.69), new PointReel(922, 335)));
            PositionGrosBougie.Add(13, new Position(new Angle(-113.2), new PointReel(881, 251)));
            PositionGrosBougie.Add(14, new Position(new Angle(-145.91), new PointReel(1110, 548)));
            PositionGrosBougie.Add(15, new Position(new Angle(-124.56), new PointReel(959, 392)));
            PositionGrosBougie.Add(16, new Position(new Angle(-138.23), new PointReel(1072, 518)));
            PositionGrosBougie.Add(17, new Position(new Angle(-155.65), new PointReel(1227, 617)));
            PositionGrosBougie.Add(18, new Position(new Angle(-166.29), new PointReel(1339, 656)));
            PositionGrosBougie.Add(19, new Position(new Angle(-170.55), new PointReel(1395, 667)));
            
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
