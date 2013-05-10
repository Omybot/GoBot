using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.Mouvements
{
    class MoveGrosLanceBalles : Mouvement
    {
        public override Position Position
        {
            get
            {
                return new Position(new Angle(posLancement.Angle), new PointReel(posLancement.X, posLancement.Y));
            }
            protected set
            {
            }
        }

        private PositionLancement posLancement;

        public MoveGrosLanceBalles(PositionLancement pos)
        {
            posLancement = pos;
        }

        public override bool Executer(int timeOut = 0)
        {
            Plateau.BaisserBras();
            DateTime debut = DateTime.Now;

            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanonTMin, posLancement.PuissanceTir);

            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.PositionerAngle(Position.Angle, 0.5);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);

                int vitesseActuelleCanon = Robots.GrosRobot.GetVitesseCanon();
                while ((DateTime.Now - debut).TotalMilliseconds < 8000 &&
                    (vitesseActuelleCanon + 40 < posLancement.PuissanceTir || vitesseActuelleCanon - 40 > posLancement.PuissanceTir))
                {
                    Thread.Sleep(500);
                    vitesseActuelleCanon = Robots.GrosRobot.GetVitesseCanon();
                }

                bool balle = true;
                while (balle)
                {
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                    if (!Robots.GrosRobot.GetPresenceBalle())
                    {
                        Thread.Sleep(350);
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                        Thread.Sleep(350);
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                        if (!Robots.GrosRobot.GetPresenceBalle())
                        {
                            balle = false;
                        }
                    }
                    else
                    {
                        Color couleur = Robots.GrosRobot.GetCouleurBalle();
                        Console.WriteLine(couleur);
                        if (couleur != Color.White)
                        {
                            Robots.GrosRobot.PivotGauche(15, false);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                            Thread.Sleep(300);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                            Robots.GrosRobot.PivotDroite(15, false);
                        }
                        else
                        {
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                            Thread.Sleep(250);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                        }

                    }
                }

                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                Robots.GrosRobot.BallesChargees = false;
                //Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
                Robots.GrosRobot.Rapide();
                return true;
            }
            else
            {
                //Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);
                Robots.GrosRobot.Rapide();
                return false;
            }
        }

        public override int Score
        {
            get
            {
                return 14;
            }
        }

        public override double ScorePondere
        {
            get
            {
                // Si on n'a pas de balles chargées on ne considère pas l'action sinon il est interessant de les lancer
                double score = 1;
                if (!Robots.GrosRobot.BallesChargees || posLancement.Couleur != Plateau.NotreCouleur)
                    return 0;

                if (Plateau.AssietteAttrapee != -1)
                    score *= Plateau.PoidActions.PoidGlobalGrosLancerBallesAvecAssietteAccrochee;
                else
                    score *= Plateau.PoidActions.PoidGlobalGrosLancerBallesSansAssietteAccrochee;

                // x10 dans les 30 dernières secondes
                if (Plateau.Enchainement.TempsRestant.TotalSeconds < 30)
                    score *= 10;

                return score;
            }
        }
    }
}
