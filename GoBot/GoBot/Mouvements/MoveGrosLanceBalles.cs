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
        private PositionLancement posLancement;

        public MoveGrosLanceBalles(PositionLancement pos)
        {
            posLancement = pos;

            Position = new Position(new Angle(posLancement.Angle), new PointReel(posLancement.X, posLancement.Y));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début lançage de balles");
            Plateau.BaisserBras();
            DateTime debut = DateTime.Now;

            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanonTMin, posLancement.PuissanceTir);

            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.Historique.Log("Position de lançage atteinte");
                Robots.GrosRobot.PositionerAngle(Position.Angle, 0.5);
                Robots.GrosRobot.Historique.Log("Angle de lançage atteint");
                Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);

                Robots.GrosRobot.Historique.Log("Attente de la régulation de la vitesse du canon");
                int vitesseActuelleCanon = Robots.GrosRobot.GetVitesseCanon();
                while ((DateTime.Now - debut).TotalMilliseconds < 8000 &&
                    (vitesseActuelleCanon + 40 < posLancement.PuissanceTir || vitesseActuelleCanon - 40 > posLancement.PuissanceTir))
                {
                    Thread.Sleep(500);
                    vitesseActuelleCanon = Robots.GrosRobot.GetVitesseCanon();
                }

                Robots.GrosRobot.LancementBalles = true;
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
                        Plateau.DateBalle = DateTime.Now;
                        if (couleur != Color.White)
                        {
                            Robots.GrosRobot.Historique.Log("Lance balle couleur");
                            Plateau.CouleurBalleLancee = Color.Black;
                            Robots.GrosRobot.PivotGauche(15, false);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                            Thread.Sleep(300);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                            Robots.GrosRobot.PivotDroite(15, false);
                            Robots.GrosRobot.BalleCouleurChargee = false;
                        }
                        else
                        {
                            Robots.GrosRobot.Historique.Log("Lance balle blanche");
                            Plateau.CouleurBalleLancee = Color.White;
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
                            Thread.Sleep(250);
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                            if (Robots.GrosRobot.NbBallesBlanchesCharges > 0)
                            {
                                Plateau.Score += 2;
                                Plateau.NbBallesMarquees++;
                                Robots.GrosRobot.NbBallesBlanchesCharges--;
                            }
                        }
                    }
                }
                Robots.GrosRobot.Historique.Log("Plus de balles en stock");

                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
                //Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
                Robots.GrosRobot.Rapide();
                Robots.GrosRobot.LancementBalles = false;
                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Abandon du lancement de balles");
                //Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);
                Robots.GrosRobot.Rapide();
                Robots.GrosRobot.LancementBalles = false;
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
                if (Robots.GrosRobot.NbBallesBlanchesCharges == 0 || posLancement.Couleur != Plateau.NotreCouleur)
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
