using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GoBot
{
    [Serializable]
    public class Config
    {        
        /// <summary>
        /// Permet de savoir si l'application est mode Design (concepteur graphique) ou en cours d'execution
        /// Le DesignMode de base :
        ///     - Ne fonctionne pas dans les contructeurs
        ///     - Ne fonctionne pas pour les contrôles imbriqués
        /// </summary>
        public static bool DesignMode { get { return designMode; } set { designMode = value; } }
        private static bool designMode = true;

        private static Config config = null;

        // Fenêtres gros robot

        public bool DeplacementGROuvert { get; set; }
        public bool HistoriqueGROuvert { get; set; }
        public bool ReglageGROuvert { get; set; }
        public bool UtilGROuvert { get; set; }

        // Fenêtres petit robot

        public bool DeplacementPROuvert { get; set; }
        public bool HistoriquePROuvert { get; set; }

        // Déplacement gros robot

        public int GRVitesseLigne { get; set; }
        public int GRAccelerationLigne { get; set; }
        public int GRVitessePivot { get; set; }
        public int GRAccelerationPivot { get; set; }

        // Déplacement petit robot

        public int PRVitesseLigne { get; set; }
        public int PRAccelerationLigne { get; set; }
        public int PRVitessePivot { get; set; }
        public int PRAccelerationPivot { get; set; }

        // Offset balises

        public double OffsetBalise1Haut { get; set; }
        public double OffsetBalise2Haut { get; set; }
        public double OffsetBalise3Haut { get; set; }

        public double OffsetBalise1Bas { get; set; }
        public double OffsetBalise2Bas { get; set; }
        public double OffsetBalise3Bas { get; set; }

        // Positions bougies à la camera

        public int[] PositionsBougiesX { get; set; }
        public int[] PositionsBougiesY { get; set; }

        public double GetOffsetBaliseHaut(Carte carteBalise)
        {
            switch (carteBalise)
            {
                case Carte.RecBun:
                    return OffsetBalise1Haut;
                case Carte.RecBeu:
                    return OffsetBalise2Haut;
                case Carte.RecBoi:
                    return OffsetBalise3Haut;
                default:
                    return 0;
            }
        }

        public void SetOffsetBaliseHaut(Carte carteBalise, double offset)
        {
            switch (carteBalise)
            {
                case Carte.RecBun:
                    OffsetBalise1Haut = offset;
                    break;
                case Carte.RecBeu:
                    OffsetBalise2Haut = offset;
                    break;
                case Carte.RecBoi:
                    OffsetBalise3Haut = offset;
                    break;
            }
        }

        public double GetOffsetBaliseBas(Carte carteBalise)
        {
            switch (carteBalise)
            {
                case Carte.RecBun:
                    return OffsetBalise1Bas;
                case Carte.RecBeu:
                    return OffsetBalise2Bas;
                case Carte.RecBoi:
                    return OffsetBalise3Bas;
                default:
                    return 0;
            }
        }

        public void SetOffsetBaliseBas(Carte carteBalise, double offset)
        {
            switch (carteBalise)
            {
                case Carte.RecBun:
                    OffsetBalise1Bas = offset;
                    break;
                case Carte.RecBeu:
                    OffsetBalise2Bas = offset;
                    break;
                case Carte.RecBoi:
                    OffsetBalise3Bas = offset;
                    break;
            }
        }

        public static Config CurrentConfig
        {
            get
            {
                if (config == null)
                    config = new Config();

                return config;
            }
            set
            {
                config = value;
            }
        }

        public static void Load()
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Config));
                FileStream myFileStream = new FileStream("config.xml", FileMode.Open);
                CurrentConfig = (Config)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Aucune configuration chargée.");
            }
        }

        public static void Save()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Config));
            StreamWriter myWriter = new StreamWriter("config.xml");
            mySerializer.Serialize(myWriter, CurrentConfig);
            myWriter.Close();
        }
    }
}
