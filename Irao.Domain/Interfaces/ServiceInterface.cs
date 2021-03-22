using IRAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRAO.Domain.Interfaces
{
    public interface IService<T> where T : class, new()
    {
        T Fetch(long id);
        IEnumerable<T> Set();
        void Save(T entity);
        void Delete(long id);
        void Delete(T entity);
    }
    public interface ICompanyService : IService<Company>
    {
     
    }
    public interface IMarketService : IService<Market>
    {
        Task<List<Market>> GetMarketsAsync();
    }
    public interface ICompanyMarketPlaceService : IService<CompanyMarketPlace>
    {

    }
}
