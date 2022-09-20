using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZ02
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public static void Critical_Path(int n, int[] i, int[] j, int[] dij,
                       int[] s1, int[] s2, int[] f1, int[] f2, int[] tf, int[] ff)
        {
            int k, index, max, min;
            int[] ti = new int[20];
            int[] te = new int[20];

            index = 0;
            for (k = 0; k < n; k++)
            {
                if (i[k] == index + 1) index = i[k];
                ti[k] = 0; te[k] = 9999;
            }

            for (k = 0; k < n; k++)
            {
                max = ti[i[k]] + dij[k];
                if (ti[j[k]] < max) ti[j[k]] = max;
            }

            te[j[n - 1]] = ti[j[n - 1]];
            for (k = n - 1; k >= 0; k--)
            {
                min = te[j[k]] - dij[k];
                if (te[i[k]] > min) te[i[k]] = min;
            }

            for (k = 0; k < n; k++)
            {
                s1[k] = ti[i[k]]; f1[k] = s1[k] + dij[k];
                f2[k] = te[j[k]]; s2[k] = f2[k] - dij[k];
                tf[k] = f2[k] - f1[k]; ff[k] = ti[j[k]] - f1[k];
            }
        }
    }
}
