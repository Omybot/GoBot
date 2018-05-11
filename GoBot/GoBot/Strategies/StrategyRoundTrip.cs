using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GoBot.Geometry.Shapes;
using GoBot.Geometry;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à faire des aller-retours sur la piste (pour homologuation d'évitement par exemple)
    /// </summary>
    class StrategyRoundTrip : Strategy
    {
        public override bool AvoidElements => false;

        protected override void SequenceBegin()
        {
            Robots.GrosRobot.SpeedConfig.SetParams(400, 1000, 2000, 400, 1000, 2000);

            Plateau.Balise.VitesseRotation(250);

            // Sortir ICI de la zone de départ pour commencer

            Robots.GrosRobot.Avancer(200);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                Robots.GrosRobot.PivotDroite(45);
            else
                Robots.GrosRobot.PivotGauche(45);

            Robots.GrosRobot.Avancer(200);
        }

        protected override void SequenceCore()
        {
            while (IsRunning)
            {
                while (!Robots.GrosRobot.GotoXYTeta(new Position(180, new RealPoint(350, 950)))) ;
                while (!Robots.GrosRobot.GotoXYTeta(new Position(0, new RealPoint(3000 - 350, 950)))) ;
            }
        }
    }
}
