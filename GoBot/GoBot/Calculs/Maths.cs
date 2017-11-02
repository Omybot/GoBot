using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Calculs
{
    public struct Direction
    {
        public Angle angle;
        public double distance;
    }

    class Maths
    {
        /// <summary>
        /// Retourne la direction (angle et distance) à suivre pour arriver à un point donné en partant d'une corrdonnée précise (et par défaut, angle de 0°)
        /// </summary>
        /// <param name="startPoint">Coordonnées de départ</param>
        /// <param name="endPoint">Coordonnées d'arrivée</param>
        /// <returns>Direction à suivre</returns>
        public static Direction GetDirection(RealPoint startPoint, RealPoint endPoint)
        {
            Position startPosition = new Position(0, startPoint);
            return GetDirection(startPosition, endPoint);
        }

        /// <summary>
        ///  Retourne la direction (angle et distance) à suivre pour arriver à un point donné en partant d'une position précise (coordonnées et angle)
        /// </summary>
        /// <param name="startPosition">Position de départ</param>
        /// <param name="endPoint">Coordonnées d'arrivée</param>
        /// <returns>Direction à suivre</returns>
        public static Direction GetDirection(Position startPosition, RealPoint endPoint)
        {
            Direction result = new Direction();

            result.distance = startPosition.Coordinates.Distance(endPoint);

            double angleCalc = 0;

            // Deux points sur le même axe vertical : 90° ou -90° selon le point le plus haut
            if (endPoint.X == startPosition.Coordinates.X)
            {
                angleCalc = Math.PI / 2;
                if (endPoint.Y > startPosition.Coordinates.Y)
                    angleCalc = -angleCalc;
            }
            // Deux points sur le même axe horizontal : 0° ou 180° selon le point le plus à gauche
            else if (endPoint.Y == startPosition.Coordinates.Y)
            {
                angleCalc = Math.PI;
                if (endPoint.X > startPosition.Coordinates.X)
                    angleCalc = 0;
            }
            // Cas général : Calcul de l'angle
            else
            {
                angleCalc = Math.Acos((endPoint.X - startPosition.Coordinates.X) / result.distance);

                if (endPoint.Y > startPosition.Coordinates.Y)
                    angleCalc = -angleCalc;
            }

            // Prendre en compte l'angle initial
            Angle angle = new Angle(angleCalc, AnglyeType.Radian);
            angle = angle + startPosition.Angle;

            result.angle = angle;

            return result;
        }

        /// <summary>
        /// Retourne les coordonnées d'une position initiale modifiée par une prise de direction
        /// </summary>
        /// <param name="startPosition">Position de départ</param>
        /// <param name="direction">Direction suivie</param>
        /// <returns>Coordonnées du point</returns>
        public static Position GetCoordonnees(Position startPosition, Direction direction)
        {
            Angle endAngle = direction.angle + startPosition.Angle;

            double x = startPosition.Coordinates.X + Math.Cos(endAngle.InRadians) * direction.distance;
            double y = startPosition.Coordinates.Y + Math.Sin(endAngle.InRadians) * direction.distance;

            return new Position(endAngle, new RealPoint(x, y));
        }
    }
}
