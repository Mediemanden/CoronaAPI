using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using CoronaAPI.Dto;
using CoronaAPI.Repository.Enums;
using CoronaAPI.Service.Interfaces;

namespace CoronaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoronaReportsController : ControllerBase
    {
        private readonly ILogger<CoronaReportsController> _logger;
        private readonly IMapper _mapper;
        private readonly ICoronaDataHandler _coronaDataHandler;

        public CoronaReportsController(ILogger<CoronaReportsController> logger, ICoronaDataHandler coronaDataHandler, IMapper mapper)
        {
            _logger = logger;
            _coronaDataHandler = coronaDataHandler;
            _mapper = mapper;
        }

        [HttpGet("bycountry")]
        public async Task<ActionResult<List<CoronaReportDto>>> GetReportsForCountry([Required] CountryCode countryCode, int limit = 5, int offset = 0)
        {
            if (limit < 0)
            {
                return BadRequest("Limit must be zero or above");
            }
            
            if (offset < 0)
            {
                return BadRequest("Offset must be zero or above");
            }

            _logger.LogDebug("Received request for reports for {CountryCode}", countryCode);
            
            return Ok(_mapper.Map<List<CoronaReportDto>>(await _coronaDataHandler.GetCoronaReports(countryCode, limit, offset)));
        }

        [HttpGet("totalcases")]
        public async Task<ActionResult<CoronaReportDto>> GetTotalCases()
        {
            _logger.LogDebug("Received request for total cases");
            
            return Ok(await _coronaDataHandler.GetTotalCoronaCases());
        }
    }
}
