using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Communications
{
    public class ConnexionMiwi : Connexion
    {
        public Carte Carte { get; private set; }

        public ConnexionMiwi(Carte carte)
        {
            ConnexionCheck = new ConnexionCheck(2000);
            Carte = carte;
            Sauvegarde = new Replay();
            SemaphoreAck = new Semaphore(0, int.MaxValue);
        }

        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="message">Message à envoyer au client</param>
        /// <param name="bloquant">Vrai si la fonction doit être bloquante en attente d'un acquittement</param>
        /// <returns>Nombre de caractères envoyés</returns>
        public override int SendMessage(Trame message, bool bloquant = false)
        {
            // Rajoute l'entête de demande de transfert de message par Miwi
            byte[] tab = new byte[message.Length + 3];
            byte[] tabOrig = message.ToTabBytes();

            tab[0] = (byte)Carte.RecMiwi;
            tab[1] = (byte)FonctionMiwi.Transmettre;
            tab[2] = (byte)(bloquant ? 1 : 0);

            for (int i = 0; i < tabOrig.Length; i++)
                tab[i + 3] = tabOrig[i];

            Trame messageComplet = new Trame(tab);

            // Initialisation sémaphore ack
            if(bloquant)
                SemaphoreAck = new Semaphore(0, int.MaxValue);

            int retour = Connexions.ConnexionMiwi.SendMessage(messageComplet);

            TrameEnvoyee(messageComplet);

            // Attente acquittement
            if (bloquant)
                SemaphoreAck.WaitOne();

            return retour;
        }

        /// <summary>
        /// Lance la réception de trames sur la configuration actuelle
        /// </summary>
        public override void StartReception()
        {
            Connexions.ConnexionMiwi.NouvelleTrameRecue += ConnexionMiwi_NouvelleTrameRecue;
        }

        void ConnexionMiwi_NouvelleTrameRecue(Trame trame)
        {
            try
            {
                if(trame[1] == (byte)FonctionMiwi.Acquittement)
                    SemaphoreAck.Release();
                else if (trame.Carte == Carte)
                {
                    ConnexionCheck.MajConnexion();
                    TrameRecue(trame);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Libère la connexion vers le client
        /// </summary>
        public override void Close()
        {
            Connexions.ConnexionMiwi.NouvelleTrameRecue -= ConnexionMiwi_NouvelleTrameRecue;
        }
    }
}
