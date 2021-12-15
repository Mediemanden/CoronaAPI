using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaAPI.Service.Models;

namespace CoronaAPI.Service.Interfaces
{
    public interface ICoronaDataHandler
    {
        Task<List<CoronaReportModel>> GetCoronaReports(string countryCode);
    }
}