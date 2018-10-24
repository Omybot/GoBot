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
        /// <param name="values">Valeurs décimales</param>
        /// <returns>Ecart-type</returns>
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            if (values.Count() > 0)
            {
                double avg = values.Average();
                double diffs = 0;

                foreach (double val in values)
                    diffs += (val - avg) * (val - avg);

                diffs /= values.Count();
                diffs = Math.Sqrt(diffs);

                return diffs;
            }
            else
                return 0;
        }
    }
}
