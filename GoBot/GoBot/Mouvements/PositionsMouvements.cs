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
        public static Dictionary<int, Position> PositionGrosFoyers { get; private set; }

        static PositionsMouvements()
        {
            // Créer les positions des actions de jeu
            PositionGrosFeuxBordure = new Dictionary<int, Position>();
            PositionGrosFeuxBordure.Add(0, new Position(new Angle(0), new PointReel(3000 - 175, 800)));
            PositionGrosFeuxBordure.Add(1, new Position(new Angle(90), new PointReel(1700, 2000 - 175)));
            PositionGrosFeuxBordure.Add(2, new Position(new Angle(90), new PointReel(1300, 2000 - 175)));
            PositionGrosFeuxBordure.Add(3, new Position(new Angle(180), new PointReel(175, 800)));
        }
    }
}
