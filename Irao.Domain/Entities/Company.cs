using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            CompanyMarketPlaces = new List<CompanyMarketPlace>();
        }
        public string CompanyName { get; set; }
        public List<CompanyMarketPlace> CompanyMarketPlaces { get; set; }
    }
}
