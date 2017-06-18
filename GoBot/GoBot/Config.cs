﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using GoBot.Communications;
using System.Drawing;
using GoBot.Actionneurs;
using System.Reflection;

namespace GoBot
{
    [Serializable]
    public partial class Config
    {

        private static Config config = null;

        public static List<Positionnable> Positionnables { get; set; }

        public static void ChargerPositionnables()
        {
            Positionnables = new List<Positionnable>();
            PropertyInfo[] proprietes = typeof(Config).GetProperties();
            foreach (PropertyInfo p in proprietes)
            {
                if (p.PropertyType.IsSubclassOf(typeof(Positionnable)))
                {
                    if (p.GetValue(Config.CurrentConfig, null) == null)
                        p.SetValue(Config.CurrentConfig, Activator.CreateInstance(p.PropertyType), null);

                    Positionnables.Add((Positionnable)(p.GetValue(Config.CurrentConfig, null)));
                }
            }
        }

        public static string PropertyNameToScreen(PropertyInfo property)
        {
            String typeName = property.Name;
            String nom = "";

            foreach (char c in typeName)
            {
                char ch = c;
                if (c <= 'Z' && c>= 'A')
                    nom += " " + (char)(c + 32);
                else
                    nom += c;
            }

            nom = typeName.Substring(0, 1) + nom.Substring(2);

            return nom;
        }

        public int AfficheDetailTraj { get; set; }

        // Batteries

        public double BatterieRobotVert { get; set; } // 23
        public double BatterieRobotOrange { get; set; } // 22
        public double BatterieRobotRouge { get; set; } // 21
        public double BatterieRobotCritique { get; set; } // 3

        // Zone camera

        public int CameraXMin { get; set; }
        public int CameraXMax { get; set; }
        public int CameraYMin { get; set; }
        public int CameraYMax { get; set; }

        // Fenêtres gros robot

        public bool DeplacementGROuvert { get; set; }
        public bool HistoriqueGROuvert { get; set; }
        public bool ReglageGROuvert { get; set; }
        public bool UtilisationGROuvert { get; set; }
        public bool SequencesGROuvert { get; set; }
        public bool CapteursGROuvert { get; set; }

        // Déplacement gros robot
        
        public SpeedConfig ConfigRapide { get; set; }
        public SpeedConfig ConfigLent { get; set; }

        public int GRCoeffP { get; set; }
        public int GRCoeffI { get; set; }
        public int GRCoeffD { get; set; }

        // Offset balises

        public double OffsetBaliseCapteur1 { get; set; }
        public double OffsetBaliseCapteur2 { get; set; }

        // Parametres logs UDP

        public SerializableDictionary<FrameFunction, bool> LogsFonctionsBalise { get; set; }
        public SerializableDictionary<FrameFunction, bool> LogsFonctionsIO { get; set; }
        public SerializableDictionary<FrameFunction, bool> LogsFonctionsMove { get; set; }
        public SerializableDictionary<FrameFunction, bool> LogsFonctionsGB { get; set; }        
        
        public SerializableDictionary<Board, bool> LogsExpediteurs { get; set; }
        public SerializableDictionary<Board, bool> LogsDestinataires { get; set; }

        public double GetOffsetBalise(int iCapteur)
        {
            if (iCapteur == 1)
            {
                return OffsetBaliseCapteur1;
            }
            else if (iCapteur == 2)
            {
                return OffsetBaliseCapteur2;
            }

            return 0;
        }

        public void SetOffsetBalise(int iCapteur, double offset)
        {
            if (iCapteur == 1)
            {
                OffsetBaliseCapteur1 = offset;
            }
            else if (iCapteur == 2)
            {
                OffsetBaliseCapteur2 = offset;
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

                ChargerPositionnables();
                CurrentConfig.AfficheDetailTraj = 0;
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
            using (StreamWriter myWriter = new StreamWriter(PathData + "/Configs/config" + Execution.DateLancementString + ".xml"))
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
