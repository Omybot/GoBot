using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.ElementsJeu
{
    public class Tapis : ElementJeu
    {
        bool pose;
        public static int LARGEUR = 100;
        public static int LONGUEUR = 288;

        public bool Pose
        {
            get { return pose; }
            set { pose = value; }
        }

        public Tapis(PointReel position)
            : base(position, 80)
        {
            Pose = false;
            Hover = false;
        }
    }
}
