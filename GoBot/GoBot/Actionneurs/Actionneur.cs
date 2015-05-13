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
        private static BrasAspirateur brasAspirateur;

        static Actionneur()
        {
            brasPiedsDroite = new BrasPiedsDroite();
            brasPiedsGauche = new BrasPiedsGauche();
            brasAmpoule = new BrasAmpoule();
            brasTapis = new BrasTapis();
            brasAspirateur = new BrasAspirateur();
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

        public static BrasAspirateur BrasAspirateur
        {
            get { return brasAspirateur; }
            set { brasAspirateur = value; }
        }

        public static BrasPieds BrasSpot
        {
            get
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                    return BrasPiedsDroite;
                else
                    return BrasPiedsGauche;
            }
        }

        public static BrasPieds BrasGobelet
        {
            get
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                    return BrasPiedsGauche;
                else
                    return BrasPiedsDroite;
            }
        }
    }
}
