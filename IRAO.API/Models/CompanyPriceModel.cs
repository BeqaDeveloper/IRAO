using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRAO.API.Models
{
    public class CompanyPriceModel
    {
        public int CompanyId { get; set; }
        public int MarketId { get; set; }
        public decimal Price { get; set; }
    }
}
