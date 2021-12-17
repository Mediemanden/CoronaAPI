using CoronaAPI.Repository.Enums;

namespace CoronaAPI.Repository.Entities
{
    public class CoronaReportEntity
    {
        public string DateRep { get; set; }
        public string Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public string CountriesAndTerritories { get; set; }
        public string GeoId { get; set; }
        public CountryCode CountryTerritoryCode { get; set; }
        public string PopData2020 { get; set; }
        public string ContinentExp { get; set; }
    }
}