using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasGlobal.Shared.Dto;
using MasGlobal.Data.Entities;
using Newtonsoft.Json;

namespace MasGlobal.WebClient.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        [Route("api/controller/{id}")]
        [HttpGet("{id}")]
        public async Task<EmployeeDto> Get([FromRoute] int id)
        {
            EmployeeDto employee = new EmployeeDto();
            HttpClient httpClient = new HttpClient();
            var request = await httpClient.GetAsync($"http://localhost:61813/api/Employees/"+ id, HttpCompletionOption.ResponseHeadersRead);
            if (request.IsSuccessStatusCode)
            {
                var rawObject = await request.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<EmployeeDto>(rawObject);
            }

            return employee;
        }

        [HttpGet("")]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();
            HttpClient httpClient = new HttpClient();
            var request = await httpClient.GetAsync($"http://localhost:61813/api/Employees", HttpCompletionOption.ResponseHeadersRead);
            if (request.IsSuccessStatusCode)
            {
                var rawObject = await request.Content.ReadAsStringAsync();
                employees =  JsonConvert.DeserializeObject<List<EmployeeDto>>(rawObject);
            }

            return employees;
        }
    }
}
