using System;

namespace FootballMatchResults.Dashboard.Models
{
    public class MatchResult
    {
        public int Id { get;set; }

        public string Round{ get; set; }

        public int RoundNumber { get; set; }

        public DateTime MatchDate{ get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }
    }
}