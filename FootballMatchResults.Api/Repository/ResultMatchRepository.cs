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

        private static string _rawJsonData;

        public string RawJsonData
        {
            get
            {                               
                if (string.IsNullOrWhiteSpace(_rawJsonData))
                {
                    var directory = Directory.GetCurrentDirectory();
                    var path = directory += _filePath;
                    
                    _rawJsonData = JsonHelper.ReadJsonFromFile(path);
                }

                return _rawJsonData;
            }
         }
        public List<MatchResult> MatchResults { 
            get
            {                               
                if (_results == null || _results.Count == 0)
                {

                    bool success = JsonHelper.TryParseJson<MatchResult>(RawJsonData, out _results);

                    if(success)
                    {

                    }
                }

                return _results;
            }
        }

        public string GetJsonRawResults()
        {
            return RawJsonData;
        }


        public List<MatchResult> GetMatchResults()
        {
            return MatchResults;
        }
    }
}