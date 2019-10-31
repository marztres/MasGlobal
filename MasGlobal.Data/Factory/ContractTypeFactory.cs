using MasGlobal.Data.Repository.Interfaces;
using MasGlobal.Shared.Enum;
using MasGlobal.Data.Entities;

namespace MasGlobal.Data.Factory
{
    public static class ContractTypeFactory
    {
        public static IContractType Create( CommonEnum.ContractType contractType, decimal currentSalary ) {
            return contractType.Equals(CommonEnum.ContractType.HourlySalaryEmployee) ? (IContractType) new HourlyContractType(currentSalary) : (IContractType) new MontlyContractType(currentSalary);
        }
    }
}
