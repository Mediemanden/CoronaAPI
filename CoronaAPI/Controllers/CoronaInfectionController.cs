using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoronaAPI.Dto;
using CoronaAPI.Service.Interfaces;

namespace CoronaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoronaInfectionController : ControllerBase
    {
        private readonly ILogger<CoronaInfectionController> _logger;
        private readonly IMapper _mapper;
        private readonly ICoronaDataHandler _coronaDataHandler;

        public CoronaInfectionController(ILogger<CoronaInfectionController> logger, ICoronaDataHandler coronaDataHandler, IMapper mapper)
        {
            _logger = logger;
            _coronaDataHandler = coronaDataHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CoronaReportDto>> GetInfectionCountsForCountry(string countryCode)
        {
            return _mapper.Map<List<CoronaReportDto>>(await _coronaDataHandler.GetCoronaReports(countryCode));
        }
    }
}
