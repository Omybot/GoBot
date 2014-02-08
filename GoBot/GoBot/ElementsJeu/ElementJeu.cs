using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.ElementsJeu
{
    public class ElementJeu
    {
        public PointReel Position { get; set; }

        public ElementJeu(PointReel position)
        {
            Position = position;
        }
    }
}
