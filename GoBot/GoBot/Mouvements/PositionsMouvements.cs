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
        public static List<Position> PositionsPieds { get; private set; }

        static PositionsMouvements()
        {
            // Créer les positions des actions de jeu

            int decallageFace = 110;
            int decallageLateral = 82;

            PointReel point = new PointReel(Plateau.Pieds[11].Position.X + decallageLateral, Plateau.Pieds[11].Position.Y + decallageFace);
            PositionsPieds = new List<Position>();

            point.Y += 70;
            PositionsPieds.Add(new Position(-90, new PointReel(point)));
            PositionsPieds.Add(new Position(-90, new PointReel(Plateau.Pieds[0].Position)));
            PositionsPieds.Add(new Position(-90, new PointReel(point)));
            PositionsPieds.Add(new Position(-90, new PointReel(Plateau.Pieds[0].Position)));
            PositionsPieds.Add(new Position(-90, new PointReel(point)));
            PositionsPieds.Add(new Position(-90, new PointReel(Plateau.Pieds[0].Position)));
            PositionsPieds.Add(new Position(-90, new PointReel(point)));
            PositionsPieds.Add(new Position(-90, new PointReel(Plateau.Pieds[0].Position)));
            PositionsPieds.Add(new Position(-90, new PointReel(point)));
            PositionsPieds.Add(new Position(-90, point));
            PositionsPieds.Add(new Position(-90, point));
            PositionsPieds.Add(new Position(-90, point));

            
            /*
            Pieds.Add(new Pied(new PointReel(90, 200), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(90, 1750), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(90, 1850), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(850, 100), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(850, 200), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(870, 1355), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(1100, 1770), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(1300, 1400), CouleurGaucheJaune));
            Pieds.Add(new Pied(new PointReel(1700, 1400), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(1900, 1770), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(2130, 1355), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(2150, 200), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(2150, 100), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(2910, 1850), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(2910, 1750), CouleurDroiteVert));
            Pieds.Add(new Pied(new PointReel(2910, 200), CouleurDroiteVert));*/
        }
    }
}
