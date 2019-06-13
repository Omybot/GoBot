using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry.Shapes;

namespace GoBot.Beacons
{
    /// <summary>
    /// Association d'une position dans un plan à une date d'acquisition
    /// </summary>
    class PositionTemporelle
    {
        /// <summary>
        /// Date d'acquisition de la position
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Position mesurée
        /// </summary>
        public RealPoint Position { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="date">Date d'acquisition de la position</param>
        /// <param name="position">Position mesurée</param>
        public PositionTemporelle(DateTime date, RealPoint position)
        {
            Date = date;
            Position = position;
        }
    }

    /// <summary>
    /// Petmet d'effectuer un tracking sur les différentes positions ennemies calculées par les balises.
    /// </summary>
    public static class SuiviBalise
    {
        // Nombre de balises à suivre
        public static int NombreMaxBalises { get; set; }

        public static List<RealPoint> PositionsEnnemies { get; set; }
        public static List<RealPoint> VecteursPositionsEnnemies { get; set; }
        private static List<List<PositionTemporelle>> PositionsTemporelles { get; set; }
        private static List<DateTime> DatePositionsBalises { get; set; }
        private const double deplacementMaxSeconde = 4000;
        
        public static void Init()
        {
            NombreMaxBalises = 2;
            PositionsEnnemies = new List<RealPoint>();
            PositionsTemporelles = new List<List<PositionTemporelle>>();
            VecteursPositionsEnnemies = new List<RealPoint>();
        }

        public static void MajPositions(List<RealPoint> detections, bool force = false)
        {
            //if (detections.Count < NombreMaxBalises && (detections.Count == 0 || detections.Count < PositionsEnnemies.Count))
            //    return;

            //if (force && detections.Count <= NombreMaxBalises)
            {
                VecteursPositionsEnnemies.Clear();
                PositionsEnnemies.Clear();
                PositionsEnnemies.AddRange(detections);

                DatePositionsBalises = new List<DateTime>();
                PositionsTemporelles.Clear();
                for (int i = 0; i < PositionsEnnemies.Count; i++)
                {
                    DatePositionsBalises.Add(DateTime.Now);
                    PositionsTemporelles.Add(new List<PositionTemporelle>());
                    PositionsTemporelles[i].Add(new PositionTemporelle(DateTime.Now, PositionsEnnemies[i]));
                    VecteursPositionsEnnemies.Add(new RealPoint());
                }
            }
            /*else
            {
                for (int i = 0; i < PositionsEnnemies.Count; i++)
                {
                    int plusProche = 0;
                    for(int j = 1; j < detections.Count; j++)
                    {
                        if (PositionsEnnemies[i].Distance(detections[j]) < PositionsEnnemies[i].Distance(detections[plusProche]))
                        {
                            plusProche = i;
                        }
                    }

                    if (PositionsEnnemies[i].Distance(detections[plusProche]) < deplacementMaxSeconde / 1000.0 * (DateTime.Now - DatePositionsBalises[i]).TotalMilliseconds)
                    {
                        PositionsEnnemies[i] = detections[plusProche];
                        DatePositionsBalises[i] = DateTime.Now;

                        PositionsTemporelles[i].Add(new PositionTemporelle(DateTime.Now, detections[plusProche]));

                        if (PositionsTemporelles[i].Count > 7)
                            PositionsTemporelles[i].RemoveAt(0);
                    }
                }

            }

            CalculVecteurs();*/
            if (PositionEnnemisActualisee != null)
                PositionEnnemisActualisee();
        }

        private static void CalculVecteurs()
        {
            for(int i = 0; i < PositionsEnnemies.Count; i++)
            {
                List<RealPoint> deplacements = new List<RealPoint>();

                for (int j = 1; j < PositionsTemporelles[i].Count; j++)
                {
                    double dx = PositionsTemporelles[i][j].Position.X - PositionsTemporelles[i][j - 1].Position.X;
                    double dy = PositionsTemporelles[i][j].Position.Y - PositionsTemporelles[i][j - 1].Position.Y;

                    TimeSpan t = PositionsTemporelles[i][j].Date - PositionsTemporelles[i][j - 1].Date;
                    if(t.TotalMilliseconds > 0)
                        deplacements.Add(new RealPoint(dx * 1000.0 / t.TotalMilliseconds, dy * 1000.0 / t.TotalMilliseconds));
                }

                double x = 0, y = 0;
                foreach (RealPoint p in deplacements)
                {
                    x += p.X;
                    y += p.Y;
                }

                if (deplacements.Count > 0)
                {
                    x /= deplacements.Count;
                    y /= deplacements.Count;
                }

                VecteursPositionsEnnemies[i] = new RealPoint(x, y);
            }
        }

        //Déclaration du délégué pour l’évènement de position des ennemis
        public delegate void PositionEnnemisDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public static event PositionEnnemisDelegate PositionEnnemisActualisee;
    }
}
