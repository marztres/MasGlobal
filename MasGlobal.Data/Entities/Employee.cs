using MasGlobal.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MasGlobal.Shared.Enum;

namespace MasGlobal.Data.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        private IContractType ContractType;
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal CurrentSalary {
                get {
                    return ContractTypeName.Equals(CommonEnum.ContractType.HourlySalaryEmployee) ? HourlySalary : MonthlySalary;
            } }
        public CommonEnum.ContractType ContractTypeName { get; set; }
        public decimal AnualSalary { get { return ContractType.GetAnualSalary(); } }

        public Employee(int id, string name, int roleId, string roleName, string roleDescription, string contractTypeName, decimal hourlySalary, decimal montlySalary ) {
            this.Id = id;
            this.Name = name;
            this.Role = new Role(roleId, roleName, roleDescription);
            this.HourlySalary = hourlySalary;
            this.MonthlySalary = montlySalary;
            this.ContractTypeName = (CommonEnum.ContractType)Enum.Parse(typeof(CommonEnum.ContractType), contractTypeName,false);
            ContractType = Factory.ContractTypeFactory.Create(ContractTypeName, CurrentSalary);
        }
    }
}
