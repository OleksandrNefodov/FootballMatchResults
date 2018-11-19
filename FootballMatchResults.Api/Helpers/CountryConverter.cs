using System;
using Newtonsoft.Json;
using FootballMatchResults.Api.Models;

namespace FootballMatchResults.Api.Helpers
{
    public class CountryConverter : JsonConverter
    {
        public static readonly CountryConverter Singleton = new CountryConverter();
        
        public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "finland")
            {
                return Country.Finland;
            }
            throw new Exception("Cannot unmarshal type Country");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Country)untypedValue;
            if (value == Country.Finland)
            {
                serializer.Serialize(writer, "finland");
                return;
            }
            throw new Exception("Cannot marshal type Country");
        }        
    }
}