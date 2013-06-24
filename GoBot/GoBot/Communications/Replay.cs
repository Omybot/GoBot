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
    public class TrameReplay
    {
        public String Trame { get; set; }
        public DateTime Date { get; set; }

        public TrameReplay(Trame trame, DateTime date)
        {
            Trame = trame.ToString();
            Date = date;
        }

        public TrameReplay()
        {
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
        private List<TrameReplay> tramesEntrantes;

        public Replay()
        {
            tramesEntrantes = new List<TrameReplay>();
        }

        /// <summary>
        /// Ajoute une trame avec l'heure actuelle
        /// </summary>
        /// <param name="trame">Trame à ajouter</param>
        public void AjouterTrameEntrante(Trame trame)
        {
            AjouterTrameEntrante(trame, DateTime.Now);
        }

        /// <summary>
        /// Ajoute une trame avec l'heure définie
        /// </summary>
        /// <param name="trame">Trame à ajouter</param>
        /// <param name="date">Heure de réception de la trame</param>
        public void AjouterTrameEntrante(Trame trame, DateTime date)
        {
            tramesEntrantes.Add(new TrameReplay(trame, date));
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
                    tramesEntrantes = (List<TrameReplay>)mySerializer.Deserialize(myFileStream);

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
                    mySerializer.Serialize(myWriter, tramesEntrantes);

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
            ReceptionTrame += new ReceptionTrameDelegate(Connexions.ConnexionMiwi.TrameRecue);

            for (int i = tramesEntrantes.Count - 1; i > 0; i--)
            {
                ReceptionTrame(new Trame(tramesEntrantes[i].Trame));
                if (i - 1 > 0)
                    Thread.Sleep(tramesEntrantes[i].Date - tramesEntrantes[i - 1].Date);
            }
        }

        public delegate void ReceptionTrameDelegate(Trame t);
        public event ReceptionTrameDelegate ReceptionTrame;
    }
}
