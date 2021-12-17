﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaAPI.Repository.Enums;
using CoronaAPI.Repository.Interfaces;
using CoronaAPI.Service.Interfaces;
using CoronaAPI.Service.Models;
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

        public async Task<List<CoronaReportModel>> GetCoronaReports(CountryCode countryCode, int limit = 5, int offset = 0)
        {
            
            var reportEntities = await _coronaDataHandler.GetCoronaReportsByCountry(countryCode);
            
            var reportModels = _mapper.Map<List<CoronaReportModel>>(reportEntities);

            var result = reportModels.OrderByDescending(x => x.Date).Skip(offset).Take(limit).ToList();
            
            _logger.LogDebug("Returning reports for {DaysCount} days for country {CountryCode}", result.Count, countryCode);

            return result;
        }

        public async Task<CoronaCasesModel> GetTotalCoronaCases()
        {
            var reportsEntities = await _coronaDataHandler.GetAllCoronaReports();

            var grouped = reportsEntities.GroupBy(x => x.CountryTerritoryCode)
                .ToDictionary(g => g.Key, g => g.ToList().Sum(x => x.Cases));

            var coronaCasesModel = new CoronaCasesModel {Cases = grouped};

            return coronaCasesModel;
        }
    }
}