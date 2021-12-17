using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Repository.Entities;
using CoronaAPI.Repository.Enums;

namespace CoronaAPI.Repository.Interfaces
{
    public interface IHttpCoronaDataFetcher
    {
        Task<List<CoronaReportEntity>> GetAllCoronaReports();
        Task<List<CoronaReportEntity>> GetCoronaReportsByCountry(CountryCode countryCode);
    }
}