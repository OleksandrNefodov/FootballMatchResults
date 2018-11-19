using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using FootballMatchResults.Dashboard.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FootballMatchResults.Api.Helpers
{
    public class JsonHelper
    {
        private readonly ILogger<JsonHelper> _logger;

        public JsonHelper(ILogger<JsonHelper> logger)
        {
            _logger = logger;
        }
        
        private readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TeamNameConverter.Singleton,
                CountryConverter.Singleton,
                LeagueConverter.Singleton,
                EventTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public List<T> ParseJson<T>(string json) where T : class
        {
            try
            {                
                return JsonConvert.DeserializeObject<List<T>>(json, Settings);
            }
            catch(JsonException ex)
            {           
                _logger.LogError($"Failed to parse {nameof(json)}. Json : \"{json}\". Exception: {ex}");

                throw;  
            }
            
        }
    }
}