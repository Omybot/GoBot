using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace UDP
{
    public class ReceptionUDP
    {
        private int portEntree;
        private String nom;
        bool stop = false;
        private int nbTrames;

        //Déclaration du délégué pour l’évènement réception de message
        public delegate void ReceptionDelegate(ReceptionUDP sender, Trame trame);
        //Déclaration de l’évènement utilisant le délégué
        public event ReceptionDelegate nouvelleTrame;

        public ReceptionUDP(String _nom, int _port)
        {
            portEntree = _port;
            nom = _nom;
            nbTrames = 0;
        }

        /// <summary>
        /// Lance la réception de trames sur le port actuel
        /// </summary>
        public void StartReception()
        {
            try
            {
                IPEndPoint e = new IPEndPoint(IPAddress.Any, portEntree);
                UdpClient u = new UdpClient(e);

                UdpState s = new UdpState();
                s.e = e;
                s.u = u;
                u.BeginReceive(new AsyncCallback(ReceptionCallback), s);
                stop = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible d'ouvrir ce port : " + ex.Message);
            }
        }

        private void ReceptionCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;

            IPEndPoint e = new IPEndPoint(IPAddress.Any, portEntree);

            Byte[] receiveBytes = u.EndReceive(ar, ref e);

            if (!stop)
            {
                Trame trameRecue = new Trame(receiveBytes);

                nbTrames++;
                nouvelleTrame(this, trameRecue);

                UdpState s = new UdpState();
                s.e = e;
                s.u = u;
                u.BeginReceive(ReceptionCallback, s);
            }
        }

        public void Close()
        {
            stop = true;
        }

        public String Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
            }
        }

        public int Port
        {
            get
            {
                return portEntree;
            }
            set
            {
                portEntree = value;
            }
        }

        public int CountSinceLast
        {
            get
            {
                int retour = nbTrames;
                nbTrames = 0;
                return retour;
            }
        }
    }
}