using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> All();
        T FindById(int Id);
    }
}
