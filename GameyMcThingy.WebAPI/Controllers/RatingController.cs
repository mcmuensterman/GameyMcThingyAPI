using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Data.Entities;
using GameyMcThingy.Models.Rating;
using GameyMcThingy.Services.Rating;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameyMcThingy.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // GET api/Note or Ratings
        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetAllRatings([FromRoute] int userId)
        {
            var ratings = await _ratingService.GetAllRatingsAsync(userId);
            return Ok(ratings);

        }

        [HttpPost]
        public async Task<IActionResult> AddRatingToGame([FromBody] RatingModel model)
        {

			if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ratingResult = await _ratingService.CreateGameRatingAsync(model);
            if(ratingResult)
            {
                return Ok("Rating was posted.");
            }

            return BadRequest("Rating could not be posted.");
        }
    }
}
