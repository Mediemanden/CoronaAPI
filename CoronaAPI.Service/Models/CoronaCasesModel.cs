using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Mappers;
using CoronaAPI.Repository.Enums;

namespace CoronaAPI.Service.Models
{
    public class CoronaCasesModel
    {
        [JsonConverter(typeof(EnumToStringMapper))]
        public Dictionary<CountryCode, int> Cases { get; set; }
    }
}