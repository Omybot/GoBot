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

        private static Dictionary<CanBoard, CanSubConnection> _connectionCanServo;

        public static UDPConnection ConnectionMove { get; set; }
        public static UDPConnection ConnectionIO { get; set; }
        public static UDPConnection ConnectionCanBridge { get; set; }
        public static Dictionary<CanBoard, CanSubConnection> ConnectionsCanServo { get { return _connectionCanServo; } }

        public static CanConnection ConnectionCan { get; set; }

        /// <summary>
        /// Liste de toutes les connexions suivies par Connections
        /// </summary>
        public static List<Connection> AllConnections { get; set; }

        /// <summary>
        /// Association de la connexion avec la carte UDP
        /// </summary>
        public static Dictionary<Board, Connection> UDPBoardConnection { get; private set; }

        /// <summary>
        /// Activation ou désactivation de la connexion
        /// </summary>
        public static Dictionary<Board, bool> EnableConnection { get; private set; }

        /// <summary>
        /// Intervalle entre les vérifications de connexion
        /// </summary>
        private static int IntervalLoopTests = 1000;


        /// <summary>
        /// Initialise toutes les connexions
        /// </summary>
        public static void Init()
        {
            _connectionCanServo = new Dictionary<CanBoard, CanSubConnection>();

            EnableConnection = new Dictionary<Board, bool>();
            UDPBoardConnection = new Dictionary<Board, Connection>();
            AllConnections = new List<Connection>();

            ConnectionIO = AddUDPConnection(Board.RecIO, IPAddress.Parse("10.1.0.14"), 12324, 12314);
            ConnectionIO.Name = Board.RecIO.ToString();

            ConnectionMove = AddUDPConnection(Board.RecMove, IPAddress.Parse("10.1.0.11"), 12321, 12311);
            ConnectionMove.Name = Board.RecMove.ToString();

            ConnectionCanBridge = AddUDPConnection(Board.RecCan, IPAddress.Parse("10.1.0.15"), 12325, 12315);
            ConnectionCanBridge.Name = Board.RecCan.ToString();
            
            ConnectionCan = new CanConnection(Board.RecCan);
            
            _connectionCanServo.Add(CanBoard.CanServo1, new CanSubConnection(ConnectionCan, CanBoard.CanServo1));
            _connectionCanServo.Add(CanBoard.CanServo2, new CanSubConnection(ConnectionCan, CanBoard.CanServo2));
            _connectionCanServo.Add(CanBoard.CanServo3, new CanSubConnection(ConnectionCan, CanBoard.CanServo3));
            _connectionCanServo.Add(CanBoard.CanServo4, new CanSubConnection(ConnectionCan, CanBoard.CanServo4));
            _connectionCanServo.Add(CanBoard.CanServo5, new CanSubConnection(ConnectionCan, CanBoard.CanServo5));
            _connectionCanServo.Add(CanBoard.CanServo6, new CanSubConnection(ConnectionCan, CanBoard.CanServo6));

            _connectionCanServo.Values.ToList().ForEach(o => AllConnections.Add(o));

            // En remplacement des tests de connexion des ConnexionCheck, pour les syncroniser
            _linkTestConnections = ThreadManager.CreateThread(link => TestConnections());
            _linkTestConnections.Name = "Tests de connexion";
            _linkTestConnections.StartInfiniteLoop();
        }

        public static void StartConnections()
        {
            ConnectionIO.StartReception();
            ConnectionMove.StartReception();
            ConnectionCan.StartReception();
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
            UDPBoardConnection.Add(board, output);
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
            sender.SendMessage(UdpFrameFactory.TestConnexion(GetUDPBoardByConnection(sender)));
        }

        /// <summary>
        /// Boucle de tests de connexions pour maintenir les vérification à intervalle régulier
        /// </summary>
        private static void TestConnections()
        {
            int interval = IntervalLoopTests / AllConnections.Count();

            foreach (Connection conn in AllConnections.OrderBy(c => Connections.GetUDPBoardByConnection(c).ToString()))
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
        public static Board GetUDPBoardByConnection(Connection conn)
        {
            Board output = Board.RecMove;

            foreach (Board c in Enum.GetValues(typeof(Board)))
            {
                if (UDPBoardConnection.ContainsKey(c) && UDPBoardConnection[c] == conn)
                    output = c;
            }

            return output;
        }

        /// <summary>
        /// Retourne la carte concernée par une connexion
        /// </summary>
        /// <param name="conn">Connexion dont on veut la carte</param>
        /// <returns>La carte concernée par la connexion donnée</returns>
        public static CanBoard GetCANBoardByConnection(Connection conn)
        {
            CanBoard output = CanBoard.CanServo1;

            foreach (CanBoard c in Enum.GetValues(typeof(CanBoard)))
            {
                if (_connectionCanServo.ContainsKey(c) && _connectionCanServo[c] == conn)
                    output = c;
            }

            return output;
        }
    }
}
