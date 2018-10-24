using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public static class Matrix
    {
        public static T[,] Transpose<T>(T[,] source)
        {
            int rowsCount = source.GetLength(0);
            int colsCount = source.GetLength(1);

            T[,] target = new T[colsCount, rowsCount];

            for (int iRow = 0; iRow < rowsCount; iRow++)
                for (int iCol = 0; iCol < colsCount; iCol++)
                    target[iCol, iRow] = source[iRow, iCol];

            return target;
        }

        public static double[,] Multiply(double[,] m1, double[,] m2)
        {
            int rowsCount1 = m1.GetLength(0);
            int colsCount1 = m1.GetLength(1);
            int colsCount2 = m2.GetLength(1);

            double[,] res = new double[rowsCount1, rowsCount1];

            for (int iRow = 0; iRow < rowsCount1; iRow++)
                for (int iCol2 = 0; iCol2 < colsCount2; iCol2++)
                    for (int iCol1 = 0; iCol1 < colsCount1; iCol1++)
                        res[iRow, iCol2] += m1[iRow, iCol1] * m2[iCol1, iCol2];

            return res;
        }

        public static double[] Multiply(double[,] m1, double[] m2)
        {
            double[] res = new double[m1.GetLength(0)];

            for (int iRow = 0; iRow < res.Length; iRow++)
                for (int iCol = 0; iCol < m2.Length; iCol++)
                    res[iRow] += m1[iRow, iCol] * m2[iCol];

            return res;
        }

        public static double Determinant2x2(double m00, double m01, double m10, double m11)
        {
            return ((m00 * m11) - (m10 * m01));
        }

        public static double Determinant2x2(double[,] m)
        {
            return Determinant2x2(m[0, 0], m[0, 1], m[1, 0], m[1, 1]);
        }

        public static double Determinant3x3(double[,] m)
        {
            var a = m[0, 0] * Determinant2x2(m[1, 1], m[1, 2], m[2, 1], m[2, 2]);
            var b = m[0, 1] * Determinant2x2(m[1, 0], m[1, 2], m[2, 0], m[2, 2]);
            var c = m[0, 2] * Determinant2x2(m[1, 0], m[1, 1], m[2, 0], m[2, 1]);

            return a - b + c;
        }

        public static double[,] Inverse3x3(double[,] m)
        {
            double d = (1 / Determinant3x3(m));

            return new double[3, 3]
            {
                {
                    +Determinant2x2(m[1,1], m[1,2], m[2,1], m[2,2]) * d,//[0,0]
				    -Determinant2x2(m[0,1], m[0,2], m[2,1], m[2,2]) * d,//[1,0]
				    +Determinant2x2(m[0,1], m[0,2], m[1,1], m[1,2]) * d,//[2,0]
			    },
                {
                    -Determinant2x2(m[1,0], m[1,2], m[2,0], m[2,2]) * d,//[0,1]
				    +Determinant2x2(m[0,0], m[0,2], m[2,0], m[2,2]) * d,//[1,1]
				    -Determinant2x2(m[0,0], m[0,2], m[1,0], m[1,2]) * d,//[2,1]
			    },
                {
                    +Determinant2x2(m[1,0], m[1,1], m[2,0], m[2,1]) * d,//[0,2]
				    -Determinant2x2(m[0,0], m[0,1], m[2,0], m[2,1]) * d,//[1,2]
				    +Determinant2x2(m[0,0], m[0,1], m[1,0], m[1,1]) * d,//[2,2]
			    }
            };
        }
    }
}
