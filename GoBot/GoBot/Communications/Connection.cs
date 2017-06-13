namespace GoBot.Communications
{
    public abstract class Connection
    {
        /// <summary>
        /// Sauvegarde les trames transitées par la connexion
        /// </summary>
        public Replay Save { get; protected set; }

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

        //Déclaration du délégué pour l’évènement réception de message
        public delegate void ReceptionDelegate(Frame frame);
        //Déclaration de l’évènement utilisant le délégué pour la réception d'une trame
        public event ReceptionDelegate FrameReceived;
        //Déclaration de l’évènement utilisant le délégué pour l'émission d'une trame
        public event ReceptionDelegate FrameSend;

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
            Save.AjouterTrameEntrante(frame);

            FrameReceived?.Invoke(frame);
        }

        /// <summary>
        /// Ajoute une trame envoyée
        /// </summary>
        /// <param name="frame">Trame envoyée</param>
        public void OnFrameSend(Frame frame)
        {
            Save.AjouterTrameSortante(frame);

            FrameSend?.Invoke(frame);
        }
    }
}
