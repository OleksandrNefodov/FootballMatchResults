﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchResults.Api.Models;
using FootballMatchResults.Api.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootballMatchResults.Api.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class FootballMatchResultsController : ControllerBase
    {
        private readonly ILogger<FootballMatchResultsController> _logger;
        private readonly IResultMatchRepository _current;

        public FootballMatchResultsController(IResultMatchRepository resultMatchRepository, ILogger<FootballMatchResultsController> logger)
        {
            _current = resultMatchRepository;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var results =  _current.GetJsonRawResults();

            return Ok(results);
        }    

        [HttpPost]
        public ActionResult Post([FromBody] FilterRequest request)
        {
            if (request.StartDate <= request.EndDate)
            {
                List<MatchResult> results =  _current.GetMatchResults(request.StartDate, request.EndDate);

                return Ok(results);
            }

            return BadRequest("Invalid Date Range");
        }    
    }
}
