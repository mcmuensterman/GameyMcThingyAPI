using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GameyMcThingy.Models.Game;
using GameyMcThingy.Data;

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


    }
}