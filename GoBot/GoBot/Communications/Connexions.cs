using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;
using System.Threading;

namespace GoBot.Communications
{
    static class Connexions
    {
        public static ConnexionUDP ConnexionMove { get; set; }
        public static ConnexionUDP ConnexionIO { get; set; }
        public static ConnexionUDP ConnexionGB { get; set; }

        public static IEnumerable<Connexion> AllConnections
        {
            get
            {
                yield return ConnexionMove;
                yield return ConnexionIO;
                yield return ConnexionGB;
            }
        }

        public static Dictionary<Carte, Connexion> ConnexionParCarte { get; private set; }
        public static Dictionary<Carte, bool> ActivationConnexion { get; private set; }

        public static void Init()
        {
            ActivationConnexion = new Dictionary<Carte, bool>();
            ActivationConnexion.Add(Carte.RecIO, true);
            ActivationConnexion.Add(Carte.RecMove, true);
            ActivationConnexion.Add(Carte.RecGB, true);

            ConnexionMove = new ConnexionUDP();
            ConnexionMove.Connexion(System.Net.IPAddress.Parse("10.1.0.11"), 12311, 12321);

            ConnexionIO = new ConnexionUDP();
            ConnexionIO.Connexion(System.Net.IPAddress.Parse("10.1.0.14"), 12314, 12324);

            ConnexionGB = new ConnexionUDP();
            ConnexionGB.Connexion(System.Net.IPAddress.Parse("10.1.0.12"), 12312, 12322);

            ConnexionParCarte = new Dictionary<Carte, Connexion>();
            ConnexionParCarte.Add(Carte.RecMove, ConnexionMove);
            ConnexionParCarte.Add(Carte.RecIO, ConnexionIO);
            ConnexionParCarte.Add(Carte.RecGB, ConnexionGB);

            ThreadPool.QueueUserWorkItem(f => TestConnectionsLoop()); // En remplacement des tests de connexion des ConnexionCheck, pour les syncroniser
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

        private static Carte GetBoardByConnection(ConnexionUDP conn)
        {
            Carte output = Carte.RecMove;

            foreach (Carte c in Enum.GetValues(typeof(Carte)))
            {
                if (ConnexionParCarte[c] == conn)
                    output = c;
            }

            return output;
        }
    }
}
