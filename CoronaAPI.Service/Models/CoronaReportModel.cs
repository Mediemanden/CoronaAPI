using System;
using CoronaAPI.Repository.Enums;

namespace CoronaAPI.Service.Models
{
    public class CoronaReportModel
    {
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public CountryCode CountryCode { get; set; }
        public string GeoId { get; set; }
        public string PopData2020 { get; set; }
        public string ContinentExp { get; set; }
    }
}