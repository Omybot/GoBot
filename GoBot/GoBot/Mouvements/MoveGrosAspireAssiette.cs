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
        private int numeroAssiette;

        public MoveGrosAspireAssiette(int iAssiette)
        {
            numeroAssiette = iAssiette;

            if (numeroAssiette < 5)
                Position = new Position(new Angle(0), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X + 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y));
            else
                Position = new Position(new Angle(180), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X - 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y));

            if (numeroAssiette == 0 || numeroAssiette == 1 || numeroAssiette == 2 || numeroAssiette == 3)
                Position = new Position(new Angle(0), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X + 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y + 40));
            if (numeroAssiette == 6 || numeroAssiette == 7 || numeroAssiette == 8 || numeroAssiette == 9)
                Position = new Position(new Angle(180), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X - 340, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y - 40));

            if (numeroAssiette == 4)
                Position = new Position(new Angle(-18.47), new PointReel(530, 1653));
            if (numeroAssiette == 5)
                Position = new Position(new Angle(-18.47 + 180), new PointReel(3000 - 530, 2000 - 1653));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début aspiration assiette " + numeroAssiette);
            int distance = 170;

            if (numeroAssiette == 4 || numeroAssiette == 5)
                distance = 207;

            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanonTMin, 6850);

            Plateau.BaisserBras();
            bool pathFindingOk = true;
            if (numeroAssiette != Plateau.AssietteAttrapee)
            {
                if(pathFindingOk = Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
                    Robots.GrosRobot.Historique.Log("Position assiette " + numeroAssiette + " atteinte");

                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                Robots.GrosRobot.Historique.Log("Angle assiette " + numeroAssiette + " atteint");
            }

            Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);

            if (pathFindingOk)
            {
                bool aspirateurRemonte = false;

                Robots.GrosRobot.Historique.Log("Séquence d'aspiration");
                // Approche d'aspiration
                Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);

                if (numeroAssiette != Plateau.AssietteAttrapee)
                {
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(distance);
                    Robots.GrosRobot.Rapide();
                }
                else
                    Thread.Sleep(1500);

                // Remontage de l'aspirateur
                int i = 0;
                while (i < 2)
                {
                    // Remontage de l'aspirateur
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspirationMaintien);
                    Thread.Sleep(300);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                    Thread.Sleep(600);

                    // Teste si l'aspirateur est bien remonté
                    aspirateurRemonte = Robots.GrosRobot.GetAspiRemonte();
                    if (aspirateurRemonte)
                        break;

                    Robots.GrosRobot.Historique.Log("Problème : aspirateur non remonté");
                    // Repose les cerises dans l'assiette et tente de les réaspirer
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
                    Thread.Sleep(500);
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                    Thread.Sleep(1500);
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                    Thread.Sleep(1000);
                    i++;
                }

                bool balle = true;

                if (i == 2)
                {
                    Plateau.AssiettesExiste[numeroAssiette] = false;
                    Robots.GrosRobot.Historique.Log("Abandon de l'assiette " + numeroAssiette);
                    Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                    Thread.Sleep(1500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
                }
                else
                {
                    // Callage de la première balle devant le capteur
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);
                    // Teste si on voit des balles chargées

                    /*
                    // Si pas d'assiette on abandonne et on s'en va. On considère que l'assiette n'est pas ici
                    if (!Robots.GrosRobot.GetPresenceAssiette())
                    {
                        Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);

                        if (numeroAssiette != Plateau.AssietteAttrapee)
                            Robots.GrosRobot.Avancer(distance);
                        Plateau.AssiettesExiste[numeroAssiette] = false;
                        return false;
                    }*/

                    Robots.GrosRobot.Historique.Log("Test 1 de la présence de balles");
                    if (!Robots.GrosRobot.GetPresenceBalle())
                    {
                        // 1ère fois qu'on ne voit pas de balle : un coup de débloqueur
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                        Thread.Sleep(500);
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                        Robots.GrosRobot.Historique.Log("Test 2 de la présence de balles");
                        if (!Robots.GrosRobot.GetPresenceBalle())
                        {
                            // 2ème fois on aspire un coup pour bouger les balles
                            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                            Thread.Sleep(600);
                            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
                            Thread.Sleep(1200);

                            Robots.GrosRobot.Historique.Log("Test 3 de la présence de balles");
                            if (!Robots.GrosRobot.GetPresenceBalle())
                            {
                                // 3ème fois : un coup de débloqueur
                                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
                                Thread.Sleep(500);
                                Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);

                                Robots.GrosRobot.Historique.Log("Test 4 de la présence de balles");
                                if (!Robots.GrosRobot.GetPresenceBalle())
                                {
                                    // 4ème fois : Bon bah y'a peut être vraiment rien alors...
                                    balle = false;
                                }
                            }
                        }
                    }

                    if (!balle)
                    {
                        Plateau.AssiettesExiste[numeroAssiette] = false;
                        Robots.GrosRobot.Historique.Log("Aucune balle détectée");
                    }
                    else
                    {
                        Robots.GrosRobot.Historique.Log("Balles chargées détectées");
                    }
                }

                if (numeroAssiette != Plateau.AssietteAttrapee)
                    Robots.GrosRobot.Avancer(distance);
                else
                {
                    // On relâche l'assiette
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);
                    Robots.GrosRobot.Historique.Log("Relâche de l'assiette " + Plateau.AssietteAttrapee + "attrapée");
                    Plateau.AssietteAttrapee = -1;
                }

                if (balle)
                {
                    Robots.GrosRobot.NbBallesBlanchesCharges = 7;
                    Robots.GrosRobot.BalleCouleurChargee = true;
                    Robots.GrosRobot.CouleurBalleChargee = numeroAssiette < 5 ? Plateau.CouleurJ2B : Plateau.CouleurJ1R;
                    Plateau.AssiettesVidees[numeroAssiette] = true;
                    Plateau.Score += Score;
                }

                return balle;
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
                if (Robots.GrosRobot.NbBallesBlanchesCharges > 0 || Plateau.AssiettesVidees[numeroAssiette] || !Plateau.AssiettesExiste[numeroAssiette])
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
