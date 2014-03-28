﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;

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
        public static bool Shutdown { get { return shutdown; } set { shutdown = value; } }
        private static bool shutdown = false;

        public static DateTime DateLancement { get; set; }
        public static String DateLancementString { get { return Config.DateLancement.Year.ToString("0000") + "." + Config.DateLancement.Month.ToString("00") + "." + Config.DateLancement.Day.ToString("00") + " " + Config.DateLancement.Hour.ToString("00") + "h" + Config.DateLancement.Minute.ToString("00") + "m" + Config.DateLancement.Second.ToString("00") + "s"; } }

        private static Config config = null;

        // Fenêtres gros robot

        public bool DeplacementGROuvert { get; set; }
        public bool HistoriqueGROuvert { get; set; }
        public bool ReglageGROuvert { get; set; }
        public bool UtilisationGROuvert { get; set; }
        public bool SequencesGROuvert { get; set; }
        public bool CapteursGROuvert { get; set; }

        // Fenêtres petit robot

        public bool DeplacementPROuvert { get; set; }
        public bool HistoriquePROuvert { get; set; }
        public bool ReglagePROuvert { get; set; }
        public bool UtilisationPROuvert { get; set; }

        // Déplacement gros robot

        public int GRVitesseLigneRapide { get; set; }
        public int GRAccelerationLigneRapide { get; set; }
        public int GRVitessePivotRapide { get; set; }
        public int GRAccelerationPivotRapide { get; set; }

        public int GRVitesseLigneLent { get; set; }
        public int GRAccelerationLigneLent { get; set; }
        public int GRVitessePivotLent { get; set; }
        public int GRAccelerationPivotLent { get; set; }

        public int GRCoeffP { get; set; }
        public int GRCoeffI { get; set; }
        public int GRCoeffD { get; set; }

        // Déplacement petit robot

        public int PRVitesseLigneRapide { get; set; }
        public int PRAccelerationLigneRapide { get; set; }
        public int PRVitessePivotRapide { get; set; }
        public int PRAccelerationPivotRapide { get; set; }

        public int PRVitesseLigneLent { get; set; }
        public int PRAccelerationLigneLent { get; set; }
        public int PRVitessePivotLent { get; set; }
        public int PRAccelerationPivotLent { get; set; }

        public int PRCoeffP { get; set; }
        public int PRCoeffI { get; set; }
        public int PRCoeffD { get; set; }

        // Offset balises

        public double OffsetBalise1Capteur1 { get; set; }
        public double OffsetBalise2Capteur1 { get; set; }
        public double OffsetBalise3Capteur1 { get; set; }

        public double OffsetBalise1Capteur2 { get; set; }
        public double OffsetBalise2Capteur2 { get; set; }
        public double OffsetBalise3Capteur2 { get; set; }

        // Position des servos du gros robot

        public int PositionGRPinceDroiteOuverte { get; set; }
        public int PositionGRPinceDroiteFermee { get; set; }

        public int PositionGRPinceGaucheOuverte { get; set; }
        public int PositionGRPinceGaucheFermee { get; set; }

        public int PositionGRCoudeRange { get; set; }

        public int PositionGREpauleRange { get; set; }

        // Positions bougies à la camera

        public int[] PositionsBougiesCameraX { get; set; }
        public int[] PositionsBougiesCameraY { get; set; }

        public double GetOffsetBalise(Carte carteBalise, int iCapteur)
        {
            if (iCapteur == 1)
            {
                switch (carteBalise)
                {
                    case Carte.RecBun:
                        return OffsetBalise1Capteur1;
                    case Carte.RecBeu:
                        return OffsetBalise2Capteur1;
                    case Carte.RecBoi:
                        return OffsetBalise3Capteur1;
                    default:
                        return 0;
                }
            }
            else if (iCapteur == 2)
            {
                switch (carteBalise)
                {
                    case Carte.RecBun:
                        return OffsetBalise1Capteur2;
                    case Carte.RecBeu:
                        return OffsetBalise2Capteur2;
                    case Carte.RecBoi:
                        return OffsetBalise3Capteur2;
                    default:
                        return 0;
                }
            }

            return 0;
        }

        public void SetOffsetBalise(Carte carteBalise, int iCapteur, double offset)
        {
            if (iCapteur == 1)
            {
                switch (carteBalise)
                {
                    case Carte.RecBun:
                        OffsetBalise1Capteur1 = offset;
                        break;
                    case Carte.RecBeu:
                        OffsetBalise2Capteur1 = offset;
                        break;
                    case Carte.RecBoi:
                        OffsetBalise3Capteur1 = offset;
                        break;
                }
            }
            else if (iCapteur == 2)
            {
                switch (carteBalise)
                {
                    case Carte.RecBun:
                        OffsetBalise1Capteur2 = offset;
                        break;
                    case Carte.RecBeu:
                        OffsetBalise2Capteur2 = offset;
                        break;
                    case Carte.RecBoi:
                        OffsetBalise3Capteur2 = offset;
                        break;
                }
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
                using (FileStream myFileStream = new FileStream(PathData + "/config.xml", FileMode.Open))
                    CurrentConfig = (Config)mySerializer.Deserialize(myFileStream);
            }
            catch (Exception)
            {
                MessageBox.Show("Aucune configuration chargée.");
            }
        }

        public static void Save()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Config));
            using (StreamWriter myWriter = new StreamWriter(PathData + "/config.xml"))
                mySerializer.Serialize(myWriter, CurrentConfig);
        }

        public static String PathData
        {
            get
            {
                return (String)Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("GoBot").GetValue("Path");
            }
        }
    }
}
