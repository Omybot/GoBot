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
        public static Dictionary<int, Position> PositionPetitBougie { get; private set; }
        public static Dictionary<int, Position> PositionGrosBougie { get; private set; }
        public static Dictionary<int, Position> PositionPetitCadeau { get; private set; }
        public static Dictionary<int, Position> PositionGrosCadeau { get; private set; }
        public static List<PositionLancement> PositionTirCanon { get; private set; }

        static PositionsMouvements()
        {
            // Créer les positions des actions de jeu
        }
    }
}
