using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameyMcThingy.WebAPI.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
        // private readonly IUserService _userService;
        // private readonly ITokenService _tokenService;

        // public RatingController(IUserService userService, ITokenService tokenService)
        // {
        //     _context = context;
        //     _logger = logger;
        // }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }

        // [HttpPost]
        // public async Task<IActionResult> RateGame([FromForm] Rating model) 
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //      _context.Ratings.Add(new Rating() {
        //         Score = model.Score,
        //         GameId = model.Game,
        //      });

        //      await _context.SaveChangesAsync();

        //      return Ok();
        // }
    }
}