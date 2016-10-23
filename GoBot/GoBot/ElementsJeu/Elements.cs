using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.ElementsJeu
{
    public class Elements
    {
        public Elements()
        {
            ZoneDeposeViolet1 = new ZoneInteret(new PointReel(1300, 1050), Plateau.CouleurGaucheViolet, 90);
            ZoneDeposeViolet2 = new ZoneInteret(new PointReel(1300, 1050), Plateau.CouleurGaucheViolet, 90);
            ZoneDeposeVert1 = new ZoneInteret(new PointReel(3000 - 1300, 1050), Plateau.CouleurDroiteVert, 90);
            ZoneDeposeVert2 = new ZoneInteret(new PointReel(3000 - 1300, 1050), Plateau.CouleurDroiteVert, 90);
            ZoneCubeGauche = new ZoneInteret(new PointReel(902, 80), Color.White, 90);
            ZoneCubeDroite = new ZoneInteret(new PointReel(3000 - 902, 80), Color.White, 90);
            ZoneDune1 = new ZoneInteret(new PointReel(1500, 160), Color.White, 200);
            ZoneDune2 = new ZoneInteret(new PointReel(1500, 40), Color.White, 200);
            ZoneDune3 = new ZoneInteret(new PointReel(1500 + 58 * 3, 40), Color.White, 200);
            ZoneDune4 = new ZoneInteret(new PointReel(1538 - 58 * 3, 40), Color.White, 200);
        }

        public ZoneInteret ZoneDeposeViolet1 { get; protected set; }
        public ZoneInteret ZoneDeposeViolet2 { get; protected set; }
        public ZoneInteret ZoneDeposeVert1 { get; protected set; }
        public ZoneInteret ZoneDeposeVert2 { get; protected set; }
        public ZoneInteret ZoneCubeGauche { get; protected set; }
        public ZoneInteret ZoneCubeDroite { get; protected set; }
        public ZoneInteret ZoneDune1 { get; protected set; }
        public ZoneInteret ZoneDune2 { get; protected set; }
        public ZoneInteret ZoneDune3 { get; protected set; }
        public ZoneInteret ZoneDune4 { get; protected set; }
    }
}
