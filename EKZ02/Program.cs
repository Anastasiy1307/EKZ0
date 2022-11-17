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
            try
            {
                int n;      //переменная отвечающая за количество работ     
                int[] i = new int[20];
                int[] j = new int[20];
                int[] Vrem_zatr = new int[20];//время затрачивающееся на выполнение операции
                int[] Ranniy_srok_nach = new int[20]; //ранний срок начала
                int[] Pozdniy_srok_nach = new int[20]; //поздний срок
                int[] Ranniy_srok_zaver = new int[20]; //ранний срок завершения
                int[] Pozdniy_srok_zaver = new int[20]; //поздний срок завершения 
                int[] Rezerv_vrem = new int[20]; //резерв времени
                int[] Svob_rezerv_vrem = new int[20]; //свободный резерв времени
                int k;
                TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
            new TextWriterTraceListener(@"D:\1.txt"),  //Путь файла
            new TextWriterTraceListener(Console.Out)};

                Console.Write("Введите количество работ: ");
                n = int.Parse(Console.ReadLine());//ввод количества работ
                for (k = 0; k < n; k++)
                {
                    Console.Write("Введите начало, конец дуги(из таблицы)\n и продолжительность (через Enter): ");
                    i[k] = int.Parse(Console.ReadLine());
                    j[k] = int.Parse(Console.ReadLine());
                    Vrem_zatr[k] = int.Parse(Console.ReadLine());
                }

                CalculatingTheCriticalPath.СriticalPath(n, i, j, Vrem_zatr, Ranniy_srok_nach, Pozdniy_srok_nach, Ranniy_srok_zaver, Pozdniy_srok_zaver, Rezerv_vrem, Svob_rezerv_vrem);

                Console.Write("Самый ранний срок начала     : ");
                for (k = 0; k < n; k++) Console.Write("{0} \n", Ranniy_srok_nach[k]);//Вывод результатов
                Console.Write("Самый поздний срок начала    : ");
                for (k = 0; k < n; k++) Console.Write("{0} \n", Pozdniy_srok_nach[k]);
                Console.Write("Самый ранний срок завершения : ");
                for (k = 0; k < n; k++) Console.Write("{0} \n", Ranniy_srok_zaver[k]);
                Console.Write("Самый поздний срок завершения : ");
                for (k = 0; k < n; k++) Console.Write("{0} \n", Pozdniy_srok_zaver[k]);
                Console.Write("Свободный резерв времени     : ");
                for (k = 0; k < n; k++) Console.Write("{0} \n", Svob_rezerv_vrem[k]);
                Console.Write("Полный резерв времени        : ");
                for (k = 0; k < n; k++) Console.Write("{0} \n", Rezerv_vrem[k]);

                Console.Write("Критический путь: 1 ");
                for (k = 0; k < n; k++)
                    if (Svob_rezerv_vrem[k] == 0) { Console.Write("{0} ", j[k]); }
                Debug.Listeners.AddRange(listeners);
                Debug.WriteLine(Convert.ToString(j[k])); // Сообщение
                Debug.Flush();
                Console.ReadKey();
            }
            catch (Exception)
            { Console.WriteLine("Ошибка ввода данных"); }
        }
    }
}

