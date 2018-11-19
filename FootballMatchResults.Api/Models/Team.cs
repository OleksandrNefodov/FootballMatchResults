using System;
using Newtonsoft.Json;

namespace FootballMatchResults.Api.Models
{
    public class Team
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public TeamName Name { get; set; }

        [JsonProperty("FullName")]
        public TeamName FullName { get; set; }

        [JsonProperty("Logo")]
        public object Logo { get; set; }

        [JsonProperty("LogoUrl")]
        public Uri LogoUrl { get; set; }

        [JsonProperty("Ranking")]
        public long Ranking { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}