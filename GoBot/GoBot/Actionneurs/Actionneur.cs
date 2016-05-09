using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static PinceBasAvant pinceBas;
        private static BarreDePompes barrePompes;
        private static BrasDroite brasDroite;
        private static BrasGauche brasGauche;
        private static PinceBasLateralGauche pinceBasLateralGauche;
        private static PinceBasLateralDroite pinceBasLateralDroite;
        private static PinceVerrou pinceVerrou;
        private static MaintienDune maintienDune;
        private static Hokuyo hokuyo;

        static Actionneur()
        {
            pinceBas = new PinceBasAvant();
            barrePompes = new BarreDePompes();
            brasDroite = new BrasDroite();
            brasGauche = new BrasGauche();
            pinceBasLateralGauche = new PinceBasLateralGauche();
            pinceBasLateralDroite = new PinceBasLateralDroite();
            pinceVerrou = new PinceVerrou();
            maintienDune = new MaintienDune();
            hokuyo = CreateHokuyo("COM3", LidarID.LidarSol);
        }

        public static Hokuyo CreateHokuyo(String portCom, LidarID id)
        {
            bool forceUart = false;
            bool forceUsb = false;

            if (forceUart)
                return new HokuyoUart(id);
            else if (forceUsb)
                return new HokuyoUsb(portCom, id);

            Hokuyo hok;

            try
            {
                hok = new HokuyoUsb(portCom, id);
                return hok;
            }
            catch (Exception)
            {
                hok = new HokuyoUart(id);
                return hok;
            }
        }

        public static Hokuyo Hokuyo
        {
            get { return hokuyo; }
            set { hokuyo = value; }
        }

        public static MaintienDune MaintienDune
        {
            get { return maintienDune; }
            set { maintienDune = value; }
        }

        public static PinceVerrou PinceVerrou
        {
            get { return pinceVerrou; }
            set { pinceVerrou = value; }
        }

        public static PinceBasLateralGauche PinceBasLateralGauche
        {
            get { return pinceBasLateralGauche; }
            set { pinceBasLateralGauche = value; }
        }

        public static PinceBasLateralDroite PinceBasLateralDroite
        {
            get { return pinceBasLateralDroite; }
            set { pinceBasLateralDroite = value; }
        }

        public static PinceBasAvant PinceBas
        {
            get { return pinceBas; }
            set { pinceBas = value; }
        }

        public static BarreDePompes BarreDePompes
        {
            get { return barrePompes; }
            set { barrePompes = value; }
        }

        public static BrasDroite BrasDroite
        {
            get { return brasDroite; }
            set { brasDroite = value; }
        }

        public static BrasGauche BrasGauche
        {
            get { return brasGauche; }
            set { brasGauche = value; }
        }
    }
}
