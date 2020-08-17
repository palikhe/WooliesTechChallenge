using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WooliesTechChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechChallengeController : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult Get()
        {
            return Ok(new { name = "Suman Palikhe", token = "fd627ca4-707f-4eb3-9b33-6a03264e09ed" });
        }
    }
}
