using System;

namespace FootballMatchResults.Api.Models
{
    public class FilterRequest
    {
        public DateTime startDate {get;set;}

        public DateTime endDate{get;set;}
    }
}