using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Service.Models;

namespace CoronaAPI.Service.Interfaces
{
    public interface ICoronaDataHandler
    {
        Task<List<CoronaReportModel>> GetCoronaReports(string countryCode, int limit = 5, int offset = 0);
    }
}