using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace UDP
{
    public class EmissionUDP
    {
        private UdpClient client;
        private IPAddress adresseIp;
        private int portSortie;
        private bool connecte = false;

        /// <summary>
        /// Initialise la connexion vers le client pour lenvoi de données
        /// </summary>
        /// <param name="_adresseIP">Adresse Ip du client</param>
        /// <param name="_portSortie">Port  de destination du message</param>
        /// <returns>Etat de la connexion</returns>
        public Etat Connexion(IPAddress _adresseIp, int _portSortie)
        {
            Etat retour = Etat.Ok;

            adresseIp = _adresseIp;
            portSortie = _portSortie;

            try
            {
                client = new UdpClient();
                client.Connect(adresseIp, portSortie);
                connecte = true;
            }
            catch (Exception)
            {
                retour = Etat.Erreur;
                connecte = false;
            }

            return retour;
        }

        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="message">Message à envoyer au client</param>
        /// <returns>Etat de réussite</returns>
        public Etat SendMessage(Trame message)
        {
            if (!connecte)
            {
                Connexion(adresseIp, portSortie);
                if (!connecte)
                    return Etat.Erreur;
            }
            try
            {
                byte[] envoi = message.ToTabBytes();

                int retour = client.Send(envoi, envoi.Length);

                if (retour == message.Length)
                    return Etat.Ok;
            }
            catch(Exception)
            {}

            return Etat.Erreur;
        }

        /// <summary>
        /// Libère la connexion vers le client
        /// </summary>
        public void Close()
        {
            client.Close();
        }
    }
}
