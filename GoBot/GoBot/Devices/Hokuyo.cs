using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GoBot.Communications;
using System.Threading;

namespace GoBot.Devices
{
    abstract class Hokuyo
    {
        private const int offsetX = 115;
        private const int offsetY = -87;

        protected int nbPoints;
        protected LidarID lidar;

        private Angle angleMesurable;
        private int offsetPoints;
        private String model;

        public Position Position;

        public Hokuyo(LidarID lidar)
        {
            //trameDetails = "VV\n00P\n";
            this.lidar = lidar;
            semLock = new Semaphore(1, 1);

            switch (lidar)
            {
                case LidarID.ScanSol: model = "URG-04LX-UG01"; break;
            }

            if (model.Contains("UBG-04LX-F01"))//Hokuyo bleu 
            {
                nbPoints = 725;
                angleMesurable = new Angle(240, AnglyeType.Degre);
                offsetPoints = 44;
            }
            else if (model.Contains("URG-04LX-UG01")) //Petit hokuyo
            {
                nbPoints = 725;
                angleMesurable = new Angle(240, AnglyeType.Degre);
                offsetPoints = 44;
            }
            else if (model.Contains("BTM-75LX")) // Grand hokuyo
            {
                nbPoints = 1080;
                angleMesurable = new Angle(270, AnglyeType.Degre);
                offsetPoints = 0;
            }

            Position = new Position();
        }

        public Angle AngleMort
        {
            get { return new Angle(360 - angleMesurable); }
        }

        protected Position PositionDepuisRobot(Position robotPosition)
        {
            return new Position(robotPosition.Angle, new PointReel(robotPosition.Coordonnees.X + offsetX, robotPosition.Coordonnees.Y + offsetY).Rotation(robotPosition.Angle, robotPosition.Coordonnees));
        }

        private Semaphore semLock;
        public List<PointReel> GetMesure()
        {
            List<PointReel> points = new List<PointReel>();

            semLock.WaitOne();
            DateTime debut = DateTime.Now;

            Position refPosition;
            String reponse = GetResultat(out refPosition);
            Position = refPosition;

            //Console.WriteLine((DateTime.Now - debut).Milliseconds.ToString() + "ms");

            try
            {
                if (reponse != "")
                {
                    List<int> mesures = DecodeMessage(reponse);
                    mesures.RemoveRange(0, offsetPoints);
                    points = ValeursToPositions(mesures, false, 10, -1, refPosition);
                }
            }
            catch (Exception) { }

            semLock.Release();

            return points;
        }

        public List<PointReel> GetRawMesure()
        {
            List<PointReel> points = new List<PointReel>();

            semLock.WaitOne();
            DateTime debut = DateTime.Now;

            Position refPosition;
            String reponse = GetResultat(out refPosition);
            
            try
            {
                if (reponse != "")
                {
                    List<int> mesures = DecodeMessage(reponse);
                    mesures.RemoveRange(0, offsetPoints);
                    points = ValeursToPositions(mesures, false, 200, 3000, new Position());
                }
            }
            catch (Exception) { }

            semLock.Release();

            return points;
        }

        protected List<PointReel> ValeursToPositions(List<int> mesures, bool limiteTable, int minDistance, int maxDistance, Position refPosition)
        {
            List<PointReel> positions = new List<PointReel>();
            double stepAngular = angleMesurable.AngleRadiansPositif / (double)mesures.Count;

            for (int i = 0; i < mesures.Count; i++)
            {
                if (mesures[i] > minDistance && (mesures[i] < maxDistance || maxDistance == -1))
                {
                    Angle angle = stepAngular * i;
                    double sin = Math.Sin(angle - refPosition.Angle.AngleRadiansPositif - angleMesurable.AngleRadiansPositif / 2 - Math.PI / 2) * mesures[i];
                    double cos = Math.Cos(angle - refPosition.Angle.AngleRadiansPositif - angleMesurable.AngleRadiansPositif / 2 - Math.PI / 2) * mesures[i];

                    PointReel pos = new PointReel(refPosition.Coordonnees.X - sin, refPosition.Coordonnees.Y - cos);
                    
                    int marge = 20; // Marge en mm de distance de detection à l'exterieur de la table (pour ne pas jeter les mesures de la bordure qui ne collent pas parfaitement)
                    if (!limiteTable || (pos.X > -marge && pos.X < Plateau.Largeur + marge && pos.Y > -marge && pos.Y < Plateau.Hauteur + marge))
                        positions.Add(pos);
                }
            }

            return positions;
        }

        protected abstract String GetResultat(out Position refPosition, int timeout = 500);

        protected List<int> DecodeMessage(String message)
        {
            List<int> values = new List<int>();

            String[] tab = message.Split(new char[] { '\n' });
            Boolean started = false;

            for (int i = 0; i < tab.Length - 2; i++)
            {
                if (tab[i].Length > 64) started = true;

                if (started)
                {
                    for (int j = 0; j < tab[i].Length - 1; j += 2)
                    {
                        int val = DecodeValue(tab[i].Substring(j, 2));
                        values.Add(val);
                    }
                }
            }

            return values;
        }

        protected int DecodeValue(String data)
        {
            int value = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                value <<= 6;
                value &= ~0x3f;
                value |= data[i] - 0x30;
            }
            return value;
        }

        public Angle CalculAngle(Segment segmentPointsProches, double distanceMaxSegment, int nombreMesures)
        {
            double angleSomme = 0;
            int nb = 0;

            for (int i = 0; i < nombreMesures; i++)
            {
                List<PointReel> points = GetMesure();

                if (points.Count > 0)
                {
                    List<PointReel> pointsBordure = points.Where(p => p.Distance(segmentPointsProches) < distanceMaxSegment).ToList();

                    Droite interpol = new Droite(pointsBordure);

                    Plateau.ObstaclesPlateau.Add(interpol);

                    Console.WriteLine(new Angle(Math.Atan(interpol.A), AnglyeType.Radian).AngleDegresPositif - 270);

                    angleSomme += Math.Atan(interpol.A);
                    nb++;
                }
            }

            return new Angle(angleSomme / nb, AnglyeType.Radian);
        }

        public Angle CalculDistanceX(Segment segmentPointsProches, double distanceMaxSegment, int nombreMesures)
        {
            double distanceSomme = 0;
            int nb = 0;

            for (int i = 0; i < nombreMesures; i++)
            {
                List<PointReel> points = GetMesure();

                if (points.Count > 0)
                {
                    List<PointReel> pointsBordure = points.Where(p => p.Distance(segmentPointsProches) < distanceMaxSegment).ToList();

                    if (pointsBordure.Count > 0)
                    {
                        distanceSomme += pointsBordure.Average(p => p.X);
                        nb++;
                    }
                }
            }

            return distanceSomme / nb;
        }

        public Angle CalculDistanceY(int minX, int maxX, int maxY, int nombreMesures)
        {
            double distanceSomme = 0;

            for (int i = 0; i < nombreMesures; i++)
            {
                List<PointReel> points = GetMesure();

                if (points.Count > 0)
                {
                    List<PointReel> pointsBordure = points.Where(p => p.X > minX && p.X < maxX && p.Y < maxY).ToList();

                    if (pointsBordure.Count > 0)
                        distanceSomme += pointsBordure.Average(p => p.Y);
                }
            }

            return distanceSomme / nombreMesures;
        }
    }
}
