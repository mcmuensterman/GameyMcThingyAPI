using GameyMcThingy.Models.Game;

namespace GameyMcThingy.Services.Game
{
    public interface IGameService
    {
        Task<bool> CreateGameAsync(GameCreate request);
        Task<IEnumerable<GameListItem>> GetAllGamesAsync();
        Task<GameDetail> GetGameByIdAsync(int gameId);

        Task<bool> UpdateGameAsync(GameUpdate request);
        Task<bool> DeleteGameAsync(int gameId);
    }
}