using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public static class ListDoubleExtensions
    {

        /// <summary>
        /// Retourne l'écart-type d'une liste de valeurs décimales
        /// </summary>
        /// <param name="list">Valeurs décimales</param>
        /// <returns>Ecart-type</returns>
        public static double StandardDeviation(this List<double> list)
        {
            if (list.Count > 0)
            {
                double avg = list.Average();
                double diffs = 0;

                foreach (double val in list)
                    diffs += (val - avg) * (val - avg);

                diffs /= list.Count;
                diffs = Math.Sqrt(diffs);

                return diffs;
            }
            else
                return 0;
        }
    }
}
