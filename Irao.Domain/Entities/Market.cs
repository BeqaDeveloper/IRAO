using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Domain.Entities
{
    public class Market : BaseEntity
    {
        public Market()
        {
            CompanyMarketPlaces = new List<CompanyMarketPlace>();

        }
        public string MarketName { get; set; }
        public List<CompanyMarketPlace> CompanyMarketPlaces { get; set; }
    }
}
