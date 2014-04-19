using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    abstract class ConnexionMiwi : Connexion
    {
        public Carte Carte { get; private set; }

        ConnexionMiwi(Carte carte)
        {
            Carte = carte;
        }

        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="message">Message à envoyer au client</param>
        /// <returns>Nombre de caractères envoyés</returns>
        public override int SendMessage(Trame message)
        {
            // Rajoute l'entête de demande de transfert de message par Miwi
            byte[] tab = new byte[message.Length + 2];
            byte[] tabOrig = message.ToTabBytes();

            for (int i = 0; i < tabOrig.Length; i++)
                tab[i + 2] = tabOrig[i];

            Trame messageComplet = new Trame(tab);

            int retour = Connexions.ConnexionMiwi.SendMessage(messageComplet);

            TrameEnvoyee(messageComplet);

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
            if (trame.Carte == Carte)
                TrameRecue(trame);
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
