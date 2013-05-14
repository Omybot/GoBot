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

        // Déplacement petit robot

        public int PRVitesseLigneRapide { get; set; }
        public int PRAccelerationLigneRapide { get; set; }
        public int PRVitessePivotRapide { get; set; }
        public int PRAccelerationPivotRapide { get; set; }

        public int PRVitesseLigneLent { get; set; }
        public int PRAccelerationLigneLent { get; set; }
        public int PRVitessePivotLent { get; set; }
        public int PRAccelerationPivotLent { get; set; }

        // Offset balises

        public double OffsetBalise1Capteur1 { get; set; }
        public double OffsetBalise2Capteur1 { get; set; }
        public double OffsetBalise3Capteur1 { get; set; }

        public double OffsetBalise1Capteur2 { get; set; }
        public double OffsetBalise2Capteur2 { get; set; }
        public double OffsetBalise3Capteur2 { get; set; }

        // Positions bras gros robot

        public int PositionGRGrandBrasHaut { get; set; }
        public int PositionGRGrandBrasBas { get; set; }
        public int PositionGRGrandBrasRange { get; set; }

        public int PositionGRPetitBrasHaut { get; set; }
        public int PositionGRPetitBrasBas { get; set; }
        public int PositionGRPetitBrasRange { get; set; }

        // Positions aspirateur

        public int PositionGRAspirateurHaut { get; set; }
        public int PositionGRAspirateurBas { get; set; }

        // Positions débloqueur

        public int PositionGRDebloqueurHaut { get; set; }
        public int PositionGRDebloqueurBas { get; set; }

        // Positions camera

        public int PositionGRCameraBleu { get; set; }
        public int PositionGRCameraRouge { get; set; }

        // Positions bloqueur

        public int PositionGRBloqueurOuvert { get; set; }
        public int PositionGRBloqueurFerme { get; set; }

        // Positions bras latéraux

        public int PositionGRBrasGaucheSorti { get; set; }
        public int PositionGRBrasGaucheRange { get; set; }

        public int PositionGRBrasDroitSorti { get; set; }
        public int PositionGRBrasDroitRange { get; set; }

        // Vitesses rotation

        public int VitesseAspiration { get; set; }
        public int VitesseAspirationMaintien { get; set; }
        public int VitessePropulsionBonne { get; set; }

        // Positions bras petit robot

        public int PositionPRBrasGaucheHaut { get; set; }
        public int PositionPRBrasGaucheBas { get; set; }
        public int PositionPRBrasGaucheRange { get; set; }

        public int PositionPRBrasDroiteHaut { get; set; }
        public int PositionPRBrasDroiteBas { get; set; }
        public int PositionPRBrasDroiteRange { get; set; }

        public int PositionPRBrasAvantHaut { get; set; }
        public int PositionPRBrasAvantBas { get; set; }
        public int PositionPRBrasAvantRange { get; set; }
        public int PositionPRBrasAvantAssiette { get; set; }

        public int PositionPRBrasArriereHaut { get; set; }
        public int PositionPRBrasArriereBas { get; set; }
        public int PositionPRBrasArriereRange { get; set; }
        public int PositionPRBrasArriereAssiette { get; set; }

        public int PositionPRBrasAvantGaucheHaut { get; set; }
        public int PositionPRBrasAvantGaucheBas { get; set; }

        public int PositionPRBrasAvantDroitHaut { get; set; }
        public int PositionPRBrasAvantDroitBas { get; set; }

        public int PositionPRBrasArriereGaucheHaut { get; set; }
        public int PositionPRBrasArriereGaucheBas { get; set; }

        public int PositionPRBrasArriereDroitHaut { get; set; }
        public int PositionPRBrasArriereDroitBas { get; set; }

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
                FileStream myFileStream = new FileStream("config.xml", FileMode.Open);
                CurrentConfig = (Config)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                myFileStream.Dispose();
            }
            catch (Exception)
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
            myWriter.Dispose();
        }
    }
}
