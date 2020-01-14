using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    public class AsserStats
    {
        /// <summary>
        /// Liste des distances parcourures en marche avant
        /// </summary>
        public List<int> ForwardMoves { get; protected set; }

        /// <summary>
        /// Liste des distances parcourures en marche arrière
        /// </summary>
        public List<int> BackwardMoves { get; protected set; }

        /// <summary>
        /// Liste des angle parcourus en pivot gauche
        /// </summary>
        public List<AngleDelta> LeftRotations { get; protected set; }

        /// <summary>
        /// Liste des angle parcourus en pivot droit
        /// </summary>
        public List<AngleDelta> RightsRotations { get; protected set; }

        public AsserStats()
        {
            ForwardMoves = new List<int>();
            BackwardMoves = new List<int>();
            LeftRotations = new List<AngleDelta>();
            RightsRotations = new List<AngleDelta>();
        }

        public TimeSpan CalculDuration(SpeedConfig config, Robot robot)
        {
            TimeSpan totalDuration = new TimeSpan();

            foreach (int dist in ForwardMoves.Union(BackwardMoves))
                totalDuration += config.LineDuration(dist);
            foreach (AngleDelta ang in LeftRotations.Union(RightsRotations))
                totalDuration += config.PivotDuration(ang, robot.WheelSpacing);

            return totalDuration;
        }
    }
}
