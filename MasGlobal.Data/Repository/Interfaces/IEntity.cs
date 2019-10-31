using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Data.Repository.Interfaces
{
    public interface IEntity // or IAggregateRoot
    {
        int Id { get; set; }
    }
}
