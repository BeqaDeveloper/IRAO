using IRAO.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Domain.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        IUnitOfWork Context { get; }
        T Fetch(long id);
        IEnumerable<T> Set();
        void Save(T entity);
        void Delete(long id);
        void Delete(T entity);
    }
  
}
