using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces;
using IRAO.Domain.Interfaces.Core;
using IRAO.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAO.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IUnitOfWork context) : base(context) { }
    }
    public class MarketRepository : RepositoryBase<Market>, IMarketRepository
    {
       
        public MarketRepository(IUnitOfWork context) : base(context) { }

        public async Task<List<Market>> GetMarketsAsync()
        {
            return await _context.Markets
                .Include(x=> x.CompanyMarketPlaces)
                .ThenInclude(x => x.Company)
                .ToListAsync();
        }
    }
    public class CompanyMarketPlaceRepository : RepositoryBase<CompanyMarketPlace>, ICompanyMarketPlaceRepository
    {
        public CompanyMarketPlaceRepository(IUnitOfWork context) : base(context) { }

    }
}
