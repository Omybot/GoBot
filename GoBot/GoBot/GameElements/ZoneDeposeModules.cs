using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.ElementsJeu
{
    public class ZoneDeposeModules : GameElementZone
    {
        int numero;

        public ZoneDeposeModules(int num, RealPoint pos, Color col, int ray) : base(pos, col, ray)
        {
            numero = num;
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

        public override bool ClickAction()
        {
            return new Mouvements.MouvementDeposeModules(numero).Executer();
        }
    }
}
