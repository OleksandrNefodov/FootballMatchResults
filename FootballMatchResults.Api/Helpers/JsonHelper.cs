using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using FootballMatchResults.Dashboard.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FootballMatchResults.Api.Helpers
{
    public class JsonHelper
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
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

        public static List<MatchResult> ReadFromJsonFile(string path)
        {
            try
            {
                if(File.Exists(path)) 
                {
                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<MatchResult>>(json, Settings);                           
                    }
                }
                else 
                {
                    Console.WriteLine($"{nameof(path)} is not a valid \"{path}\".");
                    return new List<MatchResult>();
                }                   
            }catch(Exception ex)
            { 
                Console.WriteLine($"Couldn't parse Json. Exception : { ex }");
                throw;
            }
            
        }
    }
}