using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatchResults.Api.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class FootballMatchResultsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            //sdasdasdasd
            return Ok();
        }    
    }
}
