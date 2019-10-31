using MasGlobal.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Data.Entities
{
    public class MontlyContractType : IContractType
    {
        public decimal MontlySalary;
        public MontlyContractType(decimal salary)
        {
             MontlySalary = salary;
        }

        public decimal GetAnualSalary()
        {
            return MontlySalary * 12;
        }
    }
}
