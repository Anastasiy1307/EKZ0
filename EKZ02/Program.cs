using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZ02
{
    public class Program
    {



        public static void Main(string[] args)
        {
            int n;      //переменная отвечающая за количество работ     
            int[] i = new int[20];
            int[] j = new int[20];
            int[] dk = new int[20];//время затрачивающееся на выполнение операции
            int[] rs = new int[20]; //ранний срок начала
            int[] ps = new int[20]; //поздний срок
            int[] rk = new int[20]; //ранний срок завершения
            int[] pk = new int[20]; //поздний срок завершения 
            int[] rv = new int[20]; //резерв времени
            int[] srv = new int[20]; //свободный резерв времени
            int k;
            TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
            new TextWriterTraceListener(@"D:\1.txt"),  //Путь файла
            new TextWriterTraceListener(Console.Out)};

            Console.Write("Введите количество работ: ");
            n = int.Parse(Console.ReadLine());//ввод количества работ
            for (k = 0; k < n; k++)
            {
                Console.Write("Введите начало, конец дуги(из таблицы) и продолжительность (через Enter): \n");
                i[k] = int.Parse(Console.ReadLine());
                j[k] = int.Parse(Console.ReadLine());
                dk[k] = int.Parse(Console.ReadLine());
            }

            Class1.Critput(n, i, j, dk, rs, ps, rk, pk, rv, srv);

            Console.Write("Самый ранний срок начала     : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", rs[k]);//Вывод результатов
            Console.Write("Самый поздний срок начала    : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", ps[k]);
            Console.Write("Самый ранний срок завершения : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", rk[k]);
            Console.Write("Самый поздний срок завершения : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", pk[k]);
            Console.Write("Свободный резерв времени     : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", srv[k]);
            Console.Write("Полный резерв времени        : ");
            for (k = 0; k < n; k++) Console.Write("{0} \n", rv[k]);

            Console.Write("Критический путь: 1 ");
            for (k = 0; k < n; k++)
                if (srv[k] == 0) { Console.Write("{0} ", j[k]); }
            Debug.Listeners.AddRange(listeners);
            Debug.WriteLine(Convert.ToString(j[k])); // Сообщение
            Debug.Flush();
            Console.ReadKey();
        }

    }
    }

