using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FootballMatchResults.Api.Helpers;
using FootballMatchResults.Dashboard.Models;
using Microsoft.Extensions.Logging;

namespace FootballMatchResults.Dashboard.Repository
{
    public class ResultMatchRepository : IResultMatchRepository
    {             
        private HttpClient _client;    

        private readonly ILogger<ResultMatchRepository> _logger;
        private readonly JsonHelper _jsonHelper;

        public ResultMatchRepository(HttpClient client, ILogger<ResultMatchRepository> logger, JsonHelper jsonHelper)       
        {
            _client = client;
            _logger = logger;
            _jsonHelper = jsonHelper;
        }

        private static List<MatchResult> _results;

        private static string _rawJsonData;

        public string RawJsonData
        {
            get
            {                               
                if (string.IsNullOrWhiteSpace(_rawJsonData))
                {                    
                    _rawJsonData = FetchResults();
                }

                return _rawJsonData;
            }
         }
        public List<MatchResult> MatchResults { 
            get
            {                 
                _logger.LogInformation($"Parse \"{nameof(RawJsonData)}\"");        
                _results = _jsonHelper.ParseJson<MatchResult>(RawJsonData);

                return _results;
            }
        }

        private string FetchResults()
        {
            _logger.LogInformation($"Start fetching data from external url");

            HttpResponseMessage response = _client.GetAsync("data/matches_latest.json").Result;  
  
            if (response.IsSuccessStatusCode)  
            {
                string json = response.Content.ReadAsStringAsync().Result;  
                return json;
            }
            else
            {
                _logger.LogError($"Failed to fetch data. Response : {response.Content.ToString()}");
                throw new HttpRequestException($"ResponseCode: { response.StatusCode } Message: { response.Content.ToString()}");
            }
        }
        public string GetJsonRawResults()
        {
            _logger.LogDebug($"{nameof(GetJsonRawResults)}.");

            return RawJsonData;
        }
        
        public List<MatchResult> GetMatchResults(DateTime start, DateTime end)
        {
            _logger.LogDebug($"{nameof(GetMatchResults)}."); 

            var results = MatchResults
            .Where(result => start < result.MatchDate && end > result.MatchDate)
            .ToList();

            return results;
        }
    }
}