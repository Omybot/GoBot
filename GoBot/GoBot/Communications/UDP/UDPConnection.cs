﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace GoBot.Communications.UDP
{

    public class UDPConnection : Connection
    {
        private String _name;

        private class UdpState
        {
            public UdpClient Client { get; set; }
            public IPEndPoint EndPoint { get; set; }

            public UdpState(UdpClient client, IPEndPoint endPoint)
            {
                Client = client;
                EndPoint = endPoint;
            }
        }

        public override string Name { get => _name; set => _name = value; }

        public enum ConnectionState
        {
            Ok,
            Error
        }

        /// <summary>
        /// Adresse IP du client
        /// </summary>
        public IPAddress IPAddress { get; private set; }

        /// <summary>
        /// Port écouté par le PC pour la réception de messages
        /// </summary>
        public int InputPort { get; private set; }

        /// <summary>
        /// Port du client sur lequel envoyer les messages
        /// </summary>
        public int OutputPort { get; private set; }

        /// <summary>
        /// Client connecté
        /// </summary>
        private UdpClient Client { get; set; }

        IPEndPoint e;
        UdpClient u;

        public UDPConnection()
        {
            ConnectionChecker = new ConnectionChecker(this, 500);
        }

        /// <summary>
        /// Initialise la connexion vers le client pour l'envoi de données
        /// </summary>
        /// <param name="ipAddress">Adresse Ip du client</param>
        /// <param name="inputPort">Port à écouter</param>
        /// <param name="outputPort">Port sur lequel envoyer les messages</param>
        /// <returns>Etat de la connexion</returns>
        public ConnectionState Connect(IPAddress ipAddress, int inputPort, int outputPort)
        {
            ConnectionState state = ConnectionState.Error;

            IPAddress = ipAddress;
            OutputPort = outputPort;
            InputPort = inputPort;

            lock (this)
            {
                try
                {
                    Client = new UdpClient();
                    Client.Connect(IPAddress, OutputPort);
                    Connected = true;
                    state = ConnectionState.Ok;
                }
                catch (Exception)
                {
                    Connected = false;
                }
            }

            return state;
        }

        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="frame">Message à envoyer au client</param>
        /// <returns>Nombre de caractères envoyés</returns>
        public override bool SendMessage(Frame frame)
        {
            bool ok = false;

            //if (Connections.EnableConnection[frame.Board])
            {
                try
                {
                    if (!Connected)
                        if (Connect(IPAddress, OutputPort, InputPort) != ConnectionState.Ok)
                            return false;

                    byte[] envoi = frame.ToBytes();

                    ok = Client.Send(envoi, envoi.Length) > 0;
                    OnFrameSend(frame);
                }
                catch (SocketException)
                {
                    Connected = false;
                    ok = false;
                }
            }

            return ok;
        }

        /// <summary>
        /// Lance la réception de trames sur le port actuel
        /// </summary>
        public override void StartReception()
        {
            e = new IPEndPoint(IPAddress.Any, InputPort);
            if (u != null)
                u.Close();
            u = new UdpClient(e);

            u.BeginReceive(new AsyncCallback(ReceptionCallback), new UdpState(u, e));
        }

        /// <summary>
        /// Libère la connexion vers le client
        /// </summary>
        public override void Close()
        {
            Client.Close();
        }

        /// <summary>
        /// Callback appelée par la disponibilité d'une trame
        /// </summary>
        /// <param name="ar"></param>
        private void ReceptionCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient u = ((UdpState)(ar.AsyncState)).Client;
                IPEndPoint e = new IPEndPoint(IPAddress.Any, InputPort);
                Byte[] receiveBytes = u.EndReceive(ar, ref e);
                Frame trameRecue = new Frame(receiveBytes);

                ConnectionChecker.NotifyAlive();

                try
                {
                    OnFrameReceived(trameRecue);
                }
                catch (Exception e1)
                {
                    if (Debugger.IsAttached) MessageBox.Show("Trame reçue buguée : " + trameRecue.ToString() + Environment.NewLine + e1.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                u.BeginReceive(ReceptionCallback, new UdpState(u, e));
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR UDP : " + e.ToString());
            }
        }
    }
}