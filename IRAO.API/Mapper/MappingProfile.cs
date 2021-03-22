using AutoMapper;
using IRAO.API.Models;
using IRAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRAO.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Market, MarketViewModel>();
            CreateMap<Market, MarketViewModel>().ReverseMap();

        }
    }
}
