using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZlesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Массив работников с фиксированной оплатой,заполнение и рассчет
            FixWorker[] workers = new FixWorker[5];
            for (int i = 0; i < 5; i++)
            {
                workers[i] = new FixWorker();
                workers[i].id = i;
                workers[i].fixMonthSalary = Convert.ToDouble(Console.ReadLine());
                workers[i].calcAverageSalary();
            }

            // Массив работников с почасовой оплатой,заполнение и рассчет
            TimeWorker[] timeWorkers = new TimeWorker[4];
            for (int i = 0; i < 4; i++)
            {
                timeWorkers[i] = new TimeWorker();
                timeWorkers[i].id = i+5;
                timeWorkers[i].hourlyRate = Convert.ToDouble(Console.ReadLine());
                timeWorkers[i].calcAverageSalary();
            }
            
            //Вывод на экран информации о работниках с фиксированной оплатой
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(workers[i].id + " " + workers[i].averageSalary);
            }

            //Вывод на экран информации о работниках с почасовой оплатой
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(timeWorkers[i].id + " " + timeWorkers[i].averageSalary);
            }

            Console.ReadKey();  // Ожидание нажатия для завершения
        }
    }
}
