using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballMatchResults.Dashboard.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatchResults.Api.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class FootballMatchResultsController : ControllerBase
    {
        private readonly IResultMatchRepository _current;

        public FootballMatchResultsController(IResultMatchRepository resultMatchRepository)
        {
            _current = resultMatchRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var results = _current.GetJsonRawResults();

            return Ok(results);
        }    
    }
}
