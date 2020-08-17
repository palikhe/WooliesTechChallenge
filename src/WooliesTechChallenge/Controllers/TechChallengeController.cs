using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WooliesTechChallenge.Service.Configuration;

namespace WooliesTechChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechChallengeController : ControllerBase
    {
        private WooliesX _configuration;
        public TechChallengeController(IOptions<WooliesX> configuration)
        {
            _configuration = configuration?.Value;
        }

        [HttpGet("user")]
        public IActionResult Get()
        {
            return Ok(new { name = _configuration.UserName , token = _configuration.Token });
        }
    }
}
