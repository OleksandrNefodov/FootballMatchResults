using System;
using System.Collections.Generic;
using System.IO;
using FootballMatchResults.Api.Helpers;
using FootballMatchResults.Dashboard.Models;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace FootballMatchResults.Dashboard.Repository
{
    public class ResultMatchRepository : IResultMatchRepository
    {                        
        private const string _filePath =  @"\Repository\Data.json"; 
        private static List<MatchResult> _results;
        public List<MatchResult> MatchResults { 
            get
            {                               
                if (_results == null || _results.Count == 0)
                {
                    var directory = Directory.GetCurrentDirectory();
                    var path = directory += _filePath;
                    
                    _results = JsonHelper.ReadFromJsonFile(path);
                }

                return _results;
            }
        }

        public List<MatchResult> GetAllResults()
        {
            return MatchResults;
        }
    }
}