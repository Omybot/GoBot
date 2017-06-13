using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;
using System.Threading;
using System.Net;

namespace GoBot.Communications
{
    static class Connexions
    {
        public static ConnexionUDP ConnexionMove { get; set; }
        public static ConnexionUDP ConnexionIO { get; set; }
        public static ConnexionUDP ConnexionGB { get; set; }

        public static List<Connexion> AllConnections { get; set; }
        
        public static Dictionary<Carte, Connexion> ConnexionParCarte { get; private set; }
        public static Dictionary<Carte, bool> ActivationConnexion { get; private set; }

        public static void Init()
        {
            ActivationConnexion = new Dictionary<Carte, bool>();
            ConnexionParCarte = new Dictionary<Carte, Connexion>();
            AllConnections = new List<Connexion>();

            ConnexionMove = AddUDPConnection(Carte.RecMove, IPAddress.Parse("10.1.0.11"), 12321, 12311);
            ConnexionIO = AddUDPConnection(Carte.RecIO, IPAddress.Parse("10.1.0.14"), 12324, 12314);
            ConnexionGB = AddUDPConnection(Carte.RecGB, IPAddress.Parse("10.1.0.12"), 12322, 12312);

            ThreadPool.QueueUserWorkItem(f => TestConnectionsLoop()); // En remplacement des tests de connexion des ConnexionCheck, pour les syncroniser
        }

        private static ConnexionUDP AddUDPConnection(Carte board, IPAddress ip, int inPort, int outPort)
        {
            ConnexionUDP output = new ConnexionUDP();
            output.Connexion(ip, inPort, outPort);
            ConnexionParCarte.Add(board, output);
            ActivationConnexion.Add(board, true);
            AllConnections.Add(output);

            return output;
        }

        private static void TestConnectionsLoop()
        {
            int interval = 500;

            while(!Config.Shutdown)
            {
                foreach (ConnexionUDP conn in AllConnections)
                {
                    conn.SendMessage(TrameFactory.TestConnexion(GetBoardByConnection(conn)));
                    Thread.Sleep(interval / AllConnections.Count());
                }
            }
        }

        public static Carte GetBoardByConnection(Connexion conn)
        {
            Carte output = Carte.RecMove;

            foreach (Carte c in Enum.GetValues(typeof(Carte)))
            {
                if (ConnexionParCarte.ContainsKey(c) && ConnexionParCarte[c] == conn)
                    output = c;
            }

            return output;
        }
    }
}
