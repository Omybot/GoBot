using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace GoBot
{

    /// <summary>
    /// Permet de sauvegarder l'historique des trames reçue ainsi que leur heure d'arrivée
    /// </summary>
    [Serializable]
    public class EventsReplay
    {
        /// <summary>
        /// Liste des trames
        /// </summary>
        public List<HistoLigne> Events { get; private set; }

        public EventsReplay()
        {
            Events = new List<HistoLigne>();
        }

        /// <summary>
        /// Ajoute une trame reçue avec l'heure définie
        /// </summary>
        public void AjouterEvent(HistoLigne _event)
        {
            lock (Events)
                Events.Add(_event);
        }

        /// <summary>
        /// Charge une sauvegarde de Replay
        /// </summary>
        /// <param name="nomFichier">Chemin du fichier</param>
        /// <returns>Vrai si la sauvegarde a été correctement chargée</returns>
        public bool Charger(String nomFichier)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<HistoLigne>));
                using (FileStream myFileStream = new FileStream(nomFichier, FileMode.Open))
                    Events = (List<HistoLigne>)mySerializer.Deserialize(myFileStream);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sauvegarde l'ensemble des trames dans un fichier
        /// </summary>
        /// <param name="nomFichier">Chemin du fichier</param>
        /// <returns>Vrai si la sauvegarde s'est correctement déroulée</returns>
        public bool Sauvegarder(String nomFichier)
        {
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<HistoLigne>));
                using (StreamWriter myWriter = new StreamWriter(nomFichier))
                    mySerializer.Serialize(myWriter, Events);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Permet de simuler la réception des trames enregistrées en respectant les intervalles de temps entre chaque trame
        /// </summary>
        public void Rejouer()
        {
            for (int i = Events.Count - 1; i >= 0; i--)
            {
                Robots.DicRobots[Events[i].Robot].Historique.Log(Events[i].Message, Events[i].Type);

                if (i - 1 > 0)
                    Thread.Sleep(Events[i].Heure - Events[i - 1].Heure);
            }
        }

        public void Trier()
        {
            Events.Sort();
        }
    }
}