using System;

namespace CoronaAPI.Dto
{
    public class CoronaReportDto
    {
        public string Date { get; set; }
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public string CountryCode { get; set; } // Add enum for this
    }
}