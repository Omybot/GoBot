using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs.Formes;
using GoBot.Calculs;

namespace GoBot.IHM
{
    public partial class PanelTable : UserControl
    {
        public PanelTable()
        {
            InitializeComponent();
        }
        Position posGR = new Position();

        void interpreteBalise_PositionEnnemisActualisee(InterpreteurBalise interprete)
        {
            Bitmap bmp = new Bitmap(750, 500);
            Graphics g = Graphics.FromImage(bmp);

            if(boxTable.Checked)
                g.DrawImage(Properties.Resources.table, 0, 0);

            Pen crayonNoir = new Pen(Color.Black);
            Pen crayonRougePointille = new Pen(Color.Red);
            crayonRougePointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Pen crayonBleuPointille = new Pen(Color.Blue);
            crayonBleuPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Pen crayonRougeFin = new Pen(Color.Red);
            Pen crayonBleuFin = new Pen(Color.Blue);
            Pen crayonRouge = new Pen(Color.Red, 3);
            Pen crayonBleu = new Pen(Color.Blue, 3);

            foreach (PointReel p in interprete.PositionsEnnemies)
            {
                if (p != null)
                {
                    g.DrawLine(crayonRouge, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) - 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) + 7));
                    g.DrawLine(crayonRouge, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) + 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) - 7));
                }
            }
            /*foreach (PointReel p in interprete.PositionsAlliees)
            {
                if (p != null)
                {
                    g.DrawLine(crayonBleu, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) - 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) + 7));
                    g.DrawLine(crayonBleu, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) + 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) - 7));
                }
            }*/

            if (boxDroites.Checked)
            {
                foreach (DetectionBalise detection in interprete.DetectionBalisesBas)
                {
                    // Ligne médiane
                    g.DrawLine(crayonBleuPointille,
                        new Point(RealToScreen(detection.Balise.Position.Coordonnees.X), RealToScreen(detection.Balise.Position.Coordonnees.Y)),
                        new Point(RealToScreen(detection.Position.X), RealToScreen(detection.Position.Y)));

                    // Dessin du polygone de détection
                    /*Polygone polygone = InterpreteurBalise.DetectionToPolygone(detection);
                    List<Point> points = new List<Point>();

                    foreach (Segment s in polygone.Cotes)
                    {
                        points.Add(new Point(RealToScreen(s.Debut.X), RealToScreen(s.Debut.Y)));
                        points.Add(new Point(RealToScreen(s.Fin.X), RealToScreen(s.Fin.Y)));
                    }

                    g.DrawPolygon(crayonBleuFin, points.ToArray());

                    g.DrawLine(crayonBleuFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) - 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) + 4));
                    g.DrawLine(crayonBleuFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) + 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) - 4));
                */}

                foreach (DetectionBalise detection in interprete.DetectionBalisesHaut)
                {
                    // Ligne médiane
                    g.DrawLine(crayonRougePointille,
                        new Point(RealToScreen(detection.Balise.Position.Coordonnees.X), RealToScreen(detection.Balise.Position.Coordonnees.Y)),
                        new Point(RealToScreen(detection.Position.X), RealToScreen(detection.Position.Y)));

                    // Dessin du polygone de détection
                    Polygone polygone = InterpreteurBalise.DetectionToPolygone(detection);
                    List<Point> points = new List<Point>();

                    foreach (Segment s in polygone.Cotes)
                    {
                        points.Add(new Point(RealToScreen(s.Debut.X), RealToScreen(s.Debut.Y)));
                        points.Add(new Point(RealToScreen(s.Fin.X), RealToScreen(s.Fin.Y)));
                    }

                    g.DrawPolygon(crayonRougeFin, points.ToArray());
                    g.DrawLine(crayonRougeFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) - 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) + 4));
                    g.DrawLine(crayonRougeFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) + 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) - 4));
                }

                foreach (PointReel p in interprete.Intersections)
                {
                    g.FillEllipse(new SolidBrush(Color.DarkGreen), RealToScreen(p.X) - 3, RealToScreen(p.Y) - 3, 6, 6);
                }

                foreach (PointReel p in interprete.MoyennesDistance)
                {
                    g.FillEllipse(new SolidBrush(Color.Red), RealToScreen(p.X) - 4, RealToScreen(p.Y) - 4, 6, 6);
                }

                foreach (PointReel p in interprete.MoyennesIntersections)
                {
                    g.FillEllipse(new SolidBrush(Color.DarkGreen), RealToScreen(p.X) - 4, RealToScreen(p.Y) - 4, 6, 6);
                }

                foreach (List<PointReel> liste in interprete.RegroupementsDistance)
                {
                    if (liste.Count > 1)
                    {
                        Point[] points = new Point[liste.Count];
                        for (int i = 0; i < liste.Count; i++)
                        {
                            points[i] = new Point(RealToScreen(liste[i].X), RealToScreen(liste[i].Y));
                        }
                        g.DrawPolygon(new Pen(Color.Red), points);
                    }
                }

                foreach (List<PointReel> liste in interprete.RegroupementsIntersections)
                {
                    if (liste.Count > 1)
                    {
                        Point[] points = new Point[liste.Count];
                        for (int i = 0; i < liste.Count; i++)
                        {
                            points[i] = new Point(RealToScreen(liste[i].X), RealToScreen(liste[i].Y));
                        }
                        g.DrawPolygon(new Pen(Color.DarkGreen), points);
                    }
                }

                foreach (List<PointReel> liste in interprete.AssociationPointDistanceIntersection)
                {
                    g.DrawLine(new Pen(Color.DarkGreen), new Point(RealToScreen(liste[0].X), RealToScreen(liste[0].Y)), new Point(RealToScreen(liste[1].X), RealToScreen(liste[1].Y)));
                }
            }

            pictureBoxTable.Image = bmp;

            DessinerPosGR();
        }

        private int RealToScreen(double distance)
        {
            return (int)(distance / 4);
        }

        private void btnAffichage_Click(object sender, EventArgs e)
        {
            Plateau.InterpreteurBalise.PositionEnnemisActualisee += new InterpreteurBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);

            GrosRobot.PositionActualisee += new GrosRobot.PositionActuDelegate(GrosRobot_PositionActualisee);
        }

        void GrosRobot_PositionActualisee(Position position)
        {
            posGR = position;
            
            try
            {
                //Bitmap bmp = (Bitmap)pictureBoxTable.Image;
                Bitmap bmp = new Bitmap(Properties.Resources.table);
                Graphics g = Graphics.FromImage(bmp);

                int xRobot, yRobot;
                double angleRobot;
                xRobot = RealToScreen(GrosRobot.Position.Coordonnees.X);
                yRobot = RealToScreen(GrosRobot.Position.Coordonnees.Y);
                angleRobot = GrosRobot.Position.Angle.AngleRadians + (90 * Math.PI / 360);

                Point p1, p2, p3, p4;
                double miDiago = RealToScreen((int)Math.Round((Math.Sqrt(2 * (Robot.Taille * Robot.Taille))) / 2));
                double sinAngle = Math.Sin(angleRobot);
                double cosAngle = Math.Cos(angleRobot);

                p1 = new Point((int)Math.Round(xRobot + cosAngle * miDiago), (int)Math.Round(yRobot + sinAngle * miDiago));
                p2 = new Point((int)Math.Round(xRobot + sinAngle * miDiago), (int)Math.Round(yRobot - cosAngle * miDiago));
                p3 = new Point((int)Math.Round(xRobot - cosAngle * miDiago), (int)Math.Round(yRobot - sinAngle * miDiago));
                p4 = new Point((int)Math.Round(xRobot - sinAngle * miDiago), (int)Math.Round(yRobot + cosAngle * miDiago));

                Point[] points = new Point[4];
                points[0] = p1;
                points[1] = p2;
                points[2] = p3;
                points[3] = p4;

                g.FillPolygon(new SolidBrush(Plateau.CouleurJ2), points);
                g.DrawPolygon(new Pen(Color.Black), points);

                //Point pointDevant = new Point(Maths.ArCercleir(xRobot - cosAngle * realToScreen(Maths.ArCercleir(Robot.Taille / 2))), Maths.ArCercleir(yRobot - sinAngle * realToScreen(Maths.ArCercleir(Robot.Taille / 2))));
                double angle = GrosRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);
                Point pointDevant = new Point(Maths.ArCercleir(xRobot - cos * RealToScreen(Maths.ArCercleir(Robot.Taille / 2))), Maths.ArCercleir(yRobot - sin * RealToScreen(Maths.ArCercleir(Robot.Taille / 2))));

                g.DrawLine(new Pen(Color.Red), new Point(xRobot, yRobot), pointDevant);

                angle = GrosRobot.Position.Angle.AngleRadians;
                cos = Math.Cos(angle);
                sin = Math.Sin(angle);
                Point pCentre = new Point((int)(GrosRobot.Position.Coordonnees.X + cos * 500), (int)(GrosRobot.Position.Coordonnees.Y + sin * 500));

                g.DrawEllipse(new Pen(Color.Red), RealToScreen(pCentre.X - 500), RealToScreen(pCentre.Y - 500), RealToScreen(1000), RealToScreen(1000));

                pictureBoxTable.Image = bmp;
            }
            catch (Exception)
            {
            }
        }

        public void DessinerPosGR()
        {
            try
            {
                //Bitmap bmp = (Bitmap)pictureBoxTable.Image;
                Bitmap bmp = (Bitmap)pictureBoxTable.Image;// new Bitmap(Properties.Resources.table);
                Graphics g = Graphics.FromImage(bmp);

                int xRobot, yRobot;
                double angleRobot;
                xRobot = RealToScreen(GrosRobot.Position.Coordonnees.X);
                yRobot = RealToScreen(GrosRobot.Position.Coordonnees.Y);
                angleRobot = GrosRobot.Position.Angle.AngleRadians + (90 * Math.PI / 360);

                Point p1, p2, p3, p4;
                double miDiago = RealToScreen((int)Math.Round((Math.Sqrt(2 * (Robot.Taille * Robot.Taille))) / 2));
                double sinAngle = Math.Sin(angleRobot);
                double cosAngle = Math.Cos(angleRobot);

                p1 = new Point((int)Math.Round(xRobot + cosAngle * miDiago), (int)Math.Round(yRobot + sinAngle * miDiago));
                p2 = new Point((int)Math.Round(xRobot + sinAngle * miDiago), (int)Math.Round(yRobot - cosAngle * miDiago));
                p3 = new Point((int)Math.Round(xRobot - cosAngle * miDiago), (int)Math.Round(yRobot - sinAngle * miDiago));
                p4 = new Point((int)Math.Round(xRobot - sinAngle * miDiago), (int)Math.Round(yRobot + cosAngle * miDiago));

                Point[] points = new Point[4];
                points[0] = p1;
                points[1] = p2;
                points[2] = p3;
                points[3] = p4;

                g.FillPolygon(new SolidBrush(Plateau.CouleurJ2), points);
                g.DrawPolygon(new Pen(Color.Black), points);

                //Point pointDevant = new Point(Maths.ArCercleir(xRobot - cosAngle * realToScreen(Maths.ArCercleir(Robot.Taille / 2))), Maths.ArCercleir(yRobot - sinAngle * realToScreen(Maths.ArCercleir(Robot.Taille / 2))));
                double angle = GrosRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);
                Point pointDevant = new Point(Maths.ArCercleir(xRobot - cos * RealToScreen(Maths.ArCercleir(Robot.Taille / 2))), Maths.ArCercleir(yRobot - sin * RealToScreen(Maths.ArCercleir(Robot.Taille / 2))));

                g.DrawLine(new Pen(Color.Red), new Point(xRobot, yRobot), pointDevant);

                angle = GrosRobot.Position.Angle.AngleRadians;
                cos = Math.Cos(angle);
                sin = Math.Sin(angle);
                Point pCentre = new Point((int)(GrosRobot.Position.Coordonnees.X + cos * 500), (int)(GrosRobot.Position.Coordonnees.Y + sin * 500));

                g.DrawEllipse(new Pen(Color.Red), RealToScreen(pCentre.X - 500), RealToScreen(pCentre.Y - 500), RealToScreen(1000), RealToScreen(1000));

                pictureBoxTable.Image = bmp;
            }
            catch (Exception)
            {
            }
        }
    }
}
