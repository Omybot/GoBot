using GoBot.Communications.CAN;
using GoBot.Communications.UDP;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace GoBot.Communications
{
    static class Connections
    {
        private static ThreadLink _linkTestConnections;

        public static UDPConnection ConnectionMove { get; set; }
        public static UDPConnection ConnectionIO { get; set; }
        public static UDPConnection ConnectionGB { get; set; }
        public static UDPConnection ConnectionCanBridge { get; set; }

        public static CanConnection ConnectionCan { get; set; }

        /// <summary>
        /// Liste de toutes les connexions suivies par Connections
        /// </summary>
        public static List<Connection> AllConnections { get; set; }

        /// <summary>
        /// Association de la connexion avec la carte
        /// </summary>
        public static Dictionary<Board, Connection> BoardConnection { get; private set; }

        /// <summary>
        /// Activation ou désactivation de la connexion
        /// </summary>
        public static Dictionary<Board, bool> EnableConnection { get; private set; }

        /// <summary>
        /// Intervalle entre les vérifications de connexion
        /// </summary>
        private static int IntervalLoopTests = 500;

        /// <summary>
        /// Initialise toutes les connexions
        /// </summary>
        public static void Init()
        {
            EnableConnection = new Dictionary<Board, bool>();
            BoardConnection = new Dictionary<Board, Connection>();
            AllConnections = new List<Connection>();

            ConnectionIO = AddUDPConnection(Board.RecIO, IPAddress.Parse("10.1.0.14"), 12324, 12314);
            ConnectionMove = AddUDPConnection(Board.RecMove, IPAddress.Parse("10.1.0.11"), 12321, 12311);
            ConnectionGB = AddUDPConnection(Board.RecGB, IPAddress.Parse("10.1.0.12"), 12322, 12312);
            ConnectionCanBridge = AddUDPConnection(Board.RecCan, IPAddress.Parse("10.1.0.15"), 12325, 12315);

            ConnectionCan = new CanConnection(Board.RecCan);
            ConnectionCan.StartReception();

            // En remplacement des tests de connexion des ConnexionCheck, pour les syncroniser
            _linkTestConnections = ThreadManager.CreateThread(link => TestConnections());
            _linkTestConnections.StartInfiniteLoop(new TimeSpan(0, 0, 1));
        }

        /// <summary>
        /// Ajoute une connexion UDP aux connexions suivies
        /// </summary>
        /// <param name="board">Carte associée à la connexion</param>
        /// <param name="ip">Adresse IP de la connexion</param>
        /// <param name="inPort">Port d'entrée pour le PC</param>
        /// <param name="outPort">Port de sortie pour le PC</param>
        /// <returns>La connexion créée</returns>
        private static UDPConnection AddUDPConnection(Board board, IPAddress ip, int inPort, int outPort)
        {
            UDPConnection output = new UDPConnection();
            output.Connect(ip, inPort, outPort);
            BoardConnection.Add(board, output);
            EnableConnection.Add(board, true);
            AllConnections.Add(output);
            output.ConnectionChecker.SendConnectionTest += ConnexionCheck_SendConnectionTestUDP;

            return output;
        }

        /// <summary>
        /// Envoie un teste de connexion UDP à une connexion UDP
        /// </summary>
        /// <param name="sender">Connexion à laquelle envoyer le test</param>
        private static void ConnexionCheck_SendConnectionTestUDP(Connection sender)
        {
            sender.SendMessage(UdpFrameFactory.TestConnexion(GetBoardByConnection(sender)));
        }

        /// <summary>
        /// Boucle de tests de connexions pour maintenir les vérification à intervalle régulier
        /// </summary>
        private static void TestConnections()
        {
            _linkTestConnections.RegisterName();

            int interval = IntervalLoopTests / AllConnections.Count();

            foreach (UDPConnection conn in AllConnections.OrderBy(c => Connections.GetBoardByConnection(c).ToString()))
            {
                if (!_linkTestConnections.Cancelled)
                {
                    conn.ConnectionChecker.CheckConnection();
                    Thread.Sleep(interval);
                }
            }
        }

        /// <summary>
        /// Retourne la carte concernée par une connexion
        /// </summary>
        /// <param name="conn">Connexion dont on veut la carte</param>
        /// <returns>La carte concernée par la connexion donnée</returns>
        public static Board GetBoardByConnection(Connection conn)
        {
            Board output = Board.RecMove;

            foreach (Board c in Enum.GetValues(typeof(Board)))
            {
                if (BoardConnection.ContainsKey(c) && BoardConnection[c] == conn)
                    output = c;
            }

            return output;
        }
    }
}
