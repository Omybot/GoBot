using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace GoBot.Communications
{
    static class Connections
    {
        public static ConnexionUDP ConnectionMove { get; set; }
        public static ConnexionUDP ConnectionIO { get; set; }
        public static ConnexionUDP ConnectionGB { get; set; }

        /// <summary>
        /// Liste de toutes les connexions suivies par Connections
        /// </summary>
        public static List<Connexion> AllConnections { get; set; }
        
        /// <summary>
        /// Association de la connexion avec la carte
        /// </summary>
        public static Dictionary<Carte, Connexion> BoardConnection { get; private set; }

        /// <summary>
        /// Activation ou désactivation de la connexion
        /// </summary>
        public static Dictionary<Carte, bool> EnableConnection { get; private set; }

        /// <summary>
        /// Intervalle entre les vérifications de connexion
        /// </summary>
        private static int IntervalLoopTests = 500;

        /// <summary>
        /// Initialise toutes les connexions
        /// </summary>
        public static void Init()
        {
            EnableConnection = new Dictionary<Carte, bool>();
            BoardConnection = new Dictionary<Carte, Connexion>();
            AllConnections = new List<Connexion>();

            ConnectionIO = AddUDPConnection(Carte.RecIO, IPAddress.Parse("10.1.0.14"), 12324, 12314);
            ConnectionMove = AddUDPConnection(Carte.RecMove, IPAddress.Parse("10.1.0.11"), 12321, 12311);
            ConnectionGB = AddUDPConnection(Carte.RecGB, IPAddress.Parse("10.1.0.12"), 12322, 12312);

            ThreadPool.QueueUserWorkItem(f => TestConnectionsLoop()); // En remplacement des tests de connexion des ConnexionCheck, pour les syncroniser
        }

        /// <summary>
        /// Ajoute une connexion UDP aux connexions suivies
        /// </summary>
        /// <param name="board">Carte associée à la connexion</param>
        /// <param name="ip">Adresse IP de la connexion</param>
        /// <param name="inPort">Port d'entrée pour le PC</param>
        /// <param name="outPort">Port de sortie pour le PC</param>
        /// <returns>La connexion créée</returns>
        private static ConnexionUDP AddUDPConnection(Carte board, IPAddress ip, int inPort, int outPort)
        {
            ConnexionUDP output = new ConnexionUDP();
            output.Connexion(ip, inPort, outPort);
            BoardConnection.Add(board, output);
            EnableConnection.Add(board, true);
            AllConnections.Add(output);
            output.ConnexionCheck.SendConnectionTest += ConnexionCheck_SendConnectionTestUDP;

            return output;
        }

        /// <summary>
        /// Envoie un teste de connexion UDP à une connexion UDP
        /// </summary>
        /// <param name="sender">Connexion à laquelle envoyer le test</param>
        private static void ConnexionCheck_SendConnectionTestUDP(Connexion sender)
        {
            sender.SendMessage(TrameFactory.TestConnexion(GetBoardByConnection(sender)));
        }

        /// <summary>
        /// Boucle de tests de connexions pour maintenir les vérification à intervalle régulier
        /// </summary>
        private static void TestConnectionsLoop()
        {
            int interval = IntervalLoopTests / AllConnections.Count();
            
            while (!Config.Shutdown)
            {
                foreach (ConnexionUDP conn in AllConnections.OrderBy(c => Connections.GetBoardByConnection(c).ToString()))
                {
                    Console.WriteLine("Test " + Connections.GetBoardByConnection(conn).ToString());
                    conn.ConnexionCheck.CheckConnection();
                    Thread.Sleep(interval);
                }
            }
        }

        /// <summary>
        /// Retourne la carte concernée par une connexion
        /// </summary>
        /// <param name="conn">Connexion dont on veut la carte</param>
        /// <returns>La carte concernée par la connexion donnée</returns>
        public static Carte GetBoardByConnection(Connexion conn)
        {
            Carte output = Carte.RecMove;

            foreach (Carte c in Enum.GetValues(typeof(Carte)))
            {
                if (BoardConnection.ContainsKey(c) && BoardConnection[c] == conn)
                    output = c;
            }

            return output;
        }
    }
}
