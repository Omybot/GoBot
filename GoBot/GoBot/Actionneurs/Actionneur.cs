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
        private static Hokuyo hokuyo;
        private static BrasLunaire brasLunaire;
        private static Convoyeur convoyeur;
        private static Stockeur stockeur;
        private static Ejecteur ejecteur;
        private static BrasLunaireDroite brasLunaireDroite;
        private static BrasLunaireGauche brasLunaireGauche;


        static Actionneur()
        {
            brasLunaire = new BrasLunaire();
            hokuyo = CreateHokuyo("COM3", LidarID.ScanSol);
            convoyeur = new Convoyeur();
            stockeur = new Stockeur();
            ejecteur = new Ejecteur();
            brasLunaireDroite = new BrasLunaireDroite();
            brasLunaireGauche = new BrasLunaireGauche();
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

        public static BrasLunaire BrasLunaire
        {
            get { return brasLunaire; }
            set { brasLunaire = value; }
        }

        public static Ejecteur Ejecteur
        {
            get { return ejecteur; }
            set { ejecteur = value; }
        }

        public static Convoyeur Convoyeur
        {
            get { return convoyeur; }
            set { convoyeur = value; }
        }

        public static Stockeur Stockeur
        {
            get { return stockeur; }
            set { stockeur = value; }
        }

        public static BrasLunaireDroite BrasLunaireDroite
        {
            get { return Actionneur.brasLunaireDroite; }
            set { Actionneur.brasLunaireDroite = value; }
        }

        public static BrasLunaireGauche BrasLunaireGauche
        {
            get { return Actionneur.brasLunaireGauche; }
            set { Actionneur.brasLunaireGauche = value; }
        }
    }
}
