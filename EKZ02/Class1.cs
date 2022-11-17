using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZ02
{
    public class CalculatingTheCriticalPath
    {
        public static void СriticalPath(int n, int[] i, int[] j, int[] Vrem_zatr,
                       int[] Ranniy_srok_nach, int[] Pozdniy_srok_nach, int[] Ranniy_srok_zaver, int[] Pozdniy_srok_zaver, int[] Rezerv_vrem, int[] Svob_rezerv_vrem)
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
                max = ti[i[k]] + Vrem_zatr[k];
                if (ti[j[k]] < max)
                {      
                    ti[j[k]] = max;

                }
            }

            te[j[n - 1]] = ti[j[n - 1]];
            for (k = n - 1; k >= 0; k--)
            {
                min = te[j[k]] - Vrem_zatr[k];
                if (te[i[k]] > min)
                {
                    te[i[k]] = min;
                }
            }

            for (k = 0; k < n; k++)
            {
                Ranniy_srok_nach[k] = ti[i[k]]; Ranniy_srok_zaver[k] = Ranniy_srok_nach[k] + Vrem_zatr[k];
                Pozdniy_srok_zaver[k] = te[j[k]]; Pozdniy_srok_nach[k] = Pozdniy_srok_zaver[k] - Vrem_zatr[k];
                Rezerv_vrem[k] = Pozdniy_srok_zaver[k] - Ranniy_srok_zaver[k]; Svob_rezerv_vrem[k] = ti[j[k]] - Ranniy_srok_zaver[k];

            }
        }
    }
}

