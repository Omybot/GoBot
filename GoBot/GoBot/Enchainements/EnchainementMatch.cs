using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneurs;
using System.Windows.Forms;
using GoBot.ElementsJeu;
using GoBot.Mouvements;
using Gobot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.Calculs;

namespace GoBot.Enchainements
{
    class EnchainementMatch : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            ActionsFixesGros();

            List<Mouvement> stratFixe = new List<Mouvement>();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
            {
                stratFixe.Add(new MouvementFusee(1));
                stratFixe.Add(new MouvementModuleAvant(1));
                stratFixe.Add(new MouvementModuleGauche(3));
                stratFixe.Add(new MouvementDeposeModules(0));
                stratFixe.Add(new MouvementFusee(0));
                stratFixe.Add(new MouvementModuleAvant(0));
                stratFixe.Add(new MouvementModuleAvant(2));
                stratFixe.Add(new MouvementDeposeModules(1));
            }
            else
            {
                stratFixe.Add(new MouvementFusee(2));
                stratFixe.Add(new MouvementModuleAvant(10));
                stratFixe.Add(new MouvementModuleDroite(8));
                stratFixe.Add(new MouvementDeposeModules(2));
                stratFixe.Add(new MouvementFusee(3));
                stratFixe.Add(new MouvementModuleAvant(11));
                stratFixe.Add(new MouvementModuleAvant(9));
                stratFixe.Add(new MouvementDeposeModules(1));
            }

            int iMouv = 0;

            while(iMouv < stratFixe.Count && stratFixe[iMouv].Executer())
                iMouv++;

            while (ListeMouvements.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvements.Count; j++)
                {
                    double cout = ListeMouvements[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }
                if (ListeMouvements[iMeilleur].Cout != double.MaxValue && ListeMouvements[iMeilleur].ValeurAction != 0)
                {
                    if (!ListeMouvements[iMeilleur].Executer())
                        ListeMouvements[iMeilleur].DateMinimum = DateTime.Now + new TimeSpan(0, 0, 1);
                }
                else
                {
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch(Exception)
                    {

                    }
                }
            }
            
        }

        private void ArmePince(object useless)
        {
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
            {
                Thread.Sleep(200);
                Actionneur.BrasLunaireDroite.Descendre();
                Thread.Sleep(250);
                Actionneur.BrasLunaireDroite.Ouvrir();
            }
            else
            {
                Thread.Sleep(200);
                Actionneur.BrasLunaireGauche.Descendre();
                Thread.Sleep(250);
                Actionneur.BrasLunaireGauche.Ouvrir();
            }
        }

        private void ActionsFixesGros()
        {
            Robots.GrosRobot.Rapide();

            Actionneur.Ejecteur.DemarrerCapteurCouleur();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                Robots.GrosRobot.PivotGauche(3);
            else
                Robots.GrosRobot.PivotDroite(3);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ArmePince));

            Robots.GrosRobot.SpeedConfig.SetParams(500, 1500, 1500, 800, 2000, 2000);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
            {
                Robots.GrosRobot.Virage(SensAR.Avant, SensGD.Gauche, 200, 73);
                Plateau.Elements.Modules[5].Ramasse = true;
                Actionneur.BrasLunaireDroite.Attraper();
            }
            else
            {
                Robots.GrosRobot.Virage(SensAR.Avant, SensGD.Droite, 200, 73);
                Plateau.Elements.Modules[6].Ramasse = true;
                Actionneur.BrasLunaireGauche.Attraper();
            }

            Robots.GrosRobot.Rapide();

            Thread.Sleep(200);
        }

        private void HokuyoRecalViolet()
        {
            Robots.GrosRobot.PositionerAngle(180);

            Thread.Sleep(500);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new PointReel(0, 50), new PointReel(0, 900)), 50, 10);
            if (a.AngleDegresPositif > 180)
                Robots.GrosRobot.PivotDroite(a.AngleDegresPositif - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.AngleDegresPositif));

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordonnees));

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new PointReel(0, 50), new PointReel(0, 900)), 50, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordonnees.Translation(-distance, 0)));

            distance = Actionneur.Hokuyo.CalculDistanceY(970, 1170, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordonnees.Translation(0, -distance)));
        }

        private void ThreadHokuyoRecalVert()
        {
            Robots.GrosRobot.PositionerAngle(0);

            Thread.Sleep(500);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new PointReel(3000, 50), new PointReel(3000, 900)), 50, 10);
            if (a.AngleDegresPositif > 180)
                Robots.GrosRobot.PivotDroite(a.AngleDegresPositif - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.AngleDegresPositif));

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordonnees));

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new PointReel(3000, 50), new PointReel(3000, 900)), 50, 10);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordonnees.Translation(-(distance-3000), 0)));

            Robots.GrosRobot.PositionerAngle(45);

            distance = Actionneur.Hokuyo.CalculDistanceY(3000 - 1170, 3000 - 970, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordonnees.Translation(0, -distance)));
        }
    }
}
