using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vintri.Models;
using vintri.Services;

namespace vintri.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerRatingService ratingService;

        public BeerController(ILogger<BeerController> logger, IBeerRatingService ratingService)
        {
            this.ratingService = ratingService;
        }
        [Route("List")]
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<IActionResult> GetAsync(string name = null)
        {
            List<Beer> result;
            try
            {
                result = await ratingService.ListBeerByName(name);
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            return Ok(result);
        }

        [Route("Rate")]
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Rate(int id, [FromBody] UserRatingDetail userRating)
        {
            try
            {
                await ratingService.RateBeer(id, userRating);
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }

            return Ok();
        }
    }
}
