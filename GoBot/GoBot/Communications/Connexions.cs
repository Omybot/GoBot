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
        public static ConnexionUDP ConnexionIO { get; set; }

        public static Dictionary<Carte, Connexion> ConnexionParCarte { get; private set; }
        public static Dictionary<Carte, bool> ActivationConnexion { get; private set; }

        public static void Init()
        {
            ActivationConnexion = new Dictionary<Carte, bool>();
            ActivationConnexion.Add(Carte.RecIO, true);
            ActivationConnexion.Add(Carte.RecMove, true);

            ConnexionMove = new ConnexionUDP();
            ConnexionMove.Connexion(System.Net.IPAddress.Parse("10.1.0.11"), 12311, 12321);
            ConnexionMove.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMoveCheck_TestConnexion);

            ConnexionIO = new ConnexionUDP();
            ConnexionIO.Connexion(System.Net.IPAddress.Parse("10.1.0.14"), 12314, 12324);
            ConnexionIO.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionIOCheck_TestConnexion);

            ConnexionParCarte = new Dictionary<Carte, Connexion>();
            ConnexionParCarte.Add(Carte.RecMove, ConnexionMove);
            ConnexionParCarte.Add(Carte.RecIO, ConnexionIO);
        }

        public static void ConnexionMoveCheck_TestConnexion()
        {
            ConnexionMove.SendMessage(TrameFactory.TestConnexionMove(Robots.GrosRobot.TensionPack1 < 21 && Robots.GrosRobot.TensionPack2 < 21));
        }

        public static void ConnexionIOCheck_TestConnexion()
        {
            ConnexionIO.SendMessage(TrameFactory.TestConnexionIO());
        }
    }
}
