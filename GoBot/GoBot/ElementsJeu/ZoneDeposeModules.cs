using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.ElementsJeu
{
    public class ZoneDeposeModules : ZoneInteret
    {
        public ZoneDeposeModules(PointReel pos, Color col, int ray) : base(pos, col, ray)
        {

        }

        public int ModulesPlaces { get; set; }

        public int PlacesLibres
        {
            get
            {
                return 6 - ModulesPlaces;
            }
        }

        //public override void Paint(Graphics g, PaintScale scale)
        //{
        //    // TODO2017 dessiner les modules posés
        //}
    }
}
