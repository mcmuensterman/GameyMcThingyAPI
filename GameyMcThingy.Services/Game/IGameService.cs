using GameyMcThingy.Models.Game;

namespace GameyMcThingy.Services.Game
{
    public interface IGameService
    {
        Task<bool> CreateGameAsnyc(GameCreate request);
        Task<IEnumerable<GameListItem>> GetAllGamesAsync();
        Task<GameDetail> GetGameByIdAsync(int GameId);
    }
}