using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GameyMcThingy.Models.Game;
using GameyMcThingy.Data;
using GameyMcThingy.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;



namespace GameyMcThingy.Services.Game
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;
        public GameService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build GameService without User Id Claim.");

            _dbContext = dbContext;

        }

        public async Task<IEnumerable<GameListItem>> GetAllGamesAsync()
        {
            var games = await _dbContext.Games
                .Where(entity => entity.OwnerId == _userId)
                .Select(entity => new GameListItem
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Manufacturer = entity.Manufacturer
                })
                .ToListAsync();

            return games;
        }

        public async Task<bool> CreateGameAsync(GameCreate request)
        {
            var gameEntity = new GameEntity
            {
                Title = request.Title,
                Manufacturer = request.Manufacturer,
                OwnerId = _userId
            };

            _dbContext.Games.Add(gameEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<GameDetail> GetGameByIdAsync(int gameId)
        {
            // Find the first game that has the given Id and OwnerId that matches the requesting UserID
            var gameEntity = await _dbContext.Games
                .FirstOrDefaultAsync(e => e.Id == gameId && e.OwnerId == _userId
                );

            // If GameEntity is null then return null, othewrwise intialize and return a new GameDetail
            return new GameDetail
            {
                Id = gameEntity.Id,
                Title = gameEntity.Title,
                Manufacturer = gameEntity.Manufacturer
            };
        }

        public async Task<bool> UpdateGameAsync(GameUpdate request)
        {
            // Find the game and validate it's owned by the user
            var gameEntity = await _dbContext.Games.FindAsync(request.Id);

            // By using the null conditional operator we can check if it's null at the same time we check the OwnerId
            if (gameEntity?.OwnerId != _userId)
                return false;

            gameEntity.Title = request.Title;
            gameEntity.Manufacturer = request.Manufacturer;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteGameAsync(int gameId)
        {
            // Find Game by the given Id
            var gameEntity = await _dbContext.Games.FindAsync(gameId);

            // Validate the Game exists and is owned by the owner
            if (gameEntity?.OwnerId != _userId)
                return false;

            // Remove the game from the DbContext and assert that the one change was saved.
            _dbContext.Games.Remove(gameEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }


    }
}