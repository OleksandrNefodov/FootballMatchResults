
using System;
using Newtonsoft.Json;
using FootballMatchResults.Dashboard.Models;

namespace FootballMatchResults.Api.Helpers
{
    public class EventTypeConverter: JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EventType) || t == typeof(EventType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Game ended":
                    return EventType.GameEnded;
                case "Game started":
                    return EventType.GameStarted;
            }
            throw new Exception("Cannot unmarshal type EventType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EventType)untypedValue;
            switch (value)
            {
                case EventType.GameEnded:
                    serializer.Serialize(writer, "Game ended");
                    return;
                case EventType.GameStarted:
                    serializer.Serialize(writer, "Game started");
                    return;
            }
            throw new Exception("Cannot marshal type EventType");
        }

        public static readonly EventTypeConverter Singleton = new EventTypeConverter();
    }
}