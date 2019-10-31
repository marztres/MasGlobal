using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasGlobal.Data.Repository.Interfaces;
using MasGlobal.Data.Entities;
using MasGlobal.Bussines;

namespace MasGlobal.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private IRepository<Employee> _repository;
        public EmployeesController(IRepository<Employee> repository)
        {
            this._repository = repository;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            EmployeeBLL bll = new EmployeeBLL(_repository);

            return bll.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            EmployeeBLL bll = new EmployeeBLL(_repository);

            return bll.FindById(id);
        }
    }
}
