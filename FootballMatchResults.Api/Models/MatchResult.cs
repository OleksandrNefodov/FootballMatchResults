using System;
using Newtonsoft.Json;

namespace FootballMatchResults.Api.Models
{
    public class MatchResult
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Round")]
        public object Round { get; set; }

        [JsonProperty("RoundNumber")]
        public long RoundNumber { get; set; }

        [JsonProperty("MatchDate")]
        public DateTimeOffset MatchDate { get; set; }

        [JsonProperty("HomeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty("AwayTeam")]
        public Team AwayTeam { get; set; }

        [JsonProperty("HomeGoals")]
        public long HomeGoals { get; set; }

        [JsonProperty("AwayGoals")]
        public long AwayGoals { get; set; }

        [JsonProperty("Status")]
        public long Status { get; set; }

        [JsonProperty("PlayedMinutes")]
        public long PlayedMinutes { get; set; }

        [JsonProperty("SecondHalfStarted")]
        public object SecondHalfStarted { get; set; }

        [JsonProperty("GameStarted")]
        public DateTimeOffset? GameStarted { get; set; }

        [JsonProperty("MatchEvents")]
        public MatchEvent[] MatchEvents { get; set; }

        [JsonProperty("PeriodResults")]
        public object[] PeriodResults { get; set; }

        [JsonProperty("OnlyResultAvailable")]
        public bool OnlyResultAvailable { get; set; }

        [JsonProperty("Season")]
        public long Season { get; set; }

        [JsonProperty("Country")]
        public Country Country { get; set; }

        [JsonProperty("League")]
        public League League { get; set; }
    }
}