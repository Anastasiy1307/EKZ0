using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZ02
{
    public class Class1
    {
        /// <summary>
        /// Метод определяющий критический путь
        /// </summary>
        /// <param name="n"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="dk"></param>
        /// <param name="rs"></param>
        /// <param name="ps"></param>
        /// <param name="rk"></param>
        /// <param name="pk"></param>
        /// <param name="rv"></param>
        /// <param name="srv"></param>
        public static void Critput(int n, int[] i, int[] j, int[] dk,
                       int[] rs, int[] ps, int[] rk, int[] pk, int[] rv, int[] srv)
        {

            int k, index, max, min;
            int[] ti = new int[20];
            int[] te = new int[20];

            index = 0;
            for (k = 0; k < n; k++)
            {
                if (i[k] == index + 1)
                {
                    index = i[k];
                    ti[k] = 0; te[k] = 9999;

                }
            }

            for (k = 0; k < n; k++)
            {
                max = ti[i[k]] + dk[k];
                if (ti[j[k]] < max)
                {
                    ti[j[k]] = max;

                }
            }

            te[j[n - 1]] = ti[j[n - 1]];
            for (k = n - 1; k >= 0; k--)
            {
                min = te[j[k]] - dk[k];
                if (te[i[k]] > min)
                {
                    te[i[k]] = min;
                }
            }

            for (k = 0; k < n; k++)
            {
                rs[k] = ti[i[k]]; rk[k] = rs[k] + dk[k];
                pk[k] = te[j[k]]; ps[k] = pk[k] - dk[k];
                rv[k] = pk[k] - rk[k]; srv[k] = ti[j[k]] - rk[k];

            }
        }
    }
}

