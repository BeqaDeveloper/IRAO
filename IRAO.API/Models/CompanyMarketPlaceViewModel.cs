using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRAO.API.Models
{
    public class CompanyMarketPlaceViewModel
    {
        public CompanyMarketPlaceViewModel()
        {
            Companies = new List<CompanyViewModel>();
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public List<CompanyViewModel> Companies { get; set; }

    }
}
