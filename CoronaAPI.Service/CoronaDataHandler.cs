using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Repository.Interfaces;
using CoronaAPI.Service.Interfaces;
using CoronaAPI.Service.Models;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;

namespace CoronaAPI.Service
{
    public class CoronaDataHandler : ICoronaDataHandler
    {
        public readonly ILogger<CoronaDataHandler> _logger;
        public readonly IHttpCoronaDataFetcher _coronaDataHandler;

        public CoronaDataHandler(ILogger<CoronaDataHandler> logger, IHttpCoronaDataFetcher coronaDataHandler)
        {
            _logger = logger;
            _coronaDataHandler = coronaDataHandler;
        }

        public async Task<List<CoronaReportModel>> GetCoronaReports(string countryCode)
        {
            _logger.LogInformation("Returning data for country {CountryCode}", countryCode);
            var temp = await _coronaDataHandler.GetCoronaReportsByCountry(countryCode);
            return Builder<CoronaReportModel>.CreateListOfSize(5).Build() as List<CoronaReportModel>;
        }
    }
}