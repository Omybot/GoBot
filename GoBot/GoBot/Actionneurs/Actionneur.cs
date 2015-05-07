using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static BrasPiedsDroite brasPiedsDroite;
        private static BrasPiedsGauche brasPiedsGauche;
        private static BrasAmpoule brasAmpoule;
        private static BrasTapis brasTapis;

        static Actionneur()
        {
            brasPiedsDroite = new BrasPiedsDroite();
            brasPiedsGauche = new BrasPiedsGauche();
            brasAmpoule = new BrasAmpoule();
            brasTapis = new BrasTapis();
        }

        public static BrasPiedsDroite BrasPiedsDroite
        {
            get { return brasPiedsDroite; }
            set { brasPiedsDroite = value; }
        }

        public static BrasPiedsGauche BrasPiedsGauche
        {
            get { return brasPiedsGauche; }
            set { brasPiedsGauche = value; }
        }

        public static BrasAmpoule BrasAmpoule
        {
            get { return brasAmpoule; }
            set { brasAmpoule = value; }
        }

        public static BrasTapis BrasTapis
        {
            get { return brasTapis; }
            set { brasTapis = value; }
        }
    }
}
