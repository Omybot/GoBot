using GoBot.Actions;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace GoBot.PathFinding
{
    public class Trajectory
    {
        List<RealPoint> points;
        List<Segment> lines;

        /// <summary>
        /// Liste des points de passage de la trajectoire
        /// </summary>
        public ReadOnlyCollection<RealPoint> Points
        {
            get
            {
                return points.AsReadOnly();
            }
        }

        /// <summary>
        /// Liste des segments de la trajectoire
        /// </summary>
        public ReadOnlyCollection<Segment> Lines
        {
            get
            {
                return lines.AsReadOnly();
            }
        }

        public Angle StartAngle { get; set; }
        public Angle EndAngle { get; set; }

        public Trajectory()
        {
            points = new List<RealPoint>();
            lines = new List<Segment>();
        }

        /// <summary>
        /// Ajoute un point de passage à la trajectoire
        /// </summary>
        /// <param name="point">Point à ajouter à la trajectoire</param>
        public void AddPoint(RealPoint point)
        {
            points.Add(point);

            if (Points.Count > 1)
                lines.Add(new Segment(Points[Points.Count - 2], Points[Points.Count - 1]));
        }

        /// <summary>
        /// Convertit la trajectoire en suite d'actions de déplacement à effectuer pour suivre la trajectoire
        /// </summary>
        /// <returns>Liste des déplacements correspondant</returns>
        public List<ITimeableAction> ConvertToActions(Robot robot)
        {
            List<ITimeableAction> actions = new List<ITimeableAction>();
            Angle angle = new Angle(StartAngle);

            for (int i = 0; i < Points.Count - 1; i++)
            {
                RealPoint c1 = new RealPoint(Points[i].X, Points[i].Y);
                RealPoint c2 = new RealPoint(Points[i + 1].X, Points[i + 1].Y);

                Position p = new Position(angle, c1);
                Direction traj = Maths.GetDirection(p, c2);

                // Teste si il est plus rapide (moins d'angle à tourner) de se déplacer en marche arrière avant la fin
                bool inverse = false;

                if (i < Points.Count - 2)
                {
                    inverse = Math.Abs(traj.angle.InDegrees) > 90;
                }
                else
                {
                    // On cherche à minimiser le tout dernier angle quand on fait l'avant dernier
                    Angle finalAngle = angle - traj.angle;
                    inverse = Math.Abs(finalAngle - EndAngle) > 90;
                }

                if(inverse)
                    traj.angle = new Angle(traj.angle.InDegrees - 180);

                if (traj.angle.InDegrees < 0)
                {
                    actions.Add(new ActionPivot(robot, -traj.angle, SensGD.Droite));
                    angle -= traj.angle;
                }
                else if (traj.angle.InDegrees > 0)
                {
                    actions.Add(new ActionPivot(robot, traj.angle, SensGD.Gauche));
                    angle -= traj.angle;
                }

                if (inverse)
                    actions.Add(new ActionRecule(robot, (int)(traj.distance)));
                else
                    actions.Add(new ActionAvance(robot, (int)(traj.distance)));
            }

            Angle diff = angle - EndAngle;
            if (Math.Abs(diff.InDegrees) > 0.2)
            {
                if (diff.InDegrees < 0)
                    actions.Add(new ActionPivot(robot, -diff, SensGD.Droite));
                else
                    actions.Add(new ActionPivot(robot, diff, SensGD.Gauche));
            }

            return actions;
        }

        public TimeSpan GetDuration(Robot robot)
        {
            List<ITimeableAction> actions = ConvertToActions(robot);

            TimeSpan duration = new TimeSpan();

            foreach (ITimeableAction action in actions)
                duration += action.Duration;

            return duration;
        }

        public void Paint(Graphics g, WorldScale scale)
        {
            Point previousPoint = Points[0];

            using (Pen redPen = new Pen(Color.Red, 2), whitePen = new Pen(Color.White, 4))
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    Point pointNode = scale.RealToScreenPosition(Points[i]);
                    if (i >= 1)
                    {
                        g.DrawLine(whitePen, pointNode, previousPoint);
                        g.DrawLine(redPen, pointNode, previousPoint);
                    }
                    previousPoint = pointNode;
                }
                for (int i = 0; i < Points.Count; i++)
                {
                    Point point = scale.RealToScreenPosition(Points[i]);
                    g.FillEllipse(Brushes.Red, new Rectangle(point.X - 4, point.Y - 4, 8, 8));
                    g.DrawEllipse(Pens.White, new Rectangle(point.X - 4, point.Y - 4, 8, 8));
                }
            }
        }

        public void RemoveFirst()
        {
            points.RemoveAt(0);
            lines.RemoveAt(0);
        }
    }
}
