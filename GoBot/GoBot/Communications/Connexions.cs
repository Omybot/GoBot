using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;

namespace GoBot.Communications
{
    static class Connexions
    {
        public static ConnexionUDP ConnexionMiwi { get; set; }
        public static ConnexionUDP ConnexionMove { get; set; }
        public static ConnexionUDP ConnexionPi { get; set; }

        public static Dictionary<Carte, ConnexionUDP> ConnexionParCarte { get; private set; }

        public static void Init()
        {
            ConnexionMove = new ConnexionUDP();
            ConnexionMove.Connexion(System.Net.IPAddress.Parse("10.1.0.11"), 12311, 12321);
            ConnexionMove.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMoveCheck_TestConnexion);

            ConnexionMiwi = new ConnexionUDP();
            ConnexionMiwi.Connexion(System.Net.IPAddress.Parse("10.1.0.12"), 12312, 12322);
            ConnexionMiwi.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMiwiCheck_TestConnexion);

            ConnexionPi = new ConnexionUDP();
            ConnexionPi.Connexion(System.Net.IPAddress.Parse("10.0.0.13"), 12313, 12323);
            ConnexionPi.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionPiCheck_TestConnexion);

            ConnexionParCarte = new Dictionary<Carte, ConnexionUDP>();
            ConnexionParCarte.Add(Carte.RecBun, ConnexionMiwi);
            ConnexionParCarte.Add(Carte.RecBeu, ConnexionMiwi);
            ConnexionParCarte.Add(Carte.RecBoi, ConnexionMiwi);
            ConnexionParCarte.Add(Carte.RecMiwi, ConnexionMiwi);
            ConnexionParCarte.Add(Carte.RecPi, ConnexionMiwi);
            ConnexionParCarte.Add(Carte.RecMove, ConnexionMove);
        }

        private static void ConnexionMoveCheck_TestConnexion()
        {
            ConnexionMove.SendMessage(TrameFactory.TestConnexionMove());
        }

        private static void ConnexionMiwiCheck_TestConnexion()
        {
            ConnexionMiwi.SendMessage(TrameFactory.TestConnexionMiwi());
        }

        private static void ConnexionPiCheck_TestConnexion()
        {
            ConnexionPi.SendMessage(TrameFactory.TestConnexionPi());
        }
    }
}
