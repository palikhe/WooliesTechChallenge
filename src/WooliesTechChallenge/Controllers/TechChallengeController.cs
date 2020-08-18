using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Configuration;
using WooliesTechChallenge.Service.Domain;
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
            return Ok(await _productSorter.SortProducts(sortOption));
        }

        [HttpPost]
        [Route("trolleyTotal")]
        public async Task<IActionResult> TrolleyTotal(TrolleyRequest request)
        {
            //foreach (var special in request.Specials.SelectMany(x => x.Quantities))
            //{
            //    if (!(request.Quantities.Where(x => x.Name == special.Name)?.Count() >= special.Quantity))
            //    {
            //        return false;
            //    }
            //}

            request.Quantities.Where(x => x.Name == "Test Product D").FirstOrDefault().Quantity = 1;

            return Ok(await Task.FromResult(request));
        }
    }
}
