using CoronaAPI.Repository.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoronaAPI.Dto
{
    public class CoronaReportDto
    {
        public string Date { get; set; }
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; } 
    }
}