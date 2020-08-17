using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private IProductSorter _productSorter;

        public TechChallengeController(IOptions<WooliesX> configuration, IProductSorter productSorter)
        {
            _configuration = configuration?.Value;
            _productSorter = productSorter;
        }

        [HttpGet("user")]
        public IActionResult Get()
        {
            return Ok(new { name = _configuration.UserName , token = _configuration.Token });
        }

        [HttpGet("sort")]
        public async Task<IActionResult> SortProduct([FromQuery, Required]string sortOption)
        {
            return Ok(await _productSorter.SortProduct(sortOption));
        }
    }
}
