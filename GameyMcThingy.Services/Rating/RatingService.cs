using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GameyMcThingy.Data;
using GameyMcThingy.Models.Rating;
using Microsoft.AspNetCore.Http;
using GameyMcThingy.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameyMcThingy.Services.Rating
{
	public class RatingService : IRatingService
	{
		private readonly int _userId;  
		private readonly ApplicationDbContext _dbContext;
		public RatingService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
		{
			var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
			var value = userClaims.FindFirst("Id")?.Value;
			var validId = int.TryParse(value, out _userId);
			if (!validId)
				throw new Exception("Attempted to build RatingService without User Id claim.");

			_dbContext = dbContext;
		}

		public async Task<IEnumerable<RatingListItem>> GetAllRatingsAsync(int gameId)
		{
			var ratings = await _dbContext.Ratings
			.Where(entity => entity.OwnerId == gameId)
			.Select(entity => new RatingListItem
			{
				RatingId = entity.RatingId,
				Score = entity.Score,
                GameId = entity.GameId,
				CreatedUtc = entity.CreatedUtc
			}) 
			.ToListAsync();

			return ratings;
		}

		public async Task<bool> CreateGameRatingAsync(RatingModel model)
        {
            var entity = new RatingEntity()
            {
                GameId = model.GameId,
				Score = model.Score,
				CreatedUtc = model.CreatedUtc
            };

			_dbContext.Ratings.Add(entity);
			
			var numberOfChanges = await _dbContext.SaveChangesAsync();
			return numberOfChanges == 1;
        }

	}
}