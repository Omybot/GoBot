using GoBot.Actions;
using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace GoBot.PathFinding
{
    public class Trajectory
    {
        List<RealPoint> _points;
        List<Segment> _lines;

        AnglePosition _startAngle, _endAngle;

        /// <summary>
        /// Liste des points de passage de la trajectoire
        /// </summary>
        public ReadOnlyCollection<RealPoint> Points { get { return _points.AsReadOnly(); } }

        /// <summary>
        /// Liste des segments de la trajectoire
        /// </summary>
        public ReadOnlyCollection<Segment> Lines { get { return _lines.AsReadOnly(); } }

        public AnglePosition StartAngle { get { return _startAngle; } set { _startAngle = value; } }
        public AnglePosition EndAngle { get { return _endAngle; } set { _endAngle = value; } }

        public Trajectory()
        {
            _points = new List<RealPoint>();
            _lines = new List<Segment>();
        }

        /// <summary>
        /// Ajoute un point de passage à la trajectoire
        /// </summary>
        /// <param name="point">Point à ajouter à la trajectoire</param>
        public void AddPoint(RealPoint point)
        {
            _points.Add(point);

            if (_points.Count > 1)
                _lines.Add(new Segment(Points[Points.Count - 2], Points[Points.Count - 1]));
        }

        /// <summary>
        /// Convertit la trajectoire en suite d'actions de déplacement à effectuer pour suivre la trajectoire
        /// </summary>
        /// <returns>Liste des déplacements correspondant</returns>
        public List<ITimeableAction> ConvertToActions(Robot robot)
        {
            List<ITimeableAction> actions = new List<ITimeableAction>();
            AnglePosition angle = _startAngle;

            for (int i = 0; i < Points.Count - 1; i++)
            {
                RealPoint c1 = new RealPoint(Points[i].X, Points[i].Y);
                RealPoint c2 = new RealPoint(Points[i + 1].X, Points[i + 1].Y);

                Position p = new Position(angle, c1);
                Direction traj = Maths.GetDirection(p, c2);

                // Teste si il est plus rapide (moins d'angle à tourner) de se déplacer en marche arrière avant la fin
                bool inverse = false;

                if (i < _points.Count - 2)
                {
                    inverse = Math.Abs(traj.angle) > 90;
                }
                else
                {
                    // On cherche à minimiser le tout dernier angle quand on fait l'avant dernier
                    AnglePosition finalAngle = angle - traj.angle;
                    inverse = Math.Abs(finalAngle - _endAngle) > 90;
                }

                if (inverse)
                    traj.angle = new AngleDelta(traj.angle - 180);

                traj.angle.Modulo();

                if (traj.angle < 0)
                {
                    actions.Add(new ActionPivot(robot, -traj.angle, SensGD.Droite));
                    angle -= traj.angle;
                }
                else if (traj.angle > 0)
                {
                    actions.Add(new ActionPivot(robot, traj.angle, SensGD.Gauche));
                    angle -= traj.angle;
                }

                if (inverse)
                    actions.Add(new ActionRecule(robot, (int)(traj.distance)));
                else
                    actions.Add(new ActionAvance(robot, (int)(traj.distance)));
            }

            AngleDelta diff = angle - _endAngle;
            if (Math.Abs(diff) > 0.2) // Angle minimal en dessous duquel on considère qu'il n'y a pas besoin d'effectuer le pivot
            {
                if (diff < 0)
                    actions.Add(new ActionPivot(robot, -diff, SensGD.Droite));
                else
                    actions.Add(new ActionPivot(robot, diff, SensGD.Gauche));
            }

            return actions;
        }

        public TimeSpan GetDuration(Robot robot)
        {
            return new TimeSpan(ConvertToActions(robot).Sum(o => o.Duration.Ticks));
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
            _points.RemoveAt(0);
            _lines.RemoveAt(0);
        }
    }
}
