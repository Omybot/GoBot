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
            PositionGrosBougie.Add(0, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(1, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(2, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(3, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(4, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(5, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(6, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(7, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(8, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(9, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(10, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(11, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(12, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(13, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(14, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(15, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(16, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(17, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(18, new Position(new Angle(0), new PointReel(0, 0)));
            PositionGrosBougie.Add(19, new Position(new Angle(0), new PointReel(0, 0)));

            PositionPetitCadeau = new Dictionary<int, Position>();
            for (int i = 0; i < 8; i++)
                PositionPetitCadeau.Add(i, new Position(new Angle(0), new PointReel(Plateau.PositionsCadeaux[i].X, Plateau.PositionsCadeaux[i].Y - 141)));

            PositionGrosCadeau = new Dictionary<int, Position>();
            for (int i = 0; i < 8; i++)
                PositionGrosCadeau.Add(i, new Position(new Angle(0), new PointReel(Plateau.PositionsCadeaux[i].X, Plateau.PositionsCadeaux[i].Y - 200)));
        }
    }
}
