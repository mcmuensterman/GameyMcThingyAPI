using Microsoft.AspNetCore.Mvc;
using GameyMcThingy.Services.User;
using GameyMcThingy.Models.User;
using Microsoft.AspNetCore.Authorization;
using GameyMcThingy.Models.Token;
using GameyMcThingy.Services.Token;
using GameyMcThingy.Services.Game;
using GameyMcThingy.Models.Game;

namespace GameyMcThingy.WebAPI.Controllers
{
    //! This may not work until I do section 15.03 but it's witchcraft
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _gameService.CreateGameAsnyc(request))
                return Ok("Game created successfully.");
            return BadRequest("Game could not be created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }
    }
}