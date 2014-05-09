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
        public static ConnexionMiwi ConnexionBun { get; set; }
        public static ConnexionMiwi ConnexionBeu { get; set; }
        public static ConnexionMiwi ConnexionBoi { get; set; }
        public static ConnexionMiwi ConnexionPi { get; set; }

        public static Dictionary<Carte, Connexion> ConnexionParCarte { get; private set; }

        public static void Init()
        {
            ConnexionMove = new ConnexionUDP();
            ConnexionMove.Connexion(System.Net.IPAddress.Parse("10.1.0.11"), 12311, 12321);
            ConnexionMove.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMoveCheck_TestConnexion);

            ConnexionMiwi = new ConnexionUDP();
            ConnexionMiwi.Connexion(System.Net.IPAddress.Parse("10.1.0.12"), 12312, 12322);
            ConnexionMiwi.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionMiwiCheck_TestConnexion);

            ConnexionIO = new ConnexionUDP();
            ConnexionIO.Connexion(System.Net.IPAddress.Parse("10.1.0.14"), 12314, 12324);
            ConnexionIO.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionIOCheck_TestConnexion);

            ConnexionBun = new ConnexionMiwi(Carte.RecBun);
            ConnexionBun.StartReception();
            ConnexionBeu = new ConnexionMiwi(Carte.RecBeu);
            ConnexionBeu.StartReception();
            ConnexionBoi = new ConnexionMiwi(Carte.RecBoi);
            ConnexionBoi.StartReception();

            ConnexionPi = new ConnexionMiwi(Carte.RecPi);
            ConnexionPi.StartReception();
            ConnexionPi.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(ConnexionPiCheck_TestConnexion);

            ConnexionParCarte = new Dictionary<Carte, Connexion>();
            ConnexionParCarte.Add(Carte.RecBun, ConnexionBun);
            ConnexionParCarte.Add(Carte.RecBeu, ConnexionBeu);
            ConnexionParCarte.Add(Carte.RecBoi, ConnexionBoi);
            ConnexionParCarte.Add(Carte.RecMiwi, ConnexionMiwi);
            ConnexionParCarte.Add(Carte.RecPi, ConnexionPi);
            ConnexionParCarte.Add(Carte.RecMove, ConnexionMove);
            ConnexionParCarte.Add(Carte.RecIO, ConnexionIO);
        }

        public static void ConnexionMoveCheck_TestConnexion()
        {
            ConnexionMove.SendMessage(TrameFactory.TestConnexionMove(Robots.GrosRobot.TensionPack1 < 21 && Robots.GrosRobot.TensionPack2 < 21));
        }

        public static void ConnexionMiwiCheck_TestConnexion()
        {
            ConnexionMiwi.SendMessage(TrameFactory.TestConnexionMiwi());
        }

        public static void ConnexionIOCheck_TestConnexion()
        {
            ConnexionIO.SendMessage(TrameFactory.TestConnexionIO());
        }

        public static void ConnexionPiCheck_TestConnexion()
        {
            ConnexionPi.SendMessage(TrameFactory.TestConnexionPi());
        }
    }
}
