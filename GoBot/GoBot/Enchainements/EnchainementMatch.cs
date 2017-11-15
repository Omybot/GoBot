using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneurs;
using System.Windows.Forms;
using GoBot.ElementsJeu;
using GoBot.Mouvements;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using GoBot.Geometry;

namespace GoBot.Enchainements
{
    class EnchainementMatch : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            ActionsFixesGros();

            List<Mouvement> stratFixe = new List<Mouvement>();

            // Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
            {
                //stratFixe.Add(new MouvementFusee(1));
            }
            else
            {
                //stratFixe.Add(new MouvementFusee(2));
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
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
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
            // Coder ICI les actions fixe au départ du match
        }

        private void HokuyoRecalViolet()
        {
            Robots.GrosRobot.PositionerAngle(180);

            Thread.Sleep(500);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new RealPoint(0, 50), new RealPoint(0, 900)), 50, 10);
            if (a.InPositiveDegrees > 180)
                Robots.GrosRobot.PivotDroite(a.InPositiveDegrees - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.InPositiveDegrees));

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordinates));

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new RealPoint(0, 50), new RealPoint(0, 900)), 50, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordinates.Translation(-distance, 0)));

            distance = Actionneur.Hokuyo.CalculDistanceY(970, 1170, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(180, Robots.GrosRobot.Position.Coordinates.Translation(0, -distance)));
        }

        private void ThreadHokuyoRecalVert()
        {
            Robots.GrosRobot.PositionerAngle(0);

            Thread.Sleep(500);

            Angle a = Actionneur.Hokuyo.CalculAngle(new Segment(new RealPoint(3000, 50), new RealPoint(3000, 900)), 50, 10);
            if (a.InPositiveDegrees > 180)
                Robots.GrosRobot.PivotDroite(a.InPositiveDegrees - 270);
            else
                Robots.GrosRobot.PivotGauche((90 - a.InPositiveDegrees));

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordinates));

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new RealPoint(3000, 50), new RealPoint(3000, 900)), 50, 10);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordinates.Translation(-(distance-3000), 0)));

            Robots.GrosRobot.PositionerAngle(45);

            distance = Actionneur.Hokuyo.CalculDistanceY(3000 - 1170, 3000 - 970, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, Robots.GrosRobot.Position.Coordinates.Translation(0, -distance)));
        }
    }
}
