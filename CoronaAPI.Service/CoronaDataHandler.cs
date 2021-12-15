using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Service.Interfaces;
using CoronaAPI.Service.Models;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;

namespace CoronaAPI.Service
{
    public class CoronaDataHandler : ICoronaDataHandler
    {
        public readonly ILogger<CoronaDataHandler> _logger;

        public CoronaDataHandler(ILogger<CoronaDataHandler> logger)
        {
            _logger = logger;
        }

        public async Task<List<CoronaReportModel>> GetCoronaReports(string countryCode)
        {
            _logger.LogInformation("Returning data for country {CountryCode}", countryCode);
            return Builder<CoronaReportModel>.CreateListOfSize(5).Build() as List<CoronaReportModel>;
        }
    }
}