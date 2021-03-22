using AutoMapper;
using IRAO.API.Helpers;
using IRAO.API.Models;
using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IRAO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPlaceController : ControllerBase
    {
        private readonly IMarketService _MarketService;
        private readonly ILogger<MarketPlaceController> _logger;
        private readonly ICompanyService _CompanyService;
        private readonly ICompanyMarketPlaceService _CompanyMarketService;
        private readonly IMapper _mapper;

        public MarketPlaceController(IMarketService marketService, ILogger<MarketPlaceController> logger, ICompanyService companyService, ICompanyMarketPlaceService companyMarketService, IMapper mapper)
        {
            _MarketService = marketService;
            _logger = logger;
            _CompanyService = companyService;
            _CompanyMarketService = companyMarketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Result = new ResponseModel<List<MarketViewModel>>();
            try
            {
                var data = await _MarketService.GetMarketsAsync();
                _mapper.Map(data, Result.Data);

                if (!data.Any())
                {
                    Result.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(Result);
                }

                Result.StatusCode = HttpStatusCode.OK;
                return Ok(Result);
            }
            catch (Exception e)
            {
                Result.StatusCode = HttpStatusCode.BadRequest;
                Result.ErrorMessages.Add(e.Message);
                _logger.LogError($"Exception Time: {DateTime.Now}. Message : {e.Message},  StackTrace : {e.StackTrace}");
                return BadRequest(e.Message);
            }
        }

        [HttpPut("CompanyPriceUpdate")]
        public IActionResult UpdateCompanyPrice(CompanyPriceModel model)
        {
            var Result = new ResponseModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    Result.ErrorMessages.AddRange(ModelState.GetModelStateErrors());
                    return BadRequest(Result);
                }

                var data = _CompanyMarketService.Set().FirstOrDefault(x => x.MarketId == model.MarketId && x.CompanyId == model.CompanyId);

                if (data == null)
                {
                    Result.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(Result);
                }

                data.Price = model.Price;
                _CompanyMarketService.Save(data);

                Result.StatusCode = HttpStatusCode.OK;

                return Ok(Result);
            }
            catch (Exception e)
            {
                Result.StatusCode = HttpStatusCode.BadRequest;
                Result.ErrorMessages.Add(e.Message);
                _logger.LogError($"Error at {DateTime.Now}. Message : {e.Message},  StackTrace : {e.StackTrace}");
                return BadRequest(e.Message);
            }
        }
    }
}
