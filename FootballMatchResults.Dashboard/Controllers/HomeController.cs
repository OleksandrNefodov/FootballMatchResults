using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatchResults.Dashboard.Controllers
{
    [Route("api/Dashboard")]
    [ApiController]
    public class HomeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
