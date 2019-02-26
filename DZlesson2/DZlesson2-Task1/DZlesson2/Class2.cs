using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZlesson2
{
    class TimeWorker : Worker
    {
        public double hourlyRate;  // почасовая ставка

        // Описание метода расчета средней ЗП

        public override void calcAverageSalary()
        {
            averageSalary = 20.8 * 8 * hourlyRate;
        }
    }
}
