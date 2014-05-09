using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Communications
{
    public abstract class Connexion
    {
        /// <summary>
        /// Sauvegarde les trames transitées par la connexion
        /// </summary>
        public Replay Sauvegarde { get; protected set; }

        /// <summary>
        /// Verificateur de connexion
        /// </summary>
        public ConnexionCheck ConnexionCheck { get; set; }

        /// <summary>
        /// Sémaphore bloquant pour l'attente de réception d'acquittement
        /// </summary>
        public Semaphore SemaphoreAck { get; set; }

        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="message">Message à envoyer au client</param>
        /// <param name="bloquant">Vrai si la fonction doit être bloquante en attente d'un acquittement</param>
        /// <returns>Nombre de caractères envoyés</returns>
        abstract public int SendMessage(Trame message, bool bloquant = false);

        //Déclaration du délégué pour l’évènement réception de message
        public delegate void ReceptionDelegate(Trame trame);
        //Déclaration de l’évènement utilisant le délégué pour la réception d'une trame
        public event ReceptionDelegate NouvelleTrameRecue;
        //Déclaration de l’évènement utilisant le délégué pour l'émission d'une trame
        public event ReceptionDelegate NouvelleTrameEnvoyee;

        /// <summary>
        /// Lance la réception de trames sur la configuration actuelle
        /// </summary>
        abstract public void StartReception();

        /// <summary>
        /// Libère la connexion vers le client
        /// </summary>
        abstract public void Close();

        public void TrameRecue(Trame t)
        {
            Sauvegarde.AjouterTrameEntrante(t);

            if (NouvelleTrameRecue != null)
                NouvelleTrameRecue(t);
        }

        public void TrameEnvoyee(Trame t)
        {
            Sauvegarde.AjouterTrameSortante(t);

            if (NouvelleTrameEnvoyee != null)
                NouvelleTrameEnvoyee(t);
        }
    }
}
