using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZlesson2
{
    class FixWorker : Worker
    {
        public double fixMonthSalary;  // фиксированная ЗП

        // Описание метода расчета средней ЗП
        public override void calcAverageSalary()
        {
            averageSalary = fixMonthSalary;
        }
    }
}
