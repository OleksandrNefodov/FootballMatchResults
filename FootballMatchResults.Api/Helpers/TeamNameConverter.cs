using System;
using Newtonsoft.Json;
using FootballMatchResults.Api.Models;

namespace FootballMatchResults.Api.Helpers
{
    public class TeamNameConverter : JsonConverter
    {
        public static readonly TeamNameConverter Singleton = new TeamNameConverter();

        public override bool CanConvert(Type t) => t == typeof(TeamName) || t == typeof(TeamName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "FC Inter":
                    return TeamName.FcInter;
                case "FC Lahti":
                    return TeamName.FcLahti;
                case "FF Jaro":
                    return TeamName.FfJaro;
                case "HIFK":
                    return TeamName.Hifk;
                case "HJK":
                    return TeamName.Hjk;
                case "IFK Mariehamn":
                    return TeamName.IfkMariehamn;
                case "Ilves":
                    return TeamName.Ilves;
                case "KTP":
                    return TeamName.Ktp;
                case "KuPS":
                    return TeamName.KuPs;
                case "RoPS":
                    return TeamName.RoPs;
                case "SJK":
                    return TeamName.Sjk;
                case "VPS":
                    return TeamName.Vps;
            }
            throw new Exception("Cannot unmarshal type Name");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TeamName)untypedValue;
            switch (value)
            {
                case TeamName.FcInter:
                    serializer.Serialize(writer, "FC Inter");
                    return;
                case TeamName.FcLahti:
                    serializer.Serialize(writer, "FC Lahti");
                    return;
                case TeamName.FfJaro:
                    serializer.Serialize(writer, "FF Jaro");
                    return;
                case TeamName.Hifk:
                    serializer.Serialize(writer, "HIFK");
                    return;
                case TeamName.Hjk:
                    serializer.Serialize(writer, "HJK");
                    return;
                case TeamName.IfkMariehamn:
                    serializer.Serialize(writer, "IFK Mariehamn");
                    return;
                case TeamName.Ilves:
                    serializer.Serialize(writer, "Ilves");
                    return;
                case TeamName.Ktp:
                    serializer.Serialize(writer, "KTP");
                    return;
                case TeamName.KuPs:
                    serializer.Serialize(writer, "KuPS");
                    return;
                case TeamName.RoPs:
                    serializer.Serialize(writer, "RoPS");
                    return;
                case TeamName.Sjk:
                    serializer.Serialize(writer, "SJK");
                    return;
                case TeamName.Vps:
                    serializer.Serialize(writer, "VPS");
                    return;
            }
            throw new Exception("Cannot marshal type Name");
        }        
    }
}