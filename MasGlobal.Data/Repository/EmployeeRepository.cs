using MasGlobal.Data.Entities;
using MasGlobal.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MasGlobal.Shared.Dto;

namespace MasGlobal.Data.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> _employeeContext;

        public  EmployeeRepository()
        {
            _employeeContext = new List<Employee>();

            Task.Run(async () => await GetApiData()).Wait();            
        }

        private async Task GetApiData()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<EmployeeDto> lsDto = JsonConvert.DeserializeObject<List<EmployeeDto>>(apiResponse);
                        foreach (var itemDto in lsDto)
                        {
                            _employeeContext.Add(new Employee(itemDto.Id
                                                              , itemDto.Name
                                                              , Int32.Parse(itemDto.RoleId)
                                                              ,itemDto.RoleName
                                                              ,itemDto.RoleDescription
                                                              ,itemDto.ContractTypeName
                                                              ,Decimal.Parse(!string.IsNullOrEmpty(itemDto.HourlySalary) ? itemDto.HourlySalary : "0")
                                                              ,Decimal.Parse(!string.IsNullOrEmpty(itemDto.MonthlySalary) ? itemDto.MonthlySalary : "0")));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _employeeContext = new List<Employee>();
            }
        }

        public List<Employee> All()
        {
            return _employeeContext;
        }

        public Employee FindById(int Id)
        {
            return _employeeContext.FirstOrDefault(filter => filter.Id == Id);
        }
    }
}
