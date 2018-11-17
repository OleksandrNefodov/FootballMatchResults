using System.Collections.Generic;
using FootballMatchResults.Dashboard.Models;

namespace FootballMatchResults.Dashboard.Repository
{
    public interface IResultMatchRepository
    {
        List<MatchResult> GetAllResults();
    }
}