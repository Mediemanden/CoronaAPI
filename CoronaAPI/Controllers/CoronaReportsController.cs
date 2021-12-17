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
    /// <summary>
    /// API for getting information on Corona cases and deaths reported by EU/EER countries 
    /// </summary>
    /// <remarks>
    /// Data fetched from https://www.ecdc.europa.eu/en/publications-data/data-daily-new-cases-covid-19-eueea-country
    /// </remarks>
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
        
        /// <summary>
        /// Get Corona reports from specified country
        /// </summary>
        /// <remarks>
        /// Use Limit and Offset to paginate result
        /// </remarks>
        /// <param name="countryCode"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>List of reports</returns>
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

        /// <summary>
        /// Get total amount of reported corona cases for each country in database
        /// </summary>
        /// <returns>Total cases grouped by country</returns>
        [HttpGet("totalcases")]
        public async Task<ActionResult<CoronaReportDto>> GetTotalCases()
        {
            _logger.LogDebug("Received request for total cases");
            
            return Ok(await _coronaDataHandler.GetTotalCoronaCases());
        }
    }
}
