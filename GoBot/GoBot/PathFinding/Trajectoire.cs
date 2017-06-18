using GoBot.Actions;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.PathFinding
{
    public class Trajectoire
    {
        public List<PointReel> PointsPassage { get; set; }
        public List<Segment> Segments { get; set; }
        public Angle AngleDepart { get; set; }
        public Angle AngleFinal { get; set; }

        public Trajectoire()
        {
            PointsPassage = new List<PointReel>();
            Segments = new List<Segment>();
        }

        public void AjouterPoint(PointReel point)
        {
            PointsPassage.Add(point);

            if (PointsPassage.Count > 1)
                Segments.Add(new Segment(PointsPassage[PointsPassage.Count - 2], PointsPassage[PointsPassage.Count - 1]));
        }

        public List<IActionDuree> ToActions()
        {
            List<IActionDuree> actions = new List<IActionDuree>();
            Angle angle = new Angle(AngleDepart);

            for (int i = 0; i < PointsPassage.Count - 1; i++)
            {
                PointReel c1 = new PointReel(PointsPassage[i].X, PointsPassage[i].Y);
                PointReel c2 = new PointReel(PointsPassage[i + 1].X, PointsPassage[i + 1].Y);

                Position p = new Position(angle, c1);
                Direction traj = Maths.GetDirection(p, c2);

                // Teste si il est plus rapide (moins d'angle à tourner) de se déplacer en marche arrière
                bool inverse = false;
                if (Math.Abs(traj.angle.AngleDegres) > 90)
                {
                    inverse = true;
                    traj.angle = new Angle(traj.angle.AngleDegres - 180);
                }

                if (traj.angle.AngleDegres < 0)
                {
                    actions.Add(new ActionPivot(Robots.GrosRobot, -traj.angle, SensGD.Droite));
                    angle -= traj.angle;
                }
                else if (traj.angle.AngleDegres > 0)
                {
                    actions.Add(new ActionPivot(Robots.GrosRobot, traj.angle, SensGD.Gauche));
                    angle -= traj.angle;
                }

                if (inverse)
                    actions.Add(new ActionRecule(Robots.GrosRobot, (int)(traj.distance)));
                else
                    actions.Add(new ActionAvance(Robots.GrosRobot, (int)(traj.distance)));
            }

            Angle diff = angle - AngleFinal;
            if (Math.Abs(diff.AngleDegres) > 0.2)
            {
                if (diff.AngleDegres < 0)
                    actions.Add(new ActionPivot(Robots.GrosRobot, -diff, SensGD.Droite));
                else
                    actions.Add(new ActionPivot(Robots.GrosRobot, diff, SensGD.Gauche));
            }

            return actions;
        }

        public int Duree
        {
            get
            {
                List<IActionDuree> actions = ToActions();

                int duree = 0;

                foreach (IActionDuree action in actions)
                    duree += action.Duree;

                return duree;
            }
        }

        public void Paint(Graphics g, WorldScale scale)
        {
            Point pointNodePrec = PointsPassage[0];

            using (Pen penR = new Pen(Color.Red, 2), penB = new Pen(Color.White, 4))
            {
                for (int i = 0; i < PointsPassage.Count; i++)
                {
                    Point pointNode = scale.RealToScreenPosition(PointsPassage[i]);
                    if (i >= 1)
                    {
                        g.DrawLine(penB, pointNode, pointNodePrec);
                        g.DrawLine(penR, pointNode, pointNodePrec);
                    }
                    pointNodePrec = pointNode;
                }
                for (int i = 0; i < PointsPassage.Count; i++)
                {
                    Point pointNode = scale.RealToScreenPosition(PointsPassage[i]);
                    g.FillEllipse(Brushes.Red, new Rectangle(pointNode.X - 4, pointNode.Y - 4, 8, 8));
                    g.DrawEllipse(Pens.White, new Rectangle(pointNode.X - 4, pointNode.Y - 4, 8, 8));
                }
            }
        }
    }
}
