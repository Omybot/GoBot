using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementTapis : Mouvement
    {
        private int numeroTapis;

        public MouvementTapis(int numero)
        {
            Robot = Robots.GrosRobot;
            numeroTapis = numero;
            Element = Plateau.ListeTapis[numeroTapis];

            switch (numeroTapis)
            {
                case 0:
                    Positions.Add(new Position(45, new Calculs.Formes.PointReel(1039, 766)));
                    break;
                case 1:
                    Positions.Add(new Position(45, new Calculs.Formes.PointReel(1439, 766)));
                    break;
                case 2:
                    Positions.Add(new Position(45, new Calculs.Formes.PointReel(1561, 766)));
                    break;
                case 3:
                    Positions.Add(new Position(45, new Calculs.Formes.PointReel(1961, 766)));
                    break;
            }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début tapis " + numeroTapis);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Actionneur.BrasTapis.Descendre();
                Thread.Sleep(350);
                if(numeroTapis == 1 || numeroTapis == 3)
                    Actionneur.BrasTapis.LacherTapis1();
                else
                    Actionneur.BrasTapis.LacherTapis2();
                Thread.Sleep(350);
                Actionneur.BrasTapis.Monter();

                Robots.GrosRobot.Historique.Log("Fin tapis " + numeroTapis + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                Plateau.ListeTapis[numeroTapis].Pose = true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation tapis " + numeroTapis);
                return false;
            }
            return true;
        }

        public override int Score
        {
            get
            {
                if ((Plateau.NotreCouleur == Plateau.CouleurGaucheJaune && (numeroTapis == 0 || numeroTapis == 1)) ||
                    (Plateau.NotreCouleur == Plateau.CouleurDroiteVert && (numeroTapis == 2 || numeroTapis == 3)))
                    return 12;
                else 
                    return 0;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
