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
            DateTime debut = DateTime.Now;
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, posLancement.PuissanceTir);

            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.PositionerAngle(Position.Angle, 0.5);

                // Si le moteur tourne depuis moins de 2 secondes on attends de finir les 2 secondes avant de lancer la séquence
                if ((DateTime.Now - debut).TotalMilliseconds < 2000)
                    Thread.Sleep((int)(2000 - (DateTime.Now - debut).TotalMilliseconds));

                bool balle = true;

                // Callage de la première balle devant le capteur
                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                Thread.Sleep(500);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                // Tant qu'il y a des balles à lancer
                while (balle)
                {
                    if (!Robots.GrosRobot.PresenceBalle())
                    {
                        // 1ère fois qu'on ne voit pas de balle : un coup de débloqueur
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                        Thread.Sleep(500);
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                        if (!Robots.GrosRobot.PresenceBalle())
                        {
                            // 2ème fois on aspire un coup pour bouger les balles
                            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                            Thread.Sleep(600);
                            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                            Thread.Sleep(1200);

                            if (!Robots.GrosRobot.PresenceBalle())
                            {
                                // 3ème fois : un coup de débloqueur
                                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                                Thread.Sleep(500);
                                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                                if (!Robots.GrosRobot.PresenceBalle())
                                    // 4ème fois : Bon bah y'a peut être vraiment rien alors...
                                    balle = false;
                            }
                        }
                    }
                    else
                    {
                        // Test de la couleur de la balle
                        Color couleur = Robots.GrosRobot.CouleurBalle();

                        if (couleur != Color.White)
                        {
                            // Balle de couleur on balance la balle à côyté
                            Robots.GrosRobot.PivotGauche(15);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                            Thread.Sleep(350);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                            Thread.Sleep(350);
                            Robots.GrosRobot.PivotDroite(15);
                        }
                        else
                        {
                            // Balle blanche : lancement dans le panier
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                            Thread.Sleep(350);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                            Thread.Sleep(500);
                        }
                    }
                }

                Robots.GrosRobot.BallesChargees = false;
                Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
                return true;
            }
            else
            {
                Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
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
                int score;
                if (Robots.GrosRobot.BallesChargees)
                    score = Score;
                else
                    score = 0;

                if (Plateau.AssietteAttrapee != -1)
                    return score * Plateau.PoidActions.PoidGlobalGrosLancerBallesAvecAssietteAccrochee;
                else
                    return score * Plateau.PoidActions.PoidGlobalGrosLancerBallesSansAssietteAccrochee;
            }
        }
    }
}
