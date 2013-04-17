using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using GoBot;

namespace UDP
{
    public class UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
    }

    public enum Etat
    {
        Ok,
        Erreur
    }

    public class ConnexionUDP
    {
        private IPAddress adresseIp;
        private int portEntree;
        private int portSortie;
        private UdpClient client;
        private bool isConnect = false;
        public ConnexionCheck ConnexionCheck { get; set; }

        public ConnexionUDP()
        {
            ConnexionCheck = new ConnexionCheck(2000);
        }

        /// <summary>
        /// Initialise la connexion vers le client pour l'envoi de données
        /// </summary>
        /// <param name="_adresseIP">Adresse Ip du client</param>
        /// <param name="_portSortie">Port  de destination du message</param>
        /// <returns>Etat de la connexion</returns>
        public Etat Connexion(IPAddress _adresseIP, int _portSortie, int _portEntree)
        {
            Etat retour = Etat.Ok;

            adresseIp = _adresseIP;
            portSortie = _portSortie;
            portEntree = _portEntree;
            
            try
            {
                client = new UdpClient();
                client.Connect(adresseIp, portSortie);
                isConnect = true;

                StartReception();
            }
            catch(Exception)
            {
                retour = Etat.Erreur;
                isConnect = false;
            }

            return retour;
        }

        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="message">Message à envoyer au client</param>
        /// <returns>Nombre de caractères envoyés</returns>
        public int SendMessage(Trame message)
        {
            if (!isConnect)
                if (Connexion(adresseIp, portSortie, portEntree) != Etat.Ok)
                    return -1;

            byte[] envoi = message.ToTabBytes();
            
            int retour = client.Send(envoi, envoi.Length);
            return retour;
        }


        //Déclaration du délégué pour l’évènement réception de message
        public delegate void ReceptionDelegate(Trame trame);
        //Déclaration de l’évènement utilisant le délégué
        public event ReceptionDelegate NouvelleTrame;
        

        /// <summary>
        /// Lance la réception de trames sur le port actuel
        /// </summary>
        public void StartReception()
        {
            IPEndPoint e = new IPEndPoint(IPAddress.Any, portEntree);
            UdpClient u = new UdpClient(e);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;
            u.BeginReceive(new AsyncCallback(ReceptionCallback), s);
        }

        /// <summary>
        /// Libère la connexion vers le client
        /// </summary>
        public void Close()
        {
            client.Close();
        }

        private void ReceptionCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;

            IPEndPoint e = new IPEndPoint(IPAddress.Any, portEntree);

            Byte[] receiveBytes = u.EndReceive(ar, ref e);

            ConnexionCheck.MajConnexion();

            Trame trameRecue = new Trame(receiveBytes);
            TrameRecue(trameRecue);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;
            u.BeginReceive(ReceptionCallback, s);
        }

        public void TrameRecue(Trame t)
        {
            NouvelleTrame(t);
        }
    }
}