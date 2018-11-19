using System;
using Newtonsoft.Json;

namespace FootballMatchResults.Api.Models
{
    public class MatchEvent
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("MatchId")]
        public long MatchId { get; set; }

        [JsonProperty("EventMinute")]
        public long EventMinute { get; set; }

        [JsonProperty("ElapsedSeconds")]
        public long ElapsedSeconds { get; set; }

        [JsonProperty("TeamId")]
        public long TeamId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("FullDescription")]
        public string FullDescription { get; set; }

        [JsonProperty("EventTypeIcon")]
        public Uri EventTypeIcon { get; set; }

        [JsonProperty("EventType")]
        public EventType? EventType { get; set; }

        [JsonProperty("EventTypeEnum")]
        public long EventTypeEnum { get; set; }

        [JsonProperty("PlayerId")]
        public long PlayerId { get; set; }

        [JsonProperty("Player")]
        public object Player { get; set; }

        [JsonProperty("Identifier")]
        public string Identifier { get; set; }

        [JsonProperty("AssistPlayers")]
        public object AssistPlayers { get; set; }

        [JsonProperty("AssistPlayerNames")]
        public object AssistPlayerNames { get; set; }

        [JsonProperty("Modifier")]
        public object Modifier { get; set; }

        [JsonProperty("Score")]
        public object Score { get; set; }

        [JsonProperty("IsGoal")]
        public bool IsGoal { get; set; }
    }
}