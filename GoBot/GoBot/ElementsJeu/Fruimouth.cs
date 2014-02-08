using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.ElementsJeu
{
    public class Fruimouth : ElementJeu
    {
        public bool Pourri { get; set; }

        public Fruimouth(PointReel position, bool pourri)
            : base(position)
        {
            Pourri = pourri;
        }
    }
}
