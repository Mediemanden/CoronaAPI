using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaAPI.Repository.Entities;
using CoronaAPI.Repository.Enums;
using CoronaAPI.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoronaAPI.Repository
{
    public class HttpCoronaDataFetcher : IHttpCoronaDataFetcher
    {
        private const string CovidNationalCaseDeathDailyUrl = "covid19/nationalcasedeath_eueea_daily_ei/json/";
        
        private readonly ILogger<HttpCoronaDataFetcher> _logger;
        private readonly HttpClient _httpClient;

        public HttpCoronaDataFetcher(ILogger<HttpCoronaDataFetcher> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<List<CoronaReportEntity>> GetAllCoronaReports()
        {
            var result = await _httpClient.GetAsync(CovidNationalCaseDeathDailyUrl);

            if (!result.IsSuccessStatusCode)
            {
                _logger.LogError("Could not retrieve data - {StatusCode} {Reason}", result.StatusCode,
                    result.ReasonPhrase);
                throw new HttpRequestException("Could not retrieve data", null, result.StatusCode);
            }
            
            var contentString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CoronaReportsEntity>(contentString)?.Records;
        }

        public async Task<List<CoronaReportEntity>> GetCoronaReportsByCountry(CountryCode countryCode)
        {
            var records =  await GetAllCoronaReports();
            
            return records?.Where(x => x.CountryTerritoryCode == countryCode).ToList();
        }
    }
}