using System;

namespace FootballMatchResults.Api.Models
{
    public class FilterRequest
    {
        public DateTime StartDate {get;set;}

        public DateTime EndDate{get;set;}
    }
}