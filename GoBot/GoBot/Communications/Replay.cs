using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.Communications
{
    /// <summary>
    /// Association d'une trame et de son heure de réception
    /// </summary>
    [Serializable]
    public class TrameReplay : IComparable
    {
        public String Trame { get; set; }
        public DateTime Date { get; set; }
        public bool Entrant { get; set; }

        public TrameReplay(Trame trame, DateTime date, bool entrant = true)
        {
            Trame = trame.ToString();
            Date = date;
            Entrant = entrant;
        }

        public TrameReplay()
        {
        }

        int IComparable.CompareTo(object obj)
        {
            return Date.CompareTo(((TrameReplay)obj).Date);
        }
    }

    /// <summary>
    /// Permet de sauvegarder l'historique des trames reçue ainsi que leur heure d'arrivée
    /// </summary>
    [Serializable]
    public class Replay
    {
        /// <summary>
        /// Liste des trames
        /// </summary>
        public List<TrameReplay> Trames { get; private set; }

        public Replay()
        {
            Trames = new List<TrameReplay>();
        }

        /// <summary>
        /// Ajoute une trame reçue avec l'heure actuelle
        /// </summary>
        /// <param name="trame">Trame à ajouter</param>
        public void AjouterTrameEntrante(Trame trame)
        {
            AjouterTrameEntrante(trame, DateTime.Now);
        }

        /// <summary>
        /// Ajoute une trame envoyée avec l'heure actuelle
        /// </summary>
        /// <param name="trame">Trame à ajouter</param>
        public void AjouterTrameSortante(Trame trame)
        {
            AjouterTrameSortante(trame, DateTime.Now);
        }

        /// <summary>
        /// Ajoute une trame reçue avec l'heure définie
        /// </summary>
        /// <param name="trame">Trame à ajouter</param>
        /// <param name="date">Heure de réception de la trame</param>
        public void AjouterTrameEntrante(Trame trame, DateTime date)
        {
            lock (Trames)
                Trames.Add(new TrameReplay(trame, date, true));
        }

        /// <summary>
        /// Ajoute une trame envoyée avec l'heure définie
        /// </summary>
        /// <param name="trame">Trame à ajouter</param>
        /// <param name="date">Heure de réception de la trame</param>
        public void AjouterTrameSortante(Trame trame, DateTime date)
        {
            lock (Trames)
                Trames.Add(new TrameReplay(trame, date, false));
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
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<TrameReplay>));
                using(FileStream myFileStream = new FileStream(nomFichier, FileMode.Open))
                    Trames = (List<TrameReplay>)mySerializer.Deserialize(myFileStream);

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
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<TrameReplay>));
                using(StreamWriter myWriter = new StreamWriter(nomFichier))
                    mySerializer.Serialize(myWriter, Trames);

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
            for (int i = 0; i < Trames.Count;i++)
            {
                Trame trame = new Trame(Trames[i].Trame);

                if (Trames[i].Entrant)
                    Connexions.ConnexionParCarte[trame.Carte].TrameRecue(trame);
                //else
                //    Connexions.ConnexionParCarte[trame.Carte].SendMessage(trame);

                if (i - 1 > 0)
                    Thread.Sleep(Trames[i].Date - Trames[i - 1].Date);
            }
        }

        public void Trier()
        {
            Trames.Sort();
        }
    }
}
