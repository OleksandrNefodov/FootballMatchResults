
using System;
using Newtonsoft.Json;
using FootballMatchResults.Api.Models;

namespace FootballMatchResults.Api.Helpers
{
    public class LeagueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(League) || t == typeof(League?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "veikkausliiga")
            {
                return League.Veikkausliiga;
            }
            throw new Exception("Cannot unmarshal type League");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (League)untypedValue;
            if (value == League.Veikkausliiga)
            {
                serializer.Serialize(writer, "veikkausliiga");
                return;
            }
            throw new Exception("Cannot marshal type League");
        }

        public static readonly LeagueConverter Singleton = new LeagueConverter();
    }
}