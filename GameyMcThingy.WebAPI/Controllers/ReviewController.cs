using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameyMcThingy.Models;
using GameyMcThingy.Services.Review;

namespace GameyMcThingy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }
        

        [HttpPost]
        public async Task<IActionResult> AddReviewToGame([FromBody] ReviewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviewResult = await _reviewService.AddReviewToGame(model);
            if(reviewResult)
            {
                return Ok("Review was posted.");
            }

            return BadRequest("Review could not be posted.");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}