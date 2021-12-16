using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        public readonly IMapper _mapper;

        public CoronaDataHandler(ILogger<CoronaDataHandler> logger, IHttpCoronaDataFetcher coronaDataHandler, IMapper mapper)
        {
            _logger = logger;
            _coronaDataHandler = coronaDataHandler;
            _mapper = mapper;
        }

        public async Task<List<CoronaReportModel>> GetCoronaReports(string countryCode)
        {
            _logger.LogInformation("Returning data for country {CountryCode}", countryCode);
            var reportEntities = await _coronaDataHandler.GetCoronaReportsByCountry(countryCode);
            
            var reportModels = _mapper.Map<List<CoronaReportModel>>(reportEntities);

            return reportModels;
        }
    }
}