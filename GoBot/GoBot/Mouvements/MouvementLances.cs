using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementLances : Mouvement
    {
        public MouvementLances()
        {
            Positions.Add(PositionsMouvements.PositionsLances[1]);
            Positions.Add(PositionsMouvements.PositionsLances[2]);
            Robot = Robots.PetitRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.PetitRobot.Historique.Log("Début catapulte lances");

            Position position = PositionProche;

            if (Robots.PetitRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robots.PetitRobot.Historique.Log("Lancement lances");
                ReservoirBouchons.TendTissu();
                ReservoirBouchons.Ouvrir();
                Thread.Sleep(1200);
                CatapulteLances.Tirer();
                CatapulteLances.LancesCatapultees = Robots.PetitRobot.Position.Coordonnees.X < 1500 ? 1 : 2;
                Thread.Sleep(200);
                ReservoirBouchons.Fermer();
                ReservoirBouchons.RelacheTissu();
                Robots.PetitRobot.Historique.Log("Fin catapulte lances");

                Plateau.Score += 12;

                return true;
            }

            Robots.PetitRobot.Historique.Log("Annulation catapulte lances");

            return false;
        }

        public override int Score
        {
            get { return CatapulteLances.LancesCatapultees != 0 ? 0 : 12; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
