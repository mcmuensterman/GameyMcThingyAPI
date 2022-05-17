using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GameyMcThingy.Models.Game;
using GameyMcThingy.Data;
using GameyMcThingy.Data.Entities;

namespace GameyMcThingy.Services.Game
{
    public class GameService : IGameService
    {
        public Task<bool> CreateGameAsnyc(GameCreate request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GameListItem>> GetAllGamesAsync()
        {
            var games = await _dbContext.Notes
                .Where(entity => entity.OwnerId == _userId)
                .Select(entity => new GameListItem)
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
            var GameEntity = new GameEntity
            {
                Title = request.Title,
                Manufacturer = request.Manufacturer
            };

            _dbContext.Games.Add(GameEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<GameDetail> GetGameByIdAsync(int GameId)
        {
            // Find the first game that has the given Id and OwnerId that matches the requesting UserID
            var gameEntity = await _dbContext.Games
                .FirstOrDefaultASync(e => e.Id == noteId && e.OwnerId == _userId
                );

            // If GameEntity is null then return null, othewrwise intialize and return a new GameDetail
            return gameEntity is null ? null : new GameDetail
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

            var numberOfChanges = await _dbContext.SaveChangesASync();

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