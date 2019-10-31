using MasGlobal.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Data.Entities
{
    public class HourlyContractType : IContractType
    {
        public decimal HourlySalary; 
        public HourlyContractType(decimal salary) {
            HourlySalary = salary;
        }

        public decimal GetAnualSalary()
        {
            return 120 * HourlySalary * 12;
        }
    }
}
