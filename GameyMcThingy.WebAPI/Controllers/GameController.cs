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
        private readonly GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _gameService.CreateGameAsync(request))
                return Ok("Game created successfully.");
            return BadRequest("Game could not be created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        // Get api/Game/5
        [HttpGet("gameId:int")]
        public async Task<IActionResult> GetGameById([FromRoute] int gameId)
        {
            var detail = await _gameService.GetGameByIdAsync(gameId);

            // Similar to our service method, we're using a ternary to determine our return type
            // If the returned value (detail) is not null, return it with a 200 OK
            // Otherwise return a NotFound() 404 response
            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNoteById([FromBody] GameUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _gameService.UpdateGameAsync(request)
            ? Ok("Game updated successfully.")
            : BadRequest("Game Could not be updated.");
        }

        // Delete api/Note/5
        [HttpDelete("{gameId:int}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int gameId)
        {
            return await _gameService.DeleteGameAsync(gameId)
            ? Ok($"Game {gameId} was deleted successfully.")
            : BadRequest($"Game {gameId} could not be deleted.");
        }
    }
}