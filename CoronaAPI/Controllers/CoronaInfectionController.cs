using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Service.Interfaces;
using CoronaAPI.Service.Models;

namespace CoronaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoronaInfectionController : ControllerBase
    {
        private readonly ILogger<CoronaInfectionController> _logger;
        private readonly ICoronaDataHandler _coronaDataHandler;

        public CoronaInfectionController(ILogger<CoronaInfectionController> logger, ICoronaDataHandler coronaDataHandler)
        {
            _logger = logger;
            _coronaDataHandler = coronaDataHandler;
        }

        [HttpGet]
        public async Task<List<CoronaReportModel>> GetInfectionCountsForCountry(string countryCode)
        {
            return await _coronaDataHandler.GetCoronaReports(countryCode);
        }
    }
}
