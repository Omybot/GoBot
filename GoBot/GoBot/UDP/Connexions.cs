using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDP;
using GoBot.UDP;

namespace GoBot
{
    static class Connexions
    {
        public static ConnexionUDP ConnexionMiwi { get; set; }
        public static ConnexionUDP ConnexionMove { get; set; }
        public static ConnexionUDP ConnexionPi { get; set; }

        public static void Init()
        {
            ConnexionMove = new ConnexionUDP();
            ConnexionMove.Connexion(System.Net.IPAddress.Parse("10.1.0.11"), 12311, 12321);
            ConnexionMove.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMoveCheck_TestConnexion);

            ConnexionMiwi = new ConnexionUDP();
            ConnexionMiwi.Connexion(System.Net.IPAddress.Parse("10.1.0.12"), 12312, 12322);
            ConnexionMiwi.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMiwiCheck_TestConnexion);
        }

        private static void ConnexionMoveCheck_TestConnexion()
        {
            ConnexionMove.SendMessage(TrameFactory.TestConnexionMove());
        }

        private static void ConnexionMiwiCheck_TestConnexion()
        {
            ConnexionMiwi.SendMessage(TrameFactory.TestConnexionMove());
        }
    }
}
