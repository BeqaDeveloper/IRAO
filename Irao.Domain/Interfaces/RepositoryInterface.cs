using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

    public interface ICompanyRepository : IRepository<Company>
    {

    }
    public interface IMarketRepository : IRepository<Market>
    {
        Task<List<Market>> GetMarketsAsync();
    }
    public interface ICompanyMarketPlaceRepository : IRepository<CompanyMarketPlace>
    {

    }

}
