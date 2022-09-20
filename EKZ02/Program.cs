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
            int n;      // Общее количество работ по проекту          
            // (количество ребер ориентированного графа).
            int[] i = new int[20];  // Вектор-пара, представляющая k-ю работу,    
            int[] j = new int[20];  // которая понимается как стрелка, связыва-   
            // ющая событие i[k] с событием j[k]          
            // Граф задан массивом ребер:                 
            // (i[0],j[0]),(i[1],j[1]),...,(i[n-1],j[n-1])    
            // Должно быть выполнено:  
            // i[0]=1, i[k]<i[k+1], i[k]<j[k].
            int[] dij = new int[20];// dij[k] - продолжительность k-й операции.
            int[] s1 = new int[20]; // s1[k] - самый ранний срок начала k-й операции.
            int[] s2 = new int[20]; // s2[k] - самый поздний срок начала k-й.
            int[] f1 = new int[20]; // f1[k] - самый ранний срок завершения k-й.
            int[] f2 = new int[20]; // f2[k] - самый поздний срок завершения k-й операции.
            int[] tf = new int[20]; // tf[k] - полный резерв времени k-й операции.
            int[] ff = new int[20]; // ff[k] - свободный резерв времени k-й операции.
            int k;      // Параметр цикла.

            Console.Write("Введите количество работ: ");
            n = int.Parse(Console.ReadLine());
            for (k = 0; k < n; k++)
            {
                Console.Write("Введите начало, конец дуги(из таблицы) и продолжительность через Enter: \n");
                i[k] = int.Parse(Console.ReadLine());
                j[k] = int.Parse(Console.ReadLine());
                dij[k] = int.Parse(Console.ReadLine());
            }
            Critput(n, i, j, dij, s1, s2, f1, f2, tf, ff);
            //Вывод результатов.
            Console.Write("Самый ранний срок начала     : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", s1[k]);
            Console.Write("Самый поздний срок начала    : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", s2[k]);
            Console.Write("Самый ранний срок завершения : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", f1[k]);
            Console.Write("Самый поздний срок завершения : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", f2[k]);
            Console.Write("Свободный резерв времени     : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", ff[k]);
            Console.Write("Полный резерв времени        : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", tf[k]);
            // Определение  критического  пути. Критический путь задается 
            // стрелками, соединяющими события, для которых полный резерв
            // времени равен нулю.
            Console.Write("Критический путь: 1 ");
            for (k = 0; k < n; k++)
                if (tf[k] == 0) Console.Write("{0} ", j[k]);
             Console.ReadKey();
        }
        public static void Critput(int n, int[] i, int[] j, int[] dij,
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
