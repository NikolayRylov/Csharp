using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZlesson2
{
    abstract class Worker
    {
        public int id;    // идентификатор сотрудника
        public double averageSalary;      // средняя зарплата

        // Описание метода расчета средней ЗП
        public abstract void calcAverageSalary(); 

    }
}
