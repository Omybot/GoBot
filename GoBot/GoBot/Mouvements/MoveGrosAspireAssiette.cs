using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    class MoveGrosAspireAssiette : Mouvement
    {
        public override Position Position 
        {
            get
            {
                Position position;
                if (numeroAssiette < 5)
                    position = new Position(new Angle(0), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X + 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y));
                else
                    position = new Position(new Angle(180), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X - 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y));

                return position;
            }
            protected set
            {
            }
        }

        private int numeroAssiette;

        public MoveGrosAspireAssiette(int iAssiette)
        {
            numeroAssiette = iAssiette;
        }

        public override bool Executer(int timeOut = 0)
        {
            bool pathFindingOk = true;
            if (numeroAssiette != Plateau.AssietteAttrapee)
            {
                pathFindingOk = Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true);
                Robots.GrosRobot.PositionerAngle(Position.Angle, 5);
            }
            
            if (pathFindingOk)
            {
                bool aspirateurRemonte = false;

                // Approche d'aspiration
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
                
                if (numeroAssiette != Plateau.AssietteAttrapee)
                {
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(150);
                    Robots.GrosRobot.Rapide();
                }

                // Si pas d'assiette on abandonne et on s'en va. On considère que l'assiette n'est pas ici
                if (!Robots.GrosRobot.GetPresenceAssiette())
                {
                    if (numeroAssiette != Plateau.AssietteAttrapee)
                        Robots.GrosRobot.Avancer(150);

                    Plateau.AssiettesExiste[numeroAssiette] = false;
                    return false;
                }

                while(true)
                {
                    // Remontage de l'aspirateur
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspirationMaintien);
                    Thread.Sleep(200);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
                    Thread.Sleep(1500);

                    // Teste si l'aspirateur est bien remonté
                    aspirateurRemonte = Robots.GrosRobot.GetAspiRemonte();
                    if (aspirateurRemonte)
                    {
                        Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                        break;
                    }

                    // Repose les bougies dans l'assiette et tente de les réaspirer
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
                    Thread.Sleep(500);
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                    Thread.Sleep(500);
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                }

                if (numeroAssiette != Plateau.AssietteAttrapee)
                    Robots.GrosRobot.Avancer(150);
                else
                {
                    // On relâche l'assiette
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);
                    Plateau.AssietteAttrapee = -1;
                }

                Robots.GrosRobot.BallesChargees = true;
                Plateau.AssiettesVidees[numeroAssiette] = true;
                Plateau.Score += Score;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int Score
        {
            get
            {
                return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                // Si on n'a pas de balles chargées on peut aspirer sinon on ne considère pas l'action
                double score = 1;
                if (Robots.GrosRobot.BallesChargees || Plateau.AssiettesVidees[numeroAssiette] || !Plateau.AssiettesExiste[numeroAssiette])
                    return 0;

                // Priorité ultime sur l'aspirage d'assiette accrochée : TODO : gérer un cas spécial en fin de match proche ?
                if (numeroAssiette == Plateau.AssietteAttrapee)
                    return double.MaxValue;

                score *= Plateau.PoidActions.PoidGlobalGrosAspireAssiette * Plateau.PoidActions.PoidsGrosAssiette[numeroAssiette];

                // Intêret / 1000 dans les 18 dernières secondes
                if (Plateau.Enchainement.TempsRestant.TotalSeconds < 18)
                    score /= 1000;
                // Intêret / 10 dans les 30 dernières secondes
                else if (Plateau.Enchainement.TempsRestant.TotalSeconds < 30)
                    score /= 10;

                return score;
            }
        }
    }
}
