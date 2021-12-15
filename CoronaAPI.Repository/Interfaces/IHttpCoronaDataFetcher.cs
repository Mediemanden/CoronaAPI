using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Repository.Entities;

namespace CoronaAPI.Repository.Interfaces
{
    public interface IHttpCoronaDataFetcher
    {
        Task<List<CoronaReportEntity>> GetCoronaReportsByCountry(string countryCode);
    }
}