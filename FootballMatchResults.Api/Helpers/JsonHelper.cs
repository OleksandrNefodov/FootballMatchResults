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

        public static string ReadJsonFromFile(string path)
        {
            try
            {
                if(File.Exists(path)) 
                {
                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();

                        return json;                                         
                    }
                }
                else 
                {
                    Console.WriteLine($"{nameof(path)} is not a valid \"{path}\".");
                    return "";
                }                   
            }catch(Exception ex)
            { 
                Console.WriteLine($"Couldn't parse Json. Exception : { ex }");
                throw;
            }            
        }

        public static bool TryParseJson<T>(string json, out List<T> data) where T : class
        {
            data = default(List<T>);

            try
            {                
                data = JsonConvert.DeserializeObject<List<T>>(json, Settings);

                return true;
            }
            catch(JsonException ex)
            {
                Console.WriteLine($"Failed to parse {nameof(json)}. Json : \"{json}\". Exception \"{ex}\"");
                return false;
            }
            
        }
    }
}