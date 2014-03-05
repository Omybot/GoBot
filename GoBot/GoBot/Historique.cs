using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actions;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace GoBot
{
    [Serializable]
    public enum TypeLog
    {
        Action,
        Strat,
        PathFinding
    }
        
    [Serializable]
    public class HistoLigne : IComparable
    {
        public String Message { get; set; }
        public DateTime Heure { get; set; }
        public TypeLog Type {get;set;}
        public IDRobot Robot { get; set; }

        public HistoLigne(IDRobot robot, DateTime heure, String message, TypeLog type = TypeLog.Strat)
        {
            Robot = robot;
            Message = message;
            Heure = heure;
            Type = type;
        }

        public HistoLigne()
        {
        }

        public int CompareTo(object obj)
        {
            return Heure.CompareTo(((HistoLigne)obj).Heure);
        }
    }

    public class Historique
    {
        int NBACTIONSMAX = 10;
        public IDRobot Robot { get; private set; }
        private List<IAction> actions;
        public List<IAction> Actions
        {
            get
            {
                return actions;
            }
        }

        public delegate void DelegateAction(IAction action);
        public event DelegateAction NouvelleAction;
        public delegate void DelegateLog(HistoLigne ligne);
        public event DelegateLog NouveauLog;

        public Historique(IDRobot robot)
        {
            Robot = robot;
            actions = new List<IAction>();
            HistoriqueLignes = new List<HistoLigne>();
        }

        public void AjouterAction(IAction action)
        {
            Actions.Add(action);
            Log(action.ToString(), TypeLog.Action);

            while (Actions.Count > NBACTIONSMAX)
                Actions.RemoveAt(0);

            if (NouvelleAction != null)
                NouvelleAction(action);
        }

        public void Log(String message, TypeLog type = TypeLog.Strat)
        {
            HistoLigne ligne = new HistoLigne(Robot, DateTime.Now, message, type);
            HistoriqueLignes.Add(ligne);
            if (NouveauLog != null)
                NouveauLog(ligne);

            Console.WriteLine(ligne.Message);
        }

        public List<HistoLigne> HistoriqueLignes { get; set; }

        /// <summary>
        /// Charge une sauvegarde d'historique
        /// </summary>
        /// <param name="nomFichier">Chemin du fichier</param>
        /// <returns>Vrai si la sauvegarde a été correctement chargée</returns>
        public bool Charger(String nomFichier)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<HistoLigne>));
                using (FileStream myFileStream = new FileStream(nomFichier, FileMode.Open))
                    HistoriqueLignes = (List<HistoLigne>)mySerializer.Deserialize(myFileStream);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sauvegarde l'ensemble de l'historique dans un fichier
        /// </summary>
        /// <param name="nomFichier">Chemin du fichier</param>
        /// <returns>Vrai si la sauvegarde s'est correctement déroulée</returns>
        public bool Sauvegarder(String nomFichier)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<HistoLigne>));
                using (StreamWriter myWriter = new StreamWriter(nomFichier))
                    mySerializer.Serialize(myWriter, HistoriqueLignes);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
