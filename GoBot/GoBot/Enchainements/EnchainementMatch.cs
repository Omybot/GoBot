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

            while (ListeMouvementsGros.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsGros.Count; j++)
                {
                    double cout = ListeMouvementsGros[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }
                if (ListeMouvementsGros[iMeilleur].ValeurAction != 0)
                {
                    if (!ListeMouvementsGros[iMeilleur].Executer())
                        ListeMouvementsGros[iMeilleur].DateMinimum = DateTime.Now + new TimeSpan(0, 0, 1);
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

        private void ActionsFixesGros()
        {
            List<PointReel> trajectoirePolaire;
            List<PointReel> pointsPolaires;

            Actionneur.BarreDePompes.Stop();
            Robots.GrosRobot.Avancer(210);
            //// Trajectoire normale
            //Robots.GrosRobot.AccelerationDebutDeplacement = 1200;
            //Robots.GrosRobot.AccelerationFinDeplacement = 1700;

            //Robots.GrosRobot.VitessePivot = 1000;
            //Robots.GrosRobot.AccelerationPivot = 1000;

            //Robots.GrosRobot.EnvoyerPIDCap(10000, 0, 300);
            //Robots.GrosRobot.EnvoyerPIDVitesse(20, 0, 200);

            //pointsPolaires = new List<PointReel>();

            //if (Plateau.NotreCouleur == Plateau.CouleurGaucheViolet)
            //{
            //    pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X + 10, Robots.GrosRobot.Position.Coordonnees.Y));
            //    //pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 80));
            //    pointsPolaires.Add(new PointReel(600, Robots.GrosRobot.Position.Coordonnees.Y + 70));
            //    pointsPolaires.Add(new PointReel(550, 400));
            //    pointsPolaires.Add(new PointReel(1300, 500));
            //}
            //else
            //{
            //    pointsPolaires.Add(new PointReel(Robots.GrosRobot.Position.Coordonnees.X - 10, Robots.GrosRobot.Position.Coordonnees.Y));
            //    //pointsPolaires.Add(new PointReel(700, Robots.GrosRobot.Position.Coordonnees.Y + 80));
            //    pointsPolaires.Add(new PointReel(3000 - 600, Robots.GrosRobot.Position.Coordonnees.Y + 70));
            //    pointsPolaires.Add(new PointReel(3000 - 550, 400));
            //    pointsPolaires.Add(new PointReel(3000 - 1300, 500));
            //}

            //trajectoirePolaire = BezierCurve.GetPoints(pointsPolaires, 200);
            //Dessinateur.modeCourant = Dessinateur.Mode.TrajectoirePolaire;
            //Dessinateur.TrajectoirePolaire = trajectoirePolaire;
            //Dessinateur.PointsPolaire = pointsPolaires;

            //Robots.GrosRobot.TrajectoirePolaire(SensAR.Avant, trajectoirePolaire, true);

            //Thread.Sleep(200);

            //if (Plateau.NotreCouleur == Plateau.CouleurGaucheViolet)
            //    HokuyoRecalViolet();
            //else
            //    ThreadHokuyoRecalVert();
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

            Robots.GrosRobot.ReglerOffsetAsserv((int)Robots.GrosRobot.Position.Coordonnees.X, (int)Robots.GrosRobot.Position.Coordonnees.Y, 180);

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new PointReel(0, 50), new PointReel(0, 900)), 50, 2);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X - distance), (int)Robots.GrosRobot.Position.Coordonnees.Y, 180);

            distance = Actionneur.Hokuyo.CalculDistanceY(970, 1170, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X), (int)(Robots.GrosRobot.Position.Coordonnees.Y - distance), 180);
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

            Robots.GrosRobot.ReglerOffsetAsserv((int)Robots.GrosRobot.Position.Coordonnees.X, (int)Robots.GrosRobot.Position.Coordonnees.Y, 0);

            double distance = Actionneur.Hokuyo.CalculDistanceX(new Segment(new PointReel(3000, 50), new PointReel(3000, 900)), 50, 10);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X - (distance - 3000)), (int)Robots.GrosRobot.Position.Coordonnees.Y, 0);

            Robots.GrosRobot.PositionerAngle(45);

            distance = Actionneur.Hokuyo.CalculDistanceY(3000 - 1170, 3000 - 970, 150, 2);
            Robots.GrosRobot.ReglerOffsetAsserv((int)(Robots.GrosRobot.Position.Coordonnees.X), (int)(Robots.GrosRobot.Position.Coordonnees.Y - distance), 0);
        }
    }
}
