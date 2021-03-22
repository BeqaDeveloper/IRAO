using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IRAO.Domain.Entities
{
    public class CompanyMarketPlace
    {
        [Key]
        public int CompanyMarketId { get; set; }
        public int MarketId { get; set; }
        public int CompanyId { get; set; }
        public Market Market { get; set; }
        public Company Company { get; set; }
        public decimal Price { get; set; }
    }
}
