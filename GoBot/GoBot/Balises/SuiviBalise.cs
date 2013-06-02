using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Balises
{
    class PositionTemporelle
    {
        public DateTime Date { get; set; }
        public PointReel Position { get; set; }

        public PositionTemporelle(DateTime date, PointReel position)
        {
            Date = date;
            Position = position;
        }
    }

    public static class SuiviBalise
    {
        public static int NombreMaxBalises { get; set; }

        public static List<PointReel> PositionsEnnemies { get; set; }
        public static List<PointReel> VecteursPositionsEnnemies { get; set; }
        private static List<List<PositionTemporelle>> PositionsTemporelles { get; set; }
        private static List<DateTime> DatePositionsBalises { get; set; }
        private const double deplacementMaxSeconde = 4000;

        static SuiviBalise()
        {
            NombreMaxBalises = 2;
            PositionsEnnemies = new List<PointReel>();
            PositionsTemporelles = new List<List<PositionTemporelle>>();
            VecteursPositionsEnnemies = new List<PointReel>();
        }

        public static void MajPositions(List<PointReel> detections, bool force = false)
        {
            if (force && detections.Count <= NombreMaxBalises)
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
                    VecteursPositionsEnnemies.Add(new PointReel());
                }
            }
            else
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

            CalculVecteurs();
            PositionEnnemisActualisee();
        }

        private static void CalculVecteurs()
        {
            for(int i = 0; i < PositionsEnnemies.Count; i++)
            {
                List<PointReel> deplacements = new List<PointReel>();

                for (int j = 1; j < PositionsTemporelles[i].Count; j++)
                {
                    double dx = PositionsTemporelles[i][j].Position.X - PositionsTemporelles[i][j - 1].Position.X;
                    double dy = PositionsTemporelles[i][j].Position.Y - PositionsTemporelles[i][j - 1].Position.Y;

                    TimeSpan t = PositionsTemporelles[i][j].Date - PositionsTemporelles[i][j - 1].Date;
                    if(t.TotalMilliseconds > 0)
                        deplacements.Add(new PointReel(dx * 1000.0 / t.TotalMilliseconds, dy * 1000.0 / t.TotalMilliseconds));
                }

                double x = 0, y = 0;
                foreach (PointReel p in deplacements)
                {
                    x += p.X;
                    y += p.Y;
                }

                if (deplacements.Count > 0)
                {
                    x /= deplacements.Count;
                    y /= deplacements.Count;
                }

                VecteursPositionsEnnemies[i] = new PointReel(x, y);
            }
        }

        //Déclaration du délégué pour l’évènement de position des ennemis
        public delegate void PositionEnnemisDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public static event PositionEnnemisDelegate PositionEnnemisActualisee;
    }
}
