using System;
using System.Collections.Generic;
using FootballMatchResults.Api.Models;

namespace FootballMatchResults.Api.Repository
{
    public interface IResultMatchRepository
    {
        string GetJsonRawResults();
        List<MatchResult> GetMatchResults(DateTime start, DateTime end);
    }
}