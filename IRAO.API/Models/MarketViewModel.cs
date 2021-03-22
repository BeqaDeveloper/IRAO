using IRAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRAO.API.Models
{
    public class MarketViewModel
    {
        public MarketViewModel()
        {
            CompanyMarketPlaces = new List<CompanyMarketPlaceViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CompanyMarketPlaceViewModel> CompanyMarketPlaces { get; set; }
    }
}
