using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;

namespace GoBot.Communications
{
    static class Connexions
    {
        public static ConnexionUDP ConnexionMove { get; set; }
        public static ConnexionUDP ConnexionIO { get; set; }
        public static ConnexionUDP ConnexionGB { get; set; }

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
            ConnexionMove.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMoveCheck_TestConnexion);

            ConnexionIO = new ConnexionUDP();
            ConnexionIO.Connexion(System.Net.IPAddress.Parse("10.1.0.14"), 12314, 12324);
            ConnexionIO.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionIOCheck_TestConnexion);

            ConnexionGB = new ConnexionUDP();
            ConnexionGB.Connexion(System.Net.IPAddress.Parse("10.1.0.12"), 12312, 12322);
            ConnexionGB.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionGBCheck_TestConnexion);

            ConnexionParCarte = new Dictionary<Carte, Connexion>();
            ConnexionParCarte.Add(Carte.RecMove, ConnexionMove);
            ConnexionParCarte.Add(Carte.RecIO, ConnexionIO);
            ConnexionParCarte.Add(Carte.RecGB, ConnexionGB);
        }

        public static void ConnexionMoveCheck_TestConnexion()
        {
            ConnexionMove.SendMessage(TrameFactory.TestConnexion(Carte.RecMove));
        }

        public static void ConnexionIOCheck_TestConnexion()
        {
            ConnexionIO.SendMessage(TrameFactory.TestConnexion(Carte.RecIO));
        }

        public static void ConnexionGBCheck_TestConnexion()
        {
            ConnexionGB.SendMessage(TrameFactory.TestConnexion(Carte.RecGB));
        }
    }
}
