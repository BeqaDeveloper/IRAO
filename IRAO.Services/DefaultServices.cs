using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces;
using IRAO.Domain.Interfaces.Core;
using IRAO.Services.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRAO.Services
{
    public class CompanyService : ServiceBase<Company, ICompanyRepository>, ICompanyService
    {

        private ICompanyRepository _CompanyRepository;

        public CompanyService(IUnitOfWork context, ICompanyRepository CompanyRepository) : base(context, CompanyRepository)
        {
            _CompanyRepository = CompanyRepository;
        }
    }

    public class MarketService : ServiceBase<Market, IMarketRepository>, IMarketService
    {

        private IMarketRepository _MarketRepository;

        public MarketService(IUnitOfWork context, IMarketRepository MarketRepository) : base(context, MarketRepository)
        {
            _MarketRepository = MarketRepository;
        }


        public async Task<List<Market>> GetMarketsAsync()
        {
            return await _MarketRepository.GetMarketsAsync();
        }


    }

    public class CompanyMarketPlaceReplyService : ServiceBase<CompanyMarketPlace, ICompanyMarketPlaceRepository>, ICompanyMarketPlaceService
    {

        private ICompanyMarketPlaceRepository _CompanyMarketPlaceRepository;
        public CompanyMarketPlaceReplyService(IUnitOfWork context, ICompanyMarketPlaceRepository CompanyMarketPlaceRepository) : base(context, CompanyMarketPlaceRepository)
        {
            _CompanyMarketPlaceRepository = CompanyMarketPlaceRepository;
        }

    }
}
