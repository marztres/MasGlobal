using System;
using MasGlobal.Data.Repository.Interfaces;
using MasGlobal.Data.Entities;
using System.Collections.Generic;

namespace MasGlobal.Bussines
{
    public class EmployeeBLL
    {
        IRepository<Employee> _repository;
        public EmployeeBLL(IRepository<Employee> repository) {
            _repository = repository;
        }

        public List<Employee> All() {
            return _repository.All();
        }

        public Employee FindById(int id)
        {
            return _repository.FindById(id);
        }
    }
}
