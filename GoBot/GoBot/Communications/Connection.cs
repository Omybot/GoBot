﻿namespace GoBot.Communications
{
    public abstract class Connection
    {
        /// <summary>
        /// Sauvegarde des trames transitées par la connexion
        /// </summary>
        public ConnectionReplay Archives { get; protected set; }

        /// <summary>
        /// Verificateur de connexion
        /// </summary>
        public ConnectionChecker ConnectionChecker { get; set; }
        
        /// <summary>
        /// Envoi le message au client actuellement connecté
        /// </summary>
        /// <param name="message">Message à envoyer au client</param>
        /// <returns>Nombre de caractères envoyés</returns>
        abstract public int SendMessage(Frame message);

        //Déclaration du délégué pour l’évènement réception ou émission de message
        public delegate void NewFrameDelegate(Frame frame);
        //Déclaration de l’évènement utilisant le délégué pour la réception d'une trame
        public event NewFrameDelegate FrameReceived;
        //Déclaration de l’évènement utilisant le délégué pour l'émission d'une trame
        public event NewFrameDelegate FrameSend;

        /// <summary>
        /// Lance la réception de trames sur la configuration actuelle
        /// </summary>
        abstract public void StartReception();

        /// <summary>
        /// Libère la connexion vers le client
        /// </summary>
        abstract public void Close();

        /// <summary>
        /// Ajoute une trame reçue
        /// </summary>
        /// <param name="frame">Trame reçue</param>
        public void OnFrameReceived(Frame frame)
        {
            Archives.AddFrame(frame, true);

            FrameReceived?.Invoke(frame);
        }

        /// <summary>
        /// Ajoute une trame envoyée
        /// </summary>
        /// <param name="frame">Trame envoyée</param>
        public void OnFrameSend(Frame frame)
        {
            Archives.AddFrame(frame, false);

            FrameSend?.Invoke(frame);
        }
    }
}
