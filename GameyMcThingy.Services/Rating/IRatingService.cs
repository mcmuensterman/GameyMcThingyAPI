using System.Collections.Generic;
using System.Threading.Tasks;
using GameyMcThingy.Models.Rating;

namespace GameyMcThingy.Services.Rating
{
    public interface IRatingService
    {
         Task<IEnumerable<RatingListItem>> GetAllRatingsAsync(int userId);
         Task<bool> CreateGameRatingAsync(RatingModel model);
    }
}