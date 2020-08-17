using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WooliesTechChallenge.Service.Configuration;
using WooliesTechChallenge.Service.Interface;

namespace WooliesTechChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechChallengeController : ControllerBase
    {
        private WooliesX _configuration;

        private IApiCaller _apiCaller;

        public TechChallengeController(IOptions<WooliesX> configuration, IApiCaller apiCaller)
        {
            _configuration = configuration?.Value;
            _apiCaller = apiCaller;
        }

        [HttpGet("user")]
        public IActionResult Get()
        {

            return Ok(new { name = _configuration.UserName , token = _configuration.Token });
        }
    }
}
